using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_COMPANY : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private FlowLayoutPanel _PnlBotam;

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
	[AccessedThroughProperty("lblBook")]
	private Label _lblBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRptHader")]
	private ComboBox _cboRptHader;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile2")]
	private TextBox _tMobile2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone2")]
	private TextBox _tPhone2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TState")]
	private TextBox _TState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCountry")]
	private TextBox _tCountry;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmail")]
	private TextBox _tEmail;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone")]
	private TextBox _tPhone;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCity")]
	private TextBox _tCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress3")]
	private TextBox _tAddress3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress2")]
	private TextBox _tAddress2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress1")]
	private TextBox _tAddress1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPinCode")]
	private TextBox _tPinCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCoName")]
	private TextBox _tCoName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCoCode")]
	private TextBox _tCoCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRtgsNo")]
	private TextBox _tRtgsNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankAcNo")]
	private TextBox _tBankAcNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankArea")]
	private TextBox _tBankArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPanNo")]
	private TextBox _tPanNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDhiranNo")]
	private TextBox _tDhiranNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCstNo")]
	private TextBox _tCstNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGstNo")]
	private TextBox _tGstNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCoReset")]
	private Label _lblCoReset;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboMetalType")]
	private ComboBox _cboMetalType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboWorkType")]
	private ComboBox _cboWorkType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tJudrection")]
	private TextBox _tJudrection;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tStateCode")]
	private TextBox _tStateCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mLockDate")]
	private MaskedTextBox _mLockDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCoType")]
	private TextBox _tCoType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboWithOldCoMast")]
	private ComboBox _cboWithOldCoMast;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelAbc")]
	private Panel _PanelAbc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tC")]
	private TextBox _tC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tB")]
	private TextBox _tB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tA")]
	private TextBox _tA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSet")]
	private SimpleButton _btnSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btneExit")]
	private SimpleButton _btneExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btneSave")]
	private SimpleButton _btneSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAspPwd")]
	private TextBox _tAspPwd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tePortalPwd")]
	private TextBox _tePortalPwd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUrlSet")]
	private SimpleButton _btnUrlSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHttpPath")]
	private TextBox _tHttpPath;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMailApi")]
	private TextBox _tMailApi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExitUae")]
	private SimpleButton _BtnExitUae;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSaveUae")]
	private SimpleButton _btnSaveUae;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private string CurLcCode;

	private string CoSname;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	internal virtual FlowLayoutPanel PnlBotam
	{
		[CompilerGenerated]
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PnlBotam_DoubleClick;
			FlowLayoutPanel val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PnlBotam = value;
			val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual Label lblBook
	{
		[CompilerGenerated]
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblBook_DoubleClick;
			Label val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_lblBook = value;
			val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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
	[AccessedThroughProperty("Pnl1")]
	private virtual Panel _Pnl1;

	internal virtual Panel Pnl1
	{
		get
		{
			return _Pnl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl1 = value;
		}
	}

	internal virtual ComboBox cboRptHader
	{
		[CompilerGenerated]
		get
		{
			return _cboRptHader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboRptHader_KeyDown);
			ComboBox val2 = _cboRptHader;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboRptHader = value;
			val2 = _cboRptHader;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label15")]
	private virtual Label _Label15;

	internal virtual Label Label15
	{
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label15 = value;
		}
	}

	internal virtual TextBox tMobile2
	{
		[CompilerGenerated]
		get
		{
			return _tMobile2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMobile2_KeyDown);
			TextBox val2 = _tMobile2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile2 = value;
			val2 = _tMobile2;
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

	internal virtual TextBox tPhone2
	{
		[CompilerGenerated]
		get
		{
			return _tPhone2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPhone2_KeyDown);
			TextBox val2 = _tPhone2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPhone2 = value;
			val2 = _tPhone2;
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

	internal virtual TextBox TState
	{
		[CompilerGenerated]
		get
		{
			return _TState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TState_KeyDown);
			TextBox val2 = _TState;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TState = value;
			val2 = _TState;
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

	internal virtual TextBox tCountry
	{
		[CompilerGenerated]
		get
		{
			return _tCountry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCountry_KeyDown);
			TextBox val2 = _tCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCountry = value;
			val2 = _tCountry;
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

	internal virtual TextBox tEmail
	{
		[CompilerGenerated]
		get
		{
			return _tEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmail_KeyDown);
			TextBox val2 = _tEmail;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmail = value;
			val2 = _tEmail;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tMobile
	{
		[CompilerGenerated]
		get
		{
			return _tMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tmobile_KeyDown);
			TextBox val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile = value;
			val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPhone
	{
		[CompilerGenerated]
		get
		{
			return _tPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPhone_KeyDown);
			TextBox val2 = _tPhone;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPhone = value;
			val2 = _tPhone;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tCity
	{
		[CompilerGenerated]
		get
		{
			return _tCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCity_KeyDown);
			TextBox val2 = _tCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCity = value;
			val2 = _tCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress3
	{
		[CompilerGenerated]
		get
		{
			return _tAddress3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress3_KeyDown);
			TextBox val2 = _tAddress3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress3 = value;
			val2 = _tAddress3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress2
	{
		[CompilerGenerated]
		get
		{
			return _tAddress2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress2_KeyDown);
			TextBox val2 = _tAddress2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress2 = value;
			val2 = _tAddress2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress1
	{
		[CompilerGenerated]
		get
		{
			return _tAddress1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress1_KeyDown);
			TextBox val2 = _tAddress1;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress1 = value;
			val2 = _tAddress1;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPinCode
	{
		[CompilerGenerated]
		get
		{
			return _tPinCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPinCode_KeyDown);
			TextBox val2 = _tPinCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPinCode = value;
			val2 = _tPinCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblEmail")]
	private virtual Label _lblEmail;

	internal virtual Label lblEmail
	{
		get
		{
			return _lblEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblEmail = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMoNo")]
	private virtual Label _lblMoNo;

	internal virtual Label lblMoNo
	{
		get
		{
			return _lblMoNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMoNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPhone")]
	private virtual Label _lblPhone;

	internal virtual Label lblPhone
	{
		get
		{
			return _lblPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPhone = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCity")]
	private virtual Label _lblCity;

	internal virtual Label lblCity
	{
		get
		{
			return _lblCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCity = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd3")]
	private virtual Label _lblAdd3;

	internal virtual Label lblAdd3
	{
		get
		{
			return _lblAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd2")]
	private virtual Label _lblAdd2;

	internal virtual Label lblAdd2
	{
		get
		{
			return _lblAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd1")]
	private virtual Label _lblAdd1;

	internal virtual Label lblAdd1
	{
		get
		{
			return _lblAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBookCo")]
	private virtual Label _lblBookCo;

	internal virtual Label lblBookCo
	{
		get
		{
			return _lblBookCo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBookCo = value;
		}
	}

	internal virtual TextBox tCoName
	{
		[CompilerGenerated]
		get
		{
			return _tCoName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCoName_KeyDown);
			CancelEventHandler cancelEventHandler = tCoName_Validating;
			EventHandler eventHandler = tCoName_DoubleClick;
			TextBox val2 = _tCoName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tCoName = value;
			val2 = _tCoName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual TextBox tCoCode
	{
		[CompilerGenerated]
		get
		{
			return _tCoCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCoCode_KeyDown);
			TextBox val2 = _tCoCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCoCode = value;
			val2 = _tCoCode;
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
	[AccessedThroughProperty("Pnl3")]
	private virtual Panel _Pnl3;

	internal virtual Panel Pnl3
	{
		get
		{
			return _Pnl3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl3 = value;
		}
	}

	internal virtual TextBox tRtgsNo
	{
		[CompilerGenerated]
		get
		{
			return _tRtgsNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRtgsNo_KeyDown);
			TextBox val2 = _tRtgsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRtgsNo = value;
			val2 = _tRtgsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankAcNo
	{
		[CompilerGenerated]
		get
		{
			return _tBankAcNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankAcNo_KeyDown);
			TextBox val2 = _tBankAcNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankAcNo = value;
			val2 = _tBankAcNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankArea
	{
		[CompilerGenerated]
		get
		{
			return _tBankArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankArea_KeyDown);
			TextBox val2 = _tBankArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankArea = value;
			val2 = _tBankArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankName
	{
		[CompilerGenerated]
		get
		{
			return _tBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankName_KeyDown);
			TextBox val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankName = value;
			val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl2")]
	private virtual Panel _Pnl2;

	internal virtual Panel Pnl2
	{
		get
		{
			return _Pnl2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl2 = value;
		}
	}

	internal virtual TextBox tPanNo
	{
		[CompilerGenerated]
		get
		{
			return _tPanNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPanNo_KeyDown);
			TextBox val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPanNo = value;
			val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tDhiranNo
	{
		[CompilerGenerated]
		get
		{
			return _tDhiranNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tDhiranNo_KeyDown);
			TextBox val2 = _tDhiranNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tDhiranNo = value;
			val2 = _tDhiranNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tCstNo
	{
		[CompilerGenerated]
		get
		{
			return _tCstNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCstNo_KeyDown);
			TextBox val2 = _tCstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCstNo = value;
			val2 = _tCstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tGstNo
	{
		[CompilerGenerated]
		get
		{
			return _tGstNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGstNo_KeyDown);
			EventHandler eventHandler = tGstNo_DoubleClick;
			TextBox val2 = _tGstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tGstNo = value;
			val2 = _tGstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMoNo2")]
	private virtual Label _lblMoNo2;

	internal virtual Label lblMoNo2
	{
		get
		{
			return _lblMoNo2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMoNo2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label9")]
	private virtual Label _Label9;

	internal virtual Label Label9
	{
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label9 = value;
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
			EventHandler eventHandler = Text1_Click;
			EventHandler eventHandler2 = Text1_TextChanged;
			TextBox val = _Text1;
			if (val != null)
			{
				((TextBoxBase)val).Click -= eventHandler;
				((Control)val).TextChanged -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((TextBoxBase)val).Click += eventHandler;
				((Control)val).TextChanged += eventHandler2;
			}
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

	internal virtual Label lblCoReset
	{
		[CompilerGenerated]
		get
		{
			return _lblCoReset;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = LblCoReset_Click;
			Label val = _lblCoReset;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_lblCoReset = value;
			val = _lblCoReset;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboMetalType
	{
		[CompilerGenerated]
		get
		{
			return _cboMetalType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboMetalType_KeyDown);
			ComboBox val2 = _cboMetalType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboMetalType = value;
			val2 = _cboMetalType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label17")]
	private virtual Label _Label17;

	internal virtual Label Label17
	{
		get
		{
			return _Label17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label17 = value;
		}
	}

	internal virtual ComboBox cboWorkType
	{
		[CompilerGenerated]
		get
		{
			return _cboWorkType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboWorkType_KeyDown);
			ComboBox val2 = _cboWorkType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboWorkType = value;
			val2 = _cboWorkType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	private virtual Label _Label16;

	internal virtual Label Label16
	{
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label16 = value;
		}
	}

	internal virtual TextBox tJudrection
	{
		[CompilerGenerated]
		get
		{
			return _tJudrection;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tJudrection_KeyDown);
			TextBox val2 = _tJudrection;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tJudrection = value;
			val2 = _tJudrection;
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

	internal virtual TextBox tStateCode
	{
		[CompilerGenerated]
		get
		{
			return _tStateCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tStateCode_KeyDown);
			EventHandler eventHandler = TStateCode_TextChanged;
			TextBox val2 = _tStateCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tStateCode = value;
			val2 = _tStateCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mLockDate
	{
		[CompilerGenerated]
		get
		{
			return _mLockDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mLockDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mLockDate_KeyDown);
			MaskedTextBox val2 = _mLockDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mLockDate = value;
			val2 = _mLockDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLockDt")]
	private virtual Label _lblLockDt;

	internal virtual Label lblLockDt
	{
		get
		{
			return _lblLockDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLockDt = value;
		}
	}

	internal virtual TextBox tCoType
	{
		[CompilerGenerated]
		get
		{
			return _tCoType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCoType_KeyDown);
			TextBox val2 = _tCoType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCoType = value;
			val2 = _tCoType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label18")]
	private virtual Label _Label18;

	internal virtual Label Label18
	{
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label18 = value;
		}
	}

	internal virtual ComboBox cboWithOldCoMast
	{
		[CompilerGenerated]
		get
		{
			return _cboWithOldCoMast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = cboWithOldCoMast_SelectedIndexChanged;
			KeyEventHandler val = new KeyEventHandler(cboWithOldCoMast_KeyDown);
			ComboBox val2 = _cboWithOldCoMast;
			if (val2 != null)
			{
				val2.SelectedIndexChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_cboWithOldCoMast = value;
			val2 = _cboWithOldCoMast;
			if (val2 != null)
			{
				val2.SelectedIndexChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label19")]
	private virtual Label _Label19;

	internal virtual Label Label19
	{
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label19 = value;
		}
	}

	internal virtual Panel PanelAbc
	{
		[CompilerGenerated]
		get
		{
			return _PanelAbc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PanelAbc_DoubleClick;
			Panel val = _PanelAbc;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PanelAbc = value;
			val = _PanelAbc;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label22")]
	private virtual Label _Label22;

	internal virtual Label Label22
	{
		get
		{
			return _Label22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label22 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label23")]
	private virtual Label _Label23;

	internal virtual Label Label23
	{
		get
		{
			return _Label23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label23 = value;
		}
	}

	internal virtual TextBox tC
	{
		[CompilerGenerated]
		get
		{
			return _tC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tC_KeyDown);
			TextBox val2 = _tC;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tC = value;
			val2 = _tC;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tB
	{
		[CompilerGenerated]
		get
		{
			return _tB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tB_KeyDown);
			TextBox val2 = _tB;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tB = value;
			val2 = _tB;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tA
	{
		[CompilerGenerated]
		get
		{
			return _tA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tA_KeyDown);
			TextBox val2 = _tA;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tA = value;
			val2 = _tA;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label24")]
	private virtual Label _Label24;

	internal virtual Label Label24
	{
		get
		{
			return _Label24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label24 = value;
		}
	}

	internal virtual SimpleButton btnSet
	{
		[CompilerGenerated]
		get
		{
			return _btnSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSet_Click;
			SimpleButton val = _btnSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSet = value;
			val = _btnSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabMenu")]
	private virtual SuperTabControl _TabMenu;

	internal virtual SuperTabControl TabMenu
	{
		get
		{
			return _TabMenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabMenu = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel1")]
	private virtual SuperTabControlPanel _TabPanel1;

	internal virtual SuperTabControlPanel TabPanel1
	{
		get
		{
			return _TabPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab1")]
	private virtual SuperTabItem _Tab1;

	internal virtual SuperTabItem Tab1
	{
		get
		{
			return _Tab1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel3")]
	private virtual SuperTabControlPanel _TabPanel3;

	internal virtual SuperTabControlPanel TabPanel3
	{
		get
		{
			return _TabPanel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab3")]
	private virtual SuperTabItem _Tab3;

	internal virtual SuperTabItem Tab3
	{
		get
		{
			return _Tab3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel2")]
	private virtual SuperTabControlPanel _TabPanel2;

	internal virtual SuperTabControlPanel TabPanel2
	{
		get
		{
			return _TabPanel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab2")]
	private virtual SuperTabItem _Tab2;

	internal virtual SuperTabItem Tab2
	{
		get
		{
			return _Tab2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab2 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = GroupBox1_DoubleClick;
			GroupBox val = _GroupBox1;
			if (val != null)
			{
				val.DoubleClick -= eventHandler;
			}
			_GroupBox1 = value;
			val = _GroupBox1;
			if (val != null)
			{
				val.DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tePortalId")]
	private virtual TextBox _tePortalId;

	internal virtual TextBox tePortalId
	{
		get
		{
			return _tePortalId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tePortalId = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label20")]
	private virtual Label _Label20;

	internal virtual Label Label20
	{
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label20 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("teGstNo")]
	private virtual TextBox _teGstNo;

	internal virtual TextBox teGstNo
	{
		get
		{
			return _teGstNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_teGstNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label26")]
	private virtual Label _Label26;

	internal virtual Label Label26
	{
		get
		{
			return _Label26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label26 = value;
		}
	}

	internal virtual SimpleButton btneExit
	{
		[CompilerGenerated]
		get
		{
			return _btneExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtneExit_Click;
			SimpleButton val = _btneExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btneExit = value;
			val = _btneExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btneSave
	{
		[CompilerGenerated]
		get
		{
			return _btneSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtneSave_Click;
			SimpleButton val = _btneSave;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btneSave = value;
			val = _btneSave;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tAspPwd
	{
		[CompilerGenerated]
		get
		{
			return _tAspPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tAspPwd_DoubleClick;
			TextBox val = _tAspPwd;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_tAspPwd = value;
			val = _tAspPwd;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label27")]
	private virtual Label _Label27;

	internal virtual Label Label27
	{
		get
		{
			return _Label27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label27 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAspId")]
	private virtual TextBox _tAspId;

	internal virtual TextBox tAspId
	{
		get
		{
			return _tAspId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAspId = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label25")]
	private virtual Label _Label25;

	internal virtual Label Label25
	{
		get
		{
			return _Label25;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label25 = value;
		}
	}

	internal virtual TextBox tePortalPwd
	{
		[CompilerGenerated]
		get
		{
			return _tePortalPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tePortalPwd_DoubleClick;
			TextBox val = _tePortalPwd;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_tePortalPwd = value;
			val = _tePortalPwd;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label21")]
	private virtual Label _Label21;

	internal virtual Label Label21
	{
		get
		{
			return _Label21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label21 = value;
		}
	}

	internal virtual Panel Panel1
	{
		[CompilerGenerated]
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			PaintEventHandler val = new PaintEventHandler(Panel1_Paint);
			EventHandler eventHandler = Panel1_DoubleClick;
			Panel val2 = _Panel1;
			if (val2 != null)
			{
				((Control)val2).Paint -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_Panel1 = value;
			val2 = _Panel1;
			if (val2 != null)
			{
				((Control)val2).Paint += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnUrlSet
	{
		[CompilerGenerated]
		get
		{
			return _btnUrlSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnUrlSet_Click;
			SimpleButton val = _btnUrlSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUrlSet = value;
			val = _btnUrlSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label28")]
	private virtual Label _Label28;

	internal virtual Label Label28
	{
		get
		{
			return _Label28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label28 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label29")]
	private virtual Label _Label29;

	internal virtual Label Label29
	{
		get
		{
			return _Label29;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label29 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUrlPwd")]
	private virtual TextBox _tUrlPwd;

	internal virtual TextBox tUrlPwd
	{
		get
		{
			return _tUrlPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUrlPwd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUrlId")]
	private virtual TextBox _tUrlId;

	internal virtual TextBox tUrlId
	{
		get
		{
			return _tUrlId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUrlId = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUrlPath")]
	private virtual TextBox _tUrlPath;

	internal virtual TextBox tUrlPath
	{
		get
		{
			return _tUrlPath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUrlPath = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label30")]
	private virtual Label _Label30;

	internal virtual Label Label30
	{
		get
		{
			return _Label30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label30 = value;
		}
	}

	internal virtual TextBox tHttpPath
	{
		[CompilerGenerated]
		get
		{
			return _tHttpPath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHttpPath_KeyDown);
			TextBox val2 = _tHttpPath;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHttpPath = value;
			val2 = _tHttpPath;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label31")]
	private virtual Label _Label31;

	internal virtual Label Label31
	{
		get
		{
			return _Label31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label31 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLigalName")]
	private virtual TextBox _tLigalName;

	internal virtual TextBox tLigalName
	{
		get
		{
			return _tLigalName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLigalName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLigalName")]
	private virtual Label _lblLigalName;

	internal virtual Label lblLigalName
	{
		get
		{
			return _lblLigalName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLigalName = value;
		}
	}

	internal virtual TextBox tMailApi
	{
		[CompilerGenerated]
		get
		{
			return _tMailApi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMailApi_KeyDown);
			TextBox val2 = _tMailApi;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMailApi = value;
			val2 = _tMailApi;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMailApi")]
	private virtual Label _lblMailApi;

	internal virtual Label lblMailApi
	{
		get
		{
			return _lblMailApi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMailApi = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlUae")]
	private virtual Panel _pnlUae;

	internal virtual Panel pnlUae
	{
		get
		{
			return _pnlUae;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlUae = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label35")]
	private virtual Label _Label35;

	internal virtual Label Label35
	{
		get
		{
			return _Label35;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label35 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTerminalCode")]
	private virtual TextBox _tTerminalCode;

	internal virtual TextBox tTerminalCode
	{
		get
		{
			return _tTerminalCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTerminalCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label32")]
	private virtual Label _Label32;

	internal virtual Label Label32
	{
		get
		{
			return _Label32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label32 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tClientSecret")]
	private virtual TextBox _tClientSecret;

	internal virtual TextBox tClientSecret
	{
		get
		{
			return _tClientSecret;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tClientSecret = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label33")]
	private virtual Label _Label33;

	internal virtual Label Label33
	{
		get
		{
			return _Label33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label33 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUaeClientId")]
	private virtual TextBox _tUaeClientId;

	internal virtual TextBox tUaeClientId
	{
		get
		{
			return _tUaeClientId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUaeClientId = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label34")]
	private virtual Label _Label34;

	internal virtual Label Label34
	{
		get
		{
			return _Label34;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label34 = value;
		}
	}

	internal virtual SimpleButton BtnExitUae
	{
		[CompilerGenerated]
		get
		{
			return _BtnExitUae;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExitUae_Click;
			SimpleButton val = _BtnExitUae;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExitUae = value;
			val = _BtnExitUae;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnSaveUae
	{
		[CompilerGenerated]
		get
		{
			return _btnSaveUae;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSaveUae_Click;
			SimpleButton val = _btnSaveUae;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSaveUae = value;
			val = _btnSaveUae;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkResetData")]
	private virtual CheckBox _chkResetData;

	internal virtual CheckBox chkResetData
	{
		get
		{
			return _chkResetData;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkResetData = value;
		}
	}

	internal virtual TextBox tAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			EventHandler eventHandler = tAcCode_TextChanged;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private virtual TextBox _tAcName;

	internal virtual TextBox tAcName
	{
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Lblfanac")]
	private virtual Label _Lblfanac;

	internal virtual Label Lblfanac
	{
		get
		{
			return _Lblfanac;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Lblfanac = value;
		}
	}

	public int newindex { get; set; }

	public MS_COMPANY()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += MS_COMPANY_Load;
		((Form)this).Deactivate += MS_COMPANY_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_COMPANY_KeyPress);
		((Control)this).Validated += MS_COMPANY_Validated;
		((Control)this).KeyDown += new KeyEventHandler(MS_COMPANY_KeyDown);
		((Form)this).Activated += MS_COMPANY_Activated;
		((Form)this).Closed += MS_COMPANY_Closed;
		CurLcCode = "00";
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
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected O, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected O, but got Unknown
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Expected O, but got Unknown
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected O, but got Unknown
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Expected O, but got Unknown
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Expected O, but got Unknown
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Expected O, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Expected O, but got Unknown
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Expected O, but got Unknown
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0885: Expected O, but got Unknown
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Expected O, but got Unknown
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4d: Expected O, but got Unknown
		//IL_0b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b74: Expected O, but got Unknown
		//IL_0bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be1: Expected O, but got Unknown
		//IL_0c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c94: Expected O, but got Unknown
		//IL_0cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d01: Expected O, but got Unknown
		//IL_0ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de6: Expected O, but got Unknown
		//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Expected O, but got Unknown
		//IL_0f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5e: Expected O, but got Unknown
		//IL_0fdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe6: Expected O, but got Unknown
		//IL_10bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c9: Expected O, but got Unknown
		//IL_1132: Unknown result type (might be due to invalid IL or missing references)
		//IL_113c: Expected O, but got Unknown
		//IL_12d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12dd: Expected O, but got Unknown
		//IL_1323: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Expected O, but got Unknown
		//IL_185a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1864: Expected O, but got Unknown
		//IL_1884: Unknown result type (might be due to invalid IL or missing references)
		//IL_1908: Unknown result type (might be due to invalid IL or missing references)
		//IL_1912: Expected O, but got Unknown
		//IL_19fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a07: Expected O, but got Unknown
		//IL_1a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8e: Expected O, but got Unknown
		//IL_1b4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b59: Expected O, but got Unknown
		//IL_1bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf4: Expected O, but got Unknown
		//IL_1ca8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb2: Expected O, but got Unknown
		//IL_1d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d66: Expected O, but got Unknown
		//IL_1de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df0: Expected O, but got Unknown
		//IL_1ed1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edb: Expected O, but got Unknown
		//IL_1f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f62: Expected O, but got Unknown
		//IL_2040: Unknown result type (might be due to invalid IL or missing references)
		//IL_204a: Expected O, but got Unknown
		//IL_20c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d1: Expected O, but got Unknown
		//IL_2182: Unknown result type (might be due to invalid IL or missing references)
		//IL_218c: Expected O, but got Unknown
		//IL_21af: Unknown result type (might be due to invalid IL or missing references)
		//IL_2223: Unknown result type (might be due to invalid IL or missing references)
		//IL_222d: Expected O, but got Unknown
		//IL_22e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22eb: Expected O, but got Unknown
		//IL_230e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2382: Unknown result type (might be due to invalid IL or missing references)
		//IL_238c: Expected O, but got Unknown
		//IL_2440: Unknown result type (might be due to invalid IL or missing references)
		//IL_244a: Expected O, but got Unknown
		//IL_246d: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ea: Expected O, but got Unknown
		//IL_259b: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a5: Expected O, but got Unknown
		//IL_25c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2638: Unknown result type (might be due to invalid IL or missing references)
		//IL_2642: Expected O, but got Unknown
		//IL_2700: Unknown result type (might be due to invalid IL or missing references)
		//IL_270a: Expected O, but got Unknown
		//IL_272a: Unknown result type (might be due to invalid IL or missing references)
		//IL_279e: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a8: Expected O, but got Unknown
		//IL_27c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_283c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2846: Expected O, but got Unknown
		//IL_2866: Unknown result type (might be due to invalid IL or missing references)
		//IL_28da: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e4: Expected O, but got Unknown
		//IL_2904: Unknown result type (might be due to invalid IL or missing references)
		//IL_2977: Unknown result type (might be due to invalid IL or missing references)
		//IL_2981: Expected O, but got Unknown
		//IL_29a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a1e: Expected O, but got Unknown
		//IL_2a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab8: Expected O, but got Unknown
		//IL_2ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b52: Expected O, but got Unknown
		//IL_2b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bef: Expected O, but got Unknown
		//IL_2c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca7: Expected O, but got Unknown
		//IL_2d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d5f: Expected O, but got Unknown
		//IL_2e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e17: Expected O, but got Unknown
		//IL_2ec5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ecf: Expected O, but got Unknown
		//IL_2f7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f87: Expected O, but got Unknown
		//IL_3032: Unknown result type (might be due to invalid IL or missing references)
		//IL_303c: Expected O, but got Unknown
		//IL_30e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f1: Expected O, but got Unknown
		//IL_31a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_31ac: Expected O, but got Unknown
		//IL_322a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3234: Expected O, but got Unknown
		//IL_32ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_32b8: Expected O, but got Unknown
		//IL_3363: Unknown result type (might be due to invalid IL or missing references)
		//IL_336d: Expected O, but got Unknown
		//IL_3795: Unknown result type (might be due to invalid IL or missing references)
		//IL_379f: Expected O, but got Unknown
		//IL_3877: Unknown result type (might be due to invalid IL or missing references)
		//IL_3881: Expected O, but got Unknown
		//IL_391d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3927: Expected O, but got Unknown
		//IL_3a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a46: Expected O, but got Unknown
		//IL_3af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3afe: Expected O, but got Unknown
		//IL_3bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bb6: Expected O, but got Unknown
		//IL_3c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c59: Expected O, but got Unknown
		//IL_3cf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cfc: Expected O, but got Unknown
		//IL_3d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d9f: Expected O, but got Unknown
		//IL_3e4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e57: Expected O, but got Unknown
		//IL_3e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ef5: Expected O, but got Unknown
		//IL_3fa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fb0: Expected O, but got Unknown
		//IL_3fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4041: Unknown result type (might be due to invalid IL or missing references)
		//IL_404b: Expected O, but got Unknown
		//IL_4068: Unknown result type (might be due to invalid IL or missing references)
		//IL_40dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_40e6: Expected O, but got Unknown
		//IL_4103: Unknown result type (might be due to invalid IL or missing references)
		//IL_4177: Unknown result type (might be due to invalid IL or missing references)
		//IL_4181: Expected O, but got Unknown
		//IL_419e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4201: Unknown result type (might be due to invalid IL or missing references)
		//IL_420b: Expected O, but got Unknown
		//IL_42a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_42af: Expected O, but got Unknown
		//IL_4349: Unknown result type (might be due to invalid IL or missing references)
		//IL_4353: Expected O, but got Unknown
		//IL_43ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_43f7: Expected O, but got Unknown
		//IL_47f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_47fc: Expected O, but got Unknown
		//IL_4892: Unknown result type (might be due to invalid IL or missing references)
		//IL_489c: Expected O, but got Unknown
		//IL_496a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4974: Expected O, but got Unknown
		//IL_4a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a56: Expected O, but got Unknown
		//IL_4af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4afc: Expected O, but got Unknown
		//IL_4c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c1b: Expected O, but got Unknown
		//IL_4cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ce0: Expected O, but got Unknown
		//IL_4d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4da5: Expected O, but got Unknown
		//IL_4e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e58: Expected O, but got Unknown
		//IL_4ef4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4efe: Expected O, but got Unknown
		//IL_4f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f9a: Expected O, but got Unknown
		//IL_5048: Unknown result type (might be due to invalid IL or missing references)
		//IL_5052: Expected O, but got Unknown
		//IL_506f: Unknown result type (might be due to invalid IL or missing references)
		//IL_50e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_50ed: Expected O, but got Unknown
		//IL_510a: Unknown result type (might be due to invalid IL or missing references)
		//IL_517e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5188: Expected O, but got Unknown
		//IL_51a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5219: Unknown result type (might be due to invalid IL or missing references)
		//IL_5223: Expected O, but got Unknown
		//IL_5240: Unknown result type (might be due to invalid IL or missing references)
		//IL_52a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_52aa: Expected O, but got Unknown
		//IL_5341: Unknown result type (might be due to invalid IL or missing references)
		//IL_534b: Expected O, but got Unknown
		//IL_53e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_53ec: Expected O, but got Unknown
		//IL_5483: Unknown result type (might be due to invalid IL or missing references)
		//IL_548d: Expected O, but got Unknown
		//IL_56ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_56d4: Expected O, but got Unknown
		//IL_5779: Unknown result type (might be due to invalid IL or missing references)
		//IL_5783: Expected O, but got Unknown
		//IL_57a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_5826: Unknown result type (might be due to invalid IL or missing references)
		//IL_5830: Expected O, but got Unknown
		//IL_5853: Unknown result type (might be due to invalid IL or missing references)
		//IL_58cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_58d5: Expected O, but got Unknown
		//IL_5938: Unknown result type (might be due to invalid IL or missing references)
		//IL_5942: Expected O, but got Unknown
		//IL_59f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_59fd: Expected O, but got Unknown
		//IL_5a60: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a6a: Expected O, but got Unknown
		//IL_5b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b20: Expected O, but got Unknown
		//IL_5b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bce: Expected O, but got Unknown
		//IL_5bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c61: Expected O, but got Unknown
		//IL_5c84: Unknown result type (might be due to invalid IL or missing references)
		//IL_5cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d01: Expected O, but got Unknown
		//IL_5d24: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d94: Expected O, but got Unknown
		//IL_5db4: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e3f: Expected O, but got Unknown
		//IL_5e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ec5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ecf: Expected O, but got Unknown
		//IL_5eef: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f62: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f6c: Expected O, but got Unknown
		//IL_5f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ffc: Expected O, but got Unknown
		//IL_601c: Unknown result type (might be due to invalid IL or missing references)
		//IL_608f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6099: Expected O, but got Unknown
		//IL_60b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_6265: Unknown result type (might be due to invalid IL or missing references)
		//IL_626f: Expected O, but got Unknown
		//IL_62d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_62dc: Expected O, but got Unknown
		//IL_638d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6397: Expected O, but got Unknown
		//IL_63fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_6404: Expected O, but got Unknown
		//IL_64bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_64c7: Expected O, but got Unknown
		//IL_64ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_6550: Unknown result type (might be due to invalid IL or missing references)
		//IL_655a: Expected O, but got Unknown
		//IL_657a: Unknown result type (might be due to invalid IL or missing references)
		//IL_65ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_65f7: Expected O, but got Unknown
		//IL_6617: Unknown result type (might be due to invalid IL or missing references)
		//IL_667d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6687: Expected O, but got Unknown
		//IL_66a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_671a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6724: Expected O, but got Unknown
		//IL_6744: Unknown result type (might be due to invalid IL or missing references)
		//IL_67aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_67b4: Expected O, but got Unknown
		//IL_67d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_6847: Unknown result type (might be due to invalid IL or missing references)
		//IL_6851: Expected O, but got Unknown
		//IL_6871: Unknown result type (might be due to invalid IL or missing references)
		//IL_6910: Unknown result type (might be due to invalid IL or missing references)
		//IL_691a: Expected O, but got Unknown
		//IL_6948: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a14: Expected O, but got Unknown
		//IL_6acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ad7: Expected O, but got Unknown
		//IL_6afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b8a: Expected O, but got Unknown
		//IL_6c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c52: Expected O, but got Unknown
		//IL_6d22: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d2c: Expected O, but got Unknown
		//IL_6dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6dc7: Expected O, but got Unknown
		//IL_6e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e66: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_COMPANY));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		lblBook = new Label();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		tMailApi = new TextBox();
		lblMailApi = new Label();
		cboWithOldCoMast = new ComboBox();
		Label19 = new Label();
		tCoType = new TextBox();
		Label18 = new Label();
		tStateCode = new TextBox();
		cboMetalType = new ComboBox();
		Label17 = new Label();
		cboWorkType = new ComboBox();
		Label16 = new Label();
		cboRptHader = new ComboBox();
		Label15 = new Label();
		tMobile2 = new TextBox();
		Label6 = new Label();
		tPhone2 = new TextBox();
		Label5 = new Label();
		TState = new TextBox();
		Label4 = new Label();
		tCountry = new TextBox();
		Label3 = new Label();
		tEmail = new TextBox();
		tMobile = new TextBox();
		tPhone = new TextBox();
		tCity = new TextBox();
		tAddress3 = new TextBox();
		tAddress2 = new TextBox();
		tAddress1 = new TextBox();
		tPinCode = new TextBox();
		lblEmail = new Label();
		lblMoNo = new Label();
		lblPhone = new Label();
		lblCity = new Label();
		lblAdd3 = new Label();
		lblAdd2 = new Label();
		lblAdd1 = new Label();
		lblBookCo = new Label();
		tCoName = new TextBox();
		tCoCode = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Tab1 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		PanelAbc = new Panel();
		btnSet = new SimpleButton();
		Label22 = new Label();
		Label23 = new Label();
		tC = new TextBox();
		tB = new TextBox();
		tA = new TextBox();
		Label24 = new Label();
		tJudrection = new TextBox();
		Label7 = new Label();
		tPanNo = new TextBox();
		tDhiranNo = new TextBox();
		tCstNo = new TextBox();
		tGstNo = new TextBox();
		Label8 = new Label();
		lblMoNo2 = new Label();
		Label9 = new Label();
		Label10 = new Label();
		Tab2 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		Panel1 = new Panel();
		tHttpPath = new TextBox();
		Label31 = new Label();
		btnUrlSet = new SimpleButton();
		Label28 = new Label();
		Label29 = new Label();
		tUrlPwd = new TextBox();
		tUrlId = new TextBox();
		tUrlPath = new TextBox();
		Label30 = new Label();
		tRtgsNo = new TextBox();
		tBankAcNo = new TextBox();
		tBankArea = new TextBox();
		tBankName = new TextBox();
		Label11 = new Label();
		Label12 = new Label();
		Label13 = new Label();
		Label14 = new Label();
		Tab3 = new SuperTabItem();
		GroupBox1 = new GroupBox();
		tLigalName = new TextBox();
		lblLigalName = new Label();
		btneExit = new SimpleButton();
		btneSave = new SimpleButton();
		tAspPwd = new TextBox();
		Label27 = new Label();
		tAspId = new TextBox();
		Label25 = new Label();
		tePortalPwd = new TextBox();
		Label21 = new Label();
		tePortalId = new TextBox();
		Label20 = new Label();
		teGstNo = new TextBox();
		Label26 = new Label();
		pnlUae = new Panel();
		BtnExitUae = new SimpleButton();
		btnSaveUae = new SimpleButton();
		Label35 = new Label();
		tTerminalCode = new TextBox();
		Label32 = new Label();
		tClientSecret = new TextBox();
		Label33 = new Label();
		tUaeClientId = new TextBox();
		Label34 = new Label();
		Text1 = new TextBox();
		Cr = new AxCrystalReport();
		lblCoReset = new Label();
		mLockDate = new MaskedTextBox();
		lblLockDt = new Label();
		chkResetData = new CheckBox();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Lblfanac = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)Pnl2).SuspendLayout();
		((Control)PanelAbc).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
		((Control)Pnl3).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((Control)GroupBox1).SuspendLayout();
		((Control)pnlUae).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
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
		((Control)PnlBotam).TabIndex = 26;
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
		((Control)BtnSave).TabIndex = 0;
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
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
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
		lblBook.Text = "Company Master";
		lblBook.TextAlign = (ContentAlignment)32;
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
		((DataGridView)DGV).ColumnHeadersHeight = 30;
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
		((DataGridView)DGV).GridColor = Color.FromArgb(127, 127, 127);
		((Control)DGV).Location = new Point(69, 94);
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
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(404, 418);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 7;
		((BaseItem)TabMenu.ControlBox.CloseBox).Name = "";
		((BaseItem)TabMenu.ControlBox.MenuBox).Name = "";
		((BaseItem)TabMenu.ControlBox).Name = "";
		((BaseItem)TabMenu.ControlBox).SubItems.AddRange((BaseItem[])(object)new BaseItem[2]
		{
			(BaseItem)TabMenu.ControlBox.MenuBox,
			(BaseItem)TabMenu.ControlBox.CloseBox
		});
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel1);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel2);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel3);
		((Control)TabMenu).Location = new Point(563, 49);
		((Control)TabMenu).Name = "TabMenu";
		TabMenu.ReorderTabsEnabled = true;
		TabMenu.SelectedTabFont = new Font("Microsoft Sans Serif", 11.25f);
		TabMenu.SelectedTabIndex = 0;
		((Control)TabMenu).Size = new Size(547, 463);
		TabMenu.TabAlignment = (eTabStripAlignment)3;
		TabMenu.TabFont = new Font("Microsoft Sans Serif", 11.25f);
		((Control)TabMenu).TabIndex = 8;
		TabMenu.TabLayoutType = (eSuperTabLayoutType)1;
		TabMenu.Tabs.AddRange((BaseItem[])(object)new BaseItem[3]
		{
			(BaseItem)Tab1,
			(BaseItem)Tab2,
			(BaseItem)Tab3
		});
		TabMenu.TabStyle = (eSuperTabStyle)1;
		((Control)TabMenu).Text = "SuperTabControl1";
		((PanelControl)TabPanel1).CanvasColor = Color.Black;
		((Control)TabPanel1).Controls.Add((Control)(object)Pnl1);
		TabPanel1.Dock = (DockStyle)5;
		((Control)TabPanel1).Location = new Point(0, 0);
		((Control)TabPanel1).Name = "TabPanel1";
		((Control)TabPanel1).Size = new Size(547, 436);
		((Control)TabPanel1).TabIndex = 0;
		TabPanel1.TabItem = Tab1;
		((Control)Pnl1).Controls.Add((Control)(object)tMailApi);
		((Control)Pnl1).Controls.Add((Control)(object)lblMailApi);
		((Control)Pnl1).Controls.Add((Control)(object)cboWithOldCoMast);
		((Control)Pnl1).Controls.Add((Control)(object)Label19);
		((Control)Pnl1).Controls.Add((Control)(object)tCoType);
		((Control)Pnl1).Controls.Add((Control)(object)Label18);
		((Control)Pnl1).Controls.Add((Control)(object)tStateCode);
		((Control)Pnl1).Controls.Add((Control)(object)cboMetalType);
		((Control)Pnl1).Controls.Add((Control)(object)Label17);
		((Control)Pnl1).Controls.Add((Control)(object)cboWorkType);
		((Control)Pnl1).Controls.Add((Control)(object)Label16);
		((Control)Pnl1).Controls.Add((Control)(object)cboRptHader);
		((Control)Pnl1).Controls.Add((Control)(object)Label15);
		((Control)Pnl1).Controls.Add((Control)(object)tMobile2);
		((Control)Pnl1).Controls.Add((Control)(object)Label6);
		((Control)Pnl1).Controls.Add((Control)(object)tPhone2);
		((Control)Pnl1).Controls.Add((Control)(object)Label5);
		((Control)Pnl1).Controls.Add((Control)(object)TState);
		((Control)Pnl1).Controls.Add((Control)(object)Label4);
		((Control)Pnl1).Controls.Add((Control)(object)tCountry);
		((Control)Pnl1).Controls.Add((Control)(object)Label3);
		((Control)Pnl1).Controls.Add((Control)(object)tEmail);
		((Control)Pnl1).Controls.Add((Control)(object)tMobile);
		((Control)Pnl1).Controls.Add((Control)(object)tPhone);
		((Control)Pnl1).Controls.Add((Control)(object)tCity);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress3);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress2);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress1);
		((Control)Pnl1).Controls.Add((Control)(object)tPinCode);
		((Control)Pnl1).Controls.Add((Control)(object)lblEmail);
		((Control)Pnl1).Controls.Add((Control)(object)lblMoNo);
		((Control)Pnl1).Controls.Add((Control)(object)lblPhone);
		((Control)Pnl1).Controls.Add((Control)(object)lblCity);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd3);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd2);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd1);
		((Control)Pnl1).Controls.Add((Control)(object)lblBookCo);
		((Control)Pnl1).Controls.Add((Control)(object)tCoName);
		((Control)Pnl1).Controls.Add((Control)(object)tCoCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label2);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		((Control)Pnl1).Location = new Point(-12, -2);
		((Control)Pnl1).Name = "Pnl1";
		((Control)Pnl1).Size = new Size(578, 438);
		((Control)Pnl1).TabIndex = 109;
		((TextBoxBase)tMailApi).BackColor = SystemColors.Window;
		tMailApi.CharacterCasing = (CharacterCasing)2;
		((Control)tMailApi).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMailApi).Location = new Point(127, 409);
		((Control)tMailApi).Margin = new Padding(2);
		((TextBoxBase)tMailApi).MaxLength = 100;
		((Control)tMailApi).Name = "tMailApi";
		((Control)tMailApi).Size = new Size(391, 23);
		((Control)tMailApi).TabIndex = 1161;
		((Control)tMailApi).Visible = false;
		((Control)lblMailApi).BackColor = Color.Transparent;
		((Control)lblMailApi).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMailApi).ForeColor = Color.Black;
		lblMailApi.ImeMode = (ImeMode)0;
		((Control)lblMailApi).Location = new Point(24, 409);
		((Control)lblMailApi).Name = "lblMailApi";
		((Control)lblMailApi).Size = new Size(95, 19);
		((Control)lblMailApi).TabIndex = 1162;
		lblMailApi.Text = "Email Api";
		lblMailApi.TextAlign = (ContentAlignment)16;
		((Control)lblMailApi).Visible = false;
		cboWithOldCoMast.AutoCompleteMode = (AutoCompleteMode)2;
		cboWithOldCoMast.AutoCompleteSource = (AutoCompleteSource)256;
		cboWithOldCoMast.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboWithOldCoMast).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboWithOldCoMast).FormattingEnabled = true;
		((Control)cboWithOldCoMast).Location = new Point(442, 17);
		cboWithOldCoMast.MaxLength = 5;
		((Control)cboWithOldCoMast).Name = "cboWithOldCoMast";
		((Control)cboWithOldCoMast).Size = new Size(76, 24);
		((Control)cboWithOldCoMast).TabIndex = 146;
		((Control)Label19).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(265, 18);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(171, 20);
		((Control)Label19).TabIndex = 147;
		Label19.Text = "With Old Company Master";
		Label19.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tCoType).BackColor = SystemColors.Window;
		((Control)tCoType).Enabled = false;
		((Control)tCoType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCoType).Location = new Point(380, 381);
		((TextBoxBase)tCoType).MaxLength = 1;
		((Control)tCoType).Name = "tCoType";
		((Control)tCoType).Size = new Size(65, 23);
		((Control)tCoType).TabIndex = 144;
		tCoType.TextAlign = (HorizontalAlignment)2;
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(299, 382);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(73, 20);
		((Control)Label18).TabIndex = 145;
		Label18.Text = "Co Type";
		Label18.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tStateCode).BackColor = SystemColors.Window;
		((Control)tStateCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tStateCode).Location = new Point(127, 197);
		((TextBoxBase)tStateCode).MaxLength = 2;
		((Control)tStateCode).Name = "tStateCode";
		((Control)tStateCode).Size = new Size(65, 23);
		((Control)tStateCode).TabIndex = 6;
		cboMetalType.AutoCompleteMode = (AutoCompleteMode)2;
		cboMetalType.AutoCompleteSource = (AutoCompleteSource)256;
		cboMetalType.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboMetalType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboMetalType).FormattingEnabled = true;
		((Control)cboMetalType).Location = new Point(380, 348);
		cboMetalType.MaxLength = 5;
		((Control)cboMetalType).Name = "cboMetalType";
		((Control)cboMetalType).Size = new Size(138, 24);
		((Control)cboMetalType).TabIndex = 15;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(299, 348);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(73, 20);
		((Control)Label17).TabIndex = 143;
		Label17.Text = "Metal Type";
		Label17.TextAlign = (ContentAlignment)16;
		cboWorkType.AutoCompleteMode = (AutoCompleteMode)2;
		cboWorkType.AutoCompleteSource = (AutoCompleteSource)256;
		cboWorkType.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboWorkType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboWorkType).FormattingEnabled = true;
		((Control)cboWorkType).Location = new Point(127, 348);
		cboWorkType.MaxLength = 5;
		((Control)cboWorkType).Name = "cboWorkType";
		((Control)cboWorkType).Size = new Size(148, 24);
		((Control)cboWorkType).TabIndex = 14;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(24, 345);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(95, 20);
		((Control)Label16).TabIndex = 141;
		Label16.Text = "Work Type";
		Label16.TextAlign = (ContentAlignment)16;
		cboRptHader.AutoCompleteMode = (AutoCompleteMode)2;
		cboRptHader.AutoCompleteSource = (AutoCompleteSource)256;
		cboRptHader.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboRptHader).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboRptHader).FormattingEnabled = true;
		((Control)cboRptHader).Location = new Point(127, 380);
		cboRptHader.MaxLength = 5;
		((Control)cboRptHader).Name = "cboRptHader";
		((Control)cboRptHader).Size = new Size(148, 24);
		((Control)cboRptHader).TabIndex = 16;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(24, 381);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(95, 20);
		((Control)Label15).TabIndex = 139;
		Label15.Text = "Report Hader";
		Label15.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tMobile2).BackColor = SystemColors.Window;
		((Control)tMobile2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobile2).Location = new Point(380, 288);
		((Control)tMobile2).Margin = new Padding(2);
		((TextBoxBase)tMobile2).MaxLength = 15;
		((Control)tMobile2).Name = "tMobile2";
		((Control)tMobile2).Size = new Size(138, 23);
		((Control)tMobile2).TabIndex = 12;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(299, 290);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(75, 19);
		((Control)Label6).TabIndex = 135;
		Label6.Text = "Mobile No2";
		Label6.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tPhone2).BackColor = SystemColors.Window;
		((Control)tPhone2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPhone2).Location = new Point(380, 257);
		((Control)tPhone2).Margin = new Padding(2);
		((TextBoxBase)tPhone2).MaxLength = 15;
		((Control)tPhone2).Name = "tPhone2";
		((Control)tPhone2).Size = new Size(138, 23);
		((Control)tPhone2).TabIndex = 10;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(299, 259);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(76, 19);
		((Control)Label5).TabIndex = 133;
		Label5.Text = "Phone No2";
		Label5.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TState).BackColor = SystemColors.Window;
		((Control)TState).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TState).Location = new Point(197, 197);
		((Control)TState).Margin = new Padding(2);
		((TextBoxBase)TState).MaxLength = 25;
		((Control)TState).Name = "TState";
		((Control)TState).Size = new Size(321, 23);
		((Control)TState).TabIndex = 6;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(24, 199);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(95, 19);
		((Control)Label4).TabIndex = 131;
		Label4.Text = "State";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tCountry).BackColor = SystemColors.Window;
		((Control)tCountry).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCountry).Location = new Point(127, 167);
		((Control)tCountry).Margin = new Padding(2);
		((TextBoxBase)tCountry).MaxLength = 25;
		((Control)tCountry).Name = "tCountry";
		((Control)tCountry).Size = new Size(391, 23);
		((Control)tCountry).TabIndex = 5;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(24, 169);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(95, 19);
		((Control)Label3).TabIndex = 129;
		Label3.Text = "Country";
		Label3.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tEmail).BackColor = SystemColors.Window;
		tEmail.CharacterCasing = (CharacterCasing)2;
		((Control)tEmail).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmail).Location = new Point(127, 317);
		((Control)tEmail).Margin = new Padding(2);
		((TextBoxBase)tEmail).MaxLength = 50;
		((Control)tEmail).Name = "tEmail";
		((Control)tEmail).Size = new Size(391, 23);
		((Control)tEmail).TabIndex = 13;
		((TextBoxBase)tMobile).BackColor = SystemColors.Window;
		((Control)tMobile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobile).Location = new Point(127, 287);
		((Control)tMobile).Margin = new Padding(2);
		((TextBoxBase)tMobile).MaxLength = 15;
		((Control)tMobile).Name = "tMobile";
		((Control)tMobile).Size = new Size(148, 23);
		((Control)tMobile).TabIndex = 11;
		((TextBoxBase)tPhone).BackColor = SystemColors.Window;
		((Control)tPhone).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPhone).Location = new Point(127, 257);
		((Control)tPhone).Margin = new Padding(2);
		((TextBoxBase)tPhone).MaxLength = 15;
		((Control)tPhone).Name = "tPhone";
		((Control)tPhone).Size = new Size(148, 23);
		((Control)tPhone).TabIndex = 9;
		((TextBoxBase)tCity).BackColor = SystemColors.Window;
		((Control)tCity).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCity).Location = new Point(127, 227);
		((Control)tCity).Margin = new Padding(2);
		((TextBoxBase)tCity).MaxLength = 25;
		((Control)tCity).Name = "tCity";
		((Control)tCity).Size = new Size(216, 23);
		((Control)tCity).TabIndex = 7;
		((TextBoxBase)tAddress3).BackColor = SystemColors.Window;
		((Control)tAddress3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAddress3).Location = new Point(127, 137);
		((Control)tAddress3).Margin = new Padding(2);
		((TextBoxBase)tAddress3).MaxLength = 50;
		((Control)tAddress3).Name = "tAddress3";
		((Control)tAddress3).Size = new Size(391, 23);
		((Control)tAddress3).TabIndex = 4;
		((TextBoxBase)tAddress2).BackColor = SystemColors.Window;
		((Control)tAddress2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAddress2).Location = new Point(127, 107);
		((Control)tAddress2).Margin = new Padding(2);
		((TextBoxBase)tAddress2).MaxLength = 50;
		((Control)tAddress2).Name = "tAddress2";
		((Control)tAddress2).Size = new Size(391, 23);
		((Control)tAddress2).TabIndex = 3;
		((TextBoxBase)tAddress1).BackColor = SystemColors.Window;
		((Control)tAddress1).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAddress1).Location = new Point(127, 77);
		((Control)tAddress1).Margin = new Padding(2);
		((TextBoxBase)tAddress1).MaxLength = 50;
		((Control)tAddress1).Name = "tAddress1";
		((Control)tAddress1).Size = new Size(391, 23);
		((Control)tAddress1).TabIndex = 2;
		((TextBoxBase)tPinCode).BackColor = SystemColors.Window;
		((Control)tPinCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPinCode).Location = new Point(416, 228);
		((Control)tPinCode).Margin = new Padding(2);
		((TextBoxBase)tPinCode).MaxLength = 10;
		((Control)tPinCode).Name = "tPinCode";
		((Control)tPinCode).Size = new Size(102, 23);
		((Control)tPinCode).TabIndex = 8;
		((Control)lblEmail).BackColor = Color.Transparent;
		((Control)lblEmail).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblEmail).ForeColor = Color.Black;
		lblEmail.ImeMode = (ImeMode)0;
		((Control)lblEmail).Location = new Point(24, 319);
		((Control)lblEmail).Name = "lblEmail";
		((Control)lblEmail).Size = new Size(95, 19);
		((Control)lblEmail).TabIndex = 127;
		lblEmail.Text = "Email";
		lblEmail.TextAlign = (ContentAlignment)16;
		((Control)lblMoNo).BackColor = Color.Transparent;
		((Control)lblMoNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMoNo).ForeColor = Color.Black;
		lblMoNo.ImeMode = (ImeMode)0;
		((Control)lblMoNo).Location = new Point(24, 289);
		((Control)lblMoNo).Name = "lblMoNo";
		((Control)lblMoNo).Size = new Size(95, 19);
		((Control)lblMoNo).TabIndex = 126;
		lblMoNo.Text = "Mobile No";
		lblMoNo.TextAlign = (ContentAlignment)16;
		((Control)lblPhone).BackColor = Color.Transparent;
		((Control)lblPhone).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblPhone).ForeColor = Color.Black;
		lblPhone.ImeMode = (ImeMode)0;
		((Control)lblPhone).Location = new Point(24, 259);
		((Control)lblPhone).Name = "lblPhone";
		((Control)lblPhone).Size = new Size(95, 19);
		((Control)lblPhone).TabIndex = 125;
		lblPhone.Text = "Phone No";
		lblPhone.TextAlign = (ContentAlignment)16;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(24, 229);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(95, 19);
		((Control)lblCity).TabIndex = 124;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)16;
		((Control)lblAdd3).BackColor = Color.Transparent;
		((Control)lblAdd3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd3).ForeColor = Color.Black;
		lblAdd3.ImeMode = (ImeMode)0;
		((Control)lblAdd3).Location = new Point(24, 139);
		((Control)lblAdd3).Name = "lblAdd3";
		((Control)lblAdd3).Size = new Size(95, 19);
		((Control)lblAdd3).TabIndex = 123;
		lblAdd3.Text = "Address3";
		lblAdd3.TextAlign = (ContentAlignment)16;
		((Control)lblAdd2).BackColor = Color.Transparent;
		((Control)lblAdd2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd2).ForeColor = Color.Black;
		lblAdd2.ImeMode = (ImeMode)0;
		((Control)lblAdd2).Location = new Point(24, 109);
		((Control)lblAdd2).Name = "lblAdd2";
		((Control)lblAdd2).Size = new Size(95, 19);
		((Control)lblAdd2).TabIndex = 122;
		lblAdd2.Text = "Address2";
		lblAdd2.TextAlign = (ContentAlignment)16;
		((Control)lblAdd1).BackColor = Color.Transparent;
		((Control)lblAdd1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.Black;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(24, 79);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).Size = new Size(95, 19);
		((Control)lblAdd1).TabIndex = 121;
		lblAdd1.Text = "Address1";
		lblAdd1.TextAlign = (ContentAlignment)16;
		((Control)lblBookCo).BackColor = Color.Transparent;
		((Control)lblBookCo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblBookCo).ForeColor = Color.Black;
		lblBookCo.ImeMode = (ImeMode)0;
		((Control)lblBookCo).Location = new Point(333, 229);
		((Control)lblBookCo).Name = "lblBookCo";
		((Control)lblBookCo).Size = new Size(81, 19);
		((Control)lblBookCo).TabIndex = 120;
		lblBookCo.Text = "Pin Code";
		lblBookCo.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tCoName).BackColor = SystemColors.Window;
		((Control)tCoName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCoName).Location = new Point(127, 47);
		((TextBoxBase)tCoName).MaxLength = 50;
		((Control)tCoName).Name = "tCoName";
		((Control)tCoName).Size = new Size(391, 23);
		((Control)tCoName).TabIndex = 1;
		((TextBoxBase)tCoCode).BackColor = SystemColors.Window;
		((Control)tCoCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCoCode).Location = new Point(127, 17);
		((TextBoxBase)tCoCode).MaxLength = 2;
		((Control)tCoCode).Name = "tCoCode";
		((Control)tCoCode).Size = new Size(65, 23);
		((Control)tCoCode).TabIndex = 0;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(24, 17);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(95, 20);
		((Control)Label2).TabIndex = 110;
		Label2.Text = "Co Code";
		Label2.TextAlign = (ContentAlignment)16;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(24, 48);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(95, 20);
		((Control)Label1).TabIndex = 111;
		Label1.Text = "Co Name";
		Label1.TextAlign = (ContentAlignment)16;
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		Tab1.Text = "Company Detail";
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		TabPanel2.Dock = (DockStyle)5;
		((Control)TabPanel2).Location = new Point(0, 0);
		((Control)TabPanel2).Name = "TabPanel2";
		((Control)TabPanel2).Size = new Size(547, 436);
		((Control)TabPanel2).TabIndex = 0;
		TabPanel2.TabItem = Tab2;
		((Control)TabPanel2).Visible = false;
		((Control)Pnl2).Controls.Add((Control)(object)PanelAbc);
		((Control)Pnl2).Controls.Add((Control)(object)tJudrection);
		((Control)Pnl2).Controls.Add((Control)(object)Label7);
		((Control)Pnl2).Controls.Add((Control)(object)tPanNo);
		((Control)Pnl2).Controls.Add((Control)(object)tDhiranNo);
		((Control)Pnl2).Controls.Add((Control)(object)tCstNo);
		((Control)Pnl2).Controls.Add((Control)(object)tGstNo);
		((Control)Pnl2).Controls.Add((Control)(object)Label8);
		((Control)Pnl2).Controls.Add((Control)(object)lblMoNo2);
		((Control)Pnl2).Controls.Add((Control)(object)Label9);
		((Control)Pnl2).Controls.Add((Control)(object)Label10);
		((Control)Pnl2).Location = new Point(-13, -5);
		((Control)Pnl2).Name = "Pnl2";
		((Control)Pnl2).Size = new Size(578, 441);
		((Control)Pnl2).TabIndex = 0;
		((Control)PanelAbc).BackColor = Color.FromArgb(255, 224, 192);
		PanelAbc.BorderStyle = (BorderStyle)2;
		((Control)PanelAbc).Controls.Add((Control)(object)btnSet);
		((Control)PanelAbc).Controls.Add((Control)(object)Label22);
		((Control)PanelAbc).Controls.Add((Control)(object)Label23);
		((Control)PanelAbc).Controls.Add((Control)(object)tC);
		((Control)PanelAbc).Controls.Add((Control)(object)tB);
		((Control)PanelAbc).Controls.Add((Control)(object)tA);
		((Control)PanelAbc).Controls.Add((Control)(object)Label24);
		((Control)PanelAbc).Location = new Point(160, 205);
		((Control)PanelAbc).Name = "PanelAbc";
		((Control)PanelAbc).Size = new Size(321, 119);
		((Control)PanelAbc).TabIndex = 140;
		((Control)PanelAbc).Visible = false;
		((BaseStyleControl)btnSet).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnSet).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnSet).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnSet).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnSet).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnSet).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnSet).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnSet).Appearance.Options.UseForeColor = true;
		((BaseButton)btnSet).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnSet).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnSet).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnSet).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnSet).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnSet).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnSet).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnSet).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnSet).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnSet).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnSet).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnSet).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnSet).AppearancePressed.Options.UseFont = true;
		((Control)btnSet).Location = new Point(179, 40);
		((BaseControl)btnSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnSet).Name = "btnSet";
		((Control)btnSet).Size = new Size(78, 32);
		((Control)btnSet).TabIndex = 1166;
		btnSet.Text = "Se&t";
		((BaseControl)btnSet).ToolTip = "Party Help";
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Maroon;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(41, 74);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(59, 20);
		((Control)Label22).TabIndex = 1163;
		Label22.Text = "C  :";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Maroon;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(41, 46);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(59, 20);
		((Control)Label23).TabIndex = 1162;
		Label23.Text = "B  :";
		Label23.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tC).BackColor = Color.White;
		((Control)tC).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tC).ForeColor = Color.Maroon;
		((Control)tC).Location = new Point(106, 74);
		((TextBoxBase)tC).MaxLength = 50;
		((Control)tC).Name = "tC";
		((Control)tC).Size = new Size(33, 23);
		((Control)tC).TabIndex = 2;
		tC.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tB).BackColor = Color.White;
		((Control)tB).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tB).ForeColor = Color.Maroon;
		((Control)tB).Location = new Point(106, 46);
		((TextBoxBase)tB).MaxLength = 50;
		((Control)tB).Name = "tB";
		((Control)tB).Size = new Size(33, 23);
		((Control)tB).TabIndex = 1;
		tB.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tA).BackColor = Color.White;
		((Control)tA).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tA).ForeColor = Color.Maroon;
		((Control)tA).Location = new Point(106, 18);
		((TextBoxBase)tA).MaxLength = 50;
		((Control)tA).Name = "tA";
		((Control)tA).Size = new Size(33, 23);
		((Control)tA).TabIndex = 0;
		tA.TextAlign = (HorizontalAlignment)2;
		((Control)Label24).BackColor = Color.Transparent;
		((Control)Label24).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label24).ForeColor = Color.Maroon;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(41, 18);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(59, 20);
		((Control)Label24).TabIndex = 1158;
		Label24.Text = "A  :";
		Label24.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tJudrection).BackColor = SystemColors.Window;
		((Control)tJudrection).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tJudrection).Location = new Point(127, 142);
		((Control)tJudrection).Margin = new Padding(2);
		((TextBoxBase)tJudrection).MaxLength = 30;
		((Control)tJudrection).Name = "tJudrection";
		((Control)tJudrection).Size = new Size(391, 23);
		((Control)tJudrection).TabIndex = 21;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(24, 146);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(119, 19);
		((Control)Label7).TabIndex = 139;
		Label7.Text = "Jurisdiction";
		Label7.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tPanNo).BackColor = SystemColors.Window;
		((Control)tPanNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPanNo).Location = new Point(127, 86);
		((Control)tPanNo).Margin = new Padding(2);
		((TextBoxBase)tPanNo).MaxLength = 30;
		((Control)tPanNo).Name = "tPanNo";
		((Control)tPanNo).Size = new Size(391, 23);
		((Control)tPanNo).TabIndex = 19;
		((TextBoxBase)tDhiranNo).BackColor = SystemColors.Window;
		((Control)tDhiranNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tDhiranNo).Location = new Point(127, 114);
		((Control)tDhiranNo).Margin = new Padding(2);
		((TextBoxBase)tDhiranNo).MaxLength = 30;
		((Control)tDhiranNo).Name = "tDhiranNo";
		((Control)tDhiranNo).Size = new Size(391, 23);
		((Control)tDhiranNo).TabIndex = 20;
		((TextBoxBase)tCstNo).BackColor = SystemColors.Window;
		((Control)tCstNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCstNo).Location = new Point(127, 57);
		((Control)tCstNo).Margin = new Padding(2);
		((TextBoxBase)tCstNo).MaxLength = 30;
		((Control)tCstNo).Name = "tCstNo";
		((Control)tCstNo).Size = new Size(391, 23);
		((Control)tCstNo).TabIndex = 18;
		((TextBoxBase)tGstNo).BackColor = SystemColors.Window;
		((Control)tGstNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGstNo).Location = new Point(127, 29);
		((Control)tGstNo).Margin = new Padding(2);
		((TextBoxBase)tGstNo).MaxLength = 30;
		((Control)tGstNo).Name = "tGstNo";
		((Control)tGstNo).Size = new Size(391, 23);
		((Control)tGstNo).TabIndex = 17;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(24, 58);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(85, 19);
		((Control)Label8).TabIndex = 87;
		Label8.Text = "Cst No";
		Label8.TextAlign = (ContentAlignment)16;
		((Control)lblMoNo2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMoNo2).ForeColor = Color.Black;
		lblMoNo2.ImeMode = (ImeMode)0;
		((Control)lblMoNo2).Location = new Point(24, 30);
		((Control)lblMoNo2).Name = "lblMoNo2";
		((Control)lblMoNo2).Size = new Size(90, 19);
		((Control)lblMoNo2).TabIndex = 88;
		lblMoNo2.Text = "Gst No";
		lblMoNo2.TextAlign = (ContentAlignment)16;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(24, 86);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(82, 19);
		((Control)Label9).TabIndex = 86;
		Label9.Text = "Pan No";
		Label9.TextAlign = (ContentAlignment)16;
		((Control)Label10).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(24, 115);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(79, 19);
		((Control)Label10).TabIndex = 85;
		Label10.Text = "Dhiran No";
		Label10.TextAlign = (ContentAlignment)16;
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		Tab2.Text = "Tax Detail";
		Tab2.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		TabPanel3.Dock = (DockStyle)5;
		((Control)TabPanel3).Location = new Point(0, 0);
		((Control)TabPanel3).Name = "TabPanel3";
		((Control)TabPanel3).Size = new Size(547, 436);
		((Control)TabPanel3).TabIndex = 0;
		TabPanel3.TabItem = Tab3;
		((Control)TabPanel3).Visible = false;
		((Control)Pnl3).Controls.Add((Control)(object)Panel1);
		((Control)Pnl3).Controls.Add((Control)(object)tRtgsNo);
		((Control)Pnl3).Controls.Add((Control)(object)tBankAcNo);
		((Control)Pnl3).Controls.Add((Control)(object)tBankArea);
		((Control)Pnl3).Controls.Add((Control)(object)tBankName);
		((Control)Pnl3).Controls.Add((Control)(object)Label11);
		((Control)Pnl3).Controls.Add((Control)(object)Label12);
		((Control)Pnl3).Controls.Add((Control)(object)Label13);
		((Control)Pnl3).Controls.Add((Control)(object)Label14);
		((Control)Pnl3).Location = new Point(-12, -4);
		((Control)Pnl3).Name = "Pnl3";
		((Control)Pnl3).Size = new Size(578, 440);
		((Control)Pnl3).TabIndex = 1;
		((Control)Panel1).BackColor = Color.FromArgb(255, 224, 192);
		Panel1.BorderStyle = (BorderStyle)2;
		((Control)Panel1).Controls.Add((Control)(object)tHttpPath);
		((Control)Panel1).Controls.Add((Control)(object)Label31);
		((Control)Panel1).Controls.Add((Control)(object)btnUrlSet);
		((Control)Panel1).Controls.Add((Control)(object)Label28);
		((Control)Panel1).Controls.Add((Control)(object)Label29);
		((Control)Panel1).Controls.Add((Control)(object)tUrlPwd);
		((Control)Panel1).Controls.Add((Control)(object)tUrlId);
		((Control)Panel1).Controls.Add((Control)(object)tUrlPath);
		((Control)Panel1).Controls.Add((Control)(object)Label30);
		((Control)Panel1).Location = new Point(127, 160);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(391, 150);
		((Control)Panel1).TabIndex = 141;
		((TextBoxBase)tHttpPath).BackColor = Color.White;
		((Control)tHttpPath).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tHttpPath).ForeColor = Color.Maroon;
		((Control)tHttpPath).Location = new Point(106, 20);
		((TextBoxBase)tHttpPath).MaxLength = 150;
		((Control)tHttpPath).Name = "tHttpPath";
		((Control)tHttpPath).Size = new Size(256, 23);
		((Control)tHttpPath).TabIndex = 1167;
		((Control)Label31).BackColor = Color.Transparent;
		((Control)Label31).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label31).ForeColor = Color.Maroon;
		Label31.ImeMode = (ImeMode)0;
		((Control)Label31).Location = new Point(21, 20);
		((Control)Label31).Name = "Label31";
		((Control)Label31).Size = new Size(79, 20);
		((Control)Label31).TabIndex = 1168;
		Label31.Text = "Http Path  :";
		Label31.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)btnUrlSet).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnUrlSet).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnUrlSet).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnUrlSet).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnUrlSet).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnUrlSet).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnUrlSet).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnUrlSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnUrlSet).Appearance.Options.UseForeColor = true;
		((BaseButton)btnUrlSet).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnUrlSet).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnUrlSet).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnUrlSet).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnUrlSet).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnUrlSet).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnUrlSet).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnUrlSet).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnUrlSet).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnUrlSet).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnUrlSet).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnUrlSet).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnUrlSet).AppearancePressed.Options.UseFont = true;
		((Control)btnUrlSet).Location = new Point(284, 99);
		((BaseControl)btnUrlSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnUrlSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnUrlSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnUrlSet).Name = "btnUrlSet";
		((Control)btnUrlSet).Size = new Size(78, 32);
		((Control)btnUrlSet).TabIndex = 1166;
		btnUrlSet.Text = "Se&t";
		((BaseControl)btnUrlSet).ToolTip = "Party Help";
		((Control)Label28).BackColor = Color.Transparent;
		((Control)Label28).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label28).ForeColor = Color.Maroon;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(24, 105);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(76, 20);
		((Control)Label28).TabIndex = 1163;
		Label28.Text = "Url Pwd  :";
		Label28.TextAlign = (ContentAlignment)64;
		((Control)Label28).Visible = false;
		((Control)Label29).BackColor = Color.Transparent;
		((Control)Label29).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label29).ForeColor = Color.Maroon;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(24, 77);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(76, 20);
		((Control)Label29).TabIndex = 1162;
		Label29.Text = "Url Id  :";
		Label29.TextAlign = (ContentAlignment)64;
		((Control)Label29).Visible = false;
		((TextBoxBase)tUrlPwd).BackColor = Color.White;
		((Control)tUrlPwd).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tUrlPwd).ForeColor = Color.Maroon;
		((Control)tUrlPwd).Location = new Point(106, 105);
		((TextBoxBase)tUrlPwd).MaxLength = 25;
		((Control)tUrlPwd).Name = "tUrlPwd";
		((Control)tUrlPwd).Size = new Size(132, 23);
		((Control)tUrlPwd).TabIndex = 2;
		tUrlPwd.UseSystemPasswordChar = true;
		((Control)tUrlPwd).Visible = false;
		((TextBoxBase)tUrlId).BackColor = Color.White;
		((Control)tUrlId).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tUrlId).ForeColor = Color.Maroon;
		((Control)tUrlId).Location = new Point(106, 77);
		((TextBoxBase)tUrlId).MaxLength = 50;
		((Control)tUrlId).Name = "tUrlId";
		((Control)tUrlId).Size = new Size(132, 23);
		((Control)tUrlId).TabIndex = 1;
		((Control)tUrlId).Visible = false;
		((TextBoxBase)tUrlPath).BackColor = Color.White;
		((Control)tUrlPath).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tUrlPath).ForeColor = Color.Maroon;
		((Control)tUrlPath).Location = new Point(106, 49);
		((TextBoxBase)tUrlPath).MaxLength = 150;
		((Control)tUrlPath).Name = "tUrlPath";
		((Control)tUrlPath).Size = new Size(256, 23);
		((Control)tUrlPath).TabIndex = 0;
		((Control)Label30).BackColor = Color.Transparent;
		((Control)Label30).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label30).ForeColor = Color.Maroon;
		Label30.ImeMode = (ImeMode)0;
		((Control)Label30).Location = new Point(21, 49);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(79, 20);
		((Control)Label30).TabIndex = 1158;
		Label30.Text = "Ftp Path  :";
		Label30.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tRtgsNo).BackColor = SystemColors.Window;
		((Control)tRtgsNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRtgsNo).Location = new Point(127, 112);
		((Control)tRtgsNo).Margin = new Padding(2);
		((TextBoxBase)tRtgsNo).MaxLength = 30;
		((Control)tRtgsNo).Name = "tRtgsNo";
		((Control)tRtgsNo).Size = new Size(391, 23);
		((Control)tRtgsNo).TabIndex = 25;
		((TextBoxBase)tBankAcNo).BackColor = SystemColors.Window;
		((Control)tBankAcNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankAcNo).Location = new Point(127, 84);
		((Control)tBankAcNo).Margin = new Padding(2);
		((TextBoxBase)tBankAcNo).MaxLength = 30;
		((Control)tBankAcNo).Name = "tBankAcNo";
		((Control)tBankAcNo).Size = new Size(391, 23);
		((Control)tBankAcNo).TabIndex = 24;
		((TextBoxBase)tBankArea).BackColor = SystemColors.Window;
		((Control)tBankArea).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankArea).Location = new Point(127, 56);
		((Control)tBankArea).Margin = new Padding(2);
		((TextBoxBase)tBankArea).MaxLength = 40;
		((Control)tBankArea).Name = "tBankArea";
		((Control)tBankArea).Size = new Size(391, 23);
		((Control)tBankArea).TabIndex = 23;
		((TextBoxBase)tBankName).BackColor = SystemColors.Window;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(127, 28);
		((Control)tBankName).Margin = new Padding(2);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(391, 23);
		((Control)tBankName).TabIndex = 22;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(17, 112);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(108, 19);
		((Control)Label11).TabIndex = 85;
		Label11.Text = "IFSC CODE";
		Label11.TextAlign = (ContentAlignment)16;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(17, 84);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(105, 19);
		((Control)Label12).TabIndex = 86;
		Label12.Text = "Bank AcNo";
		Label12.TextAlign = (ContentAlignment)16;
		((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(17, 56);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(105, 19);
		((Control)Label13).TabIndex = 87;
		Label13.Text = "Branch Name";
		Label13.TextAlign = (ContentAlignment)16;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(17, 28);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(102, 19);
		((Control)Label14).TabIndex = 88;
		Label14.Text = "Bank Name";
		Label14.TextAlign = (ContentAlignment)16;
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		Tab3.Text = "Bank Detail";
		Tab3.TextAlignment = (eItemAlignment)2;
		((Control)GroupBox1).BackColor = Color.Transparent;
		((Control)GroupBox1).Controls.Add((Control)(object)tLigalName);
		((Control)GroupBox1).Controls.Add((Control)(object)lblLigalName);
		((Control)GroupBox1).Controls.Add((Control)(object)btneExit);
		((Control)GroupBox1).Controls.Add((Control)(object)btneSave);
		((Control)GroupBox1).Controls.Add((Control)(object)tAspPwd);
		((Control)GroupBox1).Controls.Add((Control)(object)Label27);
		((Control)GroupBox1).Controls.Add((Control)(object)tAspId);
		((Control)GroupBox1).Controls.Add((Control)(object)Label25);
		((Control)GroupBox1).Controls.Add((Control)(object)tePortalPwd);
		((Control)GroupBox1).Controls.Add((Control)(object)Label21);
		((Control)GroupBox1).Controls.Add((Control)(object)tePortalId);
		((Control)GroupBox1).Controls.Add((Control)(object)Label20);
		((Control)GroupBox1).Controls.Add((Control)(object)teGstNo);
		((Control)GroupBox1).Controls.Add((Control)(object)Label26);
		((Control)GroupBox1).Font = new Font("Arial", 9f);
		((Control)GroupBox1).ForeColor = Color.Maroon;
		((Control)GroupBox1).Location = new Point(532, 124);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(594, 358);
		((Control)GroupBox1).TabIndex = 1160;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "E Invoice Setting";
		((Control)GroupBox1).Visible = false;
		((Control)tLigalName).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLigalName).Location = new Point(143, 218);
		((Control)tLigalName).Margin = new Padding(2);
		((TextBoxBase)tLigalName).MaxLength = 50;
		((Control)tLigalName).Name = "tLigalName";
		((Control)tLigalName).Size = new Size(391, 22);
		((Control)tLigalName).TabIndex = 1172;
		((Control)tLigalName).Visible = false;
		lblLigalName.AutoSize = true;
		((Control)lblLigalName).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLigalName).Location = new Point(40, 219);
		((Control)lblLigalName).Margin = new Padding(2, 0, 2, 0);
		((Control)lblLigalName).Name = "lblLigalName";
		((Control)lblLigalName).Size = new Size(73, 16);
		((Control)lblLigalName).TabIndex = 1171;
		lblLigalName.Text = "Ligal Name";
		((Control)lblLigalName).Visible = false;
		((BaseStyleControl)btneExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btneExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btneExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)btneExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btneExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btneExit.ImageOptions.SvgImage");
		((Control)btneExit).Location = new Point(318, 257);
		((BaseControl)btneExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btneExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btneExit).Name = "btneExit";
		((Control)btneExit).Size = new Size(91, 37);
		((Control)btneExit).TabIndex = 1170;
		btneExit.Text = "E&xit";
		((BaseButton)btneExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btneSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btneSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btneSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)btneSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btneSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btneSave.ImageOptions.SvgImage");
		((Control)btneSave).Location = new Point(200, 258);
		((BaseControl)btneSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btneSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btneSave).Name = "btneSave";
		((Control)btneSave).Size = new Size(91, 37);
		((Control)btneSave).TabIndex = 1169;
		btneSave.Text = "&Save";
		((BaseButton)btneSave).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)tAspPwd).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAspPwd).Location = new Point(143, 182);
		((Control)tAspPwd).Margin = new Padding(2);
		((TextBoxBase)tAspPwd).MaxLength = 50;
		((Control)tAspPwd).Name = "tAspPwd";
		tAspPwd.PasswordChar = '*';
		((Control)tAspPwd).Size = new Size(391, 22);
		((Control)tAspPwd).TabIndex = 1168;
		Label27.AutoSize = true;
		((Control)Label27).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label27).Location = new Point(40, 183);
		((Control)Label27).Margin = new Padding(2, 0, 2, 0);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(82, 16);
		((Control)Label27).TabIndex = 1167;
		Label27.Text = "Asp Api Pwd";
		((Control)tAspId).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAspId).Location = new Point(143, 146);
		((Control)tAspId).Margin = new Padding(2);
		((TextBoxBase)tAspId).MaxLength = 50;
		((Control)tAspId).Name = "tAspId";
		((Control)tAspId).Size = new Size(391, 22);
		((Control)tAspId).TabIndex = 1166;
		Label25.AutoSize = true;
		((Control)Label25).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label25).Location = new Point(40, 149);
		((Control)Label25).Margin = new Padding(2, 0, 2, 0);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(67, 16);
		((Control)Label25).TabIndex = 1165;
		Label25.Text = "Asp Api Id";
		((Control)tePortalPwd).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tePortalPwd).Location = new Point(143, 110);
		((Control)tePortalPwd).Margin = new Padding(2);
		((TextBoxBase)tePortalPwd).MaxLength = 50;
		((Control)tePortalPwd).Name = "tePortalPwd";
		tePortalPwd.PasswordChar = '*';
		((Control)tePortalPwd).Size = new Size(391, 22);
		((Control)tePortalPwd).TabIndex = 1164;
		Label21.AutoSize = true;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).Location = new Point(40, 113);
		((Control)Label21).Margin = new Padding(2, 0, 2, 0);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(71, 16);
		((Control)Label21).TabIndex = 1163;
		Label21.Text = "Portal Pwd";
		((Control)tePortalId).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tePortalId).Location = new Point(143, 74);
		((Control)tePortalId).Margin = new Padding(2);
		((TextBoxBase)tePortalId).MaxLength = 50;
		((Control)tePortalId).Name = "tePortalId";
		((Control)tePortalId).Size = new Size(391, 22);
		((Control)tePortalId).TabIndex = 1162;
		Label20.AutoSize = true;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).Location = new Point(40, 77);
		((Control)Label20).Margin = new Padding(2, 0, 2, 0);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(56, 16);
		((Control)Label20).TabIndex = 1161;
		Label20.Text = "Portal Id";
		((Control)teGstNo).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)teGstNo).Location = new Point(143, 38);
		((Control)teGstNo).Margin = new Padding(2);
		((TextBoxBase)teGstNo).MaxLength = 15;
		((Control)teGstNo).Name = "teGstNo";
		((Control)teGstNo).Size = new Size(391, 22);
		((Control)teGstNo).TabIndex = 1160;
		Label26.AutoSize = true;
		((Control)Label26).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label26).Location = new Point(40, 41);
		((Control)Label26).Margin = new Padding(2, 0, 2, 0);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(54, 16);
		((Control)Label26).TabIndex = 1159;
		Label26.Text = "GST No";
		pnlUae.BorderStyle = (BorderStyle)2;
		((Control)pnlUae).Controls.Add((Control)(object)BtnExitUae);
		((Control)pnlUae).Controls.Add((Control)(object)btnSaveUae);
		((Control)pnlUae).Controls.Add((Control)(object)Label35);
		((Control)pnlUae).Controls.Add((Control)(object)tTerminalCode);
		((Control)pnlUae).Controls.Add((Control)(object)Label32);
		((Control)pnlUae).Controls.Add((Control)(object)tClientSecret);
		((Control)pnlUae).Controls.Add((Control)(object)Label33);
		((Control)pnlUae).Controls.Add((Control)(object)tUaeClientId);
		((Control)pnlUae).Controls.Add((Control)(object)Label34);
		((Control)pnlUae).Location = new Point(504, 189);
		((Control)pnlUae).Name = "pnlUae";
		((Control)pnlUae).Size = new Size(654, 243);
		((Control)pnlUae).TabIndex = 1161;
		((Control)pnlUae).Visible = false;
		((BaseStyleControl)BtnExitUae).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExitUae).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExitUae).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExitUae).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExitUae.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExitUae.ImageOptions.SvgImage");
		((Control)BtnExitUae).Location = new Point(344, 165);
		((BaseControl)BtnExitUae).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExitUae).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExitUae).Name = "BtnExitUae";
		((Control)BtnExitUae).Size = new Size(91, 37);
		((Control)BtnExitUae).TabIndex = 1173;
		BtnExitUae.Text = "E&xit";
		((BaseButton)BtnExitUae).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnSaveUae).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnSaveUae).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnSaveUae).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnSaveUae).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnSaveUae.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnSaveUae.ImageOptions.SvgImage");
		((Control)btnSaveUae).Location = new Point(226, 165);
		((BaseControl)btnSaveUae).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnSaveUae).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnSaveUae).Name = "btnSaveUae";
		((Control)btnSaveUae).Size = new Size(91, 37);
		((Control)btnSaveUae).TabIndex = 1172;
		btnSaveUae.Text = "&Save";
		((BaseButton)btnSaveUae).ToolTipAnchor = (ToolTipAnchor)1;
		Label35.AutoSize = true;
		((Control)Label35).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label35).Location = new Point(286, 9);
		((Control)Label35).Margin = new Padding(2, 0, 2, 0);
		((Control)Label35).Name = "Label35";
		((Control)Label35).Size = new Size(116, 18);
		((Control)Label35).TabIndex = 1171;
		Label35.Text = "Planet Tax Free";
		((Control)tTerminalCode).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tTerminalCode).Location = new Point(140, 117);
		((Control)tTerminalCode).Margin = new Padding(2);
		((TextBoxBase)tTerminalCode).MaxLength = 50;
		((Control)tTerminalCode).Name = "tTerminalCode";
		((Control)tTerminalCode).Size = new Size(456, 22);
		((Control)tTerminalCode).TabIndex = 1170;
		Label32.AutoSize = true;
		((Control)Label32).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label32).Location = new Point(41, 120);
		((Control)Label32).Margin = new Padding(2, 0, 2, 0);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(90, 16);
		((Control)Label32).TabIndex = 1169;
		Label32.Text = "Terminal Code";
		((Control)tClientSecret).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tClientSecret).Location = new Point(140, 80);
		((Control)tClientSecret).Margin = new Padding(2);
		((TextBoxBase)tClientSecret).MaxLength = 100;
		((Control)tClientSecret).Name = "tClientSecret";
		((Control)tClientSecret).Size = new Size(456, 22);
		((Control)tClientSecret).TabIndex = 1168;
		Label33.AutoSize = true;
		((Control)Label33).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label33).Location = new Point(41, 83);
		((Control)Label33).Margin = new Padding(2, 0, 2, 0);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(83, 16);
		((Control)Label33).TabIndex = 1167;
		Label33.Text = "Client Secret";
		((Control)tUaeClientId).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tUaeClientId).Location = new Point(140, 44);
		((Control)tUaeClientId).Margin = new Padding(2);
		((TextBoxBase)tUaeClientId).MaxLength = 100;
		((Control)tUaeClientId).Name = "tUaeClientId";
		((Control)tUaeClientId).Size = new Size(456, 22);
		((Control)tUaeClientId).TabIndex = 1166;
		Label34.AutoSize = true;
		((Control)Label34).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label34).Location = new Point(41, 47);
		((Control)Label34).Margin = new Padding(2, 0, 2, 0);
		((Control)Label34).Name = "Label34";
		((Control)Label34).Size = new Size(55, 16);
		((Control)Label34).TabIndex = 1165;
		Label34.Text = "Client Id";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		((Control)Text1).Font = new Font("Franklin Gothic Book", 11.25f);
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Location = new Point(69, 64);
		((Control)Text1).Margin = new Padding(2);
		((TextBoxBase)Text1).MaxLength = 50;
		((Control)Text1).Name = "Text1";
		((Control)Text1).RightToLeft = (RightToLeft)0;
		((Control)Text1).Size = new Size(395, 18);
		((Control)Text1).TabIndex = 9;
		Text1.Text = "SEARCH RECORD";
		Text1.TextAlign = (HorizontalAlignment)2;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(30, 516);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
		((Control)lblCoReset).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblCoReset).Location = new Point(8, 4);
		((Control)lblCoReset).Name = "lblCoReset";
		((Control)lblCoReset).Size = new Size(25, 23);
		((Control)lblCoReset).TabIndex = 11;
		lblCoReset.Text = ".";
		((Control)lblCoReset).Visible = false;
		((Control)mLockDate).Font = new Font("Tahoma", 9f);
		((Control)mLockDate).Location = new Point(394, 522);
		((Control)mLockDate).Margin = new Padding(2);
		mLockDate.Mask = "00/00/0000";
		((Control)mLockDate).Name = "mLockDate";
		((Control)mLockDate).Size = new Size(79, 22);
		((Control)mLockDate).TabIndex = 1158;
		mLockDate.ValidatingType = typeof(DateTime);
		((Control)mLockDate).Visible = false;
		((Control)lblLockDt).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblLockDt).ForeColor = Color.Black;
		lblLockDt.ImeMode = (ImeMode)0;
		((Control)lblLockDt).Location = new Point(298, 522);
		((Control)lblLockDt).Name = "lblLockDt";
		((Control)lblLockDt).Size = new Size(88, 20);
		((Control)lblLockDt).TabIndex = 1159;
		lblLockDt.Text = "Lock Date";
		lblLockDt.TextAlign = (ContentAlignment)64;
		((Control)lblLockDt).Visible = false;
		((ButtonBase)chkResetData).BackColor = Color.Transparent;
		((Control)chkResetData).Font = new Font("Arial", 9.75f);
		((Control)chkResetData).ForeColor = Color.Black;
		((ButtonBase)chkResetData).ImeMode = (ImeMode)0;
		((Control)chkResetData).Location = new Point(547, 523);
		((Control)chkResetData).Name = "chkResetData";
		((Control)chkResetData).RightToLeft = (RightToLeft)0;
		((Control)chkResetData).Size = new Size(173, 27);
		((Control)chkResetData).TabIndex = 1162;
		((ButtonBase)chkResetData).Text = "Reset Compnay";
		((ButtonBase)chkResetData).UseVisualStyleBackColor = false;
		((Control)chkResetData).Visible = false;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(816, 526);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(71, 23);
		((Control)tAcCode).TabIndex = 1169;
		((Control)tAcCode).Visible = false;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(891, 525);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(270, 23);
		((Control)tAcName).TabIndex = 1170;
		((Control)tAcName).Visible = false;
		((Control)Lblfanac).BackColor = Color.Transparent;
		((Control)Lblfanac).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Lblfanac).ForeColor = Color.Black;
		Lblfanac.ImeMode = (ImeMode)0;
		((Control)Lblfanac).Location = new Point(711, 526);
		((Control)Lblfanac).Name = "Lblfanac";
		((Control)Lblfanac).Size = new Size(99, 20);
		((Control)Lblfanac).TabIndex = 1171;
		Lblfanac.Text = "Franchise Ac";
		Lblfanac.TextAlign = (ContentAlignment)64;
		((Control)Lblfanac).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Lblfanac);
		((Control)this).Controls.Add((Control)(object)chkResetData);
		((Control)this).Controls.Add((Control)(object)pnlUae);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)mLockDate);
		((Control)this).Controls.Add((Control)(object)lblLockDt);
		((Control)this).Controls.Add((Control)(object)lblCoReset);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_COMPANY";
		((Form)this).Text = "Company";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)Pnl1).PerformLayout();
		((Control)TabPanel2).ResumeLayout(false);
		((Control)Pnl2).ResumeLayout(false);
		((Control)Pnl2).PerformLayout();
		((Control)PanelAbc).ResumeLayout(false);
		((Control)PanelAbc).PerformLayout();
		((Control)TabPanel3).ResumeLayout(false);
		((Control)Pnl3).ResumeLayout(false);
		((Control)Pnl3).PerformLayout();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)pnlUae).ResumeLayout(false);
		((Control)pnlUae).PerformLayout();
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_COMPANY_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_1684: Unknown result type (might be due to invalid IL or missing references)
		//IL_168b: Expected O, but got Unknown
		//IL_16e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f4: Expected O, but got Unknown
		//IL_1762: Unknown result type (might be due to invalid IL or missing references)
		//IL_1767: Unknown result type (might be due to invalid IL or missing references)
		//IL_176d: Expected O, but got Unknown
		//IL_17db: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e6: Expected O, but got Unknown
		//IL_1854: Unknown result type (might be due to invalid IL or missing references)
		//IL_1859: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Expected O, but got Unknown
		//IL_18cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d8: Expected O, but got Unknown
		//IL_1946: Unknown result type (might be due to invalid IL or missing references)
		//IL_194b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1951: Expected O, but got Unknown
		//IL_1b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b61: Expected O, but got Unknown
		//IL_1a03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a12: Expected O, but got Unknown
		//IL_1a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a40: Expected O, but got Unknown
		//IL_1a5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6e: Expected O, but got Unknown
		//IL_1adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae9: Expected O, but got Unknown
		//IL_1afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b06: Expected O, but got Unknown
		//IL_1bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bde: Expected O, but got Unknown
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
			Panel pnl;
			((Control)(pnl = Pnl1)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl1).Width * num);
			((Control)(pnl = Pnl1)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl1).Height * num2);
			((Control)(pnl = Pnl1)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl1).Left * num);
			((Control)(pnl = Pnl1)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl1).Top * num2);
			((Control)(pnl = Pnl2)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl2).Width * num);
			((Control)(pnl = Pnl2)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl2).Height * num2);
			((Control)(pnl = Pnl2)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl2).Left * num);
			((Control)(pnl = Pnl2)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl2).Top * num2);
			((Control)(pnl = Pnl3)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl3).Width * num);
			((Control)(pnl = Pnl3)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl3).Height * num2);
			((Control)(pnl = Pnl3)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl3).Left * num);
			((Control)(pnl = Pnl3)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl3).Top * num2);
			((Control)(pnl = Panel1)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Panel1).Width * num);
			((Control)(pnl = Panel1)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Panel1).Height * num2);
			((Control)(pnl = Panel1)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Panel1).Left * num);
			((Control)(pnl = Panel1)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Panel1).Top * num2);
			((Control)(pnl = PanelAbc)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)PanelAbc).Width * num);
			((Control)(pnl = PanelAbc)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)PanelAbc).Height * num2);
			((Control)(pnl = PanelAbc)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)PanelAbc).Left * num);
			((Control)(pnl = PanelAbc)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)PanelAbc).Top * num2);
			foreach (object control3 in ((Control)Pnl1).Controls)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
				object obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control4 in ((Control)Pnl2).Controls)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
				object obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control5 in ((Control)Pnl3).Controls)
			{
				object objectValue4 = RuntimeHelpers.GetObjectValue(control5);
				object obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control6 in ((Control)TabMenu).Controls)
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(control6);
				object obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control7 in ((Control)Panel1).Controls)
			{
				object objectValue6 = RuntimeHelpers.GetObjectValue(control7);
				object obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control8 in ((Control)PanelAbc).Controls)
			{
				object objectValue7 = RuntimeHelpers.GetObjectValue(control8);
				object obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
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
				((Control)lblCoReset).BackColor = ((Control)lblBook).BackColor;
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblCoReset).BackColor = ((Control)lblBook).BackColor;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				ComboBox obj9 = cboRptHader;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				obj9.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj11 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj13 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				((Control)lblCoReset).BackColor = ((Control)lblBook).BackColor;
				Label obj14 = lblBook;
				object? obj15 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj14).ForeColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj16 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				cboRptHader.BackColor = Color.Cornsilk;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj17 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj18 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tCoName).Font.Size * (1.0 + num2));
				Font font = ((Control)tCoName).Font;
				try
				{
					foreach (Control control9 in ((Control)this).Controls)
					{
						Control val3 = control9;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control10 in ((Control)Pnl1).Controls)
					{
						object objectValue8 = RuntimeHelpers.GetObjectValue(control10);
						NewLateBinding.LateSet(objectValue8, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control11 in ((Control)Pnl2).Controls)
					{
						object objectValue9 = RuntimeHelpers.GetObjectValue(control11);
						NewLateBinding.LateSet(objectValue9, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control12 in ((Control)Pnl3).Controls)
					{
						object objectValue10 = RuntimeHelpers.GetObjectValue(control12);
						NewLateBinding.LateSet(objectValue10, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control13 in ((Control)TabMenu).Controls)
					{
						object objectValue11 = RuntimeHelpers.GetObjectValue(control13);
						NewLateBinding.LateSet(objectValue11, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control14 in ((Control)GroupBox1).Controls)
					{
						object objectValue12 = RuntimeHelpers.GetObjectValue(control14);
						NewLateBinding.LateSet(objectValue12, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
					TabMenu.SelectedTabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
					TabMenu.TabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control15 in ((Control)PnlBotam).Controls)
					{
						object objectValue13 = RuntimeHelpers.GetObjectValue(control15);
						NewLateBinding.LateSet(objectValue13, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				Label4.Text = "Emirates";
			}
			if (DC_Main.MsEmailOpen)
			{
				((Control)lblMailApi).Visible = true;
				((Control)tMailApi).Visible = true;
			}
			cboRptHader.Items.Add((object)"Company");
			cboRptHader.Items.Add((object)"Location");
			cboRptHader.Items.Add((object)"Both");
			cboRptHader.SelectedIndex = 0;
			cboWorkType.Items.Add((object)"Retail");
			cboWorkType.Items.Add((object)"WhSales");
			cboWorkType.SelectedIndex = 0;
			cboMetalType.Items.Add((object)"Gold");
			cboMetalType.Items.Add((object)"Silver");
			cboMetalType.Items.Add((object)"Other");
			cboMetalType.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT * FROM CO_MAST ORDER BY CO_CODE ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			cboWithOldCoMast.Items.Clear();
			cboWithOldCoMast.Items.Add((object)"");
			if (RsMast.Rows.Count > 0)
			{
				int num4 = RsMast.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboWithOldCoMast.Items.Add(Operators.ConcatenateObject(RsMast.Rows[DC_Main.X]["CO_CODE"], (object)""));
					DC_Main.X++;
				}
			}
			cboWithOldCoMast.SelectedIndex = 0;
			if (Operators.CompareString(DC_Main.FanMenuOpen, "Y", false) == 0)
			{
				((Control)Lblfanac).Visible = true;
				((Control)tAcCode).Visible = true;
				((Control)tAcName).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				lblBookCo.Text = "P/O - Box";
				lblMoNo2.Text = "TRN No";
				Label11.Text = "I BAN No";
			}
			BtnCancel_Click(BtnCancel, new EventArgs());
			CurActCtrl = (Control)(object)tCoName;
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
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
		foreach (object control2 in ((Control)Pnl1).Controls)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(control2);
			if ((object)objectValue.GetType() == typeof(TextBox))
			{
				TextBox val2 = (TextBox)objectValue;
				val2.Text = "";
			}
		}
		foreach (object control3 in ((Control)Pnl2).Controls)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
			if ((object)objectValue2.GetType() == typeof(TextBox))
			{
				TextBox val3 = (TextBox)objectValue2;
				val3.Text = "";
			}
		}
		foreach (object control4 in ((Control)Pnl3).Controls)
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
			if ((object)objectValue3.GetType() == typeof(TextBox))
			{
				TextBox val4 = (TextBox)objectValue3;
				val4.Text = "";
			}
		}
		chkResetData.Checked = false;
		TabMenu.SelectedTab = Tab1;
		MSG_FILL();
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tCoCode).MaxLength = 2;
		cboRptHader.SelectedIndex = 0;
		cboWorkType.SelectedIndex = 0;
		cboMetalType.SelectedIndex = 0;
		DC_Main.RsQry = "SELECT CO_CODE AS CoCode From CO_MAST ORDER BY CO_CODE DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			tCoCode.Text = "01";
		}
		else if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])))
		{
			tCoCode.Text = Strings.Format(Operators.AddObject(DC_Main.Rshlp.Rows[0]["CoCode"], (object)1), "00");
		}
		cboWithOldCoMast.SelectedIndex = 0;
		mLockDate.Text = Strings.Format((object)DC_Main.MsLockDt, "dd/MM/yyyy");
		EntryMode = "A";
		((Control)tCoName).Focus();
	}

	private void MSG_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void MSG_FILL()
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
		MSG_CLEAR();
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
				((DataGridView)DGV).Columns[0].DataPropertyName = "CO_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "CO_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "select * from CO_MAST where CO_CODE = '" + tCoCode.Text + "' ORDER BY CO_CODE";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			return;
		}
		DataTable rshlp = DC_Main.Rshlp;
		tCoCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_CODE"], (object)""));
		tCoName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_NAME"], (object)""));
		CurLcCode = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_CODE"], (object)""));
		CoSname = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_SNAME"], (object)""));
		tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_ADD1"], (object)""));
		tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_ADD2"], (object)""));
		tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_ADD3"], (object)""));
		tCountry.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_COUNTRY"], (object)""));
		tStateCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_STATE_CODE"], (object)""));
		TState.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_STATE"], (object)""));
		tCity.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_CITY"], (object)""));
		tPinCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_PIN"], (object)""));
		tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_PHONE"], (object)""));
		tPhone2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_PHONE2"], (object)""));
		tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_MOBILE"], (object)""));
		tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_MOBILE2"], (object)""));
		tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_MAIL"], (object)""));
		tMailApi.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIL_API"], (object)""));
		tJudrection.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_JUD"], (object)""));
		if (Operators.ConditionalCompareObjectEqual(rshlp.Rows[0]["REP_ADD_TYPE"], (object)"L", false))
		{
			cboRptHader.SelectedIndex = 1;
		}
		else if (Operators.ConditionalCompareObjectEqual(rshlp.Rows[0]["REP_ADD_TYPE"], (object)"B", false))
		{
			cboRptHader.SelectedIndex = 2;
		}
		else
		{
			cboRptHader.SelectedIndex = 0;
		}
		if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["WORK_TYPE"], (object)""), (object)"W", false))
		{
			cboWorkType.SelectedIndex = 1;
		}
		else
		{
			cboWorkType.SelectedIndex = 0;
		}
		if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["METAL_TYPE"], (object)""), (object)"O", false))
		{
			cboMetalType.SelectedIndex = 2;
		}
		else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["METAL_TYPE"], (object)""), (object)"S", false))
		{
			cboMetalType.SelectedIndex = 1;
		}
		else
		{
			cboMetalType.SelectedIndex = 0;
		}
		tGstNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_GST_NO"], (object)""));
		tCstNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_CSTNO"], (object)""));
		tPanNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_PAN_NO"], (object)""));
		tDhiranNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["DHIRAN_NO"], (object)""));
		tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_NAME"], (object)""));
		tBankArea.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_AREA"], (object)""));
		tBankAcNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_AC_NO"], (object)""));
		tRtgsNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_RTGS_NO"], (object)""));
		tCoType.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CO_TYPE"], (object)""));
		MainUser = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIN_USER"], (object)""));
		tHttpPath.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["HTTP_NAME"], (object)""));
		tUrlPath.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["URL_NAME"], (object)""));
		tUrlId.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["URL_ID"], (object)""));
		tUrlPwd.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["URL_PWD"], (object)""));
		if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["RTGS_TYPE"], (object)""), (object)"Y", false))
		{
			chkResetData.Checked = true;
		}
		else
		{
			chkResetData.Checked = false;
		}
		((Control)Label19).Visible = false;
		((Control)cboWithOldCoMast).Visible = false;
		DC_Main.MsOldCoCode = "";
		EntryMode = "E";
		rshlp = null;
		if (Operators.CompareString(DC_Main.MCo_code, tCoCode.Text, false) == 0)
		{
			((Control)Lblfanac).Visible = false;
			((Control)tAcCode).Visible = false;
			((Control)tAcName).Visible = false;
		}
		else
		{
			((Control)Lblfanac).Visible = true;
			((Control)tAcCode).Visible = true;
			((Control)tAcName).Visible = true;
			DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM FAN_AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.FAN_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.FAN_CO_CODE =  '" + tCoCode.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FAN_AC_CODE"], (object)""));
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			}
		}
		((TextBoxBase)tCoCode).ReadOnly = true;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_COMPANY_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_COMPANY_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_COMPANY_Validated(object sender, EventArgs e)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		bool flag = flag;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " CO_CODE = '" + tCoCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["CO_NAME"], (object)tCoName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Company Code already Exist in  '", dataView[0]["CO_NAME"]), (object)"'  Company Name...Please Change Company Code..."), (MsgBoxStyle)0, (object)null);
				flag = true;
				((TextBoxBase)tCoCode).SelectAll();
			}
		}
		else
		{
			flag = false;
		}
		flag = flag;
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bca: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) & (Operators.CompareString(tCoCode.Text, "01", false) != 0))
		{
			Interaction.MsgBox((object)"You Cant Creat New Company For DataCare Next Lite Version", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			DC_Main.RsQry = "SELECT * from CO_MAST";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count >= 2)
			{
				Interaction.MsgBox((object)"You Cant Creat More Then 2 New Company For DataCare Next Basic Version...", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((Operators.CompareString(tCoCode.Text, "", false) == 0) | (Operators.CompareString(tCoName.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Enter Company Detail", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "DELETE FROM CO_MAST WHERE CO_CODE = '" + tCoCode.Text + "' ";
		DC_Main.ExeQuteMc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM CO_MAST  WHERE CO_CODE  = '" + tCoCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = DC_Main.Rshlp.NewRow();
		dataRow["CO_CODE"] = tCoCode.Text;
		dataRow["CO_NAME"] = tCoName.Text;
		dataRow["LC_CODE"] = CurLcCode;
		dataRow["CO_SNAME"] = CoSname;
		dataRow["CO_ADD1"] = tAddress1.Text;
		dataRow["CO_ADD2"] = tAddress2.Text;
		dataRow["CO_ADD3"] = tAddress3.Text;
		dataRow["CO_COUNTRY"] = tCountry.Text;
		dataRow["CO_STATE"] = Strings.Mid(TState.Text, 1, 25);
		dataRow["CO_STATE_CODE"] = tStateCode.Text;
		dataRow["CO_CITY"] = tCity.Text;
		dataRow["CO_PIN"] = tPinCode.Text;
		dataRow["CO_PHONE"] = tPhone.Text;
		dataRow["CO_PHONE2"] = tPhone2.Text;
		dataRow["CO_MOBILE"] = tMobile.Text;
		dataRow["CO_MOBILE2"] = tMobile2.Text;
		dataRow["CO_MAIL"] = tEmail.Text;
		dataRow["MAIL_API"] = tMailApi.Text;
		dataRow["WORK_TYPE"] = Strings.Mid(cboWorkType.Text, 1, 1);
		dataRow["METAL_TYPE"] = Strings.Mid(cboMetalType.Text, 1, 1);
		dataRow["REP_ADD_TYPE"] = Strings.Mid(cboRptHader.Text, 1, 1);
		dataRow["CO_GST_NO"] = tGstNo.Text;
		dataRow["CO_CSTNO"] = tCstNo.Text;
		dataRow["CO_PAN_NO"] = tPanNo.Text;
		dataRow["DHIRAN_NO"] = tDhiranNo.Text;
		dataRow["CO_JUD"] = tJudrection.Text;
		dataRow["BANK_NAME"] = tBankName.Text;
		dataRow["BANK_AREA"] = tBankArea.Text;
		dataRow["BANK_AC_NO"] = tBankAcNo.Text;
		dataRow["BANK_RTGS_NO"] = tRtgsNo.Text;
		dataRow["MAIN_USER"] = MainUser;
		dataRow["CO_TYPE"] = tCoType.Text;
		dataRow["HTTP_NAME"] = tHttpPath.Text;
		dataRow["URL_NAME"] = tUrlPath.Text;
		dataRow["URL_ID"] = tUrlId.Text;
		dataRow["URL_PWD"] = tUrlPwd.Text;
		dataRow["RTGS_TYPE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkResetData.Checked, (object)"Y", (object)"N"));
		DC_Main.Rshlp.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		DC_Main.RsQry = "DELETE FROM CO_MAST WHERE CO_CODE = '" + tCoCode.Text + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM CO_MAST  WHERE CO_CODE  = '" + tCoCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow2 = DC_Main.Rshlp.NewRow();
		dataRow2["CO_CODE"] = tCoCode.Text;
		dataRow2["CO_NAME"] = tCoName.Text;
		dataRow2["LC_CODE"] = CurLcCode;
		dataRow2["CO_SNAME"] = CoSname;
		dataRow2["CO_ADD1"] = tAddress1.Text;
		dataRow2["CO_ADD2"] = tAddress2.Text;
		dataRow2["CO_ADD3"] = tAddress3.Text;
		dataRow2["CO_COUNTRY"] = tCountry.Text;
		dataRow2["CO_STATE"] = Strings.Mid(TState.Text, 1, 25);
		dataRow2["CO_STATE_CODE"] = tStateCode.Text;
		dataRow2["CO_CITY"] = tCity.Text;
		dataRow2["CO_PIN"] = tPinCode.Text;
		dataRow2["CO_PHONE"] = tPhone.Text;
		dataRow2["CO_PHONE2"] = tPhone2.Text;
		dataRow2["CO_MOBILE"] = tMobile.Text;
		dataRow2["CO_MOBILE2"] = tMobile2.Text;
		dataRow2["CO_MAIL"] = tEmail.Text;
		dataRow2["MAIL_API"] = tMailApi.Text;
		dataRow2["WORK_TYPE"] = Strings.Mid(cboWorkType.Text, 1, 1);
		dataRow2["METAL_TYPE"] = Strings.Mid(cboMetalType.Text, 1, 1);
		dataRow2["REP_ADD_TYPE"] = Strings.Mid(cboRptHader.Text, 1, 1);
		dataRow2["CO_GST_NO"] = tGstNo.Text;
		dataRow2["CO_CSTNO"] = tCstNo.Text;
		dataRow2["CO_PAN_NO"] = tPanNo.Text;
		dataRow2["DHIRAN_NO"] = tDhiranNo.Text;
		dataRow2["CO_JUD"] = tJudrection.Text;
		dataRow2["BANK_NAME"] = tBankName.Text;
		dataRow2["BANK_AREA"] = tBankArea.Text;
		dataRow2["BANK_AC_NO"] = tBankAcNo.Text;
		dataRow2["BANK_RTGS_NO"] = tRtgsNo.Text;
		dataRow2["MAIN_USER"] = MainUser;
		dataRow2["CO_TYPE"] = tCoType.Text;
		dataRow2["HTTP_NAME"] = tHttpPath.Text;
		dataRow2["URL_NAME"] = tUrlPath.Text;
		dataRow2["URL_ID"] = tUrlId.Text;
		dataRow2["URL_PWD"] = tUrlPwd.Text;
		dataRow2["RTGS_TYPE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkResetData.Checked, (object)"Y", (object)"N"));
		DC_Main.Rshlp.Rows.Add(dataRow2);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		if (Operators.CompareString(CoSname, "UAE", false) == 0)
		{
			DC_Main.RsQry = "UPDATE CO_SET_NEW SET SALES_WITH_HMTAX = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsSalesWithHmTax = "Y";
			DC_Main.RsQry = "UPDATE CO_SET_NEW SET PURC_WITH_HMTAX = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsPurcWithHmTax = "Y";
			DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_NAME = 'Tax Report' WHERE MAIN_SRNO = '05' AND SM_MAIN_CODE = '09' AND SM_MAIN_NAME = 'Gst Report'");
		}
		if ((Operators.CompareString(DC_Main.MCo_code, tCoCode.Text, false) != 0) & (Operators.CompareString(tAcCode.Text, "", false) != 0))
		{
			DC_Main.RsQry = "DELETE FROM FAN_AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND FAN_CO_CODE = '" + tCoCode.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO FAN_AC_MAST(CO_CODE,FAN_CO_CODE,FAN_AC_CODE,FAN_CO_NAME) VALUES  ('" + DC_Main.MCo_code + "','" + tCoCode.Text + "','" + tAcCode.Text + "','" + tAcName.Text + "')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		if ((Operators.CompareString(tCoType.Text, "A", false) == 0) | (Operators.CompareString(tCoType.Text, "B", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsOpblTrfrBtn, "N", false) == 0)
			{
				DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET RESET_BOOK = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MAIN_BOOK IN ('000','015')");
				DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET RESET_BOOK = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_TYPE = 'T'");
			}
			DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET TRFR_BOOK = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		}
		DC_Main.ExeQuteDc("UPDATE LOCT_MAST SET TRY_DATE = '" + Strings.Format((object)DateAndTime.Now.AddDays(10.0), "MM/dd/yyyy") + "' WHERE CO_CODE  = '01' AND LC_CODE = '00'");
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.NewCompCode = tCoCode.Text;
			DC_Main.NewMstCreat = "Y";
			DC_Main.MCo_code = DC_Main.NewCompCode;
			DC_Main.MCo_Name = tCoName.Text;
			DC_Main.MCo_Type = "R";
			DC_Main.MCo_SName = "";
			DC_Main.MCo_year = "";
			DC_Main.MCo_Book = "";
			DC_Main.MCo_BookType = "";
			MS_YEAR mS_YEAR = new MS_YEAR();
			((Form)mS_YEAR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)mS_YEAR).Show();
			((Control)mS_YEAR).Focus();
			((Form)this).Close();
		}
		else
		{
			DC_Main.NewCompCode = "";
			DC_Main.NewMstCreat = "";
			DC_Main.NewYearCode = "";
			DC_Main.RsQry = "SELECT * FROM CO_MAST  ORDER BY CO_CODE ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
			{
				AppSchemeTrfr();
			}
			CLEAR_DATA();
		}
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
			DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
			DC_Main.RsQry = "DELETE FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteScm(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DataTable tbl = DC_Main.Tbl;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO CO_MAST(CO_CODE,CO_NAME,LC_CODE,CO_SNAME,CO_ADD1,CO_ADD2,CO_ADD3,  CO_COUNTRY,CO_STATE_CODE,CO_STATE,CO_CITY,CO_PIN,CO_PHONE,CO_PHONE2,CO_MOBILE,CO_MOBILE2,CO_MAIL,  CO_JUD,CO_LSTNO,CO_CSTNO,CO_GST_NO,CO_PAN_NO,DHIRAN_NO,BANK_NAME,BANK_AREA,BANK_AC_NO,   CO_TYPE,ALTER_YEAR,CO_MSG,REP_ADD_TYPE,MAIN_USER,WORK_TYPE,METAL_TYPE,URL_NAME,URL_ID,URL_PWD,HTTP_NAME,MAIL_API)  VALUES('" + DC_Main.MCo_code + "','"), tbl.Rows[0]["CO_NAME"]), (object)"','"), tbl.Rows[0]["LC_CODE"]), (object)"','"), tbl.Rows[0]["CO_SNAME"]), (object)"','"), tbl.Rows[0]["CO_ADD1"]), (object)"','"), tbl.Rows[0]["CO_ADD2"]), (object)"','"), tbl.Rows[0]["CO_ADD3"]), (object)"', "), (object)" '"), tbl.Rows[0]["CO_COUNTRY"]), (object)"','"), tbl.Rows[0]["CO_STATE_CODE"]), (object)"','"), tbl.Rows[0]["CO_STATE"]), (object)"','"), tbl.Rows[0]["CO_CITY"]), (object)"','"), tbl.Rows[0]["CO_PIN"]), (object)"','"), tbl.Rows[0]["CO_PHONE"]), (object)"','"), tbl.Rows[0]["CO_PHONE2"]), (object)"','"), tbl.Rows[0]["CO_MOBILE"]), (object)"','"), tbl.Rows[0]["CO_MOBILE2"]), (object)"','"), tbl.Rows[0]["CO_MAIL"]), (object)"', "), (object)" '"), tbl.Rows[0]["CO_JUD"]), (object)"','"), tbl.Rows[0]["CO_LSTNO"]), (object)"','"), tbl.Rows[0]["CO_CSTNO"]), (object)"','"), tbl.Rows[0]["CO_GST_NO"]), (object)"','"), tbl.Rows[0]["CO_PAN_NO"]), (object)"','"), tbl.Rows[0]["DHIRAN_NO"]), (object)"','"), tbl.Rows[0]["BANK_NAME"]), (object)"','"), tbl.Rows[0]["BANK_AREA"]), (object)"','"), tbl.Rows[0]["BANK_AC_NO"]), (object)"', "), (object)" '"), tbl.Rows[0]["CO_TYPE"]), (object)"','"), tbl.Rows[0]["ALTER_YEAR"]), (object)"','"), tbl.Rows[0]["CO_MSG"]), (object)"','"), tbl.Rows[0]["REP_ADD_TYPE"]), (object)"','"), tbl.Rows[0]["MAIN_USER"]), (object)"','"), tbl.Rows[0]["WORK_TYPE"]), (object)"','"), tbl.Rows[0]["METAL_TYPE"]), (object)"','"), tbl.Rows[0]["URL_NAME"]), (object)"','"), tbl.Rows[0]["URL_ID"]), (object)"','"), tbl.Rows[0]["URL_PWD"]), (object)"','"), tbl.Rows[0]["HTTP_NAME"]), (object)"','"), tbl.Rows[0]["MAIL_API"]), (object)"')"));
				DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				tbl = null;
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d6: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tCoCode.Text, "01", false) == 0)
		{
			Interaction.MsgBox((object)"You cant Delete Defoult company...", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tCoCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Company Code For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"All Record From This Company Will Delete Permanently ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteMc("DELETE FROM CO_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteMc("DELETE FROM AC_MAST_SRNO WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteMc("DELETE FROM LOCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_GROUP WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_ADJ WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_MEMB WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ADD_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAL_GR WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BANK_RECONCILE WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BUL_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CARD_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CASH_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CO_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CO_SET WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM COL_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CONV_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CRNT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CUT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CUT_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CUT_STK_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DELETE_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_KR_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_SIZE WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM E_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM E_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM EMP_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM EMP_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM FINE_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM GROUP_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITEM_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_LOT_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_OPBL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_WT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LDR_ADJ_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LOCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_ISU_REC WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MLT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MLT_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MODEL_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PAY_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PAY_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM POINT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM POINT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM POINT_MEMB WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PRINT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PRODUCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM REM_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM REP_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM REP_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TABLE_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_ADD WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TOUCH_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM USER_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM USER_REQUEST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM VP_ADJ_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM WEB_DATA WHERE  CO_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM YEAR_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			DC_Main.RsQry = "SELECT * FROM CO_MAST  ORDER BY CO_CODE ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			CLEAR_DATA();
		}
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
			tCoCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tCoName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void MSG_DoubleClick(object sender, EventArgs e)
	{
		tCoCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tCoName).Focus();
	}

	private void MS_COMPANY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
		}
		if (((int)e.KeyCode == 79) & e.Control)
		{
			((Control)BtnSave).Enabled = false;
			((Control)tCoType).Enabled = true;
			((Control)tCoType).Focus();
		}
		if ((((int)e.KeyCode == 82) & e.Control) && Operators.CompareString(DC_Main.MsMasterResetAllData, "Y", false) == 0)
		{
			((Control)chkResetData).Visible = true;
		}
	}

	private void tCoCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tCoCode.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Co Code ...", (MsgBoxStyle)0, (object)null);
				((Control)tCoCode).Focus();
			}
			else
			{
				((Control)cboWithOldCoMast).Focus();
			}
		}
	}

	private void tCoName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)pnlUae).Visible = true;
				eMastData();
			}
			else
			{
				((Control)GroupBox1).Visible = true;
				eMastData();
			}
		}
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tCoName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Co Name ...", (MsgBoxStyle)0, (object)null);
				((Control)tCoName).Focus();
			}
			else
			{
				((Control)cboWithOldCoMast).Focus();
			}
		}
	}

	private void tAddress1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAddress2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAddress3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tCountry_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void TState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPinCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPhone_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPhone2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tmobile_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tMobile2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tEmail_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tJudrection_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			TabMenu.SelectNextTab();
			((Control)tBankName).Focus();
		}
	}

	private void tGstNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tCstNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPanNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tDhiranNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankAcNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRtgsNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void cboRptHader_KeyDown(object sender, KeyEventArgs e)
	{
		TabMenu.SelectNextTab();
		((Control)tGstNo).Focus();
	}

	private void tCoName_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " CO_NAME = '" + tCoName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["CO_CODE"], (object)tCoCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Company Name already Exist in  '", dataView[0]["CO_CODE"]), (object)"'  Company Code...Please Change Company Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tCoName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\Company.RPT";
		Cr.SelectionFormula = "{CO_MAST.CO_CODE} = '" + DC_Main.MCo_code + "' ";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					CLEAR_DATA();
					goto IL_000b;
				case 576:
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
							goto IL_0020;
						case 5:
							goto IL_0031;
						case 6:
							goto IL_004c;
						case 7:
							goto IL_0083;
						case 8:
							goto IL_00ba;
						case 9:
							goto IL_00f1;
						case 10:
							goto IL_0129;
						case 11:
							goto IL_015a;
						case 12:
							goto IL_018b;
						case 13:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 14:
						case 15:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0129:
					num2 = 10;
					DC_Main.MsHttpPath = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HTTP_NAME"], (object)""));
					goto IL_015a;
					IL_015a:
					num2 = 11;
					DC_Main.MsUrlPath = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_NAME"], (object)""));
					goto IL_018b;
					IL_00f1:
					num2 = 9;
					tUrlPwd.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_PWD"], (object)""));
					goto IL_0129;
					IL_018b:
					num2 = 12;
					DC_Main.MsUrlId = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_ID"], (object)""));
					break;
					IL_000b:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0014;
					IL_0014:
					num2 = 3;
					DC_Main.RsQry = "SELECT HTTP_NAME,URL_NAME,URL_ID,URL_PWD FROM CO_MAST WHERE CO_CODE = '01'";
					goto IL_0020;
					IL_0020:
					num2 = 4;
					DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					goto IL_0031;
					IL_0031:
					num2 = 5;
					if (DC_Main.Tbl.Rows.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_004c;
					IL_004c:
					num2 = 6;
					tHttpPath.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HTTP_NAME"], (object)""));
					goto IL_0083;
					IL_0083:
					num2 = 7;
					tUrlPath.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_NAME"], (object)""));
					goto IL_00ba;
					IL_00ba:
					num2 = 8;
					tUrlId.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_ID"], (object)""));
					goto IL_00f1;
					end_IL_0001_2:
					break;
				}
				num2 = 13;
				DC_Main.MsUrlPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_PWD"], (object)""));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 576;
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

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			MSG_FILL();
		}
		else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			MSG_CLEAR();
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = "CO_NAME Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 80;
				((DataGridView)DGV).Columns[0].DataPropertyName = "CO_CODE";
				((DataGridView)DGV).Columns[1].Width = 320;
				((DataGridView)DGV).Columns[1].DataPropertyName = "CO_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_COMPANY_Activated(object sender, EventArgs e)
	{
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		CurActCtrl.Focus();
	}

	private void MS_COMPANY_Closed(object sender, EventArgs e)
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

	private void LblCoReset_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_1629: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"All Record From This Company Will Delete Permanently ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteMc("DELETE FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteMc("DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE <> '00'");
			DC_Main.ExeQuteMc("DELETE FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LOGIN_NAME <> 'ABC' ");
			DC_Main.ExeQuteMc("DELETE FROM USER_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND USER_NAME <> 'ABC'");
			DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR <> '" + DC_Main.MCo_year + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("UPDATE AC_GROUP SET USER_SHOW_GROUP = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(AC_CODE AS INT) > 99");
			DC_Main.ExeQuteDc("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAL_GR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(SALE_AC AS INT) > 7 ");
			DC_Main.ExeQuteDc("DELETE FROM BANK_RECONCILE WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("UPDATE BOOK_DETL SET AC_CODE = '00075' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_BOOK IN('005','006','007','008','009','010','011','012','013','014') AND SR_NO = 1");
			DC_Main.ExeQuteDc("UPDATE BOOK_IDTL SET AC_CODE = 0 WHERE MAIN_BOOK = 'PURC RETURN' AND SR_NO = 5");
			DC_Main.ExeQuteDc("DELETE FROM BUL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_CODE <> '01'");
			DC_Main.ExeQuteDc("DELETE FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("UPDATE CO_SET SET VB_IMPORT = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("UPDATE CONV_MAST SET GOLD_CONV = 1.0573,SILVER_CONV = 1.022 WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CRNT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DELETE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_SIZE WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND EMP_CODE <> '001'");
			DC_Main.ExeQuteDc("DELETE FROM EMP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM FINE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("UPDATE HDD_MAST SET REF_NO = 'P'");
			DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_CITY WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LDR_ADJ_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE <> '00'");
			DC_Main.ExeQuteDc("UPDATE LOCT_MAST SET TRY_DATE = NULL");
			DC_Main.ExeQuteDc("DELETE FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LOGIN_NAME <> 'ABC'");
			DC_Main.ExeQuteDc("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MLT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MLT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM PAY_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM PAY_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM POINT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM POINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM POINT_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC ");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM REM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJMEL_BAL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TABLE_CODE <> '001'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM USER_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_AD_DATA");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_ADD");
			DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM USER_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM USER_REQUEST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM VP_ADJ_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM WEB_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR <> '" + DC_Main.MCo_year + "'");
			DC_Main.ExeQuteImg("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '00'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.i = 0;
			checked
			{
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Tbl.Rows[DC_Main.i]["PR_CODE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["PR_NAME"]), (object)"','"), (object)DC_Main.MCo_User), (object)"' ) "));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				DC_Main.i = 0;
				DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '00'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Tbl.Rows[DC_Main.i]["GR_CODE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["GR_NAME"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["GR_TYPE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["TRAD_TYPE"]), (object)"',"), DC_Main.Tbl.Rows[DC_Main.i]["GR_TOUCH"]), (object)",0,"), DC_Main.Tbl.Rows[DC_Main.i]["MELTING_PRC"]), (object)", "), (object)" "), DC_Main.Tbl.Rows[DC_Main.i]["GR_RATE"]), (object)",0,'"), DC_Main.Tbl.Rows[DC_Main.i]["SALE_AC"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["PURC_AC"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["HSN_CODE"]), (object)"','"), (object)DC_Main.MCo_User), (object)"',0,0,0,0 )"));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				DC_Main.Tbl.Clear();
				DC_Main.Tbl.Columns.Clear();
				DC_Main.i = 0;
				DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '00'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,  ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["IT_TYPE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["TAG_TYPE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["PR_CODE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["GR_CODE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["TRAD_TYPE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["UNIT_NAME"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["RATE_TYPE"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["HSN_CODE"]), (object)"', "), (object)" "), DC_Main.Tbl.Rows[DC_Main.i]["ITEM_RATE"]), (object)","), DC_Main.Tbl.Rows[DC_Main.i]["LBR_PRC"]), (object)",0,0,0,0,0,0,0,0,0,'"), DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]), (object)"','"), (object)DC_Main.MCo_User), (object)"')"));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				DC_Main.Tbl.Clear();
				DC_Main.Tbl.Columns.Clear();
				DC_Main.i = 0;
				DC_Main.RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '00'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_RPT,COL_NEW_NAME,YES_NO) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Tbl.Rows[DC_Main.i]["BOOK_NAME"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["COL_NAME"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["COL_RPT"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["COL_NEW_NAME"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.i]["YES_NO"]), (object)"')"));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				DC_Main.Tbl.Clear();
				DC_Main.Tbl.Columns.Clear();
				DC_Main.OpenTable_ColMast();
				DC_Main.MsVbImport = "N";
				Interaction.MsgBox((object)"Data Is Reset ok....", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void cboWorkType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboMetalType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)lblCoReset).Visible = true;
	}

	private void tStateCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From STATE_MAST WHERE STATE_CODE = '" + tStateCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT STATE_NAME As StateL,STATE_CODE As CodeL,STATE_SHORT As ShortL FROM STATE_MAST ORDER BY STATE_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tStateCode.Text = DC_Main.ColValue[1];
					TState.Text = DC_Main.ColValue[0];
				}
				((Control)tStateCode).Focus();
			}
		}
		else
		{
			TState.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["STATE_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void mLockDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mLockDate).SelectionStart = 0;
		((TextBoxBase)mLockDate).SelectionLength = Strings.Len(mLockDate.Text);
	}

	private void mLockDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mLockDate;
			DC_Main.SetDate(ref MsDate);
			mLockDate = MsDate;
			if (!DC_Main.RongDate)
			{
				DC_Main.ExeQuteDc("UPDATE CO_SET SET LOCK_DATE = '" + Strings.Format((object)Conversions.ToDate(mLockDate.Text), "MM/dd/yyyy") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.MsLockDt = Conversions.ToDate(mLockDate.Text);
				Interaction.MsgBox((object)"Lock Date Is Set...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)lblLockDt).Visible = true;
		((Control)mLockDate).Visible = true;
		((Control)BtnSave).Enabled = true;
	}

	private void tCoType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DC_Main.MCo_Type = tCoType.Text;
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void cboWithOldCoMast_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboWithOldCoMast.SelectedIndex != 0)
		{
			DC_Main.MsOldCoCode = cboWithOldCoMast.Text;
		}
		else
		{
			DC_Main.MsOldCoCode = "";
		}
	}

	private void cboWithOldCoMast_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tCoName.Text, "", false) == 0)
			{
				((Control)tCoName).Focus();
			}
			else
			{
				((Control)tAddress1).Focus();
			}
		}
		else
		{
			((Control)cboWithOldCoMast).Focus();
		}
	}

	private void tGstNo_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = "SELECT * FROM CONV_MAST  WHERE CO_CODE = '01' AND CON_CODE = 'A'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM CONV_MAST WHERE CO_CODE = '01' AND CON_CODE IN ('A','B','" + DC_Main.MsDataType + "')");
			DC_Main.ExeQuteDc("INSERT INTO CONV_MAST (CO_CODE,CON_CODE,CON_NAME) VALUES('01','A','A')");
			DC_Main.ExeQuteDc("INSERT INTO CONV_MAST (CO_CODE,CON_CODE,CON_NAME) VALUES('01','B','B')");
			DC_Main.ExeQuteDc("INSERT INTO CONV_MAST (CO_CODE,CON_CODE,CON_NAME) VALUES('01','C','" + DC_Main.MsDataType + "')");
		}
		((Control)PanelAbc).Visible = true;
		((Control)tA).Focus();
	}

	private void tA_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tB).Focus();
		}
	}

	private void tB_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tC).Focus();
		}
	}

	private void tC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btnSet).Focus();
		}
	}

	private void btnSet_Click(object sender, EventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Record will Update permantley ?", (MsgBoxStyle)68, (object)null) == 6 && ((Operators.CompareString(tA.Text, "", false) != 0) & (Operators.CompareString(tB.Text, "", false) != 0) & (Operators.CompareString(tC.Text, "", false) != 0)))
		{
			DC_Main.ExeQuteDc("UPDATE CONV_MAST SET CON_NAME = '" + tA.Text + "' WHERE CO_CODE = '01' AND CON_CODE = 'A'");
			DC_Main.ExeQuteDc("UPDATE CONV_MAST SET CON_NAME = '" + tB.Text + "' WHERE CO_CODE = '01' AND CON_CODE = 'B'");
			DC_Main.ExeQuteDc("UPDATE CONV_MAST SET CON_NAME = '" + tC.Text + "' WHERE CO_CODE = '01' AND CON_CODE = 'C'");
			Interaction.MsgBox((object)"Data Type Is Updated....", (MsgBoxStyle)0, (object)null);
			((Control)PanelAbc).Visible = false;
		}
	}

	private void PanelAbc_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = "SELECT * FROM CONV_MAST WHERE CO_CODE = '01' AND CON_CODE = 'A'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			tA.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CON_NAME"], (object)""));
		}
		DC_Main.RsQry = "SELECT * FROM CONV_MAST WHERE CO_CODE = '01' AND CON_CODE = 'B'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			tB.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CON_NAME"], (object)""));
		}
		DC_Main.RsQry = "SELECT * FROM CONV_MAST WHERE CO_CODE = '01' AND CON_CODE = 'C'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			tC.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CON_NAME"], (object)""));
		}
	}

	private void BtneExit_Click(object sender, EventArgs e)
	{
		((Control)GroupBox1).Visible = false;
	}

	private void tCoName_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			((Control)pnlUae).Visible = true;
		}
		else
		{
			((Control)GroupBox1).Visible = true;
		}
		eMastData();
	}

	private void eMastData()
	{
		DC_Main.RsQry = "SELECT * FROM E_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				tUaeClientId.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["CLIENT_ID"]);
				tClientSecret.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["CLIENT_SECRET"]);
				tTerminalCode.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["UAT_CODE"]);
				return;
			}
			teGstNo.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_GST_NO"]);
			tePortalId.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_USER"]);
			tePortalPwd.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_PWD"]);
			tAspId.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_ID"]);
			tAspPwd.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_PWD"]);
			tLigalName.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["CO_LEGAL_NAME"]);
		}
	}

	private void BtneSave_Click(object sender, EventArgs e)
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "DELETE FROM E_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM E_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = DC_Main.Rshlp.NewRow();
		dataRow["CO_CODE"] = DC_Main.MCo_code;
		dataRow["E_LOGIN_GST_NO"] = teGstNo.Text;
		dataRow["E_LOGIN_USER"] = tePortalId.Text;
		dataRow["E_LOGIN_PWD"] = tePortalPwd.Text;
		dataRow["ASP_ID"] = tAspId.Text;
		dataRow["ASP_PWD"] = tAspPwd.Text;
		dataRow["CO_LEGAL_NAME"] = tLigalName.Text;
		DC_Main.Rshlp.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		((Control)GroupBox1).Visible = false;
	}

	private void tePortalPwd_DoubleClick(object sender, EventArgs e)
	{
		tePortalPwd.PasswordChar = '\0';
	}

	private void tAspPwd_DoubleClick(object sender, EventArgs e)
	{
		tAspPwd.PasswordChar = '\0';
	}

	private void BtnUrlSet_Click(object sender, EventArgs e)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_MAST SET HTTP_NAME = '" + tHttpPath.Text + "',URL_NAME = '" + tUrlPath.Text + "',URL_ID = '" + tUrlId.Text + "',URL_PWD = '" + tUrlPwd.Text + "' WHERE CO_CODE = '01'";
		DC_Main.ExeQuteMc(DC_Main.RsQry);
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsHttpPath = tHttpPath.Text;
		DC_Main.MsUrlPath = tUrlPath.Text;
		DC_Main.MsUrlId = tUrlId.Text;
		DC_Main.MsUrlPwd = tUrlPwd.Text;
		Interaction.MsgBox((object)"Url Path is Set", (MsgBoxStyle)0, (object)null);
	}

	private void tHttpPath_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tUrlPath).Focus();
		}
	}

	private void TStateCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void Panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void Panel1_DoubleClick(object sender, EventArgs e)
	{
		((Control)Label29).Visible = true;
		((Control)tUrlId).Visible = true;
		((Control)Label28).Visible = true;
		((Control)tUrlPwd).Visible = true;
	}

	private void GroupBox1_DoubleClick(object sender, EventArgs e)
	{
		((Control)lblLigalName).Visible = true;
		((Control)tLigalName).Visible = true;
	}

	private void tMailApi_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btneSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void btnSaveUae_Click(object sender, EventArgs e)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "DELETE FROM E_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM E_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = DC_Main.Rshlp.NewRow();
		dataRow["CO_CODE"] = DC_Main.MCo_code;
		dataRow["CLIENT_ID"] = tUaeClientId.Text;
		dataRow["CLIENT_SECRET"] = tClientSecret.Text;
		dataRow["UAT_CODE"] = tTerminalCode.Text;
		DC_Main.Rshlp.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		((Control)pnlUae).Visible = false;
	}

	private void BtnExitUae_Click(object sender, EventArgs e)
	{
		((Control)pnlUae).Visible = false;
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[8];
			DC_Main.ColWidth[0] = 270.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 170.0;
			DC_Main.ColWidth[3] = 180.0;
			DC_Main.ColWidth[4] = 220.0;
			DC_Main.ColWidth[5] = 160.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (DC_Main.MsCreat)
			{
				MS_ACCT mS_ACCT = new MS_ACCT();
				((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ACCT).Show();
				((Control)mS_ACCT).Focus();
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
			}
			((Control)tAcCode).Focus();
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}
}
