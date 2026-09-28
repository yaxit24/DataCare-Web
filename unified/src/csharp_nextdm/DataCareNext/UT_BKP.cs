using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class UT_BKP : Form
{
	private IContainer components;

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
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBkp")]
	private SimpleButton _btnBkp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnRestore")]
	private SimpleButton _BtnRestore;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAttach")]
	private SimpleButton _btnAttach;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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
	[AccessedThroughProperty("tSavePath")]
	private virtual TextBox _tSavePath;

	internal virtual TextBox tSavePath
	{
		get
		{
			return _tSavePath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSavePath = value;
		}
	}

	internal virtual SimpleButton BtnF1
	{
		[CompilerGenerated]
		get
		{
			return _BtnF1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnF1_Click;
			SimpleButton val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnF1 = value;
			val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private virtual ProgressBar _ProgressBar1;

	internal virtual ProgressBar ProgressBar1
	{
		get
		{
			return _ProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ProgressBar1 = value;
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

	internal virtual SimpleButton btnBkp
	{
		[CompilerGenerated]
		get
		{
			return _btnBkp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBkp_Click;
			SimpleButton val = _btnBkp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBkp = value;
			val = _btnBkp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("foldbrous")]
	private virtual XtraFolderBrowserDialog _foldbrous;

	internal virtual XtraFolderBrowserDialog foldbrous
	{
		get
		{
			return _foldbrous;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_foldbrous = value;
		}
	}

	internal virtual SimpleButton BtnRestore
	{
		[CompilerGenerated]
		get
		{
			return _BtnRestore;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRestore_Click;
			SimpleButton val = _BtnRestore;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnRestore = value;
			val = _BtnRestore;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Timer1_Tick;
			Timer val = _Timer1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			_Timer1 = value;
			val = _Timer1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("OpenFileDialog1")]
	private virtual OpenFileDialog _OpenFileDialog1;

	internal virtual OpenFileDialog OpenFileDialog1
	{
		get
		{
			return _OpenFileDialog1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_OpenFileDialog1 = value;
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

	internal virtual SimpleButton btnAttach
	{
		[CompilerGenerated]
		get
		{
			return _btnAttach;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAttach_Click;
			SimpleButton val = _btnAttach;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAttach = value;
			val = _btnAttach;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UT_BKP()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += UT_BKP_Load;
		((Form)this).Deactivate += UT_BKP_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_BKP_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_BKP_KeyDown);
		((Form)this).Closed += UT_BKP_Closed;
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b4: Expected O, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Expected O, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected O, but got Unknown
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected O, but got Unknown
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Expected O, but got Unknown
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0958: Expected O, but got Unknown
		//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2c: Expected O, but got Unknown
		//IL_0b04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0e: Expected O, but got Unknown
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Expected O, but got Unknown
		//IL_0d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d48: Expected O, but got Unknown
		//IL_0e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2a: Expected O, but got Unknown
		//IL_0ec6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Expected O, but got Unknown
		//IL_1026: Unknown result type (might be due to invalid IL or missing references)
		//IL_1030: Expected O, but got Unknown
		//IL_1108: Unknown result type (might be due to invalid IL or missing references)
		//IL_1112: Expected O, but got Unknown
		//IL_11ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b8: Expected O, but got Unknown
		//IL_12fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Expected O, but got Unknown
		//IL_13c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d0: Expected O, but got Unknown
		//IL_14a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b2: Expected O, but got Unknown
		//IL_154e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1558: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_BKP));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tSavePath = new TextBox();
		BtnF1 = new SimpleButton();
		ProgressBar1 = new ProgressBar();
		btnBkp = new SimpleButton();
		foldbrous = new XtraFolderBrowserDialog(components);
		BtnRestore = new SimpleButton();
		Timer1 = new Timer(components);
		OpenFileDialog1 = new OpenFileDialog();
		Label1 = new Label();
		btnAttach = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
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
		lblBook.Text = "Backup Data";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tSavePath).BackColor = Color.White;
		((Control)tSavePath).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSavePath).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)tSavePath).Location = new Point(437, 183);
		((TextBoxBase)tSavePath).MaxLength = 50;
		((Control)tSavePath).Name = "tSavePath";
		((Control)tSavePath).Size = new Size(311, 26);
		((Control)tSavePath).TabIndex = 7;
		tSavePath.TextAlign = (HorizontalAlignment)2;
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(535, 127);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(106, 32);
		((Control)BtnF1).TabIndex = 1151;
		BtnF1.Text = "Se&lect";
		((BaseControl)BtnF1).ToolTip = "Party Help";
		((Control)ProgressBar1).Location = new Point(378, 236);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(426, 23);
		((Control)ProgressBar1).TabIndex = 1152;
		((BaseStyleControl)btnBkp).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnBkp).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnBkp).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnBkp).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnBkp).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnBkp).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnBkp).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnBkp).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBkp).Appearance.Options.UseForeColor = true;
		((BaseButton)btnBkp).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnBkp).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnBkp).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBkp).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnBkp).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnBkp).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnBkp).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnBkp).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnBkp).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnBkp).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBkp).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnBkp).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnBkp).AppearancePressed.Options.UseFont = true;
		((Control)btnBkp).Location = new Point(535, 279);
		((BaseControl)btnBkp).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnBkp).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnBkp).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBkp).Name = "btnBkp";
		((Control)btnBkp).Size = new Size(106, 32);
		((Control)btnBkp).TabIndex = 1153;
		btnBkp.Text = "&Backup";
		((BaseControl)btnBkp).ToolTip = "Party Help";
		foldbrous.SelectedPath = "XtraFolderBrowserDialog1";
		foldbrous.ShowNewFolderButton = false;
		((BaseStyleControl)BtnRestore).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnRestore).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnRestore).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnRestore).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnRestore).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnRestore).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnRestore).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnRestore).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnRestore).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnRestore).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnRestore).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnRestore).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnRestore).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnRestore).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnRestore).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnRestore).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnRestore).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnRestore).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnRestore).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnRestore).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnRestore).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnRestore).AppearancePressed.Options.UseFont = true;
		((Control)BtnRestore).Location = new Point(535, 470);
		((BaseControl)BtnRestore).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnRestore).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnRestore).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnRestore).Name = "BtnRestore";
		((Control)BtnRestore).Size = new Size(106, 32);
		((Control)BtnRestore).TabIndex = 1154;
		BtnRestore.Text = "&Restore";
		((BaseControl)BtnRestore).ToolTip = "Party Help";
		((Control)BtnRestore).Visible = false;
		((FileDialog)OpenFileDialog1).Filter = "Bakup files (*.Bak)|*.Bak";
		Label1.AutoSize = true;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)Label1).Location = new Point(331, 187);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(90, 20);
		((Control)Label1).TabIndex = 1155;
		Label1.Text = "Backup Path";
		((BaseStyleControl)btnAttach).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnAttach).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnAttach).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnAttach).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnAttach).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnAttach).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnAttach).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnAttach).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnAttach).Appearance.Options.UseForeColor = true;
		((BaseButton)btnAttach).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnAttach).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnAttach).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnAttach).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnAttach).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnAttach).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnAttach).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnAttach).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnAttach).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnAttach).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnAttach).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnAttach).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnAttach).AppearancePressed.Options.UseFont = true;
		((Control)btnAttach).Location = new Point(535, 328);
		((BaseControl)btnAttach).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnAttach).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnAttach).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnAttach).Name = "btnAttach";
		((Control)btnAttach).Size = new Size(106, 32);
		((Control)btnAttach).TabIndex = 1156;
		btnAttach.Text = "&Dattach";
		((BaseControl)btnAttach).ToolTip = "Party Help";
		((Control)btnAttach).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnAttach);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)BtnRestore);
		((Control)this).Controls.Add((Control)(object)btnBkp);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)tSavePath);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_BKP";
		((Form)this).Text = "Backup";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		FolderBrowserDialog val = new FolderBrowserDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			tSavePath.Text = val.SelectedPath;
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
	}

	private void UT_BKP_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0868: Expected O, but got Unknown
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Expected O, but got Unknown
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_0973: Expected O, but got Unknown
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Expected O, but got Unknown
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj8 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)btnBkp).Appearance;
				object? obj9 = colorConverter.ConvertFromString("233, 235, 240");
				appearance2.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AppearanceObject appearance3 = ((BaseStyleControl)BtnRestore).Appearance;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				appearance3.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj11 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj12 = lblBook;
				object? obj13 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				Label label = Label1;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)label).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				TextBox obj15 = tSavePath;
				object? obj16 = colorConverter.ConvertFromString("0, 0, 192");
				((TextBoxBase)obj15).ForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj17 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AppearanceObject appearance4 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj18 = colorConverter.ConvertFromString("Cornsilk");
				appearance4.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AppearanceObject appearance5 = ((BaseStyleControl)btnBkp).Appearance;
				object? obj19 = colorConverter.ConvertFromString("Cornsilk");
				appearance5.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AppearanceObject appearance6 = ((BaseStyleControl)BtnRestore).Appearance;
				object? obj20 = colorConverter.ConvertFromString("Cornsilk");
				appearance6.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AppearanceObject appearance7 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj21 = colorConverter.ConvertFromString("0, 0, 192");
				appearance7.ForeColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AppearanceObject appearance8 = ((BaseStyleControl)btnBkp).Appearance;
				object? obj22 = colorConverter.ConvertFromString("0, 0, 192");
				appearance8.ForeColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AppearanceObject appearance9 = ((BaseStyleControl)BtnRestore).Appearance;
				object? obj23 = colorConverter.ConvertFromString("0, 0, 192");
				appearance9.ForeColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tSavePath).Font.Size * (1.0 + num2));
				Font font = ((Control)tSavePath).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is SimpleButton || val3 is MaskedTextBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
			if (Operators.CompareString(DC_Main.MsSqlDataPath, "", false) != 0)
			{
				((Control)btnAttach).Visible = true;
			}
			tSavePath.Text = Interaction.GetSetting("NEXT SOFTWARE", "BACKUP_DATABASE", "BACKUP_PATH", "");
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
		if (DC_Main.TakeBkp)
		{
			Application.Exit();
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void UT_BKP_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_BKP_KeyPress(object sender, KeyPressEventArgs e)
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

	private void UT_BKP_KeyDown(object sender, KeyEventArgs e)
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

	private void UT_BKP_Closed(object sender, EventArgs e)
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnBkp_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tSavePath.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Path and Try", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Control)ProgressBar1).Visible = true;
		Interaction.SaveSetting("NEXT SOFTWARE", "BACKUP_DATABASE", "BACKUP_PATH", tSavePath.Text);
		Timer1.Enabled = true;
		if (Operators.CompareString(DC_Main.MCo_Type, "", false) != 0)
		{
			string text = (tSavePath.Text + "\\Next" + Strings.Mid(DC_Main.MCo_year, 3, 2) + "_" + DC_Main.MCo_Type + "_" + Strings.Format((object)DateAndTime.Now, "ddMMyy_HH")) ?? "";
			if (Operators.CompareString(FileSystem.Dir(text + ".BAK", (FileAttribute)0), "", false) != 0)
			{
				FileSystem.Kill(text + ".BAK");
			}
			DC_Main.RsQry = "BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + ".BAK'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			text = tSavePath.Text + "\\" + DC_Main.SqlMain;
			if (Operators.CompareString(FileSystem.Dir(text + ".BAK", (FileAttribute)0), "", false) != 0)
			{
				FileSystem.Kill(text + ".BAK");
			}
			DC_Main.RsQry = "BACKUP DATABASE " + DC_Main.SqlMain + " TO DISK ='" + text + ".BAK'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			string text = (tSavePath.Text + "\\Next" + Strings.Mid(DC_Main.MCo_year, 3, 2) + "_" + Strings.Format((object)DateAndTime.Now, "ddMMyy_HH")) ?? "";
			if (Operators.CompareString(FileSystem.Dir(text + ".BAK", (FileAttribute)0), "", false) != 0)
			{
				FileSystem.Kill(text + ".BAK");
			}
			DC_Main.RsQry = "BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + ".BAK'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			text = tSavePath.Text + "\\NextMain";
			if (Operators.CompareString(FileSystem.Dir(text + ".BAK", (FileAttribute)0), "", false) != 0)
			{
				FileSystem.Kill(text + ".BAK");
			}
			DC_Main.RsQry = "BACKUP DATABASE " + DC_Main.SqlMain + " TO DISK ='" + text + ".BAK'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		Interaction.MsgBox((object)"Backup Process Complete.", (MsgBoxStyle)64, (object)null);
	}

	private void BtnRestore_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(((FileDialog)OpenFileDialog1).FileName, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Path and Try", (MsgBoxStyle)0, (object)null);
			return;
		}
		((CommonDialog)OpenFileDialog1).ShowDialog();
		Timer1.Enabled = true;
		((Control)ProgressBar1).Visible = true;
		DC_Main.RsQry = "RESTORE DATABASE " + DC_Main.SqlData + " FROM disk='" + ((FileDialog)OpenFileDialog1).FileName + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		if (ProgressBar1.Value == 100)
		{
			Timer1.Enabled = false;
			((Control)ProgressBar1).Visible = false;
		}
		else
		{
			ProgressBar1.Value = checked(ProgressBar1.Value + 5);
		}
	}

	private void btnAttach_Click(object sender, EventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "USE [master] ALTER DATABASE NextMain SET SINGLE_USER WITH ROLLBACK IMMEDIATE USE [master] EXEC master.dbo.sp_detach_db @dbname = N'NextMain', @skipchecks = 'false'";
		DC_Main.ExeQuteMc(DC_Main.RsQry);
		DC_Main.RsQry = "USE [master] ALTER DATABASE " + DC_Main.SqlData + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE USE [master] EXEC master.dbo.sp_detach_db @dbname = N'" + DC_Main.SqlData + "', @skipchecks = 'false'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		Interaction.MsgBox((object)"De-Attach iS Complite", (MsgBoxStyle)64, (object)null);
		Application.Exit();
	}
}
