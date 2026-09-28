using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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
public class MS_ADD_MAST : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tdistrict")]
	private TextBox _tdistrict;

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
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankArea")]
	private TextBox _tBankArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankAcNo")]
	private TextBox _tBankAcNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRtgsNo")]
	private TextBox _tRtgsNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDay")]
	private TextBox _nCrDay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDpcPrc")]
	private TextBox _nDpcPrc;

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
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCountry")]
	private ComboBox _cboCountry;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboState")]
	private ComboBox _cboState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDistrict")]
	private ComboBox _cboDistrict;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConParcon")]
	private TextBox _tConParcon;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmail")]
	private TextBox _tEmail;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone")]
	private TextBox _tPhone;

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
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

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
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboGroup")]
	private ComboBox _cboGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mBhlDate")]
	private MaskedTextBox _mBhlDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mAnDate")]
	private MaskedTextBox _mAnDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mBhDate")]
	private MaskedTextBox _mBhDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAcImport")]
	private SimpleButton _btnAcImport;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private bool DletHoAc;

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
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
			}
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

	internal virtual TextBox tdistrict
	{
		[CompilerGenerated]
		get
		{
			return _tdistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tJudrection_KeyDown);
			TextBox val2 = _tdistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tdistrict = value;
			val2 = _tdistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("tRefAcName")]
	private virtual TextBox _tRefAcName;

	internal virtual TextBox tRefAcName
	{
		get
		{
			return _tRefAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRefAcName = value;
		}
	}

	internal virtual TextBox tRefAc
	{
		[CompilerGenerated]
		get
		{
			return _tRefAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRefAc_KeyDown);
			TextBox val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRefAc = value;
			val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nCrDay
	{
		[CompilerGenerated]
		get
		{
			return _nCrDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCrDay_KeyDown);
			TextBox val2 = _nCrDay;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrDay = value;
			val2 = _nCrDay;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCrDay")]
	private virtual Label _lblCrDay;

	internal virtual Label lblCrDay
	{
		get
		{
			return _lblCrDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCrDay = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLBDate")]
	private virtual Label _lblLBDate;

	internal virtual Label lblLBDate
	{
		get
		{
			return _lblLBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLBDate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBDate")]
	private virtual Label _lblBDate;

	internal virtual Label lblBDate
	{
		get
		{
			return _lblBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBDate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAnvDate")]
	private virtual Label _lblAnvDate;

	internal virtual Label lblAnvDate
	{
		get
		{
			return _lblAnvDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAnvDate = value;
		}
	}

	internal virtual TextBox nDpcPrc
	{
		[CompilerGenerated]
		get
		{
			return _nDpcPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDpcPrc_KeyDown);
			TextBox val2 = _nDpcPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDpcPrc = value;
			val2 = _nDpcPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblDpc")]
	private virtual Label _lblDpc;

	internal virtual Label lblDpc
	{
		get
		{
			return _lblDpc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDpc = value;
		}
	}

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

	internal virtual ComboBox cboArea
	{
		[CompilerGenerated]
		get
		{
			return _cboArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboArea_KeyDown);
			ComboBox val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboArea = value;
			val2 = _cboArea;
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

	internal virtual ComboBox cboCountry
	{
		[CompilerGenerated]
		get
		{
			return _cboCountry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCountry_KeyDown);
			ComboBox val2 = _cboCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCountry = value;
			val2 = _cboCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboState
	{
		[CompilerGenerated]
		get
		{
			return _cboState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboState_KeyDown);
			ComboBox val2 = _cboState;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboState = value;
			val2 = _cboState;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboDistrict
	{
		[CompilerGenerated]
		get
		{
			return _cboDistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboDistrict_KeyDown);
			ComboBox val2 = _cboDistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboDistrict = value;
			val2 = _cboDistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboCity
	{
		[CompilerGenerated]
		get
		{
			return _cboCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCity_KeyDown);
			ComboBox val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCity = value;
			val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tConParcon
	{
		[CompilerGenerated]
		get
		{
			return _tConParcon;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tConParcon_KeyDown);
			TextBox val2 = _tConParcon;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tConParcon = value;
			val2 = _tConParcon;
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

	internal virtual TextBox tAcName
	{
		[CompilerGenerated]
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			EventHandler eventHandler = tAcName_TextChanged;
			KeyEventHandler val2 = new KeyEventHandler(tAcName_KeyUp);
			CancelEventHandler cancelEventHandler = tAcName_Validating;
			TextBox val3 = _tAcName;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).TextChanged -= eventHandler;
				((Control)val3).KeyUp -= val2;
				((Control)val3).Validating -= cancelEventHandler;
			}
			_tAcName = value;
			val3 = _tAcName;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).TextChanged += eventHandler;
				((Control)val3).KeyUp += val2;
				((Control)val3).Validating += cancelEventHandler;
			}
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
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
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
	[AccessedThroughProperty("tCustDetl")]
	private virtual TextBox _tCustDetl;

	public virtual TextBox tCustDetl
	{
		get
		{
			return _tCustDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCustDetl = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpen")]
	private virtual OpenFileDialog _DlgOpen;

	internal virtual OpenFileDialog DlgOpen
	{
		get
		{
			return _DlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpen = value;
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

	internal virtual ComboBox cboGroup
	{
		[CompilerGenerated]
		get
		{
			return _cboGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboGroup_KeyDown);
			ComboBox val2 = _cboGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboGroup = value;
			val2 = _cboGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual MaskedTextBox mBhlDate
	{
		[CompilerGenerated]
		get
		{
			return _mBhlDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mBhlDate_KeyDown);
			MaskedTextBox val2 = _mBhlDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mBhlDate = value;
			val2 = _mBhlDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mAnDate
	{
		[CompilerGenerated]
		get
		{
			return _mAnDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mAnDate_KeyDown);
			MaskedTextBox val2 = _mAnDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mAnDate = value;
			val2 = _mAnDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mBhDate
	{
		[CompilerGenerated]
		get
		{
			return _mBhDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mBhDate_KeyDown);
			MaskedTextBox val2 = _mBhDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mBhDate = value;
			val2 = _mBhDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton btnAcImport
	{
		[CompilerGenerated]
		get
		{
			return _btnAcImport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAcImport_Click;
			SimpleButton val = _btnAcImport;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAcImport = value;
			val = _btnAcImport;
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
	[AccessedThroughProperty("DlgOpn")]
	private virtual OpenFileDialog _DlgOpn;

	internal virtual OpenFileDialog DlgOpn
	{
		get
		{
			return _DlgOpn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpn = value;
		}
	}

	public int newindex { get; set; }

	public MS_ADD_MAST()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		((Form)this).Load += MS_ADD_MAST_Load;
		((Form)this).Activated += MS_ADD_MAST_Activated;
		((Form)this).Deactivate += MS_ADD_MAST_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_ADD_MAST_KeyPress);
		((Control)this).Validating += tAcCode_Validating;
		((Control)this).KeyDown += new KeyEventHandler(MS_ADD_MAST_KeyDown);
		((Form)this).Closed += MS_ADD_MAST_Closed;
		DletHoAc = false;
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
		//IL_0d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d52: Expected O, but got Unknown
		//IL_0e37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e41: Expected O, but got Unknown
		//IL_0eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Expected O, but got Unknown
		//IL_207d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2087: Expected O, but got Unknown
		//IL_20ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f4: Expected O, but got Unknown
		//IL_2163: Unknown result type (might be due to invalid IL or missing references)
		//IL_216d: Expected O, but got Unknown
		//IL_223e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2248: Expected O, but got Unknown
		//IL_232b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2335: Expected O, but got Unknown
		//IL_2398: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a2: Expected O, but got Unknown
		//IL_2411: Unknown result type (might be due to invalid IL or missing references)
		//IL_241b: Expected O, but got Unknown
		//IL_247e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2488: Expected O, but got Unknown
		//IL_24f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2501: Expected O, but got Unknown
		//IL_2668: Unknown result type (might be due to invalid IL or missing references)
		//IL_2672: Expected O, but got Unknown
		//IL_2707: Unknown result type (might be due to invalid IL or missing references)
		//IL_2711: Expected O, but got Unknown
		//IL_2793: Unknown result type (might be due to invalid IL or missing references)
		//IL_279d: Expected O, but got Unknown
		//IL_286a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2874: Expected O, but got Unknown
		//IL_28cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d9: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_ADD_MAST));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		Text1 = new TextBox();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		mBhlDate = new MaskedTextBox();
		mAnDate = new MaskedTextBox();
		mBhDate = new MaskedTextBox();
		Label22 = new Label();
		Label9 = new Label();
		Label18 = new Label();
		cboGroup = new ComboBox();
		tMobile = new TextBox();
		lblMoNo = new Label();
		BtnF1 = new SimpleButton();
		cboArea = new ComboBox();
		cboCountry = new ComboBox();
		Label17 = new Label();
		cboState = new ComboBox();
		cboDistrict = new ComboBox();
		tConParcon = new TextBox();
		Label16 = new Label();
		cboCity = new ComboBox();
		lblBookCo = new Label();
		Label15 = new Label();
		lblCity = new Label();
		Label7 = new Label();
		tPinCode = new TextBox();
		Label4 = new Label();
		Label3 = new Label();
		tEmail = new TextBox();
		tPhone = new TextBox();
		tAddress3 = new TextBox();
		tAddress2 = new TextBox();
		tAddress1 = new TextBox();
		lblEmail = new Label();
		lblPhone = new Label();
		lblAdd3 = new Label();
		lblAdd2 = new Label();
		lblAdd1 = new Label();
		tAcName = new TextBox();
		tAcCode = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Tab1 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		tMobile2 = new TextBox();
		Label6 = new Label();
		tPhone2 = new TextBox();
		Label5 = new Label();
		nDpcPrc = new TextBox();
		lblDpc = new Label();
		nCrDay = new TextBox();
		lblCrDay = new Label();
		lblLBDate = new Label();
		lblBDate = new Label();
		lblAnvDate = new Label();
		tRtgsNo = new TextBox();
		tBankAcNo = new TextBox();
		tBankArea = new TextBox();
		tBankName = new TextBox();
		Label11 = new Label();
		Label12 = new Label();
		Label13 = new Label();
		Label14 = new Label();
		tRefAcName = new TextBox();
		tRefAc = new TextBox();
		Label20 = new Label();
		Tab2 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		Tab3 = new SuperTabItem();
		tdistrict = new TextBox();
		TState = new TextBox();
		tCountry = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnAcImport = new SimpleButton();
		tCustDetl = new TextBox();
		DlgOpen = new OpenFileDialog();
		DGV = new DataGridViewX();
		DlgOpn = new OpenFileDialog();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)Pnl2).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
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
		componentResourceManager.ApplyResources(TabMenu, "TabMenu");
		((Control)TabMenu).Name = "TabMenu";
		TabMenu.ReorderTabsEnabled = true;
		TabMenu.SelectedTabIndex = 0;
		TabMenu.TabAlignment = (eTabStripAlignment)3;
		TabMenu.TabLayoutType = (eSuperTabLayoutType)1;
		TabMenu.Tabs.AddRange((BaseItem[])(object)new BaseItem[3]
		{
			(BaseItem)Tab1,
			(BaseItem)Tab2,
			(BaseItem)Tab3
		});
		TabMenu.TabStyle = (eSuperTabStyle)1;
		((PanelControl)TabPanel1).CanvasColor = Color.Black;
		((Control)TabPanel1).Controls.Add((Control)(object)Pnl1);
		componentResourceManager.ApplyResources(TabPanel1, "TabPanel1");
		((Control)TabPanel1).Name = "TabPanel1";
		TabPanel1.TabItem = Tab1;
		((Control)Pnl1).Controls.Add((Control)(object)mBhlDate);
		((Control)Pnl1).Controls.Add((Control)(object)mAnDate);
		((Control)Pnl1).Controls.Add((Control)(object)mBhDate);
		((Control)Pnl1).Controls.Add((Control)(object)Label22);
		((Control)Pnl1).Controls.Add((Control)(object)Label9);
		((Control)Pnl1).Controls.Add((Control)(object)Label18);
		((Control)Pnl1).Controls.Add((Control)(object)cboGroup);
		((Control)Pnl1).Controls.Add((Control)(object)tMobile);
		((Control)Pnl1).Controls.Add((Control)(object)lblMoNo);
		((Control)Pnl1).Controls.Add((Control)(object)BtnF1);
		((Control)Pnl1).Controls.Add((Control)(object)cboArea);
		((Control)Pnl1).Controls.Add((Control)(object)cboCountry);
		((Control)Pnl1).Controls.Add((Control)(object)Label17);
		((Control)Pnl1).Controls.Add((Control)(object)cboState);
		((Control)Pnl1).Controls.Add((Control)(object)cboDistrict);
		((Control)Pnl1).Controls.Add((Control)(object)tConParcon);
		((Control)Pnl1).Controls.Add((Control)(object)Label16);
		((Control)Pnl1).Controls.Add((Control)(object)cboCity);
		((Control)Pnl1).Controls.Add((Control)(object)lblBookCo);
		((Control)Pnl1).Controls.Add((Control)(object)Label15);
		((Control)Pnl1).Controls.Add((Control)(object)lblCity);
		((Control)Pnl1).Controls.Add((Control)(object)Label7);
		((Control)Pnl1).Controls.Add((Control)(object)tPinCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label4);
		((Control)Pnl1).Controls.Add((Control)(object)Label3);
		((Control)Pnl1).Controls.Add((Control)(object)tEmail);
		((Control)Pnl1).Controls.Add((Control)(object)tPhone);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress3);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress2);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress1);
		((Control)Pnl1).Controls.Add((Control)(object)lblEmail);
		((Control)Pnl1).Controls.Add((Control)(object)lblPhone);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd3);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd2);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd1);
		((Control)Pnl1).Controls.Add((Control)(object)tAcName);
		((Control)Pnl1).Controls.Add((Control)(object)tAcCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label2);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		componentResourceManager.ApplyResources(Pnl1, "Pnl1");
		((Control)Pnl1).Name = "Pnl1";
		componentResourceManager.ApplyResources(mBhlDate, "mBhlDate");
		((Control)mBhlDate).Name = "mBhlDate";
		mBhlDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(mAnDate, "mAnDate");
		((Control)mAnDate).Name = "mAnDate";
		mAnDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(mBhDate, "mBhDate");
		((Control)mBhDate).Name = "mBhDate";
		mBhDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(Label22, "Label22");
		((Control)Label22).ForeColor = Color.Black;
		((Control)Label22).Name = "Label22";
		componentResourceManager.ApplyResources(Label9, "Label9");
		((Control)Label9).ForeColor = Color.Black;
		((Control)Label9).Name = "Label9";
		componentResourceManager.ApplyResources(Label18, "Label18");
		((Control)Label18).ForeColor = Color.Black;
		((Control)Label18).Name = "Label18";
		cboGroup.AutoCompleteMode = (AutoCompleteMode)2;
		cboGroup.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboGroup, "cboGroup");
		((ListControl)cboGroup).FormattingEnabled = true;
		((Control)cboGroup).Name = "cboGroup";
		((TextBoxBase)tMobile).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMobile, "tMobile");
		((Control)tMobile).Name = "tMobile";
		((Control)lblMoNo).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblMoNo, "lblMoNo");
		((Control)lblMoNo).ForeColor = Color.Black;
		((Control)lblMoNo).Name = "lblMoNo";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = (Font)componentResourceManager.GetObject("BtnF1.Appearance.Font");
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnF1.Appearance.GradientMode"));
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("BtnF1.AppearanceHovered.Font");
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnF1.AppearanceHovered.GradientMode"));
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = (Font)componentResourceManager.GetObject("BtnF1.AppearancePressed.Font");
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(BtnF1, "BtnF1");
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		cboArea.AutoCompleteMode = (AutoCompleteMode)2;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboArea, "cboArea");
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Name = "cboArea";
		cboCountry.AutoCompleteMode = (AutoCompleteMode)2;
		cboCountry.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboCountry, "cboCountry");
		((ListControl)cboCountry).FormattingEnabled = true;
		((Control)cboCountry).Name = "cboCountry";
		((Control)Label17).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label17, "Label17");
		((Control)Label17).ForeColor = Color.Black;
		((Control)Label17).Name = "Label17";
		cboState.AutoCompleteMode = (AutoCompleteMode)2;
		cboState.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboState, "cboState");
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Name = "cboState";
		cboDistrict.AutoCompleteMode = (AutoCompleteMode)2;
		cboDistrict.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboDistrict, "cboDistrict");
		((ListControl)cboDistrict).FormattingEnabled = true;
		((Control)cboDistrict).Name = "cboDistrict";
		((TextBoxBase)tConParcon).BackColor = Color.White;
		componentResourceManager.ApplyResources(tConParcon, "tConParcon");
		((Control)tConParcon).Name = "tConParcon";
		((Control)Label16).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label16, "Label16");
		((Control)Label16).ForeColor = Color.Black;
		((Control)Label16).Name = "Label16";
		cboCity.AutoCompleteMode = (AutoCompleteMode)2;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboCity, "cboCity");
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Name = "cboCity";
		((Control)lblBookCo).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblBookCo, "lblBookCo");
		((Control)lblBookCo).ForeColor = Color.Black;
		((Control)lblBookCo).Name = "lblBookCo";
		componentResourceManager.ApplyResources(Label15, "Label15");
		((Control)Label15).ForeColor = Color.Black;
		((Control)Label15).Name = "Label15";
		((Control)lblCity).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblCity, "lblCity");
		((Control)lblCity).ForeColor = Color.Black;
		((Control)lblCity).Name = "lblCity";
		((Control)Label7).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label7, "Label7");
		((Control)Label7).ForeColor = Color.Black;
		((Control)Label7).Name = "Label7";
		((TextBoxBase)tPinCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPinCode, "tPinCode");
		((Control)tPinCode).Name = "tPinCode";
		((Control)Label4).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		((Control)Label3).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		((TextBoxBase)tEmail).BackColor = Color.White;
		tEmail.CharacterCasing = (CharacterCasing)2;
		componentResourceManager.ApplyResources(tEmail, "tEmail");
		((Control)tEmail).Name = "tEmail";
		((TextBoxBase)tPhone).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPhone, "tPhone");
		((Control)tPhone).Name = "tPhone";
		((TextBoxBase)tAddress3).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress3, "tAddress3");
		((Control)tAddress3).Name = "tAddress3";
		((TextBoxBase)tAddress2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress2, "tAddress2");
		((Control)tAddress2).Name = "tAddress2";
		((TextBoxBase)tAddress1).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress1, "tAddress1");
		((Control)tAddress1).Name = "tAddress1";
		((Control)lblEmail).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblEmail, "lblEmail");
		((Control)lblEmail).ForeColor = Color.Black;
		((Control)lblEmail).Name = "lblEmail";
		((Control)lblPhone).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblPhone, "lblPhone");
		((Control)lblPhone).ForeColor = Color.Black;
		((Control)lblPhone).Name = "lblPhone";
		((Control)lblAdd3).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd3, "lblAdd3");
		((Control)lblAdd3).ForeColor = Color.Black;
		((Control)lblAdd3).Name = "lblAdd3";
		((Control)lblAdd2).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd2, "lblAdd2");
		((Control)lblAdd2).ForeColor = Color.Black;
		((Control)lblAdd2).Name = "lblAdd2";
		((Control)lblAdd1).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd1, "lblAdd1");
		((Control)lblAdd1).ForeColor = Color.Black;
		((Control)lblAdd1).Name = "lblAdd1";
		((TextBoxBase)tAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcName, "tAcName");
		((Control)tAcName).Name = "tAcName";
		((TextBoxBase)tAcCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcCode, "tAcCode");
		((Control)tAcCode).Name = "tAcCode";
		((TextBoxBase)tAcCode).ReadOnly = true;
		((Control)Label2).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		((Control)Label1).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		componentResourceManager.ApplyResources(Tab1, "Tab1");
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		componentResourceManager.ApplyResources(TabPanel2, "TabPanel2");
		((Control)TabPanel2).Name = "TabPanel2";
		TabPanel2.TabItem = Tab2;
		((Control)Pnl2).Controls.Add((Control)(object)tMobile2);
		((Control)Pnl2).Controls.Add((Control)(object)Label6);
		((Control)Pnl2).Controls.Add((Control)(object)tPhone2);
		((Control)Pnl2).Controls.Add((Control)(object)Label5);
		((Control)Pnl2).Controls.Add((Control)(object)nDpcPrc);
		((Control)Pnl2).Controls.Add((Control)(object)lblDpc);
		((Control)Pnl2).Controls.Add((Control)(object)nCrDay);
		((Control)Pnl2).Controls.Add((Control)(object)lblCrDay);
		((Control)Pnl2).Controls.Add((Control)(object)lblLBDate);
		((Control)Pnl2).Controls.Add((Control)(object)lblBDate);
		((Control)Pnl2).Controls.Add((Control)(object)lblAnvDate);
		((Control)Pnl2).Controls.Add((Control)(object)tRtgsNo);
		((Control)Pnl2).Controls.Add((Control)(object)tBankAcNo);
		((Control)Pnl2).Controls.Add((Control)(object)tBankArea);
		((Control)Pnl2).Controls.Add((Control)(object)tBankName);
		((Control)Pnl2).Controls.Add((Control)(object)Label11);
		((Control)Pnl2).Controls.Add((Control)(object)Label12);
		((Control)Pnl2).Controls.Add((Control)(object)Label13);
		((Control)Pnl2).Controls.Add((Control)(object)Label14);
		((Control)Pnl2).Controls.Add((Control)(object)tRefAcName);
		((Control)Pnl2).Controls.Add((Control)(object)tRefAc);
		((Control)Pnl2).Controls.Add((Control)(object)Label20);
		componentResourceManager.ApplyResources(Pnl2, "Pnl2");
		((Control)Pnl2).Name = "Pnl2";
		((TextBoxBase)tMobile2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMobile2, "tMobile2");
		((Control)tMobile2).Name = "tMobile2";
		((Control)Label6).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		((TextBoxBase)tPhone2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPhone2, "tPhone2");
		((Control)tPhone2).Name = "tPhone2";
		((Control)Label5).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label5, "Label5");
		((Control)Label5).ForeColor = Color.Black;
		((Control)Label5).Name = "Label5";
		componentResourceManager.ApplyResources(nDpcPrc, "nDpcPrc");
		((Control)nDpcPrc).Name = "nDpcPrc";
		((Control)lblDpc).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(lblDpc, "lblDpc");
		((Control)lblDpc).Name = "lblDpc";
		componentResourceManager.ApplyResources(nCrDay, "nCrDay");
		((Control)nCrDay).Name = "nCrDay";
		((Control)lblCrDay).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(lblCrDay, "lblCrDay");
		((Control)lblCrDay).Name = "lblCrDay";
		((Control)lblLBDate).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(lblLBDate, "lblLBDate");
		((Control)lblLBDate).Name = "lblLBDate";
		((Control)lblBDate).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(lblBDate, "lblBDate");
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblAnvDate).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(lblAnvDate, "lblAnvDate");
		((Control)lblAnvDate).Name = "lblAnvDate";
		componentResourceManager.ApplyResources(tRtgsNo, "tRtgsNo");
		((Control)tRtgsNo).Name = "tRtgsNo";
		componentResourceManager.ApplyResources(tBankAcNo, "tBankAcNo");
		((Control)tBankAcNo).Name = "tBankAcNo";
		componentResourceManager.ApplyResources(tBankArea, "tBankArea");
		((Control)tBankArea).Name = "tBankArea";
		componentResourceManager.ApplyResources(tBankName, "tBankName");
		((Control)tBankName).Name = "tBankName";
		((Control)Label11).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(Label11, "Label11");
		((Control)Label11).Name = "Label11";
		((Control)Label12).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(Label12, "Label12");
		((Control)Label12).Name = "Label12";
		((Control)Label13).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(Label13, "Label13");
		((Control)Label13).Name = "Label13";
		((Control)Label14).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(Label14, "Label14");
		((Control)Label14).Name = "Label14";
		((TextBoxBase)tRefAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRefAcName, "tRefAcName");
		((Control)tRefAcName).Name = "tRefAcName";
		((TextBoxBase)tRefAc).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRefAc, "tRefAc");
		((Control)tRefAc).Name = "tRefAc";
		((Control)Label20).ForeColor = Color.Black;
		componentResourceManager.ApplyResources(Label20, "Label20");
		((Control)Label20).Name = "Label20";
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		componentResourceManager.ApplyResources(Tab2, "Tab2");
		Tab2.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		componentResourceManager.ApplyResources(TabPanel3, "TabPanel3");
		((Control)TabPanel3).Name = "TabPanel3";
		TabPanel3.TabItem = Tab3;
		componentResourceManager.ApplyResources(Pnl3, "Pnl3");
		((Control)Pnl3).Name = "Pnl3";
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		componentResourceManager.ApplyResources(Tab3, "Tab3");
		Tab3.TextAlignment = (eItemAlignment)2;
		((TextBoxBase)tdistrict).BackColor = Color.White;
		componentResourceManager.ApplyResources(tdistrict, "tdistrict");
		((Control)tdistrict).Name = "tdistrict";
		((TextBoxBase)TState).BackColor = Color.White;
		componentResourceManager.ApplyResources(TState, "TState");
		((Control)TState).Name = "TState";
		((TextBoxBase)tCountry).BackColor = Color.White;
		componentResourceManager.ApplyResources(tCountry, "tCountry");
		((Control)tCountry).Name = "tCountry";
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnAcImport);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
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
		((BaseStyleControl)btnAcImport).Appearance.Font = (Font)componentResourceManager.GetObject("btnAcImport.Appearance.Font");
		((BaseStyleControl)btnAcImport).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnAcImport).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnAcImport).Appearance.Options.UseForeColor = true;
		componentResourceManager.ApplyResources(btnAcImport, "btnAcImport");
		((BaseControl)btnAcImport).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnAcImport).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnAcImport).Name = "btnAcImport";
		((BaseButton)btnAcImport).ToolTipAnchor = (ToolTipAnchor)1;
		tCustDetl.AcceptsReturn = true;
		((TextBoxBase)tCustDetl).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tCustDetl).BorderStyle = (BorderStyle)0;
		((Control)tCustDetl).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(tCustDetl, "tCustDetl");
		((TextBoxBase)tCustDetl).ForeColor = Color.Navy;
		((Control)tCustDetl).Name = "tCustDetl";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
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
		componentResourceManager.ApplyResources(DGV, "DGV");
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
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
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
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DGV).StandardTab = true;
		((FileDialog)DlgOpn).FileName = "DlgOpen";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tCustDetl);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)tdistrict);
		((Control)this).Controls.Add((Control)(object)TState);
		((Control)this).Controls.Add((Control)(object)tCountry);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_ADD_MAST";
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)Pnl1).PerformLayout();
		((Control)TabPanel2).ResumeLayout(false);
		((Control)Pnl2).ResumeLayout(false);
		((Control)Pnl2).PerformLayout();
		((Control)TabPanel3).ResumeLayout(false);
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_ADD_MAST_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_118d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1194: Expected O, but got Unknown
		//IL_1204: Unknown result type (might be due to invalid IL or missing references)
		//IL_1209: Unknown result type (might be due to invalid IL or missing references)
		//IL_1213: Expected O, but got Unknown
		//IL_1281: Unknown result type (might be due to invalid IL or missing references)
		//IL_1286: Unknown result type (might be due to invalid IL or missing references)
		//IL_128c: Expected O, but got Unknown
		//IL_12fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Expected O, but got Unknown
		//IL_1373: Unknown result type (might be due to invalid IL or missing references)
		//IL_1378: Unknown result type (might be due to invalid IL or missing references)
		//IL_137e: Expected O, but got Unknown
		//IL_13ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f7: Expected O, but got Unknown
		//IL_147f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_148e: Expected O, but got Unknown
		//IL_1500: Unknown result type (might be due to invalid IL or missing references)
		//IL_1505: Unknown result type (might be due to invalid IL or missing references)
		//IL_150b: Expected O, but got Unknown
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cc: Expected O, but got Unknown
		//IL_15eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fa: Expected O, but got Unknown
		//IL_1619: Unknown result type (might be due to invalid IL or missing references)
		//IL_161e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1628: Expected O, but got Unknown
		//IL_1699: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a3: Expected O, but got Unknown
		//IL_16b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c0: Expected O, but got Unknown
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
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
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
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj9 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj10 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj12 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj13 = lblBook;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj13).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj16 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj17 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj18 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
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
					TabMenu.SelectedTabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
					TabMenu.TabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
			}
			DC_Main.RsQry = "SELECT * FROM ADD_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			AddCboItem();
			CLEAR_DATA();
			EntryMode = "A";
			CurActCtrl = (Control)(object)tAcName;
		}
	}

	private void MS_ADD_MAST_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
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
				((DataGridView)DGV).Columns[0].DataPropertyName = "AC_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "AC_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
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
			else if ((object)objectValue.GetType() == typeof(ComboBox))
			{
				ComboBox val3 = (ComboBox)objectValue;
				val3.Text = "";
			}
		}
		foreach (object control3 in ((Control)Pnl2).Controls)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
			if ((object)objectValue2.GetType() == typeof(TextBox))
			{
				TextBox val4 = (TextBox)objectValue2;
				val4.Text = "";
			}
			if ((object)objectValue2.GetType() == typeof(MaskedTextBox))
			{
				MaskedTextBox val5 = (MaskedTextBox)objectValue2;
				val5.Text = "";
			}
		}
		foreach (object control4 in ((Control)Pnl3).Controls)
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
			if ((object)objectValue3.GetType() == typeof(TextBox))
			{
				TextBox val6 = (TextBox)objectValue3;
				val6.Text = "";
			}
		}
		AddCboItem();
		DGV_CLEAR();
		DGV_FILL();
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tAcCode).MaxLength = 8;
		if (Conversions.ToDouble(DC_Main.AcLcCodeLen) == 1.0)
		{
			DC_Main.RsQry = "SELECT AC_CODE As CoCode From ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 5 ORDER BY AC_CODE DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "0001";
			}
			else
			{
				tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "0000");
			}
		}
		else
		{
			DC_Main.RsQry = "SELECT AC_CODE As CoCode  From ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 ORDER BY AC_CODE DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tAcCode.Text = DC_Main.MLc_code + "0001";
			}
			else
			{
				tAcCode.Text = DC_Main.MLc_code + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
			}
		}
		EntryMode = "A";
		((Control)tAcName).Focus();
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * from ADD_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DataTable rshlp = DC_Main.Rshlp;
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CODE"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_NAME"], (object)""));
			cboGroup.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_GR"], (object)""));
			tConParcon.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PERSON"], (object)""));
			tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD1"], (object)""));
			tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD2"], (object)""));
			tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD3"], (object)""));
			cboCountry.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_COUNTRY"], (object)""));
			cboState.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_STATE"], (object)""));
			cboDistrict.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_DISTRICT"], (object)""));
			cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CITY"], (object)""));
			cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_AREA"], (object)""));
			tPinCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PIN"], (object)""));
			tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PHONE"], (object)""));
			tPhone2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PHONE2"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MOBILE"], (object)""));
			tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MOBILE2"], (object)""));
			tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_EMAIL"], (object)""));
			mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BR_DATE"], (object)""));
			mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AN_DATE"], (object)""));
			mBhlDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["L_BR_DATE"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIN_USER"], (object)""));
			rshlp = null;
			DC_Main.Rshlp.Clear();
			EntryMode = "E";
			((TextBoxBase)tAcCode).ReadOnly = true;
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

	private void MS_ADD_MAST_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_ADD_MAST_KeyPress(object sender, KeyPressEventArgs e)
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

	private void tAcCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " CO_CODE = '" + tAcCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["AC_NAME"], (object)tAcName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Customer already Exist in  '", dataView[0]["AC_NAME"]), (object)"'  Customer Name...Please Change Customer Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tAcCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsMast);
				dataView.RowFilter = "AC_NAME Like  '" + Text1.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).AutoGenerateColumns = false;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = "AC_CODE";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(320.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "AC_NAME";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
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
		DC_Main.RptName = "PartyMast";
		DC_Main.RptFormula = "{ADD_MAST.CO_CODE}= '" + DC_Main.MCo_code + "' AND {ADD_MAST.LC_CODE}= '" + DC_Main.MLc_code + "' ";
		UT_REPORT uT_REPORT = new UT_REPORT();
		((Control)uT_REPORT).Show();
		((Control)uT_REPORT).Focus();
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
			tAcCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tAcName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tAcCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tAcName).Focus();
	}

	private void MS_ADD_MAST_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		if (((int)e.KeyCode == 69) & e.Control)
		{
			((TextBoxBase)tAcCode).ReadOnly = false;
			((Control)tAcCode).Enabled = true;
			((TextBoxBase)tAcCode).BackColor = Color.MistyRose;
			((Control)tAcCode).Focus();
		}
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 75.0;
			DC_Main.ColWidth[3] = 300.0;
			DC_Main.ColWidth[4] = 100.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
				}
				DISPLAY_DATA();
				EntryMode = "E";
				((Control)tAcName).Focus();
			}
		}
		else if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tAcName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Party Name ...", (MsgBoxStyle)0, (object)null);
				((Control)tAcName).Focus();
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
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(tMobile.Text, "", false) != 0))
		{
			DC_Main.RsQry = "SELECT * FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MOBILE = '" + tMobile.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Mobile No = ", DC_Main.Rshlp.Rows[0]["AC_NAME"]), (object)" "), (object)" With this Account ....."), (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		SendKeys.Send("{tab}");
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

	private void tConParcon_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void AddCboItem()
	{
		DC_Main.RsQry = "SELECT AC_GR FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_GR ORDER BY AC_GR ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboGroup.Items.Clear();
				int count = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count)
				{
					cboGroup.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_GR"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboGroup.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_COUNTRY FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_COUNTRY ORDER BY AC_COUNTRY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCountry.Items.Clear();
				int count2 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count2)
				{
					cboCountry.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_COUNTRY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCountry.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_STATE FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_STATE <> '' GROUP BY AC_STATE   UNION ALL SELECT STATE_NAME as AC_STATE FROM STATE_MAST GROUP BY STATE_NAME ORDER BY AC_STATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboState.Items.Clear();
				int count3 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count3)
				{
					cboState.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_STATE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboState.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_DISTRICT FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_DISTRICT ORDER BY AC_DISTRICT ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboDistrict.Items.Clear();
				int count4 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count4)
				{
					cboDistrict.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_DISTRICT"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboDistrict.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_CITY FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int count5 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count5)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_CITY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCity.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_AREA FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				int count6 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count6)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
			}
		}
	}

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboCountry_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboDistrict_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcShort_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_TextChanged(object sender, EventArgs e)
	{
		tCustDetl.Text = tAcCode.Text + " - " + tAcName.Text + "  ( Mo - " + tMobile.Text + " )";
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tRefAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[7];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 75.0;
				DC_Main.ColWidth[3] = 300.0;
				DC_Main.ColWidth[4] = 100.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
						tRefAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				tRefAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_KeyUp(object sender, KeyEventArgs e)
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
					DGV_CLEAR();
					goto IL_000b;
				case 394:
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
							goto IL_0054;
						case 5:
							goto IL_0065;
						case 6:
							goto IL_0080;
						case 7:
							goto IL_008f;
						case 8:
							goto IL_00be;
						case 9:
							goto IL_00dc;
						case 10:
							goto IL_010c;
						case 11:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 12:
						case 13:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00be:
					num2 = 8;
					((DataGridView)DGV).Columns[0].Name = "AC_CODE";
					goto IL_00dc;
					IL_00dc:
					num2 = 9;
					((DataGridView)DGV).Columns[1].Width = checked((int)Math.Round(300.0 * ColCon));
					goto IL_010c;
					IL_008f:
					num2 = 7;
					((DataGridView)DGV).Columns[0].Width = checked((int)Math.Round(80.0 * ColCon));
					goto IL_00be;
					IL_010c:
					num2 = 10;
					((DataGridView)DGV).Columns[1].Name = "AC_NAME";
					break;
					IL_000b:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0014;
					IL_0014:
					num2 = 3;
					DC_Main.RsQry = "SELECT TOP 99 AC_CODE,AC_NAME FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_NAME LIKE  '" + tAcName.Text + "%' ";
					goto IL_0054;
					IL_0054:
					num2 = 4;
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0065;
					IL_0065:
					num2 = 5;
					if (DC_Main.Tbl.Rows.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0080;
					IL_0080:
					num2 = 6;
					((DataGridView)DGV).AutoGenerateColumns = false;
					goto IL_008f;
					end_IL_0001_2:
					break;
				}
				num2 = 11;
				((DataGridView)DGV).DataSource = DC_Main.Tbl;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 394;
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

	private void mBhDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mAnDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mBhlDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void tCrDay_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nDpcPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDpcPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDpcPrc.Text)), "0.00");
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
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
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " AC_NAME = '" + tAcName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["AC_CODE"], (object)tAcCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Ac Name already Exist in  '", dataView[0]["AC_CODE"]), (object)"'  Ac Code... Please Change Account Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tAcName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
				{
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if ((Operators.CompareString(tAcCode.Text, "", false) == 0) | (Operators.CompareString(tAcName.Text, "", false) == 0))
					{
						Interaction.MsgBox((object)"Please Select Customer name and try....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					DC_Main.RsQry = "DELETE FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM ADD_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = DC_Main.Rshlp.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["AC_CODE"] = tAcCode.Text;
					dataRow["AC_NAME"] = tAcName.Text;
					dataRow["AC_GR"] = cboGroup.Text;
					dataRow["AC_PERSON"] = tConParcon.Text;
					dataRow["AC_ADD1"] = tAddress1.Text;
					dataRow["AC_ADD2"] = tAddress2.Text;
					dataRow["AC_ADD3"] = tAddress3.Text;
					dataRow["AC_COUNTRY"] = cboCountry.Text;
					dataRow["AC_STATE"] = cboState.Text;
					dataRow["AC_DISTRICT"] = cboDistrict.Text;
					dataRow["AC_CITY"] = cboCity.Text;
					dataRow["AC_PIN"] = tPinCode.Text;
					dataRow["AC_AREA"] = cboArea.Text;
					dataRow["AC_PHONE"] = tPhone.Text;
					dataRow["AC_PHONE2"] = tPhone2.Text;
					dataRow["AC_MOBILE"] = tMobile.Text;
					dataRow["AC_MOBILE2"] = tMobile2.Text;
					dataRow["AC_EMAIL"] = tEmail.Text;
					dataRow["BR_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mBhDate.Text), (object)DBNull.Value, (object)mBhDate.Text));
					dataRow["AN_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mAnDate.Text), (object)DBNull.Value, (object)mAnDate.Text));
					dataRow["L_BR_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mBhlDate.Text), (object)DBNull.Value, (object)mBhlDate.Text));
					dataRow["MAIN_USER"] = MainUser;
					dataRow["DATA_TRFR"] = "N";
					DC_Main.Rshlp.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
					DC_Main.Rshlp.Clear();
					Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					if (DC_Main.MsCreat)
					{
						DC_Main.MsCode = tAcCode.Text;
						DC_Main.MsName = tAcName.Text;
						((Form)this).Close();
						goto end_IL_0001;
					}
					CLEAR_DATA();
					DC_Main.RsQry = "SELECT * FROM ADD_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_CODE ";
					RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DGV_FILL();
					goto end_IL_0001;
				}
				case 1249:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1249;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select AcCode For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Account now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM ADD_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM ADD_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void MS_ADD_MAST_Closed(object sender, EventArgs e)
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

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 75.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
			}
			DISPLAY_DATA();
			EntryMode = "E";
			((Control)tAcName).Focus();
		}
	}

	private void cboGroup_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private static DataTable ImportExceltoDatatable(string filepath)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		DataTable result;
		try
		{
			DataSet dataSet = new DataSet();
			string text = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
			OleDbConnection val = new OleDbConnection(text ?? "");
			val.Open();
			object objectValue = RuntimeHelpers.GetObjectValue(val.GetSchema("Tables").Rows[0]["TABLE_NAME"]);
			string text2 = $"SELECT * FROM [{RuntimeHelpers.GetObjectValue(objectValue)}]";
			OleDbDataAdapter val2 = new OleDbDataAdapter(text2, val);
			((DbDataAdapter)(object)val2).Fill(dataSet);
			dataTable = dataSet.Tables[0];
			result = dataTable;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)Information.Err().Description, (MsgBoxStyle)16, (object)null);
			result = dataTable;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void BtnAcImport_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Import Old Software Data In Next Software ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		((FileDialog)DlgOpen).Filter = "Excel files |*.xls;*.xlsx";
		((FileDialog)DlgOpen).Title = "Open File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
		{
			DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpen).FileName);
			string text = tAcCode.Text;
			checked
			{
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					DC_Main.RsQry = "INSERT INTO ADD_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_MOBILE,AC_GR)  VALUES  ('" + DC_Main.MCo_code + "','" + text + "','" + DC_Main.MLc_code + "','" + Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][0], (object)"")), 1, 50)) + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][1], (object)"")), 1, 10) + "','ALL')";
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					text = ((Operators.CompareString(DC_Main.MsVbImport, "Y", false) != 0) ? ((Conversions.ToDouble(DC_Main.AcLcCodeLen) != 1.0) ? (DC_Main.MLc_code + Strings.Format((object)(Conversion.Val(text) + 1.0), "000000")) : (Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(text) + 1.0), "00000"))) : (Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(text) + 1.0), "00000")));
					Application.DoEvents();
					DC_Main.i++;
				}
				Interaction.MsgBox((object)"Data is Import Ok....", (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnAcImport).Visible = true;
	}
}
