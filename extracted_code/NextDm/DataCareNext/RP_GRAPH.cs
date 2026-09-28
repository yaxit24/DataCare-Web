using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_GRAPH : Form
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
	[AccessedThroughProperty("BtnGroup")]
	private QButton _BtnGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnMothSl")]
	private QButton _BtnMothSl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItem")]
	private QButton _BtnItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnEmpSl")]
	private QButton _BtnEmpSl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSize")]
	private QButton _BtnSize;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExpType")]
	private QButton _BtnExpType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnKrSl")]
	private QButton _BtnKrSl;

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
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private string RptType;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string StkType;

	private string[] AryTableCode;

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

	internal virtual QButton BtnMothSl
	{
		[CompilerGenerated]
		get
		{
			return _BtnMothSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMothSl_Click;
			QButton val = _BtnMothSl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnMothSl = value;
			val = _BtnMothSl;
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

	internal virtual QButton BtnEmpSl
	{
		[CompilerGenerated]
		get
		{
			return _BtnEmpSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEmpSl_Click;
			QButton val = _BtnEmpSl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnEmpSl = value;
			val = _BtnEmpSl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	internal virtual QButton BtnExpType
	{
		[CompilerGenerated]
		get
		{
			return _BtnExpType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExpType_Click;
			QButton val = _BtnExpType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExpType = value;
			val = _BtnExpType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnKrSl
	{
		[CompilerGenerated]
		get
		{
			return _BtnKrSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnKrSl_Click;
			QButton val = _BtnKrSl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnKrSl = value;
			val = _BtnKrSl;
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
	[AccessedThroughProperty("cboSlType")]
	private virtual ComboBox _cboSlType;

	internal virtual ComboBox cboSlType
	{
		get
		{
			return _cboSlType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSlType = value;
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
	[AccessedThroughProperty("cboBookType")]
	private virtual ComboBox _cboBookType;

	internal virtual ComboBox cboBookType
	{
		get
		{
			return _cboBookType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboBookType = value;
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
	[AccessedThroughProperty("cboTrntype")]
	private virtual ComboBox _cboTrntype;

	internal virtual ComboBox cboTrntype
	{
		get
		{
			return _cboTrntype;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTrntype = value;
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

	public RP_GRAPH()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += RP_GRAPH_Load;
		((Form)this).Deactivate += RP_GRAPH_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_GRAPH_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_GRAPH_KeyDown);
		((Form)this).Activated += RP_GRAPH_Activated;
		((Form)this).Closed += RP_LEDR_Closed;
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
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
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
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Expected O, but got Unknown
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Expected O, but got Unknown
		//IL_084a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Expected O, but got Unknown
		//IL_0b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c07: Expected O, but got Unknown
		//IL_0c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f29: Expected O, but got Unknown
		//IL_0f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_11af: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_121b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Unknown result type (might be due to invalid IL or missing references)
		//IL_124e: Expected O, but got Unknown
		//IL_1271: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_151c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1540: Unknown result type (might be due to invalid IL or missing references)
		//IL_1569: Unknown result type (might be due to invalid IL or missing references)
		//IL_1573: Expected O, but got Unknown
		//IL_1596: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_181d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1841: Unknown result type (might be due to invalid IL or missing references)
		//IL_1865: Unknown result type (might be due to invalid IL or missing references)
		//IL_188e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1898: Expected O, but got Unknown
		//IL_18bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbe: Expected O, but got Unknown
		//IL_1be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee4: Expected O, but got Unknown
		//IL_1f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f88: Expected O, but got Unknown
		//IL_201c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2026: Expected O, but got Unknown
		//IL_20a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b3: Expected O, but got Unknown
		//IL_215b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2165: Expected O, but got Unknown
		//IL_21d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21dd: Expected O, but got Unknown
		//IL_228b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2295: Expected O, but got Unknown
		//IL_2316: Unknown result type (might be due to invalid IL or missing references)
		//IL_2320: Expected O, but got Unknown
		//IL_23e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ea: Expected O, but got Unknown
		//IL_2457: Unknown result type (might be due to invalid IL or missing references)
		//IL_2461: Expected O, but got Unknown
		//IL_251e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2528: Expected O, but got Unknown
		//IL_2595: Unknown result type (might be due to invalid IL or missing references)
		//IL_259f: Expected O, but got Unknown
		//IL_265c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2666: Expected O, but got Unknown
		//IL_26d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_26dd: Expected O, but got Unknown
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		BtnGroup = new QButton();
		BtnMothSl = new QButton();
		BtnItem = new QButton();
		BtnEmpSl = new QButton();
		BtnSize = new QButton();
		BtnExpType = new QButton();
		BtnKrSl = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		tGrName = new TextBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		tLcCode = new TextBox();
		cboSlType = new ComboBox();
		Label1 = new Label();
		cboBookType = new ComboBox();
		Label4 = new Label();
		cboTrntype = new ComboBox();
		Label5 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
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
		BtnDelete.Text = "&InOut";
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
		((Control)BtnPrint).Location = new Point(827, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 0;
		BtnPrint.Text = "Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(464, 12);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(82, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(385, 12);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(73, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = SystemColors.ButtonHighlight;
		((Control)Panel1).BackgroundImageLayout = (ImageLayout)3;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Location = new Point(0, 78);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1186, 483);
		((Control)Panel1).TabIndex = 110;
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
		((Control)BtnGroup).Location = new Point(44, 44);
		((Control)BtnGroup).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroup).Name = "BtnGroup";
		((Control)BtnGroup).Size = new Size(143, 37);
		((Control)BtnGroup).TabIndex = 7;
		BtnGroup.Text = "&Last 30 Day SL";
		((QControl)BtnMothSl).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnMothSl).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnMothSl).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnMothSl).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnMothSl).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnMothSl).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnMothSl).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnMothSl).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnMothSl).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnMothSl).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnMothSl).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnMothSl).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnMothSl).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnMothSl).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnMothSl.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMothSl.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMothSl.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMothSl.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMothSl.Image = null;
		((QControl)BtnMothSl).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnMothSl).Location = new Point(203, 44);
		((Control)BtnMothSl).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnMothSl).Name = "BtnMothSl";
		((Control)BtnMothSl).Size = new Size(143, 37);
		((Control)BtnMothSl).TabIndex = 6;
		BtnMothSl.Text = "&Month SL";
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
		((Control)BtnItem).Location = new Point(362, 44);
		((Control)BtnItem).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItem).Name = "BtnItem";
		((Control)BtnItem).Size = new Size(143, 37);
		((Control)BtnItem).TabIndex = 5;
		BtnItem.Text = "&Product SL";
		((QControl)BtnEmpSl).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnEmpSl).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnEmpSl).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnEmpSl).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnEmpSl).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnEmpSl).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnEmpSl).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnEmpSl).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnEmpSl).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnEmpSl).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnEmpSl).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnEmpSl).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnEmpSl).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnEmpSl).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnEmpSl.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmpSl.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmpSl.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmpSl.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmpSl.Image = null;
		((QControl)BtnEmpSl).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnEmpSl).Location = new Point(521, 44);
		((Control)BtnEmpSl).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnEmpSl).Name = "BtnEmpSl";
		((Control)BtnEmpSl).Size = new Size(143, 37);
		((Control)BtnEmpSl).TabIndex = 8;
		BtnEmpSl.Text = "&Emp SL";
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
		((Control)BtnSize).Location = new Point(680, 44);
		((Control)BtnSize).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSize).Name = "BtnSize";
		((Control)BtnSize).Size = new Size(143, 37);
		((Control)BtnSize).TabIndex = 9;
		BtnSize.Text = "&Monthly Exp";
		((QControl)BtnExpType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnExpType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnExpType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnExpType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnExpType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnExpType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnExpType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnExpType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnExpType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnExpType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnExpType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnExpType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnExpType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnExpType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnExpType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnExpType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnExpType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnExpType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnExpType.Image = null;
		((QControl)BtnExpType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnExpType).Location = new Point(839, 44);
		((Control)BtnExpType).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnExpType).Name = "BtnExpType";
		((Control)BtnExpType).Size = new Size(143, 37);
		((Control)BtnExpType).TabIndex = 10;
		BtnExpType.Text = "Exp Type";
		((QControl)BtnKrSl).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnKrSl).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnKrSl).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnKrSl).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnKrSl).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnKrSl).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnKrSl).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnKrSl).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnKrSl).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnKrSl).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnKrSl).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnKrSl).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnKrSl).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnKrSl).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnKrSl.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKrSl.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKrSl.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKrSl.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKrSl.Image = null;
		((QControl)BtnKrSl).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnKrSl).Location = new Point(998, 44);
		((Control)BtnKrSl).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnKrSl).Name = "BtnKrSl";
		((Control)BtnKrSl).Size = new Size(143, 37);
		((Control)BtnKrSl).TabIndex = 11;
		BtnKrSl.Text = "Karigar SL";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(61, 11);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(143, 11);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 12);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(44, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		((Control)tGrName).Font = new Font("Tahoma", 9f);
		((Control)tGrName).Location = new Point(1038, 11);
		((TextBoxBase)tGrName).MaxLength = 50;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(98, 22);
		((Control)tGrName).TabIndex = 1168;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(917, 11);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 20);
		((Control)Label10).TabIndex = 1167;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(986, 11);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(48, 22);
		((Control)tGrCode).TabIndex = 1166;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1142, 10);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1169;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		cboSlType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboSlType).Font = new Font("Tahoma", 9f);
		((ListControl)cboSlType).FormattingEnabled = true;
		((Control)cboSlType).Location = new Point(291, 11);
		((Control)cboSlType).Name = "cboSlType";
		((Control)cboSlType).Size = new Size(87, 22);
		((Control)cboSlType).TabIndex = 1170;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(222, 11);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(63, 20);
		((Control)Label1).TabIndex = 1171;
		Label1.Text = "SL Type";
		Label1.TextAlign = (ContentAlignment)64;
		cboBookType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboBookType).Font = new Font("Tahoma", 9f);
		((ListControl)cboBookType).FormattingEnabled = true;
		((Control)cboBookType).Location = new Point(636, 12);
		((Control)cboBookType).Name = "cboBookType";
		((Control)cboBookType).Size = new Size(90, 22);
		((Control)cboBookType).TabIndex = 1172;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(552, 12);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(80, 20);
		((Control)Label4).TabIndex = 1173;
		Label4.Text = "Book Type";
		Label4.TextAlign = (ContentAlignment)64;
		cboTrntype.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboTrntype).Font = new Font("Tahoma", 9f);
		((ListControl)cboTrntype).FormattingEnabled = true;
		((Control)cboTrntype).Location = new Point(816, 12);
		((Control)cboTrntype).Name = "cboTrntype";
		((Control)cboTrntype).Size = new Size(86, 22);
		((Control)cboTrntype).TabIndex = 1174;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(738, 13);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(72, 20);
		((Control)Label5).TabIndex = 1175;
		Label5.Text = "Tran type";
		Label5.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)cboTrntype);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)cboBookType);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboSlType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)BtnGroup);
		((Control)this).Controls.Add((Control)(object)BtnMothSl);
		((Control)this).Controls.Add((Control)(object)BtnItem);
		((Control)this).Controls.Add((Control)(object)BtnEmpSl);
		((Control)this).Controls.Add((Control)(object)BtnSize);
		((Control)this).Controls.Add((Control)(object)BtnExpType);
		((Control)this).Controls.Add((Control)(object)BtnKrSl);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_GRAPH";
		((Form)this).Text = "Stock Report";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		ColorConverter colorConverter = default(ColorConverter);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (Operators.CompareString(UserPrint, "Y", false) != 0)
					{
						goto IL_001e;
					}
					goto IL_0034;
				case 1085:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
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
							goto IL_0113;
						case 13:
							goto IL_0166;
						case 14:
							goto IL_01bb;
						case 15:
							goto IL_0213;
						case 16:
							goto IL_0281;
						case 17:
							goto IL_02c4;
						case 18:
							goto IL_02f3;
						case 19:
							goto IL_0336;
						case 20:
							goto IL_0377;
						case 21:
							goto IL_0398;
						case 22:
							goto IL_03a6;
						case 23:
							goto IL_03ac;
						case 24:
							goto IL_03b2;
						case 25:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 3:
						case 26:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_03a6:
					num2 = 22;
					obj = null;
					goto IL_03ac;
					IL_03ac:
					num2 = 23;
					obj2 = null;
					goto IL_03b2;
					IL_0398:
					num2 = 21;
					Cursor.Current = Cursors.Default;
					goto IL_03a6;
					IL_03b2:
					num2 = 24;
					obj3 = null;
					break;
					IL_001e:
					num2 = 2;
					Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
					goto end_IL_0001_3;
					IL_0034:
					num2 = 5;
					obj3 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
					goto IL_004b;
					IL_004b:
					num2 = 6;
					obj2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj3, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
					goto IL_007d;
					IL_007d:
					num2 = 7;
					obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
					goto IL_00a5;
					IL_00a5:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_00ae;
					IL_00ae:
					num2 = 9;
					obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
					goto IL_00d6;
					IL_00d6:
					num2 = 10;
					NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
					goto IL_0109;
					IL_0109:
					num2 = 11;
					colorConverter = new ColorConverter();
					goto IL_0113;
					IL_0113:
					num2 = 12;
					NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
					goto IL_0166;
					IL_0166:
					num2 = 13;
					NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
					goto IL_01bb;
					IL_01bb:
					num2 = 14;
					NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
					goto IL_0213;
					IL_0213:
					num2 = 15;
					NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
					goto IL_0281;
					IL_0281:
					num2 = 16;
					NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
					goto IL_02c4;
					IL_02c4:
					num2 = 17;
					NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
					goto IL_02f3;
					IL_02f3:
					num2 = 18;
					NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
					goto IL_0336;
					IL_0336:
					num2 = 19;
					NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
					goto IL_0377;
					IL_0377:
					num2 = 20;
					NewLateBinding.LateSet(obj3, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
					goto IL_0398;
					end_IL_0001_2:
					break;
				}
				num2 = 25;
				GC.Collect();
				break;
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1085;
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

	private void RP_GRAPH_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Expected O, but got Unknown
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		//IL_0951: Expected O, but got Unknown
		//IL_0a01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
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
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				ComboBox obj4 = cboItemTyp;
				object? obj5 = colorConverter.ConvertFromString("243, 240, 239");
				obj4.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				ComboBox obj6 = cboSlType;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				obj6.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panel = Panel1;
				object? obj9 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				ComboBox obj10 = cboItemTyp;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				obj10.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				ComboBox obj12 = cboSlType;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				obj12.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj14 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				Panel panel2 = Panel1;
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
				cboSlType.BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
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
			}
			cboItemTyp.Items.Add((object)"");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 1;
			}
			else
			{
				cboItemTyp.SelectedIndex = 2;
			}
			cboSlType.Items.Add((object)"Amount");
			cboSlType.Items.Add((object)"Weight");
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				cboSlType.SelectedIndex = 1;
			}
			else
			{
				cboSlType.SelectedIndex = 0;
			}
			cboBookType.Items.Add((object)"");
			cboBookType.Items.Add((object)"Retail");
			cboBookType.Items.Add((object)"WhSale");
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				cboBookType.SelectedIndex = 2;
			}
			else
			{
				cboBookType.SelectedIndex = 1;
			}
			cboTrntype.Items.Add((object)"");
			cboTrntype.Items.Add((object)"Sales");
			cboTrntype.Items.Add((object)"Return");
			cboTrntype.SelectedIndex = 0;
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
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
			cboItemTyp.SelectedIndex = 1;
		}
		else
		{
			cboItemTyp.SelectedIndex = 2;
		}
		BtnExit.Text = "&Exit";
	}

	private void RP_GRAPH_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_GRAPH_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_GRAPH_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_GRAPH_Activated(object sender, EventArgs e)
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

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BarChartShow()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		ChartControl val = default(ChartControl);
		StackedBarTotalLabel stackedBarTotalLabel = default(StackedBarTotalLabel);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 1439:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_001e;
						case 4:
							goto IL_0026;
						case 5:
							goto IL_0035;
						case 6:
							goto IL_0053;
						case 7:
							goto IL_0061;
						case 8:
							goto IL_0074;
						case 9:
							goto IL_0095;
						case 10:
							goto IL_00a9;
						case 11:
							goto IL_00b9;
						case 12:
							goto IL_00d3;
						case 13:
							goto IL_0105;
						case 14:
							goto IL_0111;
						case 16:
							goto IL_0121;
						case 17:
							goto IL_012d;
						case 15:
						case 18:
						case 19:
							goto IL_013a;
						case 20:
							goto IL_0157;
						case 21:
							goto IL_016e;
						case 23:
							goto IL_0182;
						case 26:
							goto IL_0199;
						case 27:
							goto IL_01b6;
						case 28:
							goto IL_01cd;
						case 30:
							goto IL_01e1;
						case 33:
							goto IL_01f8;
						case 34:
							goto IL_0215;
						case 35:
							goto IL_022c;
						case 37:
							goto IL_0240;
						case 40:
							goto IL_0257;
						case 41:
							goto IL_0274;
						case 42:
							goto IL_028b;
						case 44:
							goto IL_029f;
						case 47:
							goto IL_02b6;
						case 48:
							goto IL_02d3;
						case 50:
							goto IL_02e6;
						case 51:
							goto IL_0303;
						case 52:
							goto IL_031a;
						case 54:
							goto IL_032e;
						case 22:
						case 24:
						case 25:
						case 29:
						case 31:
						case 32:
						case 36:
						case 38:
						case 39:
						case 43:
						case 45:
						case 46:
						case 49:
						case 53:
						case 55:
						case 56:
						case 57:
							goto IL_0340;
						case 58:
							goto IL_035a;
						case 59:
							goto IL_0383;
						case 60:
							goto IL_03a2;
						case 61:
							goto IL_03cf;
						case 62:
							goto IL_03fc;
						case 63:
							goto IL_041a;
						case 64:
						case 65:
							goto IL_0439;
						case 66:
							goto IL_0444;
						case 68:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 67:
						case 69:
						case 70:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_041a:
					num2 = 63;
					if (Operators.CompareString(RptType, "PrSl", false) != 0)
					{
					}
					goto IL_0439;
					IL_0439:
					num2 = 65;
					((Control)val).Dock = (DockStyle)5;
					goto IL_0444;
					IL_03fc:
					num2 = 62;
					val.Legend.Font = new Font("Segoe UI", 10f);
					goto IL_041a;
					IL_0444:
					num2 = 66;
					((Control)Panel1).Controls.Add((Control)(object)val);
					goto end_IL_0001_3;
					IL_000b:
					num2 = 2;
					((Control)Panel1).Controls.Clear();
					goto IL_001e;
					IL_001e:
					num2 = 3;
					val = new ChartControl();
					goto IL_0026;
					IL_0026:
					num2 = 4;
					val.DataSource = RsStkSum;
					goto IL_0035;
					IL_0035:
					num2 = 5;
					if (RsStkSum.Rows.Count <= 0)
					{
						break;
					}
					goto IL_0053;
					IL_0053:
					num2 = 6;
					val.SeriesDataMember = "TotAmt";
					goto IL_0061;
					IL_0061:
					num2 = 7;
					((SeriesBase)val.SeriesTemplate).ArgumentDataMember = "Name";
					goto IL_0074;
					IL_0074:
					num2 = 8;
					((SeriesBase)val.SeriesTemplate).ValueDataMembers.AddRange(new string[1] { "Value" });
					goto IL_0095;
					IL_0095:
					num2 = 9;
					((SeriesBase)val.SeriesTemplate).View = (SeriesViewBase)new StackedBarSeriesView();
					goto IL_00a9;
					IL_00a9:
					num2 = 10;
					val.Legend.Visibility = (DefaultBoolean)1;
					goto IL_00b9;
					IL_00b9:
					num2 = 11;
					stackedBarTotalLabel = ((XYDiagramPaneBase)((XYDiagram2D)(XYDiagram)val.Diagram).DefaultPane).StackedBarTotalLabel;
					goto IL_00d3;
					IL_00d3:
					num2 = 12;
					if ((Operators.CompareString(RptType, "Exp", false) == 0) | (Operators.CompareString(RptType, "KrSl", false) == 0))
					{
						goto IL_0105;
					}
					goto IL_0121;
					IL_0105:
					num2 = 13;
					((TotalLabel)stackedBarTotalLabel).Visible = false;
					goto IL_0111;
					IL_0111:
					num2 = 14;
					stackedBarTotalLabel.ShowConnector = false;
					goto IL_013a;
					IL_0121:
					num2 = 16;
					((TotalLabel)stackedBarTotalLabel).Visible = true;
					goto IL_012d;
					IL_012d:
					num2 = 17;
					stackedBarTotalLabel.ShowConnector = true;
					goto IL_013a;
					IL_013a:
					num2 = 19;
					if (Operators.CompareString(RptType, "PrSl", false) == 0)
					{
						goto IL_0157;
					}
					goto IL_0199;
					IL_0157:
					num2 = 20;
					if (cboSlType.SelectedIndex == 0)
					{
						goto IL_016e;
					}
					goto IL_0182;
					IL_016e:
					num2 = 21;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Amt : {V:F0}";
					goto IL_0340;
					IL_0182:
					num2 = 23;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Nwt : {V:F2}";
					goto IL_0340;
					IL_0199:
					num2 = 26;
					if (Operators.CompareString(RptType, "MonthSl", false) == 0)
					{
						goto IL_01b6;
					}
					goto IL_01f8;
					IL_01b6:
					num2 = 27;
					if (cboSlType.SelectedIndex == 0)
					{
						goto IL_01cd;
					}
					goto IL_01e1;
					IL_01cd:
					num2 = 28;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Amt : {V:F0}";
					goto IL_0340;
					IL_01e1:
					num2 = 30;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Nwt : {V:F2}";
					goto IL_0340;
					IL_01f8:
					num2 = 33;
					if (Operators.CompareString(RptType, "DaySl", false) == 0)
					{
						goto IL_0215;
					}
					goto IL_0257;
					IL_0215:
					num2 = 34;
					if (cboSlType.SelectedIndex == 0)
					{
						goto IL_022c;
					}
					goto IL_0240;
					IL_022c:
					num2 = 35;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Amt : {V:F0}";
					goto IL_0340;
					IL_0240:
					num2 = 37;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Nwt : {V:F2}";
					goto IL_0340;
					IL_0257:
					num2 = 40;
					if (Operators.CompareString(RptType, "EmpSl", false) == 0)
					{
						goto IL_0274;
					}
					goto IL_02b6;
					IL_0274:
					num2 = 41;
					if (cboSlType.SelectedIndex == 0)
					{
						goto IL_028b;
					}
					goto IL_029f;
					IL_028b:
					num2 = 42;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Amt : {V:F0}";
					goto IL_0340;
					IL_029f:
					num2 = 44;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Nwt : {V:F2}";
					goto IL_0340;
					IL_02b6:
					num2 = 47;
					if (Operators.CompareString(RptType, "Exp", false) == 0)
					{
						goto IL_02d3;
					}
					goto IL_02e6;
					IL_02d3:
					num2 = 48;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Amt : {V:F0}";
					goto IL_0340;
					IL_02e6:
					num2 = 50;
					if (Operators.CompareString(RptType, "KrSl", false) == 0)
					{
						goto IL_0303;
					}
					goto IL_0340;
					IL_0303:
					num2 = 51;
					if (cboSlType.SelectedIndex == 0)
					{
						goto IL_031a;
					}
					goto IL_032e;
					IL_031a:
					num2 = 52;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Amt : {V:F0}";
					goto IL_0340;
					IL_032e:
					num2 = 54;
					((TotalLabel)stackedBarTotalLabel).TextPattern = "Gwt : {V:F2}";
					goto IL_0340;
					IL_0340:
					num2 = 57;
					((TotalLabel)stackedBarTotalLabel).Font = new Font("Segoe UI", 8f);
					goto IL_035a;
					IL_035a:
					num2 = 58;
					((SeriesBase)val.Series[0]).Label.Font = new Font("Segoe UI", 10f);
					goto IL_0383;
					IL_0383:
					num2 = 59;
					((AxisLabel)((Axis2D)((XYDiagram)val.Diagram).AxisX).Label).Angle = 0;
					goto IL_03a2;
					IL_03a2:
					num2 = 60;
					((TitleBase)((Axis2D)((XYDiagram)val.Diagram).AxisX).Label).Font = new Font("Segoe UI", 8f);
					goto IL_03cf;
					IL_03cf:
					num2 = 61;
					((TitleBase)((Axis2D)((XYDiagram)val.Diagram).AxisY).Label).Font = new Font("Segoe UI", 8f);
					goto IL_03fc;
					end_IL_0001_2:
					break;
				}
				num2 = 68;
				Interaction.MsgBox((object)"No Data Found", (MsgBoxStyle)0, (object)"DataCare");
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1439;
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

	private void BtnGroup_Click(object sender, EventArgs e)
	{
		string text = ((cboBookType.SelectedIndex == 1) ? "'SALES','E INVOICE','SALES RETURNE'" : ((cboBookType.SelectedIndex != 2) ? "'SALES','E INVOICE','SALES RETURNE','WH SALES'" : "'WH SALES'"));
		string text2 = ((cboSlType.SelectedIndex != 1) ? "A.NET_AMT" : "A.ITM_NWT");
		if (cboTrntype.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_DATE As Name,SUM(IIF(A.ITM_SIGN = '-'," + text2 + ",-" + text2 + ")) As Value,SUM(IIF(A.ITM_SIGN = '-'," + text2 + ",-" + text2 + ")) As TotAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-30.0), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY A.VCH_DATE ORDER BY A.VCH_DATE";
		}
		else if (cboTrntype.SelectedIndex == 1)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_DATE As Name,SUM(" + text2 + ") As Value,SUM(" + text2 + ") As TotAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND B.MAIN_BOOK IN ("), (object)text), (object)") "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-30.0), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY A.VCH_DATE ORDER BY A.VCH_DATE";
		}
		else if (cboTrntype.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_DATE As Name,SUM(" + text2 + ") As Value,SUM(" + text2 + ") As TotAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND B.MAIN_BOOK IN ("), (object)text), (object)") "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-30.0), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY A.VCH_DATE ORDER BY A.VCH_DATE";
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		RptType = "DaySl";
		BarChartShow();
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
	}

	private void BtnMothSl_Click(object sender, EventArgs e)
	{
		string text = ((cboBookType.SelectedIndex == 1) ? "'SALES','E INVOICE','SALES RETURNE'" : ((cboBookType.SelectedIndex != 2) ? "'SALES','E INVOICE','SALES RETURNE','WH SALES'" : "'WH SALES'"));
		string text2 = ((cboSlType.SelectedIndex != 1) ? "A.NET_AMT" : "A.ITM_NWT");
		if (cboTrntype.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MONTH(A.VCH_DATE) As Code,CONVERT(varchar(3), A.VCH_DATE, 100) As Name,SUM(IIF(A.ITM_SIGN = '-'," + text2 + ",-" + text2 + ")) As Value,SUM(IIF(A.ITM_SIGN = '-'," + text2 + ",-" + text2 + ")) As TotAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100) ORDER BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100)";
		}
		else if (cboTrntype.SelectedIndex == 1)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MONTH(A.VCH_DATE) As Code,CONVERT(varchar(3), A.VCH_DATE, 100) As Name,SUM(" + text2 + ") As Value,SUM(" + text2 + ") As TotAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND B.MAIN_BOOK IN ("), (object)text), (object)") "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100) ORDER BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100)";
		}
		else if (cboTrntype.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MONTH(A.VCH_DATE) As Code,CONVERT(varchar(3), A.VCH_DATE, 100) As Name,SUM(" + text2 + ") As Value,SUM(" + text2 + ") As TotAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND B.MAIN_BOOK IN ("), (object)text), (object)") "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100) ORDER BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100)";
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		RptType = "MonthSl";
		BarChartShow();
	}

	private void BtnItem_Click(object sender, EventArgs e)
	{
		string text = ((cboBookType.SelectedIndex == 1) ? "'SALES','E INVOICE','SALES RETURNE'" : ((cboBookType.SelectedIndex != 2) ? "'SALES','E INVOICE','SALES RETURNE','WH SALES'" : "'WH SALES'"));
		if (cboSlType.SelectedIndex == 0)
		{
			if (cboTrntype.SelectedIndex == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Name,Sum(IIF(A.ITM_SIGN = '-',A.NET_AMT,-A.NET_AMT)) As Value,SUM(IIF(A.ITM_SIGN = '-',A.NET_AMT,-A.NET_AMT)) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY D.PR_CODE ORDER BY D.PR_CODE "));
			}
			else if (cboTrntype.SelectedIndex == 1)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Name,Sum(A.NET_AMT) As Value,SUM(A.NET_AMT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '-' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY D.PR_CODE ORDER BY D.PR_CODE "));
			}
			else if (cboTrntype.SelectedIndex == 2)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Name,Sum(A.NET_AMT) As Value,SUM(A.NET_AMT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '+' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY D.PR_CODE ORDER BY D.PR_CODE "));
			}
		}
		else if (cboTrntype.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Name,Sum(IIF(A.ITM_SIGN = '-',A.ITM_NWT,-A.ITM_NWT)) As Value,SUM(IIF(A.ITM_SIGN = '-',A.NET_AMT,-A.NET_AMT)) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY D.PR_CODE ORDER BY D.PR_CODE "));
		}
		else if (cboTrntype.SelectedIndex == 1)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Name,Sum(A.ITM_NWT) As Value,SUM(A.ITM_NWT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '-' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY D.PR_CODE ORDER BY D.PR_CODE "));
		}
		else if (cboTrntype.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Name,Sum(A.ITM_NWT) As Value,SUM(A.ITM_NWT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '+' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY D.PR_CODE ORDER BY D.PR_CODE "));
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		RptType = "PrSl";
		BarChartShow();
	}

	private void BtnEmpSl_Click(object sender, EventArgs e)
	{
		string text = ((cboBookType.SelectedIndex == 1) ? "'SALES','E INVOICE','SALES RETURNE'" : ((cboBookType.SelectedIndex != 2) ? "'SALES','E INVOICE','SALES RETURNE','WH SALES'" : "'WH SALES'"));
		if (cboSlType.SelectedIndex == 0)
		{
			if (cboTrntype.SelectedIndex == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Name,Sum(IIF(A.ITM_SIGN = '-',A.NET_AMT,-A.NET_AMT)) As Value,SUM(IIF(A.ITM_SIGN = '-',A.NET_AMT,-A.NET_AMT)) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY A.EMP_CODE ORDER BY A.EMP_CODE "));
			}
			else if (cboTrntype.SelectedIndex == 1)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Name,Sum(A.NET_AMT) As Value,SUM(A.NET_AMT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '-' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY A.EMP_CODE ORDER BY A.EMP_CODE "));
			}
			else if (cboTrntype.SelectedIndex == 2)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Name,Sum(A.NET_AMT) As Value,SUM(A.NET_AMT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '+' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY A.EMP_CODE ORDER BY A.EMP_CODE "));
			}
		}
		else if (cboTrntype.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Name,Sum(IIF(A.ITM_SIGN = '-',A.ITM_NWT,-A.ITM_NWT)) As Value,SUM(IIF(A.ITM_SIGN = '-',A.NET_AMT,-A.NET_AMT)) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY A.EMP_CODE ORDER BY A.EMP_CODE "));
		}
		else if (cboTrntype.SelectedIndex == 1)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Name,Sum(A.ITM_NWT) As Value,SUM(A.ITM_NWT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '-' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY A.EMP_CODE ORDER BY A.EMP_CODE "));
		}
		else if (cboTrntype.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Name,Sum(A.ITM_NWT) As Value,SUM(A.ITM_NWT) As TotAmt from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND B.MAIN_BOOK IN ("), (object)text), (object)") AND A.ITM_SIGN = '+' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY A.EMP_CODE ORDER BY A.EMP_CODE "));
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		RptType = "EmpSl";
		BarChartShow();
	}

	private void BtnSize_Click(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select DATEPART(Month, A.VCH_DATE) As Name,SUM(A.DR_AMT) As Value,DATEPART(Day, A.VCH_DATE) AS TotAmt\r\n        FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE \r\n        WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'  AND B.AC_GR IN( '45','46','47') \r\n        GROUP BY DATEPART(Month, A.VCH_DATE),DATEPART(Day, A.VCH_DATE) HAVING SUM(A.DR_AMT) > 0 ORDER BY DATEPART(Day, A.VCH_DATE) "));
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		RptType = "Exp";
		BarChartShow();
	}

	private void BtnExpType_Click(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select DATEPART(Month, A.VCH_DATE) As Name,SUM(A.DR_AMT) As Value,B.AC_NAME AS TotAmt\r\n        FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE \r\n        WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'  AND B.AC_GR IN( '45','46','47') \r\n        GROUP BY DATEPART(Month, A.VCH_DATE),B.AC_NAME HAVING SUM(A.DR_AMT) > 0 ORDER BY DATEPART(Month, A.VCH_DATE),B.AC_NAME "));
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		RptType = "Exp";
		BarChartShow();
	}

	private void BtnKrSl_Click(object sender, EventArgs e)
	{
		if (cboSlType.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.KR_NAME As Name,Sum(A.NET_AMT) As Value,D.IT_NAME As TotAmt from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY B.KR_NAME,D.IT_NAME ORDER BY B.KR_NAME,D.IT_NAME"));
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.KR_NAME As Name,Sum(A.ITM_NWT) As Value,D.IT_NAME As TotAmt from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND D.GR_CODE = '" + tGrCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND D.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"' GROUP BY B.KR_NAME,D.IT_NAME ORDER BY B.KR_NAME,D.IT_NAME"));
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		RptType = "KrSl";
		BarChartShow();
	}
}
