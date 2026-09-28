using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class UT_PWD_UPDATE : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tOldPasword")]
	private TextBox _tOldPasword;

	private DataTable RsMast;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConPasword")]
	private virtual TextBox _tConPasword;

	internal virtual TextBox tConPasword
	{
		get
		{
			return _tConPasword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tConPasword = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPasword")]
	private virtual TextBox _tPasword;

	internal virtual TextBox tPasword
	{
		get
		{
			return _tPasword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPasword = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUserName")]
	private virtual TextBox _tUserName;

	internal virtual TextBox tUserName
	{
		get
		{
			return _tUserName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUserName = value;
		}
	}

	internal virtual TextBox tOldPasword
	{
		[CompilerGenerated]
		get
		{
			return _tOldPasword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CancelEventHandler cancelEventHandler = tOldPasword_Validating;
			TextBox val = _tOldPasword;
			if (val != null)
			{
				((Control)val).Validating -= cancelEventHandler;
			}
			_tOldPasword = value;
			val = _tOldPasword;
			if (val != null)
			{
				((Control)val).Validating += cancelEventHandler;
			}
		}
	}

	public UT_PWD_UPDATE()
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
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Expected O, but got Unknown
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Expected O, but got Unknown
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Expected O, but got Unknown
		//IL_094c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Expected O, but got Unknown
		//IL_0a07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Expected O, but got Unknown
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Expected O, but got Unknown
		//IL_0b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Expected O, but got Unknown
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Expected O, but got Unknown
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Expected O, but got Unknown
		//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d50: Expected O, but got Unknown
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		tSrNo1 = new TextBox();
		tSrNo2 = new TextBox();
		Label4 = new Label();
		Label3 = new Label();
		Label1 = new Label();
		Label2 = new Label();
		tConPasword = new TextBox();
		tPasword = new TextBox();
		tUserName = new TextBox();
		tOldPasword = new TextBox();
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
		((Control)PnlBotam).TabIndex = 3;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
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
		((TextBoxBase)tSrNo2).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tSrNo2).BorderStyle = (BorderStyle)0;
		((Control)tSrNo2).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSrNo2).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tSrNo2).Location = new Point(780, 97);
		((TextBoxBase)tSrNo2).MaxLength = 50;
		((Control)tSrNo2).Name = "tSrNo2";
		((Control)tSrNo2).Size = new Size(351, 19);
		((Control)tSrNo2).TabIndex = 2;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(369, 266);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(124, 20);
		((Control)Label4).TabIndex = 128;
		Label4.Text = "Confirm Password";
		Label4.TextAlign = (ContentAlignment)16;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(369, 229);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(124, 20);
		((Control)Label3).TabIndex = 127;
		Label3.Text = "New Password";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(369, 193);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(124, 20);
		((Control)Label1).TabIndex = 126;
		Label1.Text = "Old Password";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(369, 158);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(124, 20);
		((Control)Label2).TabIndex = 125;
		Label2.Text = "Create New User";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tConPasword).BackColor = Color.White;
		((Control)tConPasword).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tConPasword).Location = new Point(505, 266);
		((TextBoxBase)tConPasword).MaxLength = 15;
		((Control)tConPasword).Name = "tConPasword";
		tConPasword.PasswordChar = '*';
		((Control)tConPasword).Size = new Size(184, 22);
		((Control)tConPasword).TabIndex = 124;
		((TextBoxBase)tPasword).BackColor = Color.White;
		((Control)tPasword).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPasword).Location = new Point(505, 229);
		((TextBoxBase)tPasword).MaxLength = 15;
		((Control)tPasword).Name = "tPasword";
		tPasword.PasswordChar = '*';
		((Control)tPasword).Size = new Size(184, 22);
		((Control)tPasword).TabIndex = 123;
		((TextBoxBase)tUserName).BackColor = Color.White;
		((Control)tUserName).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tUserName).Location = new Point(505, 158);
		((TextBoxBase)tUserName).MaxLength = 15;
		((Control)tUserName).Name = "tUserName";
		((Control)tUserName).Size = new Size(184, 22);
		((Control)tUserName).TabIndex = 121;
		((TextBoxBase)tOldPasword).BackColor = Color.White;
		((Control)tOldPasword).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tOldPasword).Location = new Point(505, 193);
		((TextBoxBase)tOldPasword).MaxLength = 15;
		((Control)tOldPasword).Name = "tOldPasword";
		tOldPasword.PasswordChar = '*';
		((Control)tOldPasword).Size = new Size(184, 22);
		((Control)tOldPasword).TabIndex = 122;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tConPasword);
		((Control)this).Controls.Add((Control)(object)tPasword);
		((Control)this).Controls.Add((Control)(object)tUserName);
		((Control)this).Controls.Add((Control)(object)tOldPasword);
		((Control)this).Controls.Add((Control)(object)tSrNo2);
		((Control)this).Controls.Add((Control)(object)tSrNo1);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Name = "UT_PWD_UPDATE";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Pc Registrar No";
		((Form)this).WindowState = (FormWindowState)2;
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void UT_HDD_Load(object sender, EventArgs e)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
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
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '01' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			tUserName.Text = DC_Main.MCo_User;
			((TextBoxBase)tUserName).ReadOnly = true;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tPasword.Text, tConPasword.Text, false) != 0)
		{
			Interaction.MsgBox((object)"Password and Conform Password is Not Same", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "UPDATE LOGIN_MAST SET LOGIN_PWD = '" + tPasword.Text + "' WHERE LOGIN_NAME = '" + tUserName.Text + "'";
		DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		Interaction.MsgBox((object)"Password Is Update...Please Re Open Software...", (MsgBoxStyle)0, (object)null);
		tOldPasword.Text = "";
		tPasword.Text = "";
		tConPasword.Text = "";
		Application.Exit();
	}

	private void tOldPasword_Validating(object sender, CancelEventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " LOGIN_NAME = '" + tUserName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["LOGIN_PWD"], (object)"", false))
			{
				if (Operators.CompareString(tOldPasword.Text, "", false) == 0)
				{
					Interaction.MsgBox((object)"Please Insert Old Password", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					((Control)tOldPasword).Focus();
					return;
				}
				if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["LOGIN_PWD"], (object)tOldPasword.Text, false))
				{
					Interaction.MsgBox((object)"Old Password Doesn't Match", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					((Control)tOldPasword).Focus();
					((TextBoxBase)tOldPasword).SelectAll();
					return;
				}
				cancel = false;
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}
}
