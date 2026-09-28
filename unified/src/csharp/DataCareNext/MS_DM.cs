using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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
public class MS_DM : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDmCode")]
	private TextBox _tDmCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDmName")]
	private TextBox _tDmName;

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
	[AccessedThroughProperty("nSlRate")]
	private TextBox _nSlRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCut")]
	private ComboBox _cboCut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboClear")]
	private ComboBox _cboClear;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPrRate")]
	private TextBox _nPrRate;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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

	internal virtual TextBox tDmCode
	{
		[CompilerGenerated]
		get
		{
			return _tDmCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCntrCode_KeyDown);
			CancelEventHandler cancelEventHandler = tGrCode_Validating;
			TextBox val2 = _tDmCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tDmCode = value;
			val2 = _tDmCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
			}
		}
	}

	internal virtual TextBox tDmName
	{
		[CompilerGenerated]
		get
		{
			return _tDmName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			CancelEventHandler cancelEventHandler = tDmName_Validating;
			KeyEventHandler val = new KeyEventHandler(tDmName_KeyDown);
			TextBox val2 = _tDmName;
			if (val2 != null)
			{
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tDmName = value;
			val2 = _tDmName;
			if (val2 != null)
			{
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).KeyDown += val;
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
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			EventHandler eventHandler = DGV_DoubleClick;
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
	[AccessedThroughProperty("Label7")]
	private virtual Label _Label7;

	internal virtual Label Label7
	{
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label7 = value;
		}
	}

	internal virtual TextBox nSlRate
	{
		[CompilerGenerated]
		get
		{
			return _nSlRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSlRate_KeyDown);
			TextBox val2 = _nSlRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSlRate = value;
			val2 = _nSlRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual ComboBox cboCut
	{
		[CompilerGenerated]
		get
		{
			return _cboCut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCut_KeyDown);
			ComboBox val2 = _cboCut;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCut = value;
			val2 = _cboCut;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label14")]
	private virtual Label _Label14;

	internal virtual Label Label14
	{
		get
		{
			return _Label14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label14 = value;
		}
	}

	internal virtual ComboBox cboClear
	{
		[CompilerGenerated]
		get
		{
			return _cboClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboClear_KeyDown);
			ComboBox val2 = _cboClear;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboClear = value;
			val2 = _cboClear;
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
			KeyEventHandler val = new KeyEventHandler(tGTradTyp_KeyDown);
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

	internal virtual TextBox nPrRate
	{
		[CompilerGenerated]
		get
		{
			return _nPrRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPrRate_KeyDown);
			TextBox val2 = _nPrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPrRate = value;
			val2 = _nPrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("tShortName")]
	private virtual TextBox _tShortName;

	internal virtual TextBox tShortName
	{
		get
		{
			return _tShortName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tShortName = value;
		}
	}

	public MS_DM()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_DM_Load;
		((Form)this).Activated += MS_DM_Activated;
		((Form)this).Deactivate += MS_DM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_DM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_DM_KeyDown);
		((Form)this).Closed += MS_DM_Closed;
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
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
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
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected O, but got Unknown
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Expected O, but got Unknown
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Expected O, but got Unknown
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ab: Expected O, but got Unknown
		//IL_0a7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Expected O, but got Unknown
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af3: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_DM));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		tDmCode = new TextBox();
		tDmName = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Text1 = new TextBox();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		Label6 = new Label();
		Label7 = new Label();
		nSlRate = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		cboCut = new ComboBox();
		Label14 = new Label();
		cboClear = new ComboBox();
		Label3 = new Label();
		tGrName = new TextBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		nPrRate = new TextBox();
		Label4 = new Label();
		tShortName = new TextBox();
		((ISupportInitialize)DGV).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		((TextBoxBase)tDmCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tDmCode, "tDmCode");
		((Control)tDmCode).Name = "tDmCode";
		((TextBoxBase)tDmName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tDmName, "tDmName");
		((Control)tDmName).Name = "tDmName";
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
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		componentResourceManager.ApplyResources(Label7, "Label7");
		((Control)Label7).ForeColor = Color.Black;
		((Control)Label7).Name = "Label7";
		((TextBoxBase)nSlRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nSlRate, "nSlRate");
		((Control)nSlRate).Name = "nSlRate";
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
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
		cboCut.AutoCompleteMode = (AutoCompleteMode)3;
		cboCut.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboCut, "cboCut");
		((ListControl)cboCut).FormattingEnabled = true;
		((Control)cboCut).Name = "cboCut";
		componentResourceManager.ApplyResources(Label14, "Label14");
		((Control)Label14).ForeColor = Color.Black;
		((Control)Label14).Name = "Label14";
		cboClear.AutoCompleteMode = (AutoCompleteMode)3;
		cboClear.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboClear, "cboClear");
		((ListControl)cboClear).FormattingEnabled = true;
		((Control)cboClear).Name = "cboClear";
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tGrName, "tGrName");
		((Control)tGrName).Name = "tGrName";
		componentResourceManager.ApplyResources(Label10, "Label10");
		((Control)Label10).ForeColor = Color.Black;
		((Control)Label10).Name = "Label10";
		((TextBoxBase)tGrCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tGrCode, "tGrCode");
		((Control)tGrCode).Name = "tGrCode";
		((TextBoxBase)nPrRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nPrRate, "nPrRate");
		((Control)nPrRate).Name = "nPrRate";
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		((TextBoxBase)tShortName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tShortName, "tShortName");
		((Control)tShortName).Name = "tShortName";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tShortName);
		((Control)this).Controls.Add((Control)(object)nPrRate);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)cboClear);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)cboCut);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)nSlRate);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tDmCode);
		((Control)this).Controls.Add((Control)(object)tDmName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_DM";
		((ISupportInitialize)DGV).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_DM_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f2: Expected O, but got Unknown
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Expected O, but got Unknown
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fd: Expected O, but got Unknown
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0974: Unknown result type (might be due to invalid IL or missing references)
		//IL_097a: Expected O, but got Unknown
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Expected O, but got Unknown
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a69: Expected O, but got Unknown
		//IL_0a88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a97: Expected O, but got Unknown
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
				TextBox obj8 = tGrName;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj11 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				TextBox obj13 = tGrName;
				object? obj14 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj13).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj15 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj16 = lblBook;
				object? obj17 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj16).ForeColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj18 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj19 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				((TextBoxBase)tGrName).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
			}
			CLEAR_DATA();
			EntryMode = "A";
			CurActCtrl = (Control)(object)tDmCode;
		}
	}

	private void MS_DM_Activated(object sender, EventArgs e)
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
				((DataGridView)DGV).Columns[0].DataPropertyName = "DM_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "DM_NAME";
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
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tDmCode).MaxLength = 3;
		((TextBoxBase)tDmCode).ReadOnly = false;
		EntryMode = "A";
		DC_Main.RsQry = "SELECT * FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY DM_CODE ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
		cboCut.Items.Clear();
		cboCut.Items.Add((object)"");
		DC_Main.RsQry = "SELECT DM_SHAPE FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY DM_SHAPE ORDER BY DM_SHAPE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					cboCut.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["DM_SHAPE"], (object)""));
					DC_Main.X++;
				}
			}
			cboCut.SelectedIndex = 0;
			cboClear.Items.Clear();
			cboClear.Items.Add((object)"");
			DC_Main.RsQry = "SELECT DM_CLARITY FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY DM_CLARITY ORDER BY DM_CLARITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num2 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num2)
				{
					cboClear.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["DM_CLARITY"], (object)""));
					DC_Main.X++;
				}
			}
			cboClear.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT DM_CODE As CoCode From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY CAST(DM_CODE AS INT) DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tDmCode.Text = "0001";
			}
			else
			{
				tDmCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "0000");
			}
			((Control)tDmCode).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " DM_CODE = '" + tDmCode.Text + "'";
		if (dataView.Count > 0)
		{
			DataView dataView2 = dataView;
			tDmCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["DM_CODE"], (object)""));
			tGrCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["GR_CODE"], (object)""));
			DC_Main.RsQry = "SELECT GR_NAME FROM GROUP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND GR_CODE = '" + tGrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
			}
			cboCut.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["DM_SHAPE"], (object)""));
			cboClear.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["DM_CLARITY"], (object)""));
			tDmName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["DM_NAME"], (object)""));
			tShortName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["DM_SHORT"], (object)""));
			nSlRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["SL_RATE"]), "0.00");
			nPrRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["PR_RATE"]), "0.00");
			dataView2 = null;
			EntryMode = "E";
			((TextBoxBase)tDmCode).ReadOnly = true;
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
		DC_Main.RptName = "Diamond";
		DC_Main.RptFormula = "{DM_MAST.CO_CODE}= '" + DC_Main.MCo_code + "' ";
		UT_REPORT uT_REPORT = new UT_REPORT();
		((Control)uT_REPORT).Show();
		((Control)uT_REPORT).Focus();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
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
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if ((Operators.CompareString(tDmCode.Text, "", false) == 0) | (Operators.CompareString(tDmName.Text, "", false) == 0))
					{
						Interaction.MsgBox((object)"Enter Group Detail", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					DC_Main.RsQry = "DELETE FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  DM_CODE = '" + tDmCode.Text + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM DM_MAST  WHERE CO_CODE  = '" + tDmCode.Text + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = DC_Main.Rshlp.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["DM_CODE"] = tDmCode.Text;
					dataRow["GR_CODE"] = tGrCode.Text;
					dataRow["DM_SHAPE"] = cboCut.Text;
					dataRow["DM_CLARITY"] = cboClear.Text;
					dataRow["DM_NAME"] = tDmName.Text;
					dataRow["DM_SHORT"] = tShortName.Text;
					dataRow["SL_RATE"] = Conversion.Val(nSlRate.Text);
					dataRow["PR_RATE"] = Conversion.Val(nPrRate.Text);
					dataRow["MAIN_USER"] = MainUser;
					DC_Main.Rshlp.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
					DC_Main.Rshlp.Clear();
					Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					CLEAR_DATA();
					goto end_IL_0001;
				}
				case 640:
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
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 640;
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tDmCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Dm Code For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + tDmCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Cant Delete Record This Dm Code Use in Stock....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Dm Name now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  DM_CODE = '" + tDmCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY DM_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
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

	private void MS_DM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_DM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void tCntrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13 && Operators.CompareString(tDmCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tGrCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " DM_CODE = '" + tDmCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["DM_NAME"], (object)tDmName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Diamond Code already Exist in  '", dataView[0]["DM_NAME"]), (object)"'  Group Name... Please Change Dm Code..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tDmCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tDmName_Validating(object sender, CancelEventArgs e)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		if (RsMast.Rows.Count > 0)
		{
			dataView.RowFilter = " DM_NAME = '" + tDmName.Text + "'";
			if (dataView.Count > 0)
			{
				if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["DM_CODE"], (object)tDmCode.Text, false))
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Diamond Name already Exist in  '", dataView[0]["DM_CODE"]), (object)"'  Dm Code... Please Change Dmiamond Name..."), (MsgBoxStyle)0, (object)null);
					cancel = true;
					((TextBoxBase)tDmName).SelectAll();
				}
			}
			else
			{
				cancel = false;
			}
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
			dataView.RowFilter = "DM_NAME Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 80;
				((DataGridView)DGV).Columns[0].DataPropertyName = "DM_CODE";
				((DataGridView)DGV).Columns[1].Width = 320;
				((DataGridView)DGV).Columns[1].DataPropertyName = "DM_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_DM_KeyDown(object sender, KeyEventArgs e)
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

	private void tDmName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tDmName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Diamond Name ...", (MsgBoxStyle)0, (object)null);
				((Control)tDmName).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
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
			tDmCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tDmName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tDmCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tDmName).Focus();
	}

	private void nSlRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSlRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSlRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nPrRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPrRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPrRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void tGTradTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT GR_NAME As GroupNameL,GR_CODE as CodeL,TRAD_TYPE As TradTypeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY GR_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tGrCode.Text = DC_Main.ColValue[1];
					tGrName.Text = DC_Main.ColValue[0];
				}
				((Control)tGrCode).Focus();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["GR_NAME"]);
			SendKeys.Send("{tab}");
		}
	}

	private void MS_DM_Closed(object sender, EventArgs e)
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

	private void cboCut_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void cboClear_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			tDmName.Text = cboCut.Text + " " + cboClear.Text;
			SendKeys.Send("{TAB}");
		}
	}
}
