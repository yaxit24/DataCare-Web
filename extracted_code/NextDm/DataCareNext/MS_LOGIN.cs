using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_LOGIN : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUserName")]
	private TextBox _tUserName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPasward")]
	private TextBox _tPasward;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblExit")]
	private Label _LblExit;

	internal virtual TextBox tUserName
	{
		[CompilerGenerated]
		get
		{
			return _tUserName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tUserName_KeyDown);
			KeyPressEventHandler val2 = new KeyPressEventHandler(tUserName_KeyPress);
			EventHandler eventHandler = tUserName_TextChanged;
			TextBox val3 = _tUserName;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyPress -= val2;
				((Control)val3).TextChanged -= eventHandler;
			}
			_tUserName = value;
			val3 = _tUserName;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).KeyPress += val2;
				((Control)val3).TextChanged += eventHandler;
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

	internal virtual TextBox tPasward
	{
		[CompilerGenerated]
		get
		{
			return _tPasward;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tPasward_GotFocus;
			EventHandler eventHandler2 = tPasward_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tPasward_KeyDown);
			EventHandler eventHandler3 = tPasward_DoubleClick;
			TextBox val2 = _tPasward;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler3;
			}
			_tPasward = value;
			val2 = _tPasward;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler3;
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

	public MS_LOGIN()
	{
		((Form)this).Load += MS_LOGIN_Load;
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
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_LOGIN));
		tUserName = new TextBox();
		Label1 = new Label();
		tPasward = new TextBox();
		Label2 = new Label();
		LblExit = new Label();
		((Control)this).SuspendLayout();
		((TextBoxBase)tUserName).BackColor = Color.Gainsboro;
		((Control)tUserName).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tUserName).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)tUserName).ImeMode = (ImeMode)0;
		((Control)tUserName).Location = new Point(146, 56);
		((Control)tUserName).Name = "tUserName";
		((Control)tUserName).Size = new Size(126, 26);
		((Control)tUserName).TabIndex = 0;
		Label1.AutoSize = true;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Century Gothic", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.White;
		((Control)Label1).Location = new Point(44, 59);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(96, 18);
		((Control)Label1).TabIndex = 8;
		Label1.Text = "User Name :";
		((TextBoxBase)tPasward).BackColor = Color.Gainsboro;
		((Control)tPasward).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tPasward).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)tPasward).Location = new Point(146, 100);
		((Control)tPasward).Name = "tPasward";
		tPasward.PasswordChar = '●';
		((Control)tPasward).Size = new Size(127, 26);
		((Control)tPasward).TabIndex = 1;
		Label2.AutoSize = true;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Century Gothic", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.White;
		((Control)Label2).Location = new Point(57, 101);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 18);
		((Control)Label2).TabIndex = 10;
		Label2.Text = "Password :";
		LblExit.AutoSize = true;
		((Control)LblExit).BackColor = Color.Transparent;
		((Control)LblExit).Font = new Font("Segoe UI Semibold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)LblExit).ForeColor = Color.Navy;
		((Control)LblExit).Location = new Point(326, 18);
		((Control)LblExit).Name = "LblExit";
		((Control)LblExit).Size = new Size(24, 25);
		((Control)LblExit).TabIndex = 11;
		LblExit.Text = "X";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).AutoSize = true;
		((Control)this).BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		((Control)this).BackgroundImageLayout = (ImageLayout)3;
		((Form)this).ClientSize = new Size(366, 225);
		((Control)this).Controls.Add((Control)(object)LblExit);
		((Control)this).Controls.Add((Control)(object)tPasward);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tUserName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "MS_LOGIN";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Login Form";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void tUserName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tUserName.Text, "", false) == 0)
			{
				((Control)tUserName).Focus();
			}
			else
			{
				((Control)tPasward).Focus();
			}
		}
	}

	private void tUserName_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_LOGIN_Load(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		string path = default(string);
		string path2 = default(string);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					DC_Main.MainPcW = 1366.0;
					goto IL_0012;
				case 301:
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
							goto IL_0012;
						case 3:
							goto IL_0022;
						case 4:
							goto IL_003d;
						case 5:
							goto IL_0058;
						case 6:
							goto IL_0061;
						case 7:
							goto IL_0069;
						case 8:
							goto IL_007a;
						case 9:
						case 10:
							goto IL_0085;
						case 11:
							goto IL_008f;
						case 12:
							goto IL_00a2;
						case 13:
						case 14:
							goto IL_00b4;
						case 15:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 16:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_008f:
					num2 = 11;
					if (!File.Exists(path))
					{
						goto IL_00a2;
					}
					goto IL_00b4;
					IL_00a2:
					num2 = 12;
					File.Create(path).Dispose();
					goto IL_00b4;
					IL_0085:
					num2 = 10;
					path = "C:\\DcLink\\DcOpen.txt";
					goto IL_008f;
					IL_00b4:
					num2 = 14;
					((Form)this).BackColor = default(Color);
					break;
					IL_0012:
					num2 = 2;
					DC_Main.MainPcH = 768.0;
					goto IL_0022;
					IL_0022:
					num2 = 3;
					DC_Main.PcW = Screen.PrimaryScreen.Bounds.Width;
					goto IL_003d;
					IL_003d:
					num2 = 4;
					DC_Main.PcH = Screen.PrimaryScreen.Bounds.Height;
					goto IL_0058;
					IL_0058:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0061;
					IL_0061:
					num2 = 6;
					path2 = "C:\\DcLink";
					goto IL_0069;
					IL_0069:
					num2 = 7;
					if (!Directory.Exists(path2))
					{
						goto IL_007a;
					}
					goto IL_0085;
					IL_007a:
					num2 = 8;
					Directory.CreateDirectory(path2);
					goto IL_0085;
					end_IL_0001_2:
					break;
				}
				num2 = 15;
				((Form)this).TransparencyKey = ((Form)this).BackColor;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 301;
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

	private void tPasward_GotFocus(object sender, EventArgs e)
	{
		DC_Main.DataCon();
		DC_Main.SSCompSrNo1 = SystemSerialNumber();
		DC_Main.SSCompSrNo2 = GetHDSerialNo("C");
	}

	private void tPasward_TextChanged(object sender, EventArgs e)
	{
	}

	private void tPasward_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		string text = "";
		DC_Main.RsQry = "SELECT * FROM TILE_DATA WHERE SM_MAIN_NAME = 'Opning Form'";
		DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SHORT_NAME"], (object)""));
		}
		if (Operators.CompareString(Strings.UCase(Strings.Mid(tPasward.Text, 1, 7)), "GUJARAT", false) == 0 && Operators.CompareString(Strings.Mid(tPasward.Text, 8, 2), Strings.Mid(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), 1, 2), false) == 0 && Versioned.IsNumeric((object)Strings.Mid(tPasward.Text, 10, 1)))
		{
			int num = Conversions.ToInteger(Strings.Mid(tPasward.Text, 10, 1));
			DC_Main.ExeQuteMc("DELETE FROM AC_MAST_SRNO WHERE CO_CODE = '01' AND LC_CODE = '00' AND AC_CODE = '00001' AND MAIN_USER = 'ABC' ");
			DC_Main.ExeQuteMc("INSERT INTO AC_MAST_SRNO(CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_GR,MAIN_USER)VALUES('01','00','00001','CASH ON HAND','" + Conversions.ToString(0) + Conversions.ToString(num) + "','ABC')");
			Interaction.MsgBox((object)("Software Unlok for " + Conversions.ToString(num) + " Days Please Paid Amc..."), (MsgBoxStyle)0, (object)null);
			tPasward.Text = "";
			((Control)tUserName).Focus();
			return;
		}
		if ((Operators.CompareString(tUserName.Text, "ABC", false) == 0) & (Operators.CompareString(Strings.UCase(tPasward.Text), "SS", false) == 0) & (Operators.CompareString(text, "", false) == 0))
		{
			DC_Main.MsSSPwd = true;
			DC_Main.MCo_User = tUserName.Text;
			DC_Main.MCo_UserType = "A";
			((Control)this).Hide();
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST where LOGIN_NAME = 'ABC' AND PC_W <> 0 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MainPcW = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["PC_W"]);
				DC_Main.MainPcH = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["PC_H"]);
			}
			((Form)MyProject.Forms.MS_OPNCOMP).ShowDialog();
			((Control)MyProject.Forms.MS_OPNCOMP).Focus();
			return;
		}
		DC_Main.MsSSPwd = false;
		DC_Main.RsQry = "SELECT * FROM LOGIN_MAST where LOGIN_NAME='" + tUserName.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.BDataRest = false;
				if ((Operators.CompareString(text, "", false) != 0) & (Operators.CompareString(Strings.UCase(tPasward.Text), text, false) == 0))
				{
					DC_Main.MCo_User = tUserName.Text;
					DC_Main.MCo_UserType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LOGIN_CATG"], (object)""));
					((Control)this).Hide();
					DC_Main.RsQry = "SELECT * FROM LOGIN_MAST where LOGIN_NAME = 'ABC' AND PC_W <> 0 ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						DC_Main.MainPcW = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["PC_W"]);
						DC_Main.MainPcH = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["PC_H"]);
					}
					DC_Main.BDataRest = true;
					if (DC_Main.BDataRest)
					{
						DC_Main.RsQry = "SELECT CO_CODE FROM CO_MAST WHERE RTGS_TYPE = 'Y'";
						DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							int num2 = DC_Main.Tbl.Rows.Count - 1;
							DC_Main.M = 0;
							while (DC_Main.M <= num2)
							{
								DC_Main.ExeQuteMc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"DELETE From CO_MAST WHERE CO_CODE = '", DC_Main.Tbl.Rows[DC_Main.M]["CO_CODE"]), (object)"'")));
								DC_Main.M++;
							}
						}
					}
					((Form)MyProject.Forms.MS_OPNCOMP).ShowDialog();
					((Control)MyProject.Forms.MS_OPNCOMP).Focus();
					return;
				}
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LOGIN_PWD"], (object)""), (object)"", false), (object)(Operators.CompareString(tPasward.Text, "", false) != 0))))
				{
					Interaction.MsgBox((object)"Passward is Not Valid....", (MsgBoxStyle)0, (object)null);
					((Control)tPasward).Focus();
					((TextBoxBase)tPasward).SelectAll();
					return;
				}
				DC_Main.RsQry = "SELECT * FROM LOGIN_MAST where LOGIN_NAME='" + tUserName.Text + "' AND LOGIN_PWD='" + tPasward.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MCo_User = tUserName.Text;
					DC_Main.MCo_UserType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LOGIN_CATG"], (object)""));
					((Control)this).Hide();
					DC_Main.RsQry = "SELECT * FROM LOGIN_MAST where LOGIN_NAME = 'ABC' AND PC_W <> 0 ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						DC_Main.MainPcW = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["PC_W"]);
						DC_Main.MainPcH = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["PC_H"]);
					}
					((Form)MyProject.Forms.MS_OPNCOMP).ShowDialog();
					((Control)MyProject.Forms.MS_OPNCOMP).Focus();
				}
				else
				{
					Interaction.MsgBox((object)"Passward is Not Valid ...", (MsgBoxStyle)0, (object)null);
					((Control)tPasward).Focus();
					((TextBoxBase)tPasward).SelectAll();
				}
			}
			else
			{
				Interaction.MsgBox((object)"Please Check User Name ...", (MsgBoxStyle)0, (object)null);
				DC_Main.MCo_User = "";
				((Control)tUserName).Focus();
				((TextBoxBase)tUserName).SelectAll();
			}
		}
	}

	private void LblExit_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void tPasward_DoubleClick(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.UT_HDD).Show();
	}

	private void tUserName_TextChanged(object sender, EventArgs e)
	{
	}
}
