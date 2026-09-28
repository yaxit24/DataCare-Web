using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_E_INVOICE : Form
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
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

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
	[AccessedThroughProperty("BtnOk")]
	private QButton _BtnOk;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string[] ArySchmCode;

	private string[] AryEmpCode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cBillType = 0;

	private const int cRCharge = 1;

	private const int cEComGstn = 2;

	private const int cIgstOnIntra = 3;

	private const int cDockType = 4;

	private const int cDockNumber = 5;

	private const int cDockDate = 6;

	private const int cByerGstn = 7;

	private const int cByerLegalName = 8;

	private const int cByerTradName = 9;

	private const int cByerPos = 10;

	private const int cByerAdd1 = 11;

	private const int cByerAdd2 = 12;

	private const int cByerLoct = 13;

	private const int cByerPinCode = 14;

	private const int cByerState = 15;

	private const int cByerPhone = 16;

	private const int cByerEmail = 17;

	private const int cDispName = 18;

	private const int cDispAdd1 = 19;

	private const int cDispAdd2 = 20;

	private const int cDispLoct = 21;

	private const int cDispPinCode = 22;

	private const int cDispState = 23;

	private const int cShipGstn = 24;

	private const int cShipLegalName = 25;

	private const int cShipTradName = 26;

	private const int cShipAdd1 = 27;

	private const int cShipAdd2 = 28;

	private const int cShipLoct = 29;

	private const int cShipPinCode = 30;

	private const int cShipState = 31;

	private const int cTotTaxablVal = 32;

	private const int cTotSgstAmt = 33;

	private const int cTotCgstAmt = 34;

	private const int cTotIgstAmt = 35;

	private const int cTotCessAmt = 36;

	private const int cTotStateCessAmt = 37;

	private const int cTotDiscAmt = 38;

	private const int cTotOthCharg = 39;

	private const int cTotRoundOff = 40;

	private const int cTotInvoiceVal = 41;

	private const int cExpBillNo = 42;

	private const int cExpDate = 43;

	private const int cExpPort = 44;

	private const int cExpRefund = 45;

	private const int cExpFornCurency = 46;

	private const int cExpCuntryCode = 47;

	private const int cExpDutyAmt = 48;

	private const int cWayid = 49;

	private const int cWayTranName = 50;

	private const int cWayTarnMode = 51;

	private const int cWayDistance = 52;

	private const int cWayDocNo = 53;

	private const int cWayDocDate = 54;

	private const int cWayVehicalNo = 55;

	private const int cWayVehicalType = 56;

	private const int cDockType1 = 0;

	private const int cDockNumber1 = 1;

	private const int cDockDate1 = 2;

	private const int cSlNo = 3;

	private const int cProdDesc = 4;

	private const int cIsService = 5;

	private const int cHsnCode = 6;

	private const int cBarcdoe = 7;

	private const int cQty = 8;

	private const int cFreeQry = 9;

	private const int cUnit = 10;

	private const int cUnitRate = 11;

	private const int cGrossAmt = 12;

	private const int cDiscount = 13;

	private const int cPreTaxVal = 14;

	private const int cTaxablVal = 15;

	private const int cGstRate = 16;

	private const int cSgstAmt = 17;

	private const int cCgstAmt = 18;

	private const int cIgstAmt = 19;

	private const int cCessPrc = 20;

	private const int cCessAmtAdVal = 21;

	private const int cCessNonAdVal = 22;

	private const int cStateCessPrc = 23;

	private const int cStateCessAdVal = 24;

	private const int cStateCessNonAdVal = 25;

	private const int cOthCharge = 26;

	private const int cItmTotal = 27;

	private const int cBachName = 28;

	private const int cBachExpiry = 29;

	private const int cBachWaranty = 30;

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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewX val2 = _DGV;
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

	internal virtual QButton BtnOk
	{
		[CompilerGenerated]
		get
		{
			return _BtnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOk_Click;
			QButton val = _BtnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnOk = value;
			val = _BtnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgSave")]
	private virtual SaveFileDialog _DlgSave;

	internal virtual SaveFileDialog DlgSave
	{
		get
		{
			return _DlgSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgSave = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private virtual DataGridViewX _DGV_DETL;

	internal virtual DataGridViewX DGV_DETL
	{
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_DETL = value;
		}
	}

	public UT_E_INVOICE()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += UT_E_INVOICE_Load;
		((Form)this).Activated += UT_E_INVOICE_Activated;
		((Form)this).Deactivate += UT_E_INVOICE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_E_INVOICE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_E_INVOICE_KeyDown);
		((Form)this).Closed += UT_E_INVOICE_Closed;
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
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Expected O, but got Unknown
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Expected O, but got Unknown
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d9: Expected O, but got Unknown
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Expected O, but got Unknown
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4d: Expected O, but got Unknown
		//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac0: Expected O, but got Unknown
		//IL_0b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5c: Expected O, but got Unknown
		//IL_0c0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c14: Expected O, but got Unknown
		//IL_0cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb5: Expected O, but got Unknown
		//IL_0f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1017: Expected O, but got Unknown
		//IL_103a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected O, but got Unknown
		//IL_1176: Unknown result type (might be due to invalid IL or missing references)
		//IL_1180: Expected O, but got Unknown
		//IL_1206: Unknown result type (might be due to invalid IL or missing references)
		//IL_1210: Expected O, but got Unknown
		//IL_12fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1304: Expected O, but got Unknown
		//IL_136d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1377: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_E_INVOICE));
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
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV = new DataGridViewX();
		Label4 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		BtnOk = new QButton();
		DlgSave = new SaveFileDialog();
		DGV_DETL = new DataGridViewX();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
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
		lblBook.Text = "E - Invoice Data ";
		lblBook.TextAlign = (ContentAlignment)32;
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
		((Control)DGV).Location = new Point(13, 80);
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
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1159, 257);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1133;
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
		((QControl)BtnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnOk).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOk).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOk.Image = null;
		((QControl)BtnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnOk).Location = new Point(278, 39);
		((Control)BtnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnOk).Name = "BtnOk";
		((Control)BtnOk).Size = new Size(94, 32);
		((Control)BtnOk).TabIndex = 1160;
		BtnOk.Text = "&Get List";
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Snow;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val8;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 343);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val10;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 209);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1161;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)BtnOk);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_E_INVOICE";
		((Form)this).Text = "E - Invoice Data ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_ITM_FILL()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edc: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1b: Expected O, but got Unknown
		//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f40: Expected O, but got Unknown
		//IL_0f56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f65: Expected O, but got Unknown
		//IL_1efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_202a: Unknown result type (might be due to invalid IL or missing references)
		//IL_208d: Unknown result type (might be due to invalid IL or missing references)
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "DockType");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "DockNo");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "DockDate");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "SlNo");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Product");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "IsService");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "HsnCode");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "BarCode");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Qty");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "FreeQry");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Unit");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "UnitRate");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "GrossAmt");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "DiscAmt");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "PreTaxVal");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "TaxableVal");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Gst%");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "SgstAmt");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CgstAmt");
			((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "IgstAmt");
			((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Cess%");
			((DataGridView)DGV_DETL).Columns[20].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CessAdVal");
			((DataGridView)DGV_DETL).Columns[21].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CessNonVal");
			((DataGridView)DGV_DETL).Columns[22].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "StateCess%");
			((DataGridView)DGV_DETL).Columns[23].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[23].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "StateCessAddVal");
			((DataGridView)DGV_DETL).Columns[24].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[24].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[24].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "StateCessNonVal");
			((DataGridView)DGV_DETL).Columns[25].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[25].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[25].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OtherCharge");
			((DataGridView)DGV_DETL).Columns[26].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[26].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "ItemTotal");
			((DataGridView)DGV_DETL).Columns[27].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[27].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[27].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "BachName");
			((DataGridView)DGV_DETL).Columns[28].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "BachExpiry");
			((DataGridView)DGV_DETL).Columns[29].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "BachWaranty");
			((DataGridView)DGV_DETL).Columns[30].Width = (int)Math.Round(0.0 * ColCon);
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
			((DataGridView)DGV).Columns.Add("", "SType");
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "RCharg");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "EcomGstn");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "IgstOnIntra");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DockType");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DockNo");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DockDate");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByGstn");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByLglName");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByTradName");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByPos");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByAdd1");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByAdd2");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByLoct");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByPinCode");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByState");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByPhone");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ByMail");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DispName");
			((DataGridView)DGV).Columns[18].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DispAdd1");
			((DataGridView)DGV).Columns[19].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DispAdd2");
			((DataGridView)DGV).Columns[20].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DispLoct");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DispPin");
			((DataGridView)DGV).Columns[22].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "DispState");
			((DataGridView)DGV).Columns[23].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipGstn");
			((DataGridView)DGV).Columns[24].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipLgName");
			((DataGridView)DGV).Columns[25].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipTradName");
			((DataGridView)DGV).Columns[26].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipAdd1");
			((DataGridView)DGV).Columns[27].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipAdd2");
			((DataGridView)DGV).Columns[28].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipLoct");
			((DataGridView)DGV).Columns[29].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipPin");
			((DataGridView)DGV).Columns[30].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ShipState");
			((DataGridView)DGV).Columns[31].Width = (int)Math.Round(0.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "TotTaxableVal");
			((DataGridView)DGV).Columns[32].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[32].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[32].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "SgstAmt");
			((DataGridView)DGV).Columns[33].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[33].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[33].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "CgstAmt");
			((DataGridView)DGV).Columns[34].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[34].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[34].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "IgstAmt");
			((DataGridView)DGV).Columns[35].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[35].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[35].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotCessAmt");
			((DataGridView)DGV).Columns[36].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[36].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[36].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotStateCess");
			((DataGridView)DGV).Columns[37].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[37].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[37].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "DiscAmt");
			((DataGridView)DGV).Columns[38].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[38].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[38].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OthCharge");
			((DataGridView)DGV).Columns[39].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[39].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[39].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "RofAmt");
			((DataGridView)DGV).Columns[40].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[40].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[40].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotInvoiceVal");
			((DataGridView)DGV).Columns[41].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[41].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[41].DefaultCellStyle.Format = "N2";
			DC_Main.RsQry = "SELECT B.IT_NAME FROM (SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '025' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND C.BOOK_TYPE = 'T' AND (B.HSN_CODE = '' OR B.HSN_CODE IS NULL) GROUP BY B.IT_NAME ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Please Insert HSN CODE IN Item Master item Name is  ", DC_Main.Tbl.Rows[0]["IT_NAME"]), (object)""), (MsgBoxStyle)0, (object)null);
				return;
			}
			DC_Main.RsQry = "SELECT A.AC_CODE,B.AC_NAME,B.AC_GSTNO,B.AC_PIN FROM (SL_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '025' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND C.BOOK_TYPE = 'T' AND (B.AC_PIN = '' OR B.AC_GSTNO = '') GROUP BY A.AC_CODE,B.AC_NAME,B.AC_GSTNO,B.AC_PIN ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["AC_PIN"], (object)"", false))
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Please Insert PIN CODE IN AC_MAST Ac Name is  ", DC_Main.Tbl.Rows[0]["AC_NAME"]), (object)""), (MsgBoxStyle)0, (object)null);
				}
				if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["AC_GSTNO"], (object)"", false))
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Please Insert GST NO IN AC_MAST Ac Name is  ", DC_Main.Tbl.Rows[0]["AC_NAME"]), (object)""), (MsgBoxStyle)0, (object)null);
				}
				return;
			}
			DC_Main.RsQry = "SELECT A.CO_BOOK,E.MAIN_BOOK,E.BOOK_SR_NAME,A.VCH_NO,A.VCH_DATE,C.AC_GSTNO,C.AC_NAME,C.AC_NAME,C.AC_STATE,C.AC_ADD1,C.AC_ADD2,C.AC_CITY,C.AC_PIN,C.AC_MOBILE,C.AC_EMAIL,  A.NET_AMT,A.SGST_TAX,A.CGST_TAX,A.IGST_TAX,A.DISC_AMT,A.TOT_AMT FROM (SL_DATA AS A LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.LC_CODE = E.LC_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '025' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND E.BOOK_TYPE = 'T' ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			DC_Main.R = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV = DGV;
				while (DC_Main.X < dataTable.Rows.Count)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = "B2B";
					((DataGridView)dGV)[1, DC_Main.R].Value = "No";
					((DataGridView)dGV)[2, DC_Main.R].Value = "";
					((DataGridView)dGV)[3, DC_Main.R].Value = "No";
					((DataGridView)dGV)[4, DC_Main.R].Value = "Tax Invoice";
					((DataGridView)dGV)[5, DC_Main.R].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_SR_NAME"], (object)"-"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"");
					((DataGridView)dGV)[6, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"");
					((DataGridView)dGV)[7, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_GSTNO"], (object)"");
					((DataGridView)dGV)[8, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_NAME"], (object)"");
					((DataGridView)dGV)[9, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_NAME"], (object)"");
					((DataGridView)dGV)[10, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_STATE"], (object)"");
					((DataGridView)dGV)[11, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_ADD1"], (object)"");
					((DataGridView)dGV)[12, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_ADD2"], (object)"");
					((DataGridView)dGV)[13, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_CITY"], (object)"");
					((DataGridView)dGV)[14, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_PIN"], (object)"");
					((DataGridView)dGV)[15, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_STATE"], (object)"");
					((DataGridView)dGV)[16, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_MOBILE"], (object)"");
					((DataGridView)dGV)[17, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_EMAIL"], (object)"");
					((DataGridView)dGV)[32, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["NET_AMT"], (object)"")), "0.00");
					((DataGridView)dGV)[33, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["SGST_TAX"], (object)"")), "0.00");
					((DataGridView)dGV)[34, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CGST_TAX"], (object)"")), "0.00");
					((DataGridView)dGV)[35, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IGST_TAX"], (object)"")), "0.00");
					((DataGridView)dGV)[36, DC_Main.R].Value = 0;
					((DataGridView)dGV)[37, DC_Main.R].Value = 0;
					((DataGridView)dGV)[38, DC_Main.R].Value = 0;
					((DataGridView)dGV)[39, DC_Main.R].Value = 0;
					((DataGridView)dGV)[40, DC_Main.R].Value = 0;
					((DataGridView)dGV)[41, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["TOT_AMT"], (object)"")), "0.00");
					VchItemDetl(Conversions.ToString(dataTable.Rows[DC_Main.X]["CO_BOOK"]), Conversions.ToString(dataTable.Rows[DC_Main.X]["VCH_NO"]), Conversions.ToDouble(((DataGridView)dGV)[35, DC_Main.R].Value));
					DC_Main.R++;
					DC_Main.X++;
				}
				dGV = null;
			}
		}
	}

	private void VchItemDetl(string CurBook, string CurVch, double IgstTax)
	{
		DC_Main.RsQry = "SELECT A.CO_BOOK,E.BOOK_SR_NAME,A.VCH_NO,A.VCH_DATE,  B.SR_NO,D.IT_NAME,D.HSN_CODE,B.ITM_NWT,D.UNIT_NAME,B.ITM_RATE,B.ITM_AMT,B.IT_DISC_AMT,B.NET_AMT,A.TAX_PRC,B.IT_TAX_AMT,B.LBR_AMT,B.OTH_AMT,B.NET_AMT As ItmNetAmt  FROM (((SL_DATA AS A LEFT JOIN SL_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)  LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)  LEFT JOIN ITEM_MAST AS D ON B.CO_CODE = D.CO_CODE And B.IT_CODE = D.IT_CODE)  LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE And A.LC_CODE = E.LC_CODE And A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + CurBook + "' AND A.VCH_NO = '" + CurVch + "' ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO,B.SR_NO";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		int i = 0;
		checked
		{
			int num = ((DataGridView)DGV_DETL).Rows.Count - 1 + 1;
			if (dataTable.Rows.Count <= 0)
			{
				return;
			}
			DataGridViewX dGV_DETL = DGV_DETL;
			for (; i < dataTable.Rows.Count; i++)
			{
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, num].Value = "Tax Invoice";
				((DataGridView)dGV_DETL)[1, num].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[i]["BOOK_SR_NAME"], (object)"-"), dataTable.Rows[i]["VCH_NO"]), (object)"");
				((DataGridView)dGV_DETL)[2, num].Value = Operators.ConcatenateObject(dataTable.Rows[i]["VCH_DATE"], (object)"");
				((DataGridView)dGV_DETL)[3, num].Value = Operators.ConcatenateObject(dataTable.Rows[i]["SR_NO"], (object)"");
				((DataGridView)dGV_DETL)[4, num].Value = Operators.ConcatenateObject(dataTable.Rows[i]["IT_NAME"], (object)"");
				((DataGridView)dGV_DETL)[5, num].Value = "No";
				((DataGridView)dGV_DETL)[6, num].Value = Operators.ConcatenateObject(dataTable.Rows[i]["HSN_CODE"], (object)"");
				((DataGridView)dGV_DETL)[7, num].Value = "";
				((DataGridView)dGV_DETL)[8, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ITM_NWT"], (object)"")), "0.000");
				((DataGridView)dGV_DETL)[9, num].Value = 0;
				((DataGridView)dGV_DETL)[10, num].Value = "GRAMMES";
				if ((Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ItmNetAmt"], (object)"")) != 0.0) & (Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ITM_NWT"], (object)"")) != 0.0))
				{
					((DataGridView)dGV_DETL)[11, num].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ItmNetAmt"], (object)"")) / Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ITM_NWT"], (object)""))), "0.000");
					((DataGridView)dGV_DETL)[12, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ItmNetAmt"], (object)"")), "0.00");
					((DataGridView)dGV_DETL)[15, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ItmNetAmt"], (object)"")), "0.00");
				}
				else
				{
					((DataGridView)dGV_DETL)[11, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ITM_RATE"], (object)"")), "0.000");
					((DataGridView)dGV_DETL)[12, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ITM_AMT"], (object)"")), "0.00");
					((DataGridView)dGV_DETL)[15, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["ITM_AMT"], (object)"")), "0.00");
				}
				((DataGridView)dGV_DETL)[13, num].Value = 0;
				((DataGridView)dGV_DETL)[14, num].Value = 0;
				((DataGridView)dGV_DETL)[16, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["TAX_PRC"], (object)"")), "0.000");
				if (IgstTax == 0.0)
				{
					if (Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["IT_TAX_AMT"], (object)"")) != 0.0)
					{
						((DataGridView)dGV_DETL)[17, num].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["IT_TAX_AMT"], (object)"")) / 2.0), "0.00");
						((DataGridView)dGV_DETL)[18, num].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["IT_TAX_AMT"], (object)"")) / 2.0), "0.00");
					}
				}
				else
				{
					((DataGridView)dGV_DETL)[19, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["IT_TAX_AMT"], (object)"")), "0.00");
				}
				((DataGridView)dGV_DETL)[20, num].Value = 0;
				((DataGridView)dGV_DETL)[21, num].Value = 0;
				((DataGridView)dGV_DETL)[22, num].Value = 0;
				((DataGridView)dGV_DETL)[23, num].Value = 0;
				((DataGridView)dGV_DETL)[24, num].Value = 0;
				((DataGridView)dGV_DETL)[25, num].Value = 0;
				((DataGridView)dGV_DETL)[26, num].Value = 0;
				((DataGridView)dGV_DETL)[27, num].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[i]["NET_AMT"], (object)"")) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[17, num].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[18, num].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[19, num].Value))), "0.00");
				num++;
			}
			dGV_DETL = null;
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
					break;
				case 15:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_0045;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 15;
				continue;
			}
			break;
			IL_0045:
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
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Invalid comparison between Unknown and I4
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		Worksheet worksheet = default(Worksheet);
		int num5 = default(int);
		int num6 = default(int);
		Application application = default(Application);
		Workbook workbook = default(Workbook);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		int num10 = default(int);
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
					case 1036:
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
								goto IL_0051;
							case 7:
								goto IL_0105;
							case 8:
								goto IL_011e;
							case 9:
								goto IL_0127;
							case 10:
								goto IL_0141;
							case 11:
								goto IL_0158;
							case 12:
								goto IL_0199;
							case 13:
								goto IL_01a8;
							case 14:
								goto IL_01c0;
							case 15:
								goto IL_01da;
							case 16:
								goto IL_01f4;
							case 17:
								goto IL_020b;
							case 18:
								goto IL_024c;
							case 19:
								goto IL_025b;
							case 20:
								goto IL_0273;
							case 21:
								goto IL_0287;
							case 22:
								goto IL_029b;
							case 23:
								goto IL_02b2;
							case 24:
							case 25:
								goto IL_032e;
							case 26:
								goto IL_0356;
							case 27:
								goto IL_0361;
							case 28:
								goto IL_0367;
							case 29:
								goto IL_036c;
							case 30:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 31:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_01a8:
						num2 = 13;
						DC_Main.i++;
						goto IL_01b7;
						IL_0158:
						num2 = 11;
						worksheet.Cells[DC_Main.i + 5, num5 + 1] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[num5, DC_Main.i].Value);
						goto IL_0199;
						IL_01a2:
						if (num5 <= num6)
						{
							goto IL_0158;
						}
						goto IL_01a8;
						IL_0199:
						num2 = 12;
						num5++;
						goto IL_01a2;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
						goto IL_0051;
						IL_0051:
						num2 = 6;
						workbook = application.Workbooks.Open(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\JSON_DC_BILL_ITEM.xlsm", RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						goto IL_0105;
						IL_0105:
						num2 = 7;
						worksheet = (Worksheet)workbook.Worksheets["einvoice"];
						goto IL_011e;
						IL_011e:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0127;
						IL_0127:
						num2 = 9;
						num7 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_01b7;
						IL_01b7:
						if (DC_Main.i <= num7)
						{
							goto IL_0141;
						}
						goto IL_01c0;
						IL_01c0:
						num2 = 14;
						worksheet = (Worksheet)workbook.Worksheets["Items"];
						goto IL_01da;
						IL_01da:
						num2 = 15;
						num8 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_026a;
						IL_026a:
						if (DC_Main.i <= num8)
						{
							goto IL_01f4;
						}
						goto IL_0273;
						IL_0273:
						num2 = 20;
						((FileDialog)DlgSave).Filter = "xlsm (*.xlsm)|*.xlsm";
						goto IL_0287;
						IL_0287:
						num2 = 21;
						((FileDialog)DlgSave).Title = "Save File";
						goto IL_029b;
						IL_029b:
						num2 = 22;
						if (unchecked((int)((CommonDialog)DlgSave).ShowDialog()) == 1)
						{
							goto IL_02b2;
						}
						goto IL_032e;
						IL_02b2:
						num2 = 23;
						workbook.SaveAs(((FileDialog)DlgSave).FileName, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						goto IL_032e;
						IL_032e:
						num2 = 25;
						workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						goto IL_0356;
						IL_0356:
						num2 = 26;
						application.Quit();
						goto IL_0361;
						IL_0361:
						num2 = 27;
						worksheet = null;
						goto IL_0367;
						IL_0367:
						num2 = 28;
						workbook = null;
						goto IL_036c;
						IL_036c:
						num2 = 29;
						application = null;
						break;
						IL_01f4:
						num2 = 16;
						num9 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num10 = 0;
						goto IL_0255;
						IL_0255:
						if (num10 <= num9)
						{
							goto IL_020b;
						}
						goto IL_025b;
						IL_025b:
						num2 = 19;
						DC_Main.i++;
						goto IL_026a;
						IL_020b:
						num2 = 17;
						worksheet.Cells[DC_Main.i + 5, num10 + 1] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[num10, DC_Main.i].Value);
						goto IL_024c;
						IL_024c:
						num2 = 18;
						num10++;
						goto IL_0255;
						IL_0141:
						num2 = 10;
						num6 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_01a2;
						end_IL_0001_2:
						break;
					}
					num2 = 30;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1036;
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

	private void UT_E_INVOICE_Load(object sender, EventArgs e)
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
				DataGridViewX dGV2 = DGV;
				object? obj12 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
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
				DataGridViewX dGV3 = DGV;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
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

	private void UT_E_INVOICE_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void UT_E_INVOICE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_E_INVOICE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void UT_E_INVOICE_KeyDown(object sender, KeyEventArgs e)
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

	private void UT_E_INVOICE_Closed(object sender, EventArgs e)
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

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
	}

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
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

	private void cboValType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
			{
				DGV_ITM_FILL();
			}
			else if (Operators.CompareString(CurRpt, "Party InOut", false) == 0)
			{
				DGV_ITM_FILL();
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		DGV_ITM_FILL();
	}
}
