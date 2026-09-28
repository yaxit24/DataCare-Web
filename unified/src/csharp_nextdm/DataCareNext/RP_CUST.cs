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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class RP_CUST : XtraForm
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
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboProduct")]
	private ComboBox _cboProduct;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string[] AryPrCode;

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

	internal virtual SearchControl tSerchAll
	{
		[CompilerGenerated]
		get
		{
			return _tSerchAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSerchAll_TextChanged;
			SearchControl val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSerchAll = value;
			val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private virtual GridControl _DGV;

	internal virtual GridControl DGV
	{
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GridView1")]
	private virtual GridView _GridView1;

	internal virtual GridView GridView1
	{
		get
		{
			return _GridView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_GridView1 = value;
		}
	}

	internal virtual ComboBox cboProduct
	{
		[CompilerGenerated]
		get
		{
			return _cboProduct;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboProduct_KeyDown);
			ComboBox val2 = _cboProduct;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboProduct = value;
			val2 = _cboProduct;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	public int newindex { get; set; }

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
			((XtraForm)this).Dispose(disposing);
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
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Expected O, but got Unknown
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Expected O, but got Unknown
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Expected O, but got Unknown
		//IL_080f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Expected O, but got Unknown
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Expected O, but got Unknown
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Expected O, but got Unknown
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Expected O, but got Unknown
		//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Expected O, but got Unknown
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Expected O, but got Unknown
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected O, but got Unknown
		//IL_0b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b33: Expected O, but got Unknown
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c01: Expected O, but got Unknown
		//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Expected O, but got Unknown
		//IL_0d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Expected O, but got Unknown
		//IL_0dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Expected O, but got Unknown
		//IL_0e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e75: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_CUST));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tSerchAll = new SearchControl();
		DGV = new GridControl();
		GridView1 = new GridView();
		cboProduct = new ComboBox();
		Label1 = new Label();
		Label2 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)GridView1).BeginInit();
		((XtraForm)this).SuspendLayout();
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
		((Control)BtnPrint).TabIndex = 0;
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
		lblBook.Text = "Party Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)tSerchAll).Location = new Point(233, 41);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Advance Search";
		((Control)tSerchAll).Size = new Size(155, 22);
		((Control)tSerchAll).TabIndex = 2;
		((Control)DGV).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DGV).Location = new Point(12, 73);
		DGV.MainView = (BaseView)(object)GridView1;
		((Control)DGV).Name = "DGV";
		((Control)DGV).Size = new Size(1158, 483);
		((Control)DGV).TabIndex = 3;
		DGV.ViewCollection.AddRange((BaseView[])(object)new BaseView[1] { (BaseView)GridView1 });
		GridView1.Appearance.ColumnFilterButton.Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		GridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		GridView1.AppearancePrint.EvenRow.Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		GridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		((BaseView)GridView1).GridControl = DGV;
		((BaseView)GridView1).Name = "GridView1";
		((ColumnViewOptionsBehavior)GridView1.OptionsBehavior).Editable = false;
		GridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		GridView1.OptionsView.ShowFooter = true;
		cboProduct.AutoCompleteMode = (AutoCompleteMode)3;
		cboProduct.AutoCompleteSource = (AutoCompleteSource)256;
		cboProduct.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboProduct).Font = new Font("Tahoma", 9f);
		((ListControl)cboProduct).FormattingEnabled = true;
		((Control)cboProduct).Location = new Point(478, 42);
		((Control)cboProduct).Name = "cboProduct";
		((Control)cboProduct).Size = new Size(152, 22);
		((Control)cboProduct).TabIndex = 125;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(394, 43);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(78, 20);
		((Control)Label1).TabIndex = 126;
		Label1.Text = "Ac Group";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(18, 41);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(44, 20);
		((Control)Label2).TabIndex = 129;
		Label2.Text = "Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(151, 41);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(69, 41);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((XtraForm)this).Appearance.BackColor = SystemColors.ButtonHighlight;
		((XtraForm)this).Appearance.Options.UseBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)cboProduct);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tSerchAll);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_CUST";
		((XtraForm)this).Text = "Party Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)GridView1).EndInit();
		((XtraForm)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public RP_CUST()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((Form)this).Load += RP_CUST_Load;
		((Form)this).Activated += RP_CUST_Activated;
		((Form)this).Deactivate += RP_CUST_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_CUST_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_CUST_KeyDown);
		((Form)this).Closed += RP_CUST_Closed;
		InitializeComponent();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
	}

	private void RP_CUST_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Expected O, but got Unknown
		//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Expected O, but got Unknown
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Expected O, but got Unknown
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082f: Expected O, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Expected O, but got Unknown
		//IL_0889: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Expected O, but got Unknown
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
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
		((XtraForm)this).SuspendLayout();
		((XtraForm)this).ResumeLayout();
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
				((XtraForm)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				ComboBox obj7 = cboProduct;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				obj7.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((XtraForm)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				ComboBox obj10 = cboProduct;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				obj10.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj12 = colorConverter.ConvertFromString("205, 220, 220");
				((XtraForm)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj13 = lblBook;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj13).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				ComboBox obj16 = cboProduct;
				object? obj17 = colorConverter.ConvertFromString("238, 244, 236");
				obj16.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)Label1).Font.Size * (1.0 + num2));
				Font font = ((Control)Label1).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is MaskedTextBox || val3 is Label || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) | (Operators.CompareString(val3.Name, "GridView1", false) != 0)))
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					((Control)mFromDt).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)mToDt).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((BaseEdit)tSerchAll).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)cboProduct).Font = new Font(font.FontFamily, (float)num3, font.Style);
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
			DC_Main.RsQry = "SELECT AC_GR_NAME As AcGrName,AC_GR as Code FROM AC_GROUP  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_GR IN ('04','15','05','10','19','20') ORDER BY AC_GR";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryPrCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryPrCode[DC_Main.X] = "";
				cboProduct.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboProduct.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.X]["AcGrName"]), (object)""));
					AryPrCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboProduct.Items.Add((object)"");
				AryPrCode[DC_Main.X] = "";
			}
			cboProduct.SelectedIndex = 0;
			mFromDt.Text = "01/01/2010";
			mToDt.Text = Conversions.ToString(DateTime.Now);
			DC_Main.RsQry = "SELECT A.AC_CODE,(SELECT TOP(1) VCH_DATE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = A.AC_CODE ORDER BY VCH_DATE DESC) As VchDate,(SELECT TOP(1) CO_BOOK FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = A.AC_CODE ORDER BY VCH_DATE DESC) As CoBook FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ('04','15','05','10','19','20') ORDER BY A.AC_CODE DESC";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["CoBook"])))
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AC_MAST SET LAST_VISIT = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.X]["VchDate"]), "MM/dd/yyyy") + "',VISIT_TRAN = '"), DC_Main.Rshlp.Rows[DC_Main.X]["CoBook"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND  AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'")));
					}
					DC_Main.X++;
				}
			}
			CurActCtrl = (Control)(object)mFromDt;
		}
	}

	private void RP_CUST_Activated(object sender, EventArgs e)
	{
		Last_Visit();
		CurActCtrl.Focus();
	}

	private void Last_Visit()
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY A.LAST_VISIT DESC) AS SrNo,A.AC_NAME As AcName,A.AC_MOBILE As Mobile,A.LAST_VISIT As LastVisit,B.BOOK_NAME As LastTran,AC_CITY As City,  A.AC_ADD1 As Address1,A.AC_AREA As Area,A.AC_GR As AcGroup,A.AC_CODE As AcCode  from AC_MAST AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.VISIT_TRAN = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND AC_GR IN ('04','05','10','15','20','45','19')AND A.LAST_VISIT >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.LAST_VISIT <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
		if (Operators.CompareString(cboProduct.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + AryPrCode[cboProduct.SelectedIndex] + "'";
		}
		DC_Main.RsQry += "ORDER BY A.LAST_VISIT DESC";
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_FILL()
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataView dataView = default(DataView);
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
						DGV_CLEAR();
						goto IL_000b;
					case 854:
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
								goto IL_000b;
							case 3:
								goto IL_0019;
							case 4:
								goto IL_002a;
							case 5:
								goto IL_0039;
							case 6:
							case 7:
								goto IL_0049;
							case 8:
								goto IL_0064;
							case 9:
							case 10:
								goto IL_0098;
							case 11:
								goto IL_00a1;
							case 12:
								goto IL_00d4;
							case 13:
								goto IL_00fd;
							case 14:
								goto IL_0130;
							case 15:
								goto IL_0163;
							case 16:
								goto IL_0196;
							case 17:
								goto IL_01c9;
							case 18:
								goto IL_01f9;
							case 19:
								goto IL_0213;
							case 20:
								goto IL_0239;
							case 21:
								goto IL_0257;
							case 22:
								goto IL_027d;
							case 23:
								goto IL_02a3;
							case 24:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 25:
							case 26:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0257:
						num2 = 21;
						GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", (float)num5);
						goto IL_027d;
						IL_027d:
						num2 = 22;
						GridView1.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", (float)num5);
						goto IL_02a3;
						IL_0239:
						num2 = 20;
						GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
						goto IL_0257;
						IL_02a3:
						num2 = 23;
						GridView1.RowHeight = (int)Math.Round(22.0 * DC_Main.ScreenHight);
						break;
						IL_000b:
						num2 = 2;
						dataView = new DataView(RsStkSum);
						goto IL_0019;
						IL_0019:
						num2 = 3;
						if (dataView.Count > 0)
						{
							goto IL_002a;
						}
						goto IL_0049;
						IL_002a:
						num2 = 4;
						DGV.DataSource = dataView;
						goto IL_0039;
						IL_0039:
						num2 = 5;
						DGV.ForceInitialize();
						goto IL_0049;
						IL_0049:
						num2 = 7;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_0064;
						}
						goto IL_0098;
						IL_0064:
						num2 = 8;
						GridView1.Appearance.Row.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize - 1f, DC_Main.MsFontStyle);
						goto IL_0098;
						IL_0098:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00a1;
						IL_00a1:
						num2 = 11;
						((ColumnView)GridView1).Columns["SrNo"].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
						goto IL_00d4;
						IL_00d4:
						num2 = 12;
						((AppearanceObject)((ColumnView)GridView1).Columns["SrNo"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)1;
						goto IL_00fd;
						IL_00fd:
						num2 = 13;
						((ColumnView)GridView1).Columns["AcName"].Width = (int)Math.Round(225.0 * DC_Main.ScreenHight);
						goto IL_0130;
						IL_0130:
						num2 = 14;
						((ColumnView)GridView1).Columns["Mobile"].Width = (int)Math.Round(85.0 * DC_Main.ScreenHight);
						goto IL_0163;
						IL_0163:
						num2 = 15;
						((ColumnView)GridView1).Columns["LastVisit"].Width = (int)Math.Round(85.0 * DC_Main.ScreenHight);
						goto IL_0196;
						IL_0196:
						num2 = 16;
						((ColumnView)GridView1).Columns["Address1"].Width = (int)Math.Round(200.0 * DC_Main.ScreenHight);
						goto IL_01c9;
						IL_01c9:
						num2 = 17;
						if (!((Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0) & (DC_Main.ScreenHight > 1.0)))
						{
							goto end_IL_0001_3;
						}
						goto IL_01f9;
						IL_01f9:
						num2 = 18;
						num5 = (int)Math.Ceiling(9.0 * DC_Main.ScreenHight);
						goto IL_0213;
						IL_0213:
						num2 = 19;
						GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", (float)num5);
						goto IL_0239;
						end_IL_0001_2:
						break;
					}
					num2 = 24;
					GridView1.BestFitColumns(true);
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 854;
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
		cboProduct.SelectedIndex = 0;
		mFromDt.Text = "01/01/2010";
		mToDt.Text = Conversions.ToString(DateTime.Now);
		Last_Visit();
		((Control)mFromDt).Focus();
	}

	private void DGV_CLEAR()
	{
		DGV.DataSource = null;
		((CollectionBase)(object)((ColumnView)GridView1).Columns).Clear();
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataView dataView = default(DataView);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
					{
						goto IL_0024;
					}
					goto IL_0107;
				case 748:
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
							goto IL_0024;
						case 3:
							goto IL_002d;
						case 4:
							goto IL_0036;
						case 5:
							goto IL_0055;
						case 6:
							goto IL_007d;
						case 7:
							goto IL_009f;
						case 8:
							goto IL_00be;
						case 9:
							goto IL_00dd;
						case 11:
						case 12:
							goto IL_0107;
						case 13:
							goto IL_012c;
						case 14:
							goto IL_0136;
						case 15:
							goto IL_0146;
						case 16:
							goto IL_016b;
						case 17:
							goto IL_017e;
						case 18:
						case 19:
							goto IL_0191;
						case 20:
							goto IL_019a;
						case 21:
							goto IL_01ba;
						case 22:
							goto IL_01e3;
						case 23:
							goto IL_0206;
						case 24:
							goto IL_0226;
						case 25:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 10:
						case 26:
						case 27:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_01e3:
					num2 = 22;
					((ColumnView)GridView1).Columns["AcName"].Width = 225;
					goto IL_0206;
					IL_0206:
					num2 = 23;
					((ColumnView)GridView1).Columns["Mobile"].Width = 85;
					goto IL_0226;
					IL_01ba:
					num2 = 21;
					((AppearanceObject)((ColumnView)GridView1).Columns["SrNo"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)1;
					goto IL_01e3;
					IL_0226:
					num2 = 24;
					((ColumnView)GridView1).Columns["LastVisit"].Width = 85;
					break;
					IL_0024:
					num2 = 2;
					DGV_FILL();
					goto IL_002d;
					IL_002d:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0036;
					IL_0036:
					num2 = 4;
					((ColumnView)GridView1).Columns["SrNo"].Width = 50;
					goto IL_0055;
					IL_0055:
					num2 = 5;
					((AppearanceObject)((ColumnView)GridView1).Columns["SrNo"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)1;
					goto IL_007d;
					IL_007d:
					num2 = 6;
					((ColumnView)GridView1).Columns["AcName"].Width = 225;
					goto IL_009f;
					IL_009f:
					num2 = 7;
					((ColumnView)GridView1).Columns["Mobile"].Width = 85;
					goto IL_00be;
					IL_00be:
					num2 = 8;
					((ColumnView)GridView1).Columns["LastVisit"].Width = 85;
					goto IL_00dd;
					IL_00dd:
					num2 = 9;
					((ColumnView)GridView1).Columns["Address1"].Width = 200;
					goto end_IL_0001_3;
					IL_0107:
					num2 = 12;
					if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_012c;
					IL_012c:
					num2 = 13;
					DGV_CLEAR();
					goto IL_0136;
					IL_0136:
					num2 = 14;
					dataView = new DataView(RsStkSum);
					goto IL_0146;
					IL_0146:
					num2 = 15;
					dataView.RowFilter = "AcName Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";
					goto IL_016b;
					IL_016b:
					num2 = 16;
					if (dataView.Count > 0)
					{
						goto IL_017e;
					}
					goto IL_0191;
					IL_017e:
					num2 = 17;
					DGV.DataSource = dataView;
					goto IL_0191;
					IL_0191:
					ProjectData.ClearProjectError();
					num3 = -3;
					goto IL_019a;
					IL_019a:
					num2 = 20;
					((ColumnView)GridView1).Columns["SrNo"].Width = 50;
					goto IL_01ba;
					end_IL_0001_2:
					break;
				}
				num2 = 25;
				((ColumnView)GridView1).Columns["Address1"].Width = 200;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 748;
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

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_CUST_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_CUST_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_CUST_KeyDown(object sender, KeyEventArgs e)
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)Interaction.MsgBox((object)"Default Report Display....", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DGV.ShowPrintPreview();
			return;
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLastVisit.RPT";
		Cr.SelectionFormula = "{AC_MAST.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_MAST.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_MAST.LAST_VISIT} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_MAST.LAST_VISIT} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(cboProduct.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_GR} = '" + Strings.Mid(cboProduct.Text, 1, 2) + "'";
		}
		Cr[(short)0] = "RptTitel = '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_CUST_Closed(object sender, EventArgs e)
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

	private void cboProduct_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			Last_Visit();
		}
	}
}
