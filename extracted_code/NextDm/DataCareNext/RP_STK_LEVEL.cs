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
public class RP_STK_LEVEL : Form
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
	[AccessedThroughProperty("cboItmType")]
	private ComboBox _cboItmType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnList")]
	private QButton _BtnList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double[] TotPcs;

	private const int cSrNo = 0;

	private const int cItName = 1;

	private const int cDesign = 2;

	private const int cFromWt = 3;

	private const int cToWt = 4;

	private const int cClQty = 5;

	private const int cClPcs = 6;

	private const int cClGrwt = 7;

	private const int cClWt = 8;

	private const int cMinStk = 9;

	private const int cDifStk = 10;

	private const int cExStk = 11;

	private const int cItCode = 12;

	private const int cItType = 13;

	private const int c2SrNo = 0;

	private const int c2MembCode = 1;

	private const int c2MembName = 2;

	private const int c2MembMobile = 3;

	private const int c2MembAmt = 4;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private virtual SimpleButton _BtnPrint;

	internal virtual SimpleButton BtnPrint
	{
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnPrint = value;
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
			EventHandler eventHandler = TAcCode_TextChanged;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnJmaUdhar")]
	private virtual SimpleButton _BtnJmaUdhar;

	internal virtual SimpleButton BtnJmaUdhar
	{
		get
		{
			return _BtnJmaUdhar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnJmaUdhar = value;
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

	internal virtual ComboBox cboItmType
	{
		[CompilerGenerated]
		get
		{
			return _cboItmType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItmType_KeyDown);
			ComboBox val2 = _cboItmType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItmType = value;
			val2 = _cboItmType;
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

	internal virtual TextBox tLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLcCode_KeyDown);
			TextBox val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tLcCode = value;
			val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWithAdjSchm")]
	private virtual CheckBox _chkWithAdjSchm;

	internal virtual CheckBox chkWithAdjSchm
	{
		get
		{
			return _chkWithAdjSchm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkWithAdjSchm = value;
		}
	}

	public RP_STK_LEVEL()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += RP_STK_LEVEL_Load;
		((Form)this).Activated += RP_STK_LEVEL_Activated;
		((Form)this).Deactivate += RP_STK_LEVEL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_STK_LEVEL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_STK_LEVEL_KeyDown);
		((Form)this).Closed += RP_STK_LEVEL_Closed;
		((Form)this).MarginChanged += RP_STK_LEVEL_MarginChanged;
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
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Expected O, but got Unknown
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected O, but got Unknown
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0836: Expected O, but got Unknown
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Expected O, but got Unknown
		//IL_098c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Expected O, but got Unknown
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0e: Expected O, but got Unknown
		//IL_0abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac7: Expected O, but got Unknown
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Expected O, but got Unknown
		//IL_0bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Expected O, but got Unknown
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb1: Expected O, but got Unknown
		//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d50: Expected O, but got Unknown
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Expected O, but got Unknown
		//IL_0eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec4: Expected O, but got Unknown
		//IL_0f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f37: Expected O, but got Unknown
		//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Expected O, but got Unknown
		//IL_1081: Unknown result type (might be due to invalid IL or missing references)
		//IL_108b: Expected O, but got Unknown
		//IL_113a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1144: Expected O, but got Unknown
		//IL_11be: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c8: Expected O, but got Unknown
		//IL_1466: Unknown result type (might be due to invalid IL or missing references)
		//IL_148a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1505: Expected O, but got Unknown
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a2: Expected O, but got Unknown
		//IL_160b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1615: Expected O, but got Unknown
		//IL_16c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d0: Expected O, but got Unknown
		//IL_1792: Unknown result type (might be due to invalid IL or missing references)
		//IL_179c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_STK_LEVEL));
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
		BtnJmaUdhar = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		Label4 = new Label();
		mToDt = new MaskedTextBox();
		cboItmType = new ComboBox();
		Label3 = new Label();
		BtnList = new QButton();
		cboStockType = new ComboBox();
		Label1 = new Label();
		tLcCode = new TextBox();
		chkWithAdjSchm = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnJmaUdhar);
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
		lblBook.Text = "Stock Level Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(291, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(71, 22);
		((Control)tAcCode).TabIndex = 1;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(366, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(246, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(201, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "It Code";
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
		((Control)DGV_DETL).Location = new Point(13, 80);
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
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(32, 45);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(82, 20);
		((Control)Label4).TabIndex = 1159;
		Label4.Text = "As On Date";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(119, 44);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 0;
		mToDt.ValidatingType = typeof(DateTime);
		cboItmType.AutoCompleteMode = (AutoCompleteMode)3;
		cboItmType.AutoCompleteSource = (AutoCompleteSource)256;
		cboItmType.BackColor = Color.White;
		((Control)cboItmType).Font = new Font("Tahoma", 9f);
		((ListControl)cboItmType).FormattingEnabled = true;
		((Control)cboItmType).Location = new Point(700, 46);
		((Control)cboItmType).Name = "cboItmType";
		((Control)cboItmType).Size = new Size(103, 22);
		((Control)cboItmType).TabIndex = 2;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(613, 46);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(81, 19);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
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
		((Control)BtnList).Location = new Point(1039, 39);
		((Control)BtnList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnList).Name = "BtnList";
		((Control)BtnList).Size = new Size(91, 33);
		((Control)BtnList).TabIndex = 4;
		BtnList.Text = "Ok";
		cboStockType.BackColor = Color.White;
		((Control)cboStockType).Font = new Font("Tahoma", 9f);
		((ListControl)cboStockType).FormattingEnabled = true;
		((Control)cboStockType).Location = new Point(917, 46);
		((Control)cboStockType).Name = "cboStockType";
		((Control)cboStockType).Size = new Size(98, 22);
		((Control)cboStockType).TabIndex = 3;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(820, 46);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(91, 20);
		((Control)Label1).TabIndex = 1167;
		Label1.Text = "Stock Type";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1068, 5);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1168;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((ButtonBase)chkWithAdjSchm).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkWithAdjSchm).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWithAdjSchm).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkWithAdjSchm).Location = new Point(892, 8);
		((Control)chkWithAdjSchm).Name = "chkWithAdjSchm";
		((Control)chkWithAdjSchm).RightToLeft = (RightToLeft)0;
		((Control)chkWithAdjSchm).Size = new Size(144, 19);
		((Control)chkWithAdjSchm).TabIndex = 1169;
		((ButtonBase)chkWithAdjSchm).Text = "With Adj Scheme";
		((ButtonBase)chkWithAdjSchm).UseVisualStyleBackColor = false;
		((Control)chkWithAdjSchm).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkWithAdjSchm);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)cboStockType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)BtnList);
		((Control)this).Controls.Add((Control)(object)cboItmType);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_STK_LEVEL";
		((Form)this).Text = "Stock Level Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_DETL_SCHM_FILL()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		DataGridViewX dGV_DETL = DGV_DETL;
		((DataGridView)DGV_DETL).MultiSelect = false;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", (float)DC_Main.HaderFont, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT YEAR(A.SCHM_DATE) as YrCode,MONTH(A.SCHM_DATE) AS MnCode FROM AD_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.SCHM_CODE = '"), (object)tAcCode.Text), (object)"' AND A.SCHM_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'  "), (object)" GROUP BY YEAR(A.SCHM_DATE),MONTH(A.SCHM_DATE) ORDER BY YEAR(A.SCHM_DATE),MONth(A.SCHM_DATE) "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				TotPcs = new double[DC_Main.Tbl.Rows.Count + 4 + 1];
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Sr");
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Code");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Memb Name");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(210.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Mobile");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			DC_Main.i = 4;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_DETL).Columns.Add("", Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["YrCode"]), 3, 2) + "/" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["MnCode"]), "00"));
				((DataGridView)DGV_DETL).Columns[DC_Main.i].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				DC_Main.i++;
				DC_Main.M++;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Total");
			((DataGridView)DGV_DETL).Columns[DC_Main.i].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns.Add("", "LMonth");
			((DataGridView)DGV_DETL).Columns[DC_Main.i + 1].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[DC_Main.i + 1].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.Tbl.Clear();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_CODE,B.MEMB_NAME,B.AC_MOBILE,YEAR(A.SCHM_DATE) as YrCode,MONTH(A.SCHM_DATE) AS MnCode,SUM(A.MEMB_AMT) AS MembAmt  FROM AD_DATA AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.SCHM_CODE = '"), (object)tAcCode.Text), (object)"' AND A.SCHM_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY A.MEMB_CODE,B.MEMB_NAME,B.AC_MOBILE,YEAR(A.SCHM_DATE),MONTH(A.SCHM_DATE) ORDER BY A.MEMB_CODE,YEAR(A.SCHM_DATE),MONth(A.SCHM_DATE) "));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			string text = "";
			bool flag = false;
			DC_Main.R = -1;
			int num2 = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.M = 0;
			double num3 = default(double);
			while (DC_Main.M <= num2)
			{
				DataGridViewX dGV_DETL2 = DGV_DETL;
				if (Operators.CompareString(Strings.RTrim(Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_CODE"])), Strings.RTrim(text), false) != 0)
				{
					text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_CODE"], (object)""));
					flag = false;
					if (!chkWithAdjSchm.Checked)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.MEMB_CODE FROM AD_OS AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.MEMB_CODE = B.MEMB_CODE AND A.SCHM_CODE = B.SCHM_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SCHM_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.MEMB_CODE = '"), (object)text), (object)"' GROUP BY A.MEMB_CODE "), (object)" HAVING SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) - SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) <= 0 ORDER BY A.MEMB_CODE "));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						num3 = 0.0;
						DC_Main.R++;
						((DataGridView)dGV_DETL2).Rows.Add();
						((DataGridView)dGV_DETL2)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV_DETL2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_CODE"]);
						((DataGridView)dGV_DETL2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_NAME"]);
						((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_MOBILE"]);
					}
				}
				if (!flag)
				{
					int num4 = ((BaseCollection)((DataGridView)dGV_DETL2).Columns).Count - 1;
					DC_Main.X = 4;
					while (DC_Main.X <= num4)
					{
						if (Operators.CompareString(Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.M]["YrCode"]), 3, 2) + "/" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["MnCode"]), "00"), ((DataGridView)DGV_DETL).Columns[DC_Main.X].HeaderText ?? "", false) == 0)
						{
							((DataGridView)dGV_DETL2)[DC_Main.X, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["MembAmt"]);
							num3 = Conversions.ToDouble(Operators.AddObject((object)num3, DC_Main.Rshlp.Rows[DC_Main.M]["MembAmt"]));
							ref double reference = ref TotPcs[DC_Main.X];
							reference = Conversions.ToDouble(Operators.AddObject((object)reference, DC_Main.Rshlp.Rows[DC_Main.M]["MembAmt"]));
							((DataGridView)dGV_DETL2)[((BaseCollection)((DataGridView)dGV_DETL2).Columns).Count - 2, DC_Main.R].Value = num3;
							((DataGridView)dGV_DETL2)[((BaseCollection)((DataGridView)dGV_DETL2).Columns).Count - 1, DC_Main.R].Value = Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.M]["YrCode"]), 3, 2) + "/" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["MnCode"]), "00");
							break;
						}
						DC_Main.X++;
					}
				}
				dGV_DETL2 = null;
				DC_Main.M++;
			}
			DC_Main.Rshlp.Clear();
			int num5 = 0;
			((DataGridView)DGV_DETL).Rows.Add();
			((DataGridView)DGV_DETL).Rows.Add();
			DC_Main.R = ((DataGridView)DGV_DETL).Rows.Count - 1;
			((DataGridView)DGV_DETL)[2, DC_Main.R].Value = "Total :";
			int num6 = ((BaseCollection)((DataGridView)DGV_DETL).Columns).Count - 1;
			DC_Main.M = 4;
			while (DC_Main.M <= num6)
			{
				num5 = 0;
				int num7 = ((DataGridView)DGV_DETL).Rows.Count - 2;
				DC_Main.X = 0;
				while (DC_Main.X <= num7)
				{
					num5 = (int)Math.Round((double)num5 + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[DC_Main.M, DC_Main.X].Value)));
					DC_Main.X++;
				}
				((DataGridView)DGV_DETL)[DC_Main.M, DC_Main.X].Value = num5;
				DC_Main.M++;
			}
			dGV_DETL = null;
		}
	}

	private void DGV_ITM_FILL()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_1a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa6: Expected O, but got Unknown
		//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b69: Expected O, but got Unknown
		//IL_0bc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcd: Expected O, but got Unknown
		//IL_172c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1736: Expected O, but got Unknown
		//IL_1790: Unknown result type (might be due to invalid IL or missing references)
		//IL_179a: Expected O, but got Unknown
		//IL_17f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fe: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
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
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Item Name");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Design");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "From Wt");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[3].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "To Wt");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "StkQty");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "StkPcs");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "ClGrwt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "ClNwt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "MinStk");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "MakeOrd");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "ExtraStk");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
			((DataGridView)DGV_DETL).Columns[12].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "ItType");
			((DataGridView)DGV_DETL).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			DC_Main.R++;
			DC_Main.M = 0;
			string text = "";
			string text2 = "N";
			DC_Main.RsQry = "SELECT IT_DESIGN FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_DESIGN <> 'N'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 1)
			{
				text2 = "Y";
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM ITM_WT_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(cboItmType.SelectedIndex == 0, (object)"", (object)("AND B.IT_TYPE = '" + Strings.Mid(cboItmType.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.IT_CODE = '" + tAcCode.Text + "'"))), (object)" ORDER BY IT_CODE,IT_DESIGN,SR_NO "));
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				while (DC_Main.X < dataTable.Rows.Count)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					DC_Main.R = ((DataGridView)dGV_DETL).Rows.Count - 1;
					((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["FROM_WT"], (object)"")), "0.000");
					((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["TO_WT"], (object)"")), "0.000");
					((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MIN_PCS"], (object)"")), "0");
					if (Operators.ConditionalCompareObjectNotEqual((object)text, Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_NAME"], dataTable.Rows[DC_Main.X]["IT_DESIGN"]), false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_NAME"], dataTable.Rows[DC_Main.X]["IT_DESIGN"]));
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_NAME"], (object)"");
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_DESIGN"], (object)"");
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[1].Style.ForeColor = Color.Maroon;
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[1].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Style.ForeColor = Color.Maroon;
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
					}
					((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_CODE"], (object)"");
					if (Operators.CompareString(text2, "N", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE AS Code, SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN  1 ELSE -1 END)ELSE 0 END) AS ClQty,SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN  ITM_NWT  ELSE - ITM_NWT  END) ELSE 0 END) AS ClWt, SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END)ELSE 0 END) AS ClGrWt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '"), ((DataGridView)dGV_DETL)[12, DC_Main.R].Value), (object)"' "), (object)" AND A.ITM_NWT >= "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[3, DC_Main.R].Value))), (object)" AND A.ITM_NWT <= "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[4, DC_Main.R].Value))), (object)" "));
						if (cboStockType.SelectedIndex == 1)
						{
							DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
						}
						else if (cboStockType.SelectedIndex == 2)
						{
							DC_Main.RsQry += "AND A.TAG_NO = 'N'";
						}
						DC_Main.RsQry += "GROUP BY A.IT_CODE";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_DESIGN"], (object)""), (object)"N", false))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE AS Code, SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN  1 ELSE -1 END)ELSE 0 END) AS ClQty,SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN  ITM_NWT  ELSE - ITM_NWT  END) ELSE 0 END) AS ClWt, SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END)ELSE 0 END) AS ClGrWt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '"), ((DataGridView)dGV_DETL)[12, DC_Main.R].Value), (object)"' "), (object)" AND A.ITM_NWT >= "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[3, DC_Main.R].Value))), (object)" AND A.ITM_NWT <= "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[4, DC_Main.R].Value))), (object)" AND (A.DESIGN_NO = '' OR A.DESIGN_NO IS NULL) "));
						if (cboStockType.SelectedIndex == 1)
						{
							DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
						}
						else if (cboStockType.SelectedIndex == 2)
						{
							DC_Main.RsQry += "AND A.TAG_NO = 'N'";
						}
						DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE HAVING SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END)ELSE 0 END) > 0";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE AS Code,A.DESIGN_NO As Design, SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN  1 ELSE -1 END)ELSE 0 END) AS ClQty,SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN  ITM_NWT  ELSE - ITM_NWT  END) ELSE 0 END) AS ClWt, SUM(CASE WHEN VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END)ELSE 0 END) AS ClGrWt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '"), ((DataGridView)dGV_DETL)[12, DC_Main.R].Value), (object)"' "), (object)" AND A.ITM_NWT >= "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[3, DC_Main.R].Value))), (object)" AND A.ITM_NWT <= "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[4, DC_Main.R].Value))), (object)" AND A.DESIGN_NO = '"), dataTable.Rows[DC_Main.X]["IT_DESIGN"]), (object)""), (object)"' "));
						if (cboStockType.SelectedIndex == 1)
						{
							DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
						}
						else if (cboStockType.SelectedIndex == 2)
						{
							DC_Main.RsQry += "AND A.TAG_NO = 'N'";
						}
						DC_Main.RsQry += "GROUP BY A.IT_CODE,A.DESIGN_NO";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						((DataGridView)dGV_DETL)[5, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ClQty"]), "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[5, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[6, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ClPcs"]), "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[6, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[6, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ClWt"]), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[8, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[7, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ClGrWt"]), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[7, DC_Main.R].Value = "";
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, DC_Main.R].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[6, DC_Main.R].Value));
						num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, DC_Main.R].Value))), "0");
						num5 += Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)), "0"));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) <= 0.0)
						{
							((DataGridView)dGV_DETL)[10, DC_Main.R].Value = "";
						}
						else
						{
							num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
							((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_NAME"], (object)"");
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[10].Style.ForeColor = Color.Maroon;
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[10].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[3].Style.ForeColor = Color.Maroon;
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[3].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[4].Style.ForeColor = Color.Maroon;
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[4].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) > 0.0)
						{
							((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value))), "0");
							num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						}
					}
					DC_Main.X++;
				}
				dGV_DETL = null;
			}
			DataGridViewX dGV_DETL2 = DGV_DETL;
			((DataGridView)dGV_DETL2).Rows.Add();
			((DataGridView)dGV_DETL2).Rows.Add();
			DC_Main.R = ((DataGridView)dGV_DETL2).Rows.Count - 1;
			((DataGridView)dGV_DETL2)[1, DC_Main.R].Value = "Total :";
			((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = Strings.Format((object)num, "0");
			((DataGridView)dGV_DETL2)[6, DC_Main.R].Value = Strings.Format((object)num2, "0");
			((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = Strings.Format((object)num3, "0.000");
			((DataGridView)dGV_DETL2)[7, DC_Main.R].Value = Strings.Format((object)num4, "0.000");
			((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = Strings.Format((object)num5, "0");
			((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = Strings.Format((object)num6, "0");
			((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = Strings.Format((object)num7, "0");
			dGV_DETL2 = null;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
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
					if ((uint)(columnIndex - 4) <= 7u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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
		object obj = default(object);
		int num5 = default(int);
		int num6 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num13 = default(int);
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
					case 1916:
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
								goto IL_017d;
							case 16:
								goto IL_019d;
							case 17:
								goto IL_01ba;
							case 18:
								goto IL_01f4;
							case 19:
								goto IL_01fd;
							case 20:
								goto IL_0214;
							case 21:
								goto IL_0237;
							case 22:
							case 23:
								goto IL_0289;
							case 24:
							case 25:
								goto IL_029d;
							case 27:
								goto IL_02bf;
							case 28:
								goto IL_02dc;
							case 29:
								goto IL_0317;
							case 30:
								goto IL_0320;
							case 31:
								goto IL_0337;
							case 32:
								goto IL_035a;
							case 33:
							case 34:
								goto IL_03ac;
							case 35:
							case 36:
								goto IL_03c0;
							case 26:
							case 37:
							case 38:
								goto IL_03dc;
							case 39:
								goto IL_03e6;
							case 40:
								goto IL_0439;
							case 41:
								goto IL_048e;
							case 42:
								goto IL_04e6;
							case 43:
								goto IL_0554;
							case 44:
								goto IL_0597;
							case 45:
								goto IL_05c6;
							case 46:
								goto IL_0609;
							case 47:
								goto IL_064a;
							case 48:
								goto IL_066b;
							case 49:
								goto IL_0679;
							case 50:
								goto IL_067f;
							case 51:
								goto IL_0685;
							case 52:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 53:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_03c0:
						num2 = 36;
						DC_Main.i++;
						goto IL_03cf;
						IL_0120:
						num2 = 12;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num5 + 1,
							((DataGridView)DGV_DETL).Columns[num5].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_03ac:
						num2 = 34;
						num6++;
						goto IL_03b5;
						IL_0168:
						num2 = 13;
						num5++;
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
						num7 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num5 = 0;
						goto IL_0171;
						IL_0171:
						if (num5 <= num7)
						{
							goto IL_0120;
						}
						goto IL_0177;
						IL_0177:
						num2 = 14;
						num8 = 0;
						goto IL_017d;
						IL_017d:
						num2 = 15;
						if (Operators.CompareString(CurRpt, "Monthly Report", false) == 0)
						{
							goto IL_019d;
						}
						goto IL_02bf;
						IL_019d:
						num2 = 16;
						num9 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_02ac;
						IL_02ac:
						if (DC_Main.i <= num9)
						{
							goto IL_01ba;
						}
						goto IL_03dc;
						IL_01ba:
						num2 = 17;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[1, DC_Main.i].Value)) != 0.0)
						{
							goto IL_01f4;
						}
						goto IL_029d;
						IL_01f4:
						num2 = 18;
						num8++;
						goto IL_01fd;
						IL_01fd:
						num2 = 19;
						num10 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num11 = 0;
						goto IL_0292;
						IL_0292:
						if (num11 <= num10)
						{
							goto IL_0214;
						}
						goto IL_029d;
						IL_0214:
						num2 = 20;
						if (((DataGridView)DGV_DETL)[num11, DC_Main.i].Value != null)
						{
							goto IL_0237;
						}
						goto IL_0289;
						IL_0237:
						num2 = 21;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							num8 + 2,
							num11 + 1,
							((DataGridView)DGV_DETL)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0289;
						IL_0289:
						num2 = 23;
						num11++;
						goto IL_0292;
						IL_029d:
						num2 = 25;
						DC_Main.i++;
						goto IL_02ac;
						IL_02bf:
						num2 = 27;
						num12 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_03cf;
						IL_03cf:
						if (DC_Main.i <= num12)
						{
							goto IL_02dc;
						}
						goto IL_03dc;
						IL_03dc:
						num2 = 38;
						colorConverter = new ColorConverter();
						goto IL_03e6;
						IL_03e6:
						num2 = 39;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0439;
						IL_0439:
						num2 = 40;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_048e;
						IL_048e:
						num2 = 41;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04e6;
						IL_04e6:
						num2 = 42;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0554;
						IL_0554:
						num2 = 43;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0597;
						IL_0597:
						num2 = 44;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05c6;
						IL_05c6:
						num2 = 45;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0609;
						IL_0609:
						num2 = 46;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_064a;
						IL_064a:
						num2 = 47;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_066b;
						IL_066b:
						num2 = 48;
						Cursor.Current = Cursors.Default;
						goto IL_0679;
						IL_0679:
						num2 = 49;
						obj = null;
						goto IL_067f;
						IL_067f:
						num2 = 50;
						obj3 = null;
						goto IL_0685;
						IL_0685:
						num2 = 51;
						obj2 = null;
						break;
						IL_02dc:
						num2 = 28;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[10, DC_Main.i].Value)) != 0.0)
						{
							goto IL_0317;
						}
						goto IL_03c0;
						IL_0317:
						num2 = 29;
						num8++;
						goto IL_0320;
						IL_0320:
						num2 = 30;
						num13 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num6 = 0;
						goto IL_03b5;
						IL_03b5:
						if (num6 <= num13)
						{
							goto IL_0337;
						}
						goto IL_03c0;
						IL_0337:
						num2 = 31;
						if (((DataGridView)DGV_DETL)[num6, DC_Main.i].Value != null)
						{
							goto IL_035a;
						}
						goto IL_03ac;
						IL_035a:
						num2 = 32;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							num8 + 2,
							num6 + 1,
							((DataGridView)DGV_DETL)[num6, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_03ac;
						end_IL_0001_2:
						break;
					}
					num2 = 52;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1916;
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

	private void RP_STK_LEVEL_Load(object sender, EventArgs e)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Expected O, but got Unknown
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Expected O, but got Unknown
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected O, but got Unknown
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Expected O, but got Unknown
		//IL_09f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_0a27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Expected O, but got Unknown
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = "Item Stock Level";
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
				DataGridViewX dGV_DETL = DGV_DETL;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
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
				DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj10 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj12 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj13 = lblBook;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj13).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj16 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj17 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
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
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
				}
			}
			if (Operators.CompareString(CurRpt, "Monthly Report", false) == 0)
			{
				((Control)cboItmType).Visible = false;
				((Control)cboStockType).Visible = false;
				Label2.Text = "Schm Code";
				CLEAR_DATA();
				lblBook.Text = "Member Monthly Report";
				((Control)Label3).Visible = false;
				((Control)Label1).Visible = false;
				((Control)chkWithAdjSchm).Visible = true;
			}
			else
			{
				cboItmType.Items.Add((object)"");
				cboItmType.Items.Add((object)"Gold");
				cboItmType.Items.Add((object)"Silver");
				if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
				{
					cboItmType.SelectedIndex = 1;
				}
				else
				{
					cboItmType.SelectedIndex = 2;
				}
				cboStockType.Items.Add((object)"All");
				cboStockType.Items.Add((object)"Tag");
				cboStockType.Items.Add((object)"Item");
				cboStockType.SelectedIndex = 0;
				CLEAR_DATA();
				DGV_ITM_FILL();
			}
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			CurActCtrl = (Control)(object)mToDt;
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
		if (Operators.CompareString(CurRpt, "Monthly Report", false) != 0)
		{
			cboStockType.SelectedIndex = 0;
		}
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)mToDt).Focus();
	}

	private void RP_STK_LEVEL_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_STK_LEVEL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_STK_LEVEL_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_STK_LEVEL_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_STK_LEVEL_Closed(object sender, EventArgs e)
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

	private void TAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Monthly Report", false) == 0)
		{
			DC_Main.RsQry = "Select * From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT SCHM_CODE As CodeL,SCHM_NAME as SchemeNameL, SCHM_AMT AS AmountR,SCHM_TYPE As SchmTypeM FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY SCHM_CODE";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 300.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[0];
						tAcName.Text = DC_Main.ColValue[1];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_NAME"], (object)""));
				DGV_DETL_SCHM_FILL();
			}
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
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
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
					DGV_ITM_FILL();
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
			DGV_ITM_FILL();
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
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
			DGV_ITM_FILL();
		}
	}

	private void BtnList_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Monthly Report", false) == 0)
		{
			DGV_DETL_SCHM_FILL();
		}
		else
		{
			DGV_ITM_FILL();
		}
	}

	private void tLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tLcCode.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[5];
			DC_Main.ColWidth[0] = 70.0;
			DC_Main.ColWidth[1] = 280.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 250.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tLcCode.Text = DC_Main.ColValue[0];
				((TextBoxBase)tLcCode).SelectAll();
			}
		}
	}

	private void RP_STK_LEVEL_MarginChanged(object sender, EventArgs e)
	{
	}
}
