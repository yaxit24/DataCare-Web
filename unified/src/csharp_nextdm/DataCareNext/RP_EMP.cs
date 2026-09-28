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
public class RP_EMP : Form
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
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAll")]
	private QButton _btnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItCancel")]
	private QButton _btnItCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItSelect")]
	private CheckBox _chkItSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nComVal")]
	private TextBox _nComVal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string SelectIt;

	private string CommType;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cEmpName = 1;

	private const int cVchType = 2;

	private const int cVchNo = 3;

	private const int cVchDate = 4;

	private const int cItCode = 5;

	private const int cItName = 6;

	private const int cComPrc = 7;

	private const int cPcs = 8;

	private const int cGrWt = 9;

	private const int cNetWt = 10;

	private const int cFine = 11;

	private const int cLbrAmt = 12;

	private const int cOthAmt = 13;

	private const int cMrp = 14;

	private const int cNetAmt = 15;

	private const int cEmpComm = 16;

	private const int cComType = 17;

	private const int cComVal = 18;

	private const int cSign = 19;

	private const int cEmpCode = 20;

	private const int cMainBook = 21;

	private const int cCoBook = 22;

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
	[AccessedThroughProperty("chkVchSum")]
	private virtual CheckBox _chkVchSum;

	internal virtual CheckBox chkVchSum
	{
		get
		{
			return _chkVchSum;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkVchSum = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlIt")]
	private virtual Panel _PnlIt;

	internal virtual Panel PnlIt
	{
		get
		{
			return _PnlIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlIt = value;
		}
	}

	internal virtual QButton btnAll
	{
		[CompilerGenerated]
		get
		{
			return _btnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAll_Click;
			QButton val = _btnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAll = value;
			val = _btnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnItCancel
	{
		[CompilerGenerated]
		get
		{
			return _btnItCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItCancel_Click;
			QButton val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItCancel = value;
			val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOk_Click;
			QButton val = _btnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOk = value;
			val = _btnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ITM")]
	private virtual DataGridViewX _DGV_ITM;

	internal virtual DataGridViewX DGV_ITM
	{
		get
		{
			return _DGV_ITM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_ITM = value;
		}
	}

	internal virtual CheckBox chkItSelect
	{
		[CompilerGenerated]
		get
		{
			return _chkItSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkItSelect_Click;
			EventHandler eventHandler2 = chkItSelect_CheckedChanged;
			CheckBox val = _chkItSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				val.CheckedChanged -= eventHandler2;
			}
			_chkItSelect = value;
			val = _chkItSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				val.CheckedChanged += eventHandler2;
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
	[AccessedThroughProperty("cboCommType")]
	private virtual ComboBox _cboCommType;

	internal virtual ComboBox cboCommType
	{
		get
		{
			return _cboCommType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCommType = value;
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

	internal virtual TextBox nComVal
	{
		[CompilerGenerated]
		get
		{
			return _nComVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nComVal_KeyDown);
			TextBox val2 = _nComVal;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nComVal = value;
			val2 = _nComVal;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItemComm")]
	private virtual CheckBox _chkItemComm;

	internal virtual CheckBox chkItemComm
	{
		get
		{
			return _chkItemComm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkItemComm = value;
		}
	}

	public int newindex { get; set; }

	public RP_EMP()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += RP_EMP_Load;
		((Form)this).Activated += RP_EMP_Activated;
		((Form)this).Deactivate += RP_EMP_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_EMP_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_EMP_KeyDown);
		((Form)this).Closed += RP_EMP_Closed;
		CommType = "";
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
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Expected O, but got Unknown
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Expected O, but got Unknown
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected O, but got Unknown
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Expected O, but got Unknown
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Expected O, but got Unknown
		//IL_097c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0986: Expected O, but got Unknown
		//IL_0a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a79: Expected O, but got Unknown
		//IL_0ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af1: Expected O, but got Unknown
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Expected O, but got Unknown
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Expected O, but got Unknown
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Expected O, but got Unknown
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d94: Expected O, but got Unknown
		//IL_0e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e33: Expected O, but got Unknown
		//IL_0eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebb: Expected O, but got Unknown
		//IL_0f9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa7: Expected O, but got Unknown
		//IL_1010: Unknown result type (might be due to invalid IL or missing references)
		//IL_101a: Expected O, but got Unknown
		//IL_10ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b6: Expected O, but got Unknown
		//IL_1164: Unknown result type (might be due to invalid IL or missing references)
		//IL_116e: Expected O, but got Unknown
		//IL_1220: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Expected O, but got Unknown
		//IL_12a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b2: Expected O, but got Unknown
		//IL_1550: Unknown result type (might be due to invalid IL or missing references)
		//IL_1574: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ef: Expected O, but got Unknown
		//IL_1612: Unknown result type (might be due to invalid IL or missing references)
		//IL_1689: Unknown result type (might be due to invalid IL or missing references)
		//IL_1693: Expected O, but got Unknown
		//IL_1745: Unknown result type (might be due to invalid IL or missing references)
		//IL_174f: Expected O, but got Unknown
		//IL_1acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6a: Expected O, but got Unknown
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e90: Expected O, but got Unknown
		//IL_1eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_211a: Unknown result type (might be due to invalid IL or missing references)
		//IL_213e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2162: Unknown result type (might be due to invalid IL or missing references)
		//IL_2186: Unknown result type (might be due to invalid IL or missing references)
		//IL_21af: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b9: Expected O, but got Unknown
		//IL_21df: Unknown result type (might be due to invalid IL or missing references)
		//IL_2275: Unknown result type (might be due to invalid IL or missing references)
		//IL_227f: Expected O, but got Unknown
		//IL_231b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2325: Expected O, but got Unknown
		//IL_23ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b5: Expected O, but got Unknown
		//IL_248f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2499: Expected O, but got Unknown
		//IL_2502: Unknown result type (might be due to invalid IL or missing references)
		//IL_250c: Expected O, but got Unknown
		//IL_25bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_25c9: Expected O, but got Unknown
		//IL_2679: Unknown result type (might be due to invalid IL or missing references)
		//IL_2683: Expected O, but got Unknown
		//IL_2731: Unknown result type (might be due to invalid IL or missing references)
		//IL_273b: Expected O, but got Unknown
		//IL_27b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c3: Expected O, but got Unknown
		//IL_2862: Unknown result type (might be due to invalid IL or missing references)
		//IL_286c: Expected O, but got Unknown
		//IL_28ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f4: Expected O, but got Unknown
		//IL_29a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_29af: Expected O, but got Unknown
		//IL_2a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a67: Expected O, but got Unknown
		//IL_2ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aeb: Expected O, but got Unknown
		//IL_2b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba3: Expected O, but got Unknown
		//IL_2c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c2e: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_EMP));
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
		mFromDt = new MaskedTextBox();
		chkVchSum = new CheckBox();
		PnlIt = new Panel();
		btnAll = new QButton();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DataGridViewX();
		chkItSelect = new CheckBox();
		Label1 = new Label();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		cboCommType = new ComboBox();
		Label5 = new Label();
		Label6 = new Label();
		nComVal = new TextBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		chkItemComm = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
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
		lblBook.Text = "Employee Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(665, 44);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(59, 22);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(730, 43);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(176, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(578, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(81, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Emp Code";
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
		((Control)DGV_DETL).Location = new Point(13, 111);
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
		((Control)DGV_DETL).Size = new Size(1159, 442);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(12, 44);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(56, 20);
		((Control)Label4).TabIndex = 1159;
		Label4.Text = "Date";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(161, 41);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		cboItmType.AutoCompleteMode = (AutoCompleteMode)3;
		cboItmType.AutoCompleteSource = (AutoCompleteSource)256;
		cboItmType.BackColor = Color.White;
		((Control)cboItmType).Font = new Font("Tahoma", 9f);
		((ListControl)cboItmType).FormattingEnabled = true;
		((Control)cboItmType).Location = new Point(331, 44);
		((Control)cboItmType).Name = "cboItmType";
		((Control)cboItmType).Size = new Size(98, 22);
		((Control)cboItmType).TabIndex = 1160;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(244, 44);
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
		((Control)BtnList).Location = new Point(1051, 56);
		((Control)BtnList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnList).Name = "BtnList";
		((Control)BtnList).Size = new Size(91, 33);
		((Control)BtnList).TabIndex = 1165;
		BtnList.Text = "Ok";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(75, 41);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 1166;
		mFromDt.ValidatingType = typeof(DateTime);
		((ButtonBase)chkVchSum).BackColor = Color.Transparent;
		chkVchSum.Checked = true;
		chkVchSum.CheckState = (CheckState)1;
		((Control)chkVchSum).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkVchSum).ForeColor = Color.Black;
		((Control)chkVchSum).Location = new Point(924, 47);
		((Control)chkVchSum).Name = "chkVchSum";
		((Control)chkVchSum).RightToLeft = (RightToLeft)0;
		((Control)chkVchSum).Size = new Size(94, 19);
		((Control)chkVchSum).TabIndex = 1167;
		((ButtonBase)chkVchSum).Text = "Vch Summ";
		((ButtonBase)chkVchSum).UseVisualStyleBackColor = false;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnAll);
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(716, 254);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1207;
		((Control)PnlIt).Visible = false;
		((QControl)btnAll).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAll).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAll).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAll.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Image = null;
		((QControl)btnAll).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAll).Location = new Point(53, 249);
		((Control)btnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAll).Name = "btnAll";
		((Control)btnAll).Size = new Size(100, 38);
		((Control)btnAll).TabIndex = 1159;
		btnAll.Text = "All";
		((QControl)btnItCancel).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItCancel).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItCancel.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Image = null;
		((QControl)btnItCancel).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItCancel).Location = new Point(317, 249);
		((Control)btnItCancel).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItCancel).Name = "btnItCancel";
		((Control)btnItCancel).Size = new Size(100, 38);
		((Control)btnItCancel).TabIndex = 1158;
		btnItCancel.Text = "Cancel";
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(184, 249);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(100, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV_ITM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITM).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val8;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val10;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((ButtonBase)chkItSelect).BackColor = Color.Transparent;
		((Control)chkItSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItSelect).ForeColor = Color.Black;
		((Control)chkItSelect).Location = new Point(924, 79);
		((Control)chkItSelect).Name = "chkItSelect";
		((Control)chkItSelect).RightToLeft = (RightToLeft)0;
		((Control)chkItSelect).Size = new Size(108, 19);
		((Control)chkItSelect).TabIndex = 1208;
		((ButtonBase)chkItSelect).Text = "Item Select";
		((ButtonBase)chkItSelect).UseVisualStyleBackColor = false;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(578, 77);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(81, 20);
		((Control)Label1).TabIndex = 1211;
		Label1.Text = "Book Code";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9f);
		((Control)tBookCode).Location = new Point(665, 77);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(59, 22);
		((Control)tBookCode).TabIndex = 1209;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f);
		((Control)tBookName).Location = new Point(730, 77);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(176, 23);
		((Control)tBookName).TabIndex = 1210;
		cboCommType.AutoCompleteMode = (AutoCompleteMode)3;
		cboCommType.AutoCompleteSource = (AutoCompleteSource)256;
		cboCommType.BackColor = Color.White;
		((Control)cboCommType).Font = new Font("Tahoma", 9f);
		((ListControl)cboCommType).FormattingEnabled = true;
		((Control)cboCommType).Location = new Point(331, 77);
		((Control)cboCommType).Name = "cboCommType";
		((Control)cboCommType).Size = new Size(98, 22);
		((Control)cboCommType).TabIndex = 1212;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(235, 77);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(90, 19);
		((Control)Label5).TabIndex = 1213;
		Label5.Text = "Comm Type";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(441, 79);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(48, 20);
		((Control)Label6).TabIndex = 1215;
		Label6.Text = "Val";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nComVal).BackColor = Color.White;
		((Control)nComVal).Font = new Font("Tahoma", 9f);
		((Control)nComVal).Location = new Point(504, 77);
		((TextBoxBase)nComVal).MaxLength = 6;
		((Control)nComVal).Name = "nComVal";
		((Control)nComVal).Size = new Size(62, 22);
		((Control)nComVal).TabIndex = 1214;
		nComVal.TextAlign = (HorizontalAlignment)2;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(425, 45);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(67, 20);
		((Control)Label10).TabIndex = 1217;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(504, 45);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(62, 22);
		((Control)tGrCode).TabIndex = 1216;
		((ButtonBase)chkItemComm).BackColor = Color.Transparent;
		((Control)chkItemComm).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItemComm).ForeColor = Color.Black;
		((Control)chkItemComm).Location = new Point(75, 78);
		((Control)chkItemComm).Name = "chkItemComm";
		((Control)chkItemComm).RightToLeft = (RightToLeft)0;
		((Control)chkItemComm).Size = new Size(162, 19);
		((Control)chkItemComm).TabIndex = 1218;
		((ButtonBase)chkItemComm).Text = "Item Comm% Wise";
		((ButtonBase)chkItemComm).UseVisualStyleBackColor = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkItemComm);
		((Control)this).Controls.Add((Control)(object)cboItmType);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nComVal);
		((Control)this).Controls.Add((Control)(object)cboCommType);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)chkItSelect);
		((Control)this).Controls.Add((Control)(object)PnlIt);
		((Control)this).Controls.Add((Control)(object)chkVchSum);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)BtnList);
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
		((Control)this).Name = "RP_EMP";
		((Form)this).Text = "Employee Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
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
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Expected O, but got Unknown
		//IL_2bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bde: Expected O, but got Unknown
		//IL_13c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cb: Expected O, but got Unknown
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
			((DataGridView)DGV_DETL).Columns.Add("", "Emp Name");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchDate");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			if (chkItemComm.Checked)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
				((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_DETL).Columns.Add("", "It Name");
				((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)DGV_DETL).Columns.Add("", "Com%");
				((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
				((DataGridView)DGV_DETL).Columns[5].Visible = false;
				((DataGridView)DGV_DETL).Columns.Add("", "ItName");
				((DataGridView)DGV_DETL).Columns[6].Visible = false;
				((DataGridView)DGV_DETL).Columns.Add("", "ComPrc");
				((DataGridView)DGV_DETL).Columns[7].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV_DETL).Columns.Add("", "GrWt");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Fine");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "LbrAmt");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OthAmt");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Mrp");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "NetAmt");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "EmpComm");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CmType");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			if (chkItemComm.Checked)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "CmVal");
				((DataGridView)DGV_DETL).Columns[18].Visible = false;
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "CmVal");
				((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N2";
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Sign");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "EmpCode");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[21].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
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
			double num11 = 0.0;
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			string text = "";
			int num19 = 0;
			if (cboCommType.SelectedIndex == 1)
			{
				CommType = "L";
			}
			else if (cboCommType.SelectedIndex == 2)
			{
				CommType = "T";
			}
			else if (cboCommType.SelectedIndex == 3)
			{
				CommType = "G";
			}
			else if (cboCommType.SelectedIndex == 4)
			{
				CommType = "N";
			}
			else if (cboCommType.SelectedIndex == 5)
			{
				CommType = "M";
			}
			else
			{
				CommType = "";
			}
			if (chkItemComm.Checked)
			{
				ItemWiseComm();
				return;
			}
			if (chkVchSum.Checked)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_PCS ELSE - A.ITM_PCS END) AS ITM_PCS,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_GWT ELSE -A.ITM_GWT END) AS ITM_GWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_NWT ELSE -A.ITM_NWT END) AS ITM_NWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_FINE ELSE -A.ITM_FINE END) AS ITM_FINE,SUM(CASE WHEN ITM_SIGN = '-' THEN A.LBR_AMT ELSE -A.LBR_AMT END) AS LBR_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.OTH_AMT ELSE -A.OTH_AMT END) AS OTH_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_MRP ELSE -A.ITM_MRP END) AS ITM_MRP,SUM(CASE WHEN ITM_SIGN = '-' THEN A.NET_AMT ELSE -A.NET_AMT END) AS NET_AMT,B.EMP_NAME FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN EMP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.EMP_CODE = B.EMP_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(cboItmType.SelectedIndex == 0, (object)"", (object)("AND C.IT_TYPE = '" + Strings.Mid(cboItmType.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.EMP_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" And A.EMP_CODE <> '' GROUP BY A.EMP_CODE,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,B.EMP_NAME ORDER BY A.EMP_CODE,A.CO_BOOK,A.VCH_NO "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.SR_NO,A.ISR_NO,A.VCH_DATE,A.BOOK_NAME,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_PCS ELSE - A.ITM_PCS END) AS ITM_PCS,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_GWT ELSE -A.ITM_GWT END) AS ITM_GWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_NWT ELSE -A.ITM_NWT END) AS ITM_NWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_FINE ELSE -A.ITM_FINE END) AS ITM_FINE,SUM(CASE WHEN ITM_SIGN = '-' THEN A.LBR_AMT ELSE -A.LBR_AMT END) AS LBR_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.OTH_AMT ELSE -A.OTH_AMT END) AS OTH_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_MRP ELSE -A.ITM_MRP END) AS ITM_MRP,SUM(CASE WHEN ITM_SIGN = '-' THEN A.NET_AMT ELSE -A.NET_AMT END) AS NET_AMT,B.EMP_NAME FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN EMP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.EMP_CODE = B.EMP_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(cboItmType.SelectedIndex == 0, (object)"", (object)("AND C.IT_TYPE = '" + Strings.Mid(cboItmType.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.EMP_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" And A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" And A.EMP_CODE <> '' GROUP BY A.EMP_CODE,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.SR_NO,A.ISR_NO,A.VCH_DATE,A.BOOK_NAME,B.EMP_NAME ORDER BY A.VCH_DATE,A.EMP_CODE,A.CO_BOOK,A.VCH_NO "));
			}
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
					if (Operators.ConditionalCompareObjectNotEqual((object)text, Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)""), false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)""));
						if (DC_Main.X != 0)
						{
							((DataGridView)dGV_DETL)[8, num19].Value = Strings.Format((object)num, "0");
							((DataGridView)dGV_DETL)[9, num19].Value = Strings.Format((object)num2, "0.00");
							((DataGridView)dGV_DETL)[10, num19].Value = Strings.Format((object)num3, "0.00");
							((DataGridView)dGV_DETL)[11, num19].Value = Strings.Format((object)num4, "0.00");
							((DataGridView)dGV_DETL)[12, num19].Value = Strings.Format((object)num5, "0");
							((DataGridView)dGV_DETL)[13, num19].Value = Strings.Format((object)num6, "0");
							((DataGridView)dGV_DETL)[14, num19].Value = Strings.Format((object)num7, "0");
							((DataGridView)dGV_DETL)[15, num19].Value = Strings.Format((object)num8, "0");
							((DataGridView)dGV_DETL)[16, num19].Value = Strings.Format((object)num9, "0");
							num = 0.0;
							num2 = 0.0;
							num3 = 0.0;
							num4 = 0.0;
							num5 = 0.0;
							num6 = 0.0;
							num7 = 0.0;
							num8 = 0.0;
							num9 = 0.0;
							num19 = DC_Main.R;
						}
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)"");
						((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Maroon;
						((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
						((DataGridView)dGV_DETL).Rows.Add();
						DC_Main.R = ((DataGridView)dGV_DETL).Rows.Count - 1;
						((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)"");
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_NO"], (object)"");
						((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_PCS"], (object)"")), "0");
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_GWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_NWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["LBR_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["OTH_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[14, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_MRP"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[15, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["NET_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = CommType;
						((DataGridView)dGV_DETL)[18, DC_Main.R].Value = Conversion.Val(nComVal.Text);
						if ((Operators.CompareString(CommType, "", false) != 0) & (Conversion.Val(nComVal.Text) != 0.0))
						{
							switch (CommType)
							{
							case "L":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) * Conversion.Val(nComVal.Text) / 100.0, 0), "0.00");
								}
								break;
							case "T":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) * Conversion.Val(nComVal.Text) / 100.0, 0), "0.00");
								}
								break;
							case "G":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) * Conversion.Val(nComVal.Text), 0), "0.00");
								break;
							case "N":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) * Conversion.Val(nComVal.Text), 0), "0.00");
								break;
							case "M":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) * Conversion.Val(nComVal.Text) / 100.0, 0), "0.00");
								}
								break;
							}
						}
						((DataGridView)dGV_DETL)[20, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_CODE"], (object)"");
						((DataGridView)dGV_DETL)[21, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
						((DataGridView)dGV_DETL)[22, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CO_BOOK"], (object)"");
						num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
					}
					else
					{
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)"");
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_NO"], (object)"");
						((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_PCS"], (object)"")), "0");
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_GWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_NWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["LBR_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["OTH_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[14, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_MRP"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[15, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["NET_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = CommType;
						((DataGridView)dGV_DETL)[18, DC_Main.R].Value = Conversion.Val(nComVal.Text);
						if ((Operators.CompareString(CommType, "", false) != 0) & (Conversion.Val(nComVal.Text) != 0.0))
						{
							switch (CommType)
							{
							case "L":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) * Conversion.Val(nComVal.Text) / 100.0, 0), "0.00");
								}
								break;
							case "T":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) * Conversion.Val(nComVal.Text) / 100.0, 0), "0.00");
								}
								break;
							case "G":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) * Conversion.Val(nComVal.Text), 0), "0.00");
								break;
							case "N":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) * Conversion.Val(nComVal.Text), 0), "0.00");
								break;
							case "M":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) * Conversion.Val(nComVal.Text) / 100.0, 0), "0.00");
								}
								break;
							}
						}
						((DataGridView)dGV_DETL)[20, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_CODE"], (object)"");
						((DataGridView)dGV_DETL)[21, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
						((DataGridView)dGV_DETL)[22, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CO_BOOK"], (object)"");
						num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
					}
					DC_Main.X++;
				}
				if (DC_Main.X != 0)
				{
					((DataGridView)dGV_DETL)[8, num19].Value = Strings.Format((object)num, "0");
					((DataGridView)dGV_DETL)[9, num19].Value = Strings.Format((object)num2, "0.00");
					((DataGridView)dGV_DETL)[10, num19].Value = Strings.Format((object)num3, "0.00");
					((DataGridView)dGV_DETL)[11, num19].Value = Strings.Format((object)num4, "0.00");
					((DataGridView)dGV_DETL)[12, num19].Value = Strings.Format((object)num5, "0");
					((DataGridView)dGV_DETL)[13, num19].Value = Strings.Format((object)num6, "0");
					((DataGridView)dGV_DETL)[14, num19].Value = Strings.Format((object)num7, "0");
					((DataGridView)dGV_DETL)[15, num19].Value = Strings.Format((object)num8, "0");
					((DataGridView)dGV_DETL)[16, num19].Value = Strings.Format((object)num9, "0");
					num = 0.0;
					num2 = 0.0;
					num3 = 0.0;
					num4 = 0.0;
					num5 = 0.0;
					num6 = 0.0;
					num7 = 0.0;
					num8 = 0.0;
					num9 = 0.0;
					num19 = DC_Main.R;
				}
				dGV_DETL = null;
			}
			DataGridViewX dGV_DETL2 = DGV_DETL;
			((DataGridView)dGV_DETL2).Rows.Add();
			((DataGridView)dGV_DETL2).Rows.Add();
			DC_Main.R = ((DataGridView)dGV_DETL2).Rows.Count - 1;
			((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = "Total :";
			((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = Strings.Format((object)num10, "0");
			((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = Strings.Format((object)num11, "0.00");
			((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = Strings.Format((object)num12, "0.00");
			((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = Strings.Format((object)num13, "0.00");
			((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = Strings.Format((object)num14, "0");
			((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = Strings.Format((object)num15, "0");
			((DataGridView)dGV_DETL2)[14, DC_Main.R].Value = Strings.Format((object)num16, "0");
			((DataGridView)dGV_DETL2)[15, DC_Main.R].Value = Strings.Format((object)num17, "0");
			((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = Strings.Format((object)num18, "0");
			dGV_DETL2 = null;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
		}
	}

	private void ItemWiseComm()
	{
		//IL_21b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21bd: Expected O, but got Unknown
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected O, but got Unknown
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
		double num16 = 0.0;
		double num17 = 0.0;
		double num18 = 0.0;
		string text = "";
		int num19 = 0;
		if (chkVchSum.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE,A.IT_CODE,C.IT_NAME,C.EMP_COM_PRC,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_PCS ELSE - A.ITM_PCS END) AS ITM_PCS,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_GWT ELSE -A.ITM_GWT END) AS ITM_GWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_NWT ELSE -A.ITM_NWT END) AS ITM_NWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_FINE ELSE -A.ITM_FINE END) AS ITM_FINE,SUM(CASE WHEN ITM_SIGN = '-' THEN A.LBR_AMT ELSE -A.LBR_AMT END) AS LBR_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.OTH_AMT ELSE -A.OTH_AMT END) AS OTH_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_MRP ELSE -A.ITM_MRP END) AS ITM_MRP,SUM(CASE WHEN ITM_SIGN = '-' THEN A.NET_AMT ELSE -A.NET_AMT END) AS NET_AMT,B.EMP_NAME FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN EMP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.EMP_CODE = B.EMP_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(cboItmType.SelectedIndex == 0, (object)"", (object)("AND C.IT_TYPE = '" + Strings.Mid(cboItmType.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.EMP_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" And A.EMP_CODE <> '' GROUP BY A.EMP_CODE,A.IT_CODE,C.IT_NAME,C.EMP_COM_PRC,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,B.EMP_NAME ORDER BY A.EMP_CODE,C.IT_NAME "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE,A.IT_CODE,C.IT_NAME,C.EMP_COM_PRC,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.SR_NO,A.ISR_NO,A.VCH_DATE,A.BOOK_NAME,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_PCS ELSE - A.ITM_PCS END) AS ITM_PCS,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_GWT ELSE -A.ITM_GWT END) AS ITM_GWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_NWT ELSE -A.ITM_NWT END) AS ITM_NWT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_FINE ELSE -A.ITM_FINE END) AS ITM_FINE,SUM(CASE WHEN ITM_SIGN = '-' THEN A.LBR_AMT ELSE -A.LBR_AMT END) AS LBR_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.OTH_AMT ELSE -A.OTH_AMT END) AS OTH_AMT,SUM(CASE WHEN ITM_SIGN = '-' THEN A.ITM_MRP ELSE -A.ITM_MRP END) AS ITM_MRP,SUM(CASE WHEN ITM_SIGN = '-' THEN A.NET_AMT ELSE -A.NET_AMT END) AS NET_AMT,B.EMP_NAME FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN EMP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.EMP_CODE = B.EMP_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(cboItmType.SelectedIndex == 0, (object)"", (object)("AND C.IT_TYPE = '" + Strings.Mid(cboItmType.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.EMP_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" And A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" And A.EMP_CODE <> '' GROUP BY A.EMP_CODE,A.IT_CODE,C.IT_NAME,C.EMP_COM_PRC,A.VCH_TYPE,A.CO_BOOK,A.VCH_NO,A.SR_NO,A.ISR_NO,A.VCH_DATE,A.BOOK_NAME,B.EMP_NAME ORDER BY A.VCH_DATE,A.EMP_CODE,A.CO_BOOK,A.VCH_NO,A.IT_CODE,C.IT_NAME "));
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				while (DC_Main.X < dataTable.Rows.Count)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					DC_Main.R = ((DataGridView)dGV_DETL).Rows.Count - 1;
					((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
					if (Operators.ConditionalCompareObjectNotEqual((object)text, Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)""), false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)""));
						if (DC_Main.X != 0)
						{
							((DataGridView)dGV_DETL)[8, num19].Value = Strings.Format((object)num, "0");
							((DataGridView)dGV_DETL)[9, num19].Value = Strings.Format((object)num2, "0.00");
							((DataGridView)dGV_DETL)[10, num19].Value = Strings.Format((object)num3, "0.00");
							((DataGridView)dGV_DETL)[11, num19].Value = Strings.Format((object)num4, "0.00");
							((DataGridView)dGV_DETL)[12, num19].Value = Strings.Format((object)num5, "0");
							((DataGridView)dGV_DETL)[13, num19].Value = Strings.Format((object)num6, "0");
							((DataGridView)dGV_DETL)[14, num19].Value = Strings.Format((object)num7, "0");
							((DataGridView)dGV_DETL)[15, num19].Value = Strings.Format((object)num8, "0");
							((DataGridView)dGV_DETL)[16, num19].Value = Strings.Format((object)num9, "0");
							num = 0.0;
							num2 = 0.0;
							num3 = 0.0;
							num4 = 0.0;
							num5 = 0.0;
							num6 = 0.0;
							num7 = 0.0;
							num8 = 0.0;
							num9 = 0.0;
							num19 = DC_Main.R;
						}
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)"");
						((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Maroon;
						((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.Font = new Font("Segoe UI", (float)DC_Main.HaderFont, (FontStyle)1);
						((DataGridView)dGV_DETL).Rows.Add();
						DC_Main.R = ((DataGridView)dGV_DETL).Rows.Count - 1;
						((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)"");
						((DataGridView)dGV_DETL)[5, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_CODE"], (object)"");
						((DataGridView)dGV_DETL)[6, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_NAME"], (object)"");
						((DataGridView)dGV_DETL)[7, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_COM_PRC"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_NO"], (object)"");
						((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_PCS"], (object)"")), "0");
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_GWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_NWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["LBR_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["OTH_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[14, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_MRP"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[15, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["NET_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = CommType;
						((DataGridView)dGV_DETL)[18, DC_Main.R].Value = Conversion.Val(nComVal.Text);
						if ((Operators.CompareString(CommType, "", false) != 0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) != 0.0))
						{
							switch (CommType)
							{
							case "L":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) / 100.0, 0), "0.00");
								}
								break;
							case "T":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) / 100.0, 0), "0.00");
								}
								break;
							case "G":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)), 0), "0.00");
								break;
							case "N":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)), 0), "0.00");
								break;
							case "M":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) / 100.0, 0), "0.00");
								}
								break;
							}
						}
						((DataGridView)dGV_DETL)[20, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_CODE"], (object)"");
						((DataGridView)dGV_DETL)[21, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
						((DataGridView)dGV_DETL)[22, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CO_BOOK"], (object)"");
						num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
					}
					else
					{
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_NAME"], (object)"");
						((DataGridView)dGV_DETL)[5, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_CODE"], (object)"");
						((DataGridView)dGV_DETL)[6, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["IT_NAME"], (object)"");
						((DataGridView)dGV_DETL)[7, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_COM_PRC"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_NO"], (object)"");
						((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_PCS"], (object)"")), "0");
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_GWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_NWT"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_FINE"], (object)"")), "0.000");
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["LBR_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["OTH_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[14, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["ITM_MRP"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[15, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["NET_AMT"], (object)"")), "0.00");
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = CommType;
						((DataGridView)dGV_DETL)[18, DC_Main.R].Value = Conversion.Val(nComVal.Text);
						if ((Operators.CompareString(CommType, "", false) != 0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) != 0.0))
						{
							switch (CommType)
							{
							case "L":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) / 100.0, 0), "0.00");
								}
								break;
							case "T":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) / 100.0, 0), "0.00");
								}
								break;
							case "G":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)), 0), "0.00");
								break;
							case "N":
								((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)), 0), "0.00");
								break;
							case "M":
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) != 0.0)
								{
									((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) / 100.0, 0), "0.00");
								}
								break;
							}
						}
						((DataGridView)dGV_DETL)[20, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["EMP_CODE"], (object)"");
						((DataGridView)dGV_DETL)[21, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
						((DataGridView)dGV_DETL)[22, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CO_BOOK"], (object)"");
						num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV_DETL)[10, DC_Main.R].Value));
						num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV_DETL)[12, DC_Main.R].Value));
						num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV_DETL)[14, DC_Main.R].Value));
						num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
					}
					DC_Main.X++;
				}
				if (DC_Main.X != 0)
				{
					((DataGridView)dGV_DETL)[8, num19].Value = Strings.Format((object)num, "0");
					((DataGridView)dGV_DETL)[9, num19].Value = Strings.Format((object)num2, "0.00");
					((DataGridView)dGV_DETL)[10, num19].Value = Strings.Format((object)num3, "0.00");
					((DataGridView)dGV_DETL)[11, num19].Value = Strings.Format((object)num4, "0.00");
					((DataGridView)dGV_DETL)[12, num19].Value = Strings.Format((object)num5, "0");
					((DataGridView)dGV_DETL)[13, num19].Value = Strings.Format((object)num6, "0");
					((DataGridView)dGV_DETL)[14, num19].Value = Strings.Format((object)num7, "0");
					((DataGridView)dGV_DETL)[15, num19].Value = Strings.Format((object)num8, "0");
					((DataGridView)dGV_DETL)[16, num19].Value = Strings.Format((object)num9, "0");
					num = 0.0;
					num2 = 0.0;
					num3 = 0.0;
					num4 = 0.0;
					num5 = 0.0;
					num6 = 0.0;
					num7 = 0.0;
					num8 = 0.0;
					num9 = 0.0;
					num19 = DC_Main.R;
				}
				dGV_DETL = null;
			}
			DataGridViewX dGV_DETL2 = DGV_DETL;
			((DataGridView)dGV_DETL2).Rows.Add();
			((DataGridView)dGV_DETL2).Rows.Add();
			DC_Main.R = ((DataGridView)dGV_DETL2).Rows.Count - 1;
			((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = "Total :";
			((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = Strings.Format((object)num10, "0");
			((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = Strings.Format((object)num11, "0.00");
			((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = Strings.Format((object)num12, "0.00");
			((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = Strings.Format((object)num13, "0.00");
			((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = Strings.Format((object)num14, "0");
			((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = Strings.Format((object)num15, "0");
			((DataGridView)dGV_DETL2)[14, DC_Main.R].Value = Strings.Format((object)num16, "0");
			((DataGridView)dGV_DETL2)[15, DC_Main.R].Value = Strings.Format((object)num17, "0");
			((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = Strings.Format((object)num18, "0");
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
					if (((uint)(columnIndex - 8) <= 5u || columnIndex == 15) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 110:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00a4;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 110;
				continue;
			}
			break;
			IL_00a4:
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
		ColorConverter colorConverter = default(ColorConverter);
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
					case 1527:
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
								goto IL_019a;
							case 17:
								goto IL_01c7;
							case 18:
								goto IL_01d0;
							case 19:
								goto IL_01e7;
							case 20:
								goto IL_020a;
							case 21:
							case 22:
								goto IL_025c;
							case 23:
							case 24:
								goto IL_0270;
							case 25:
								goto IL_028b;
							case 26:
								goto IL_0295;
							case 27:
								goto IL_02e8;
							case 28:
								goto IL_033d;
							case 29:
								goto IL_0395;
							case 30:
								goto IL_0403;
							case 31:
								goto IL_0446;
							case 32:
								goto IL_0475;
							case 33:
								goto IL_04b8;
							case 34:
								goto IL_04f9;
							case 35:
								goto IL_051a;
							case 36:
								goto IL_0528;
							case 37:
								goto IL_052e;
							case 38:
								goto IL_0534;
							case 39:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 40:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0270:
						num2 = 24;
						DC_Main.i++;
						goto IL_027f;
						IL_0120:
						num2 = 12;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num5 + 1,
							((DataGridView)DGV_DETL).Columns[num5].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_025c:
						num2 = 22;
						num6++;
						goto IL_0265;
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
						num9 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_027f;
						IL_027f:
						if (DC_Main.i <= num9)
						{
							goto IL_019a;
						}
						goto IL_028b;
						IL_028b:
						num2 = 25;
						colorConverter = new ColorConverter();
						goto IL_0295;
						IL_0295:
						num2 = 26;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_02e8;
						IL_02e8:
						num2 = 27;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_033d;
						IL_033d:
						num2 = 28;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_0395;
						IL_0395:
						num2 = 29;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0403;
						IL_0403:
						num2 = 30;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0446;
						IL_0446:
						num2 = 31;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0475;
						IL_0475:
						num2 = 32;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_04b8;
						IL_04b8:
						num2 = 33;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_04f9;
						IL_04f9:
						num2 = 34;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_051a;
						IL_051a:
						num2 = 35;
						Cursor.Current = Cursors.Default;
						goto IL_0528;
						IL_0528:
						num2 = 36;
						obj = null;
						goto IL_052e;
						IL_052e:
						num2 = 37;
						obj3 = null;
						goto IL_0534;
						IL_0534:
						num2 = 38;
						obj2 = null;
						break;
						IL_019a:
						num2 = 16;
						if (Operators.ConditionalCompareObjectNotEqual(((DataGridView)DGV_DETL)[3, DC_Main.i].Value, (object)"", false))
						{
							goto IL_01c7;
						}
						goto IL_0270;
						IL_01c7:
						num2 = 17;
						num8++;
						goto IL_01d0;
						IL_01d0:
						num2 = 18;
						num10 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num6 = 0;
						goto IL_0265;
						IL_0265:
						if (num6 <= num10)
						{
							goto IL_01e7;
						}
						goto IL_0270;
						IL_01e7:
						num2 = 19;
						if (((DataGridView)DGV_DETL)[num6, DC_Main.i].Value != null)
						{
							goto IL_020a;
						}
						goto IL_025c;
						IL_020a:
						num2 = 20;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							num8 + 2,
							num6 + 1,
							((DataGridView)DGV_DETL)[num6, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_025c;
						end_IL_0001_2:
						break;
					}
					num2 = 39;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1527;
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

	private void RP_EMP_Load(object sender, EventArgs e)
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected O, but got Unknown
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Expected O, but got Unknown
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Expected O, but got Unknown
		//IL_092b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Expected O, but got Unknown
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f7: Expected O, but got Unknown
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a25: Expected O, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a53: Expected O, but got Unknown
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
				int num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mFromDt).Font;
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
			cboItmType.Items.Add((object)"");
			cboItmType.Items.Add((object)"Gold");
			cboItmType.Items.Add((object)"Silver");
			cboItmType.SelectedIndex = 0;
			cboCommType.Items.Add((object)"");
			cboCommType.Items.Add((object)"Labour %");
			cboCommType.Items.Add((object)"TotAmt %");
			cboCommType.Items.Add((object)"GrWt x Val");
			cboCommType.Items.Add((object)"NetWt x Val");
			cboCommType.Items.Add((object)"Mrp %");
			cboCommType.SelectedIndex = 0;
			CLEAR_DATA();
			DGV_ITM_FILL();
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
		SelectIt = "";
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((DataGridView)DGV_ITM).Columns.Clear();
		((Control)DGV_ITM).Refresh();
		((Control)PnlIt).Visible = false;
		chkItSelect.Checked = false;
		mFromDt.Text = "01" + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 3, 10);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)mToDt).Focus();
	}

	private void RP_EMP_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_EMP_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_EMP_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_EMP_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_EMP_Closed(object sender, EventArgs e)
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
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND EMP_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.EMP_NAME As EmpNameL,A.EMP_CODE As EmpCodeL FROM EMP_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.EMP_CODE";
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
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
			DGV_ITM_FILL();
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[22].Value), (object)""), (object)"' "));
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
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[3].Value, (object)""));
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
			DGV_ITM_FILL();
		}
	}

	private void BtnList_Click(object sender, EventArgs e)
	{
		DGV_ITM_FILL();
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

	private void chkItSelect_Click(object sender, EventArgs e)
	{
		if (chkItSelect.Checked)
		{
			((Control)PnlIt).Visible = true;
			ItmList();
		}
	}

	private void ItmList()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(cboItmType.Text, "", false) == 0, (object)"", (object)("AND IT_TYPE = '" + Strings.Mid(cboItmType.Text, 1, 1) + "'"))), (object)" ORDER BY A.IT_NAME "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV_ITM).Rows.Count <= 0)
			{
				DataGridViewX dGV_ITM = DGV_ITM;
				((DataGridView)dGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV_ITM).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV_ITM).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV_ITM).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "Sr");
				((DataGridView)dGV_ITM).Columns[1].Width = 40;
				((DataGridView)dGV_ITM).Columns.Add("", "Itm Name");
				((DataGridView)dGV_ITM).Columns[2].Width = 224;
				((DataGridView)dGV_ITM).Columns.Add("", "It Code");
				((DataGridView)dGV_ITM).Columns[3].Width = 80;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV_ITM).Rows.Add();
					((DataGridView)dGV_ITM)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV_ITM)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"]);
					((DataGridView)dGV_ITM)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]);
					DC_Main.i++;
				}
				dGV_ITM = null;
			}
		}
	}

	private void BtnAll_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value = true;
				DC_Main.M++;
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		SelectIt = "";
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false))
				{
					SelectIt = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(SelectIt + "'"), ((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells[3].Value), (object)"',"));
				}
				DC_Main.M++;
			}
			if (Operators.CompareString(SelectIt, "", false) == 0)
			{
				Interaction.MsgBox((object)"Item Selection Not Done...", (MsgBoxStyle)0, (object)null);
				((Control)PnlIt).Visible = false;
			}
			else
			{
				SelectIt = Strings.Mid(SelectIt, 1, Strings.Len(SelectIt) - 1);
				((Control)PnlIt).Visible = false;
			}
		}
	}

	private void BtnItCancel_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
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
				((Control)BtnList).Focus();
			}
		}
		else
		{
			((Control)BtnList).Focus();
		}
	}

	private void nComVal_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nComVal.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nComVal.Text)), "0.00");
			((Control)BtnList).Focus();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Invalid comparison between Unknown and I4
		string text = "Employee Wise Sales Summ";
		DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DataGridViewX dGV_DETL = DGV_DETL;
		checked
		{
			int num = ((DataGridView)dGV_DETL).RowCount - 3;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				if (Operators.ConditionalCompareObjectNotEqual(((DataGridView)dGV_DETL)[3, DC_Main.X].Value, (object)"", false))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13,COL_14,COL_15)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[0, DC_Main.X].Value), "0000") + "','"), ((DataGridView)dGV_DETL)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[3, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[5, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[7, DC_Main.X].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_DETL)[8, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[9, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[10, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[11, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[12, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[13, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[14, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[15, DC_Main.X].Value), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.X++;
			}
			dGV_DETL = null;
			DC_Main.RsQry = "SELECT * FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY SR_NO";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (unchecked((int)Interaction.MsgBox((object)"Day Wise Employee Bill..?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\EmpDaySumm.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\EmpSumm.RPT";
			}
			Cr.SelectionFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
			Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
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
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
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
			}
			((TextBoxBase)tGrCode).SelectAll();
		}
	}

	private void chkItSelect_CheckedChanged(object sender, EventArgs e)
	{
	}
}
