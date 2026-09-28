using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using QRCoder;

namespace DataCareNext;

[DesignerGenerated]
public class UT_HDD : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHddNo")]
	private TextBox _tHddNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUpdate")]
	private SimpleButton _btnUpdate;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private virtual SimpleButton _BtnCancel;

	internal virtual SimpleButton BtnCancel
	{
		get
		{
			return _BtnCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnCancel = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private virtual SimpleButton _BtnPrint;

	internal virtual SimpleButton BtnPrint
	{
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnPrint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSrNo1")]
	private virtual TextBox _tSrNo1;

	internal virtual TextBox tSrNo1
	{
		get
		{
			return _tSrNo1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSrNo1 = value;
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
	[AccessedThroughProperty("tSrNo2")]
	private virtual TextBox _tSrNo2;

	internal virtual TextBox tSrNo2
	{
		get
		{
			return _tSrNo2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSrNo2 = value;
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
	[AccessedThroughProperty("PictureBox1")]
	private virtual PictureBox _PictureBox1;

	internal virtual PictureBox PictureBox1
	{
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PictureBox1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox2")]
	private virtual PictureBox _PictureBox2;

	internal virtual PictureBox PictureBox2
	{
		get
		{
			return _PictureBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PictureBox2 = value;
		}
	}

	internal virtual TextBox tHddNo
	{
		[CompilerGenerated]
		get
		{
			return _tHddNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHddNo_KeyDown);
			TextBox val2 = _tHddNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHddNo = value;
			val2 = _tHddNo;
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

	internal virtual SimpleButton btnUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnUpdate_Click;
			SimpleButton val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUpdate = value;
			val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UT_HDD()
	{
		((Form)this).Load += UT_HDD_Load;
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
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected O, but got Unknown
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Expected O, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Expected O, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected O, but got Unknown
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_0933: Expected O, but got Unknown
		//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d6: Expected O, but got Unknown
		//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b95: Expected O, but got Unknown
		//IL_0c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c48: Expected O, but got Unknown
		//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2a: Expected O, but got Unknown
		//IL_0e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0c: Expected O, but got Unknown
		//IL_0ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb2: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_HDD));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		tSrNo1 = new TextBox();
		Label1 = new Label();
		tSrNo2 = new TextBox();
		Label2 = new Label();
		PictureBox1 = new PictureBox();
		PictureBox2 = new PictureBox();
		tHddNo = new TextBox();
		Label3 = new Label();
		btnUpdate = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)PictureBox2).BeginInit();
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
		((Control)PnlBotam).TabIndex = 3;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1219, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(87, 37);
		((Control)BtnExit).TabIndex = 4;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1126, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(87, 37);
		((Control)BtnDelete).TabIndex = 3;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1033, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(87, 37);
		((Control)BtnCancel).TabIndex = 2;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(940, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(87, 37);
		((Control)BtnSave).TabIndex = 1;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(847, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(87, 37);
		((Control)BtnPrint).TabIndex = 0;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)tSrNo1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tSrNo1).BorderStyle = (BorderStyle)0;
		((Control)tSrNo1).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSrNo1).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tSrNo1).Location = new Point(278, 99);
		((TextBoxBase)tSrNo1).MaxLength = 50;
		((Control)tSrNo1).Name = "tSrNo1";
		((Control)tSrNo1).Size = new Size(344, 19);
		((Control)tSrNo1).TabIndex = 1;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(192, 0, 0);
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(188, 97);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(84, 20);
		((Control)Label1).TabIndex = 113;
		Label1.Text = "Sr No 1 :";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSrNo2).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tSrNo2).BorderStyle = (BorderStyle)0;
		((Control)tSrNo2).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSrNo2).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tSrNo2).Location = new Point(780, 97);
		((TextBoxBase)tSrNo2).MaxLength = 50;
		((Control)tSrNo2).Name = "tSrNo2";
		((Control)tSrNo2).Size = new Size(351, 19);
		((Control)tSrNo2).TabIndex = 2;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.FromArgb(192, 0, 0);
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(694, 94);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(76, 20);
		((Control)Label2).TabIndex = 115;
		Label2.Text = "Sr No 2 :";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)PictureBox1).BackColor = Color.White;
		((Control)PictureBox1).Location = new Point(224, 134);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(172, 144);
		PictureBox1.SizeMode = (PictureBoxSizeMode)3;
		PictureBox1.TabIndex = 116;
		PictureBox1.TabStop = false;
		((Control)PictureBox2).BackColor = Color.White;
		((Control)PictureBox2).Location = new Point(720, 134);
		((Control)PictureBox2).Name = "PictureBox2";
		((Control)PictureBox2).Size = new Size(170, 144);
		PictureBox2.SizeMode = (PictureBoxSizeMode)3;
		PictureBox2.TabIndex = 117;
		PictureBox2.TabStop = false;
		((TextBoxBase)tHddNo).BackColor = SystemColors.ButtonHighlight;
		((Control)tHddNo).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tHddNo).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tHddNo).Location = new Point(502, 252);
		((TextBoxBase)tHddNo).MaxLength = 50;
		((Control)tHddNo).Name = "tHddNo";
		((Control)tHddNo).Size = new Size(130, 26);
		((Control)tHddNo).TabIndex = 0;
		tHddNo.TextAlign = (HorizontalAlignment)2;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.FromArgb(192, 0, 0);
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(527, 216);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(84, 20);
		((Control)Label3).TabIndex = 119;
		Label3.Text = "Hdd No";
		Label3.TextAlign = (ContentAlignment)32;
		((BaseStyleControl)btnUpdate).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnUpdate).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnUpdate).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnUpdate).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnUpdate).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnUpdate).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnUpdate).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnUpdate).Appearance.Options.UseForeColor = true;
		((BaseButton)btnUpdate).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnUpdate).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnUpdate).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnUpdate).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnUpdate).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnUpdate).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnUpdate).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnUpdate).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnUpdate).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnUpdate).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnUpdate).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnUpdate).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnUpdate).AppearancePressed.Options.UseFont = true;
		((Control)btnUpdate).Location = new Point(505, 306);
		((BaseControl)btnUpdate).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnUpdate).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnUpdate).Name = "btnUpdate";
		((Control)btnUpdate).Size = new Size(127, 32);
		((Control)btnUpdate).TabIndex = 120;
		btnUpdate.Text = "Hdd Update";
		((BaseControl)btnUpdate).ToolTip = "Party Help";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnUpdate);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHddNo);
		((Control)this).Controls.Add((Control)(object)PictureBox2);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)tSrNo2);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tSrNo1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Name = "UT_HDD";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Pc Registrar No";
		((Form)this).WindowState = (FormWindowState)2;
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)PictureBox2).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void UT_HDD_Load(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		DC_Main.MainPcW = 1366.0;
		DC_Main.MainPcH = 768.0;
		DC_Main.PcW = Screen.PrimaryScreen.Bounds.Width;
		DC_Main.PcH = Screen.PrimaryScreen.Bounds.Height;
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		checked
		{
			if (unchecked(num != 0.0 && num2 != 0.0))
			{
				((Control)this).Width = (int)Math.Round(DC_Main.PcW);
				((Control)this).Height = (int)Math.Round(DC_Main.PcH);
			}
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
			tSrNo1.Text = SystemSerialNumber();
			tSrNo2.Text = GetHDSerialNo("C");
			QRCodeGenerator val3 = new QRCodeGenerator();
			QRCodeData val4 = val3.CreateQrCode(tSrNo1.Text, (ECCLevel)2, false, false, (EciMode)0, -1);
			QRCode val5 = new QRCode(val4);
			PictureBox1.Image = (Image)(object)val5.GetGraphic(6);
			val4 = val3.CreateQrCode(tSrNo2.Text, (ECCLevel)2, false, false, (EciMode)0, -1);
			QRCode val6 = new QRCode(val4);
			PictureBox2.Image = (Image)(object)val6.GetGraphic(6);
		}
	}

	private string GetHDSerialNo(string strDrive)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		if (Operators.CompareString(strDrive, "", false) == 0 || strDrive == null)
		{
			strDrive = "C";
		}
		ManagementObject val = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + strDrive + ":\"");
		val.Get();
		return ((ManagementBaseObject)val)["VolumeSerialNumber"].ToString();
	}

	private string SystemSerialNumber()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		string text = "";
		ManagementClass val = new ManagementClass("Win32_BaseBoard");
		ManagementObjectCollection instances = val.GetInstances();
		if (instances.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"A", NewLateBinding.LateIndexGet(((IEnumerable)instances).Cast<object>().ElementAtOrDefault(0), new object[1] { "SerialNumber" }, (string[])null)), (object)"Z"));
			if (text.Length > 0)
			{
				text = text.ToString();
			}
		}
		return text;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void tHddNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.ExeQuteDc("DELETE FROM HDD_MAST");
		DC_Main.RsQry = "INSERT INTO HDD_MAST (REF_NO) VALUES  ('" + tHddNo.Text + "')";
		DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		Interaction.MsgBox((object)"Hdd Is Update...", (MsgBoxStyle)0, (object)null);
		((Form)this).Close();
	}
}
