using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_BOOKLIST : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblExit")]
	private Label _LblExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearchText")]
	private TextBox _tSearchText;

	private int HelpWidth;

	private DataTable dtTableGrd;

	private double ColCon;

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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX MSG
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
			DevComponents.DotNetBar.Controls.DataGridViewX val5 = _MSG;
			if (val5 != null)
			{
				((DataGridView)val5).CellDoubleClick -= val;
				((Control)val5).KeyDown -= val2;
				((DataGridView)val5).CellContentClick -= val3;
				((Control)val5).KeyPress -= val4;
			}
			_MSG = value;
			val5 = _MSG;
			if (val5 != null)
			{
				((DataGridView)val5).CellDoubleClick += val;
				((Control)val5).KeyDown += val2;
				((DataGridView)val5).CellContentClick += val3;
				((Control)val5).KeyPress += val4;
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

	public MS_BOOKLIST()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((Form)this).Load += MS_BOOKLIST_Load;
		((Control)this).KeyDown += new KeyEventHandler(MS_BOOKLIST_KeyDown);
		((Control)this).KeyPress += new KeyPressEventHandler(MS_BOOKLIST_KeyPress);
		((Form)this).Activated += MS_BOOKLIST_Activated;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_BOOKLIST));
		tSearchText = new TextBox();
		MSG = new DevComponents.DotNetBar.Controls.DataGridViewX();
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
		((Control)MSG).Location = new Point(16, 28);
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
		((Control)this).Name = "MS_BOOKLIST";
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)0;
		((Form)this).Text = "DataCare HD Help";
		((ISupportInitialize)MSG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_BOOKLIST_Load(object sender, EventArgs e)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected O, but got Unknown
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected O, but got Unknown
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
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 1)
			{
				object? obj = colorConverter.ConvertFromString("Tan");
				((Form)this).BackColor = ((obj != null) ? ((Color)obj) : default(Color));
				((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
				DevComponents.DotNetBar.Controls.DataGridViewX mSG = MSG;
				object? obj2 = colorConverter.ConvertFromString("SeaShell");
				((DataGridView)mSG).BackgroundColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
				((DataGridView)MSG).AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
			}
			else if (DC_Main.MsCoTheme == 2)
			{
				object? obj3 = colorConverter.ConvertFromString("Gray");
				((Form)this).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
				DevComponents.DotNetBar.Controls.DataGridViewX mSG2 = MSG;
				object? obj4 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)mSG2).BackgroundColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
				object? obj5 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				((Form)this).BackColor = Color.LightSlateGray;
				((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
				DevComponents.DotNetBar.Controls.DataGridViewX mSG3 = MSG;
				object? obj6 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)mSG3).BackgroundColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj8 = colorConverter.ConvertFromString("CadetBlue");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
				DevComponents.DotNetBar.Controls.DataGridViewX mSG4 = MSG;
				object? obj9 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)mSG4).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			((DataGridView)MSG).Columns.Clear();
			((DataGridView)MSG).MultiSelect = false;
			tSearchText.Text = "";
			DC_Main.HelpClose = false;
			if (DC_Main.RsDg.Rows.Count > 0)
			{
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)MSG).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
				{
					if (DC_Main.DgvRowHight == 0.0)
					{
						DC_Main.DgvRowHight = ((DataGridView)MSG).RowTemplate.Height;
					}
					int num3;
					if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
					{
						num3 = (int)Math.Ceiling(10.0 * (1.0 + num2));
						((DataGridView)MSG).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)num3, (FontStyle)1);
						((DataGridView)MSG).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)MSG).Font.Style);
						((DataGridView)MSG).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)MSG).Font.Style);
					}
					((DataGridView)MSG).ColumnHeadersHeight = (int)Math.Round(DC_Main.DgvRowHight * (1.0 + num2));
					((DataGridView)MSG).RowTemplate.Height = (int)Math.Round(DC_Main.DgvRowHight * (1.0 + num2));
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((Control)LblHelpName).Font = new Font("Arial", (float)num3, ((Control)LblHelpName).Font.Style);
					((Control)tSearchText).Font = new Font("Arial", (float)num3, ((Control)tSearchText).Font.Style);
					((Control)this).Height = (int)Math.Round(268.0 * (1.0 + num2));
				}
				((DataGridView)MSG).DataSource = DC_Main.RsDg;
				HelpWidth = 0;
				int num4 = DC_Main.RsDg.Columns.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					((DataGridView)MSG).Columns[i].Width = (int)Math.Round(DC_Main.ColWidth[i] * ColCon);
					if (DC_Main.ColWidth[i] == 0.0)
					{
						((DataGridView)MSG).Columns[i].Visible = false;
					}
					int num5 = Strings.Len(DC_Main.RsDg.Columns[i].ColumnName);
					num5--;
					((DataGridView)MSG).Columns[i].HeaderText = Strings.Mid(DC_Main.RsDg.Columns[i].ColumnName, 1, num5);
					HelpWidth = (int)Math.Round((double)HelpWidth + DC_Main.ColWidth[i] * ColCon);
					num5++;
					((DataGridView)MSG).Columns[i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
					if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[i].ColumnName, num5, num5), "L", false) == 0)
					{
						((DataGridView)MSG).Columns[i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
					}
					else if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[i].ColumnName, num5, num5), "M", false) == 0)
					{
						((DataGridView)MSG).Columns[i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					}
					else if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[i].ColumnName, num5, num5), "R", false) == 0)
					{
						((DataGridView)MSG).Columns[i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)MSG).Columns[i].DefaultCellStyle.Format = "0.00";
					}
					else if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[i].ColumnName, num5, num5), "W", false) == 0)
					{
						((DataGridView)MSG).Columns[i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)MSG).Columns[i].DefaultCellStyle.Format = "0.000";
					}
				}
				((Control)MSG).Top = 32;
				((Control)MSG).Width = HelpWidth + 25;
				((Control)MSG).Height = ((Control)this).Height - 65;
				((Control)tSearchText).Top = ((Control)MSG).Bottom + 7;
				((Control)tSearchText).Left = ((Control)MSG).Left + 5;
				((Control)tSearchText).Width = ((Control)MSG).Width;
				((Control)this).Width = (int)Math.Round((double)((Control)MSG).Width + 30.0 * ColCon);
				((Control)MSG).Left = (int)Math.Round(15.0 * ColCon);
				((Control)LblHelpName).Left = ((Control)MSG).Left;
				((Control)LblHelpName).Top = 10;
				((Control)LblExit).Left = ((Control)MSG).Right - 20;
				((Control)LblExit).Top = 10;
				((Control)tSearchText).Width = ((Control)MSG).Width;
				DC_Main.ColValue = new string[DC_Main.RsDg.Columns.Count - 1 + 1];
				((DataGridView)MSG).Rows[((DataGridView)MSG).RowCount - 1].Cells[0].Selected = true;
				if (DC_Main.HelpSelect == 1)
				{
					((DataGridView)MSG).Rows[0].Cells[0].Selected = true;
				}
				else
				{
					((DataGridView)MSG).Rows[((DataGridView)MSG).RowCount - 1].Cells[0].Selected = true;
				}
				DC_Main.HelpSelect = 0;
				((Control)this).Left = (int)Math.Round((double)(Screen.PrimaryScreen.WorkingArea.Width - ((Control)this).Width) / 2.0);
				((Control)this).Top = (int)Math.Round((double)(Screen.PrimaryScreen.WorkingArea.Height - ((Control)this).Height) / 2.0);
				((Control)MSG).Focus();
			}
			else
			{
				Interaction.MsgBox((object)"No Record Found", (MsgBoxStyle)0, (object)null);
				((Form)this).Close();
				DC_Main.HelpClose = true;
			}
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
					case 356:
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
								goto IL_002d;
							case 4:
								goto IL_004b;
							case 5:
								goto IL_0075;
							case 6:
								goto IL_00b0;
							case 7:
								goto IL_00cb;
							case 8:
							case 9:
								goto IL_00f9;
							case 10:
								goto IL_010b;
							default:
								goto end_IL_0001;
							case 11:
							case 12:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_00b0:
						num2 = 6;
						((DataGridView)MSG).Rows[num5].Selected = true;
						goto IL_00cb;
						IL_00cb:
						num2 = 7;
						((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num5].Cells[num6];
						goto IL_00f9;
						IL_0075:
						num2 = 5;
						if (((DataGridView)MSG)[num6, num5].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
						{
							goto IL_00b0;
						}
						goto IL_00f9;
						IL_00f9:
						num2 = 9;
						num6++;
						goto IL_0102;
						IL_000b:
						num2 = 2;
						if (Operators.CompareString(tSearchText.Text, "", false) == 0)
						{
							goto end_IL_0001_2;
						}
						goto IL_002d;
						IL_002d:
						num2 = 3;
						num7 = ((DataGridView)MSG).Rows.Count - 1;
						num5 = 0;
						goto IL_0114;
						IL_0114:
						if (num5 > num7)
						{
							goto end_IL_0001_2;
						}
						goto IL_004b;
						IL_004b:
						num2 = 4;
						num8 = ((BaseCollection)((DataGridView)MSG).Rows[num5].Cells).Count - 1;
						num6 = 0;
						goto IL_0102;
						IL_0102:
						if (num6 <= num8)
						{
							goto IL_0075;
						}
						goto IL_010b;
						IL_010b:
						num2 = 10;
						num5++;
						goto IL_0114;
						end_IL_0001:
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 356;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_2:
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Invalid comparison between Unknown and I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Invalid comparison between Unknown and I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Invalid comparison between Unknown and I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 37)
		{
			tSearchText.Text = "";
		}
		else if ((int)e.KeyCode == 39)
		{
			tSearchText.Text = "";
		}
		else if ((int)e.KeyCode == 38)
		{
			tSearchText.Text = "";
		}
		else if ((int)e.KeyCode == 40)
		{
			tSearchText.Text = "";
		}
		else if ((int)e.KeyCode == 8)
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
			int index = ((DataGridViewBand)((DataGridView)MSG).CurrentRow).Index;
			checked
			{
				if (DC_Main.RsDg.Rows.Count > 0)
				{
					int num = ((DataGridView)MSG).ColumnCount - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(((DataGridView)MSG).Rows[index].Cells[DC_Main.X].Value)))
					{
						DC_Main.ColValue[DC_Main.X] = Conversions.ToString(((DataGridView)MSG).Rows[index].Cells[DC_Main.X].Value);
						DC_Main.X++;
					}
				}
				((Form)this).Close();
			}
		}
	}

	private void MSG_CLEAR()
	{
		((DataGridView)MSG).DataSource = null;
	}

	private void MS_BOOKLIST_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
			if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
			{
				((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
			}
			else
			{
				((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
			}
		}
		else if ((int)e.KeyCode == 112)
		{
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

	private void MS_BOOKLIST_KeyPress(object sender, KeyPressEventArgs e)
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
		DataTable dataTable = (DataTable)((DataGridView)MSG).DataSource;
		if (dataTable.Rows.Count != 0)
		{
			if (Strings.Asc(e.KeyChar) != 8)
			{
				tSearchText.Text += Conversions.ToString(Strings.Chr(Strings.Asc(e.KeyChar)));
			}
			((Control)MSG).Focus();
		}
	}

	private void MS_BOOKLIST_Activated(object sender, EventArgs e)
	{
		((Control)MSG).Focus();
	}
}
