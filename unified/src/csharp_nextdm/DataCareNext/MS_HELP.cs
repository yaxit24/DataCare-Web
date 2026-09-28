using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_HELP : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblExit")]
	private Label _LblExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private DataGridViewX _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearchText")]
	private TextBox _tSearchText;

	private int HelpWidth;

	private DataTable dtTableGrd;

	private double ColCon;

	private int ColNumber;

	internal virtual Label LblExit
	{
		[CompilerGenerated]
		get
		{
			return _LblExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = LblExit_Click;
			Label val = _LblExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_LblExit = value;
			val = _LblExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblHelpName")]
	private virtual Label _LblHelpName;

	internal virtual Label LblHelpName
	{
		get
		{
			return _LblHelpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblHelpName = value;
		}
	}

	internal virtual DataGridViewX MSG
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(MSG_CellContentDoubleClick);
			KeyEventHandler val2 = new KeyEventHandler(MSG_KeyDown);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(MSG_CellContentClick);
			KeyPressEventHandler val4 = new KeyPressEventHandler(MSG_KeyPress);
			EventHandler eventHandler = MSG_Click;
			DataGridViewX val5 = _MSG;
			if (val5 != null)
			{
				((DataGridView)val5).CellDoubleClick -= val;
				((Control)val5).KeyDown -= val2;
				((DataGridView)val5).CellContentClick -= val3;
				((Control)val5).KeyPress -= val4;
				((Control)val5).Click -= eventHandler;
			}
			_MSG = value;
			val5 = _MSG;
			if (val5 != null)
			{
				((DataGridView)val5).CellDoubleClick += val;
				((Control)val5).KeyDown += val2;
				((DataGridView)val5).CellContentClick += val3;
				((Control)val5).KeyPress += val4;
				((Control)val5).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tSearchText
	{
		[CompilerGenerated]
		get
		{
			return _tSearchText;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tSearchText_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tSearchText_KeyDown);
			TextBox val2 = _tSearchText;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tSearchText = value;
			val2 = _tSearchText;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	public MS_HELP()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((Form)this).Load += MS_HELP_Load;
		((Control)this).KeyDown += new KeyEventHandler(MS_HELP_KeyDown);
		((Control)this).KeyPress += new KeyPressEventHandler(MS_HELP_KeyPress);
		((Form)this).Activated += MS_HELP_Activated;
		((Form)this).Closed += MS_HELP_Closed;
		HelpWidth = 0;
		ColNumber = 0;
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_HELP));
		tSearchText = new TextBox();
		MSG = new DataGridViewX();
		LblExit = new Label();
		LblHelpName = new Label();
		((ISupportInitialize)MSG).BeginInit();
		((Control)this).SuspendLayout();
		((TextBoxBase)tSearchText).BackColor = Color.Tan;
		((TextBoxBase)tSearchText).BorderStyle = (BorderStyle)0;
		tSearchText.CharacterCasing = (CharacterCasing)1;
		((Control)tSearchText).Font = new Font("Verdana", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSearchText).ForeColor = Color.White;
		((Control)tSearchText).Location = new Point(18, 244);
		((Control)tSearchText).Name = "tSearchText";
		((Control)tSearchText).Size = new Size(701, 16);
		((Control)tSearchText).TabIndex = 1;
		((Control)MSG).AllowDrop = true;
		((DataGridView)MSG).AllowUserToAddRows = false;
		((DataGridView)MSG).AllowUserToDeleteRows = false;
		((DataGridView)MSG).AllowUserToOrderColumns = true;
		((DataGridView)MSG).AllowUserToResizeRows = false;
		val.BackColor = SystemColors.Control;
		val.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)MSG).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)MSG).BackgroundColor = SystemColors.ButtonHighlight;
		((DataGridView)MSG).BorderStyle = (BorderStyle)2;
		((DataGridView)MSG).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)MSG).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)MSG).ColumnHeadersHeight = 25;
		((DataGridView)MSG).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)MSG).DefaultCellStyle = val3;
		((DataGridView)MSG).EnableHeadersVisualStyles = false;
		((DataGridView)MSG).GridColor = Color.FromArgb(208, 215, 229);
		((Control)MSG).Location = new Point(14, 28);
		((Control)MSG).Name = "MSG";
		MSG.PaintEnhancedSelection = false;
		((DataGridView)MSG).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)MSG).RowHeadersDefaultCellStyle = val4;
		((DataGridView)MSG).RowHeadersVisible = false;
		((DataGridView)MSG).RowHeadersWidth = 10;
		val5.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((DataGridView)MSG).RowsDefaultCellStyle = val5;
		MSG.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)MSG).ScrollBars = (ScrollBars)2;
		((DataGridView)MSG).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)MSG).Size = new Size(705, 209);
		((DataGridView)MSG).StandardTab = true;
		((Control)MSG).TabIndex = 0;
		LblExit.AutoSize = true;
		((Control)LblExit).BackColor = Color.Transparent;
		((Control)LblExit).Font = new Font("Verdana", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblExit).ForeColor = Color.White;
		((Control)LblExit).Location = new Point(706, 5);
		((Control)LblExit).Name = "LblExit";
		((Control)LblExit).Size = new Size(18, 18);
		((Control)LblExit).TabIndex = 3;
		LblExit.Text = "X";
		LblHelpName.AutoSize = true;
		((Control)LblHelpName).BackColor = Color.Transparent;
		((Control)LblHelpName).Font = new Font("Verdana", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblHelpName).ForeColor = Color.White;
		((Control)LblHelpName).Location = new Point(12, 5);
		((Control)LblHelpName).Name = "LblHelpName";
		((Control)LblHelpName).Size = new Size(115, 18);
		((Control)LblHelpName).TabIndex = 4;
		LblHelpName.Text = "DataCare Help";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.Tan;
		((Control)this).BackgroundImageLayout = (ImageLayout)3;
		((Form)this).ClientSize = new Size(734, 268);
		((Control)this).Controls.Add((Control)(object)LblHelpName);
		((Control)this).Controls.Add((Control)(object)LblExit);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)tSearchText);
		((Control)this).DoubleBuffered = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "MS_HELP";
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "DataCare HD Help";
		((ISupportInitialize)MSG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_HELP_Load(object sender, EventArgs e)
	{
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected O, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Expected O, but got Unknown
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		double num7 = default(double);
		double num8 = default(double);
		IEnumerator enumerator = default(IEnumerator);
		Control val = default(Control);
		ColorConverter colorConverter = default(ColorConverter);
		int num9 = default(int);
		int num10 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					object? obj;
					DataGridViewX mSG;
					object? obj2;
					object? obj3;
					DataGridViewX mSG2;
					object? obj4;
					DataGridViewCellStyle alternatingRowsDefaultCellStyle;
					object? obj5;
					DataGridViewX mSG3;
					object? obj6;
					DataGridViewCellStyle alternatingRowsDefaultCellStyle2;
					object? obj7;
					object? obj8;
					DataGridViewX mSG4;
					object? obj9;
					DataGridViewCellStyle alternatingRowsDefaultCellStyle3;
					object? obj10;
					Control val2;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						((Control)this).SuspendLayout();
						goto IL_000b;
					case 4566:
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
								goto IL_0014;
							case 4:
								goto IL_0028;
							case 5:
								goto IL_003d;
							case 6:
								goto IL_0050;
							case 7:
								goto IL_0072;
							case 8:
								goto IL_0097;
							case 9:
								goto IL_00bd;
							case 10:
								goto IL_00e3;
							case 11:
								goto IL_010a;
							case 12:
								goto IL_011d;
							case 13:
								goto IL_0136;
							case 14:
								goto IL_0140;
							case 15:
								goto IL_0154;
							case 16:
								goto IL_017f;
							case 17:
								goto IL_0194;
							case 18:
								goto IL_01c4;
							case 20:
								goto IL_01e3;
							case 21:
								goto IL_01f7;
							case 22:
								goto IL_0222;
							case 23:
								goto IL_0237;
							case 24:
								goto IL_0267;
							case 26:
								goto IL_02a2;
							case 27:
								goto IL_02b6;
							case 28:
								goto IL_02c5;
							case 29:
								goto IL_02da;
							case 30:
								goto IL_030a;
							case 32:
								goto IL_0345;
							case 33:
								goto IL_0359;
							case 34:
								goto IL_0384;
							case 35:
								goto IL_0399;
							case 36:
								goto IL_03c9;
							case 19:
							case 25:
							case 31:
							case 37:
							case 38:
								goto IL_03ff;
							case 39:
								goto IL_0409;
							case 40:
								goto IL_0419;
							case 41:
								goto IL_0428;
							case 42:
								goto IL_043c;
							case 43:
								goto IL_0450;
							case 44:
								goto IL_045f;
							case 45:
								goto IL_046f;
							case 46:
								goto IL_0483;
							case 47:
								goto IL_048c;
							case 48:
								goto IL_04aa;
							case 49:
								goto IL_04c9;
							case 50:
								goto IL_04f1;
							case 51:
								goto IL_0519;
							case 52:
								goto IL_0541;
							case 53:
								goto IL_055d;
							case 54:
							case 55:
							case 56:
								goto IL_057a;
							case 57:
								goto IL_058e;
							case 58:
								goto IL_05b6;
							case 59:
								goto IL_05cf;
							case 60:
							case 61:
								goto IL_05ea;
							case 62:
								goto IL_0621;
							case 63:
								goto IL_0642;
							case 64:
								goto IL_0664;
							case 65:
								goto IL_0695;
							case 66:
							case 67:
								goto IL_06c8;
							case 68:
								goto IL_06ef;
							case 69:
								goto IL_071b;
							case 70:
								goto IL_073c;
							case 71:
								goto IL_0768;
							case 72:
								goto IL_0794;
							case 73:
							case 74:
								goto IL_07bc;
							case 75:
								goto IL_07c6;
							case 76:
								goto IL_07e4;
							case 77:
								goto IL_0814;
							case 78:
								goto IL_0830;
							case 79:
								goto IL_084c;
							case 80:
								goto IL_086c;
							case 81:
								goto IL_0875;
							case 82:
								goto IL_08ae;
							case 83:
								goto IL_08d4;
							case 84:
								goto IL_08dd;
							case 85:
								goto IL_08ff;
							case 86:
								goto IL_0935;
							case 88:
								goto IL_095d;
							case 89:
								goto IL_0993;
							case 91:
								goto IL_09bb;
							case 92:
								goto IL_09f1;
							case 93:
								goto IL_0a13;
							case 95:
								goto IL_0a3b;
							case 96:
								goto IL_0a71;
							case 97:
								goto IL_0a93;
							case 87:
							case 90:
							case 94:
							case 98:
							case 99:
								goto IL_0ab9;
							case 100:
								goto IL_0acb;
							case 101:
								goto IL_0adc;
							case 102:
								goto IL_0af4;
							case 103:
								goto IL_0b0c;
							case 104:
								goto IL_0b28;
							case 105:
								goto IL_0b44;
							case 106:
								goto IL_0b5e;
							case 107:
								goto IL_0b8b;
							case 108:
								goto IL_0bb0;
							case 109:
								goto IL_0bca;
							case 110:
								goto IL_0bdb;
							case 111:
								goto IL_0bf8;
							case 112:
								goto IL_0c09;
							case 113:
								goto IL_0c23;
							case 114:
								goto IL_0c43;
							case 115:
								goto IL_0c75;
							case 116:
								goto IL_0c86;
							case 118:
								goto IL_0cb0;
							case 117:
							case 119:
							case 120:
								goto IL_0ce3;
							case 122:
								goto IL_0cf3;
							case 123:
								goto IL_0d0c;
							case 124:
								goto IL_0d1d;
							case 125:
								goto IL_0d2e;
							case 126:
								goto IL_0d46;
							case 127:
								goto IL_0d5e;
							case 128:
								goto IL_0d83;
							case 129:
								goto IL_0da0;
							case 130:
								goto IL_0db4;
							case 131:
								goto IL_0dd4;
							case 132:
								goto IL_0de8;
							case 133:
								goto IL_0e05;
							case 134:
								goto IL_0e19;
							case 135:
								goto IL_0e22;
							case 136:
								goto IL_0e2e;
							case 137:
								goto IL_0e44;
							case 138:
								goto IL_0e5f;
							case 139:
								goto IL_0e72;
							case 140:
								goto IL_0e89;
							case 141:
								goto IL_0ea0;
							case 121:
							case 142:
							case 143:
								goto IL_0eb3;
							case 144:
								goto IL_0eeb;
							case 145:
								goto IL_0f23;
							case 146:
								goto IL_0f42;
							case 147:
							case 148:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 149:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0a13:
						num2 = 93;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Format = "0.00";
						goto IL_0ab9;
						IL_0a3b:
						num2 = 95;
						if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num5].ColumnName, num6, num6), "W", false) == 0)
						{
							goto IL_0a71;
						}
						goto IL_0ab9;
						IL_09f1:
						num2 = 92;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0a13;
						IL_0a71:
						num2 = 96;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0a93;
						IL_000b:
						num2 = 2;
						((Control)this).ResumeLayout();
						goto IL_0014;
						IL_0014:
						num2 = 3;
						num7 = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
						goto IL_0028;
						IL_0028:
						num2 = 4;
						num8 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
						goto IL_003d;
						IL_003d:
						num2 = 5;
						ColCon = 1.0 + num7;
						goto IL_0050;
						IL_0050:
						num2 = 6;
						enumerator = ((Control)this).Controls.GetEnumerator();
						goto IL_010d;
						IL_010d:
						if (enumerator.MoveNext())
						{
							val = (Control)enumerator.Current;
							goto IL_0072;
						}
						goto IL_011d;
						IL_011d:
						num2 = 12;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto IL_0136;
						IL_0ab9:
						num2 = 99;
						num5++;
						goto IL_0ac2;
						IL_0136:
						num2 = 13;
						colorConverter = new ColorConverter();
						goto IL_0140;
						IL_0140:
						num2 = 14;
						if (DC_Main.MsCoTheme == 1)
						{
							goto IL_0154;
						}
						goto IL_01e3;
						IL_0154:
						num2 = 15;
						obj = colorConverter.ConvertFromString("Tan");
						((Form)this).BackColor = ((obj != null) ? ((Color)obj) : default(Color));
						goto IL_017f;
						IL_0d0c:
						num2 = 123;
						DC_Main.DgvRowHight = 13.0;
						goto IL_0d1d;
						IL_0d1d:
						num2 = 124;
						((Control)MSG).Top = 32;
						goto IL_0d2e;
						IL_0cf3:
						num2 = 122;
						if (DC_Main.DgvRowHight == 0.0)
						{
							goto IL_0d0c;
						}
						goto IL_0d1d;
						IL_017f:
						num2 = 16;
						((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
						goto IL_0194;
						IL_0194:
						num2 = 17;
						mSG = MSG;
						obj2 = colorConverter.ConvertFromString("SeaShell");
						((DataGridView)mSG).BackgroundColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
						goto IL_01c4;
						IL_0d46:
						num2 = 126;
						((Control)MSG).Height = ((Control)this).Height - 65;
						goto IL_0d5e;
						IL_0d5e:
						num2 = 127;
						((Control)MSG).Left = (int)Math.Round(15.0 * ColCon);
						goto IL_0d83;
						IL_0d2e:
						num2 = 125;
						((Control)MSG).Width = HelpWidth + 25;
						goto IL_0d46;
						IL_01c4:
						num2 = 18;
						((DataGridView)MSG).AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
						goto IL_03ff;
						IL_01e3:
						num2 = 20;
						if (DC_Main.MsCoTheme == 2)
						{
							goto IL_01f7;
						}
						goto IL_02a2;
						IL_01f7:
						num2 = 21;
						obj3 = colorConverter.ConvertFromString("Gray");
						((Form)this).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
						goto IL_0222;
						IL_0da0:
						num2 = 129;
						((Control)LblHelpName).Top = 9;
						goto IL_0db4;
						IL_0db4:
						num2 = 130;
						((Control)LblExit).Left = ((Control)MSG).Right - 20;
						goto IL_0dd4;
						IL_0d83:
						num2 = 128;
						((Control)LblHelpName).Left = ((Control)MSG).Left;
						goto IL_0da0;
						IL_0222:
						num2 = 22;
						((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
						goto IL_0237;
						IL_0237:
						num2 = 23;
						mSG2 = MSG;
						obj4 = colorConverter.ConvertFromString("174, 184, 194");
						((DataGridView)mSG2).BackgroundColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
						goto IL_0267;
						IL_0de8:
						num2 = 132;
						((Control)tSearchText).Width = ((Control)MSG).Width;
						goto IL_0e05;
						IL_0e05:
						num2 = 133;
						DC_Main.DgvRowHight = 0.0;
						goto IL_0e19;
						IL_0dd4:
						num2 = 131;
						((Control)LblExit).Top = 9;
						goto IL_0de8;
						IL_0267:
						num2 = 24;
						alternatingRowsDefaultCellStyle = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
						obj5 = colorConverter.ConvertFromString("243, 240, 239");
						alternatingRowsDefaultCellStyle.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
						goto IL_03ff;
						IL_0e22:
						num2 = 135;
						DC_Main.X = 0;
						goto IL_0e2e;
						IL_0e2e:
						num2 = 136;
						DC_Main.ColValue[DC_Main.X] = "";
						goto IL_0e44;
						IL_0e19:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0e22;
						IL_02a2:
						num2 = 26;
						if (DC_Main.MsCoTheme == 3)
						{
							goto IL_02b6;
						}
						goto IL_0345;
						IL_02b6:
						num2 = 27;
						((Form)this).BackColor = Color.LightSlateGray;
						goto IL_02c5;
						IL_02c5:
						num2 = 28;
						((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
						goto IL_02da;
						IL_02da:
						num2 = 29;
						mSG3 = MSG;
						obj6 = colorConverter.ConvertFromString("174, 184, 194");
						((DataGridView)mSG3).BackgroundColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
						goto IL_030a;
						IL_0e5f:
						num2 = 138;
						((DataGridView)MSG).DataSource = null;
						goto IL_0e72;
						IL_0e72:
						num2 = 139;
						((DataGridView)MSG).Rows.Clear();
						goto IL_0e89;
						IL_0e44:
						num2 = 137;
						DC_Main.X++;
						if (DC_Main.X <= 10)
						{
							goto IL_0e2e;
						}
						goto IL_0e5f;
						IL_030a:
						num2 = 30;
						alternatingRowsDefaultCellStyle2 = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
						obj7 = colorConverter.ConvertFromString("233, 235, 240");
						alternatingRowsDefaultCellStyle2.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
						goto IL_03ff;
						IL_0ea0:
						num2 = 141;
						((Control)MSG).Refresh();
						goto IL_0eb3;
						IL_0eb3:
						num2 = 143;
						((Control)this).Left = (int)Math.Round((double)(Screen.PrimaryScreen.WorkingArea.Width - ((Control)this).Width) / 2.0);
						goto IL_0eeb;
						IL_0e89:
						num2 = 140;
						((DataGridView)MSG).Columns.Clear();
						goto IL_0ea0;
						IL_0345:
						num2 = 32;
						if (DC_Main.MsCoTheme == 4)
						{
							goto IL_0359;
						}
						goto IL_03ff;
						IL_0359:
						num2 = 33;
						obj8 = colorConverter.ConvertFromString("CadetBlue");
						((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
						goto IL_0384;
						IL_0f23:
						num2 = 145;
						if (Operators.CompareString(DC_Main.MsMobileLen, "", false) == 0)
						{
							break;
						}
						goto IL_0f42;
						IL_0f42:
						num2 = 146;
						tSearchText.Text = DC_Main.MsMobileLen;
						break;
						IL_0eeb:
						num2 = 144;
						((Control)this).Top = (int)Math.Round((double)(Screen.PrimaryScreen.WorkingArea.Height - ((Control)this).Height) / 2.0);
						goto IL_0f23;
						IL_0384:
						num2 = 34;
						((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
						goto IL_0399;
						IL_0399:
						num2 = 35;
						mSG4 = MSG;
						obj9 = colorConverter.ConvertFromString("Ivory");
						((DataGridView)mSG4).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
						goto IL_03c9;
						IL_0072:
						num2 = 7;
						(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num7);
						goto IL_0097;
						IL_0097:
						num2 = 8;
						(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num8);
						goto IL_00bd;
						IL_0a93:
						num2 = 97;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Format = "0.000";
						goto IL_0ab9;
						IL_03c9:
						num2 = 36;
						alternatingRowsDefaultCellStyle3 = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
						obj10 = colorConverter.ConvertFromString("238, 244, 236");
						alternatingRowsDefaultCellStyle3.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
						goto IL_03ff;
						IL_00e3:
						num2 = 10;
						(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num8);
						goto IL_010a;
						IL_010a:
						num2 = 11;
						goto IL_010d;
						IL_00bd:
						num2 = 9;
						(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num7);
						goto IL_00e3;
						IL_03ff:
						num2 = 38;
						ColNumber = 0;
						goto IL_0409;
						IL_0409:
						num2 = 39;
						((DataGridView)MSG).DataSource = null;
						goto IL_0419;
						IL_0419:
						num2 = 40;
						((DataGridView)MSG).ClearSelection();
						goto IL_0428;
						IL_0428:
						num2 = 41;
						((DataGridView)MSG).Columns.Clear();
						goto IL_043c;
						IL_043c:
						num2 = 42;
						((DataGridView)MSG).Rows.Clear();
						goto IL_0450;
						IL_0450:
						num2 = 43;
						((Control)MSG).Refresh();
						goto IL_045f;
						IL_045f:
						num2 = 44;
						((DataGridView)MSG).MultiSelect = false;
						goto IL_046f;
						IL_046f:
						num2 = 45;
						tSearchText.Text = "";
						goto IL_0483;
						IL_0483:
						num2 = 46;
						DC_Main.HelpClose = false;
						goto IL_048c;
						IL_048c:
						num2 = 47;
						if (DC_Main.RsDg.Rows.Count > 0)
						{
							goto IL_04aa;
						}
						goto IL_0cf3;
						IL_04aa:
						num2 = 48;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_04c9;
						}
						goto IL_057a;
						IL_04c9:
						num2 = 49;
						((DataGridView)MSG).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_04f1;
						IL_04f1:
						num2 = 50;
						((DataGridView)MSG).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0519;
						IL_0519:
						num2 = 51;
						((DataGridView)MSG).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0541;
						IL_0541:
						num2 = 52;
						if (Operators.CompareString(DC_Main.MsMainFontChange, "N", false) == 0)
						{
							goto IL_055d;
						}
						goto IL_057a;
						IL_055d:
						num2 = 53;
						((DataGridView)MSG).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_057a;
						IL_057a:
						num2 = 56;
						((DataGridView)MSG).DataSource = DC_Main.RsDg;
						goto IL_058e;
						IL_058e:
						num2 = 57;
						if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.RsDg != null))
						{
							goto IL_05b6;
						}
						goto IL_07bc;
						IL_05b6:
						num2 = 58;
						if (DC_Main.DgvRowHight == 0.0)
						{
							goto IL_05cf;
						}
						goto IL_05ea;
						IL_05cf:
						num2 = 59;
						DC_Main.DgvRowHight = ((DataGridView)MSG).RowTemplate.Height;
						goto IL_05ea;
						IL_05ea:
						num2 = 61;
						if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num8 > 1.0))
						{
							goto IL_0621;
						}
						goto IL_06c8;
						IL_0621:
						num2 = 62;
						num9 = (int)Math.Ceiling(10.0 * (1.0 + num8));
						goto IL_0642;
						IL_0642:
						num2 = 63;
						((DataGridView)MSG).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)num9, (FontStyle)1);
						goto IL_0664;
						IL_0664:
						num2 = 64;
						((DataGridView)MSG).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num9, ((DataGridView)MSG).Font.Style);
						goto IL_0695;
						IL_0695:
						num2 = 65;
						((DataGridView)MSG).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num9, ((DataGridView)MSG).Font.Style);
						goto IL_06c8;
						IL_06c8:
						num2 = 67;
						((DataGridView)MSG).ColumnHeadersHeight = (int)Math.Round(DC_Main.DgvRowHight * (1.0 + num8));
						goto IL_06ef;
						IL_06ef:
						num2 = 68;
						((DataGridView)MSG).RowTemplate.Height = (int)Math.Round(DC_Main.DgvRowHight * (1.0 + num8));
						goto IL_071b;
						IL_071b:
						num2 = 69;
						num9 = (int)Math.Ceiling(9.0 * (1.0 + num8));
						goto IL_073c;
						IL_073c:
						num2 = 70;
						((Control)LblHelpName).Font = new Font("Arial", (float)num9, ((Control)LblHelpName).Font.Style);
						goto IL_0768;
						IL_0768:
						num2 = 71;
						((Control)tSearchText).Font = new Font("Arial", (float)num9, ((Control)tSearchText).Font.Style);
						goto IL_0794;
						IL_0794:
						num2 = 72;
						((Control)this).Height = (int)Math.Round(268.0 * (1.0 + num8));
						goto IL_07bc;
						IL_07bc:
						num2 = 74;
						HelpWidth = 0;
						goto IL_07c6;
						IL_07c6:
						num2 = 75;
						num10 = DC_Main.RsDg.Columns.Count - 1;
						num5 = 0;
						goto IL_0ac2;
						IL_0ac2:
						if (num5 <= num10)
						{
							goto IL_07e4;
						}
						goto IL_0acb;
						IL_0acb:
						num2 = 100;
						((Control)MSG).Top = 32;
						goto IL_0adc;
						IL_0adc:
						num2 = 101;
						((Control)MSG).Width = HelpWidth + 25;
						goto IL_0af4;
						IL_0af4:
						num2 = 102;
						((Control)MSG).Height = ((Control)this).Height - 65;
						goto IL_0b0c;
						IL_0b0c:
						num2 = 103;
						((Control)tSearchText).Top = ((Control)MSG).Bottom + 7;
						goto IL_0b28;
						IL_0b28:
						num2 = 104;
						((Control)tSearchText).Left = ((Control)MSG).Left + 5;
						goto IL_0b44;
						IL_0b44:
						num2 = 105;
						((Control)tSearchText).Width = ((Control)MSG).Width;
						goto IL_0b5e;
						IL_0b5e:
						num2 = 106;
						((Control)this).Width = (int)Math.Round((double)((Control)MSG).Width + 30.0 * ColCon);
						goto IL_0b8b;
						IL_0b8b:
						num2 = 107;
						((Control)MSG).Left = (int)Math.Round(15.0 * ColCon);
						goto IL_0bb0;
						IL_0bb0:
						num2 = 108;
						((Control)LblHelpName).Left = ((Control)MSG).Left;
						goto IL_0bca;
						IL_0bca:
						num2 = 109;
						((Control)LblHelpName).Top = 9;
						goto IL_0bdb;
						IL_0bdb:
						num2 = 110;
						((Control)LblExit).Left = ((Control)MSG).Right - 20;
						goto IL_0bf8;
						IL_0bf8:
						num2 = 111;
						((Control)LblExit).Top = 9;
						goto IL_0c09;
						IL_0c09:
						num2 = 112;
						((Control)tSearchText).Width = ((Control)MSG).Width;
						goto IL_0c23;
						IL_0c23:
						num2 = 113;
						DC_Main.ColValue = new string[DC_Main.RsDg.Columns.Count - 1 + 1];
						goto IL_0c43;
						IL_0c43:
						num2 = 114;
						((DataGridView)MSG).Rows[((DataGridView)MSG).RowCount - 1].Cells[0].Selected = true;
						goto IL_0c75;
						IL_0c75:
						num2 = 115;
						if (DC_Main.HelpSelect == 1)
						{
							goto IL_0c86;
						}
						goto IL_0cb0;
						IL_0c86:
						num2 = 116;
						((DataGridView)MSG).Rows[0].Cells[0].Selected = true;
						goto IL_0ce3;
						IL_0cb0:
						num2 = 118;
						((DataGridView)MSG).Rows[((DataGridView)MSG).RowCount - 1].Cells[0].Selected = true;
						goto IL_0ce3;
						IL_0ce3:
						num2 = 120;
						DC_Main.HelpSelect = 0;
						goto IL_0eb3;
						IL_07e4:
						num2 = 76;
						((DataGridView)MSG).Columns[num5].Width = (int)Math.Round(DC_Main.ColWidth[num5] * ColCon);
						goto IL_0814;
						IL_0814:
						num2 = 77;
						if (DC_Main.ColWidth[num5] == 0.0)
						{
							goto IL_0830;
						}
						goto IL_084c;
						IL_0830:
						num2 = 78;
						((DataGridView)MSG).Columns[num5].Visible = false;
						goto IL_084c;
						IL_084c:
						num2 = 79;
						num6 = Strings.Len(DC_Main.RsDg.Columns[num5].ColumnName);
						goto IL_086c;
						IL_086c:
						num2 = 80;
						num6--;
						goto IL_0875;
						IL_0875:
						num2 = 81;
						((DataGridView)MSG).Columns[num5].HeaderText = Strings.Mid(DC_Main.RsDg.Columns[num5].ColumnName, 1, num6);
						goto IL_08ae;
						IL_08ae:
						num2 = 82;
						HelpWidth = (int)Math.Round((double)HelpWidth + DC_Main.ColWidth[num5] * ColCon);
						goto IL_08d4;
						IL_08d4:
						num2 = 83;
						num6++;
						goto IL_08dd;
						IL_08dd:
						num2 = 84;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
						goto IL_08ff;
						IL_08ff:
						num2 = 85;
						if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num5].ColumnName, num6, num6), "L", false) == 0)
						{
							goto IL_0935;
						}
						goto IL_095d;
						IL_0935:
						num2 = 86;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
						goto IL_0ab9;
						IL_095d:
						num2 = 88;
						if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num5].ColumnName, num6, num6), "M", false) == 0)
						{
							goto IL_0993;
						}
						goto IL_09bb;
						IL_0993:
						num2 = 89;
						((DataGridView)MSG).Columns[num5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
						goto IL_0ab9;
						IL_09bb:
						num2 = 91;
						if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num5].ColumnName, num6, num6), "R", false) == 0)
						{
							goto IL_09f1;
						}
						goto IL_0a3b;
						end_IL_0001_2:
						break;
					}
					num2 = 148;
					((Control)MSG).Focus();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj11) when (obj11 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj11);
				try0001_dispatch = 4566;
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

	private void tSearchText_TextChanged(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		int num8 = default(int);
		DataView dataView = default(DataView);
		string columnName = default(string);
		string text = default(string);
		DataView dataView2 = default(DataView);
		string columnName2 = default(string);
		string text2 = default(string);
		int num9 = default(int);
		int num10 = default(int);
		DataView dataView3 = default(DataView);
		string columnName3 = default(string);
		string text3 = default(string);
		int num11 = default(int);
		int num12 = default(int);
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
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 3587:
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
								goto IL_000f;
							case 5:
								goto IL_002a;
							case 6:
								goto IL_003d;
							case 7:
								goto IL_0058;
							case 8:
							case 9:
								goto IL_0062;
							case 10:
								goto IL_0073;
							case 11:
								goto IL_0098;
							case 12:
								goto IL_00a7;
							case 13:
								goto IL_00c6;
							case 14:
								goto IL_010a;
							case 15:
								goto IL_0134;
							case 17:
								goto IL_017b;
							case 18:
								goto IL_0197;
							case 20:
								goto IL_021e;
							case 16:
							case 19:
							case 21:
							case 22:
								goto IL_0259;
							case 23:
								goto IL_026c;
							case 24:
								goto IL_027d;
							case 27:
								goto IL_02b3;
							case 28:
								goto IL_02c7;
							case 31:
								goto IL_02fe;
							case 32:
								goto IL_031d;
							case 33:
								goto IL_0342;
							case 34:
								goto IL_0351;
							case 35:
								goto IL_0370;
							case 36:
								goto IL_03b4;
							case 37:
								goto IL_03de;
							case 39:
								goto IL_0425;
							case 40:
								goto IL_043e;
							case 42:
								goto IL_048f;
							case 43:
								goto IL_04ab;
							case 45:
								goto IL_0532;
							case 38:
							case 41:
							case 44:
							case 46:
							case 47:
								goto IL_056d;
							case 48:
								goto IL_0580;
							case 49:
								goto IL_0591;
							case 52:
								goto IL_05c7;
							case 53:
								goto IL_05db;
							case 56:
								goto IL_0612;
							case 57:
								goto IL_0631;
							case 58:
								goto IL_0656;
							case 59:
								goto IL_0665;
							case 60:
								goto IL_0684;
							case 61:
								goto IL_06c8;
							case 62:
								goto IL_06f2;
							case 64:
								goto IL_0739;
							case 65:
								goto IL_0755;
							case 67:
								goto IL_07dc;
							case 63:
							case 66:
							case 68:
							case 69:
								goto IL_0817;
							case 70:
								goto IL_082a;
							case 71:
								goto IL_083b;
							case 74:
								goto IL_0871;
							case 75:
								goto IL_0885;
							case 78:
								goto IL_08bc;
							case 79:
								goto IL_08db;
							case 80:
								goto IL_0900;
							case 81:
								goto IL_091f;
							case 82:
								goto IL_095a;
							case 83:
								goto IL_0986;
							case 85:
							case 86:
								goto IL_09a6;
							case 89:
								goto IL_09c0;
							case 90:
								goto IL_09df;
							case 91:
								goto IL_0a18;
							case 92:
								goto IL_0a37;
							case 93:
								goto IL_0a61;
							case 94:
								goto IL_0a9c;
							case 95:
								goto IL_0ab8;
							case 97:
							case 98:
								goto IL_0ae8;
							case 96:
							case 99:
								goto IL_0af7;
							case 102:
								goto IL_0b12;
							case 103:
								goto IL_0b2c;
							case 104:
								goto IL_0b40;
							case 105:
								goto IL_0b65;
							case 106:
								goto IL_0b84;
							case 107:
								goto IL_0bbf;
							case 108:
								goto end_IL_0001_2;
							case 110:
							case 111:
								goto IL_0c0b;
							default:
								goto end_IL_0001;
							case 4:
							case 25:
							case 26:
							case 29:
							case 30:
							case 50:
							case 51:
							case 54:
							case 55:
							case 72:
							case 73:
							case 76:
							case 77:
							case 84:
							case 87:
							case 88:
							case 100:
							case 101:
							case 109:
							case 112:
							case 113:
							case 114:
							case 115:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0a37:
						num2 = 92;
						num5 = ((BaseCollection)((DataGridView)MSG).Rows[num6].Cells).Count - 1;
						num7 = 0;
						goto IL_0aef;
						IL_0aef:
						if (num7 <= num5)
						{
							goto IL_0a61;
						}
						goto IL_0af7;
						IL_0b00:
						if (num6 > num8)
						{
							goto end_IL_0001_3;
						}
						goto IL_0a37;
						IL_0a61:
						num2 = 93;
						if (((DataGridView)MSG)[num7, num6].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
						{
							goto IL_0a9c;
						}
						goto IL_0ae8;
						IL_000b:
						num2 = 2;
						num7 = 0;
						goto IL_000f;
						IL_000f:
						num2 = 3;
						if (((DataGridView)MSG).CurrentCell == null)
						{
							goto end_IL_0001_3;
						}
						goto IL_002a;
						IL_002a:
						num2 = 5;
						num7 = ((DataGridView)MSG).CurrentCell.ColumnIndex;
						goto IL_003d;
						IL_003d:
						num2 = 6;
						if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
						{
							goto IL_0058;
						}
						goto IL_0062;
						IL_0058:
						num2 = 7;
						DC_Main.SoftLoad();
						goto IL_0062;
						IL_0062:
						num2 = 9;
						if (DC_Main.F1Search)
						{
							goto IL_0073;
						}
						goto IL_02fe;
						IL_0073:
						num2 = 10;
						if (Operators.CompareString(tSearchText.Text, "", false) != 0)
						{
							goto IL_0098;
						}
						goto IL_02b3;
						IL_0098:
						num2 = 11;
						dataView = new DataView(DC_Main.RsDg);
						goto IL_00a7;
						IL_00a7:
						num2 = 12;
						columnName = DC_Main.RsDg.Columns[ColNumber].ColumnName;
						goto IL_00c6;
						IL_00c6:
						num2 = 13;
						text = Strings.Mid(DC_Main.RsDg.Columns[ColNumber].ColumnName, Strings.Len(DC_Main.RsDg.Columns[ColNumber].ColumnName), 1);
						goto IL_010a;
						IL_010a:
						num2 = 14;
						if ((Operators.CompareString(text, "L", false) == 0) | (Operators.CompareString(text, "M", false) == 0))
						{
							goto IL_0134;
						}
						goto IL_017b;
						IL_0134:
						num2 = 15;
						dataView.RowFilter = " " + columnName + " Like '%" + tSearchText.Text + "%' ";
						goto IL_0259;
						IL_017b:
						num2 = 17;
						if (Operators.CompareString(text, "W", false) == 0)
						{
							goto IL_0197;
						}
						goto IL_021e;
						IL_0197:
						num2 = 18;
						dataView.RowFilter = (" " + columnName + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text)) + " AND " + columnName + " <= " + Conversions.ToString(Conversion.Val(tSearchText.Text) + 0.3)) ?? "";
						goto IL_0259;
						IL_0ab8:
						num2 = 95;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num6].Cells[num7];
						goto IL_0af7;
						IL_0a9c:
						num2 = 94;
						((DataGridView)MSG).Rows[num6].Selected = true;
						goto IL_0ab8;
						IL_021e:
						num2 = 20;
						dataView.RowFilter = (" " + columnName + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text))) ?? "";
						goto IL_0259;
						IL_0ae8:
						num2 = 98;
						num7++;
						goto IL_0aef;
						IL_0af7:
						num2 = 99;
						num6++;
						goto IL_0b00;
						IL_0259:
						num2 = 22;
						if (dataView.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_026c;
						IL_026c:
						num2 = 23;
						((DataGridView)MSG).DataSource = dataView;
						goto IL_027d;
						IL_027d:
						num2 = 24;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
						goto end_IL_0001_3;
						IL_02b3:
						num2 = 27;
						((DataGridView)MSG).DataSource = DC_Main.RsDg;
						goto IL_02c7;
						IL_02c7:
						num2 = 28;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
						goto end_IL_0001_3;
						IL_02fe:
						num2 = 31;
						if (Operators.CompareString(DC_Main.MsHelpSearch, "S", false) == 0)
						{
							goto IL_031d;
						}
						goto IL_0612;
						IL_031d:
						num2 = 32;
						if (Operators.CompareString(tSearchText.Text, "", false) != 0)
						{
							goto IL_0342;
						}
						goto IL_05c7;
						IL_0342:
						num2 = 33;
						dataView2 = new DataView(DC_Main.RsDg);
						goto IL_0351;
						IL_0351:
						num2 = 34;
						columnName2 = DC_Main.RsDg.Columns[ColNumber].ColumnName;
						goto IL_0370;
						IL_0370:
						num2 = 35;
						text2 = Strings.Mid(DC_Main.RsDg.Columns[ColNumber].ColumnName, Strings.Len(DC_Main.RsDg.Columns[ColNumber].ColumnName), 1);
						goto IL_03b4;
						IL_03b4:
						num2 = 36;
						if ((Operators.CompareString(text2, "L", false) == 0) | (Operators.CompareString(text2, "M", false) == 0))
						{
							goto IL_03de;
						}
						goto IL_0425;
						IL_03de:
						num2 = 37;
						dataView2.RowFilter = " " + columnName2 + " Like  '" + tSearchText.Text + "%' ";
						goto IL_056d;
						IL_0425:
						num2 = 39;
						if (Operators.CompareString(text2, "D", false) == 0)
						{
							goto IL_043e;
						}
						goto IL_048f;
						IL_043e:
						num2 = 40;
						dataView2.RowFilter = " " + columnName2 + " = '" + Strings.Format((object)tSearchText.Text, "dd") + "'";
						goto IL_056d;
						IL_048f:
						num2 = 42;
						if (Operators.CompareString(text2, "W", false) == 0)
						{
							goto IL_04ab;
						}
						goto IL_0532;
						IL_04ab:
						num2 = 43;
						dataView2.RowFilter = (" " + columnName2 + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text)) + " And " + columnName2 + " <= " + Conversions.ToString(Conversion.Val(tSearchText.Text) + 0.3)) ?? "";
						goto IL_056d;
						IL_0b2c:
						num2 = 103;
						num7 = ((DataGridView)MSG).CurrentCell.ColumnIndex;
						goto IL_0b40;
						IL_0b12:
						num2 = 102;
						if (((DataGridView)MSG).CurrentCell == null)
						{
							goto end_IL_0001_3;
						}
						goto IL_0b2c;
						IL_0532:
						num2 = 45;
						dataView2.RowFilter = (" " + columnName2 + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text))) ?? "";
						goto IL_056d;
						IL_0b65:
						num2 = 105;
						num9 = ((DataGridView)MSG).Rows.Count - 1;
						num10 = 0;
						goto IL_0c14;
						IL_0b40:
						num2 = 104;
						if (Operators.CompareString(tSearchText.Text, "", false) == 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_0b65;
						IL_056d:
						num2 = 47;
						if (dataView2.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_0580;
						IL_0580:
						num2 = 48;
						((DataGridView)MSG).DataSource = dataView2;
						goto IL_0591;
						IL_0591:
						num2 = 49;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
						goto end_IL_0001_3;
						IL_05c7:
						num2 = 52;
						((DataGridView)MSG).DataSource = DC_Main.RsDg;
						goto IL_05db;
						IL_05db:
						num2 = 53;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
						goto end_IL_0001_3;
						IL_0612:
						num2 = 56;
						if (Operators.CompareString(DC_Main.MsHelpSearch, "M", false) == 0)
						{
							goto IL_0631;
						}
						goto IL_08bc;
						IL_0631:
						num2 = 57;
						if (Operators.CompareString(tSearchText.Text, "", false) != 0)
						{
							goto IL_0656;
						}
						goto IL_0871;
						IL_0656:
						num2 = 58;
						dataView3 = new DataView(DC_Main.RsDg);
						goto IL_0665;
						IL_0665:
						num2 = 59;
						columnName3 = DC_Main.RsDg.Columns[ColNumber].ColumnName;
						goto IL_0684;
						IL_0684:
						num2 = 60;
						text3 = Strings.Mid(DC_Main.RsDg.Columns[ColNumber].ColumnName, Strings.Len(DC_Main.RsDg.Columns[ColNumber].ColumnName), 1);
						goto IL_06c8;
						IL_06c8:
						num2 = 61;
						if ((Operators.CompareString(text3, "L", false) == 0) | (Operators.CompareString(text3, "M", false) == 0))
						{
							goto IL_06f2;
						}
						goto IL_0739;
						IL_06f2:
						num2 = 62;
						dataView3.RowFilter = " " + columnName3 + " Like '%" + tSearchText.Text + "%' ";
						goto IL_0817;
						IL_0739:
						num2 = 64;
						if (Operators.CompareString(text3, "W", false) == 0)
						{
							goto IL_0755;
						}
						goto IL_07dc;
						IL_0755:
						num2 = 65;
						dataView3.RowFilter = (" " + columnName3 + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text)) + " AND " + columnName3 + " <= " + Conversions.ToString(Conversion.Val(tSearchText.Text) + 0.3)) ?? "";
						goto IL_0817;
						IL_0b84:
						num2 = 106;
						if (((DataGridView)MSG)[num7, num10].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
						{
							goto IL_0bbf;
						}
						goto IL_0c0b;
						IL_0c14:
						if (num10 > num9)
						{
							goto end_IL_0001_3;
						}
						goto IL_0b84;
						IL_07dc:
						num2 = 67;
						dataView3.RowFilter = (" " + columnName3 + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text))) ?? "";
						goto IL_0817;
						IL_0c0b:
						num2 = 111;
						num10++;
						goto IL_0c14;
						IL_0bbf:
						num2 = 107;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num10].Cells[num7];
						break;
						IL_0817:
						num2 = 69;
						if (dataView3.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_082a;
						IL_082a:
						num2 = 70;
						((DataGridView)MSG).DataSource = dataView3;
						goto IL_083b;
						IL_083b:
						num2 = 71;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
						goto end_IL_0001_3;
						IL_0871:
						num2 = 74;
						((DataGridView)MSG).DataSource = DC_Main.RsDg;
						goto IL_0885;
						IL_0885:
						num2 = 75;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
						goto end_IL_0001_3;
						IL_08bc:
						num2 = 78;
						if (Operators.CompareString(DC_Main.MsHelpSearch, "W", false) == 0)
						{
							goto IL_08db;
						}
						goto IL_09c0;
						IL_08db:
						num2 = 79;
						if (Operators.CompareString(tSearchText.Text, "", false) == 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_0900;
						IL_0900:
						num2 = 80;
						num11 = ((DataGridView)MSG).Rows.Count - 1;
						num12 = 0;
						goto IL_09af;
						IL_09af:
						if (num12 > num11)
						{
							goto end_IL_0001_3;
						}
						goto IL_091f;
						IL_091f:
						num2 = 81;
						if (((DataGridView)MSG)[num7, num12].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
						{
							goto IL_095a;
						}
						goto IL_09a6;
						IL_095a:
						num2 = 82;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num12].Cells[num7];
						goto IL_0986;
						IL_0986:
						num2 = 83;
						((DataGridView)MSG).Rows[num12].Selected = true;
						goto end_IL_0001_3;
						IL_09a6:
						num2 = 86;
						num12++;
						goto IL_09af;
						IL_09c0:
						num2 = 89;
						if (Operators.CompareString(DC_Main.MsHelpSearch, "A", false) == 0)
						{
							goto IL_09df;
						}
						goto IL_0b12;
						IL_09df:
						num2 = 90;
						if (!((Operators.CompareString(tSearchText.Text, "", false) != 0) & (Strings.Len(tSearchText.Text) > 2)))
						{
							goto end_IL_0001_3;
						}
						goto IL_0a18;
						IL_0a18:
						num2 = 91;
						num8 = ((DataGridView)MSG).Rows.Count - 1;
						num6 = 0;
						goto IL_0b00;
						end_IL_0001_2:
						break;
					}
					num2 = 108;
					((DataGridView)MSG).Rows[num10].Selected = true;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3587;
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

	private void MSG_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int rowIndex = default(int);
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
				case 196:
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
							goto IL_0014;
						case 4:
							goto IL_002e;
						case 5:
							goto IL_0044;
						case 6:
							goto IL_0075;
						case 7:
						case 8:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 9:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_007d:
					if (num5 > num6)
					{
						break;
					}
					goto IL_0044;
					IL_0044:
					num2 = 5;
					DC_Main.ColValue[num5] = Conversions.ToString(((DataGridView)MSG).Rows[rowIndex].Cells[num5].Value);
					goto IL_0075;
					IL_002e:
					num2 = 4;
					num6 = checked(((DataGridView)MSG).ColumnCount - 1);
					num5 = 0;
					goto IL_007d;
					IL_0075:
					num2 = 6;
					num5 = checked(num5 + 1);
					goto IL_007d;
					IL_000b:
					num2 = 2;
					rowIndex = e.RowIndex;
					goto IL_0014;
					IL_0014:
					num2 = 3;
					if (DC_Main.RsDg.Rows.Count <= 0)
					{
						break;
					}
					goto IL_002e;
					end_IL_0001_2:
					break;
				}
				num2 = 8;
				((Form)this).Close();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 196;
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

	private void MSG_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Invalid comparison between Unknown and I4
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 37)
		{
			tSearchText.Text = "";
			if (((DataGridView)MSG).CurrentCell.ColumnIndex > 0)
			{
				ColNumber = checked(((DataGridView)MSG).CurrentCell.ColumnIndex - 1);
			}
		}
		else if ((int)e.KeyCode == 39)
		{
			tSearchText.Text = "";
			checked
			{
				if (((DataGridView)MSG).CurrentCell.ColumnIndex < DC_Main.RsDg.Columns.Count - 1)
				{
					ColNumber = ((DataGridView)MSG).CurrentCell.ColumnIndex + 1;
				}
			}
		}
		else
		{
			if ((int)e.KeyCode == 38 || (int)e.KeyCode == 40)
			{
				return;
			}
			if ((int)e.KeyCode == 8)
			{
				if (Strings.Len(tSearchText.Text) > 0)
				{
					tSearchText.Text = Strings.Mid(tSearchText.Text, 1, checked(Strings.Len(tSearchText.Text) - 1));
				}
			}
			else
			{
				if ((int)e.KeyCode != 13)
				{
					return;
				}
				if (DC_Main.RsDg.Rows.Count == 0)
				{
					DC_Main.HelpClose = true;
					((Form)this).Close();
					return;
				}
				int index = ((DataGridViewBand)((DataGridView)MSG).CurrentRow).Index;
				checked
				{
					if (DC_Main.RsDg.Rows.Count > 0)
					{
						int num = ((DataGridView)MSG).ColumnCount - 1;
						DC_Main.X = 0;
						while (DC_Main.X <= num)
						{
							DC_Main.ColValue[DC_Main.X] = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)MSG).Rows[index].Cells[DC_Main.X].Value, (object)""));
							DC_Main.X++;
						}
					}
					((Form)this).Close();
				}
			}
		}
	}

	private void MSG_CLEAR()
	{
		((DataGridView)MSG).DataSource = null;
	}

	private void MS_HELP_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112)
		{
			if (Operators.CompareString(DC_Main.MsMobileLen, "", false) != 0)
			{
				DC_Main.MsMobileSearchNo = tSearchText.Text;
			}
			if (DC_Main.MsCreat)
			{
				DC_Main.MsSubCreat = true;
			}
			else
			{
				DC_Main.MsCreat = true;
			}
			((Form)this).Close();
		}
	}

	private void MS_HELP_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (Operators.CompareString(tSearchText.Text, "", false) == 0)
		{
			((Control)tSearchText).Focus();
		}
	}

	private void LblExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MSG_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void tSearchText_KeyDown(object sender, KeyEventArgs e)
	{
		((Control)MSG).Focus();
	}

	private void MSG_KeyPress(object sender, KeyPressEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
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
				case 251:
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
							goto IL_0022;
						case 4:
						case 5:
							goto IL_0057;
						case 6:
							goto IL_0065;
						case 7:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 8:
						case 9:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0022:
					num2 = 3;
					tSearchText.Text += Conversions.ToString(Strings.Chr(Strings.Asc(e.KeyChar)));
					goto IL_0057;
					IL_0057:
					num2 = 5;
					((Control)MSG).Focus();
					goto IL_0065;
					IL_000b:
					num2 = 2;
					if (Strings.Asc(e.KeyChar) != 8)
					{
						goto IL_0022;
					}
					goto IL_0057;
					IL_0065:
					num2 = 6;
					if (!((Operators.CompareString(DC_Main.MsHelpSearch, "S", false) == 0) | (Operators.CompareString(DC_Main.MsHelpSearch, "M", false) == 0)))
					{
						goto end_IL_0001_3;
					}
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 7;
				((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 251;
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

	private void MS_HELP_Activated(object sender, EventArgs e)
	{
		((Control)MSG).Focus();
		if (DC_Main.RsDg.Rows.Count != 0 && ((Operators.CompareString(DC_Main.MsHelpSearch, "S", false) == 0) | (Operators.CompareString(DC_Main.MsHelpSearch, "M", false) == 0)) && Operators.CompareString(tSearchText.Text, "", false) != 0)
		{
			((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
		}
	}

	private void MS_HELP_Closed(object sender, EventArgs e)
	{
		DC_Main.F1Search = false;
		DC_Main.MsMobileLen = "";
	}

	private void MSG_Click(object sender, EventArgs e)
	{
		if (DC_Main.RsDg.Rows.Count != 0 && ((DataGridView)MSG).CurrentCell.ColumnIndex < checked(DC_Main.RsDg.Columns.Count - 1))
		{
			ColNumber = ((DataGridView)MSG).CurrentCell.ColumnIndex;
		}
	}
}
