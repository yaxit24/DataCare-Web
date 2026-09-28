using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
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
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_CUST_CRM : Form
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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnJmaUdhar")]
	private SimpleButton _BtnJmaUdhar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboValType")]
	private ComboBox _cboValType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCustCode")]
	private TextBox _tCustCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mUpdDate")]
	private MaskedTextBox _mUpdDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItRemark")]
	private TextBox _tItRemark;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkReminderClose")]
	private CheckBox _chkReminderClose;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRemUpdate")]
	private QButton _btnRemUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRemClose")]
	private QButton _btnRemClose;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItmSale")]
	private CheckBox _chkItmSale;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string[] ArySchmCode;

	private string[] AryEmpCode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private DataGridViewButtonColumn btn;

	private const int cSrNoCr = 0;

	private const int cPartyNme = 1;

	private const int cMobileNo = 2;

	private const int cBtnUpdate = 3;

	private const int cRemark = 4;

	private const int cVchDate = 5;

	private const int cNewRemDate = 6;

	private const int cBookType = 7;

	private const int cVchNo = 8;

	private const int cTagNo = 9;

	private const int cItCode = 10;

	private const int cPcs = 11;

	private const int cGrWt = 12;

	private const int cNetWt = 13;

	private const int cFine = 14;

	private const int cTotAmt = 15;

	private const int cRemDate = 16;

	private const int cEmpName = 17;

	private const int cMainRemark = 18;

	private const int cBookCode = 19;

	private const int cMainBook = 20;

	private const int cEmpCode = 21;

	private const int cRemSrNo = 22;

	private const int cCoYear = 23;

	private const int cVchSrNo = 24;

	private const int cItLike = 25;

	private const int cItCart = 26;

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
			EventHandler eventHandler = tAcCode_TextChanged;
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
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			TextBox val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcName = value;
			val2 = _tAcName;
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

	internal virtual DataGridViewX DGV_DETL
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_DETL_CellClick);
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(DGV_DETL_RowEnter);
			DataGridViewX val4 = _DGV_DETL;
			if (val4 != null)
			{
				((DataGridView)val4).CellClick -= val;
				((DataGridView)val4).CellFormatting -= val2;
				((Control)val4).DoubleClick -= eventHandler;
				((DataGridView)val4).RowEnter -= val3;
			}
			_DGV_DETL = value;
			val4 = _DGV_DETL;
			if (val4 != null)
			{
				((DataGridView)val4).CellClick += val;
				((DataGridView)val4).CellFormatting += val2;
				((Control)val4).DoubleClick += eventHandler;
				((DataGridView)val4).RowEnter += val3;
			}
		}
	}

	internal virtual SimpleButton BtnJmaUdhar
	{
		[CompilerGenerated]
		get
		{
			return _BtnJmaUdhar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnJmaUdhar_Click;
			SimpleButton val = _BtnJmaUdhar;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnJmaUdhar = value;
			val = _BtnJmaUdhar;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual ComboBox cboValType
	{
		[CompilerGenerated]
		get
		{
			return _cboValType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboValType_KeyDown);
			ComboBox val2 = _cboValType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboValType = value;
			val2 = _cboValType;
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

	internal virtual TextBox tCustCode
	{
		[CompilerGenerated]
		get
		{
			return _tCustCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCustCode_KeyDown);
			TextBox val2 = _tCustCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCustCode = value;
			val2 = _tCustCode;
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

	internal virtual QButton btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOk_Click;
			QButton val = _btnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOk = value;
			val = _btnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tEmpCode
	{
		[CompilerGenerated]
		get
		{
			return _tEmpCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmpCode_KeyDown);
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpName")]
	private virtual TextBox _tEmpName;

	internal virtual TextBox tEmpName
	{
		get
		{
			return _tEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tEmpName = value;
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
	[AccessedThroughProperty("pnlEdit")]
	private virtual Panel _pnlEdit;

	internal virtual Panel pnlEdit
	{
		get
		{
			return _pnlEdit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlEdit = value;
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
	[AccessedThroughProperty("tVchNo")]
	private virtual TextBox _tVchNo;

	internal virtual TextBox tVchNo
	{
		get
		{
			return _tVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tVchNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mVchDate")]
	private virtual MaskedTextBox _mVchDate;

	internal virtual MaskedTextBox mVchDate
	{
		get
		{
			return _mVchDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mVchDate = value;
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

	internal virtual MaskedTextBox mUpdDate
	{
		[CompilerGenerated]
		get
		{
			return _mUpdDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mUpdDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mUpdDate_KeyDown);
			MaskedTextBox val2 = _mUpdDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mUpdDate = value;
			val2 = _mUpdDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mUpdTime")]
	private virtual TextBox _mUpdTime;

	internal virtual TextBox mUpdTime
	{
		get
		{
			return _mUpdTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mUpdTime = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUpdateEmpCode")]
	private virtual TextBox _tUpdateEmpCode;

	internal virtual TextBox tUpdateEmpCode
	{
		get
		{
			return _tUpdateEmpCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUpdateEmpCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUpdateEmpName")]
	private virtual TextBox _tUpdateEmpName;

	internal virtual TextBox tUpdateEmpName
	{
		get
		{
			return _tUpdateEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tUpdateEmpName = value;
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

	internal virtual TextBox tItRemark
	{
		[CompilerGenerated]
		get
		{
			return _tItRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItRemark_KeyDown);
			TextBox val2 = _tItRemark;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItRemark = value;
			val2 = _tItRemark;
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

	internal virtual CheckBox chkReminderClose
	{
		[CompilerGenerated]
		get
		{
			return _chkReminderClose;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkReminderClose_KeyDown);
			CheckBox val2 = _chkReminderClose;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkReminderClose = value;
			val2 = _chkReminderClose;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual QButton btnRemUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnRemUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRemUpdate_Click;
			QButton val = _btnRemUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRemUpdate = value;
			val = _btnRemUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIsrNo")]
	private virtual TextBox _nIsrNo;

	internal virtual TextBox nIsrNo
	{
		get
		{
			return _nIsrNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nIsrNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSrNo")]
	private virtual TextBox _nSrNo;

	internal virtual TextBox nSrNo
	{
		get
		{
			return _nSrNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nSrNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCoYear")]
	private virtual TextBox _tCoYear;

	internal virtual TextBox tCoYear
	{
		get
		{
			return _tCoYear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCoYear = value;
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
	[AccessedThroughProperty("tRemCustName")]
	private virtual TextBox _tRemCustName;

	internal virtual TextBox tRemCustName
	{
		get
		{
			return _tRemCustName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRemCustName = value;
		}
	}

	internal virtual QButton btnRemClose
	{
		[CompilerGenerated]
		get
		{
			return _btnRemClose;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRemClose_Click;
			QButton val = _btnRemClose;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRemClose = value;
			val = _btnRemClose;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tNewRemark")]
	private virtual TextBox _tNewRemark;

	internal virtual TextBox tNewRemark
	{
		get
		{
			return _tNewRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tNewRemark = value;
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
	[AccessedThroughProperty("PicImage")]
	private virtual PictureBox _PicImage;

	internal virtual PictureBox PicImage
	{
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PicImage = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private virtual DataGridViewX _DGV;

	internal virtual DataGridViewX DGV
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

	internal virtual CheckBox chkItmSale
	{
		[CompilerGenerated]
		get
		{
			return _chkItmSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkItmSale_KeyDown);
			CheckBox val2 = _chkItmSale;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkItmSale = value;
			val2 = _chkItmSale;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMainRemark")]
	private virtual TextBox _tMainRemark;

	internal virtual TextBox tMainRemark
	{
		get
		{
			return _tMainRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMainRemark = value;
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

	public int newindex { get; set; }

	public RP_CUST_CRM()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += RP_CUST_CRM_Load;
		((Form)this).Activated += RP_CUST_CRM_Activated;
		((Form)this).Deactivate += RP_CUST_CRM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_CUST_CRM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_CUST_CRM_KeyDown);
		((Form)this).Closed += RP_CUST_CRM_Closed;
		btn = new DataGridViewButtonColumn();
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
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Expected O, but got Unknown
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected O, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Expected O, but got Unknown
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		//IL_0a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6e: Expected O, but got Unknown
		//IL_0b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Expected O, but got Unknown
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c92: Expected O, but got Unknown
		//IL_0d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d16: Expected O, but got Unknown
		//IL_0d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da0: Expected O, but got Unknown
		//IL_0e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Expected O, but got Unknown
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Expected O, but got Unknown
		//IL_0f95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9f: Expected O, but got Unknown
		//IL_1074: Unknown result type (might be due to invalid IL or missing references)
		//IL_107e: Expected O, but got Unknown
		//IL_10e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f1: Expected O, but got Unknown
		//IL_1183: Unknown result type (might be due to invalid IL or missing references)
		//IL_118d: Expected O, but got Unknown
		//IL_123a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Expected O, but got Unknown
		//IL_12d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e2: Expected O, but got Unknown
		//IL_1391: Unknown result type (might be due to invalid IL or missing references)
		//IL_139b: Expected O, but got Unknown
		//IL_1422: Unknown result type (might be due to invalid IL or missing references)
		//IL_142c: Expected O, but got Unknown
		//IL_14d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e0: Expected O, but got Unknown
		//IL_158d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1597: Expected O, but got Unknown
		//IL_1645: Unknown result type (might be due to invalid IL or missing references)
		//IL_164f: Expected O, but got Unknown
		//IL_16cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d6: Expected O, but got Unknown
		//IL_19b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19da: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a55: Expected O, but got Unknown
		//IL_1a78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af2: Expected O, but got Unknown
		//IL_1b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b76: Expected O, but got Unknown
		//IL_1bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c05: Expected O, but got Unknown
		//IL_1f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f20: Expected O, but got Unknown
		//IL_220c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2230: Unknown result type (might be due to invalid IL or missing references)
		//IL_2254: Unknown result type (might be due to invalid IL or missing references)
		//IL_2278: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ab: Expected O, but got Unknown
		//IL_22d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2345: Unknown result type (might be due to invalid IL or missing references)
		//IL_234f: Expected O, but got Unknown
		//IL_23fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2407: Expected O, but got Unknown
		//IL_2485: Unknown result type (might be due to invalid IL or missing references)
		//IL_248f: Expected O, but got Unknown
		//IL_2538: Unknown result type (might be due to invalid IL or missing references)
		//IL_2542: Expected O, but got Unknown
		//IL_25eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f5: Expected O, but got Unknown
		//IL_28bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2907: Unknown result type (might be due to invalid IL or missing references)
		//IL_292b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2954: Unknown result type (might be due to invalid IL or missing references)
		//IL_295e: Expected O, but got Unknown
		//IL_2981: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fc: Expected O, but got Unknown
		//IL_2abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ac6: Expected O, but got Unknown
		//IL_2b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b6f: Expected O, but got Unknown
		//IL_2c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c27: Expected O, but got Unknown
		//IL_2cb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cc2: Expected O, but got Unknown
		//IL_2d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d53: Expected O, but got Unknown
		//IL_2dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e08: Expected O, but got Unknown
		//IL_2e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e9a: Expected O, but got Unknown
		//IL_2f2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f36: Expected O, but got Unknown
		//IL_2fe1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2feb: Expected O, but got Unknown
		//IL_307f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3089: Expected O, but got Unknown
		//IL_3126: Unknown result type (might be due to invalid IL or missing references)
		//IL_3130: Expected O, but got Unknown
		//IL_31db: Unknown result type (might be due to invalid IL or missing references)
		//IL_31e5: Expected O, but got Unknown
		//IL_3270: Unknown result type (might be due to invalid IL or missing references)
		//IL_327a: Expected O, but got Unknown
		//IL_331c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3326: Expected O, but got Unknown
		//IL_34a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ab: Expected O, but got Unknown
		//IL_3547: Unknown result type (might be due to invalid IL or missing references)
		//IL_3551: Expected O, but got Unknown
		//IL_35d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_35e1: Expected O, but got Unknown
		//IL_36ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d8: Expected O, but got Unknown
		//IL_3741: Unknown result type (might be due to invalid IL or missing references)
		//IL_374b: Expected O, but got Unknown
		//IL_37fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3805: Expected O, but got Unknown
		//IL_38a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_38b1: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_CUST_CRM));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnJmaUdhar = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		Label4 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		cboValType = new ComboBox();
		Label3 = new Label();
		Label1 = new Label();
		Label5 = new Label();
		tCustCode = new TextBox();
		Label6 = new Label();
		btnOk = new QButton();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label7 = new Label();
		pnlEdit = new Panel();
		chkItmSale = new CheckBox();
		btnRemClose = new QButton();
		Label18 = new Label();
		tRemCustName = new TextBox();
		tCoYear = new TextBox();
		nSrNo = new TextBox();
		nIsrNo = new TextBox();
		btnRemUpdate = new QButton();
		chkReminderClose = new CheckBox();
		tItRemark = new TextBox();
		Label11 = new Label();
		mUpdDate = new MaskedTextBox();
		mUpdTime = new TextBox();
		Label10 = new Label();
		tUpdateEmpCode = new TextBox();
		tUpdateEmpName = new TextBox();
		Label9 = new Label();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		Label8 = new Label();
		tVchNo = new TextBox();
		tNewRemark = new TextBox();
		Label12 = new Label();
		PicImage = new PictureBox();
		DGV = new DataGridViewX();
		tMainRemark = new TextBox();
		Label13 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)pnlEdit).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnJmaUdhar);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 14;
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
		((Control)BtnExit).TabIndex = 17;
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
		((Control)BtnDelete).TabIndex = 6;
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
		((Control)BtnCancel).TabIndex = 16;
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
		((Control)BtnSave).TabIndex = 4;
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
		((Control)BtnPrint).TabIndex = 15;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnJmaUdhar.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnJmaUdhar.ImageOptions.SvgImage");
		((Control)BtnJmaUdhar).Location = new Point(730, 3);
		((BaseControl)BtnJmaUdhar).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnJmaUdhar).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnJmaUdhar).Name = "BtnJmaUdhar";
		((Control)BtnJmaUdhar).Size = new Size(91, 37);
		((Control)BtnJmaUdhar).TabIndex = 10;
		BtnJmaUdhar.Text = "&JmUdr";
		((BaseButton)BtnJmaUdhar).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnJmaUdhar).Visible = false;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1247, 476);
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
		lblBook.Text = "Customer Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(251, 46);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(71, 22);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(390, 46);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(250, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(178, 48);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(67, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Ac Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Snow;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val3;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 108);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val5;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 319);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(5, 44);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(71, 20);
		((Control)Label4).TabIndex = 1159;
		Label4.Text = "From Dt";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(82, 75);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(82, 46);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		cboValType.AutoCompleteMode = (AutoCompleteMode)3;
		cboValType.AutoCompleteSource = (AutoCompleteSource)256;
		cboValType.BackColor = Color.White;
		((Control)cboValType).Font = new Font("Tahoma", 9f);
		((ListControl)cboValType).FormattingEnabled = true;
		((Control)cboValType).Location = new Point(745, 46);
		((Control)cboValType).Name = "cboValType";
		((Control)cboValType).Size = new Size(103, 22);
		((Control)cboValType).TabIndex = 6;
		((Control)cboValType).Visible = false;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(658, 46);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(82, 19);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Value Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label3).Visible = false;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(3, 73);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(71, 20);
		((Control)Label1).TabIndex = 1162;
		Label1.Text = "To Date";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(162, 76);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(83, 20);
		((Control)Label5).TabIndex = 1164;
		Label5.Text = "Cust Code";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tCustCode).BackColor = Color.White;
		((Control)tCustCode).Font = new Font("Tahoma", 9f);
		((Control)tCustCode).Location = new Point(251, 76);
		((TextBoxBase)tCustCode).MaxLength = 8;
		((Control)tCustCode).Name = "tCustCode";
		((Control)tCustCode).Size = new Size(71, 22);
		((Control)tCustCode).TabIndex = 3;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(329, 50);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(55, 20);
		((Control)Label6).TabIndex = 1165;
		Label6.Text = "Party";
		Label6.TextAlign = (ContentAlignment)64;
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(1041, 48);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(103, 37);
		((Control)btnOk).TabIndex = 7;
		btnOk.Text = "&Ok";
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(391, 76);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(58, 22);
		((Control)tEmpCode).TabIndex = 5;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(455, 76);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(185, 22);
		((Control)tEmpName).TabIndex = 1168;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(329, 78);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(50, 20);
		((Control)Label7).TabIndex = 1167;
		Label7.Text = "Emp";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)pnlEdit).BackColor = SystemColors.ButtonFace;
		pnlEdit.BorderStyle = (BorderStyle)1;
		((Control)pnlEdit).Controls.Add((Control)(object)chkItmSale);
		((Control)pnlEdit).Controls.Add((Control)(object)btnRemClose);
		((Control)pnlEdit).Controls.Add((Control)(object)Label18);
		((Control)pnlEdit).Controls.Add((Control)(object)tRemCustName);
		((Control)pnlEdit).Controls.Add((Control)(object)tCoYear);
		((Control)pnlEdit).Controls.Add((Control)(object)nSrNo);
		((Control)pnlEdit).Controls.Add((Control)(object)nIsrNo);
		((Control)pnlEdit).Controls.Add((Control)(object)btnRemUpdate);
		((Control)pnlEdit).Controls.Add((Control)(object)chkReminderClose);
		((Control)pnlEdit).Controls.Add((Control)(object)tItRemark);
		((Control)pnlEdit).Controls.Add((Control)(object)Label11);
		((Control)pnlEdit).Controls.Add((Control)(object)mUpdDate);
		((Control)pnlEdit).Controls.Add((Control)(object)mUpdTime);
		((Control)pnlEdit).Controls.Add((Control)(object)Label10);
		((Control)pnlEdit).Controls.Add((Control)(object)tUpdateEmpCode);
		((Control)pnlEdit).Controls.Add((Control)(object)tUpdateEmpName);
		((Control)pnlEdit).Controls.Add((Control)(object)Label9);
		((Control)pnlEdit).Controls.Add((Control)(object)mVchDate);
		((Control)pnlEdit).Controls.Add((Control)(object)lblBDate);
		((Control)pnlEdit).Controls.Add((Control)(object)Label8);
		((Control)pnlEdit).Controls.Add((Control)(object)tVchNo);
		((Control)pnlEdit).Location = new Point(640, 108);
		((Control)pnlEdit).Name = "pnlEdit";
		((Control)pnlEdit).Size = new Size(532, 317);
		((Control)pnlEdit).TabIndex = 1169;
		((Control)pnlEdit).Visible = false;
		((ButtonBase)chkItmSale).BackColor = Color.Transparent;
		((Control)chkItmSale).Font = new Font("Arial", 9.75f);
		((Control)chkItmSale).ForeColor = Color.Black;
		((ButtonBase)chkItmSale).ImeMode = (ImeMode)0;
		((Control)chkItmSale).Location = new Point(114, 224);
		((Control)chkItmSale).Name = "chkItmSale";
		((Control)chkItmSale).RightToLeft = (RightToLeft)0;
		((Control)chkItmSale).Size = new Size(137, 27);
		((Control)chkItmSale).TabIndex = 10;
		((ButtonBase)chkItmSale).Text = "Item Sale";
		((ButtonBase)chkItmSale).UseVisualStyleBackColor = false;
		((QControl)btnRemClose).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnRemClose).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRemClose).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnRemClose).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnRemClose).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRemClose).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRemClose).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRemClose).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnRemClose).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)btnRemClose).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnRemClose).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnRemClose).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRemClose).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRemClose).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)btnRemClose).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnRemClose).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnRemClose.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemClose.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemClose.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemClose.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemClose.Image = null;
		((QControl)btnRemClose).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnRemClose).Location = new Point(247, 260);
		((Control)btnRemClose).Margin = new Padding(3, 6, 3, 6);
		((Control)btnRemClose).Name = "btnRemClose";
		((Control)btnRemClose).Size = new Size(103, 37);
		((Control)btnRemClose).TabIndex = 13;
		btnRemClose.Text = "&Close";
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(25, 83);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(81, 20);
		((Control)Label18).TabIndex = 1180;
		Label18.Text = "Cust Name";
		Label18.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tRemCustName).BackColor = Color.White;
		((Control)tRemCustName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRemCustName).Location = new Point(114, 82);
		((TextBoxBase)tRemCustName).MaxLength = 8;
		((Control)tRemCustName).Name = "tRemCustName";
		((Control)tRemCustName).Size = new Size(345, 23);
		((Control)tRemCustName).TabIndex = 1179;
		((TextBoxBase)tCoYear).BackColor = Color.White;
		((Control)tCoYear).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tCoYear).Location = new Point(374, 24);
		((TextBoxBase)tCoYear).MaxLength = 8;
		((Control)tCoYear).Name = "tCoYear";
		((TextBoxBase)tCoYear).ReadOnly = true;
		((Control)tCoYear).Size = new Size(85, 22);
		((Control)tCoYear).TabIndex = 1175;
		tCoYear.TextAlign = (HorizontalAlignment)2;
		((Control)nSrNo).AccessibleName = "nSrNo";
		((TextBoxBase)nSrNo).BackColor = Color.White;
		((Control)nSrNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)nSrNo).Location = new Point(277, 112);
		((TextBoxBase)nSrNo).MaxLength = 8;
		((Control)nSrNo).Name = "nSrNo";
		((TextBoxBase)nSrNo).ReadOnly = true;
		((Control)nSrNo).Size = new Size(49, 22);
		((Control)nSrNo).TabIndex = 1174;
		nSrNo.TextAlign = (HorizontalAlignment)2;
		((Control)nIsrNo).AccessibleName = "nSrNo";
		((TextBoxBase)nIsrNo).BackColor = Color.White;
		((Control)nIsrNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)nIsrNo).Location = new Point(332, 112);
		((TextBoxBase)nIsrNo).MaxLength = 8;
		((Control)nIsrNo).Name = "nIsrNo";
		((TextBoxBase)nIsrNo).ReadOnly = true;
		((Control)nIsrNo).Size = new Size(49, 22);
		((Control)nIsrNo).TabIndex = 1173;
		nIsrNo.TextAlign = (HorizontalAlignment)2;
		((QControl)btnRemUpdate).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnRemUpdate).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnRemUpdate).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnRemUpdate).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnRemUpdate).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnRemUpdate).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnRemUpdate).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRemUpdate).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)btnRemUpdate).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnRemUpdate).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnRemUpdate.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemUpdate.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemUpdate.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemUpdate.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRemUpdate.Image = null;
		((QControl)btnRemUpdate).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnRemUpdate).Location = new Point(114, 260);
		((Control)btnRemUpdate).Margin = new Padding(3, 6, 3, 6);
		((Control)btnRemUpdate).Name = "btnRemUpdate";
		((Control)btnRemUpdate).Size = new Size(103, 37);
		((Control)btnRemUpdate).TabIndex = 12;
		btnRemUpdate.Text = "&Update";
		((ButtonBase)chkReminderClose).BackColor = Color.Transparent;
		((Control)chkReminderClose).Font = new Font("Arial", 9.75f);
		((Control)chkReminderClose).ForeColor = Color.Black;
		((ButtonBase)chkReminderClose).ImeMode = (ImeMode)0;
		((Control)chkReminderClose).Location = new Point(273, 224);
		((Control)chkReminderClose).Name = "chkReminderClose";
		((Control)chkReminderClose).RightToLeft = (RightToLeft)0;
		((Control)chkReminderClose).Size = new Size(137, 27);
		((Control)chkReminderClose).TabIndex = 11;
		((ButtonBase)chkReminderClose).Text = "Remainder Close";
		((ButtonBase)chkReminderClose).UseVisualStyleBackColor = false;
		((TextBoxBase)tItRemark).BackColor = Color.White;
		((Control)tItRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItRemark).Location = new Point(115, 142);
		((TextBoxBase)tItRemark).MaxLength = 150;
		tItRemark.Multiline = true;
		((Control)tItRemark).Name = "tItRemark";
		tItRemark.ScrollBars = (ScrollBars)2;
		((Control)tItRemark).Size = new Size(392, 69);
		((Control)tItRemark).TabIndex = 9;
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(28, 140);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(72, 20);
		((Control)Label11).TabIndex = 1170;
		Label11.Text = "Remark";
		Label11.TextAlign = (ContentAlignment)16;
		((TextBoxBase)mUpdDate).BackColor = Color.White;
		((Control)mUpdDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mUpdDate).Location = new Point(115, 112);
		mUpdDate.Mask = "00/00/0000";
		((Control)mUpdDate).Name = "mUpdDate";
		((Control)mUpdDate).Size = new Size(76, 22);
		((Control)mUpdDate).TabIndex = 8;
		mUpdDate.ValidatingType = typeof(DateTime);
		((TextBoxBase)mUpdTime).BackColor = Color.White;
		((Control)mUpdTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mUpdTime).Location = new Point(196, 112);
		((TextBoxBase)mUpdTime).MaxLength = 8;
		((Control)mUpdTime).Name = "mUpdTime";
		((TextBoxBase)mUpdTime).ReadOnly = true;
		((Control)mUpdTime).Size = new Size(75, 22);
		((Control)mUpdTime).TabIndex = 1168;
		mUpdTime.TextAlign = (HorizontalAlignment)2;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(25, 113);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(101, 20);
		((Control)Label10).TabIndex = 1167;
		Label10.Text = "Rem Date";
		Label10.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tUpdateEmpCode).BackColor = Color.White;
		((Control)tUpdateEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tUpdateEmpCode).Location = new Point(114, 54);
		((TextBoxBase)tUpdateEmpCode).MaxLength = 3;
		((Control)tUpdateEmpCode).Name = "tUpdateEmpCode";
		((TextBoxBase)tUpdateEmpCode).ReadOnly = true;
		((Control)tUpdateEmpCode).Size = new Size(76, 22);
		((Control)tUpdateEmpCode).TabIndex = 1163;
		((TextBoxBase)tUpdateEmpName).BackColor = Color.White;
		((Control)tUpdateEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tUpdateEmpName).Location = new Point(196, 54);
		((TextBoxBase)tUpdateEmpName).MaxLength = 50;
		((Control)tUpdateEmpName).Name = "tUpdateEmpName";
		((TextBoxBase)tUpdateEmpName).ReadOnly = true;
		((Control)tUpdateEmpName).Size = new Size(263, 22);
		((Control)tUpdateEmpName).TabIndex = 1165;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(26, 54);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(69, 20);
		((Control)Label9).TabIndex = 1164;
		Label9.Text = "Employee";
		Label9.TextAlign = (ContentAlignment)16;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(273, 26);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		mVchDate.ReadOnly = true;
		((Control)mVchDate).Size = new Size(77, 22);
		((Control)mVchDate).TabIndex = 1133;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(203, 27);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1134;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(26, 26);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(68, 20);
		((Control)Label8).TabIndex = 1127;
		Label8.Text = "Vch No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(114, 25);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 1126;
		((TextBoxBase)tNewRemark).BackColor = Color.White;
		((Control)tNewRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tNewRemark).Location = new Point(82, 507);
		((TextBoxBase)tNewRemark).MaxLength = 150;
		tNewRemark.Multiline = true;
		((Control)tNewRemark).Name = "tNewRemark";
		tNewRemark.ScrollBars = (ScrollBars)2;
		((Control)tNewRemark).Size = new Size(302, 49);
		((Control)tNewRemark).TabIndex = 1171;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(16, 504);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(60, 20);
		((Control)Label12).TabIndex = 1172;
		Label12.Text = "Remark";
		Label12.TextAlign = (ContentAlignment)16;
		((Control)PicImage).BackColor = Color.LavenderBlush;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.Image = (Image)(object)Resources.longset;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(398, 439);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(159, 117);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1173;
		PicImage.TabStop = false;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val8;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(570, 440);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val10;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV).ScrollBars = (ScrollBars)2;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(602, 116);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1235;
		((TextBoxBase)tMainRemark).BackColor = Color.White;
		((Control)tMainRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMainRemark).Location = new Point(82, 438);
		((TextBoxBase)tMainRemark).MaxLength = 150;
		tMainRemark.Multiline = true;
		((Control)tMainRemark).Name = "tMainRemark";
		tMainRemark.ScrollBars = (ScrollBars)2;
		((Control)tMainRemark).Size = new Size(302, 59);
		((Control)tMainRemark).TabIndex = 1236;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(14, 439);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(60, 48);
		((Control)Label13).TabIndex = 1237;
		Label13.Text = "Main Remark";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)tMainRemark);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)tNewRemark);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)pnlEdit);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)btnOk);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tCustCode);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)cboValType);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_CUST_CRM";
		((Form)this).Text = "Customer Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)pnlEdit).ResumeLayout(false);
		((Control)pnlEdit).PerformLayout();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnRemUpdate_Click(object sender, EventArgs e)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(tCoYear.Text, "", false) == 0) | (Operators.CompareString(tVchNo.Text, "", false) == 0) | (Operators.CompareString(nSrNo.Text, "", false) == 0) | (Operators.CompareString(tUpdateEmpCode.Text, "", false) == 0) | (Operators.CompareString(nIsrNo.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Check Update Detail ... Because Entry Is Not Proper....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.ExeQuteCrm(("DELETE FROM CUST_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tCoYear.Text + "' AND  CO_BOOK = '" + tUpdateEmpCode.Text + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(nSrNo.Text)) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(nIsrNo.Text))) ?? "");
		DC_Main.RsQry = ("SELECT * FROM CUST_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tCoYear.Text + "' AND  CO_BOOK = '" + tUpdateEmpCode.Text + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(nSrNo.Text)) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(nIsrNo.Text))) ?? "";
		DataTable dataTable = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = dataTable.NewRow();
		dataRow["CO_CODE"] = DC_Main.MCo_code;
		dataRow["LC_CODE"] = DC_Main.MLc_code;
		dataRow["CO_YEAR"] = tCoYear.Text;
		dataRow["CO_BOOK"] = tUpdateEmpCode.Text;
		dataRow["EMP_CODE"] = tUpdateEmpCode.Text;
		dataRow["VCH_NO"] = tVchNo.Text;
		dataRow["SR_NO"] = Conversion.Val(nSrNo.Text);
		dataRow["ISR_NO"] = Conversion.Val(nIsrNo.Text);
		dataRow["REM_DATE"] = mUpdDate.Text;
		dataRow["REM_TIME"] = mUpdDate.Text + " " + mUpdTime.Text;
		dataRow["ITM_REMARK"] = tItRemark.Text;
		dataRow["MAIN_USER"] = MainUser;
		dataTable.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
		dataTable.Clear();
		tUpdateEmpCode.Text = "";
		tUpdateEmpCode.Text = "";
		tVchNo.Text = "";
		nSrNo.Text = "";
		nIsrNo.Text = "";
		tRemCustName.Text = "";
		tItRemark.Text = "";
		Interaction.MsgBox((object)"Record Is Update...", (MsgBoxStyle)0, (object)null);
		((Control)pnlEdit).Visible = false;
	}

	private void DGV_DETL_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
		if (e.ColumnIndex != 3)
		{
			return;
		}
		if (!((Control)pnlEdit).Visible)
		{
			tVchNo.Text = Conversions.ToString(((DataGridView)DGV_DETL)[8, index].Value);
			nSrNo.Text = Conversions.ToString(((DataGridView)DGV_DETL)[22, index].Value);
			mVchDate.Text = Conversions.ToString(((DataGridView)DGV_DETL)[5, index].Value);
			tUpdateEmpCode.Text = Conversions.ToString(((DataGridView)DGV_DETL)[21, index].Value);
			tUpdateEmpName.Text = Conversions.ToString(((DataGridView)DGV_DETL)[17, index].Value);
			tRemCustName.Text = Conversions.ToString(((DataGridView)DGV_DETL)[1, index].Value);
			mUpdDate.Text = Strings.Format((object)DC_Main.MsSysDate.AddDays(1.0), "dd/MM/yyyy");
			mUpdTime.Text = Strings.Format((object)DateAndTime.Now, "HH:mm");
			tCoYear.Text = Conversions.ToString(((DataGridView)DGV_DETL)[23, index].Value);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM CUST_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), ((DataGridView)DGV_DETL)[23, index].Value), (object)"' AND  CO_BOOK = '"), (object)tUpdateEmpCode.Text), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND SR_NO = "), ((DataGridView)DGV_DETL)[22, index].Value), (object)" ORDER BY ISR_NO DESC"));
			DC_Main.Tbl = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				nIsrNo.Text = Conversions.ToString(2);
			}
			else
			{
				nIsrNo.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ISR_NO"])) + 1.0);
			}
			((Control)pnlEdit).Visible = true;
			((Control)mUpdDate).Focus();
		}
		else
		{
			((Control)pnlEdit).Visible = false;
		}
	}

	private void mUpdDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mUpdDate).SelectionStart = 0;
		((TextBoxBase)mUpdDate).SelectionLength = Strings.Len(mUpdDate.Text);
	}

	private void mUpdDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mUpdDate;
			DC_Main.SetDate(ref MsDate);
			mUpdDate = MsDate;
			if (!DC_Main.RongDate)
			{
				((Control)tItRemark).Focus();
			}
		}
	}

	private void DGV_ITM_FILL()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "Party Name");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "Mobile");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add((DataGridViewColumn)(object)btn);
			((DataGridViewColumn)btn).HeaderText = "Update";
			((DataGridViewColumn)btn).Width = (int)Math.Round(80.0 * ColCon);
			btn.Text = "Update";
			((DataGridViewColumn)btn).Name = "btn";
			btn.UseColumnTextForButtonValue = true;
			((DataGridView)DGV_DETL).Columns.Add("", "Remark");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "NewDate");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[7].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "TagNo");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N";
			((DataGridView)DGV_DETL).Columns.Add("", "GrWt");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Fine");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "TotAmt");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "RemDate");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Emp Name");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Main Remark");
			((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "EmpCode");
			((DataGridView)DGV_DETL).Columns[21].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "VchSrNo");
			((DataGridView)DGV_DETL).Columns[22].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "CoYear");
			((DataGridView)DGV_DETL).Columns[23].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "TagId");
			((DataGridView)DGV_DETL).Columns[24].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "ItLike");
			((DataGridView)DGV_DETL).Columns[25].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "ItCart");
			((DataGridView)DGV_DETL).Columns[26].Visible = false;
			double num = 0.0;
			double num2 = 0.0;
			DC_Main.RsQry = "SELECT A.* FROM (CUST_DATA AS A LEFT JOIN CUST_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO AND A.SR_NO = C.SR_NO)  LEFT JOIN " + DC_Main.SqlData + ".dbo.AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + DC_Main.MLc_code + "'  And (C.REM_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' And C.REM_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "') ";
			if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "And A.EMP_CODE = '" + tEmpCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tCustCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE = '" + tCustCode.Text + "'";
			}
			if (Operators.CompareString(tAcName.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_NAME = '" + tAcName.Text + "'";
			}
			DC_Main.RsQry += "ORDER BY REM_DATE,A.EMP_CODE,A.AC_NAME";
			DataTable dataTable = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
			int num3 = 0;
			if (dataTable.Rows.Count <= 0)
			{
				return;
			}
			int num4 = dataTable.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num4)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, num3].Value = num3 + 1;
				((DataGridView)dGV_DETL)[5, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["VCH_DATE"], (object)"");
				((DataGridView)dGV_DETL)[7, num3].Value = "";
				((DataGridView)dGV_DETL)[8, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["VCH_NO"], (object)"");
				((DataGridView)dGV_DETL)[1, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_NAME"], (object)"");
				((DataGridView)dGV_DETL)[2, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["MOBILE_NO"], (object)"");
				((DataGridView)dGV_DETL)[4, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ITM_REMARK"], (object)"");
				((DataGridView)dGV_DETL)[16, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["REM_DATE"], (object)"");
				((DataGridView)dGV_DETL)[17, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["EMP_NAME"], (object)"");
				((DataGridView)dGV_DETL)[11, num3].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ITM_PCS"]));
				((DataGridView)dGV_DETL)[12, num3].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ITM_GWT"]));
				((DataGridView)dGV_DETL)[13, num3].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ITM_NWT"]));
				((DataGridView)dGV_DETL)[14, num3].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ITM_FINE"]));
				((DataGridView)dGV_DETL)[15, num3].Value = 0;
				((DataGridView)dGV_DETL)[19, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["EMP_CODE"], (object)"");
				((DataGridView)dGV_DETL)[20, num3].Value = "";
				((DataGridView)dGV_DETL)[21, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["EMP_CODE"], (object)"");
				((DataGridView)dGV_DETL)[22, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["SR_NO"], (object)"");
				((DataGridView)dGV_DETL)[23, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["CO_YEAR"], (object)"");
				((DataGridView)dGV_DETL)[10, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["IT_CODE"], (object)"");
				((DataGridView)dGV_DETL)[9, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["TAG_NO"], (object)"");
				((DataGridView)dGV_DETL)[24, num3].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["VCH_SRNO"]));
				((DataGridView)dGV_DETL)[18, num3].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ITM_REMARK"], (object)"");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TOP 1 B.REM_DATE,B.ITM_REMARK,B.ITM_SALE,B.REM_CLOSE FROM CUST_DATA AS A LEFT JOIN CUST_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE  AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO AND A.SR_NO = B.SR_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '"), ((DataGridView)DGV_DETL)[23, num3].Value), (object)"' AND A.CO_BOOK = '"), ((DataGridView)DGV_DETL)[19, num3].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)DGV_DETL)[8, num3].Value), (object)"' AND B.SR_NO = "), ((DataGridView)DGV_DETL)[22, num3].Value), (object)" AND B.ISR_NO <> 1 ORDER BY B.ISR_NO DESC "));
				DC_Main.Tbl = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					((DataGridView)dGV_DETL)[4, num3].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ITM_REMARK"], (object)"");
					((DataGridView)dGV_DETL)[6, num3].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["REM_DATE"], (object)"");
				}
				num = Conversions.ToDouble(((DataGridView)dGV_DETL)[12, num3].Value);
				num2 = Conversions.ToDouble(((DataGridView)dGV_DETL)[13, num3].Value);
				num3++;
				dGV_DETL = null;
				DC_Main.i++;
			}
		}
	}

	private void DGV_DETL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
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
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 11) <= 4u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 104:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009e;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 104;
				continue;
			}
			break;
			IL_009e:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		object obj = default(object);
		int num6 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num9 = default(int);
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
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 1455:
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
								goto IL_001e;
							case 4:
							case 5:
								goto IL_0034;
							case 6:
								goto IL_004b;
							case 7:
								goto IL_007d;
							case 8:
								goto IL_00a5;
							case 9:
								goto IL_00ae;
							case 10:
								goto IL_00d6;
							case 11:
								goto IL_0109;
							case 12:
								goto IL_0120;
							case 13:
								goto IL_0168;
							case 14:
								goto IL_0177;
							case 15:
								goto IL_0194;
							case 16:
								goto IL_01ae;
							case 17:
								goto IL_01d1;
							case 18:
							case 19:
								goto IL_0226;
							case 20:
								goto IL_0238;
							case 21:
								goto IL_0253;
							case 22:
								goto IL_025d;
							case 23:
								goto IL_02b0;
							case 24:
								goto IL_0305;
							case 25:
								goto IL_035d;
							case 26:
								goto IL_03cb;
							case 27:
								goto IL_040e;
							case 28:
								goto IL_043d;
							case 29:
								goto IL_0480;
							case 30:
								goto IL_04c1;
							case 31:
								goto IL_04e2;
							case 32:
								goto IL_04f0;
							case 33:
								goto IL_04f6;
							case 34:
								goto IL_04fc;
							case 35:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 36:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0226:
						num2 = 19;
						num5++;
						goto IL_022f;
						IL_0120:
						num2 = 12;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_DETL).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_01d1:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_DETL)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0226;
						IL_0168:
						num2 = 13;
						num6++;
						goto IL_0171;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						obj2 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
						goto IL_004b;
						IL_004b:
						num2 = 6;
						obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
						goto IL_007d;
						IL_007d:
						num2 = 7;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00a5;
						IL_00a5:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00ae;
						IL_00ae:
						num2 = 9;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00d6;
						IL_00d6:
						num2 = 10;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_0109;
						IL_0109:
						num2 = 11;
						num7 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num6 = 0;
						goto IL_0171;
						IL_0171:
						if (num6 <= num7)
						{
							goto IL_0120;
						}
						goto IL_0177;
						IL_0177:
						num2 = 14;
						num8 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0247;
						IL_0247:
						if (DC_Main.i <= num8)
						{
							goto IL_0194;
						}
						goto IL_0253;
						IL_0253:
						num2 = 21;
						colorConverter = new ColorConverter();
						goto IL_025d;
						IL_025d:
						num2 = 22;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_02b0;
						IL_02b0:
						num2 = 23;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0305;
						IL_0305:
						num2 = 24;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_035d;
						IL_035d:
						num2 = 25;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_03cb;
						IL_03cb:
						num2 = 26;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_040e;
						IL_040e:
						num2 = 27;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_043d;
						IL_043d:
						num2 = 28;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0480;
						IL_0480:
						num2 = 29;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_04c1;
						IL_04c1:
						num2 = 30;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_04e2;
						IL_04e2:
						num2 = 31;
						Cursor.Current = Cursors.Default;
						goto IL_04f0;
						IL_04f0:
						num2 = 32;
						obj = null;
						goto IL_04f6;
						IL_04f6:
						num2 = 33;
						obj3 = null;
						goto IL_04fc;
						IL_04fc:
						num2 = 34;
						obj2 = null;
						break;
						IL_0194:
						num2 = 15;
						num9 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num5 = 0;
						goto IL_022f;
						IL_022f:
						if (num5 <= num9)
						{
							goto IL_01ae;
						}
						goto IL_0238;
						IL_0238:
						num2 = 20;
						DC_Main.i++;
						goto IL_0247;
						IL_01ae:
						num2 = 16;
						if (((DataGridView)DGV_DETL)[num5, DC_Main.i].Value != null)
						{
							goto IL_01d1;
						}
						goto IL_0226;
						end_IL_0001_2:
						break;
					}
					num2 = 35;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1455;
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

	private void RP_CUST_CRM_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
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
			foreach (object control3 in ((Control)pnlEdit).Controls)
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
				DataGridViewX dGV_DETL = DGV_DETL;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj10 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj12 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj13 = lblBook;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj13).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj16 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj17 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			cboValType.Items.Add((object)"");
			cboValType.Items.Add((object)"Amount");
			cboValType.Items.Add((object)"Fine");
			cboValType.Items.Add((object)"Silver");
			cboValType.SelectedIndex = 0;
			CLEAR_DATA();
			DGV_ITM_FILL();
			CurActCtrl = (Control)(object)mFromDt;
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
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)mFromDt).Focus();
	}

	private void RP_CUST_CRM_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_CUST_CRM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_CUST_CRM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_CUST_CRM_KeyDown(object sender, KeyEventArgs e)
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
		double num = 0.0;
		DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedger.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Ledr Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
		Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num, "0.00")) ?? "";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_CUST_CRM_Closed(object sender, EventArgs e)
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

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
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
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
					DGV_ITM_FILL();
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_ITM_FILL();
			((Control)tAcName).Focus();
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
	}

	private void BtnJmaUdhar_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr[(short)7] = "";
		double num = 0.0;
		double num2 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdAmt.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
		Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";
		Cr[(short)4] = ("ClBal = " + Strings.Format((object)num2, "0.00")) ?? "";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
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

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboEmp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
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

	private void cboValType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Stock Ledger", false) == 0)
			{
				DGV_ITM_FILL();
			}
			else if (Operators.CompareString(CurRpt, "Party InOut", false) == 0)
			{
				DGV_ITM_FILL();
			}
		}
	}

	private void tCustCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tCustCode.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tCustCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM ADD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
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
					tCustCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
					DGV_ITM_FILL();
				}
				((Control)tCustCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_ITM_FILL();
			((Control)tAcName).Focus();
		}
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tAcName.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select AC_NAME From CUST_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + tAcName.Text + "' AND AC_CODE = '' AND CUST_CODE = ''";
		DC_Main.Tbl = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL FROM CUST_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '' AND CUST_CODE = '' GROUP BY AC_NAME ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
			DC_Main.ColWidth = new double[2];
			DC_Main.ColWidth[0] = 350.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcName.Text = DC_Main.ColValue[0];
					DGV_ITM_FILL();
				}
				((Control)tAcName).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_ITM_FILL();
			((Control)tAcName).Focus();
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		DGV_ITM_FILL();
	}

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND EMP_CODE = '" + tEmpCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT EMP_NAME As EmpNameL,EMP_CODE As EmpL FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tEmpCode.Text = DC_Main.ColValue[1];
					tEmpName.Text = DC_Main.ColValue[0];
				}
				else
				{
					tEmpName.Text = "";
				}
				((Control)tEmpCode).Focus();
			}
		}
		else
		{
			tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
			DGV_ITM_FILL();
		}
	}

	private void tItRemark_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)chkItmSale).Focus();
		}
	}

	private void chkReminderClose_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btnRemUpdate).Focus();
		}
	}

	private void BtnRemClose_Click(object sender, EventArgs e)
	{
		tUpdateEmpCode.Text = "";
		tUpdateEmpCode.Text = "";
		tVchNo.Text = "";
		nSrNo.Text = "";
		nIsrNo.Text = "";
		tRemCustName.Text = "";
		tItRemark.Text = "";
		((Control)pnlEdit).Visible = false;
	}

	private void DGV_DETL_RowEnter(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		Dgv_fill(rowIndex);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Dgv_fill(int R)
	{
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Expected O, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		Image image = default(Image);
		DataTable dataTable = default(DataTable);
		object obj = default(object);
		byte[] bA = default(byte[]);
		object objectValue = default(object);
		string text = default(string);
		HttpWebRequest httpWebRequest = default(HttpWebRequest);
		DataView dataView = default(DataView);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					WebResponse response;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						PicImage.Image = null;
						goto IL_0011;
					case 2521:
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
								goto IL_0011;
							case 3:
								goto IL_0052;
							case 4:
								goto IL_005e;
							case 5:
								goto IL_00a0;
							case 6:
								goto IL_00af;
							case 7:
								goto IL_00d1;
							case 8:
								goto IL_00f8;
							case 10:
								goto IL_010f;
							case 11:
								goto IL_0139;
							case 12:
								goto IL_019e;
							case 13:
								goto IL_01ac;
							case 14:
								goto IL_01c6;
							case 15:
								goto IL_01fa;
							case 17:
								goto IL_020f;
							case 18:
								goto IL_0234;
							case 19:
								goto IL_0245;
							case 20:
								goto IL_0256;
							case 22:
								goto IL_0273;
							case 23:
								goto IL_0292;
							case 24:
								goto IL_029b;
							case 25:
								goto IL_02b7;
							case 27:
								goto IL_02fb;
							case 26:
							case 28:
							case 29:
								goto IL_0315;
							case 30:
								goto IL_0326;
							case 31:
								goto IL_0332;
							case 9:
							case 21:
							case 32:
							case 33:
							case 34:
							case 35:
							case 36:
								goto IL_035d;
							case 37:
								goto IL_0383;
							case 38:
								goto IL_03aa;
							case 39:
								goto IL_03d3;
							case 40:
								goto IL_049a;
							case 41:
								goto IL_04ac;
							case 42:
								goto IL_04bb;
							case 43:
								goto IL_04d1;
							case 44:
								goto IL_04e1;
							case 45:
								goto IL_04f1;
							case 46:
								goto IL_0515;
							case 47:
								goto IL_0534;
							case 48:
								goto IL_055c;
							case 49:
								goto IL_0584;
							case 50:
								goto IL_05ac;
							case 51:
							case 52:
								goto IL_05c7;
							case 53:
								goto IL_05d7;
							case 54:
								goto IL_0607;
							case 55:
								goto IL_0626;
							case 56:
								goto IL_0645;
							case 57:
								goto IL_0675;
							case 58:
								goto IL_0694;
							case 59:
								goto IL_06b3;
							case 60:
								goto IL_06e3;
							case 61:
								goto IL_0702;
							case 62:
								goto IL_0721;
							case 63:
								goto IL_0751;
							case 64:
								goto IL_0770;
							case 65:
								goto IL_078f;
							case 66:
								goto IL_07b0;
							case 67:
								goto IL_07e0;
							case 68:
								goto IL_07ff;
							case 69:
								goto IL_081e;
							case 70:
								goto IL_083f;
							case 71:
								goto IL_0858;
							case 72:
							case 73:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 16:
							case 74:
							case 75:
							case 76:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_081e:
						num2 = 69;
						((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
						goto IL_083f;
						IL_083f:
						num2 = 70;
						if (!(DC_Main.ScreenHight > 1.0))
						{
							break;
						}
						goto IL_0858;
						IL_07ff:
						num2 = 68;
						((DataGridView)DGV).Columns[4].DataPropertyName = "REM_CLOSE";
						goto IL_081e;
						IL_0858:
						num2 = 71;
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
						break;
						IL_0011:
						num2 = 2;
						DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[9, R].Value, (object)"_"), ((DataGridView)DGV_DETL)[24, R].Value));
						goto IL_0052;
						IL_0052:
						num2 = 3;
						DC_Main.MsImageType = "TagImage";
						goto IL_005e;
						IL_005e:
						num2 = 4;
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						goto IL_00a0;
						IL_00a0:
						num2 = 5;
						PicImage.Image = null;
						goto IL_00af;
						IL_00af:
						num2 = 6;
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							goto IL_00d1;
						}
						goto IL_010f;
						IL_00d1:
						num2 = 7;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						goto IL_00f8;
						IL_00f8:
						num2 = 8;
						PicImage.Image = image;
						goto IL_035d;
						IL_010f:
						num2 = 10;
						if (Operators.ConditionalCompareObjectNotEqual(((DataGridView)DGV_DETL)[9, R].Value, (object)"", false))
						{
							goto IL_0139;
						}
						goto IL_035d;
						IL_0139:
						num2 = 11;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[9, R].Value), (object)"' AND VCH_SRNO = "), ((DataGridView)DGV_DETL)[24, R].Value), (object)""));
						goto IL_019e;
						IL_019e:
						num2 = 12;
						dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						goto IL_01ac;
						IL_01ac:
						num2 = 13;
						if (dataTable.Rows.Count > 0)
						{
							goto IL_01c6;
						}
						goto IL_0273;
						IL_01c6:
						num2 = 14;
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
						{
							goto IL_01fa;
						}
						goto IL_020f;
						IL_01fa:
						num2 = 15;
						PicImage.Image = null;
						goto end_IL_0001_3;
						IL_020f:
						num2 = 17;
						obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
						goto IL_0234;
						IL_0234:
						num2 = 18;
						bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
						goto IL_0245;
						IL_0245:
						num2 = 19;
						objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
						goto IL_0256;
						IL_0256:
						num2 = 20;
						PicImage.Image = (Image)objectValue;
						goto IL_035d;
						IL_0273:
						num2 = 22;
						if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
						{
							goto IL_0292;
						}
						goto IL_035d;
						IL_0292:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_029b;
						IL_029b:
						num2 = 24;
						if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
						{
							goto IL_02b7;
						}
						goto IL_02fb;
						IL_02b7:
						num2 = 25;
						text = DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
						goto IL_0315;
						IL_02fb:
						num2 = 27;
						text = DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg";
						goto IL_0315;
						IL_0315:
						num2 = 29;
						httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
						goto IL_0326;
						IL_0326:
						num2 = 30;
						response = httpWebRequest.GetResponse();
						goto IL_0332;
						IL_0332:
						num2 = 31;
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(text)));
						goto IL_035d;
						IL_035d:
						num2 = 36;
						tNewRemark.Text = Conversions.ToString(((DataGridView)DGV_DETL)[4, R].Value);
						goto IL_0383;
						IL_0383:
						num2 = 37;
						tMainRemark.Text = Conversions.ToString(((DataGridView)DGV_DETL)[18, R].Value);
						goto IL_03aa;
						IL_03aa:
						num2 = 38;
						if (!Operators.ConditionalCompareObjectNotEqual(((DataGridView)DGV_DETL)[8, R].Value, (object)"", false))
						{
							goto end_IL_0001_3;
						}
						goto IL_03d3;
						IL_03d3:
						num2 = 39;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY B.ISR_NO) AS SrNo,B.REM_DATE,B.ITM_REMARK,B.ITM_SALE,B.REM_CLOSE FROM CUST_DATA AS A LEFT JOIN CUST_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE  AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO AND A.SR_NO = B.SR_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '"), ((DataGridView)DGV_DETL)[23, R].Value), (object)"' AND A.CO_BOOK = '"), ((DataGridView)DGV_DETL)[19, R].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)DGV_DETL)[8, R].Value), (object)"' AND B.SR_NO = "), ((DataGridView)DGV_DETL)[22, R].Value), (object)" ORDER BY B.ISR_NO "));
						goto IL_049a;
						IL_049a:
						num2 = 40;
						DC_Main.Tbl = DC_Main.OpenRecordSetCrm(DC_Main.RsQry);
						goto IL_04ac;
						IL_04ac:
						num2 = 41;
						dataView = new DataView(DC_Main.Tbl);
						goto IL_04bb;
						IL_04bb:
						num2 = 42;
						if (dataView.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_04d1;
						IL_04d1:
						num2 = 43;
						((DataGridView)DGV).MultiSelect = false;
						goto IL_04e1;
						IL_04e1:
						num2 = 44;
						((DataGridView)DGV).AutoGenerateColumns = false;
						goto IL_04f1;
						IL_04f1:
						num2 = 45;
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
						goto IL_0515;
						IL_0515:
						num2 = 46;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_0534;
						}
						goto IL_05c7;
						IL_0534:
						num2 = 47;
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_055c;
						IL_055c:
						num2 = 48;
						((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0584;
						IL_0584:
						num2 = 49;
						((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_05ac;
						IL_05ac:
						num2 = 50;
						((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_05c7;
						IL_05c7:
						num2 = 52;
						((DataGridView)DGV).ColumnCount = 5;
						goto IL_05d7;
						IL_05d7:
						num2 = 53;
						((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
						goto IL_0607;
						IL_0607:
						num2 = 54;
						((DataGridView)DGV).Columns[0].HeaderText = "Sr";
						goto IL_0626;
						IL_0626:
						num2 = 55;
						((DataGridView)DGV).Columns[0].DataPropertyName = "SrNo";
						goto IL_0645;
						IL_0645:
						num2 = 56;
						((DataGridView)DGV).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
						goto IL_0675;
						IL_0675:
						num2 = 57;
						((DataGridView)DGV).Columns[1].HeaderText = "NewDate";
						goto IL_0694;
						IL_0694:
						num2 = 58;
						((DataGridView)DGV).Columns[1].DataPropertyName = "REM_DATE";
						goto IL_06b3;
						IL_06b3:
						num2 = 59;
						((DataGridView)DGV).Columns[2].Width = (int)Math.Round(300.0 * ColCon);
						goto IL_06e3;
						IL_06e3:
						num2 = 60;
						((DataGridView)DGV).Columns[2].HeaderText = "Remark";
						goto IL_0702;
						IL_0702:
						num2 = 61;
						((DataGridView)DGV).Columns[2].DataPropertyName = "ITM_REMARK";
						goto IL_0721;
						IL_0721:
						num2 = 62;
						((DataGridView)DGV).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
						goto IL_0751;
						IL_0751:
						num2 = 63;
						((DataGridView)DGV).Columns[3].HeaderText = "ItmSale";
						goto IL_0770;
						IL_0770:
						num2 = 64;
						((DataGridView)DGV).Columns[3].DataPropertyName = "ITM_SALE";
						goto IL_078f;
						IL_078f:
						num2 = 65;
						((DataGridView)DGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
						goto IL_07b0;
						IL_07b0:
						num2 = 66;
						((DataGridView)DGV).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
						goto IL_07e0;
						IL_07e0:
						num2 = 67;
						((DataGridView)DGV).Columns[4].HeaderText = "Close";
						goto IL_07ff;
						end_IL_0001_2:
						break;
					}
					num2 = 73;
					((DataGridView)DGV).DataSource = dataView;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj2) when (obj2 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj2);
				try0001_dispatch = 2521;
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

	private void chkItmSale_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)chkReminderClose).Focus();
		}
	}
}
