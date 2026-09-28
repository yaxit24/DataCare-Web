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
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_TAX : Form
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
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGroupWise")]
	private QButton _BtnGroupWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWithRef")]
	private QButton _btnWithRef;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAreaWise")]
	private QButton _btnAreaWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDrList")]
	private QButton _BtnDrList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLdrWeight")]
	private QButton _btnLdrWeight;

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
	[AccessedThroughProperty("tTaxCode")]
	private TextBox _tTaxCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTaxSumm")]
	private QButton _btnTaxSumm;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string CurFormula;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
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
	[AccessedThroughProperty("dlgOpen")]
	private virtual FolderBrowserDialog _dlgOpen;

	internal virtual FolderBrowserDialog dlgOpen
	{
		get
		{
			return _dlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_dlgOpen = value;
		}
	}

	internal virtual TextBox tRefAc
	{
		[CompilerGenerated]
		get
		{
			return _tRefAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRefAc_KeyDown);
			TextBox val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRefAc = value;
			val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefName")]
	private virtual TextBox _tRefName;

	internal virtual TextBox tRefName
	{
		get
		{
			return _tRefName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRefName = value;
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
	[AccessedThroughProperty("tLcName")]
	private virtual TextBox _tLcName;

	internal virtual TextBox tLcName
	{
		get
		{
			return _tLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLcName = value;
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
	[AccessedThroughProperty("PanelDhrn")]
	private virtual Panel _PanelDhrn;

	internal virtual Panel PanelDhrn
	{
		get
		{
			return _PanelDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelDhrn = value;
		}
	}

	internal virtual QButton BtnGroupWise
	{
		[CompilerGenerated]
		get
		{
			return _BtnGroupWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGroupWise_Click;
			QButton val = _BtnGroupWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGroupWise = value;
			val = _BtnGroupWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnWithRef
	{
		[CompilerGenerated]
		get
		{
			return _btnWithRef;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnWithRef_Click;
			QButton val = _btnWithRef;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWithRef = value;
			val = _btnWithRef;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAreaWise
	{
		[CompilerGenerated]
		get
		{
			return _btnAreaWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAreaWise_Click;
			QButton val = _btnAreaWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAreaWise = value;
			val = _btnAreaWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnDrList
	{
		[CompilerGenerated]
		get
		{
			return _BtnDrList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDrList_Click;
			QButton val = _BtnDrList;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDrList = value;
			val = _BtnDrList;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnLdrWeight
	{
		[CompilerGenerated]
		get
		{
			return _btnLdrWeight;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLdrWeight_Click;
			QButton val = _btnLdrWeight;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLdrWeight = value;
			val = _btnLdrWeight;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tTaxCode
	{
		[CompilerGenerated]
		get
		{
			return _tTaxCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTaxCode_KeyDown);
			TextBox val2 = _tTaxCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTaxCode = value;
			val2 = _tTaxCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTaxName")]
	private virtual TextBox _tTaxName;

	internal virtual TextBox tTaxName
	{
		get
		{
			return _tTaxName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTaxName = value;
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

	internal virtual QButton btnTaxSumm
	{
		[CompilerGenerated]
		get
		{
			return _btnTaxSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTaxSumm_Click;
			QButton val = _btnTaxSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTaxSumm = value;
			val = _btnTaxSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public RP_TAX()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += RP_TAX_Load;
		((Form)this).Deactivate += RP_TAX_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_TAX_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_TAX_KeyDown);
		((Form)this).Closed += RP_TAX_Closed;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Expected O, but got Unknown
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Expected O, but got Unknown
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0945: Expected O, but got Unknown
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		//IL_0a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Expected O, but got Unknown
		//IL_0b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1c: Expected O, but got Unknown
		//IL_0bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Expected O, but got Unknown
		//IL_0c8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c95: Expected O, but got Unknown
		//IL_0d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Expected O, but got Unknown
		//IL_0da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dab: Expected O, but got Unknown
		//IL_0e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e66: Expected O, but got Unknown
		//IL_0ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eed: Expected O, but got Unknown
		//IL_0f71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7b: Expected O, but got Unknown
		//IL_1308: Unknown result type (might be due to invalid IL or missing references)
		//IL_132c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1350: Unknown result type (might be due to invalid IL or missing references)
		//IL_1374: Unknown result type (might be due to invalid IL or missing references)
		//IL_139d: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a7: Expected O, but got Unknown
		//IL_13ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_162d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1651: Unknown result type (might be due to invalid IL or missing references)
		//IL_1675: Unknown result type (might be due to invalid IL or missing references)
		//IL_1699: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cc: Expected O, but got Unknown
		//IL_16ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1952: Unknown result type (might be due to invalid IL or missing references)
		//IL_1976: Unknown result type (might be due to invalid IL or missing references)
		//IL_199a: Unknown result type (might be due to invalid IL or missing references)
		//IL_19be: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f1: Expected O, but got Unknown
		//IL_1a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d16: Expected O, but got Unknown
		//IL_1d36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2005: Unknown result type (might be due to invalid IL or missing references)
		//IL_202e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2038: Expected O, but got Unknown
		//IL_205b: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_20db: Expected O, but got Unknown
		//IL_2172: Unknown result type (might be due to invalid IL or missing references)
		//IL_217c: Expected O, but got Unknown
		//IL_2213: Unknown result type (might be due to invalid IL or missing references)
		//IL_221d: Expected O, but got Unknown
		//IL_229d: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a7: Expected O, but got Unknown
		//IL_232e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2338: Expected O, but got Unknown
		//IL_23ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f6: Expected O, but got Unknown
		//IL_2476: Unknown result type (might be due to invalid IL or missing references)
		//IL_2480: Expected O, but got Unknown
		//IL_2507: Unknown result type (might be due to invalid IL or missing references)
		//IL_2511: Expected O, but got Unknown
		//IL_27b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_281e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2847: Unknown result type (might be due to invalid IL or missing references)
		//IL_2851: Expected O, but got Unknown
		//IL_2877: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_TAX));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tRefAc = new TextBox();
		tRefName = new TextBox();
		Label1 = new Label();
		Label2 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label3 = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		PanelDhrn = new Panel();
		btnLdrWeight = new QButton();
		BtnDrList = new QButton();
		BtnGroupWise = new QButton();
		btnWithRef = new QButton();
		btnAreaWise = new QButton();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label4 = new Label();
		tTaxCode = new TextBox();
		tTaxName = new TextBox();
		Label5 = new Label();
		btnTaxSumm = new QButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)PanelDhrn).SuspendLayout();
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
		((Control)PnlBotam).TabIndex = 8;
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
		((Control)BtnExit).TabIndex = 25;
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
		((Control)BtnDelete).TabIndex = 24;
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
		((Control)BtnCancel).TabIndex = 23;
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
		((Control)BtnSave).TabIndex = 22;
		BtnSave.Text = "&Save";
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
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
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
		lblBook.Text = "Tax Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tRefAc).BackColor = Color.White;
		((Control)tRefAc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefAc).Location = new Point(475, 154);
		((TextBoxBase)tRefAc).MaxLength = 8;
		((Control)tRefAc).Name = "tRefAc";
		((Control)tRefAc).Size = new Size(76, 23);
		((Control)tRefAc).TabIndex = 4;
		((TextBoxBase)tRefName).BackColor = Color.White;
		((Control)tRefName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefName).Location = new Point(557, 153);
		((TextBoxBase)tRefName).MaxLength = 8;
		((Control)tRefName).Name = "tRefName";
		((Control)tRefName).Size = new Size(282, 23);
		((Control)tRefName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(408, 154);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Ref Ac";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(367, 67);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "From / To Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(475, 124);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(557, 124);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(393, 124);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(75, 20);
		((Control)Label3).TabIndex = 1165;
		Label3.Text = "Party Code";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(475, 96);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(76, 23);
		((Control)tLcCode).TabIndex = 2;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(557, 95);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(282, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(408, 96);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "Lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)PanelDhrn).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelDhrn).Controls.Add((Control)(object)btnTaxSumm);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnLdrWeight);
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnDrList);
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnGroupWise);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnWithRef);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnAreaWise);
		((Control)PanelDhrn).Location = new Point(220, 257);
		((Control)PanelDhrn).Name = "PanelDhrn";
		((Control)PanelDhrn).Size = new Size(712, 222);
		((Control)PanelDhrn).TabIndex = 7;
		((QControl)btnLdrWeight).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLdrWeight).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLdrWeight).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLdrWeight.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Image = null;
		((QControl)btnLdrWeight).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLdrWeight).Location = new Point(434, 23);
		((Control)btnLdrWeight).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLdrWeight).Name = "btnLdrWeight";
		((Control)btnLdrWeight).Size = new Size(143, 37);
		((Control)btnLdrWeight).TabIndex = 7;
		btnLdrWeight.Text = "In Out Tax";
		((QControl)BtnDrList).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDrList).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDrList).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDrList).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDrList).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDrList).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDrList).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnDrList).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDrList).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDrList).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDrList).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDrList).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDrList).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDrList).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDrList.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Image = null;
		((QControl)BtnDrList).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDrList).Location = new Point(344, 78);
		((Control)BtnDrList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDrList).Name = "BtnDrList";
		((Control)BtnDrList).Size = new Size(143, 37);
		((Control)BtnDrList).TabIndex = 3;
		BtnDrList.Text = "InPut Tax (Purc)";
		((QControl)BtnGroupWise).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGroupWise).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGroupWise).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGroupWise.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Image = null;
		((QControl)BtnGroupWise).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGroupWise).Location = new Point(182, 78);
		((Control)BtnGroupWise).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroupWise).Name = "BtnGroupWise";
		((Control)BtnGroupWise).Size = new Size(143, 37);
		((Control)BtnGroupWise).TabIndex = 0;
		BtnGroupWise.Text = "OutPut Tax (Sale)";
		((QControl)btnWithRef).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWithRef).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWithRef).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWithRef).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWithRef).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWithRef).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWithRef).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWithRef).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWithRef).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWithRef).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWithRef).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWithRef).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWithRef).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWithRef).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWithRef.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Image = null;
		((QControl)btnWithRef).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWithRef).Location = new Point(102, 23);
		((Control)btnWithRef).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWithRef).Name = "btnWithRef";
		((Control)btnWithRef).Size = new Size(143, 37);
		((Control)btnWithRef).TabIndex = 1;
		btnWithRef.Text = "Sales Tax";
		((QControl)btnAreaWise).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAreaWise).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAreaWise).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAreaWise).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAreaWise).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAreaWise).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAreaWise).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAreaWise).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAreaWise).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAreaWise).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAreaWise.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Image = null;
		((QControl)btnAreaWise).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAreaWise).Location = new Point(266, 23);
		((Control)btnAreaWise).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAreaWise).Name = "btnAreaWise";
		((Control)btnAreaWise).Size = new Size(143, 37);
		((Control)btnAreaWise).TabIndex = 2;
		btnAreaWise.Text = "Purchase Tax";
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(559, 66);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(477, 66);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(475, 184);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(76, 23);
		((Control)tBookCode).TabIndex = 5;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(557, 183);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(282, 23);
		((Control)tBookName).TabIndex = 1290;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(370, 184);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(97, 20);
		((Control)Label4).TabIndex = 1289;
		Label4.Text = "Book";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tTaxCode).BackColor = Color.White;
		((Control)tTaxCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tTaxCode).Location = new Point(475, 213);
		((TextBoxBase)tTaxCode).MaxLength = 8;
		((Control)tTaxCode).Name = "tTaxCode";
		((Control)tTaxCode).Size = new Size(76, 23);
		((Control)tTaxCode).TabIndex = 6;
		((TextBoxBase)tTaxName).BackColor = Color.White;
		((Control)tTaxName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tTaxName).Location = new Point(557, 212);
		((TextBoxBase)tTaxName).MaxLength = 8;
		((Control)tTaxName).Name = "tTaxName";
		((Control)tTaxName).Size = new Size(282, 23);
		((Control)tTaxName).TabIndex = 1293;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(370, 213);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(97, 20);
		((Control)Label5).TabIndex = 1292;
		Label5.Text = "Tax Code";
		Label5.TextAlign = (ContentAlignment)64;
		((QControl)btnTaxSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnTaxSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTaxSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnTaxSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnTaxSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnTaxSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTaxSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnTaxSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnTaxSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnTaxSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnTaxSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTaxSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnTaxSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnTaxSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnTaxSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTaxSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTaxSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTaxSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTaxSumm.Image = null;
		((QControl)btnTaxSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnTaxSumm).Location = new Point(266, 137);
		((Control)btnTaxSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)btnTaxSumm).Name = "btnTaxSumm";
		((Control)btnTaxSumm).Size = new Size(143, 37);
		((Control)btnTaxSumm).TabIndex = 8;
		btnTaxSumm.Text = "Tax (Summ)";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tTaxCode);
		((Control)this).Controls.Add((Control)(object)tTaxName);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)PanelDhrn);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tRefAc);
		((Control)this).Controls.Add((Control)(object)tRefName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_TAX";
		((Form)this).Text = "Tax Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)PanelDhrn).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_TAX_Load(object sender, EventArgs e)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = "Tax Report";
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
			foreach (object control3 in ((Control)PanelDhrn).Controls)
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
				((Control)PanelDhrn).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelDhrn = PanelDhrn;
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelDhrn).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj9 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj10 = lblBook;
				object? obj11 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj10).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				Panel panelDhrn2 = PanelDhrn;
				object? obj13 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelDhrn2).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			mFromDt.Text = "01/" + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 7);
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
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_TAX_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_TAX_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_TAX_KeyDown(object sender, KeyEventArgs e)
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
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_TAX_Closed(object sender, EventArgs e)
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
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
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
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
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
					tLcName.Text = DC_Main.ColValue[1];
				}
			}
			else
			{
				tLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select B.AC_NAME,A.AC_REF_CODE From AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.AC_REF_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.AC_REF_CODE = '" + tRefAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.AC_REF_CODE As AcCodeL,B.AC_CITY AS CityL,B.AC_ADD1 As AddressL,B.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.AC_REF_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_REF_CODE <> '' GROUP BY B.AC_NAME,A.AC_REF_CODE,B.AC_CITY,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[7];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 220.0;
				DC_Main.ColWidth[3] = 280.0;
				DC_Main.ColWidth[4] = 120.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
						tRefName.Text = DC_Main.ColValue[0];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				tRefName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void btnWithRef_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SlTaxRpt.RPT";
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {TAX_DATA.TRAN_TYPE} = 'S'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.TAX_CODE} = '" + tTaxCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Sales Vat Report (Output Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "SlTaxRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Sales Vat Report (Output Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnAreaWise_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PrTaxRpt.RPT";
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {TAX_DATA.TRAN_TYPE} = 'P'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.TAX_CODE} = '" + tTaxCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Purchase Vat Report (Input Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "PrTaxRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Purchase Vat Report (Input Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnDrList_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\InTax_PurcRpt.RPT";
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {TAX_DATA.TRAN_TYPE} = 'P'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.TAX_CODE} = '" + tTaxCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Purchase Vat Report(InPut Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "InTax_PurcRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Purchase Vat Report(InPut Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnLdrWeight_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TaxInOutRpt.RPT";
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.TAX_CODE} = '" + tTaxCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Vat InPut and OutPut Tax Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "TaxInOutRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Vat InPut and OutPut Tax Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
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
		((TextBoxBase)mFromDt).SelectAll();
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectAll();
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
				DC_Main.RsQry = "SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM TAX_DATA AS B INNER JOIN  BOOK_DATA AS A ON B.CO_CODE = A.CO_CODE AND B.CO_BOOK = A.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.BOOK_NAME,A.CO_BOOK  ORDER BY A.BOOK_NAME";
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
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tTaxCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_CODE = '" + tTaxCode.Text + "'  ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.TAX_CODE As TaxCodeL,A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcR FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 250.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tTaxCode.Text = DC_Main.ColValue[0];
					tTaxName.Text = DC_Main.ColValue[1];
				}
				((Control)tTaxCode).Focus();
			}
		}
		else
		{
			tTaxCode.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["TAX_CODE"]);
			tTaxName.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["TAX_NAME"]);
		}
	}

	private void BtnGroupWise_Click(object sender, EventArgs e)
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
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OutTax_SaleRpt.RPT";
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {TAX_DATA.TRAN_TYPE} = 'S'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.TAX_CODE} = '" + tTaxCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Sales Vat Report (Output Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "OutTax_SaleRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Sales Vat Report(Output Tax) From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnTaxSumm_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TaxSummUae.RPT";
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.TAX_CODE} = '" + tTaxCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Vat InPut and OutPut Tax Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "TaxSummUae";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Vat Summary Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}
}
