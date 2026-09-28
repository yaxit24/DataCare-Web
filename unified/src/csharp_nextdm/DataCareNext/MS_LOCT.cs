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
public class MS_LOCT : Form
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
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRptHader")]
	private ComboBox _cboRptHader;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tJudrection")]
	private TextBox _tJudrection;

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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private string CurLcCode;

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

	internal virtual DataGridViewX DGV
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
			DataGridViewX val2 = _DGV;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblReset")]
	private virtual Label _lblReset;

	internal virtual Label lblReset
	{
		get
		{
			return _lblReset;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblReset = value;
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
			TextBox val2 = _tCoName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tCoName = value;
			val2 = _tCoName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
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
			TextBox val2 = _tGstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tGstNo = value;
			val2 = _tGstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("TabMenu")]
	private virtual SuperTabControl _TabMenu;

	private virtual SuperTabControl TabMenu
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

	private virtual SuperTabControlPanel TabPanel1
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

	private virtual SuperTabItem Tab1
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

	private virtual SuperTabControlPanel TabPanel3
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

	private virtual SuperTabItem Tab3
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

	private virtual SuperTabControlPanel TabPanel2
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

	private virtual SuperTabItem Tab2
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("chkItmDisc")]
	private virtual CheckBox _chkItmDisc;

	internal virtual CheckBox chkItmDisc
	{
		get
		{
			return _chkItmDisc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkItmDisc = value;
		}
	}

	public int newindex { get; set; }

	public MS_LOCT()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_LOCT_Load;
		((Form)this).Deactivate += MS_LOCT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_LOCT_KeyPress);
		((Control)this).Validated += MS_LOCT_Validated;
		((Control)this).KeyDown += new KeyEventHandler(MS_LOCT_KeyDown);
		((Form)this).Activated += MS_LOCT_Activated;
		((Form)this).Closed += MS_LOCT_Closed;
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
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected O, but got Unknown
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Expected O, but got Unknown
		//IL_08f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fb: Expected O, but got Unknown
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Expected O, but got Unknown
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Expected O, but got Unknown
		//IL_0af8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Expected O, but got Unknown
		//IL_0bd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdb: Expected O, but got Unknown
		//IL_0c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7a: Expected O, but got Unknown
		//IL_0cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Expected O, but got Unknown
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de5: Expected O, but got Unknown
		//IL_0e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e58: Expected O, but got Unknown
		//IL_0fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff9: Expected O, but got Unknown
		//IL_103f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1049: Expected O, but got Unknown
		//IL_150a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1514: Expected O, but got Unknown
		//IL_15d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15de: Expected O, but got Unknown
		//IL_168f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1699: Expected O, but got Unknown
		//IL_171a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1724: Expected O, but got Unknown
		//IL_17d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e3: Expected O, but got Unknown
		//IL_186a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1874: Expected O, but got Unknown
		//IL_192f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1939: Expected O, but got Unknown
		//IL_19f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fe: Expected O, but got Unknown
		//IL_1a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9c: Expected O, but got Unknown
		//IL_1b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b57: Expected O, but got Unknown
		//IL_1b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf8: Expected O, but got Unknown
		//IL_1cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb6: Expected O, but got Unknown
		//IL_1cd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d57: Expected O, but got Unknown
		//IL_1e0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e15: Expected O, but got Unknown
		//IL_1e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb2: Expected O, but got Unknown
		//IL_1f63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6d: Expected O, but got Unknown
		//IL_1f8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2000: Unknown result type (might be due to invalid IL or missing references)
		//IL_200a: Expected O, but got Unknown
		//IL_20c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d2: Expected O, but got Unknown
		//IL_20f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2166: Unknown result type (might be due to invalid IL or missing references)
		//IL_2170: Expected O, but got Unknown
		//IL_2190: Unknown result type (might be due to invalid IL or missing references)
		//IL_2204: Unknown result type (might be due to invalid IL or missing references)
		//IL_220e: Expected O, but got Unknown
		//IL_222e: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ac: Expected O, but got Unknown
		//IL_22cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_233f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2349: Expected O, but got Unknown
		//IL_2369: Unknown result type (might be due to invalid IL or missing references)
		//IL_23dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e6: Expected O, but got Unknown
		//IL_2403: Unknown result type (might be due to invalid IL or missing references)
		//IL_2476: Unknown result type (might be due to invalid IL or missing references)
		//IL_2480: Expected O, but got Unknown
		//IL_249d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2510: Unknown result type (might be due to invalid IL or missing references)
		//IL_251a: Expected O, but got Unknown
		//IL_253d: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b7: Expected O, but got Unknown
		//IL_2665: Unknown result type (might be due to invalid IL or missing references)
		//IL_266f: Expected O, but got Unknown
		//IL_271d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2727: Expected O, but got Unknown
		//IL_27d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_27df: Expected O, but got Unknown
		//IL_288d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2897: Expected O, but got Unknown
		//IL_2945: Unknown result type (might be due to invalid IL or missing references)
		//IL_294f: Expected O, but got Unknown
		//IL_29fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a04: Expected O, but got Unknown
		//IL_2aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab9: Expected O, but got Unknown
		//IL_2b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b74: Expected O, but got Unknown
		//IL_2bf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bfc: Expected O, but got Unknown
		//IL_2c76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c80: Expected O, but got Unknown
		//IL_2d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d35: Expected O, but got Unknown
		//IL_2fbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fc5: Expected O, but got Unknown
		//IL_2fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3056: Unknown result type (might be due to invalid IL or missing references)
		//IL_3060: Expected O, but got Unknown
		//IL_307d: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_30fb: Expected O, but got Unknown
		//IL_3118: Unknown result type (might be due to invalid IL or missing references)
		//IL_318c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3196: Expected O, but got Unknown
		//IL_31b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3216: Unknown result type (might be due to invalid IL or missing references)
		//IL_3220: Expected O, but got Unknown
		//IL_32ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_32c4: Expected O, but got Unknown
		//IL_335e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3368: Expected O, but got Unknown
		//IL_3402: Unknown result type (might be due to invalid IL or missing references)
		//IL_340c: Expected O, but got Unknown
		//IL_3692: Unknown result type (might be due to invalid IL or missing references)
		//IL_369c: Expected O, but got Unknown
		//IL_36b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_372d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3737: Expected O, but got Unknown
		//IL_3754: Unknown result type (might be due to invalid IL or missing references)
		//IL_37c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_37d2: Expected O, but got Unknown
		//IL_37ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_3863: Unknown result type (might be due to invalid IL or missing references)
		//IL_386d: Expected O, but got Unknown
		//IL_388a: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_38f4: Expected O, but got Unknown
		//IL_398b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3995: Expected O, but got Unknown
		//IL_3a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a36: Expected O, but got Unknown
		//IL_3acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ad7: Expected O, but got Unknown
		//IL_3bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c07: Expected O, but got Unknown
		//IL_3c35: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_LOCT));
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
		DGV = new DataGridViewX();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		chkItmDisc = new CheckBox();
		Label16 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		cboRptHader = new ComboBox();
		Label15 = new Label();
		lblReset = new Label();
		tJudrection = new TextBox();
		Label7 = new Label();
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
		tRtgsNo = new TextBox();
		tBankAcNo = new TextBox();
		tBankArea = new TextBox();
		tBankName = new TextBox();
		Label11 = new Label();
		Label12 = new Label();
		Label13 = new Label();
		Label14 = new Label();
		Tab3 = new SuperTabItem();
		Text1 = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)Pnl2).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
		((Control)Pnl3).SuspendLayout();
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
		((Control)PnlBotam).TabIndex = 5;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1211, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(95, 37);
		((Control)BtnExit).TabIndex = 25;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1110, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(95, 37);
		((Control)BtnDelete).TabIndex = 24;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1009, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(95, 37);
		((Control)BtnCancel).TabIndex = 23;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(908, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(95, 37);
		((Control)BtnSave).TabIndex = 22;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(807, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(95, 37);
		((Control)BtnPrint).TabIndex = 26;
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
		lblBook.Text = "Location Master";
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
		((Control)DGV).Size = new Size(395, 391);
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
		((Control)Pnl1).Controls.Add((Control)(object)chkItmDisc);
		((Control)Pnl1).Controls.Add((Control)(object)Label16);
		((Control)Pnl1).Controls.Add((Control)(object)tAcCode);
		((Control)Pnl1).Controls.Add((Control)(object)tAcName);
		((Control)Pnl1).Controls.Add((Control)(object)cboRptHader);
		((Control)Pnl1).Controls.Add((Control)(object)Label15);
		((Control)Pnl1).Controls.Add((Control)(object)lblReset);
		((Control)Pnl1).Controls.Add((Control)(object)tJudrection);
		((Control)Pnl1).Controls.Add((Control)(object)Label7);
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
		((ButtonBase)chkItmDisc).BackColor = Color.Transparent;
		((Control)chkItmDisc).Font = new Font("Arial", 9.75f);
		((Control)chkItmDisc).ForeColor = Color.Black;
		((ButtonBase)chkItmDisc).ImeMode = (ImeMode)0;
		((Control)chkItmDisc).Location = new Point(287, 405);
		((Control)chkItmDisc).Name = "chkItmDisc";
		((Control)chkItmDisc).RightToLeft = (RightToLeft)0;
		((Control)chkItmDisc).Size = new Size(127, 27);
		((Control)chkItmDisc).TabIndex = 1169;
		((ButtonBase)chkItmDisc).Text = "Item Discount";
		((ButtonBase)chkItmDisc).UseVisualStyleBackColor = false;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(24, 379);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(92, 19);
		((Control)Label16).TabIndex = 1168;
		Label16.Text = "Branch Ac";
		Label16.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(127, 377);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(79, 23);
		((Control)tAcCode).TabIndex = 1166;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(211, 377);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(307, 23);
		((Control)tAcName).TabIndex = 1167;
		cboRptHader.AutoCompleteMode = (AutoCompleteMode)2;
		cboRptHader.AutoCompleteSource = (AutoCompleteSource)256;
		cboRptHader.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboRptHader).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboRptHader).FormattingEnabled = true;
		((Control)cboRptHader).Location = new Point(127, 407);
		cboRptHader.MaxLength = 5;
		((Control)cboRptHader).Name = "cboRptHader";
		((Control)cboRptHader).Size = new Size(124, 24);
		((Control)cboRptHader).TabIndex = 15;
		((Control)cboRptHader).Visible = false;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(24, 407);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(124, 20);
		((Control)Label15).TabIndex = 139;
		Label15.Text = "Report Hader";
		Label15.TextAlign = (ContentAlignment)16;
		((Control)Label15).Visible = false;
		((Control)lblReset).BackColor = Color.Transparent;
		((Control)lblReset).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblReset).ForeColor = Color.Black;
		lblReset.ImeMode = (ImeMode)0;
		((Control)lblReset).Location = new Point(198, 18);
		((Control)lblReset).Name = "lblReset";
		((Control)lblReset).Size = new Size(66, 20);
		((Control)lblReset).TabIndex = 112;
		lblReset.Text = "-";
		lblReset.TextAlign = (ContentAlignment)32;
		((Control)lblReset).Visible = false;
		((TextBoxBase)tJudrection).BackColor = SystemColors.Window;
		((Control)tJudrection).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tJudrection).Location = new Point(127, 348);
		((Control)tJudrection).Margin = new Padding(2);
		((TextBoxBase)tJudrection).MaxLength = 30;
		((Control)tJudrection).Name = "tJudrection";
		((Control)tJudrection).Size = new Size(391, 23);
		((Control)tJudrection).TabIndex = 14;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(24, 349);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(119, 19);
		((Control)Label7).TabIndex = 137;
		Label7.Text = "Jurisdiction";
		Label7.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tMobile2).BackColor = SystemColors.Window;
		((Control)tMobile2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobile2).Location = new Point(370, 288);
		((Control)tMobile2).Margin = new Padding(2);
		((TextBoxBase)tMobile2).MaxLength = 15;
		((Control)tMobile2).Name = "tMobile2";
		((Control)tMobile2).Size = new Size(148, 23);
		((Control)tMobile2).TabIndex = 12;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(277, 290);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(86, 19);
		((Control)Label6).TabIndex = 135;
		Label6.Text = "Mobile No2";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPhone2).BackColor = SystemColors.Window;
		((Control)tPhone2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPhone2).Location = new Point(370, 259);
		((Control)tPhone2).Margin = new Padding(2);
		((TextBoxBase)tPhone2).MaxLength = 15;
		((Control)tPhone2).Name = "tPhone2";
		((Control)tPhone2).Size = new Size(148, 23);
		((Control)tPhone2).TabIndex = 10;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(277, 259);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(86, 19);
		((Control)Label5).TabIndex = 133;
		Label5.Text = "Phone No2";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TState).BackColor = SystemColors.Window;
		((Control)TState).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TState).Location = new Point(127, 197);
		((Control)TState).Margin = new Padding(2);
		((TextBoxBase)TState).MaxLength = 25;
		((Control)TState).Name = "TState";
		((Control)TState).Size = new Size(391, 23);
		((Control)TState).TabIndex = 6;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(24, 199);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(119, 19);
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
		((Control)Label3).Size = new Size(119, 19);
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
		((TextBoxBase)tPinCode).BackColor = Color.White;
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
		((Control)lblEmail).Size = new Size(107, 19);
		((Control)lblEmail).TabIndex = 127;
		lblEmail.Text = "Email";
		lblEmail.TextAlign = (ContentAlignment)16;
		((Control)lblMoNo).BackColor = Color.Transparent;
		((Control)lblMoNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMoNo).ForeColor = Color.Black;
		lblMoNo.ImeMode = (ImeMode)0;
		((Control)lblMoNo).Location = new Point(24, 289);
		((Control)lblMoNo).Name = "lblMoNo";
		((Control)lblMoNo).Size = new Size(108, 19);
		((Control)lblMoNo).TabIndex = 126;
		lblMoNo.Text = "Mobile No";
		lblMoNo.TextAlign = (ContentAlignment)16;
		((Control)lblPhone).BackColor = Color.Transparent;
		((Control)lblPhone).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblPhone).ForeColor = Color.Black;
		lblPhone.ImeMode = (ImeMode)0;
		((Control)lblPhone).Location = new Point(24, 259);
		((Control)lblPhone).Name = "lblPhone";
		((Control)lblPhone).Size = new Size(108, 19);
		((Control)lblPhone).TabIndex = 125;
		lblPhone.Text = "Phone No";
		lblPhone.TextAlign = (ContentAlignment)16;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(24, 229);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(101, 19);
		((Control)lblCity).TabIndex = 124;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)16;
		((Control)lblAdd3).BackColor = Color.Transparent;
		((Control)lblAdd3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd3).ForeColor = Color.Black;
		lblAdd3.ImeMode = (ImeMode)0;
		((Control)lblAdd3).Location = new Point(24, 139);
		((Control)lblAdd3).Name = "lblAdd3";
		((Control)lblAdd3).Size = new Size(119, 19);
		((Control)lblAdd3).TabIndex = 123;
		lblAdd3.Text = "Address3";
		lblAdd3.TextAlign = (ContentAlignment)16;
		((Control)lblAdd2).BackColor = Color.Transparent;
		((Control)lblAdd2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd2).ForeColor = Color.Black;
		lblAdd2.ImeMode = (ImeMode)0;
		((Control)lblAdd2).Location = new Point(24, 109);
		((Control)lblAdd2).Name = "lblAdd2";
		((Control)lblAdd2).Size = new Size(119, 19);
		((Control)lblAdd2).TabIndex = 122;
		lblAdd2.Text = "Address2";
		lblAdd2.TextAlign = (ContentAlignment)16;
		((Control)lblAdd1).BackColor = Color.Transparent;
		((Control)lblAdd1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.Black;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(24, 79);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).Size = new Size(116, 19);
		((Control)lblAdd1).TabIndex = 121;
		lblAdd1.Text = "Address1";
		lblAdd1.TextAlign = (ContentAlignment)16;
		((Control)lblBookCo).BackColor = Color.Transparent;
		((Control)lblBookCo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblBookCo).ForeColor = Color.Black;
		lblBookCo.ImeMode = (ImeMode)0;
		((Control)lblBookCo).Location = new Point(333, 227);
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
		((Control)Label2).Size = new Size(97, 20);
		((Control)Label2).TabIndex = 110;
		Label2.Text = "Co Code";
		Label2.TextAlign = (ContentAlignment)16;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(24, 48);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(105, 20);
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
		((Control)Pnl2).Controls.Add((Control)(object)tPanNo);
		((Control)Pnl2).Controls.Add((Control)(object)tDhiranNo);
		((Control)Pnl2).Controls.Add((Control)(object)tCstNo);
		((Control)Pnl2).Controls.Add((Control)(object)tGstNo);
		((Control)Pnl2).Controls.Add((Control)(object)Label8);
		((Control)Pnl2).Controls.Add((Control)(object)lblMoNo2);
		((Control)Pnl2).Controls.Add((Control)(object)Label9);
		((Control)Pnl2).Controls.Add((Control)(object)Label10);
		((Control)Pnl2).Location = new Point(-13, -4);
		((Control)Pnl2).Name = "Pnl2";
		((Control)Pnl2).Size = new Size(578, 441);
		((Control)Pnl2).TabIndex = 0;
		((TextBoxBase)tPanNo).BackColor = SystemColors.Window;
		((Control)tPanNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPanNo).Location = new Point(127, 86);
		((Control)tPanNo).Margin = new Padding(2);
		((TextBoxBase)tPanNo).MaxLength = 30;
		((Control)tPanNo).Name = "tPanNo";
		((Control)tPanNo).Size = new Size(391, 23);
		((Control)tPanNo).TabIndex = 18;
		((TextBoxBase)tDhiranNo).BackColor = SystemColors.Window;
		((Control)tDhiranNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tDhiranNo).Location = new Point(127, 114);
		((Control)tDhiranNo).Margin = new Padding(2);
		((TextBoxBase)tDhiranNo).MaxLength = 30;
		((Control)tDhiranNo).Name = "tDhiranNo";
		((Control)tDhiranNo).Size = new Size(391, 23);
		((Control)tDhiranNo).TabIndex = 19;
		((TextBoxBase)tCstNo).BackColor = SystemColors.Window;
		((Control)tCstNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCstNo).Location = new Point(127, 57);
		((Control)tCstNo).Margin = new Padding(2);
		((TextBoxBase)tCstNo).MaxLength = 30;
		((Control)tCstNo).Name = "tCstNo";
		((Control)tCstNo).Size = new Size(391, 23);
		((Control)tCstNo).TabIndex = 17;
		((TextBoxBase)tGstNo).BackColor = SystemColors.Window;
		((Control)tGstNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGstNo).Location = new Point(127, 29);
		((Control)tGstNo).Margin = new Padding(2);
		((TextBoxBase)tGstNo).MaxLength = 30;
		((Control)tGstNo).Name = "tGstNo";
		((Control)tGstNo).Size = new Size(391, 23);
		((Control)tGstNo).TabIndex = 16;
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
		((Control)lblMoNo2).Size = new Size(98, 19);
		((Control)lblMoNo2).TabIndex = 88;
		lblMoNo2.Text = "Gst / Tin No";
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
		((Control)Pnl3).Controls.Add((Control)(object)tRtgsNo);
		((Control)Pnl3).Controls.Add((Control)(object)tBankAcNo);
		((Control)Pnl3).Controls.Add((Control)(object)tBankArea);
		((Control)Pnl3).Controls.Add((Control)(object)tBankName);
		((Control)Pnl3).Controls.Add((Control)(object)Label11);
		((Control)Pnl3).Controls.Add((Control)(object)Label12);
		((Control)Pnl3).Controls.Add((Control)(object)Label13);
		((Control)Pnl3).Controls.Add((Control)(object)Label14);
		((Control)Pnl3).Location = new Point(-12, -3);
		((Control)Pnl3).Name = "Pnl3";
		((Control)Pnl3).Size = new Size(578, 440);
		((Control)Pnl3).TabIndex = 1;
		((TextBoxBase)tRtgsNo).BackColor = SystemColors.Window;
		((Control)tRtgsNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRtgsNo).Location = new Point(127, 112);
		((Control)tRtgsNo).Margin = new Padding(2);
		((TextBoxBase)tRtgsNo).MaxLength = 30;
		((Control)tRtgsNo).Name = "tRtgsNo";
		((Control)tRtgsNo).Size = new Size(391, 23);
		((Control)tRtgsNo).TabIndex = 23;
		((TextBoxBase)tBankAcNo).BackColor = SystemColors.Window;
		((Control)tBankAcNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankAcNo).Location = new Point(127, 84);
		((Control)tBankAcNo).Margin = new Padding(2);
		((TextBoxBase)tBankAcNo).MaxLength = 30;
		((Control)tBankAcNo).Name = "tBankAcNo";
		((Control)tBankAcNo).Size = new Size(391, 23);
		((Control)tBankAcNo).TabIndex = 22;
		((TextBoxBase)tBankArea).BackColor = SystemColors.Window;
		((Control)tBankArea).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankArea).Location = new Point(127, 56);
		((Control)tBankArea).Margin = new Padding(2);
		((TextBoxBase)tBankArea).MaxLength = 40;
		((Control)tBankArea).Name = "tBankArea";
		((Control)tBankArea).Size = new Size(391, 23);
		((Control)tBankArea).TabIndex = 21;
		((TextBoxBase)tBankName).BackColor = SystemColors.Window;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(127, 28);
		((Control)tBankName).Margin = new Padding(2);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(391, 23);
		((Control)tBankName).TabIndex = 20;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(17, 112);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(108, 19);
		((Control)Label11).TabIndex = 85;
		Label11.Text = "Rtgs No";
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
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_LOCT";
		((Form)this).Text = "Location";
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
		((Control)TabPanel3).ResumeLayout(false);
		((Control)Pnl3).ResumeLayout(false);
		((Control)Pnl3).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_LOCT_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_10f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fc: Expected O, but got Unknown
		//IL_116c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1171: Unknown result type (might be due to invalid IL or missing references)
		//IL_117b: Expected O, but got Unknown
		//IL_11e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f4: Expected O, but got Unknown
		//IL_1262: Unknown result type (might be due to invalid IL or missing references)
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_126d: Expected O, but got Unknown
		//IL_12db: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e6: Expected O, but got Unknown
		//IL_1354: Unknown result type (might be due to invalid IL or missing references)
		//IL_1359: Unknown result type (might be due to invalid IL or missing references)
		//IL_135f: Expected O, but got Unknown
		//IL_13e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f6: Expected O, but got Unknown
		//IL_1468: Unknown result type (might be due to invalid IL or missing references)
		//IL_146d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1473: Expected O, but got Unknown
		//IL_1525: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1534: Expected O, but got Unknown
		//IL_1553: Unknown result type (might be due to invalid IL or missing references)
		//IL_1558: Unknown result type (might be due to invalid IL or missing references)
		//IL_1562: Expected O, but got Unknown
		//IL_1581: Unknown result type (might be due to invalid IL or missing references)
		//IL_1586: Unknown result type (might be due to invalid IL or missing references)
		//IL_1590: Expected O, but got Unknown
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV = DGV;
				object? obj9 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj11 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj12 = lblBook;
				object? obj13 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj14 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj15 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcName).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcName).Font;
				try
				{
					foreach (Control control7 in ((Control)this).Controls)
					{
						Control val3 = control7;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is CheckBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control8 in ((Control)Pnl1).Controls)
					{
						object objectValue6 = RuntimeHelpers.GetObjectValue(control8);
						NewLateBinding.LateSet(objectValue6, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control9 in ((Control)Pnl2).Controls)
					{
						object objectValue7 = RuntimeHelpers.GetObjectValue(control9);
						NewLateBinding.LateSet(objectValue7, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control10 in ((Control)Pnl3).Controls)
					{
						object objectValue8 = RuntimeHelpers.GetObjectValue(control10);
						NewLateBinding.LateSet(objectValue8, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control11 in ((Control)TabMenu).Controls)
					{
						object objectValue9 = RuntimeHelpers.GetObjectValue(control11);
						NewLateBinding.LateSet(objectValue9, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
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
					foreach (object control12 in ((Control)PnlBotam).Controls)
					{
						object objectValue10 = RuntimeHelpers.GetObjectValue(control12);
						NewLateBinding.LateSet(objectValue10, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
			cboRptHader.Items.Add((object)"Company");
			cboRptHader.Items.Add((object)"Location");
			cboRptHader.Items.Add((object)"Both");
			cboRptHader.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT * FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LC_CODE ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			BtnCancel_Click(BtnCancel, new EventArgs());
			CurActCtrl = (Control)(object)tCoName;
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
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
		TabMenu.SelectedTab = Tab1;
		DGV_FILL();
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tCoCode).MaxLength = 2;
		cboRptHader.SelectedIndex = 0;
		DC_Main.RsQry = "SELECT LC_CODE AS CoCode  From LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			tCoCode.Text = "01";
		}
		else
		{
			tCoCode.Text = Strings.Format(Operators.AddObject(DC_Main.Rshlp.Rows[0]["CoCode"], (object)1), "00");
		}
		EntryMode = "A";
		((Control)tCoName).Focus();
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
				((DataGridView)DGV).Columns[0].DataPropertyName = "LC_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "LC_NAME";
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
		DC_Main.RsQry = "select * from LOCT_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "' ORDER BY LC_CODE";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DataTable rshlp = DC_Main.Rshlp;
			tCoCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_CODE"], (object)""));
			tCoName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_NAME"], (object)""));
			CurLcCode = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_CODE"], (object)""));
			tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_ADD1"], (object)""));
			tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_ADD2"], (object)""));
			tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_ADD3"], (object)""));
			tCity.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_CITY"], (object)""));
			tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_PHONE"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_MOBILE"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIN_USER"], (object)""));
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CODE"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_NAME"], (object)""));
			tCountry.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_COUNTRY"], (object)""));
			TState.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_STATE"], (object)""));
			tPinCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_PIN"], (object)""));
			tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_MAIL"], (object)""));
			tJudrection.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_JUD"], (object)""));
			tPhone2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_PHONE2"], (object)""));
			tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LC_MOBILE2"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["ITEM_DISCOUNT"], (object)""), (object)"Y", false))
			{
				chkItmDisc.Checked = true;
			}
			else
			{
				chkItmDisc.Checked = false;
			}
			rshlp = null;
			EntryMode = "E";
			((TextBoxBase)tCoCode).ReadOnly = true;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_LOCT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_LOCT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_LOCT_Validated(object sender, EventArgs e)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		bool flag = flag;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " LC_CODE = '" + tCoCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["LC_NAME"], (object)tCoName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Location Code already Exist in  '", dataView[0]["LC_NAME"]), (object)"'  Location Name...Please Change Company Code..."), (MsgBoxStyle)0, (object)null);
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(tCoCode.Text, "", false) == 0) | (Operators.CompareString(tCoName.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Enter Company Detail", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "' ";
		DC_Main.ExeQuteMc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM LOCT_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = DC_Main.Rshlp.NewRow();
		dataRow["CO_CODE"] = DC_Main.MCo_code;
		dataRow["LC_NAME"] = tCoName.Text;
		dataRow["LC_CODE"] = tCoCode.Text;
		dataRow["LC_ADD1"] = tAddress1.Text;
		dataRow["LC_ADD2"] = tAddress2.Text;
		dataRow["LC_ADD3"] = tAddress3.Text;
		dataRow["LC_CITY"] = tCity.Text;
		dataRow["LC_PHONE"] = tPhone.Text;
		dataRow["LC_MOBILE"] = tMobile.Text;
		dataRow["MAIN_USER"] = MainUser;
		dataRow["AC_CODE"] = tAcCode.Text;
		dataRow["AC_NAME"] = tAcName.Text;
		dataRow["LC_COUNTRY"] = tCountry.Text;
		dataRow["LC_STATE"] = TState.Text;
		dataRow["LC_PIN"] = tPinCode.Text;
		dataRow["LC_MAIL"] = tEmail.Text;
		dataRow["LC_JUD"] = tJudrection.Text;
		dataRow["LC_PHONE2"] = tPhone2.Text;
		dataRow["LC_MOBILE2"] = tMobile2.Text;
		dataRow["ITEM_DISCOUNT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkItmDisc.Checked, (object)"Y", (object)"N"));
		DC_Main.Rshlp.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '03' AND SM_MAIN_NAME = 'Stock Out'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '03' AND SM_MAIN_NAME = 'Stock In'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '09' AND SM_MAIN_NAME = 'Amt Out'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '09' AND SM_MAIN_NAME = 'Amt In'");
		DC_Main.RsQry = "DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM LOCT_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow2 = DC_Main.Rshlp.NewRow();
		dataRow2["CO_CODE"] = DC_Main.MCo_code;
		dataRow2["LC_NAME"] = tCoName.Text;
		dataRow2["LC_CODE"] = tCoCode.Text;
		dataRow2["LC_ADD1"] = tAddress1.Text;
		dataRow2["LC_ADD2"] = tAddress2.Text;
		dataRow2["LC_ADD3"] = tAddress3.Text;
		dataRow2["LC_CITY"] = tCity.Text;
		dataRow2["LC_PHONE"] = tPhone.Text;
		dataRow2["LC_MOBILE"] = tMobile.Text;
		dataRow2["MAIN_USER"] = MainUser;
		dataRow2["AC_CODE"] = tAcCode.Text;
		dataRow2["AC_NAME"] = tAcName.Text;
		dataRow2["LC_COUNTRY"] = tCountry.Text;
		dataRow2["LC_STATE"] = TState.Text;
		dataRow2["LC_PIN"] = tPinCode.Text;
		dataRow2["LC_MAIL"] = tEmail.Text;
		dataRow2["LC_JUD"] = tJudrection.Text;
		dataRow2["LC_PHONE2"] = tPhone2.Text;
		dataRow2["LC_MOBILE2"] = tMobile2.Text;
		dataRow2["ITEM_DISCOUNT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkItmDisc.Checked, (object)"Y", (object)"N"));
		DC_Main.Rshlp.Rows.Add(dataRow2);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_DATA (CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR)  SELECT '" + DC_Main.MCo_code + "','" + tCoCode.Text + "', CO_BOOK, BOOK_NAME, BOOK_SNAME, CUR_USE, BOOK_INOUT, MAIN_BOOK, ITM_TYPE, BOOK_TYPE, BOOK_VCH_TYPE, MAIN_USER, BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)  SELECT '" + DC_Main.MCo_code + "','" + tCoCode.Text + "',CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("INSERT INTO TABLE_MAST (CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME)  SELECT '" + DC_Main.MCo_code + "','" + tCoCode.Text + "',TABLE_CODE,TABLE_NAME FROM TABLE_MAST WHERE CO_CODE = '01' AND LC_CODE = '00' AND TABLE_CODE = '001'");
		}
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		DC_Main.RsQry = "SELECT * FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LC_CODE ";
		RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CLEAR_DATA();
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f10: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tCoCode.Text, "00", false) == 0)
		{
			Interaction.MsgBox((object)"You cant Delete Defoult Location...", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tCoCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Location Code For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"All Record From This Location Will Delete Permanently ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM FINE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tCoCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			DC_Main.RsQry = "SELECT * FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY CO_CODE ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			CLEAR_DATA();
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
			tCoCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tCoName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tCoCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tCoName).Focus();
	}

	private void MS_LOCT_KeyDown(object sender, KeyEventArgs e)
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
				SendKeys.Send("{tab}");
			}
		}
	}

	private void tCoName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tCoName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Co Name ...", (MsgBoxStyle)0, (object)null);
				((Control)tCoName).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
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
			((Control)cboRptHader).Focus();
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
			TabMenu.SelectNextTab();
			((Control)tBankName).Focus();
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
		dataView.RowFilter = " LC_NAME = '" + tCoName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["LC_CODE"], (object)tCoCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Company Name already Exist in  '", dataView[0]["LC_CODE"]), (object)"'  Location Code...Please Change Location Name..."), (MsgBoxStyle)0, (object)null);
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
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
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
			DGV_FILL();
		}
		else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = "LC_NAME Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 80;
				((DataGridView)DGV).Columns[0].DataPropertyName = "LC_CODE";
				((DataGridView)DGV).Columns[1].Width = 320;
				((DataGridView)DGV).Columns[1].DataPropertyName = "LC_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_LOCT_Activated(object sender, EventArgs e)
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

	private void MS_LOCT_Closed(object sender, EventArgs e)
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

	private void TAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.LC_CODE,A.AC_NAME";
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
			}
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
				DC_Main.MsGrCode = "07";
				MS_ACCT mS_ACCT = new MS_ACCT();
				((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ACCT).Show();
				((Control)mS_ACCT).Focus();
			}
			else
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}
}
