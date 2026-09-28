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
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_GOLD_MAST : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tContryCode")]
	private TextBox _tContryCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGoldRate")]
	private TextBox _nGoldRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOzConv")]
	private TextBox _nOzConv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGoldConv")]
	private TextBox _nGoldConv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSilverRate")]
	private TextBox _nSilverRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankCode")]
	private TextBox _tBankCode;

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
	[AccessedThroughProperty("nSilverConv")]
	private TextBox _nSilverConv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkGoldBookActiv")]
	private CheckBox _chkGoldBookActiv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBookWithLiveRate")]
	private CheckBox _chkBookWithLiveRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCustSlRateLess")]
	private TextBox _nCustSlRateLess;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCustBuyRateAdd")]
	private TextBox _nCustBuyRateAdd;

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

	internal virtual TextBox tContryCode
	{
		[CompilerGenerated]
		get
		{
			return _tContryCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCntrCode_KeyDown);
			TextBox val2 = _tContryCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tContryCode = value;
			val2 = _tContryCode;
			if (val2 != null)
			{
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

	internal virtual TextBox nGoldRate
	{
		[CompilerGenerated]
		get
		{
			return _nGoldRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldRate_KeyDown);
			TextBox val2 = _nGoldRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGoldRate = value;
			val2 = _nGoldRate;
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

	internal virtual TextBox nOzConv
	{
		[CompilerGenerated]
		get
		{
			return _nOzConv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOzConv_KeyDown);
			TextBox val2 = _nOzConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nOzConv = value;
			val2 = _nOzConv;
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

	internal virtual TextBox nGoldConv
	{
		[CompilerGenerated]
		get
		{
			return _nGoldConv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldConv_KeyDown);
			TextBox val2 = _nGoldConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGoldConv = value;
			val2 = _nGoldConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nSilverRate
	{
		[CompilerGenerated]
		get
		{
			return _nSilverRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSilverRate_KeyDown);
			TextBox val2 = _nSilverRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSilverRate = value;
			val2 = _nSilverRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private virtual TextBox _tBankName;

	internal virtual TextBox tBankName
	{
		get
		{
			return _tBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBankName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label8")]
	private virtual Label _Label8;

	internal virtual Label Label8
	{
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label8 = value;
		}
	}

	internal virtual TextBox tBankCode
	{
		[CompilerGenerated]
		get
		{
			return _tBankCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tSalesAc_KeyDown);
			TextBox val2 = _tBankCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankCode = value;
			val2 = _tBankCode;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label11")]
	private virtual Label _Label11;

	internal virtual Label Label11
	{
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual TextBox nSilverConv
	{
		[CompilerGenerated]
		get
		{
			return _nSilverConv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSilverConv_KeyDown);
			TextBox val2 = _nSilverConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSilverConv = value;
			val2 = _nSilverConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual CheckBox chkGoldBookActiv
	{
		[CompilerGenerated]
		get
		{
			return _chkGoldBookActiv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkGoldBookActiv_KeyDown);
			CheckBox val2 = _chkGoldBookActiv;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkGoldBookActiv = value;
			val2 = _chkGoldBookActiv;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual CheckBox chkBookWithLiveRate
	{
		[CompilerGenerated]
		get
		{
			return _chkBookWithLiveRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkBookWithLiveRate_KeyDown);
			CheckBox val2 = _chkBookWithLiveRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkBookWithLiveRate = value;
			val2 = _chkBookWithLiveRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label12")]
	private virtual Label _Label12;

	internal virtual Label Label12
	{
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label12 = value;
		}
	}

	internal virtual TextBox nCustSlRateLess
	{
		[CompilerGenerated]
		get
		{
			return _nCustSlRateLess;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCustSlRateLess_KeyDown);
			TextBox val2 = _nCustSlRateLess;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCustSlRateLess = value;
			val2 = _nCustSlRateLess;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label13")]
	private virtual Label _Label13;

	internal virtual Label Label13
	{
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual TextBox nCustBuyRateAdd
	{
		[CompilerGenerated]
		get
		{
			return _nCustBuyRateAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCustBuyRateAdd_KeyDown);
			TextBox val2 = _nCustBuyRateAdd;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCustBuyRateAdd = value;
			val2 = _nCustBuyRateAdd;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	public MS_GOLD_MAST()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_GOLD_MAST_Load;
		((Form)this).Activated += MS_GOLD_MAST_Activated;
		((Form)this).Deactivate += MS_GOLD_MAST_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_GOLD_MAST_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_GOLD_MAST_KeyDown);
		((Form)this).Closed += MS_GOLD_MAST_Closed;
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
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Expected O, but got Unknown
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Expected O, but got Unknown
		//IL_0828: Unknown result type (might be due to invalid IL or missing references)
		//IL_0832: Expected O, but got Unknown
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089f: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_GOLD_MAST));
		lblBook = new Label();
		tContryCode = new TextBox();
		Label2 = new Label();
		Label4 = new Label();
		nGoldRate = new TextBox();
		Label5 = new Label();
		nOzConv = new TextBox();
		Label6 = new Label();
		nGoldConv = new TextBox();
		Label7 = new Label();
		nSilverRate = new TextBox();
		tBankName = new TextBox();
		Label8 = new Label();
		tBankCode = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		Label11 = new Label();
		nSilverConv = new TextBox();
		chkGoldBookActiv = new CheckBox();
		chkBookWithLiveRate = new CheckBox();
		Label12 = new Label();
		nCustSlRateLess = new TextBox();
		Label13 = new Label();
		nCustBuyRateAdd = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		((TextBoxBase)tContryCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tContryCode, "tContryCode");
		((Control)tContryCode).Name = "tContryCode";
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		((TextBoxBase)nGoldRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nGoldRate, "nGoldRate");
		((Control)nGoldRate).Name = "nGoldRate";
		componentResourceManager.ApplyResources(Label5, "Label5");
		((Control)Label5).ForeColor = Color.Black;
		((Control)Label5).Name = "Label5";
		((TextBoxBase)nOzConv).BackColor = Color.White;
		componentResourceManager.ApplyResources(nOzConv, "nOzConv");
		((Control)nOzConv).Name = "nOzConv";
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		((TextBoxBase)nGoldConv).BackColor = Color.White;
		componentResourceManager.ApplyResources(nGoldConv, "nGoldConv");
		((Control)nGoldConv).Name = "nGoldConv";
		componentResourceManager.ApplyResources(Label7, "Label7");
		((Control)Label7).ForeColor = Color.Black;
		((Control)Label7).Name = "Label7";
		((TextBoxBase)nSilverRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nSilverRate, "nSilverRate");
		((Control)nSilverRate).Name = "nSilverRate";
		((TextBoxBase)tBankName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tBankName, "tBankName");
		((Control)tBankName).Name = "tBankName";
		componentResourceManager.ApplyResources(Label8, "Label8");
		((Control)Label8).ForeColor = Color.Black;
		((Control)Label8).Name = "Label8";
		((TextBoxBase)tBankCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tBankCode, "tBankCode");
		((Control)tBankCode).Name = "tBankCode";
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
		componentResourceManager.ApplyResources(Label11, "Label11");
		((Control)Label11).ForeColor = Color.Black;
		((Control)Label11).Name = "Label11";
		((TextBoxBase)nSilverConv).BackColor = Color.White;
		componentResourceManager.ApplyResources(nSilverConv, "nSilverConv");
		((Control)nSilverConv).Name = "nSilverConv";
		((ButtonBase)chkGoldBookActiv).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkGoldBookActiv, "chkGoldBookActiv");
		((Control)chkGoldBookActiv).ForeColor = Color.Black;
		((Control)chkGoldBookActiv).Name = "chkGoldBookActiv";
		((ButtonBase)chkGoldBookActiv).UseVisualStyleBackColor = false;
		((ButtonBase)chkBookWithLiveRate).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkBookWithLiveRate, "chkBookWithLiveRate");
		((Control)chkBookWithLiveRate).ForeColor = Color.Black;
		((Control)chkBookWithLiveRate).Name = "chkBookWithLiveRate";
		((ButtonBase)chkBookWithLiveRate).UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(Label12, "Label12");
		((Control)Label12).ForeColor = Color.Black;
		((Control)Label12).Name = "Label12";
		((TextBoxBase)nCustSlRateLess).BackColor = Color.White;
		componentResourceManager.ApplyResources(nCustSlRateLess, "nCustSlRateLess");
		((Control)nCustSlRateLess).Name = "nCustSlRateLess";
		componentResourceManager.ApplyResources(Label13, "Label13");
		((Control)Label13).ForeColor = Color.Black;
		((Control)Label13).Name = "Label13";
		((TextBoxBase)nCustBuyRateAdd).BackColor = Color.White;
		componentResourceManager.ApplyResources(nCustBuyRateAdd, "nCustBuyRateAdd");
		((Control)nCustBuyRateAdd).Name = "nCustBuyRateAdd";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)nCustSlRateLess);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)nCustBuyRateAdd);
		((Control)this).Controls.Add((Control)(object)nGoldConv);
		((Control)this).Controls.Add((Control)(object)nSilverConv);
		((Control)this).Controls.Add((Control)(object)chkBookWithLiveRate);
		((Control)this).Controls.Add((Control)(object)chkGoldBookActiv);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)nSilverRate);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nOzConv);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tBankCode);
		((Control)this).Controls.Add((Control)(object)nGoldRate);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)tContryCode);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_GOLD_MAST";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_GOLD_MAST_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected O, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Expected O, but got Unknown
		//IL_07c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Expected O, but got Unknown
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Expected O, but got Unknown
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
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				TextBox obj7 = tBankName;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj7).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				TextBox obj10 = tBankName;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
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
				((TextBoxBase)tBankName).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tContryCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tContryCode).Font;
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
			}
			CLEAR_DATA();
			EntryMode = "A";
			CurActCtrl = (Control)(object)tContryCode;
		}
	}

	private void MS_GOLD_MAST_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
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
		((TextBoxBase)tContryCode).MaxLength = 3;
		((TextBoxBase)tContryCode).ReadOnly = false;
		EntryMode = "A";
		DC_Main.RsQry = "SELECT * FROM DG_GOLD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DISPLAY_DATA();
		((Control)tBankCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " CO_CODE = '" + DC_Main.MCo_code + "'";
		if (dataView.Count > 0)
		{
			DataView dataView2 = dataView;
			tContryCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["COUNTRY_CODE"], (object)""));
			tBankCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["BANK_AC_CODE"], (object)""));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc("SELECT * FROM AC_MAST WHERE AC_CODE = '" + tBankCode.Text + "'");
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["BOOK_WITH_LIVE_RATE"], (object)""), (object)"Y", false))
			{
				chkBookWithLiveRate.Checked = true;
			}
			else
			{
				chkBookWithLiveRate.Checked = false;
			}
			nOzConv.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["OUNCES_CONV"]), "0.0000");
			nGoldConv.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["GOLD_CONV"]), "0.0000");
			nSilverConv.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["SILVER_CONV"]), "0.0000");
			nGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["GOLD_FIX_RATE"]), "0.00");
			nSilverRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["SILVER_FIX_RATE"]), "0.00");
			nCustBuyRateAdd.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["CUST_BUY_RATE_ADD"]), "0.00");
			nCustSlRateLess.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["CUST_SALE_RATE_LESS"]), "0.00");
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["SHOW_DG_GOLD"], (object)""), (object)"Y", false))
			{
				chkGoldBookActiv.Checked = true;
			}
			else
			{
				chkGoldBookActiv.Checked = false;
			}
			MainUser = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["MAIN_USER"], (object)""));
			dataView2 = null;
			EntryMode = "E";
			((TextBoxBase)tContryCode).ReadOnly = true;
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
		DC_Main.RptName = "Digital Gold";
		DC_Main.RptFormula = "{DG_GOLD_MAST.CO_CODE}= '" + DC_Main.MCo_code + "' ";
		UT_REPORT uT_REPORT = new UT_REPORT();
		((Control)uT_REPORT).Show();
		((Control)uT_REPORT).Focus();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(tContryCode.Text, "", false) == 0) | (Operators.CompareString(tBankCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Enter Detail And Try", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "DELETE FROM DG_GOLD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM DG_GOLD_MAST  WHERE CO_CODE  = '" + tContryCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = DC_Main.Rshlp.NewRow();
		dataRow["CO_CODE"] = DC_Main.MCo_code;
		dataRow["COUNTRY_CODE"] = tContryCode.Text;
		dataRow["BANK_AC_CODE"] = tBankCode.Text;
		dataRow["BOOK_WITH_LIVE_RATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkBookWithLiveRate.Checked, (object)"Y", (object)"N"));
		dataRow["API_KEY"] = "";
		dataRow["CURRENCY_RATE"] = 0;
		dataRow["OUNCES_CONV"] = Conversion.Val(nOzConv.Text);
		dataRow["GOLD_CONV"] = Conversion.Val(nGoldConv.Text);
		dataRow["SILVER_CONV"] = Conversion.Val(nSilverConv.Text);
		dataRow["GOLD_FIX_RATE"] = Conversion.Val(nGoldRate.Text);
		dataRow["SILVER_FIX_RATE"] = Conversion.Val(nSilverRate.Text);
		dataRow["CUST_BUY_RATE_ADD"] = Conversion.Val(nCustBuyRateAdd.Text);
		dataRow["CUST_SALE_RATE_LESS"] = Conversion.Val(nCustSlRateLess.Text);
		dataRow["SHOW_DG_GOLD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkGoldBookActiv.Checked, (object)"Y", (object)"N"));
		dataRow["MAIN_USER"] = MainUser;
		DC_Main.Rshlp.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		AppSchemeTrfr();
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		CLEAR_DATA();
	}

	private void AppSchemeTrfr()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
			text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
			text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		}
		DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
		DC_Main.RsQry = "DELETE FROM DG_GOLD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteScm(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM DG_GOLD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			DataTable tbl = DC_Main.Tbl;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DG_GOLD_MAST(CO_CODE,COUNTRY_CODE,SHOW_DG_GOLD,API_KEY,CURRENCY_RATE,OUNCES_CONV,GOLD_CONV,SILVER_CONV,  CUST_BUY_RATE_ADD,CUST_SALE_RATE_LESS,BOOK_WITH_LIVE_RATE,GOLD_FIX_RATE,SILVER_FIX_RATE,MAIN_USER,BANK_AC_CODE)  VALUES('" + DC_Main.MCo_code + "','"), tbl.Rows[0]["COUNTRY_CODE"]), (object)"','"), tbl.Rows[0]["SHOW_DG_GOLD"]), (object)"','"), tbl.Rows[0]["API_KEY"]), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["CURRENCY_RATE"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["OUNCES_CONV"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["GOLD_CONV"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["SILVER_CONV"]))), (object)", "), (object)" "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["CUST_BUY_RATE_ADD"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["CUST_SALE_RATE_LESS"]))), (object)",'"), tbl.Rows[0]["BOOK_WITH_LIVE_RATE"]), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["GOLD_FIX_RATE"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[0]["SILVER_FIX_RATE"]))), (object)",'"), tbl.Rows[0]["MAIN_USER"]), (object)"','"), tbl.Rows[0]["BANK_AC_CODE"]), (object)"')"));
			DC_Main.OpenRecordSetScm(DC_Main.RsQry);
			tbl = null;
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tContryCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Group For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tContryCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Cant Delete Record This Group Code Use in Item Master....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Group now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM DG_GOLD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  GR_CODE = '" + tContryCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
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

	private void MS_GOLD_MAST_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_GOLD_MAST_KeyPress(object sender, KeyPressEventArgs e)
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
		if ((int)e.KeyCode == 13 && Operators.CompareString(tContryCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void MS_GOLD_MAST_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void nGoldRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nGoldRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nOzConv_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nOzConv.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nOzConv.Text)), "0.0000");
			SendKeys.Send("{TAB}");
		}
	}

	private void nSilverRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSilverRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSilverRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nGoldConv_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nGoldConv.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldConv.Text)), "0.0000");
			SendKeys.Send("{TAB}");
		}
	}

	private void tSalesAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tBankCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  AC_GR IN ('02','03','19','22','23')  ORDER BY AC_NAME";
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
					tBankCode.Text = DC_Main.ColValue[1];
					tBankName.Text = DC_Main.ColValue[0];
				}
				EntryMode = "E";
				((Control)tBankCode).Focus();
			}
		}
		else
		{
			tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void MS_GOLD_MAST_Closed(object sender, EventArgs e)
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

	private void tHsnCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void nSilverConv_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSilverConv.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSilverConv.Text)), "0.0000");
			SendKeys.Send("{TAB}");
		}
	}

	private void chkBookWithLiveRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void nCustBuyRateAdd_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCustBuyRateAdd.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCustBuyRateAdd.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nCustSlRateLess_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCustSlRateLess.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCustSlRateLess.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void chkGoldBookActiv_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			SendKeys.Send("{TAB}");
		}
	}
}
