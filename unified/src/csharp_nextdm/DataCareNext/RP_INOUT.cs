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

namespace DataCareNext;

[DesignerGenerated]
public class RP_INOUT : Form
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
	[AccessedThroughProperty("cboValType")]
	private ComboBox _cboValType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkProcuctWise")]
	private CheckBox _chkProcuctWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLdrCode")]
	private TextBox _tLdrCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string[] ArySchmCode;

	private string[] AryEmpCode;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNoCr = 0;

	private const int cVchDate = 1;

	private const int cBookCr = 2;

	private const int cVchNoCr = 3;

	private const int cLdAcNameCr = 4;

	private const int cCrPcs = 5;

	private const int cCrNwt = 6;

	private const int cCrFine = 7;

	private const int cCrSilver = 8;

	private const int cCrAmt = 9;

	private const int cSrNoDr = 10;

	private const int cBookDr = 11;

	private const int cVchNoDr = 12;

	private const int cLdAcNameDr = 13;

	private const int cDrPcs = 14;

	private const int cDrNwt = 15;

	private const int cDrFine = 16;

	private const int cDrSilver = 17;

	private const int cDrAmt = 18;

	private const int cBookCodeCr = 19;

	private const int cBookNameCr = 20;

	private const int cBookCodeDr = 21;

	private const int cBookNameDr = 22;

	private const int c1SrNo = 0;

	private const int c1Book = 1;

	private const int c1VchNo = 2;

	private const int c1VchDate = 3;

	private const int c1OsDay = 4;

	private const int c1Pcs = 5;

	private const int c1Gwt = 6;

	private const int c1Nwt = 7;

	private const int c1TotAmt = 8;

	private const int c1AdjAmt = 9;

	private const int c1OsAmt = 10;

	private const int c1AmtCr = 11;

	private const int c1GlFine = 12;

	private const int c1GlAdjFine = 13;

	private const int c1GlOsFine = 14;

	private const int c1GoldCr = 15;

	private const int c1SlFine = 16;

	private const int c1SlAdjFine = 17;

	private const int c1SlOsFine = 18;

	private const int c1SlvrCr = 19;

	private const int c1BookCode = 20;

	private const int c1BookName = 21;

	private const int cInSrNo = 0;

	private const int cInBook = 1;

	private const int cInVchNo = 2;

	private const int cInVchDate = 3;

	private const int cInAcCode = 4;

	private const int cInAcName = 5;

	private const int cInCrDay = 6;

	private const int cInIntDay = 7;

	private const int cInTotAmt = 8;

	private const int cInAdjAmt = 9;

	private const int cInOsAmt = 10;

	private const int cInIntPrc = 11;

	private const int cInIntAmt = 12;

	private const int cInPanAmt = 13;

	private const int cInBookCode = 14;

	private const int cInBookName = 15;

	private const int cLSrNo = 0;

	private const int cLVchDate = 1;

	private const int cLVchNo = 2;

	private const int cLBookName = 3;

	private const int cLInPcs = 4;

	private const int cLInGrWt = 5;

	private const int cLInNetWt = 6;

	private const int cLInFine = 7;

	private const int cLOutPcs = 8;

	private const int cLOutGrWt = 9;

	private const int cLOutNetWt = 10;

	private const int cLOutFine = 11;

	private const int cLBalPcs = 12;

	private const int cLBalGrWt = 13;

	private const int cLBalNetWt = 14;

	private const int cLBalFine = 15;

	private const int cLCoBook = 16;

	private const int cLMainBook = 17;

	private const int cLRemark = 18;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_DETL_CellContentClick);
			DataGridViewX val3 = _DGV_DETL;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((DataGridView)val3).CellContentClick -= val2;
			}
			_DGV_DETL = value;
			val3 = _DGV_DETL;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((Control)val3).DoubleClick += eventHandler;
				((DataGridView)val3).CellContentClick += val2;
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

	internal virtual ComboBox cboValType
	{
		[CompilerGenerated]
		get
		{
			return _cboValType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboValType_KeyDown);
			ComboBox val2 = _cboValType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboValType = value;
			val2 = _cboValType;
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

	internal virtual CheckBox chkProcuctWise
	{
		[CompilerGenerated]
		get
		{
			return _chkProcuctWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkProcuctWise_CheckedChanged;
			CheckBox val = _chkProcuctWise;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkProcuctWise = value;
			val = _chkProcuctWise;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
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
	[AccessedThroughProperty("lblLdrCode")]
	private virtual Label _lblLdrCode;

	internal virtual Label lblLdrCode
	{
		get
		{
			return _lblLdrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLdrCode = value;
		}
	}

	internal virtual TextBox tLdrCode
	{
		[CompilerGenerated]
		get
		{
			return _tLdrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tLdrCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tLdrCode_KeyDown);
			TextBox val2 = _tLdrCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tLdrCode = value;
			val2 = _tLdrCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLdrName")]
	private virtual TextBox _tLdrName;

	internal virtual TextBox tLdrName
	{
		get
		{
			return _tLdrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLdrName = value;
		}
	}

	public int newindex { get; set; }

	public RP_INOUT()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += RP_INOUT_Load;
		((Form)this).Activated += RP_INOUT_Activated;
		((Form)this).Deactivate += RP_INOUT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_INOUT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_INOUT_KeyDown);
		((Form)this).Closed += RP_INOUT_Closed;
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
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected O, but got Unknown
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Expected O, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Expected O, but got Unknown
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Expected O, but got Unknown
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Expected O, but got Unknown
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Expected O, but got Unknown
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c6: Expected O, but got Unknown
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_0982: Expected O, but got Unknown
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Expected O, but got Unknown
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aea: Expected O, but got Unknown
		//IL_0b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba3: Expected O, but got Unknown
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Expected O, but got Unknown
		//IL_0ca8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb2: Expected O, but got Unknown
		//IL_0d7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d87: Expected O, but got Unknown
		//IL_0e1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e26: Expected O, but got Unknown
		//IL_0ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eae: Expected O, but got Unknown
		//IL_0f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9a: Expected O, but got Unknown
		//IL_1003: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Expected O, but got Unknown
		//IL_109f: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a9: Expected O, but got Unknown
		//IL_1157: Unknown result type (might be due to invalid IL or missing references)
		//IL_1161: Expected O, but got Unknown
		//IL_11f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1202: Expected O, but got Unknown
		//IL_12b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bb: Expected O, but got Unknown
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_1343: Expected O, but got Unknown
		//IL_13f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fb: Expected O, but got Unknown
		//IL_14bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c5: Expected O, but got Unknown
		//IL_1580: Unknown result type (might be due to invalid IL or missing references)
		//IL_158a: Expected O, but got Unknown
		//IL_1615: Unknown result type (might be due to invalid IL or missing references)
		//IL_161f: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_INOUT));
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
		lblMobile = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		Label4 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		cboValType = new ComboBox();
		Label3 = new Label();
		chkProcuctWise = new CheckBox();
		lblLdrCode = new Label();
		tLdrCode = new TextBox();
		tLdrName = new TextBox();
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
		((Control)PnlBotam).Controls.Add((Control)(object)lblMobile);
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
		((Control)lblMobile).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.White;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(450, 0);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).RightToLeft = (RightToLeft)0;
		((Control)lblMobile).Size = new Size(274, 36);
		((Control)lblMobile).TabIndex = 1142;
		lblMobile.Text = "Mobile";
		lblMobile.TextAlign = (ContentAlignment)64;
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
		lblBook.Text = "In Out Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(82, 73);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 22);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(164, 73);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(273, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(-19, 72);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(94, 20);
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
		((Control)DGV_DETL).Location = new Point(13, 102);
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
		((Control)DGV_DETL).Size = new Size(1159, 454);
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
		cboValType.AutoCompleteMode = (AutoCompleteMode)3;
		cboValType.AutoCompleteSource = (AutoCompleteSource)256;
		cboValType.BackColor = Color.White;
		((Control)cboValType).Font = new Font("Tahoma", 9f);
		((ListControl)cboValType).FormattingEnabled = true;
		((Control)cboValType).Location = new Point(334, 45);
		((Control)cboValType).Name = "cboValType";
		((Control)cboValType).Size = new Size(103, 22);
		((Control)cboValType).TabIndex = 1160;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(247, 45);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(82, 19);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Value Type";
		Label3.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkProcuctWise).BackColor = Color.Transparent;
		((Control)chkProcuctWise).Font = new Font("Arial", 9.75f);
		((Control)chkProcuctWise).ForeColor = Color.Black;
		((ButtonBase)chkProcuctWise).ImeMode = (ImeMode)0;
		((Control)chkProcuctWise).Location = new Point(473, 42);
		((Control)chkProcuctWise).Name = "chkProcuctWise";
		((Control)chkProcuctWise).RightToLeft = (RightToLeft)0;
		((Control)chkProcuctWise).Size = new Size(178, 27);
		((Control)chkProcuctWise).TabIndex = 1162;
		((ButtonBase)chkProcuctWise).Text = "Procuct Wise Stock";
		((ButtonBase)chkProcuctWise).UseVisualStyleBackColor = false;
		((Control)lblLdrCode).BackColor = Color.Transparent;
		((Control)lblLdrCode).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLdrCode).ForeColor = Color.Black;
		lblLdrCode.ImeMode = (ImeMode)0;
		((Control)lblLdrCode).Location = new Point(442, 73);
		((Control)lblLdrCode).Name = "lblLdrCode";
		((Control)lblLdrCode).Size = new Size(94, 20);
		((Control)lblLdrCode).TabIndex = 1165;
		lblLdrCode.Text = "Ledger Ac";
		lblLdrCode.TextAlign = (ContentAlignment)64;
		((Control)lblLdrCode).Visible = false;
		((TextBoxBase)tLdrCode).BackColor = Color.White;
		((Control)tLdrCode).Font = new Font("Tahoma", 9f);
		((Control)tLdrCode).Location = new Point(541, 73);
		((TextBoxBase)tLdrCode).MaxLength = 8;
		((Control)tLdrCode).Name = "tLdrCode";
		((Control)tLdrCode).Size = new Size(76, 22);
		((Control)tLdrCode).TabIndex = 1163;
		((Control)tLdrCode).Visible = false;
		((TextBoxBase)tLdrName).BackColor = Color.White;
		((Control)tLdrName).Font = new Font("Tahoma", 9.75f);
		((Control)tLdrName).Location = new Point(624, 72);
		((TextBoxBase)tLdrName).MaxLength = 8;
		((Control)tLdrName).Name = "tLdrName";
		((Control)tLdrName).Size = new Size(273, 23);
		((Control)tLdrName).TabIndex = 1164;
		((Control)tLdrName).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)lblLdrCode);
		((Control)this).Controls.Add((Control)(object)tLdrCode);
		((Control)this).Controls.Add((Control)(object)tLdrName);
		((Control)this).Controls.Add((Control)(object)chkProcuctWise);
		((Control)this).Controls.Add((Control)(object)cboValType);
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
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_INOUT";
		((Form)this).Text = "Inout Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void Stock_Balance()
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
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Expected O, but got Unknown
		//IL_251b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2525: Expected O, but got Unknown
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
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "InPcs");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "InGwt");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "InNwt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "InFine");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "OutPcs");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "OutGwt");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "OutNWt");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "OutFine");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "BalPcs");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "BalGwt");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "BalNwt");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "BalFine");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "DbCd");
			((DataGridView)DGV_DETL).Columns[16].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[17].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "Remark");
			((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE - ITM_PCS END) as Pcs,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE - ITM_GWT END) as GrWt, Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE - ITM_NWT END) as NetWt,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) As FineWt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  and A.IT_CODE = '"), (object)tAcCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tLdrCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tLdrCode.Text + "'"))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.IT_CODE"));
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_DATE,A.CO_BOOK,A.VCH_NO,B.IT_CODE AS Code,C.BOOK_SNAME As VchType,C.MAIN_BOOK As MainBook, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS InGwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS InNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS InFine, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS OutGwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS OutNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS OutFine FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND "), (object)"A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' And A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tLdrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tLdrCode.Text + "'";
			}
			DC_Main.RsQry += "GROUP BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO,B.IT_CODE,C.BOOK_SNAME,C.MAIN_BOOK ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,VCH_REMARK FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'";
			DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(table);
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
			double num12 = 0.0;
			DC_Main.X = 0;
			int num13 = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, num13].Value = num13 + 1;
				((DataGridView)dGV_DETL)[1, num13].Value = Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy");
				((DataGridView)dGV_DETL)[3, num13].Value = "Op Stk";
				((DataGridView)dGV_DETL)[4, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["Pcs"], (object)"")), "0");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[4, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[4, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[5, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["GrWt"], (object)"")), "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[5, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[6, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["NetWt"], (object)"")), "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[6, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[6, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[7, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FineWt"], (object)"")), "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[7, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[12, num13].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[4, num13].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, num13].Value))), "0");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[12, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[13, num13].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, num13].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, num13].Value))), "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[13, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[13, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[14, num13].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[6, num13].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, num13].Value))), "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[14, num13].Value = "";
				}
				((DataGridView)dGV_DETL)[15, num13].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, num13].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[11, num13].Value))), "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, num13].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL)[15, num13].Value = "";
				}
				num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[4, num13].Value));
				num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[5, num13].Value));
				num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[6, num13].Value));
				num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, num13].Value));
				num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, num13].Value));
				num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[13, num13].Value));
				num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, num13].Value));
				num12 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, num13].Value));
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL2 = DGV_DETL;
				while (DC_Main.X < dataTable2.Rows.Count)
				{
					((DataGridView)dGV_DETL2).Rows.Add();
					num13 = ((DataGridView)dGV_DETL2).Rows.Count - 1;
					((DataGridView)dGV_DETL2)[0, num13].Value = num13 + 1;
					((DataGridView)dGV_DETL2)[1, num13].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
					((DataGridView)dGV_DETL2)[2, num13].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_NO"], (object)"");
					((DataGridView)dGV_DETL2)[3, num13].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VchType"], (object)"");
					((DataGridView)dGV_DETL2)[4, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["InPcs"], (object)"")), "0");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[4, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[4, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[5, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["InGwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[5, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[5, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[6, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["InNwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[6, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[6, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[7, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["InFine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[7, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[7, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[8, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["OutPcs"], (object)"")), "0");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[8, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[8, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[9, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["OutGwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[9, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[9, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[10, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["OutNwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[10, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[10, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[11, num13].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["OutFine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[11, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[11, num13].Value = "";
					}
					num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[4, num13].Value));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[5, num13].Value));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[6, num13].Value));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[7, num13].Value));
					num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[8, num13].Value));
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[9, num13].Value));
					num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[10, num13].Value));
					num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[11, num13].Value));
					((DataGridView)dGV_DETL2)[12, num13].Value = Strings.Format((object)(num - num2), "0");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[12, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[12, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[13, num13].Value = Strings.Format((object)(num4 - num5), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[13, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[13, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[14, num13].Value = Strings.Format((object)(num7 - num8), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[14, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[14, num13].Value = "";
					}
					((DataGridView)dGV_DETL2)[15, num13].Value = Strings.Format((object)(num10 - num11), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[15, num13].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL2)[15, num13].Value = "";
					}
					num3 = num - num2;
					num6 = num4 - num5;
					num9 = num7 - num8;
					num12 = num10 - num11;
					((DataGridView)dGV_DETL2)[16, num13].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CO_BOOK"], (object)"");
					((DataGridView)dGV_DETL2)[17, num13].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["MainBook"], (object)"");
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.X]["CO_BOOK"]), (object)""), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.X]["VCH_NO"]), (object)""), (object)"'"));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV_DETL2)[18, num13].Value = Operators.ConcatenateObject(dataView[0]["VCH_REMARK"], (object)"");
					}
					num13++;
					DC_Main.X++;
				}
				dGV_DETL2 = null;
			}
			DataGridViewX dGV_DETL3 = DGV_DETL;
			((DataGridView)dGV_DETL3).Rows.Add();
			((DataGridView)dGV_DETL3).Rows.Add();
			num13 = ((DataGridView)dGV_DETL3).Rows.Count - 1;
			((DataGridView)dGV_DETL3)[3, num13].Value = "Total :";
			((DataGridView)dGV_DETL3)[4, num13].Value = Strings.Format((object)num, "0");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[4, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[4, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[5, num13].Value = Strings.Format((object)num4, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[5, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[5, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[6, num13].Value = Strings.Format((object)num7, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[6, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[6, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[7, num13].Value = Strings.Format((object)num10, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[7, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[7, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[8, num13].Value = Strings.Format((object)num2, "0");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[8, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[8, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[9, num13].Value = Strings.Format((object)num5, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[9, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[9, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[10, num13].Value = Strings.Format((object)num8, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[10, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[10, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[11, num13].Value = Strings.Format((object)num11, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[11, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[11, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[12, num13].Value = Strings.Format((object)num3, "0");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[12, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[12, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[13, num13].Value = Strings.Format((object)num6, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[13, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[13, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[14, num13].Value = Strings.Format((object)num9, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[14, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[14, num13].Value = "";
			}
			((DataGridView)dGV_DETL3)[15, num13].Value = Strings.Format((object)num12, "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[15, num13].Value)) == 0.0)
			{
				((DataGridView)dGV_DETL3)[15, num13].Value = "";
			}
			dGV_DETL3 = null;
			((DataGridView)DGV_DETL).Rows[num13].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[num13].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
		}
	}

	private void Bill_Interest_Rpt()
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
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Expected O, but got Unknown
		//IL_10eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f5: Expected O, but got Unknown
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
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "AcName");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "CrDay");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "IntDay");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "TotAmt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "AdjAmt");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "OsAmt");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "Int%");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "IntAmt");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "TotPan");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "DbCd");
			((DataGridView)DGV_DETL).Columns[14].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[15].Visible = false;
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.BOOK_SNAME,A.VCH_DATE,A.VCH_NO,A.AC_CODE,C.AC_NAME,A.CO_BOOK,D.MAIN_BOOK,A.CR_DAYS,C.AC_INT_PRC,  A.TOT_AMT As TotAmt,SUM(B.REC_AMT) As AdjAmt,SUM(B.KASAR_AMT) As KsrAmt  FROM ((SL_DATA AS A LEFT JOIN BILL_OS_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.BILL_YRCD AND A.CO_BOOK = B.BILL_DBCD AND A.VCH_NO = B.BILL_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tAcCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND C.AC_INT_PRC <> 0 "));
			DC_Main.RsQry += " GROUP BY D.BOOK_SNAME,A.VCH_DATE,A.VCH_NO,A.AC_CODE,C.AC_NAME,A.CO_BOOK,D.MAIN_BOOK,A.CR_DAYS,C.AC_INT_PRC,A.TOT_AMT HAVING  A.TOT_AMT -(SUM(B.REC_AMT)+SUM(B.KASAR_AMT)) > 0   ORDER BY A.CO_BOOK,A.VCH_NO ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			DC_Main.X = 0;
			DC_Main.R = 0;
			if (dataTable.Rows.Count <= 0)
			{
				return;
			}
			DataGridViewX dGV_DETL = DGV_DETL;
			while (DC_Main.X < dataTable.Rows.Count)
			{
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_SNAME"], (object)"");
				((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_NO"], (object)"");
				((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_CODE"], (object)"");
				((DataGridView)dGV_DETL)[5, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_NAME"], (object)"");
				((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
				((DataGridView)dGV_DETL)[6, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CR_DAYS"], (object)"")), Conversions.ToString(0));
				((DataGridView)dGV_DETL)[7, DC_Main.R].Value = (double)Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDt.Text), Conversions.ToDate(((DataGridView)dGV_DETL)[3, DC_Main.R].Value), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[6, DC_Main.R].Value));
				((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["TotAmt"], (object)"")), "0.00");
				((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AdjAmt"], (object)"")), "0.00");
				((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value))), "0.00");
				((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_INT_PRC"], (object)"")), "0.00");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[11, DC_Main.R].Value)) != 0.0)
				{
					((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
					{
						Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(((DataGridView)dGV_DETL)[10, DC_Main.R].Value, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value), (object)12), (object)100), ((DataGridView)dGV_DETL)[7, DC_Main.R].Value), (object)DC_Main.MsIntYearDays),
						0
					}, (string[])null, (Type[])null, (bool[])null)), "0.00");
				}
				((DataGridView)dGV_DETL)[13, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value))), "0.00");
				((DataGridView)dGV_DETL)[14, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CO_BOOK"], (object)"");
				((DataGridView)dGV_DETL)[15, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MAIN_BOOK"], (object)"");
				num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
				num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
				num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
				num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
				num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
				DC_Main.R++;
				DC_Main.X++;
			}
			dGV_DETL = null;
			DataGridViewX dGV_DETL2 = DGV_DETL;
			((DataGridView)dGV_DETL2).Rows.Add();
			((DataGridView)dGV_DETL2).Rows.Add();
			DC_Main.R = ((DataGridView)dGV_DETL2).Rows.Count - 1;
			((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = "Total :";
			((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = Strings.Format((object)num, "0.0");
			((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = Strings.Format((object)num2, "0.0");
			((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = Strings.Format((object)num3, "0.0");
			((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = Strings.Format((object)num4, "0.0");
			((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = Strings.Format((object)num5, "0.0");
			dGV_DETL2 = null;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
		}
	}

	private void Bill_Os_Day()
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
		//IL_0cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc9: Expected O, but got Unknown
		//IL_2a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a10: Expected O, but got Unknown
		//IL_2c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c60: Expected O, but got Unknown
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
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Day");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(45.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(45.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DETL).Columns.Add("", "GrWt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "TotAmt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "AdjAmt");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "OsAmt");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "CrAmt");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "GlFine");
			((DataGridView)DGV_DETL).Columns.Add("", "GlAdj");
			((DataGridView)DGV_DETL).Columns.Add("", "GlOsFine");
			((DataGridView)DGV_DETL).Columns.Add("", "GoldCr");
			if (cboValType.SelectedIndex == 0)
			{
				((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			}
			else
			{
				((DataGridView)DGV_DETL).Columns[12].Visible = false;
				((DataGridView)DGV_DETL).Columns[13].Visible = false;
				((DataGridView)DGV_DETL).Columns[14].Visible = false;
				((DataGridView)DGV_DETL).Columns[15].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "SlFine");
			((DataGridView)DGV_DETL).Columns.Add("", "AdjFine");
			((DataGridView)DGV_DETL).Columns.Add("", "OsFine");
			((DataGridView)DGV_DETL).Columns.Add("", "SlvrCr");
			if (cboValType.SelectedIndex == 1)
			{
				((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N3";
			}
			else
			{
				((DataGridView)DGV_DETL).Columns[16].Visible = false;
				((DataGridView)DGV_DETL).Columns[17].Visible = false;
				((DataGridView)DGV_DETL).Columns[18].Visible = false;
				((DataGridView)DGV_DETL).Columns[19].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "CoBookCr");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBookCr");
			((DataGridView)DGV_DETL).Columns[21].Visible = false;
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
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
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			int num16 = 0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, num16].Value = num16 + 1;
				((DataGridView)dGV_DETL)[3, num16].Value = "Op Balance";
				((DataGridView)dGV_DETL)[8, num16].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])));
				((DataGridView)dGV_DETL)[11, num16].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])));
				((DataGridView)dGV_DETL)[12, num16].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"])));
				((DataGridView)dGV_DETL)[15, num16].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"])));
				((DataGridView)dGV_DETL)[16, num16].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"])));
				((DataGridView)dGV_DETL)[19, num16].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"])));
				num = Conversions.ToDouble(((DataGridView)dGV_DETL)[5, num16].Value);
				num2 = Conversions.ToDouble(((DataGridView)dGV_DETL)[6, num16].Value);
				num3 = Conversions.ToDouble(((DataGridView)dGV_DETL)[7, num16].Value);
				num5 = Conversions.ToDouble(((DataGridView)dGV_DETL)[8, num16].Value);
				num6 = Conversions.ToDouble(((DataGridView)dGV_DETL)[9, num16].Value);
				num7 = Conversions.ToDouble(((DataGridView)dGV_DETL)[10, num16].Value);
				num4 = Conversions.ToDouble(((DataGridView)dGV_DETL)[11, num16].Value);
				num9 = Conversions.ToDouble(((DataGridView)dGV_DETL)[12, num16].Value);
				num10 = Conversions.ToDouble(((DataGridView)dGV_DETL)[13, num16].Value);
				num11 = Conversions.ToDouble(((DataGridView)dGV_DETL)[14, num16].Value);
				num8 = Conversions.ToDouble(((DataGridView)dGV_DETL)[15, num16].Value);
				num13 = Conversions.ToDouble(((DataGridView)dGV_DETL)[16, num16].Value);
				num14 = Conversions.ToDouble(((DataGridView)dGV_DETL)[17, num16].Value);
				num15 = Conversions.ToDouble(((DataGridView)dGV_DETL)[18, num16].Value);
				num12 = Conversions.ToDouble(((DataGridView)dGV_DETL)[16, num16].Value);
				dGV_DETL = null;
			}
			else
			{
				((DataGridView)DGV_DETL).Rows.Add();
				((DataGridView)DGV_DETL)[0, num16].Value = num16 + 1;
				((DataGridView)DGV_DETL)[3, num16].Value = "Op Balance";
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.CO_YEAR,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,B.BOOK_SNAME,B.BOOK_NAME,  SUM(A.DR_AMT) As DrAmt,SUM(A.CR_AMT) CrAmt,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END) As DrGold,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrGold,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END) As DrSilver,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrSilver  FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY A.CO_YEAR,A.VCH_DATE,A.CO_BOOK,B.BOOK_SNAME,B.BOOK_NAME,A.VCH_NO  "), (object)" HAVING ROUND(SUM(A.DR_AMT),2)+ROUND(SUM(A.CR_AMT),2)+ "), (object)" ROUND(SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END),3)+ ROUND(SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END),3)+ "), (object)" ROUND(SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END),3)+ ROUND(SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END),3) > 0  "), (object)" ORDER BY A.CO_YEAR,A.VCH_DATE,A.CO_BOOK,B.BOOK_SNAME,B.BOOK_NAME,A.VCH_NO"));
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (dataTable2.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL2 = DGV_DETL;
				while (DC_Main.X < dataTable2.Rows.Count)
				{
					((DataGridView)dGV_DETL2).Rows.Add();
					num16++;
					((DataGridView)dGV_DETL2)[0, num16].Value = num16 + 1;
					((DataGridView)dGV_DETL2)[1, num16].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["BOOK_SNAME"], (object)"");
					((DataGridView)dGV_DETL2)[2, num16].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_NO"], (object)"");
					((DataGridView)dGV_DETL2)[3, num16].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
					((DataGridView)dGV_DETL2)[4, num16].Value = Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDt.Text), Conversions.ToDate(((DataGridView)dGV_DETL2)[3, num16].Value), (FirstDayOfWeek)1, (FirstWeekOfYear)1));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_BOOK,VCH_NO,SUM(ITM_PCS) As ItPcs,SUM(ITM_GWT) As ItGwt,SUM(ITM_NWT) As ItNwt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[DC_Main.X]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.X]["VCH_NO"]), (object)"' GROUP BY CO_BOOK,VCH_NO  "));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						((DataGridView)dGV_DETL2)[5, num16].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ItPcs"], (object)"");
						((DataGridView)dGV_DETL2)[6, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ItGwt"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[7, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ItNwt"], (object)"")), "0.000");
					}
					((DataGridView)dGV_DETL2)[8, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["DrAmt"], (object)"")), "0.0");
					((DataGridView)dGV_DETL2)[10, num16].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[8, num16].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[9, num16].Value))), "0.0");
					((DataGridView)dGV_DETL2)[11, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CrAmt"], (object)"")), "0.0");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[11, num16].Value)) != 0.0)
					{
						((DataGridView)dGV_DETL2).Rows[num16].Cells[4].Style.ForeColor = Color.DarkGreen;
						((DataGridView)dGV_DETL2).Rows[num16].Cells[11].Style.ForeColor = Color.DarkGreen;
					}
					((DataGridView)dGV_DETL2)[12, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["DrGold"], (object)"")), "0.000");
					((DataGridView)dGV_DETL2)[14, num16].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[12, num16].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[13, num16].Value))), "0.000");
					((DataGridView)dGV_DETL2)[15, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CrGold"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[15, num16].Value)) != 0.0)
					{
						((DataGridView)dGV_DETL2).Rows[num16].Cells[4].Style.ForeColor = Color.DarkGreen;
						((DataGridView)dGV_DETL2).Rows[num16].Cells[15].Style.ForeColor = Color.DarkGreen;
					}
					((DataGridView)dGV_DETL2)[16, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["DrSilver"], (object)"")), "0.000");
					((DataGridView)dGV_DETL2)[18, num16].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[16, num16].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[17, num16].Value))), "0.000");
					((DataGridView)dGV_DETL2)[19, num16].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CrSilver"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[19, num16].Value)) != 0.0)
					{
						((DataGridView)dGV_DETL2).Rows[num16].Cells[4].Style.ForeColor = Color.DarkGreen;
						((DataGridView)dGV_DETL2).Rows[num16].Cells[19].Style.ForeColor = Color.DarkGreen;
					}
					((DataGridView)dGV_DETL2)[20, num16].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CO_BOOK"], (object)"");
					((DataGridView)dGV_DETL2)[21, num16].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
					num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL2)[5, num16].Value));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL2)[6, num16].Value));
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL2)[7, num16].Value));
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL2)[8, num16].Value));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL2)[9, num16].Value));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL2)[11, num16].Value));
					num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV_DETL2)[12, num16].Value));
					num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL2)[13, num16].Value));
					num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV_DETL2)[15, num16].Value));
					num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV_DETL2)[16, num16].Value));
					num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV_DETL2)[17, num16].Value));
					num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV_DETL2)[19, num16].Value));
					DC_Main.X++;
				}
				dGV_DETL2 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(A.CR_AMT) As CrAmt,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrGold,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrSilver  FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" HAVING ROUND(SUM(A.CR_AMT),2)+ROUND(SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END),3)+ROUND(SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END),3) > 0  "));
				dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable2.Rows.Count > 0)
				{
					num17 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["CrAmt"], (object)"")), "0.00"));
					num18 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["CrGold"], (object)"")), "0.000"));
					num19 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["CrSilver"], (object)"")), "0.000"));
				}
				int num20 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				for (int i = 0; i <= num20; i++)
				{
					DataGridViewX dGV_DETL3 = DGV_DETL;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[8, i].Value)) != 0.0)
					{
						if (Operators.ConditionalCompareObjectGreaterEqual((object)num17, ((DataGridView)dGV_DETL3)[8, i].Value, false))
						{
							((DataGridView)dGV_DETL3)[9, i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[8, i].Value)), "0.0");
							num17 -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[8, i].Value)), "0.0"));
						}
						else
						{
							((DataGridView)dGV_DETL3)[9, i].Value = Strings.Format((object)num17, "0.0");
							num17 = 0.0;
						}
						((DataGridView)dGV_DETL3)[10, i].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[8, i].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[9, i].Value))), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[10, i].Value)) > 0.0)
						{
							((DataGridView)dGV_DETL3).Rows[i].Cells[4].Style.ForeColor = Color.Red;
							((DataGridView)dGV_DETL3).Rows[i].Cells[10].Style.ForeColor = Color.Red;
						}
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL3)[10, i].Value));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[12, i].Value)) != 0.0)
					{
						if (Operators.ConditionalCompareObjectGreaterEqual((object)num18, ((DataGridView)dGV_DETL3)[12, i].Value, false))
						{
							((DataGridView)dGV_DETL3)[13, i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[12, i].Value)), "0.000");
							num18 -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[12, i].Value)), "0.000"));
						}
						else
						{
							((DataGridView)dGV_DETL3)[13, i].Value = Strings.Format((object)num18, "0.000");
							num18 = 0.0;
						}
						((DataGridView)dGV_DETL3)[14, i].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[12, i].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[13, i].Value))), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[14, i].Value)) > 0.0)
						{
							((DataGridView)dGV_DETL3).Rows[i].Cells[4].Style.ForeColor = Color.Red;
							((DataGridView)dGV_DETL3).Rows[i].Cells[14].Style.ForeColor = Color.Red;
						}
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV_DETL3)[14, i].Value));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[16, i].Value)) != 0.0)
					{
						if (Operators.ConditionalCompareObjectGreaterEqual((object)num19, ((DataGridView)dGV_DETL3)[16, i].Value, false))
						{
							((DataGridView)dGV_DETL3)[17, i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[16, i].Value)), "0.000");
							num19 -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[16, i].Value)), "0.000"));
						}
						else
						{
							((DataGridView)dGV_DETL3)[17, i].Value = Strings.Format((object)num19, "0.000");
							num19 = 0.0;
						}
						((DataGridView)dGV_DETL3)[18, i].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[16, i].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[17, i].Value))), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[18, i].Value)) > 0.0)
						{
							((DataGridView)dGV_DETL3).Rows[i].Cells[4].Style.ForeColor = Color.Red;
							((DataGridView)dGV_DETL3).Rows[i].Cells[18].Style.ForeColor = Color.Red;
						}
						num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV_DETL3)[18, i].Value));
					}
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL3)[9, i].Value));
					num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL3)[13, i].Value));
					num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV_DETL3)[17, i].Value));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[8, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[8, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[9, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[9, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[10, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[10, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[11, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[11, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[12, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[12, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[13, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[13, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[14, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[14, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[15, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[15, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[16, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[16, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[17, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[17, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[18, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[18, i].Value = "";
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL3)[19, i].Value)) == 0.0)
					{
						((DataGridView)dGV_DETL3)[19, i].Value = "";
					}
					dGV_DETL3 = null;
				}
			}
			DataGridViewX dGV_DETL4 = DGV_DETL;
			((DataGridView)dGV_DETL4).Rows.Add();
			((DataGridView)dGV_DETL4).Rows.Add();
			num16 = ((DataGridView)dGV_DETL4).Rows.Count - 1;
			((DataGridView)dGV_DETL4)[3, num16].Value = "Total :";
			((DataGridView)dGV_DETL4)[5, num16].Value = Strings.Format((object)num, "0");
			((DataGridView)dGV_DETL4)[6, num16].Value = Strings.Format((object)num2, "0.000");
			((DataGridView)dGV_DETL4)[7, num16].Value = Strings.Format((object)num3, "0.000");
			((DataGridView)dGV_DETL4)[8, num16].Value = Strings.Format((object)num5, "0.0");
			((DataGridView)dGV_DETL4)[9, num16].Value = Strings.Format((object)num6, "0.0");
			((DataGridView)dGV_DETL4)[10, num16].Value = Strings.Format((object)num7, "0.0");
			((DataGridView)dGV_DETL4)[11, num16].Value = Strings.Format((object)num4, "0.0");
			((DataGridView)dGV_DETL4)[12, num16].Value = Strings.Format((object)num9, "0.000");
			((DataGridView)dGV_DETL4)[13, num16].Value = Strings.Format((object)num10, "0.000");
			((DataGridView)dGV_DETL4)[14, num16].Value = Strings.Format((object)num11, "0.000");
			((DataGridView)dGV_DETL4)[15, num16].Value = Strings.Format((object)num8, "0.000");
			((DataGridView)dGV_DETL4)[16, num16].Value = Strings.Format((object)num13, "0.000");
			((DataGridView)dGV_DETL4)[17, num16].Value = Strings.Format((object)num14, "0.000");
			((DataGridView)dGV_DETL4)[18, num16].Value = Strings.Format((object)num15, "0.000");
			((DataGridView)dGV_DETL4)[19, num16].Value = Strings.Format((object)num12, "0.000");
			dGV_DETL4 = null;
			((DataGridView)DGV_DETL).Rows[num16].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[num16].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
			if (num17 + num18 + num19 > 0.0)
			{
				DataGridViewX dGV_DETL5 = DGV_DETL;
				((DataGridView)dGV_DETL5).Rows.Add();
				((DataGridView)dGV_DETL5).Rows.Add();
				num16 = ((DataGridView)dGV_DETL5).Rows.Count - 1;
				((DataGridView)dGV_DETL5)[9, num16].Value = "Cr Amt";
				((DataGridView)dGV_DETL5)[10, num16].Value = Strings.Format((object)num17, "0.0");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL5)[10, num16].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL5)[10, num16].Value = "";
					((DataGridView)dGV_DETL5)[9, num16].Value = "";
				}
				((DataGridView)dGV_DETL5)[13, num16].Value = "Cr Fine";
				((DataGridView)dGV_DETL5)[14, num16].Value = Strings.Format((object)num18, "0.000");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL5)[14, num16].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL5)[14, num16].Value = "";
					((DataGridView)dGV_DETL5)[13, num16].Value = "";
				}
				((DataGridView)dGV_DETL5)[17, num16].Value = "Cr Fine";
				((DataGridView)dGV_DETL5)[18, num16].Value = Strings.Format((object)num19, "0.00");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL5)[18, num16].Value)) == 0.0)
				{
					((DataGridView)dGV_DETL5)[18, num16].Value = "";
					((DataGridView)dGV_DETL5)[17, num16].Value = "";
				}
				dGV_DETL5 = null;
				((DataGridView)DGV_DETL).Rows[num16].DefaultCellStyle.ForeColor = Color.DarkGreen;
				((DataGridView)DGV_DETL).Rows[num16].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
			}
		}
	}

	private void DGV_ITM_FILL()
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
		//IL_0cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbd: Expected O, but got Unknown
		//IL_0d6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Invalid comparison between Unknown and I4
		//IL_1712: Unknown result type (might be due to invalid IL or missing references)
		//IL_1717: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Expected O, but got Unknown
		//IL_176a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1774: Expected O, but got Unknown
		//IL_2a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a21: Expected O, but got Unknown
		//IL_1d7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d84: Expected O, but got Unknown
		//IL_1dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de4: Expected O, but got Unknown
		//IL_1661: Unknown result type (might be due to invalid IL or missing references)
		//IL_1666: Unknown result type (might be due to invalid IL or missing references)
		//IL_1670: Expected O, but got Unknown
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
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Item Name (Cr)");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "cCrFine");
			((DataGridView)DGV_DETL).Columns.Add("", "cCrSilver");
			((DataGridView)DGV_DETL).Columns.Add("", "cCrAmt");
			if (cboValType.SelectedIndex == 2)
			{
				((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[8].Visible = false;
				((DataGridView)DGV_DETL).Columns[9].Visible = false;
			}
			else if (cboValType.SelectedIndex == 3)
			{
				((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[7].Visible = false;
				((DataGridView)DGV_DETL).Columns[9].Visible = false;
			}
			else if (cboValType.SelectedIndex == 1)
			{
				((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[7].Visible = false;
				((DataGridView)DGV_DETL).Columns[8].Visible = false;
			}
			else
			{
				((DataGridView)DGV_DETL).Columns[7].Visible = false;
				((DataGridView)DGV_DETL).Columns[8].Visible = false;
				((DataGridView)DGV_DETL).Columns[9].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Sr");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Item Name (Dr)");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "cDrFine");
			((DataGridView)DGV_DETL).Columns.Add("", "cDrSilver");
			((DataGridView)DGV_DETL).Columns.Add("", "cDrAmt");
			if (cboValType.SelectedIndex == 2)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "FinGlCr");
				((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[17].Visible = false;
				((DataGridView)DGV_DETL).Columns[18].Visible = false;
			}
			else if (cboValType.SelectedIndex == 3)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "FinSlCr");
				((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[16].Visible = false;
				((DataGridView)DGV_DETL).Columns[18].Visible = false;
			}
			else if (cboValType.SelectedIndex == 1)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "CrAmt");
				((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[16].Visible = false;
				((DataGridView)DGV_DETL).Columns[17].Visible = false;
			}
			else
			{
				((DataGridView)DGV_DETL).Columns[16].Visible = false;
				((DataGridView)DGV_DETL).Columns[17].Visible = false;
				((DataGridView)DGV_DETL).Columns[18].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "CoBookCr");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBookCr");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBookDr");
			((DataGridView)DGV_DETL).Columns[21].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBookDr");
			((DataGridView)DGV_DETL).Columns[22].Visible = false;
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
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			string text = "G";
			if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
			{
				if (chkProcuctWise.Checked)
				{
					text = ((unchecked((int)Interaction.MsgBox((object)"Item Type Select If Yes Then Gold or No Then Silver", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6) ? "S" : "G");
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.PR_CODE,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE - ITM_PCS END) as Pcs, Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE - ITM_NWT END) as NetWt,Sum(CASE WHEN B.IT_TYPE = 'G' THEN (CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) ELSE 0 END) As FineWt,Sum(CASE WHEN B.IT_TYPE = 'S' THEN (CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) ELSE 0 END) As SilverWt,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_AMT ELSE - ITM_AMT END) As ItmAmt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.IT_TYPE = '"), (object)text), (object)"' and B.PR_CODE = '"), (object)tAcCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tLdrCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tLdrCode.Text + "'"))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY B.PR_CODE"));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE - ITM_PCS END) as Pcs, Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE - ITM_NWT END) as NetWt,Sum(CASE WHEN B.IT_TYPE = 'G' THEN (CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) ELSE 0 END) As FineWt,Sum(CASE WHEN B.IT_TYPE = 'S' THEN (CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) ELSE 0 END) As SilverWt,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_AMT ELSE - ITM_AMT END) As ItmAmt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  and A.IT_CODE = '"), (object)tAcCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tLdrCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tLdrCode.Text + "'"))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.IT_CODE"));
				}
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE - ITM_PCS END) as Pcs, Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE - ITM_NWT END) as NetWt,Sum(CASE WHEN B.IT_TYPE = 'G' THEN (CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) ELSE 0 END) As FineWt,Sum(CASE WHEN B.IT_TYPE = 'S' THEN (CASE WHEN ITM_SIGN = '+' THEN ITM_FINE ELSE - ITM_FINE END) ELSE 0 END) As SilverWt,Sum(CASE WHEN ITM_SIGN = '+' THEN ITM_AMT ELSE - ITM_AMT END) As ItmAmt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  and A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.IT_CODE"));
			}
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			int num11 = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, num11].Value = num11 + 1;
				((DataGridView)dGV_DETL)[4, num11].Value = "Op Balance";
				((DataGridView)dGV_DETL)[13, num11].Value = "Op Balance";
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Pcs"])) > 0.0)
				{
					((DataGridView)dGV_DETL)[5, num11].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Pcs"]));
				}
				else
				{
					((DataGridView)dGV_DETL)[14, num11].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Pcs"])));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NetWt"])) > 0.0)
				{
					((DataGridView)dGV_DETL)[6, num11].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NetWt"]));
				}
				else
				{
					((DataGridView)dGV_DETL)[15, num11].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NetWt"])));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ItmAmt"])) > 0.0)
				{
					((DataGridView)dGV_DETL)[9, num11].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ItmAmt"]));
				}
				else
				{
					((DataGridView)dGV_DETL)[18, num11].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ItmAmt"])));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FineWt"])) > 0.0)
				{
					((DataGridView)dGV_DETL)[7, num11].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FineWt"]));
				}
				else
				{
					((DataGridView)dGV_DETL)[16, num11].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FineWt"])));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"])) > 0.0)
				{
					((DataGridView)dGV_DETL)[8, num11].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"]));
				}
				else
				{
					((DataGridView)dGV_DETL)[17, num11].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"])));
				}
				num2 = Conversions.ToDouble(((DataGridView)dGV_DETL)[5, num11].Value);
				num = Conversions.ToDouble(((DataGridView)dGV_DETL)[14, num11].Value);
				num4 = Conversions.ToDouble(((DataGridView)dGV_DETL)[6, num11].Value);
				num3 = Conversions.ToDouble(((DataGridView)dGV_DETL)[15, num11].Value);
				num6 = Conversions.ToDouble(((DataGridView)dGV_DETL)[9, num11].Value);
				num5 = Conversions.ToDouble(((DataGridView)dGV_DETL)[18, num11].Value);
				num8 = Conversions.ToDouble(((DataGridView)dGV_DETL)[7, num11].Value);
				num7 = Conversions.ToDouble(((DataGridView)dGV_DETL)[16, num11].Value);
				num10 = Conversions.ToDouble(((DataGridView)dGV_DETL)[8, num11].Value);
				num9 = Conversions.ToDouble(((DataGridView)dGV_DETL)[17, num11].Value);
				dGV_DETL = null;
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)DC_Main.HaderFont, ((DataGridView)DGV_DETL).Font.Style);
				}
			}
			else
			{
				((DataGridView)DGV_DETL).Rows.Add();
				((DataGridView)DGV_DETL)[0, num11].Value = num11 + 1;
				((DataGridView)DGV_DETL)[4, num11].Value = "Op Balance";
				((DataGridView)DGV_DETL)[13, num11].Value = "Op Balance";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)DC_Main.HaderFont, ((DataGridView)DGV_DETL).Font.Style);
				}
			}
			((DataGridView)DGV_DETL).Rows[num11].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[num11].DefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)DC_Main.HaderFont, (FontStyle)1);
			num11++;
			if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
			{
				DC_Main.RsQry = "SELECT AC_CODE,AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY AC_CODE";
			}
			else
			{
				DC_Main.RsQry = "SELECT IT_CODE,IT_NAME FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_CODE";
			}
			DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(table);
			bool flag = false;
			DC_Main.M = 0;
			if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
			{
				if (chkProcuctWise.Checked)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.PR_CODE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.IT_TYPE = '" + text + "' AND B.PR_CODE = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(tLdrCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tLdrCode.Text + "'"))), (object)" AND VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY VCH_DATE ,ITM_SIGN"));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(tLdrCode.Text, "", false) == 0, (object)"", (object)("AND AC_CODE = '" + tLdrCode.Text + "'"))), (object)" AND VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY VCH_DATE ,ITM_SIGN"));
				}
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '" + tAcCode.Text + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY VCH_DATE ,ITM_SIGN"));
			}
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (dataTable2.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL2 = DGV_DETL;
				DateTime t = default(DateTime);
				while (DC_Main.X < dataTable2.Rows.Count)
				{
					if (DateTime.Compare(t, Conversions.ToDate(Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy"))) != 0)
					{
						t = Conversions.ToDate(Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy"));
						((DataGridView)dGV_DETL2).Rows.Add();
						num11 = ((DataGridView)dGV_DETL2).Rows.Count - 1;
						((DataGridView)dGV_DETL2)[1, num11].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
						((DataGridView)dGV_DETL2)[0, num11].Value = num11 + 1;
						((DataGridView)dGV_DETL2)[10, num11].Value = "   + ";
						((DataGridView)dGV_DETL2).Rows[num11].Cells[1].Style.ForeColor = Color.Maroon;
						((DataGridView)dGV_DETL2).Rows[num11].Cells[1].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
						((DataGridView)dGV_DETL2).Rows[num11].Cells[10].Style.ForeColor = Color.Maroon;
						((DataGridView)dGV_DETL2).Rows[num11].Cells[10].Style.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
						DC_Main.M = num11;
						flag = true;
					}
					if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.X]["ITM_SIGN"], (object)"+", false))
					{
						((DataGridView)dGV_DETL2).Rows.Add();
						num11++;
						((DataGridView)dGV_DETL2)[0, num11].Value = num11 + 1;
						((DataGridView)dGV_DETL2)[2, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL2)[3, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_NO"], (object)"");
						if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
						{
							dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable2.Rows[DC_Main.X]["AC_CODE"]), (object)""), (object)"'"));
							if (dataView.Count > 0)
							{
								((DataGridView)dGV_DETL2)[4, num11].Value = Operators.ConcatenateObject(dataView[0]["AC_NAME"], (object)"");
							}
						}
						else
						{
							dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"IT_CODE = '", dataTable2.Rows[DC_Main.X]["IT_CODE"]), (object)""), (object)"'"));
							if (dataView.Count > 0)
							{
								((DataGridView)dGV_DETL2)[4, num11].Value = Operators.ConcatenateObject(dataView[0]["IT_NAME"], (object)"");
							}
						}
						((DataGridView)dGV_DETL2)[5, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_PCS"], (object)"");
						((DataGridView)dGV_DETL2)[6, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_NWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[7, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[8, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[9, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL2)[19, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CO_BOOK"], (object)"");
						((DataGridView)dGV_DETL2)[20, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL2)[5, num11].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL2)[6, num11].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL2)[9, num11].Value));
						num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV_DETL2)[7, num11].Value));
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL2)[8, num11].Value));
					}
					if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.X]["ITM_SIGN"], (object)"-", false))
					{
						if (DateTime.Compare(t, Conversions.ToDate(Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy"))) == 0)
						{
							if (flag)
							{
								flag = false;
								num11 = DC_Main.M;
								if (num11 == ((DataGridView)dGV_DETL2).Rows.Count - 1)
								{
									((DataGridView)dGV_DETL2).Rows.Add();
									num11++;
									if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[0, num11].Value)) == 0.0)
									{
										((DataGridView)dGV_DETL2)[0, num11].Value = ((DataGridView)dGV_DETL2).Rows.Count;
									}
								}
								else
								{
									num11++;
								}
							}
							else if (num11 == ((DataGridView)dGV_DETL2).Rows.Count - 1)
							{
								((DataGridView)dGV_DETL2).Rows.Add();
								num11++;
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[0, num11].Value)) == 0.0)
								{
									((DataGridView)dGV_DETL2)[0, num11].Value = ((DataGridView)dGV_DETL2).Rows.Count;
								}
							}
							else
							{
								num11++;
							}
						}
						((DataGridView)dGV_DETL2)[11, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL2)[12, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["VCH_NO"], (object)"");
						if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
						{
							dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable2.Rows[DC_Main.X]["AC_CODE"]), (object)""), (object)"'"));
							if (dataView.Count > 0)
							{
								((DataGridView)dGV_DETL2)[13, num11].Value = Operators.ConcatenateObject(dataView[0]["AC_NAME"], (object)"");
							}
						}
						else
						{
							dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"IT_CODE = '", dataTable2.Rows[DC_Main.X]["IT_CODE"]), (object)""), (object)"'"));
							if (dataView.Count > 0)
							{
								((DataGridView)dGV_DETL2)[13, num11].Value = Operators.ConcatenateObject(dataView[0]["IT_NAME"], (object)"");
							}
						}
						((DataGridView)dGV_DETL2)[14, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_PCS"], (object)"");
						((DataGridView)dGV_DETL2)[15, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_NWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[16, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[17, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL2)[18, num11].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["ITM_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL2)[21, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["CO_BOOK"], (object)"");
						((DataGridView)dGV_DETL2)[22, num11].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
						num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL2)[14, num11].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL2)[15, num11].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL2)[18, num11].Value));
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL2)[16, num11].Value));
						num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV_DETL2)[17, num11].Value));
					}
					DC_Main.X++;
				}
				dGV_DETL2 = null;
			}
			DataGridViewX dGV_DETL3 = DGV_DETL;
			((DataGridView)dGV_DETL3).Rows.Add();
			((DataGridView)dGV_DETL3).Rows.Add();
			num11 = ((DataGridView)dGV_DETL3).Rows.Count - 1;
			((DataGridView)dGV_DETL3)[4, num11].Value = "Cr Total :";
			((DataGridView)dGV_DETL3)[5, num11].Value = Strings.Format((object)num2, "0");
			((DataGridView)dGV_DETL3)[6, num11].Value = Strings.Format((object)num4, "0.000");
			((DataGridView)dGV_DETL3)[7, num11].Value = Strings.Format((object)num8, "0.000");
			((DataGridView)dGV_DETL3)[8, num11].Value = Strings.Format((object)num10, "0.000");
			((DataGridView)dGV_DETL3)[9, num11].Value = Strings.Format((object)num6, "0.00");
			((DataGridView)dGV_DETL3)[13, num11].Value = "Dr Total :";
			((DataGridView)dGV_DETL3)[14, num11].Value = Strings.Format((object)num, "0");
			((DataGridView)dGV_DETL3)[15, num11].Value = Strings.Format((object)num3, "0.000");
			((DataGridView)dGV_DETL3)[16, num11].Value = Strings.Format((object)num7, "0.000");
			((DataGridView)dGV_DETL3)[17, num11].Value = Strings.Format((object)num9, "0.000");
			((DataGridView)dGV_DETL3)[18, num11].Value = Strings.Format((object)num5, "0.00");
			dGV_DETL3 = null;
			((DataGridView)DGV_DETL).Rows[num11].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[num11].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
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
					if (Operators.CompareString(CurRpt, "Bill Os Day", false) != 0)
					{
						int columnIndex = e.ColumnIndex;
						if (((uint)(columnIndex - 5) <= 4u || (uint)(columnIndex - 14) <= 4u) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					break;
				case 143:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00c5;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 143;
				continue;
			}
			break;
			IL_00c5:
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
							((DataGridView)DGV_DETL).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_01d1:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_DETL)[num5, DC_Main.i].Value.ToString()
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
						num7 = ((DataGridView)DGV_DETL).ColumnCount - 1;
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
						num8 = ((DataGridView)DGV_DETL).RowCount - 1;
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
						num9 = ((DataGridView)DGV_DETL).ColumnCount - 1;
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
						if (((DataGridView)DGV_DETL)[num5, DC_Main.i].Value != null)
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

	private void RP_INOUT_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Expected O, but got Unknown
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Expected O, but got Unknown
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Expected O, but got Unknown
		//IL_093d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Expected O, but got Unknown
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a09: Expected O, but got Unknown
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a37: Expected O, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a65: Expected O, but got Unknown
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
			if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
			{
				cboValType.Items.Add((object)"Gold");
				cboValType.Items.Add((object)"Silver");
				if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
				{
					cboValType.SelectedIndex = 0;
				}
				else
				{
					cboValType.SelectedIndex = 1;
				}
			}
			else if (Operators.CompareString(CurRpt, "Bill Interest", false) == 0)
			{
				((Control)cboValType).Visible = false;
				cboValType.Items.Add((object)"");
				cboValType.SelectedIndex = 0;
				((Control)Label3).Visible = false;
				((Control)chkProcuctWise).Visible = false;
			}
			else if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
			{
				((Control)cboValType).Visible = false;
				((Control)Label3).Visible = false;
				((Control)chkProcuctWise).Visible = false;
				Label2.Text = "It Code";
				((Control)lblLdrCode).Visible = true;
				((Control)tLdrCode).Visible = true;
				((Control)tLdrName).Visible = true;
			}
			else
			{
				cboValType.Items.Add((object)"");
				cboValType.Items.Add((object)"Amount");
				cboValType.Items.Add((object)"Fine");
				cboValType.Items.Add((object)"Silver");
				cboValType.SelectedIndex = 0;
			}
			if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
			{
				Label2.Text = "It Code";
				((Control)lblLdrCode).Visible = true;
				((Control)tLdrCode).Visible = true;
				((Control)tLdrName).Visible = true;
			}
			else if (Operators.CompareString(CurRpt, "Party InOut", false) == 0)
			{
				((Control)chkProcuctWise).Visible = false;
			}
			else if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
			{
				Label3.Text = "It Type";
				((Control)chkProcuctWise).Visible = false;
			}
			CLEAR_DATA();
			if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
			{
				if (Operators.CompareString(DC_Main.LdrAcMastCode, "", false) != 0)
				{
					tAcCode.Text = DC_Main.LdrAcMastCode;
					DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
						Bill_Os_Day();
					}
				}
				CurActCtrl = (Control)(object)tAcCode;
			}
			else if (Operators.CompareString(CurRpt, "Bill Interest", false) == 0)
			{
				Bill_Interest_Rpt();
				CurActCtrl = (Control)(object)tAcCode;
			}
			else
			{
				CurActCtrl = (Control)(object)mFromDt;
			}
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
		chkProcuctWise.Checked = false;
		if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
		{
			Label2.Text = "Itm Code";
		}
		lblMobile.Text = "";
		if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
		{
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			((Control)tAcCode).Focus();
		}
		else
		{
			mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			((Control)mFromDt).Focus();
		}
	}

	private void RP_INOUT_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_INOUT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_INOUT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_INOUT_KeyDown(object sender, KeyEventArgs e)
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
		checked
		{
			if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
			{
				string text = ((Operators.CompareString(tLdrCode.Text, "", false) == 0) ? ("Item = " + tAcName.Text + " Stock Balance From Date  ") : (" " + tLdrName.Text + " / Item = " + tAcName.Text + " Stock Balance From Date  "));
				DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DataGridViewX dGV_DETL = DGV_DETL;
				int num = ((DataGridView)dGV_DETL).RowCount - 3;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,  COL_1,COL_2,COL_3,  COL_4,COL_5,COL_6,  COL_7,COL_8,COL_9,  COL_10,COL_11,COL_12)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[0, DC_Main.X].Value), "0000") + "', '"), ((DataGridView)dGV_DETL)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[3, DC_Main.X].Value), (object)"', "), (object)"'"), ((DataGridView)dGV_DETL)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[7, DC_Main.X].Value), (object)"', "), (object)"'"), ((DataGridView)dGV_DETL)[8, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[10, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[11, DC_Main.X].Value), (object)"', "), (object)"'"), ((DataGridView)dGV_DETL)[12, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[14, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[15, DC_Main.X].Value), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				dGV_DETL = null;
				DC_Main.RsQry = "SELECT * FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY SR_NO";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if (DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + DC_Main.MLc_code + "  " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "ItmStkWithGrid";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					UT_REPORT uT_REPORT = new UT_REPORT();
					((Control)uT_REPORT).Show();
					((Control)uT_REPORT).Focus();
					CurFormula = "";
					return;
				}
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItmStkBalance.RPT";
				CurFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
				if (DC_Main.MsLcBoxShow)
				{
					Cr[(short)0] = "RptTitel = 'Branch - " + DC_Main.MLc_code + " " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
			else if (Operators.CompareString(CurRpt, "Party InOut", false) == 0)
			{
				double num2 = 0.0;
				DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				}
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedger.RPT";
				Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				Cr[(short)0] = "RptTitel = 'Ledr Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
				Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
				Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num2, "0.00")) ?? "";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_INOUT_Closed(object sender, EventArgs e)
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
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LC_CODE,AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
				}
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
						Bill_Os_Day();
					}
					((Control)tAcCode).Focus();
					((TextBoxBase)tAcCode).SelectAll();
				}
				return;
			}
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
			Bill_Os_Day();
			((Control)tAcCode).Focus();
		}
		else if (Operators.CompareString(CurRpt, "Bill Interest", false) == 0)
		{
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
					{
						DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LC_CODE,AC_NAME";
					}
					else
					{
						DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
					}
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
							Bill_Interest_Rpt();
						}
						((Control)tAcCode).Focus();
						((TextBoxBase)tAcCode).SelectAll();
					}
					return;
				}
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
				Bill_Interest_Rpt();
				((Control)tAcCode).Focus();
			}
			else
			{
				Bill_Interest_Rpt();
				((Control)tAcCode).Focus();
			}
		}
		else if ((Operators.CompareString(CurRpt, "Stock Ledger", false) == 0) | (Operators.CompareString(CurRpt, "Item Balance", false) == 0))
		{
			if (chkProcuctWise.Checked)
			{
				DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tAcCode.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT A.PR_NAME As ProductL,A.PR_CODE As PrCodeL FROM PRODUCT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.PR_NAME";
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
						((TextBoxBase)tAcCode).SelectAll();
					}
					return;
				}
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_NAME"], (object)""));
				DGV_ITM_FILL();
			}
			else
			{
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
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
						if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
						{
							Stock_Balance();
						}
						else
						{
							DGV_ITM_FILL();
						}
					}
					((Control)tAcCode).Focus();
					((TextBoxBase)tAcCode).SelectAll();
					return;
				}
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
				if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
				{
					Stock_Balance();
				}
				else
				{
					DGV_ITM_FILL();
				}
			}
		}
		else if (Operators.CompareString(CurRpt, "Party InOut", false) == 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LC_CODE,AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
				}
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
						DGV_ITM_FILL();
					}
					((Control)tAcCode).Focus();
					((TextBoxBase)tAcCode).SelectAll();
				}
				return;
			}
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
			DGV_ITM_FILL();
			((Control)tAcCode).Focus();
		}
		((TextBoxBase)tAcCode).SelectAll();
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[20].Value), (object)""), (object)"' "));
		}
		else if (Operators.CompareString(CurRpt, "Bill Interest", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[14].Value), (object)""), (object)"' "));
		}
		else if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[16].Value), (object)""), (object)"' "));
		}
		else if (((DataGridView)DGV_DETL).CurrentCell.ColumnIndex < 9)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[19].Value), (object)""), (object)"' "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[21].Value), (object)""), (object)"' "));
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
		if (Operators.CompareString(CurRpt, "Bill Os Day", false) == 0)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
		}
		else if (Operators.CompareString(CurRpt, "Bill Interest", false) == 0)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
		}
		else if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
		}
		else if (((DataGridView)DGV_DETL).CurrentCell.ColumnIndex < 9)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[3].Value, (object)""));
		}
		else
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[12].Value, (object)""));
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

	private void BtnJmaUdhar_Click(object sender, EventArgs e)
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
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# ";
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

	private void ChkProcuctWise_CheckedChanged(object sender, EventArgs e)
	{
		if (chkProcuctWise.Checked)
		{
			Label2.Text = "Prod Code";
			tAcCode.Text = "";
			tAcName.Text = "";
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((DataGridView)DGV_DETL).Columns.Clear();
			((Control)DGV_DETL).Refresh();
		}
		else
		{
			Label2.Text = "Itm Code";
			tAcCode.Text = "";
			tAcName.Text = "";
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((DataGridView)DGV_DETL).Columns.Clear();
			((Control)DGV_DETL).Refresh();
			DGV_ITM_FILL();
		}
	}

	private void DGV_DETL_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void tLdrCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tLdrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || !((Operators.CompareString(CurRpt, "Item Balance", false) == 0) | (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)))
		{
			return;
		}
		if (Operators.CompareString(tLdrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tLdrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LC_CODE,AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
				}
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
						tLdrCode.Text = DC_Main.ColValue[1];
						tLdrName.Text = DC_Main.ColValue[0];
					}
					((Control)tLdrCode).Focus();
				}
				return;
			}
			tLdrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
			{
				Stock_Balance();
			}
			else
			{
				DGV_ITM_FILL();
			}
			((Control)tLdrCode).Focus();
		}
		else
		{
			if (Operators.CompareString(CurRpt, "Item Balance", false) == 0)
			{
				Stock_Balance();
			}
			else
			{
				DGV_ITM_FILL();
			}
			((Control)tLdrCode).Focus();
		}
		((TextBoxBase)tLdrCode).SelectAll();
	}
}
