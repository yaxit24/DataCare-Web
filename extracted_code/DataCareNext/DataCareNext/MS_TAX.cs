using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxMSFlexGridLib;
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
public class MS_TAX : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTaxCode")]
	private TextBox _tTaxCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTaxName")]
	private TextBox _tTaxName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTaxPrc")]
	private TextBox _nTaxPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTaxAcCode")]
	private TextBox _tTaxAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAddTaxPrc")]
	private TextBox _nAddTaxPrc;

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
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tInputTax")]
	private TextBox _tInputTax;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private bool MsgClear;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cTaxGroup = 1;

	private const int cTaxTypeName = 2;

	private const int cTaxAc = 3;

	private const int cTaxPrc = 4;

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
			CancelEventHandler cancelEventHandler = tTaxCode_Validating;
			TextBox val2 = _tTaxCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tTaxCode = value;
			val2 = _tTaxCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
			}
		}
	}

	internal virtual TextBox tTaxName
	{
		[CompilerGenerated]
		get
		{
			return _tTaxName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTaxName_KeyDown);
			CancelEventHandler cancelEventHandler = tTaxName_Validating;
			TextBox val2 = _tTaxName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tTaxName = value;
			val2 = _tTaxName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
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

	public virtual TextBox Text1
	{
		[CompilerGenerated]
		get
		{
			return _Text1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
			}
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
			KeyEventHandler val = new KeyEventHandler(MSG_KeyDown);
			EventHandler eventHandler = MSG_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
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

	internal virtual TextBox nTaxPrc
	{
		[CompilerGenerated]
		get
		{
			return _nTaxPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nTaxPrc_KeyDown);
			TextBox val2 = _nTaxPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nTaxPrc = value;
			val2 = _nTaxPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTaxAcName")]
	private virtual TextBox _tTaxAcName;

	internal virtual TextBox tTaxAcName
	{
		get
		{
			return _tTaxAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTaxAcName = value;
		}
	}

	internal virtual TextBox tTaxAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tTaxAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTaxAcCode_KeyDown);
			TextBox val2 = _tTaxAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTaxAcCode = value;
			val2 = _tTaxAcCode;
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

	internal virtual TextBox nAddTaxPrc
	{
		[CompilerGenerated]
		get
		{
			return _nAddTaxPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAddTaxPrc_KeyDown);
			TextBox val2 = _nAddTaxPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAddTaxPrc = value;
			val2 = _nAddTaxPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

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

	internal virtual AxMSFlexGrid MSG
	{
		[CompilerGenerated]
		get
		{
			return _MSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_EnterCell;
			EventHandler eventHandler2 = MSG_LeaveCell;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.EnterCell -= eventHandler;
				val.LeaveCell -= eventHandler2;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.EnterCell += eventHandler;
				val.LeaveCell += eventHandler2;
			}
		}
	}

	internal virtual TextBox TEXT_ENTRY
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblInputTaxName")]
	private virtual TextBox _LblInputTaxName;

	internal virtual TextBox LblInputTaxName
	{
		get
		{
			return _LblInputTaxName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblInputTaxName = value;
		}
	}

	internal virtual TextBox tInputTax
	{
		[CompilerGenerated]
		get
		{
			return _tInputTax;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tInputTax_KeyDown);
			TextBox val2 = _tInputTax;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tInputTax = value;
			val2 = _tInputTax;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	public MS_TAX()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_TAX_Load;
		((Form)this).Activated += MS_TAX_Activated;
		((Form)this).Deactivate += MS_TAX_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_TAX_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_TAX_KeyDown);
		((Form)this).Closed += MS_TAX_Closed;
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
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Expected O, but got Unknown
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Expected O, but got Unknown
		//IL_085f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Expected O, but got Unknown
		//IL_08cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Expected O, but got Unknown
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_094f: Expected O, but got Unknown
		//IL_0a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2a: Expected O, but got Unknown
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b17: Expected O, but got Unknown
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b84: Expected O, but got Unknown
		//IL_0bf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfd: Expected O, but got Unknown
		//IL_0c60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6a: Expected O, but got Unknown
		//IL_0cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d01: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_TAX));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		tTaxCode = new TextBox();
		tTaxName = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Text1 = new TextBox();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		Label3 = new Label();
		nTaxPrc = new TextBox();
		Label4 = new Label();
		tTaxAcName = new TextBox();
		tTaxAcCode = new TextBox();
		Label5 = new Label();
		nAddTaxPrc = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		MSG = new AxMSFlexGrid();
		TEXT_ENTRY = new TextBox();
		LblInputTaxName = new TextBox();
		tInputTax = new TextBox();
		Label6 = new Label();
		((ISupportInitialize)DGV).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		((TextBoxBase)tTaxCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tTaxCode, "tTaxCode");
		((Control)tTaxCode).Name = "tTaxCode";
		((TextBoxBase)tTaxName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tTaxName, "tTaxName");
		((Control)tTaxName).Name = "tTaxName";
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
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
		componentResourceManager.ApplyResources(DGV, "DGV");
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
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DGV).StandardTab = true;
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		((TextBoxBase)nTaxPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nTaxPrc, "nTaxPrc");
		((Control)nTaxPrc).Name = "nTaxPrc";
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		((TextBoxBase)tTaxAcName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tTaxAcName, "tTaxAcName");
		((Control)tTaxAcName).Name = "tTaxAcName";
		((TextBoxBase)tTaxAcCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tTaxAcCode, "tTaxAcCode");
		((Control)tTaxAcCode).Name = "tTaxAcCode";
		componentResourceManager.ApplyResources(Label5, "Label5");
		((Control)Label5).ForeColor = Color.Black;
		((Control)Label5).Name = "Label5";
		((TextBoxBase)nAddTaxPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nAddTaxPrc, "nAddTaxPrc");
		((Control)nAddTaxPrc).Name = "nAddTaxPrc";
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
		((BaseStyleControl)BtnExit).Appearance.Font = (Font)componentResourceManager.GetObject("BtnExit.Appearance.Font");
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnExit, "BtnExit");
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = (Font)componentResourceManager.GetObject("BtnDelete.Appearance.Font");
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		componentResourceManager.ApplyResources(BtnDelete, "BtnDelete");
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = (Font)componentResourceManager.GetObject("BtnCancel.Appearance.Font");
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = (Font)componentResourceManager.GetObject("BtnSave.Appearance.Font");
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnSave, "BtnSave");
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = (Font)componentResourceManager.GetObject("BtnPrint.Appearance.Font");
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnPrint, "BtnPrint");
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		componentResourceManager.ApplyResources(MSG, "MSG");
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		componentResourceManager.ApplyResources(TEXT_ENTRY, "TEXT_ENTRY");
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((TextBoxBase)LblInputTaxName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(LblInputTaxName, "LblInputTaxName");
		((Control)LblInputTaxName).Name = "LblInputTaxName";
		((TextBoxBase)tInputTax).BackColor = Color.White;
		componentResourceManager.ApplyResources(tInputTax, "tInputTax");
		((Control)tInputTax).Name = "tInputTax";
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)tInputTax);
		((Control)this).Controls.Add((Control)(object)LblInputTaxName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)nAddTaxPrc);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tTaxAcName);
		((Control)this).Controls.Add((Control)(object)tTaxAcCode);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)nTaxPrc);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tTaxCode);
		((Control)this).Controls.Add((Control)(object)tTaxName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_TAX";
		((ISupportInitialize)DGV).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 5;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1500.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "Tax Type";
			mSG[2] = (int)Math.Round(2800.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Tax Name";
			mSG[3] = (int)Math.Round(1300.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Ac Code";
			mSG[4] = (int)Math.Round(1100.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "Tax %";
			mSG.Row = 1;
			mSG.Col = 0;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG[1, 0] = Conversions.ToString(1);
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (!MsgClear && !((mSG.Row == 0) | (mSG.CellWidth <= 0)))
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				if (((Control)TEXT_ENTRY).Visible)
				{
					((Control)TEXT_ENTRY).Focus();
				}
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
				Application.DoEvents();
				switch (MSG.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
					TEXT_ENTRY.Text = Strings.Format((object)mSG[mSG.Row, mSG.Col], "0.000");
					break;
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClear && MSG.Row != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)TEXT_ENTRY.Text, "0.000");
				break;
			}
			((Control)TEXT_ENTRY).Visible = false;
			mSG = null;
		}
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG.Col > 1)
					{
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						mSG.Row += 1;
					}
					return;
				}
			}
			else
			{
				if (mSG.Col == 3)
				{
					DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL  FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.AC_NAME";
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[4];
						DC_Main.ColWidth[0] = 400.0;
						DC_Main.ColWidth[1] = 100.0;
						DC_Main.ColWidth[2] = 350.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose)
						{
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[1];
								mSG[mSG.Row, 3] = DC_Main.ColValue[1];
							}
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					}
				}
				if (mSG.Col == 4)
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							((Control)BtnSave).Enabled = true;
							((Control)BtnSave).Focus();
							MSG_LeaveCell(MSG, new EventArgs());
						}
						else
						{
							MSG[mSG.Row, mSG.Col] = Strings.Format((object)TEXT_ENTRY.Text, "0.000");
							mSG.Rows += 1;
							mSG.Row = mSG.Rows - 1;
							mSG[mSG.Row, 0] = Conversions.ToString(mSG.Row);
							mSG.Col = 1;
						}
					}
					else
					{
						MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						MsgClear = true;
						mSG.Row += 1;
						MsgClear = false;
						mSG.Col = 1;
						MSG_EnterCell(MSG, new EventArgs());
						((Control)TEXT_ENTRY).Visible = true;
						((Control)TEXT_ENTRY).Focus();
					}
					return;
				}
				MSG.Col += 1;
				((Control)TEXT_ENTRY).Visible = true;
				((Control)TEXT_ENTRY).Focus();
			}
			mSG = null;
		}
	}

	private void MS_TAX_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0981: Unknown result type (might be due to invalid IL or missing references)
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_0990: Expected O, but got Unknown
		//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09de: Expected O, but got Unknown
		//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a61: Expected O, but got Unknown
		//IL_0a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8f: Expected O, but got Unknown
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abd: Expected O, but got Unknown
		//IL_0b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Expected O, but got Unknown
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfb: Expected O, but got Unknown
		//IL_0c83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c92: Expected O, but got Unknown
		//IL_0d04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0f: Expected O, but got Unknown
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
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj8 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj9 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj10 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj10 != null) ? ((Color)obj10) : default(Color));
				TextBox obj11 = tTaxAcName;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj11).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj13 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj14 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj16 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj17 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj18 != null) ? ((Color)obj18) : default(Color));
				TextBox obj19 = tTaxAcName;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj19).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj21 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj22 = lblBook;
				object? obj23 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj22).ForeColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj24 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj25 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj26 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj28 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj29 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
				((TextBoxBase)tTaxAcName).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)tTaxCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tTaxCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
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
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK195NEPH", false) == 0)
			{
				((Control)Label6).Visible = true;
				((Control)tInputTax).Visible = true;
				((Control)LblInputTaxName).Visible = true;
				DC_Main.RsQry = "UPDATE AC_MAST SET AC_NAME = 'VAT INPUT A/C' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '00085'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE AC_MAST SET AC_NAME = 'VAT OUTPUT A/C' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '00014'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			CLEAR_DATA();
			CurActCtrl = (Control)(object)tTaxCode;
		}
	}

	private void MS_TAX_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsMast);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).MultiSelect = false;
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV).ColumnCount = 2;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "TAX_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "TAX_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
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
		}
		MainUser = DC_Main.MCo_User;
		DGV_CLEAR();
		MSG_CLEAR();
		((Control)TEXT_ENTRY).Visible = false;
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tTaxCode).MaxLength = 2;
		DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SR_NO = 0 ORDER BY TAX_CODE ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
		EntryMode = "A";
		((TextBoxBase)tTaxCode).ReadOnly = false;
		((Control)tTaxCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " TAX_CODE = '" + tTaxCode.Text + "'";
		checked
		{
			if (dataView.Count > 0)
			{
				DataView dataView2 = dataView;
				tTaxCode.Text = Conversions.ToString(dataView2[0]["TAX_CODE"]);
				tTaxName.Text = Conversions.ToString(dataView2[0]["TAX_NAME"]);
				nTaxPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["TAX_PRC"]), "0.00");
				nAddTaxPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["ADD_TAX_PRC"]), "0.00");
				tTaxAcCode.Text = Conversions.ToString(dataView2[0]["TAX_AC"]);
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tTaxAcCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				tTaxAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				tInputTax.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["INPUT_TAX_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tInputTax.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					LblInputTaxName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				}
				dataView2 = null;
				MSG_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM TAX_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.TAX_AC = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAX_CODE = '" + tTaxCode.Text + "'  AND A.SR_NO <> 0  ORDER BY A.SR_NO ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"]);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAX_GROUP"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAX_NAME"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAX_AC"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num = DC_Main.i + 1;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.i])["TAX_PRC"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num, 4] = Strings.Format((object)num2, "0.000");
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG = null;
				EntryMode = "E";
				((TextBoxBase)tTaxCode).ReadOnly = true;
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void MS_TAX_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_TAX_KeyPress(object sender, KeyPressEventArgs e)
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

	private void tTaxCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13 && Operators.CompareString(tTaxCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tTaxCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " TAX_CODE = '" + tTaxCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["TAX_NAME"], (object)tTaxName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Tax Code already Exist in  '", dataView[0]["TAX_NAME"]), (object)"'  Tax Name...Please Change Tax Code..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tTaxCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tTaxName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tTaxName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Tax Name ...", (MsgBoxStyle)0, (object)null);
				((Control)tTaxName).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void tTaxName_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " TAX_NAME = '" + tTaxName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["TAX_CODE"], (object)tTaxCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Tax Name already Exist in  '", dataView[0]["TAX_CODE"]), (object)"'  Tax Code...Please Change Tax Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tTaxName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_FILL();
		}
		else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = "TAX_NAME Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 80;
				((DataGridView)DGV).Columns[0].DataPropertyName = "TAX_CODE";
				((DataGridView)DGV).Columns[1].Width = 320;
				((DataGridView)DGV).Columns[1].DataPropertyName = "TAX_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_TAX_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
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
					{
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						if (Operators.CompareString(tTaxCode.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Enter Tax Code.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							((Control)tTaxCode).Focus();
							goto end_IL_0001;
						}
						if (Operators.CompareString(tTaxName.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Enter Tax Name.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							((Control)tTaxName).Focus();
							goto end_IL_0001;
						}
						DC_Main.RsQry = "DELETE FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + tTaxCode.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "SELECT * FROM TAX_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + tTaxCode.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = DC_Main.Rshlp.NewRow();
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["SR_NO"] = 0;
						dataRow["TAX_CODE"] = tTaxCode.Text;
						dataRow["TAX_NAME"] = tTaxName.Text;
						dataRow["TAX_GROUP"] = "N";
						dataRow["TAX_PRC"] = nTaxPrc.Text;
						dataRow["ADD_TAX_PRC"] = nAddTaxPrc.Text;
						dataRow["TAX_AC"] = tTaxAcCode.Text;
						dataRow["INPUT_TAX_AC"] = tInputTax.Text;
						DC_Main.Rshlp.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
						DC_Main.Rshlp.Clear();
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							if (Conversion.Val(MSG[DC_Main.i, 4]) != 0.0)
							{
								dataRow["CO_CODE"] = DC_Main.MCo_code;
								dataRow["SR_NO"] = DC_Main.i;
								dataRow["TAX_CODE"] = tTaxCode.Text;
								dataRow["TAX_GROUP"] = MSG[DC_Main.i, 1];
								dataRow["TAX_NAME"] = MSG[DC_Main.i, 2];
								dataRow["TAX_AC"] = MSG[DC_Main.i, 3];
								dataRow["TAX_PRC"] = Conversion.Val(MSG[DC_Main.i, 4]);
								dataRow["ADD_TAX_PRC"] = nAddTaxPrc.Text;
								DC_Main.Rshlp.Rows.Add(dataRow);
								((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
								DC_Main.Rshlp.Clear();
							}
							DC_Main.i++;
						}
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						CLEAR_DATA();
						goto end_IL_0001;
					}
					case 1044:
						num = -1;
						switch (num2)
						{
						case 2:
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1044;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tTaxCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Tax Code For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAX_CODE = '" + tTaxCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
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
		DC_Main.RptName = "TaxMast";
		DC_Main.RptFormula = "{TAX_MAST.CO_CODE}= '" + DC_Main.MCo_code + "' ";
		UT_REPORT uT_REPORT = new UT_REPORT();
		((Control)uT_REPORT).Show();
		((Control)uT_REPORT).Focus();
	}

	private void MSG_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13)
		{
			tTaxCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tTaxName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void MSG_DoubleClick(object sender, EventArgs e)
	{
		tTaxCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tTaxCode).Focus();
	}

	private void nTaxPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nTaxPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nTaxPrc.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nAddTaxPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAddTaxPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAddTaxPrc.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void tTaxAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tTaxAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND (AC_GR = '12' OR  AC_CODE = '00013') ORDER BY AC_NAME";
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
					tTaxAcCode.Text = DC_Main.ColValue[1];
					tTaxAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tTaxAcCode).Focus();
			}
		}
		else
		{
			tTaxAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
		}
	}

	private void MS_TAX_Closed(object sender, EventArgs e)
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

	private void tInputTax_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tInputTax.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND (AC_GR = '12' OR  AC_CODE = '00013') ORDER BY AC_NAME";
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
					tInputTax.Text = DC_Main.ColValue[1];
					LblInputTaxName.Text = DC_Main.ColValue[0];
				}
				((Control)tInputTax).Focus();
			}
		}
		else
		{
			LblInputTaxName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}
}
