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
public class RP_STK_MOVE : Form
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
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DataGridViewX _DGV_VCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDesign")]
	private QButton _BtnDesign;

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
	[AccessedThroughProperty("BtnSize")]
	private QButton _BtnSize;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private bool DgvLoad;

	private string RptDisplay;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string StkType;

	private string CurRpt;

	private double[] TotPcs;

	private string DgvRptType;

	private const int cSrNo1 = 0;

	private const int cItCode1 = 1;

	private const int cItName1 = 2;

	private const int cWeight1 = 3;

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

	private const int cFine = 10;

	private const int cSign = 11;

	private const int cBookCode = 12;

	private const int cBookName = 13;

	private const int cItCode = 14;

	private const int cAcCode = 15;

	private const int czSrNo = 0;

	private const int czBookType = 1;

	private const int czLdAcName = 2;

	private const int czVchNo = 3;

	private const int czVchDate = 4;

	private const int czTagNo = 5;

	private const int czItemName = 6;

	private const int czDesignNo = 7;

	private const int czSize = 8;

	private const int czPcs = 9;

	private const int czGrWt = 10;

	private const int czNetWt = 11;

	private const int czFine = 12;

	private const int czSign = 13;

	private const int czBookCode = 14;

	private const int czBookName = 15;

	private const int czItCode = 16;

	private const int czAcCode = 17;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_CellContentClick);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).CellContentClick -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).CellContentClick += val2;
				((Control)val3).DoubleClick += eventHandler;
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

	internal virtual DataGridViewX DGV_VCH
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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_VCH_CellContentClick);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			DataGridViewX val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).CellContentClick -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV_VCH = value;
			val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).CellContentClick += val2;
				((Control)val3).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual QButton BtnDesign
	{
		[CompilerGenerated]
		get
		{
			return _BtnDesign;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDesign_Click;
			QButton val = _BtnDesign;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDesign = value;
			val = _BtnDesign;
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

	internal virtual QButton BtnSize
	{
		[CompilerGenerated]
		get
		{
			return _BtnSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSize_Click;
			QButton val = _BtnSize;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSize = value;
			val = _BtnSize;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrName")]
	private virtual TextBox _tGrName;

	internal virtual TextBox tGrName
	{
		get
		{
			return _tGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tGrName = value;
		}
	}

	internal virtual TextBox tGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGrCode_KeyDown);
			EventHandler eventHandler = tGrCode_LostFocus;
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).LostFocus -= eventHandler;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).LostFocus += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrName")]
	private virtual TextBox _tPrName;

	internal virtual TextBox tPrName
	{
		get
		{
			return _tPrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPrName = value;
		}
	}

	internal virtual TextBox tPrCode
	{
		[CompilerGenerated]
		get
		{
			return _tPrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrCode_KeyDown);
			EventHandler eventHandler = tPrCode_LostFocus;
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).LostFocus -= eventHandler;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).LostFocus += eventHandler;
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
	[AccessedThroughProperty("tDesignNo")]
	private virtual TextBox _tDesignNo;

	internal virtual TextBox tDesignNo
	{
		get
		{
			return _tDesignNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tDesignNo = value;
		}
	}

	public int newindex { get; set; }

	public RP_STK_MOVE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_STK_MOVE_Load;
		((Form)this).Deactivate += RP_STK_MOVE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_STK_MOVE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_STK_MOVE_KeyDown);
		((Form)this).Activated += RP_STK_MOVE_Activated;
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
		//IL_08de: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Expected O, but got Unknown
		//IL_0956: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Expected O, but got Unknown
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a39: Expected O, but got Unknown
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Expected O, but got Unknown
		//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b60: Expected O, but got Unknown
		//IL_0c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4c: Expected O, but got Unknown
		//IL_0cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbf: Expected O, but got Unknown
		//IL_0d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d77: Expected O, but got Unknown
		//IL_0de0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dea: Expected O, but got Unknown
		//IL_0f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5b: Expected O, but got Unknown
		//IL_0ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1001: Expected O, but got Unknown
		//IL_1087: Unknown result type (might be due to invalid IL or missing references)
		//IL_1091: Expected O, but got Unknown
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_1182: Expected O, but got Unknown
		//IL_11eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f5: Expected O, but got Unknown
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1519: Unknown result type (might be due to invalid IL or missing references)
		//IL_1523: Expected O, but got Unknown
		//IL_1546: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c6: Expected O, but got Unknown
		//IL_165a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1664: Expected O, but got Unknown
		//IL_16e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f1: Expected O, but got Unknown
		//IL_1989: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a28: Expected O, but got Unknown
		//IL_1a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac9: Expected O, but got Unknown
		//IL_1b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b55: Expected O, but got Unknown
		//IL_1bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bdd: Expected O, but got Unknown
		//IL_1c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c69: Expected O, but got Unknown
		//IL_1cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce0: Expected O, but got Unknown
		//IL_1d7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d87: Expected O, but got Unknown
		//IL_1e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e2e: Expected O, but got Unknown
		//IL_1e9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea6: Expected O, but got Unknown
		//IL_1f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4d: Expected O, but got Unknown
		//IL_1ff3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffd: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_STK_MOVE));
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
		DGV = new DataGridViewX();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		DGV_VCH = new DataGridViewX();
		BtnDesign = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		BtnSize = new QButton();
		tGrName = new TextBox();
		tGrCode = new TextBox();
		tPrName = new TextBox();
		tPrCode = new TextBox();
		Label4 = new Label();
		Label1 = new Label();
		tTagNo = new TextBox();
		Label5 = new Label();
		Label6 = new Label();
		tDesignNo = new TextBox();
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
		lblBook.Text = "Stock Move Report";
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
		((Control)DGV).Location = new Point(10, 13);
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
		((Control)DGV).Size = new Size(1160, 423);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 2;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(314, 46);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(109, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(230, 46);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(79, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.PeachPuff;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Controls.Add((Control)(object)DGV_VCH);
		((Control)Panel1).Location = new Point(0, 113);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 451);
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
		((QControl)BtnDesign).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDesign).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDesign).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDesign).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDesign).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDesign).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDesign).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDesign).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDesign).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDesign).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDesign).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDesign).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDesign).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDesign).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDesign.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Image = null;
		((QControl)BtnDesign).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDesign).Location = new Point(852, 79);
		((Control)BtnDesign).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDesign).Name = "BtnDesign";
		((Control)BtnDesign).Size = new Size(143, 37);
		((Control)BtnDesign).TabIndex = 8;
		BtnDesign.Text = "&Sales";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(68, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(154, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 45);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(48, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "Date";
		Label2.TextAlign = (ContentAlignment)64;
		((QControl)BtnSize).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSize).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSize).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSize).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSize).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSize).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSize).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSize).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSize).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSize).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSize).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSize).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSize).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSize).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSize.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Image = null;
		((QControl)BtnSize).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSize).Location = new Point(1011, 79);
		((Control)BtnSize).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSize).Name = "BtnSize";
		((Control)BtnSize).Size = new Size(143, 37);
		((Control)BtnSize).TabIndex = 9;
		BtnSize.Text = "Tag Stock";
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		((Control)tGrName).Font = new Font("Tahoma", 9f);
		((Control)tGrName).Location = new Point(543, 80);
		((TextBoxBase)tGrName).MaxLength = 50;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(140, 22);
		((Control)tGrName).TabIndex = 1178;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(492, 80);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(48, 22);
		((Control)tGrCode).TabIndex = 1177;
		((TextBoxBase)tPrName).BackColor = Color.PapayaWhip;
		((Control)tPrName).Font = new Font("Tahoma", 9f);
		((Control)tPrName).Location = new Point(543, 46);
		((TextBoxBase)tPrName).MaxLength = 50;
		((Control)tPrName).Name = "tPrName";
		((Control)tPrName).Size = new Size(140, 22);
		((Control)tPrName).TabIndex = 1176;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(492, 46);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(48, 22);
		((Control)tPrCode).TabIndex = 1175;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(432, 80);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(49, 20);
		((Control)Label4).TabIndex = 1174;
		Label4.Text = "Group";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(256, 80);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(53, 20);
		((Control)Label1).TabIndex = 1173;
		Label1.Text = "TagNo";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(314, 78);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(109, 22);
		((Control)tTagNo).TabIndex = 1171;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(432, 46);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(57, 20);
		((Control)Label5).TabIndex = 1172;
		Label5.Text = "PrCode";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(3, 77);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(57, 20);
		((Control)Label6).TabIndex = 1180;
		Label6.Text = "Design";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label6).Visible = false;
		((Control)tDesignNo).Font = new Font("Tahoma", 9f);
		((Control)tDesignNo).Location = new Point(68, 78);
		((TextBoxBase)tDesignNo).MaxLength = 15;
		((Control)tDesignNo).Name = "tDesignNo";
		((Control)tDesignNo).Size = new Size(162, 22);
		((Control)tDesignNo).TabIndex = 1179;
		((Control)tDesignNo).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tDesignNo);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tTagNo);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)BtnDesign);
		((Control)this).Controls.Add((Control)(object)BtnSize);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_STK_MOVE";
		((Form)this).Text = "Stock Move Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		Weight_ColSet();
	}

	private void Weight_ColSet()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected O, but got Unknown
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		DC_Main.ExeQuteDc("UPDATE MAIN_STOCK SET ITM_SIZE = '' WHERE ITM_SIZE Is NULL");
		DataGridViewX dGV = DGV;
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV_VCH).ColumnCount = 3;
		checked
		{
			if (Operators.CompareString(CurRpt, "Deisgn Move", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.ITM_SIZE AS ItSize FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND A.TAG_NO <> 'N' AND A.ITM_SIZE <> ''  ";
				if (Operators.CompareString(tPrCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
				}
				if (Operators.CompareString(tGrCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
				}
				if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
				}
				DC_Main.RsQry += "GROUP BY A.ITM_SIZE HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) > 0 ORDER BY A.ITM_SIZE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					TotPcs = new double[DC_Main.Tbl.Rows.Count + 4 + 1];
				}
				((DataGridView)DGV).Columns.Add("", "Sr");
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
				((DataGridView)DGV).Columns.Add("", "ItCode");
				((DataGridView)DGV).Columns[1].Visible = false;
				((DataGridView)DGV).Columns.Add("", "Name");
				((DataGridView)DGV).Columns[2].Width = (int)Math.Round(230.0 * ColCon);
				DC_Main.i = 3;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					((DataGridView)DGV).Columns.Add("", Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["ItSize"], (object)"")));
					((DataGridView)DGV).Columns[DC_Main.i].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					DC_Main.i++;
					DC_Main.M++;
				}
				((DataGridView)DGV).Columns.Add("", "Total");
				((DataGridView)DGV).Columns[DC_Main.i].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				DC_Main.Tbl.Clear();
			}
			else
			{
				DC_Main.RsQry = "SELECT COL_NAME FROM WEIGHT_MAST ORDER BY SR_NO";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					TotPcs = new double[DC_Main.Tbl.Rows.Count + 4 + 1];
				}
				((DataGridView)DGV).Columns.Add("", "Sr");
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
				((DataGridView)DGV).Columns.Add("", "ItCode");
				((DataGridView)DGV).Columns[1].Visible = false;
				((DataGridView)DGV).Columns.Add("", "ItName");
				((DataGridView)DGV).Columns[2].Width = (int)Math.Round(230.0 * ColCon);
				DC_Main.i = 3;
				int num2 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					((DataGridView)DGV).Columns.Add("", Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["COL_NAME"]));
					((DataGridView)DGV).Columns[DC_Main.i].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					DC_Main.i++;
					DC_Main.M++;
				}
				((DataGridView)DGV).Columns.Add("", "Total");
				((DataGridView)DGV).Columns[DC_Main.i].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				DC_Main.Tbl.Clear();
			}
			dGV = null;
		}
	}

	private void BtnSize_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Deisgn Move", false) == 0)
		{
			DGV_CLEAR();
			RptDisplay = "Design";
			DesignSizeStk();
		}
		else
		{
			DGV_CLEAR();
			RptDisplay = "Tag Stock";
			StockMove();
		}
	}

	private void DesignSizeStk()
	{
		if (Operators.CompareString(RptDisplay, "Item", false) == 0)
		{
			DC_Main.RsQry = "SELECT B.IT_CODE AS ItCode,C.IT_NAME AS DesignNo,B.ITM_SIZE,  SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE -1 END) AS  SizPcs  FROM (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE And A.TAG_NO = B.TAG_NO And A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  ";
		}
		else
		{
			DC_Main.RsQry = "SELECT B.DESIGN_NO AS ItName,B.DESIGN_NO AS DesignNo,B.ITM_SIZE,  SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE -1 END) AS  SizPcs  FROM (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE And A.TAG_NO = B.TAG_NO And A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  ";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE =  '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE =  '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
		}
		if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.DESIGN_NO =  '" + tDesignNo.Text + "'";
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'";
			}
		}
		if (Operators.CompareString(RptDisplay, "Item", false) == 0)
		{
			DC_Main.RsQry += " GROUP BY B.IT_CODE,C.IT_NAME,B.ITM_SIZE HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE - 1 END) > 0 ORDER BY C.IT_NAME,B.IT_CODE,B.ITM_SIZE";
		}
		else
		{
			DC_Main.RsQry += " GROUP BY B.DESIGN_NO,B.ITM_SIZE HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE - 1 END) > 0 ORDER BY B.DESIGN_NO,B.ITM_SIZE";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = "abcdef";
		double num = 0.0;
		string text2 = "abcdef";
		int num2 = 0;
		DC_Main.R = -1;
		DC_Main.M = 0;
		checked
		{
			int num3 = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num3)
			{
				DataGridViewX dGV = DGV;
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DesignNo"], (object)""), (object)text, false))
				{
					text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DesignNo"], (object)""));
					num = 0.0;
					DC_Main.R++;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					if (Operators.CompareString(RptDisplay, "Item", false) == 0)
					{
						((DataGridView)dGV)[1, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["ItCode"], (object)"");
					}
					else
					{
						((DataGridView)dGV)[1, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DesignNo"], (object)"");
					}
					((DataGridView)dGV)[2, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DesignNo"], (object)"");
					if (DC_Main.R >= 0)
					{
						int num4 = ((BaseCollection)((DataGridView)dGV).Columns).Count - 2;
						DC_Main.X = 3;
						while (DC_Main.X <= num4)
						{
							num2 = DC_Main.X;
							text2 = ((DataGridView)DGV).Columns[num2].HeaderText;
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_SIZE"], (object)""), (object)text2, false))
							{
								((DataGridView)dGV)[num2, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["SizPcs"], (object)""));
								num += Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["SizPcs"], (object)""));
								break;
							}
							DC_Main.X++;
						}
						((DataGridView)dGV)[((BaseCollection)((DataGridView)dGV).Columns).Count - 1, DC_Main.R].Value = num;
					}
				}
				else
				{
					if (DC_Main.R >= 0)
					{
						int num5 = ((BaseCollection)((DataGridView)dGV).Columns).Count - 2;
						DC_Main.X = 3;
						while (DC_Main.X <= num5)
						{
							num2 = DC_Main.X;
							text2 = ((DataGridView)DGV).Columns[num2].HeaderText;
							string text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_SIZE"], (object)""));
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_SIZE"], (object)""), (object)text2, false))
							{
								((DataGridView)dGV)[num2, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["SizPcs"], (object)""));
								num += Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["SizPcs"], (object)""));
								break;
							}
							DC_Main.X++;
						}
					}
					((DataGridView)dGV)[((BaseCollection)((DataGridView)dGV).Columns).Count - 1, DC_Main.R].Value = num;
				}
				dGV = null;
				DC_Main.M++;
			}
			DC_Main.Rshlp.Clear();
			int num6 = 0;
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV).Rows.Add();
			DC_Main.R = ((DataGridView)DGV).Rows.Count - 1;
			((DataGridView)DGV)[2, DC_Main.R].Value = "Total :";
			double num7 = 0.0;
			int num8 = ((BaseCollection)((DataGridView)DGV).Columns).Count - 2;
			DC_Main.M = 3;
			while (DC_Main.M <= num8)
			{
				num6 = 0;
				int num9 = ((DataGridView)DGV).Rows.Count - 2;
				DC_Main.X = 0;
				while (DC_Main.X <= num9)
				{
					num6 = (int)Math.Round((double)num6 + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[DC_Main.M, DC_Main.X].Value)));
					DC_Main.X++;
				}
				((DataGridView)DGV)[DC_Main.M, DC_Main.X].Value = num6;
				num7 += (double)num6;
				DC_Main.M++;
			}
			((DataGridView)DGV)[((BaseCollection)((DataGridView)DGV).Columns).Count - 1, DC_Main.R].Value = num7;
			StkType = "Stock";
		}
	}

	private void BtnDesign_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Deisgn Move", false) == 0)
		{
			DGV_CLEAR();
			RptDisplay = "Item";
			DesignSizeStk();
		}
		else
		{
			DGV_CLEAR();
			RptDisplay = "Sales";
			StockMove();
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (Operators.CompareString(DgvRptType, "TagWise", false) != 0)
		{
		}
	}

	private void StockMove()
	{
		//IL_2b64: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b6e: Expected O, but got Unknown
		if (Operators.CompareString(RptDisplay, "Tag Stock", false) == 0)
		{
			DC_Main.RsQry = "SELECT C.IT_NAME AS ItName,A.IT_CODE AS ItCode,A.TAG_NO,B.ITM_GWT,  SUM(CASE WHEN A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 1 THEN A.ITM_PCS ELSE 0 END) AS  A,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 2 THEN A.ITM_PCS ELSE 0 END) AS  B, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 3 THEN A.ITM_PCS ELSE 0 END) AS  C,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 4 THEN A.ITM_PCS ELSE 0 END) AS  D, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 5 THEN A.ITM_PCS ELSE 0 END) AS  E,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 6 THEN A.ITM_PCS ELSE 0 END) AS  F, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 7 THEN A.ITM_PCS ELSE 0 END) AS  G,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 8 THEN A.ITM_PCS ELSE 0 END) AS  H, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 9 THEN A.ITM_PCS ELSE 0 END) AS  I,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 10 THEN A.ITM_PCS ELSE 0 END) AS J, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 11 THEN A.ITM_PCS ELSE 0 END) AS  K,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 12 THEN A.ITM_PCS ELSE 0 END) AS  L, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 13 THEN A.ITM_PCS ELSE 0 END) AS  M,   SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 14 THEN A.ITM_PCS ELSE 0 END) AS  N, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 15 THEN A.ITM_PCS ELSE 0 END) AS  O,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 16 THEN A.ITM_PCS ELSE 0 END) AS  P, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 17 THEN A.ITM_PCS ELSE 0 END) AS  Q,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 18 THEN A.ITM_PCS ELSE 0 END) AS  R, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 19 THEN A.ITM_PCS ELSE 0 END) AS  S,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 20 THEN A.ITM_PCS ELSE 0 END) AS  T, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 21 THEN A.ITM_PCS ELSE 0 END) AS  U,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 22 THEN A.ITM_PCS ELSE 0 END) AS  V, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 23 THEN A.ITM_PCS ELSE 0 END) AS  W,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 24 THEN A.ITM_PCS ELSE 0 END) AS  X, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 25 THEN A.ITM_PCS ELSE 0 END) AS  Y,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 26 THEN A.ITM_PCS ELSE 0 END) AS  AA, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 27 THEN A.ITM_PCS ELSE 0 END) AS  BB,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 28 THEN A.ITM_PCS ELSE 0 END) AS  CC, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 29 THEN A.ITM_PCS ELSE 0 END) AS  DD,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 30 THEN A.ITM_PCS ELSE 0 END) AS  EE, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 31 THEN A.ITM_PCS ELSE 0 END) AS  FF,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 32 THEN A.ITM_PCS ELSE 0 END) AS  GG, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 33 THEN A.ITM_PCS ELSE 0 END) AS  HH,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 34 THEN A.ITM_PCS ELSE 0 END) AS  II, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT And A.ITM_GWT <= D.HIGH_WT And D.SR_NO = 35 THEN A.ITM_PCS ELSE 0 END) AS  JJ,  SUM(CASE WHEN A.ITM_GWT > D.HIGH_WT And D.SR_NO = 36 THEN A.ITM_PCS ELSE 0 END) AS  Z  FROM ((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE And A.TAG_NO = B.TAG_NO And A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE)LEFT JOIN WEIGHT_MAST AS D ON A.CO_CODE = '" + DC_Main.MCo_code + "'  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  ";
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'";
				}
			}
			DC_Main.RsQry += " GROUP BY C.IT_NAME,A.IT_CODE,A.TAG_NO,B.ITM_GWT HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN 1 ELSE - 1 END) > 0 ORDER BY C.IT_NAME,B.ITM_GWT";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(RptDisplay, "Sales", false) == 0)
		{
			DC_Main.RsQry = "SELECT C.IT_NAME AS ItName,A.IT_CODE AS ItCode,A.TAG_NO,B.ITM_GWT,  SUM(CASE WHEN A.ITM_GWT < = D.HIGH_WT AND D.SR_NO = 1 THEN A.ITM_PCS ELSE 0 END) AS  A,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 2 THEN A.ITM_PCS ELSE 0 END) AS  B, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 3 THEN A.ITM_PCS ELSE 0 END) AS  C,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 4 THEN A.ITM_PCS ELSE 0 END) AS  D, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 5 THEN A.ITM_PCS ELSE 0 END) AS  E,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 6 THEN A.ITM_PCS ELSE 0 END) AS  F, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 7 THEN A.ITM_PCS ELSE 0 END) AS  G,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 8 THEN A.ITM_PCS ELSE 0 END) AS  H, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 9 THEN A.ITM_PCS ELSE 0 END) AS  I,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 10 THEN A.ITM_PCS ELSE 0 END) AS J, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 11 THEN A.ITM_PCS ELSE 0 END) AS  K,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 12 THEN A.ITM_PCS ELSE 0 END) AS  L, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 13 THEN A.ITM_PCS ELSE 0 END) AS  M,   SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 14 THEN A.ITM_PCS ELSE 0 END) AS  N, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 15 THEN A.ITM_PCS ELSE 0 END) AS  O,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 16 THEN A.ITM_PCS ELSE 0 END) AS  P, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 17 THEN A.ITM_PCS ELSE 0 END) AS  Q,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 18 THEN A.ITM_PCS ELSE 0 END) AS  R, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 19 THEN A.ITM_PCS ELSE 0 END) AS  S,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 20 THEN A.ITM_PCS ELSE 0 END) AS  T, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 21 THEN A.ITM_PCS ELSE 0 END) AS  U,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 22 THEN A.ITM_PCS ELSE 0 END) AS  V, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 23 THEN A.ITM_PCS ELSE 0 END) AS  W,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 24 THEN A.ITM_PCS ELSE 0 END) AS  X, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 25 THEN A.ITM_PCS ELSE 0 END) AS  Y,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 26 THEN A.ITM_PCS ELSE 0 END) AS  AA, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 27 THEN A.ITM_PCS ELSE 0 END) AS  BB,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 28 THEN A.ITM_PCS ELSE 0 END) AS  CC, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 29 THEN A.ITM_PCS ELSE 0 END) AS  DD,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 30 THEN A.ITM_PCS ELSE 0 END) AS  EE, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 31 THEN A.ITM_PCS ELSE 0 END) AS  FF,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 32 THEN A.ITM_PCS ELSE 0 END) AS  GG, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 33 THEN A.ITM_PCS ELSE 0 END) AS  HH,  SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 34 THEN A.ITM_PCS ELSE 0 END) AS  II, SUM(CASE WHEN A.ITM_GWT > D.LOW_WT and A.ITM_GWT <= D.HIGH_WT AND D.SR_NO = 35 THEN A.ITM_PCS ELSE 0 END) AS  JJ,  SUM(CASE WHEN A.ITM_GWT > D.HIGH_WT AND D.SR_NO = 36 THEN A.ITM_PCS ELSE 0 END) AS  Z  FROM ((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE)LEFT JOIN WEIGHT_MAST AS D ON A.CO_CODE = '" + DC_Main.MCo_code + "'  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N' AND A.ITM_SIGN = '-'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  ";
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'";
				}
			}
			DC_Main.RsQry += " GROUP BY C.IT_NAME,A.IT_CODE,A.TAG_NO,B.ITM_GWT  ORDER BY C.IT_NAME,B.ITM_GWT";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		string text = "";
		double num = 0.0;
		DC_Main.R = -1;
		checked
		{
			int num2 = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.M = 0;
			double num50 = default(double);
			double num51 = default(double);
			double num56 = default(double);
			double num57 = default(double);
			double num32 = default(double);
			double num33 = default(double);
			double num6 = default(double);
			double num7 = default(double);
			double num60 = default(double);
			double num61 = default(double);
			double num54 = default(double);
			double num55 = default(double);
			double num18 = default(double);
			double num19 = default(double);
			double num72 = default(double);
			double num73 = default(double);
			double num38 = default(double);
			double num39 = default(double);
			double num24 = default(double);
			double num25 = default(double);
			double num74 = default(double);
			double num75 = default(double);
			double num68 = default(double);
			double num69 = default(double);
			double num42 = default(double);
			double num43 = default(double);
			double num36 = default(double);
			double num37 = default(double);
			double num20 = default(double);
			double num21 = default(double);
			double num14 = default(double);
			double num15 = default(double);
			double num66 = default(double);
			double num67 = default(double);
			double num62 = default(double);
			double num63 = default(double);
			double num48 = default(double);
			double num49 = default(double);
			double num44 = default(double);
			double num45 = default(double);
			double num30 = default(double);
			double num31 = default(double);
			double num26 = default(double);
			double num27 = default(double);
			double num12 = default(double);
			double num13 = default(double);
			double num8 = default(double);
			double num9 = default(double);
			double num70 = default(double);
			double num71 = default(double);
			double num64 = default(double);
			double num65 = default(double);
			double num58 = default(double);
			double num59 = default(double);
			double num52 = default(double);
			double num53 = default(double);
			double num46 = default(double);
			double num47 = default(double);
			double num40 = default(double);
			double num41 = default(double);
			double num34 = default(double);
			double num35 = default(double);
			double num28 = default(double);
			double num29 = default(double);
			double num22 = default(double);
			double num23 = default(double);
			double num16 = default(double);
			double num17 = default(double);
			double num10 = default(double);
			double num11 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			double num76 = default(double);
			while (DC_Main.M <= num2)
			{
				DataGridViewX dGV = DGV;
				if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.M]["ItCode"], (object)text, false))
				{
					text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["ItCode"], (object)""));
					DC_Main.R++;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ItCode"]);
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ItName"]);
					if (DC_Main.R >= 1)
					{
						int num3 = ((BaseCollection)((DataGridView)dGV).Columns).Count - 1;
						DC_Main.X = 3;
						while (DC_Main.X <= num3)
						{
							switch (DC_Main.X)
							{
							case 3:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num50, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num51 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 4:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num56, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num57 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 5:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num32, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num33 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 6:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num6, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 7:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num60, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num61 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 8:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num54, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num55 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 9:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num18, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num19 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 10:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num72, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num73 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 11:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num38, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num39 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 12:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num24, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num25 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 13:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num74, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num75 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 14:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num68, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num69 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 15:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num42, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num43 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 16:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num36, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num37 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 17:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num20, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 18:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num14, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num15 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 19:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num66, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num67 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 20:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num62, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num63 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 21:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num48, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num49 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 22:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num44, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num45 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 23:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num30, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num31 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 24:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num26, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num27 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 25:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num12, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num13 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 26:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num8, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 27:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num70, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num71 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 28:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num64, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num65 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 29:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num58, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num59 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 30:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num52, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num53 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 31:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num46, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num47 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 32:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num40, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num41 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 33:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num34, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num35 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 34:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num28, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num29 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 35:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num22, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 36:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num16, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 37:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num10, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							case 38:
								((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = Strings.Format((object)num4, "0");
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value)) == 0.0)
								{
									((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value = "";
								}
								num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[DC_Main.X, DC_Main.R - 1].Value));
								break;
							}
							DC_Main.X++;
						}
						((DataGridView)dGV)[39, DC_Main.R - 1].Value = Strings.Format((object)(num50 + num56 + num32 + num6 + num60 + num54 + num18 + num72 + num38 + num24 + num74 + num68 + num42 + num36 + num20 + num14 + num66 + num62 + num48 + num44 + num30 + num26 + num12 + num8 + num70 + num64 + num58 + num52 + num46 + num40 + num34 + num28 + num22 + num16 + num10 + num4), "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[39, DC_Main.R - 1].Value)) == 0.0)
						{
							((DataGridView)dGV)[39, DC_Main.R - 1].Value = "";
						}
						num76 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[39, DC_Main.R - 1].Value));
					}
					num50 = 0.0;
					num56 = 0.0;
					num32 = 0.0;
					num6 = 0.0;
					num60 = 0.0;
					num54 = 0.0;
					num18 = 0.0;
					num72 = 0.0;
					num38 = 0.0;
					num24 = 0.0;
					num74 = 0.0;
					num68 = 0.0;
					num42 = 0.0;
					num36 = 0.0;
					num20 = 0.0;
					num14 = 0.0;
					num66 = 0.0;
					num62 = 0.0;
					num48 = 0.0;
					num44 = 0.0;
					num30 = 0.0;
					num26 = 0.0;
					num12 = 0.0;
					num8 = 0.0;
					num70 = 0.0;
					num64 = 0.0;
					num58 = 0.0;
					num52 = 0.0;
					num46 = 0.0;
					num40 = 0.0;
					num34 = 0.0;
					num28 = 0.0;
					num22 = 0.0;
					num16 = 0.0;
					num10 = 0.0;
					num4 = 0.0;
					double num77 = 0.0;
				}
				if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["a"], (object)"")))
				{
					num50 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["b"], (object)"")))
				{
					num56 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["C"], (object)"")))
				{
					num32 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["D"], (object)"")))
				{
					num6 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["e"], (object)"")))
				{
					num60 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["F"], (object)"")))
				{
					num54 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["g"], (object)"")))
				{
					num18 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["h"], (object)"")))
				{
					num72 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["i"], (object)"")))
				{
					num38 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["J"], (object)"")))
				{
					num24 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["K"], (object)"")))
				{
					num74 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["L"], (object)"")))
				{
					num68 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["M"], (object)"")))
				{
					num42 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["n"], (object)"")))
				{
					num36 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["O"], (object)"")))
				{
					num20 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["P"], (object)"")))
				{
					num14 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["Q"], (object)"")))
				{
					num66 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["R"], (object)"")))
				{
					num62 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["S"], (object)"")))
				{
					num48 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["T"], (object)"")))
				{
					num44 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["u"], (object)"")))
				{
					num30 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["V"], (object)"")))
				{
					num26 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["W"], (object)"")))
				{
					num12 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["x"], (object)"")))
				{
					num8 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["y"], (object)"")))
				{
					num70 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["AA"], (object)"")))
				{
					num64 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["BB"], (object)"")))
				{
					num58 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["CC"], (object)"")))
				{
					num52 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DD"], (object)"")))
				{
					num46 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["EE"], (object)"")))
				{
					num40 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["FF"], (object)"")))
				{
					num34 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GG"], (object)"")))
				{
					num28 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["HH"], (object)"")))
				{
					num22 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["II"], (object)"")))
				{
					num16 += 1.0;
				}
				else if (Conversions.ToBoolean(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["JJ"], (object)"")))
				{
					num10 += 1.0;
				}
				else
				{
					num4 += 1.0;
				}
				dGV = null;
				DC_Main.M++;
			}
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DataGridViewX dGV2 = DGV;
			if (DC_Main.R >= 0)
			{
				int num78 = ((BaseCollection)((DataGridView)dGV2).Columns).Count - 1;
				DC_Main.X = 3;
				while (DC_Main.X <= num78)
				{
					switch (DC_Main.X)
					{
					case 3:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num50, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num51 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 4:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num56, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num57 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 5:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num32, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num33 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 6:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num6, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 7:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num60, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num61 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 8:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num54, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num55 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 9:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num18, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num19 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 10:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num72, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num73 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 11:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num38, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num39 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 12:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num24, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num25 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 13:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num74, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num75 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 14:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num68, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num69 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 15:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num42, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num43 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 16:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num36, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num37 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 17:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num20, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 18:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num14, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num15 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 19:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num66, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num67 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 20:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num62, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num63 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 21:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num48, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num49 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 22:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num44, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num45 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 23:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num30, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num31 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 24:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num26, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num27 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 25:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num12, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num13 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 26:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num8, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 27:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num70, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num71 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 28:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num64, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num65 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 29:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num58, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num59 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 30:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num52, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num53 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 31:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num46, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num47 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 32:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num40, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num41 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 33:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num34, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num35 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 34:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num28, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num29 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 35:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num22, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 36:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num16, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 37:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num10, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					case 38:
						((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = Strings.Format((object)num4, "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = "";
						}
						num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value));
						break;
					}
					DC_Main.X++;
				}
				((DataGridView)dGV2)[39, DC_Main.R].Value = Strings.Format((object)(num50 + num56 + num32 + num6 + num60 + num54 + num18 + num72 + num38 + num24 + num74 + num68 + num42 + num36 + num20 + num14 + num66 + num62 + num48 + num44 + num30 + num26 + num12 + num8 + num70 + num64 + num58 + num52 + num46 + num40 + num34 + num28 + num22 + num16 + num10 + num4), "0");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[39, DC_Main.R].Value)) == 0.0)
				{
					((DataGridView)dGV2)[39, DC_Main.R].Value = "";
				}
				num76 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[39, DC_Main.R].Value));
			}
			dGV2 = null;
			DC_Main.Rshlp.Clear();
			int num79 = 0;
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV).Rows.Add();
			DC_Main.R = ((DataGridView)DGV).Rows.Count - 1;
			((DataGridView)DGV)[2, DC_Main.R].Value = "Total :";
			int num80 = ((BaseCollection)((DataGridView)DGV).Columns).Count - 1;
			DC_Main.M = 3;
			while (DC_Main.M <= num80)
			{
				num79 = 0;
				int num81 = ((DataGridView)DGV).Rows.Count - 2;
				DC_Main.X = 0;
				while (DC_Main.X <= num81)
				{
					num79 = (int)Math.Round((double)num79 + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[DC_Main.M, DC_Main.X].Value)));
					DC_Main.X++;
				}
				((DataGridView)DGV)[DC_Main.M, DC_Main.X].Value = num79;
				DC_Main.M++;
			}
			StkType = "Stock";
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
					if ((uint)(columnIndex - 7) <= 3u && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 86:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_008c;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 86;
				continue;
			}
			break;
			IL_008c:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Expected O, but got Unknown
		//IL_0c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8b: Expected O, but got Unknown
		if (Operators.CompareString(CurRpt, "Deisgn Move", false) != 0)
		{
			return;
		}
		((Control)DGV).Visible = false;
		BtnExit.Text = "&Back";
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		if (Operators.CompareString(RptDisplay, "Item", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,C.IT_NAME,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.KR_FINE As ItmFine,'+',F.CO_BOOK,B.MAIN_BOOK,F.IT_CODE,F.AC_CODE,F.DESIGN_NO,F.ITM_SIZE  FROM (((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS F ON A.CO_CODE = F.CO_CODE AND A.LC_CODE = F.LC_CODE AND A.TAG_NO = F.TAG_NO AND A.VCH_SRNO = F.VCH_SRNO) LEFT JOIN BOOK_DATA AS B ON F.CO_CODE = B.CO_CODE And F.LC_CODE = B.LC_CODE And F.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON F.CO_CODE = E.CO_CODE And F.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_CODE = '"), ((DataGridView)DGV)[1, index].Value), (object)"' AND F.ITM_SIZE = '"), (object)((DataGridView)DGV).Columns[columnIndex].HeaderText), (object)"'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tDesignNo.Text, "", false) == 0, (object)"", (object)("AND F.DESIGN_NO = '" + tDesignNo.Text + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND C.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' "), (object)" GROUP BY B.BOOK_SNAME,E.AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,C.IT_NAME,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.KR_FINE,F.CO_BOOK,B.MAIN_BOOK,F.IT_CODE,F.AC_CODE,F.DESIGN_NO,F.ITM_SIZE "), (object)" HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0"));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,C.IT_NAME,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.KR_FINE As ItmFine,'+',F.CO_BOOK,B.MAIN_BOOK,F.IT_CODE,F.AC_CODE,F.DESIGN_NO,F.ITM_SIZE  FROM (((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS F ON A.CO_CODE = F.CO_CODE AND A.LC_CODE = F.LC_CODE AND A.TAG_NO = F.TAG_NO AND A.VCH_SRNO = F.VCH_SRNO) LEFT JOIN BOOK_DATA AS B ON F.CO_CODE = B.CO_CODE And F.LC_CODE = B.LC_CODE And F.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON F.CO_CODE = E.CO_CODE And F.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND F.DESIGN_NO = '"), ((DataGridView)DGV)[1, index].Value), (object)"' AND F.ITM_SIZE = '"), (object)((DataGridView)DGV).Columns[columnIndex].HeaderText), (object)"'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND C.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' "), (object)" GROUP BY B.BOOK_SNAME,E.AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,C.IT_NAME,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.KR_FINE,F.CO_BOOK,B.MAIN_BOOK,F.IT_CODE,F.AC_CODE,F.DESIGN_NO,F.ITM_SIZE "), (object)" HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0"));
		}
		RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsStk);
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_VCH).MultiSelect = false;
		((DataGridView)DGV_VCH).AutoGenerateColumns = false;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_VCH).ColumnCount = 18;
		checked
		{
			((DataGridView)DGV_VCH).Columns[0].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV_VCH).Rows.Count);
			((DataGridView)DGV_VCH).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_VCH).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[1].DataPropertyName = "BOOK_SNAME";
			((DataGridView)DGV_VCH).Columns[1].HeaderText = "Vchtype";
			((DataGridView)DGV_VCH).Columns[2].Visible = false;
			((DataGridView)DGV_VCH).Columns[2].DataPropertyName = "AC_NAME";
			((DataGridView)DGV_VCH).Columns[2].HeaderText = "Party Name";
			((DataGridView)DGV_VCH).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[3].DataPropertyName = "VCH_NO";
			((DataGridView)DGV_VCH).Columns[3].HeaderText = "VchNo";
			((DataGridView)DGV_VCH).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[4].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV_VCH).Columns[4].HeaderText = "VchDate";
			((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[5].DataPropertyName = "TAG_NO";
			((DataGridView)DGV_VCH).Columns[5].HeaderText = "TagNo";
			((DataGridView)DGV_VCH).Columns[6].Width = (int)Math.Round(145.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[6].DataPropertyName = "IT_NAME";
			((DataGridView)DGV_VCH).Columns[6].HeaderText = "ItName";
			((DataGridView)DGV_VCH).Columns[7].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[7].DataPropertyName = "DESIGN_NO";
			((DataGridView)DGV_VCH).Columns[7].HeaderText = "Design";
			((DataGridView)DGV_VCH).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[8].DataPropertyName = "ITM_SIZE";
			((DataGridView)DGV_VCH).Columns[8].HeaderText = "Size";
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DataPropertyName = "ITM_PCS";
			((DataGridView)DGV_VCH).Columns[9].HeaderText = "Pcs";
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DataPropertyName = "ITM_GWT";
			((DataGridView)DGV_VCH).Columns[10].HeaderText = "GrWt";
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DataPropertyName = "ITM_NWT";
			((DataGridView)DGV_VCH).Columns[11].HeaderText = "NetWt";
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[12].DataPropertyName = "ItmFine";
			((DataGridView)DGV_VCH).Columns[12].HeaderText = "Fine";
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[13].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[13].DataPropertyName = "ITM_SIGN";
			((DataGridView)DGV_VCH).Columns[13].HeaderText = "Sign";
			((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns[14].Visible = false;
			((DataGridView)DGV_VCH).Columns[14].DataPropertyName = "CO_BOOK";
			((DataGridView)DGV_VCH).Columns[14].HeaderText = "Book";
			((DataGridView)DGV_VCH).Columns[15].Visible = false;
			((DataGridView)DGV_VCH).Columns[15].DataPropertyName = "MAIN_BOOK";
			((DataGridView)DGV_VCH).Columns[15].HeaderText = "BooKName";
			((DataGridView)DGV_VCH).Columns[16].Visible = false;
			((DataGridView)DGV_VCH).Columns[16].DataPropertyName = "IT_CODE";
			((DataGridView)DGV_VCH).Columns[16].HeaderText = "ItCode";
			((DataGridView)DGV_VCH).Columns[17].Visible = false;
			((DataGridView)DGV_VCH).Columns[17].DataPropertyName = "AC_CODE";
			((DataGridView)DGV_VCH).Columns[17].HeaderText = "AcCode";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV_VCH).DataSource = dataView;
			if (((DataGridView)DGV_VCH).Rows.Count >= 1)
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			int num5 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			for (int i = 0; i <= num5; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[6].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV_VCH).Rows[i].Cells[0].Value = i + 1;
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[12].Value, (object)""));
				}
			}
			if (((DataGridView)DGV_VCH).Rows.Count > 1)
			{
				int num6 = ((DataGridView)DGV_VCH).Rows.Count - 1;
				((DataGridView)DGV_VCH).Rows[num6].Cells[2].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num6].Cells[9].Value = num;
				((DataGridView)DGV_VCH).Rows[num6].Cells[10].Value = num2;
				((DataGridView)DGV_VCH).Rows[num6].Cells[11].Value = num3;
				((DataGridView)DGV_VCH).Rows[num6].Cells[12].Value = num4;
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
					case 1861:
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
								goto IL_01d0;
							case 18:
								goto IL_0223;
							case 19:
								goto IL_0232;
							case 21:
								goto IL_0254;
							case 22:
								goto IL_026b;
							case 23:
								goto IL_02b3;
							case 24:
								goto IL_02c2;
							case 25:
								goto IL_02df;
							case 26:
								goto IL_02f9;
							case 27:
								goto IL_031c;
							case 28:
							case 29:
								goto IL_0371;
							case 30:
								goto IL_0383;
							case 20:
							case 31:
							case 32:
								goto IL_039f;
							case 33:
								goto IL_03a9;
							case 34:
								goto IL_03fc;
							case 35:
								goto IL_0451;
							case 36:
								goto IL_04a9;
							case 37:
								goto IL_0517;
							case 38:
								goto IL_055a;
							case 39:
								goto IL_0589;
							case 40:
								goto IL_05cc;
							case 41:
								goto IL_060d;
							case 42:
								goto IL_062e;
							case 43:
								goto IL_063c;
							case 44:
								goto IL_0656;
							case 45:
								goto IL_065c;
							case 46:
								goto IL_0662;
							case 47:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 48:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0371:
						num2 = 29;
						num5++;
						goto IL_037a;
						IL_026b:
						num2 = 22;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02b3;
						IL_031c:
						num2 = 27;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0371;
						IL_02b3:
						num2 = 23;
						num6++;
						goto IL_02bc;
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
						goto IL_0254;
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
						goto IL_0241;
						IL_0241:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_039f;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num11 = 0;
						goto IL_022c;
						IL_022c:
						if (num11 <= num10)
						{
							goto IL_01d0;
						}
						goto IL_0232;
						IL_0232:
						num2 = 19;
						DC_Main.i++;
						goto IL_0241;
						IL_01d0:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0223;
						IL_0223:
						num2 = 18;
						num11++;
						goto IL_022c;
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
						IL_0254:
						num2 = 21;
						num12 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_02bc;
						IL_02bc:
						if (num6 <= num12)
						{
							goto IL_026b;
						}
						goto IL_02c2;
						IL_02c2:
						num2 = 24;
						num13 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0392;
						IL_0392:
						if (DC_Main.i <= num13)
						{
							goto IL_02df;
						}
						goto IL_039f;
						IL_039f:
						num2 = 32;
						colorConverter = new ColorConverter();
						goto IL_03a9;
						IL_03a9:
						num2 = 33;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_03fc;
						IL_03fc:
						num2 = 34;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0451;
						IL_0451:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04a9;
						IL_04a9:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0517;
						IL_0517:
						num2 = 37;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_055a;
						IL_055a:
						num2 = 38;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0589;
						IL_0589:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05cc;
						IL_05cc:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_060d;
						IL_060d:
						num2 = 41;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_062e;
						IL_062e:
						num2 = 42;
						Cursor.Current = Cursors.Default;
						goto IL_063c;
						IL_063c:
						num2 = 43;
						NewLateBinding.LateCall(obj2, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0656;
						IL_0656:
						num2 = 44;
						obj = null;
						goto IL_065c;
						IL_065c:
						num2 = 45;
						obj3 = null;
						goto IL_0662;
						IL_0662:
						num2 = 46;
						obj2 = null;
						break;
						IL_02df:
						num2 = 25;
						num14 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_037a;
						IL_037a:
						if (num5 <= num14)
						{
							goto IL_02f9;
						}
						goto IL_0383;
						IL_0383:
						num2 = 30;
						DC_Main.i++;
						goto IL_0392;
						IL_02f9:
						num2 = 26;
						if (((DataGridView)DGV)[num5, DC_Main.i].Value != null)
						{
							goto IL_031c;
						}
						goto IL_0371;
						end_IL_0001_2:
						break;
					}
					num2 = 47;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1861;
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

	private void RP_STK_MOVE_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b95: Expected O, but got Unknown
		//IL_0c05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c14: Expected O, but got Unknown
		//IL_0cc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccf: Expected O, but got Unknown
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d66: Expected O, but got Unknown
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de3: Expected O, but got Unknown
		//IL_0e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea4: Expected O, but got Unknown
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed2: Expected O, but got Unknown
		//IL_0ef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Expected O, but got Unknown
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
				DataGridViewX dGV_VCH = DGV_VCH;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				ComboBox obj12 = cboItemTyp;
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
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj17 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				Panel panel = Panel1;
				object? obj19 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				ComboBox obj20 = cboItemTyp;
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
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj27 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj28 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj29 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				Panel panel2 = Panel1;
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mFromDt).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
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
					foreach (object control5 in ((Control)Panel1).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
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
			cboItemTyp.Items.Add((object)"");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
			{
				cboItemTyp.SelectedIndex = 2;
			}
			else
			{
				cboItemTyp.SelectedIndex = 1;
			}
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			if (Operators.CompareString(CurRpt, "Bill Wise Profit", false) == 0)
			{
				mFromDt.Text = "01/" + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 7);
				BtnDesign.Text = "Bill Wise";
				BtnSize.Text = "Tag Wise";
			}
			else if (Operators.CompareString(CurRpt, "Deisgn Move", false) == 0)
			{
				lblBook.Text = "Design or Item Wise Size Stock";
				BtnSize.Text = "Design / Size";
				BtnDesign.Text = "Item / Size";
				((Control)Label6).Visible = true;
				((Control)tDesignNo).Visible = true;
			}
			else
			{
				BtnSize.Text = "Tag Stock";
				DGV_CLEAR();
			}
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

	private void RP_STK_MOVE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_STK_MOVE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_STK_MOVE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
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
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_STK_MOVE_Activated(object sender, EventArgs e)
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
		if (Operators.CompareString(CurRpt, "Deisgn Move", false) != 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[12].Value), (object)""), (object)"' "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[14].Value), (object)""), (object)"' "));
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
		if (Operators.CompareString(CurRpt, "Deisgn Move", false) != 0)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[3].Value, (object)""));
		}
		else
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[3].Value, (object)""));
		}
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
	}

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
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
					tGrCode.Text = DC_Main.ColValue[1];
					tGrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
		}
	}

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tPrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT PR_NAME As PrNameL,PR_CODE as PrCodeL FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tPrCode.Text = DC_Main.ColValue[1];
					tPrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tPrCode).SelectAll();
			}
		}
		else
		{
			tPrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_NAME"], (object)""));
		}
	}

	private void tPrCode_LostFocus(object sender, EventArgs e)
	{
		if (Operators.CompareString(tPrCode.Text, "", false) == 0)
		{
			tPrName.Text = "";
		}
	}

	private void tGrCode_LostFocus(object sender, EventArgs e)
	{
		if (Operators.CompareString(tGrCode.Text, "", false) == 0)
		{
			tGrName.Text = "";
		}
	}
}
