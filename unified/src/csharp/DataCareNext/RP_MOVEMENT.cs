using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
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
public class RP_MOVEMENT : Form
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
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private QButton _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnProduct")]
	private QButton _BtnProduct;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnEmp")]
	private QButton _BtnEmp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnKarigar")]
	private QButton _BtnKarigar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWtType")]
	private CheckBox _chkWtType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnParty")]
	private QButton _btnParty;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItCancel")]
	private QButton _btnItCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItmSelect")]
	private CheckBox _chkItmSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAll")]
	private QButton _btnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnProd")]
	private QButton _btnProd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnState")]
	private QButton _BtnState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_VCH;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private bool DgvLoad;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string StkType;

	private string CurRpt;

	private double[] TotPcs;

	private string SelectIt;

	private const int cSrNo2 = 0;

	private const int cItName2 = 1;

	private const int cItCode2 = 2;

	private const int cStock2 = 3;

	private const int cMSrNo = 0;

	private const int cMItName = 1;

	private const int cMQty = 2;

	private const int cMPcs = 3;

	private const int cMGrWt = 4;

	private const int cMNetWt = 5;

	private const int cMFine = 6;

	private const int cMNetAmt = 7;

	private const int cMPrc = 8;

	private const int cMStkSlPrc = 9;

	private const int cMKrTotStk = 10;

	private const int cMKrCurStk = 11;

	private const int cMKrSlPrc = 12;

	private const int cMMove = 13;

	private const int cMItCode = 14;

	private const int cMItType = 15;

	private const int czSrNo = 0;

	private const int czItName = 1;

	private const int czQty = 2;

	private const int czPcs = 3;

	private const int czGrWt = 4;

	private const int czNetWt = 5;

	private const int czFine = 6;

	private const int czNetAmt = 7;

	private const int czPrc = 8;

	private const int czItCode = 9;

	private const int czItType = 10;

	private const int czMainCode = 11;

	private const int czMainName = 12;

	private const int cSrNo = 0;

	private const int cBookType = 1;

	private const int cAcName = 2;

	private const int cVchNo = 3;

	private const int cVchDate = 4;

	private const int cTagNo = 5;

	private const int cItemName = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cNetWt = 9;

	private const int cFine = 10;

	private const int cNetAmt = 11;

	private const int cBookCode = 12;

	private const int cBookName = 13;

	private const int cItCode = 14;

	private const int cAcCode = 15;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_CellContentClick);
			EventHandler eventHandler = DGV_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).CellContentClick -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).CellContentClick += val2;
				((Control)val3).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private virtual ComboBox _cboItemTyp;

	internal virtual ComboBox cboItemTyp
	{
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboItemTyp = value;
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
	[AccessedThroughProperty("Panel1")]
	private virtual Panel _Panel1;

	internal virtual Panel Panel1
	{
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel1 = value;
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DETL
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
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val = _DGV_DETL;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val = _DGV_DETL;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual QButton cboArea
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
			EventHandler eventHandler = CboArea_Click;
			QButton val = _cboArea;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_cboArea = value;
			val = _cboArea;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnProduct
	{
		[CompilerGenerated]
		get
		{
			return _BtnProduct;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnProduct_Click;
			QButton val = _BtnProduct;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnProduct = value;
			val = _BtnProduct;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnEmp
	{
		[CompilerGenerated]
		get
		{
			return _BtnEmp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEmp_Click;
			QButton val = _BtnEmp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnEmp = value;
			val = _BtnEmp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnKarigar
	{
		[CompilerGenerated]
		get
		{
			return _BtnKarigar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnKarigar_Click;
			QButton val = _BtnKarigar;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnKarigar = value;
			val = _BtnKarigar;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual CheckBox chkWtType
	{
		[CompilerGenerated]
		get
		{
			return _chkWtType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkWtType_Click;
			CheckBox val = _chkWtType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkWtType = value;
			val = _chkWtType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnParty
	{
		[CompilerGenerated]
		get
		{
			return _btnParty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnParty_Click;
			QButton val = _btnParty;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnParty = value;
			val = _btnParty;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLcCode_KeyDown);
			TextBox val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tLcCode = value;
			val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlIt")]
	private virtual Panel _PnlIt;

	internal virtual Panel PnlIt
	{
		get
		{
			return _PnlIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlIt = value;
		}
	}

	internal virtual QButton btnItCancel
	{
		[CompilerGenerated]
		get
		{
			return _btnItCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItCancel_Click;
			QButton val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItCancel = value;
			val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ITM")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV_ITM;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_ITM
	{
		get
		{
			return _DGV_ITM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_ITM = value;
		}
	}

	internal virtual CheckBox chkItmSelect
	{
		[CompilerGenerated]
		get
		{
			return _chkItmSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkItmSelect_CheckedChanged;
			EventHandler eventHandler2 = chkItmSelect_Click;
			CheckBox val = _chkItmSelect;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkItmSelect = value;
			val = _chkItmSelect;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	internal virtual QButton btnAll
	{
		[CompilerGenerated]
		get
		{
			return _btnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAll_Click;
			QButton val = _btnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAll = value;
			val = _btnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGrCode_KeyDown);
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrName")]
	private virtual TextBox _tGrName;

	internal virtual TextBox tGrName
	{
		get
		{
			return _tGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tGrName = value;
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
	[AccessedThroughProperty("cboMoveType")]
	private virtual ComboBox _cboMoveType;

	internal virtual ComboBox cboMoveType
	{
		get
		{
			return _cboMoveType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboMoveType = value;
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

	internal virtual QButton btnProd
	{
		[CompilerGenerated]
		get
		{
			return _btnProd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnProd_Click;
			QButton val = _btnProd;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnProd = value;
			val = _btnProd;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnState
	{
		[CompilerGenerated]
		get
		{
			return _BtnState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnState_Click;
			QButton val = _BtnState;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnState = value;
			val = _BtnState;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_VCH
	{
		[CompilerGenerated]
		get
		{
			return _DGV_VCH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV_VCH;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_VCH = value;
			val2 = _DGV_VCH;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSalesType")]
	private virtual ComboBox _cboSalesType;

	internal virtual ComboBox cboSalesType
	{
		get
		{
			return _cboSalesType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSalesType = value;
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
	[AccessedThroughProperty("cboState")]
	private virtual ComboBox _cboState;

	internal virtual ComboBox cboState
	{
		get
		{
			return _cboState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboState = value;
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
	[AccessedThroughProperty("cboCity")]
	private virtual ComboBox _cboCity;

	internal virtual ComboBox cboCity
	{
		get
		{
			return _cboCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCity = value;
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

	public int newindex { get; set; }

	public RP_MOVEMENT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_MOVEMENT_Load;
		((Form)this).Deactivate += RP_MOVEMENT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_MOVEMENT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_MOVEMENT_KeyDown);
		((Form)this).Activated += RP_MOVEMENT_Activated;
		((Form)this).Closed += RP_LEDR_Closed;
		DgvLoad = false;
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_078e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0798: Expected O, but got Unknown
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Expected O, but got Unknown
		//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Expected O, but got Unknown
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Expected O, but got Unknown
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Expected O, but got Unknown
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected O, but got Unknown
		//IL_0b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b57: Expected O, but got Unknown
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf6: Expected O, but got Unknown
		//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7e: Expected O, but got Unknown
		//IL_0d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6a: Expected O, but got Unknown
		//IL_0dd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddd: Expected O, but got Unknown
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e95: Expected O, but got Unknown
		//IL_0efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f08: Expected O, but got Unknown
		//IL_1347: Unknown result type (might be due to invalid IL or missing references)
		//IL_136b: Unknown result type (might be due to invalid IL or missing references)
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e6: Expected O, but got Unknown
		//IL_1409: Unknown result type (might be due to invalid IL or missing references)
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1691: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1702: Unknown result type (might be due to invalid IL or missing references)
		//IL_170c: Expected O, but got Unknown
		//IL_1732: Unknown result type (might be due to invalid IL or missing references)
		//IL_1996: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_19de: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a35: Expected O, but got Unknown
		//IL_1a5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afb: Expected O, but got Unknown
		//IL_1b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba1: Expected O, but got Unknown
		//IL_1c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c31: Expected O, but got Unknown
		//IL_1d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d15: Expected O, but got Unknown
		//IL_1d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d88: Expected O, but got Unknown
		//IL_1e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e64: Expected O, but got Unknown
		//IL_1f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0a: Expected O, but got Unknown
		//IL_1f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9a: Expected O, but got Unknown
		//IL_2081: Unknown result type (might be due to invalid IL or missing references)
		//IL_208b: Expected O, but got Unknown
		//IL_20f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fe: Expected O, but got Unknown
		//IL_21bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c9: Expected O, but got Unknown
		//IL_2265: Unknown result type (might be due to invalid IL or missing references)
		//IL_226f: Expected O, but got Unknown
		//IL_22f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ff: Expected O, but got Unknown
		//IL_23e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f0: Expected O, but got Unknown
		//IL_2459: Unknown result type (might be due to invalid IL or missing references)
		//IL_2463: Expected O, but got Unknown
		//IL_26f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_271a: Unknown result type (might be due to invalid IL or missing references)
		//IL_273e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2762: Unknown result type (might be due to invalid IL or missing references)
		//IL_278b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2795: Expected O, but got Unknown
		//IL_27b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aba: Expected O, but got Unknown
		//IL_2add: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d64: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d88: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddf: Expected O, but got Unknown
		//IL_2e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_3065: Unknown result type (might be due to invalid IL or missing references)
		//IL_3089: Unknown result type (might be due to invalid IL or missing references)
		//IL_30ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_30d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_30fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3104: Expected O, but got Unknown
		//IL_3127: Unknown result type (might be due to invalid IL or missing references)
		//IL_319d: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a7: Expected O, but got Unknown
		//IL_323b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3245: Expected O, but got Unknown
		//IL_32c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_32d2: Expected O, but got Unknown
		//IL_338c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3396: Expected O, but got Unknown
		//IL_3647: Unknown result type (might be due to invalid IL or missing references)
		//IL_366b: Unknown result type (might be due to invalid IL or missing references)
		//IL_368f: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_36dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_36e6: Expected O, but got Unknown
		//IL_3709: Unknown result type (might be due to invalid IL or missing references)
		//IL_3780: Unknown result type (might be due to invalid IL or missing references)
		//IL_378a: Expected O, but got Unknown
		//IL_383d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3847: Expected O, but got Unknown
		//IL_38fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3904: Expected O, but got Unknown
		//IL_3985: Unknown result type (might be due to invalid IL or missing references)
		//IL_398f: Expected O, but got Unknown
		//IL_3a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a1d: Expected O, but got Unknown
		//IL_3ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae4: Expected O, but got Unknown
		//IL_3b51: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b5b: Expected O, but got Unknown
		//IL_3df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e41: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e98: Expected O, but got Unknown
		//IL_3ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_4122: Unknown result type (might be due to invalid IL or missing references)
		//IL_4146: Unknown result type (might be due to invalid IL or missing references)
		//IL_416a: Unknown result type (might be due to invalid IL or missing references)
		//IL_418e: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_41c1: Expected O, but got Unknown
		//IL_41e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4267: Unknown result type (might be due to invalid IL or missing references)
		//IL_4271: Expected O, but got Unknown
		//IL_42de: Unknown result type (might be due to invalid IL or missing references)
		//IL_42e8: Expected O, but got Unknown
		//IL_43a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_43af: Expected O, but got Unknown
		//IL_441f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4429: Expected O, but got Unknown
		//IL_44e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_44f0: Expected O, but got Unknown
		//IL_4560: Unknown result type (might be due to invalid IL or missing references)
		//IL_456a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_MOVEMENT));
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
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		DataGridViewCellStyle val16 = new DataGridViewCellStyle();
		DataGridViewCellStyle val17 = new DataGridViewCellStyle();
		DataGridViewCellStyle val18 = new DataGridViewCellStyle();
		DataGridViewCellStyle val19 = new DataGridViewCellStyle();
		DataGridViewCellStyle val20 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		PnlIt = new Panel();
		btnAll = new QButton();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DevComponents.DotNetBar.Controls.DataGridViewX();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		DGV_VCH = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboArea = new QButton();
		BtnProduct = new QButton();
		BtnEmp = new QButton();
		BtnKarigar = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		chkWtType = new CheckBox();
		btnParty = new QButton();
		tLcCode = new TextBox();
		chkItmSelect = new CheckBox();
		tGrCode = new TextBox();
		tGrName = new TextBox();
		Label7 = new Label();
		cboMoveType = new ComboBox();
		Label1 = new Label();
		btnProd = new QButton();
		BtnState = new QButton();
		cboSalesType = new ComboBox();
		Label4 = new Label();
		cboState = new ComboBox();
		Label5 = new Label();
		cboCity = new ComboBox();
		Label6 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)Panel1).SuspendLayout();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((ISupportInitialize)DGV_VCH).BeginInit();
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
		((Control)PnlBotam).TabIndex = 12;
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
		((Control)BtnSave).TabIndex = 1;
		BtnSave.Text = "Excel";
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
		((Control)BtnPrint).TabIndex = 0;
		BtnPrint.Text = "Print";
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
		lblBook.Text = "Movement Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(10, 13);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1160, 404);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 2;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(96, 70);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(162, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(11, 70);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(79, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.PeachPuff;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)PnlIt);
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Controls.Add((Control)(object)DGV_DETL);
		((Control)Panel1).Controls.Add((Control)(object)DGV_VCH);
		((Control)Panel1).Location = new Point(0, 132);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 432);
		((Control)Panel1).TabIndex = 110;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnAll);
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(713, 13);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1207;
		((Control)PnlIt).Visible = false;
		((QControl)btnAll).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAll).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAll).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAll.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Image = null;
		((QControl)btnAll).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAll).Location = new Point(50, 249);
		((Control)btnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAll).Name = "btnAll";
		((Control)btnAll).Size = new Size(100, 38);
		((Control)btnAll).TabIndex = 1160;
		btnAll.Text = "All";
		((QControl)btnItCancel).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItCancel).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItCancel.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Image = null;
		((QControl)btnItCancel).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItCancel).Location = new Point(312, 249);
		((Control)btnItCancel).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItCancel).Name = "btnItCancel";
		((Control)btnItCancel).Size = new Size(100, 38);
		((Control)btnItCancel).TabIndex = 1158;
		btnItCancel.Text = "Cancel";
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(182, 249);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(100, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV_ITM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITM).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val8;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val10;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_DETL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val13;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(11, 13);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val15;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1158, 406);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 3;
		((DataGridView)DGV_VCH).AllowUserToAddRows = false;
		((DataGridView)DGV_VCH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_VCH).AllowUserToResizeRows = false;
		val16.BackColor = Color.PapayaWhip;
		val16.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val16.ForeColor = Color.FromArgb(64, 64, 64);
		val16.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val16.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle = val16;
		((DataGridView)DGV_VCH).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_VCH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_VCH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val17.Alignment = (DataGridViewContentAlignment)16;
		val17.BackColor = SystemColors.Control;
		val17.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val17.ForeColor = Color.FromArgb(64, 64, 64);
		val17.SelectionBackColor = SystemColors.ScrollBar;
		val17.SelectionForeColor = Color.White;
		val17.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle = val17;
		((DataGridView)DGV_VCH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_VCH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val18.Alignment = (DataGridViewContentAlignment)16;
		val18.BackColor = SystemColors.Window;
		val18.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val18.ForeColor = Color.FromArgb(64, 64, 64);
		val18.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val18.SelectionForeColor = Color.Maroon;
		val18.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).DefaultCellStyle = val18;
		((DataGridView)DGV_VCH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_VCH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_VCH).Location = new Point(12, 12);
		((Control)DGV_VCH).Name = "DGV_VCH";
		DGV_VCH.PaintEnhancedSelection = false;
		((DataGridView)DGV_VCH).ReadOnly = true;
		val19.Alignment = (DataGridViewContentAlignment)16;
		val19.BackColor = Color.MintCream;
		val19.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val19.ForeColor = SystemColors.WindowText;
		val19.SelectionBackColor = SystemColors.Highlight;
		val19.SelectionForeColor = SystemColors.HighlightText;
		val19.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_VCH).RowHeadersDefaultCellStyle = val19;
		((DataGridView)DGV_VCH).RowHeadersVisible = false;
		((DataGridView)DGV_VCH).RowHeadersWidth = 20;
		val20.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val20.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_VCH).RowsDefaultCellStyle = val20;
		DGV_VCH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_VCH.SelectAllSignVisible = false;
		((DataGridView)DGV_VCH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_VCH).Size = new Size(1158, 406);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 1208;
		((QControl)cboArea).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)cboArea).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)cboArea).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)cboArea).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)cboArea).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)cboArea).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)cboArea).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)cboArea).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)cboArea).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)cboArea).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)cboArea).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)cboArea).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)cboArea).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)cboArea).ColorScheme).InheritCurrentThemeFromGlobal = false;
		cboArea.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		cboArea.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		cboArea.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		cboArea.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		cboArea.Image = null;
		((QControl)cboArea).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)cboArea).Location = new Point(357, 100);
		((Control)cboArea).Margin = new Padding(3, 6, 3, 6);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(143, 37);
		((Control)cboArea).TabIndex = 7;
		cboArea.Text = "Area Wise";
		((QControl)BtnProduct).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnProduct).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnProduct).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnProduct).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnProduct).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnProduct).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnProduct).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnProduct).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnProduct).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnProduct).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnProduct).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnProduct).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnProduct).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnProduct).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnProduct.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnProduct.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnProduct.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnProduct.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnProduct.Image = null;
		((QControl)BtnProduct).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnProduct).Location = new Point(518, 100);
		((Control)BtnProduct).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnProduct).Name = "BtnProduct";
		((Control)BtnProduct).Size = new Size(143, 37);
		((Control)BtnProduct).TabIndex = 6;
		BtnProduct.Text = "&City Wise";
		((QControl)BtnEmp).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnEmp).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnEmp).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnEmp).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnEmp).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnEmp).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnEmp).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnEmp).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnEmp).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnEmp).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnEmp).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnEmp).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnEmp).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnEmp).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnEmp.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmp.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmp.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmp.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnEmp.Image = null;
		((QControl)BtnEmp).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnEmp).Location = new Point(679, 100);
		((Control)BtnEmp).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnEmp).Name = "BtnEmp";
		((Control)BtnEmp).Size = new Size(143, 37);
		((Control)BtnEmp).TabIndex = 5;
		BtnEmp.Text = "&Employe Wise";
		((QControl)BtnKarigar).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnKarigar).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnKarigar).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnKarigar).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnKarigar).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnKarigar).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnKarigar).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnKarigar).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnKarigar).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnKarigar).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnKarigar).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnKarigar).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnKarigar).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnKarigar).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnKarigar.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKarigar.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKarigar.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKarigar.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnKarigar.Image = null;
		((QControl)BtnKarigar).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnKarigar).Location = new Point(840, 100);
		((Control)BtnKarigar).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnKarigar).Name = "BtnKarigar";
		((Control)BtnKarigar).Size = new Size(143, 37);
		((Control)BtnKarigar).TabIndex = 8;
		BtnKarigar.Text = "Karigar Wise";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(96, 41);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(182, 41);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(46, 42);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(44, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "Date";
		Label2.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkWtType).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkWtType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWtType).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkWtType).Location = new Point(16, 7);
		((Control)chkWtType).Name = "chkWtType";
		((Control)chkWtType).RightToLeft = (RightToLeft)0;
		((Control)chkWtType).Size = new Size(159, 19);
		((Control)chkWtType).TabIndex = 1136;
		((ButtonBase)chkWtType).Text = "Gross Wise Weight";
		chkWtType.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkWtType).UseVisualStyleBackColor = false;
		((QControl)btnParty).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnParty).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnParty).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnParty).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnParty).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnParty).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnParty).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnParty).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnParty).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnParty).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnParty).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnParty).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnParty).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnParty).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnParty.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParty.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParty.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParty.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParty.Image = null;
		((QControl)btnParty).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnParty).Location = new Point(1001, 100);
		((Control)btnParty).Margin = new Padding(3, 6, 3, 6);
		((Control)btnParty).Name = "btnParty";
		((Control)btnParty).Size = new Size(143, 37);
		((Control)btnParty).TabIndex = 9;
		btnParty.Text = "Party Sales";
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1068, 6);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1159;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((ButtonBase)chkItmSelect).BackColor = Color.Transparent;
		((Control)chkItmSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItmSelect).ForeColor = Color.Black;
		((Control)chkItmSelect).Location = new Point(987, 41);
		((Control)chkItmSelect).Name = "chkItmSelect";
		((Control)chkItmSelect).RightToLeft = (RightToLeft)0;
		((Control)chkItmSelect).Size = new Size(176, 19);
		((Control)chkItmSelect).TabIndex = 1204;
		((ButtonBase)chkItmSelect).Text = "Select Item Not In List";
		((ButtonBase)chkItmSelect).UseVisualStyleBackColor = false;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrCode).Location = new Point(857, 69);
		((TextBoxBase)tGrCode).MaxLength = 8;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(53, 23);
		((Control)tGrCode).TabIndex = 1205;
		((TextBoxBase)tGrName).BackColor = Color.White;
		((Control)tGrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrName).Location = new Point(915, 69);
		((TextBoxBase)tGrName).MaxLength = 8;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(229, 23);
		((Control)tGrName).TabIndex = 1207;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(775, 70);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(77, 20);
		((Control)Label7).TabIndex = 1206;
		Label7.Text = "Ac Group";
		Label7.TextAlign = (ContentAlignment)64;
		cboMoveType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboMoveType).Font = new Font("Tahoma", 9f);
		((ListControl)cboMoveType).FormattingEnabled = true;
		((Control)cboMoveType).Location = new Point(375, 42);
		((Control)cboMoveType).Name = "cboMoveType";
		((Control)cboMoveType).Size = new Size(107, 22);
		((Control)cboMoveType).TabIndex = 1208;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(283, 42);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(86, 20);
		((Control)Label1).TabIndex = 1209;
		Label1.Text = "Move Type";
		Label1.TextAlign = (ContentAlignment)64;
		((QControl)btnProd).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnProd).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnProd).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnProd).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnProd).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnProd).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnProd).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnProd).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnProd).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnProd).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnProd).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnProd).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnProd).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnProd).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnProd.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnProd.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnProd.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnProd.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnProd.Image = null;
		((QControl)btnProd).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnProd).Location = new Point(196, 100);
		((Control)btnProd).Margin = new Padding(3, 6, 3, 6);
		((Control)btnProd).Name = "btnProd";
		((Control)btnProd).Size = new Size(143, 37);
		((Control)btnProd).TabIndex = 1210;
		btnProd.Text = "Product Wise";
		((QControl)BtnState).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnState).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnState).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnState).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnState).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnState).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnState).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnState).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnState).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnState).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnState).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnState).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnState).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnState).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnState.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnState.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnState.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnState.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnState.Image = null;
		((QControl)BtnState).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnState).Location = new Point(35, 99);
		((Control)BtnState).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnState).Name = "BtnState";
		((Control)BtnState).Size = new Size(143, 37);
		((Control)BtnState).TabIndex = 1211;
		BtnState.Text = "State";
		cboSalesType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboSalesType).Font = new Font("Tahoma", 9f);
		((ListControl)cboSalesType).FormattingEnabled = true;
		((Control)cboSalesType).Location = new Point(375, 71);
		((Control)cboSalesType).Name = "cboSalesType";
		((Control)cboSalesType).Size = new Size(107, 22);
		((Control)cboSalesType).TabIndex = 1212;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(276, 70);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(92, 20);
		((Control)Label4).TabIndex = 1213;
		Label4.Text = "Sales Type";
		Label4.TextAlign = (ContentAlignment)64;
		cboState.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboState).Font = new Font("Tahoma", 9f);
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Location = new Point(581, 70);
		((Control)cboState).Name = "cboState";
		((Control)cboState).Size = new Size(159, 22);
		((Control)cboState).TabIndex = 1214;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(499, 69);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(73, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "State";
		Label5.TextAlign = (ContentAlignment)64;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(581, 41);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(159, 22);
		((Control)cboCity).TabIndex = 1216;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(503, 42);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(69, 20);
		((Control)Label6).TabIndex = 1217;
		Label6.Text = "City";
		Label6.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)cboCity);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboState);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)cboSalesType);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboMoveType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)chkItmSelect);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)chkWtType);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)BtnProduct);
		((Control)this).Controls.Add((Control)(object)BtnEmp);
		((Control)this).Controls.Add((Control)(object)BtnKarigar);
		((Control)this).Controls.Add((Control)(object)btnParty);
		((Control)this).Controls.Add((Control)(object)btnProd);
		((Control)this).Controls.Add((Control)(object)BtnState);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_MOVEMENT";
		((Form)this).Text = "Movement Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
	}

	private void DGV_FILL()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0edd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee7: Expected O, but got Unknown
		DGV_CLEAR();
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			if ((Operators.CompareString(StkType, "Party", false) == 0) | (Operators.CompareString(StkType, "Employe", false) == 0) | (Operators.CompareString(StkType, "City", false) == 0) | (Operators.CompareString(StkType, "Area", false) == 0) | (Operators.CompareString(StkType, "State", false) == 0))
			{
				((DataGridView)DGV).Columns.Add("", "Party Name");
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(275.0 * ColCon);
				((DataGridView)DGV).Columns[1].Frozen = true;
			}
			else if (Operators.CompareString(StkType, "Karigar", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "Kr Code");
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(175.0 * ColCon);
				((DataGridView)DGV).Columns[1].Frozen = true;
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "Product");
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(175.0 * ColCon);
				((DataGridView)DGV).Columns[1].Frozen = true;
			}
			((DataGridView)DGV).Columns.Add("", "Qty");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns.Add("", "Pcs");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns.Add("", "SlGrWt");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SlNetWt");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SlFine");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SlAmt");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "SlPrc%");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Stk/Sl%");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			if ((Operators.CompareString(StkType, "Party", false) == 0) | (Operators.CompareString(StkType, "Employe", false) == 0) | (Operators.CompareString(StkType, "City", false) == 0) | (Operators.CompareString(StkType, "Area", false) == 0) | (Operators.CompareString(StkType, "State", false) == 0))
			{
				((DataGridView)DGV).Columns.Add("", "KrTotRec");
				((DataGridView)DGV).Columns[10].Visible = false;
				((DataGridView)DGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "KrCurStk");
				((DataGridView)DGV).Columns[11].Visible = false;
				((DataGridView)DGV).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "KrSl%");
				((DataGridView)DGV).Columns[12].Visible = false;
				((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "Move");
				((DataGridView)DGV).Columns[13].Visible = false;
				((DataGridView)DGV).Columns[13].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			}
			else if (Operators.CompareString(StkType, "Karigar", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "KrTotRec");
				((DataGridView)DGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "KrCurStk");
				((DataGridView)DGV).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "KrRatio%");
				((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "Move");
				((DataGridView)DGV).Columns[13].Visible = false;
				((DataGridView)DGV).Columns[13].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "ProdTot");
				((DataGridView)DGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "ProdStk");
				((DataGridView)DGV).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "PrRatio%");
				((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "Move");
				((DataGridView)DGV).Columns[13].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			}
			((DataGridView)DGV).Columns.Add("", "ItCode");
			((DataGridView)DGV).Columns[14].Visible = false;
			((DataGridView)DGV).Columns.Add("", "It Type");
			((DataGridView)DGV).Columns[15].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
		}
	}

	private void BtnParty_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Party";
		PartySales();
	}

	private void BtnKarigar_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Karigar";
		PartySales();
	}

	private void BtnEmp_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Employe";
		PartySales();
	}

	private void BtnProduct_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "City";
		PartySales();
	}

	private void CboArea_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Area";
		PartySales();
	}

	private void BtnProd_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Product";
		PartySales();
	}

	private void PartySales()
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		int num9 = 0;
		string text = "";
		checked
		{
			num9 = (int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDt.Text), Conversions.ToDate(mFromDt.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1));
			if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "A", false) == 0)
			{
				text = "SUM(A.NET_AMT)";
			}
			else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "N", false) == 0)
			{
				text = "SUM(A.ITM_NWT)";
			}
			else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "F", false) == 0)
			{
				text = "SUM(A.ITM_FINE)";
			}
			DGV_FILL();
			if (Operators.CompareString(StkType, "Party", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE As Code,C.AC_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_CITY = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_STATE = '" + cboState.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.AC_CODE,C.AC_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Karigar", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.KR_NAME As Code,C.KR_NAME As Name,SUM(1) As Qty,SUM(A.ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND C.KR_NAME <> '' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND E.AC_CITY = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND E.AC_STATE = '" + cboState.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY C.KR_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Employe", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.EMP_CODE As Code,C.EMP_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)INNER JOIN EMP_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.EMP_CODE = C.EMP_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE)LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND E.AC_CITY = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND E.AC_STATE = '" + cboState.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.EMP_CODE,C.EMP_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "City", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_CITY As Code,C.AC_CITY As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_CITY = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_STATE = '" + cboState.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY C.AC_CITY,C.AC_CITY ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "State", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_STATE As Code,C.AC_STATE As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_CITY = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_STATE = '" + cboState.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY C.AC_STATE,C.AC_STATE ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Area", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_AREA As Code,C.AC_AREA As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_CITY = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND C.AC_STATE = '" + cboState.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY C.AC_AREA,C.AC_AREA ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.PR_CODE As Code,C.PR_NAME As Name,SUM(1) As Qty,SUM(A.ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE)LEFT JOIN PRODUCT_MAST AS C ON D.CO_CODE = C.CO_CODE AND D.PR_CODE = C.PR_CODE)LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY D.PR_CODE,C.PR_NAME ORDER BY " + text + " DESC";
			}
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.R = 0;
			if (RsStkSum.Rows.Count <= 0)
			{
				return;
			}
			if ((Operators.CompareString(StkType, "Party", false) == 0) | (Operators.CompareString(StkType, "Employe", false) == 0) | (Operators.CompareString(StkType, "City", false) == 0) | (Operators.CompareString(StkType, "Area", false) == 0) | (Operators.CompareString(StkType, "State", false) == 0))
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(A.ITM_NWT) As TotStk FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_SIGN = '+' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND C.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND C.AC_STATE = '" + cboState.Text + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			}
			else if (Operators.CompareString(StkType, "Karigar", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(A.ITM_NWT) As TotStk FROM (BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND A.KR_NAME <> '' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND C.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND C.AC_STATE = '" + cboState.Text + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(A.ITM_NWT) As TotStk FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND C.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND C.AC_STATE = '" + cboState.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			}
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				num = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TotStk"], (object)"")), "0.000"));
			}
			int num10 = RsStkSum.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num10)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Code"]);
				((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Name"]);
				((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Qty"]);
				((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Pcs"]);
				((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Gwt"]);
				((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["NetWt"]);
				((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["FineWt"]);
				((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["NetAmt"]);
				if (num > 0.0)
				{
					((DataGridView)dGV)[9, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) * 100.0 / num), "0.000");
				}
				if (!((Operators.CompareString(StkType, "Party", false) == 0) | (Operators.CompareString(StkType, "Employe", false) == 0) | (Operators.CompareString(StkType, "City", false) == 0) | (Operators.CompareString(StkType, "Area", false) == 0) | (Operators.CompareString(StkType, "State", false) == 0)))
				{
					if (Operators.CompareString(StkType, "Karigar", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(A.ITM_NWT) As TotStk FROM (BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND A.KR_NAME = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND C.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND C.AC_STATE = '" + cboState.Text + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TotStk"], (object)"")), "0.000");
							((DataGridView)dGV)[12, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value))), "0.000");
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) As KrStk FROM ((MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE AND C.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND D.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND D.AC_STATE = '" + cboState.Text + "'"))), (object)" AND C.KR_NAME = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["KrStk"], (object)"")), "0.000");
						}
					}
					else if (Operators.CompareString(StkType, "Product", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(A.ITM_NWT) As TotStk FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.AC_CODE = C.AC_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND C.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND C.AC_STATE = '" + cboState.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND B.PR_CODE = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TotStk"], (object)"")), "0.000");
							((DataGridView)dGV)[12, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value))), "0.000");
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) As KrStk FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND B.PR_CODE = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND C.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND C.AC_STATE = '" + cboState.Text + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) > 0"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["KrStk"], (object)"")), "0.000");
						}
						double num11 = 0.0;
						if (num9 > 0)
						{
							num11 = Conversions.ToDouble(Strings.Format(Operators.DivideObject((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) * 1000.0), Operators.MultiplyObject(((DataGridView)dGV)[11, DC_Main.R].Value, (object)num9)), "0.000"));
							object value = ((DataGridView)dGV)[12, DC_Main.R].Value;
							if (Operators.ConditionalCompareObjectLess(value, (object)5, false))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "G = Very Slow";
							}
							else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectGreaterEqual(value, (object)5, false)) && Conversions.ToBoolean(Operators.CompareObjectLessEqual(value, (object)14.99, false)))))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "F = Slow";
							}
							else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectGreaterEqual(value, (object)15, false)) && Conversions.ToBoolean(Operators.CompareObjectLessEqual(value, (object)29.99, false)))))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "E = Average";
							}
							else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectGreaterEqual(value, (object)30, false)) && Conversions.ToBoolean(Operators.CompareObjectLessEqual(value, (object)44.99, false)))))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "D = Normal";
							}
							else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectGreaterEqual(value, (object)45, false)) && Conversions.ToBoolean(Operators.CompareObjectLessEqual(value, (object)69.99, false)))))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "C = Fast";
							}
							else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectGreaterEqual(value, (object)70, false)) && Conversions.ToBoolean(Operators.CompareObjectLessEqual(value, (object)89.99, false)))))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "B = Very Fast";
							}
							else if (Operators.ConditionalCompareObjectGreater(value, (object)90, false))
							{
								((DataGridView)dGV)[13, DC_Main.R].Value = "A = Best";
							}
						}
					}
				}
				num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV)[2, DC_Main.R].Value));
				num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[3, DC_Main.R].Value));
				num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV)[4, DC_Main.R].Value));
				num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV)[5, DC_Main.R].Value));
				num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV)[6, DC_Main.R].Value));
				num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV)[7, DC_Main.R].Value));
				num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV)[9, DC_Main.R].Value));
				DC_Main.R++;
				dGV = null;
				DC_Main.M++;
			}
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV).Rows.Add();
			int num12 = ((DataGridView)DGV).Rows.Count - 1;
			((DataGridView)DGV)[2, num12].Value = num2;
			((DataGridView)DGV)[3, num12].Value = num3;
			((DataGridView)DGV)[4, num12].Value = num4;
			((DataGridView)DGV)[5, num12].Value = num5;
			((DataGridView)DGV)[6, num12].Value = num6;
			((DataGridView)DGV)[7, num12].Value = num7;
			((DataGridView)DGV)[9, num12].Value = num8;
			int num13 = ((DataGridView)DGV).RowCount - 1;
			DC_Main.R = 0;
			while (DC_Main.R <= num13)
			{
				if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "A", false) == 0)
				{
					((DataGridView)DGV)[8, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[7, DC_Main.R].Value)) * 100.0 / num7), "0.000");
				}
				else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "N", false) == 0)
				{
					((DataGridView)DGV)[8, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[5, DC_Main.R].Value)) * 100.0 / num5), "0.000");
				}
				else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "F", false) == 0)
				{
					((DataGridView)DGV)[8, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[6, DC_Main.R].Value)) * 100.0 / num6), "0.000");
				}
				DC_Main.R++;
			}
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 3) <= 3u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 103:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009d;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 103;
				continue;
			}
			break;
			IL_009d:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_VCH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 7) <= 3u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 103:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009d;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 103;
				continue;
			}
			break;
			IL_009d:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b0: Expected O, but got Unknown
		((Control)DGV).Visible = false;
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Columns.Clear();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Back";
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		((DataGridView)DGV_DETL).MultiSelect = false;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			if ((Operators.CompareString(StkType, "Party", false) == 0) | (Operators.CompareString(StkType, "Employe", false) == 0) | (Operators.CompareString(StkType, "City", false) == 0) | (Operators.CompareString(StkType, "Area", false) == 0) | (Operators.CompareString(StkType, "Karigar", false) == 0) | (Operators.CompareString(StkType, "State", false) == 0))
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Item Name");
				((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(275.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Karigar");
				((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(175.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Qty");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns.Add("", "SlGrWt");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "SlNetWt");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "SlFine");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "SlAmt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "SlPrc%");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
			((DataGridView)DGV_DETL).Columns[9].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "It Type");
			((DataGridView)DGV_DETL).Columns[10].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "ZoomCode");
			((DataGridView)DGV_DETL).Columns[11].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "ZoomItem");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(200.0 * ColCon);
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			string text = "";
			if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "A", false) == 0)
			{
				text = "SUM(A.NET_AMT)";
			}
			else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "N", false) == 0)
			{
				text = "SUM(A.ITM_NWT)";
			}
			else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "F", false) == 0)
			{
				text = "SUM(A.ITM_FINE)";
			}
			string value = Conversions.ToString(((DataGridView)DGV)[14, index].Value);
			string text2 = Conversions.ToString(((DataGridView)DGV)[1, index].Value);
			if (Operators.CompareString(StkType, "Party", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,C.IT_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND C.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.AC_CODE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE,C.IT_NAME ORDER BY " + text + " DESC";
				RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(StkType, "Karigar", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As Name,SUM(1) As Qty,SUM(A.ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND C.KR_NAME = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Employe", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)INNER JOIN EMP_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.EMP_CODE = C.EMP_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.EMP_CODE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "City", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND C.AC_CITY = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "State", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND C.AC_STATE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Area", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As Name,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND C.AC_AREA = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY " + text + " DESC";
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.KR_NAME As Code,C.KR_NAME As Name,SUM(1) As Qty,SUM(A.ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND D.PR_CODE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				if (cboSalesType.SelectedIndex == 2)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
				}
				else if (cboSalesType.SelectedIndex == 1)
				{
					DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','E CRNT')";
				}
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY C.KR_NAME ORDER BY " + text + " DESC";
			}
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			index = 0;
			if (DC_Main.Tbl.Rows.Count <= 0)
			{
				return;
			}
			int num8 = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num8)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[0, index].Value = index + 1;
				((DataGridView)dGV_DETL)[9, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Code"]);
				((DataGridView)dGV_DETL)[1, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Name"]);
				((DataGridView)dGV_DETL)[2, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Qty"]);
				((DataGridView)dGV_DETL)[3, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Pcs"]);
				((DataGridView)dGV_DETL)[4, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"]);
				((DataGridView)dGV_DETL)[5, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["NetWt"]);
				((DataGridView)dGV_DETL)[6, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["FineWt"]);
				((DataGridView)dGV_DETL)[7, index].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["NetAmt"]);
				((DataGridView)dGV_DETL)[11, index].Value = value;
				((DataGridView)dGV_DETL)[12, index].Value = "  " + text2;
				num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV_DETL)[2, index].Value));
				num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV_DETL)[3, index].Value));
				num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV_DETL)[4, index].Value));
				num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV_DETL)[5, index].Value));
				num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV_DETL)[6, index].Value));
				num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV_DETL)[7, index].Value));
				index++;
				dGV_DETL = null;
				DC_Main.M++;
			}
			((DataGridView)DGV_DETL).Rows.Add();
			((DataGridView)DGV_DETL).Rows.Add();
			int num9 = ((DataGridView)DGV_DETL).Rows.Count - 1;
			((DataGridView)DGV_DETL)[2, num9].Value = num;
			((DataGridView)DGV_DETL)[3, num9].Value = num2;
			((DataGridView)DGV_DETL)[4, num9].Value = num3;
			((DataGridView)DGV_DETL)[5, num9].Value = num4;
			((DataGridView)DGV_DETL)[6, num9].Value = num5;
			((DataGridView)DGV_DETL)[7, num9].Value = num6;
			int num10 = ((DataGridView)DGV_DETL).RowCount - 1;
			for (index = 0; index <= num10; index++)
			{
				if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "A", false) == 0)
				{
					((DataGridView)DGV_DETL)[8, index].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[7, index].Value)) * 100.0 / num6), "0.000");
				}
				else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "N", false) == 0)
				{
					((DataGridView)DGV_DETL)[8, index].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[5, index].Value)) * 100.0 / num4), "0.000");
				}
				else if (Operators.CompareString(Strings.Mid(cboMoveType.Text, 1, 1), "F", false) == 0)
				{
					((DataGridView)DGV_DETL)[8, index].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[6, index].Value)) * 100.0 / num5), "0.000");
				}
			}
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
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		int num13 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num14 = default(int);
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
					case 2214:
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
								goto IL_012e;
							case 13:
								goto IL_0145;
							case 14:
								goto IL_018d;
							case 15:
								goto IL_019c;
							case 16:
								goto IL_01b9;
							case 17:
								goto IL_01d0;
							case 18:
								goto IL_0223;
							case 19:
								goto IL_0232;
							case 21:
								goto IL_0254;
							case 22:
								goto IL_026b;
							case 23:
								goto IL_02b3;
							case 24:
								goto IL_02c2;
							case 25:
								goto IL_02df;
							case 26:
								goto IL_02f9;
							case 27:
								goto IL_0318;
							case 28:
								goto IL_0326;
							case 30:
								goto IL_0393;
							case 31:
								goto IL_03a1;
							case 33:
								goto IL_0402;
							case 36:
								goto IL_045a;
							case 29:
							case 32:
							case 34:
							case 35:
							case 37:
							case 38:
								goto IL_04ae;
							case 39:
								goto IL_04c0;
							case 20:
							case 40:
							case 41:
								goto IL_04dc;
							case 42:
								goto IL_04e6;
							case 43:
								goto IL_0539;
							case 44:
								goto IL_058e;
							case 45:
								goto IL_05e6;
							case 46:
								goto IL_0654;
							case 47:
								goto IL_0697;
							case 48:
								goto IL_06c6;
							case 49:
								goto IL_0709;
							case 50:
								goto IL_074a;
							case 51:
								goto IL_076b;
							case 52:
								goto IL_0779;
							case 53:
								goto IL_0793;
							case 54:
								goto IL_0799;
							case 55:
								goto IL_079f;
							case 56:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 57:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_04ae:
						num2 = 38;
						num5++;
						goto IL_04b7;
						IL_026b:
						num2 = 22;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02b3;
						IL_045a:
						num2 = 36;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_04ae;
						IL_02b3:
						num2 = 23;
						num6++;
						goto IL_02bc;
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
						if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
						{
							goto IL_012e;
						}
						goto IL_0254;
						IL_012e:
						num2 = 12;
						num7 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num8 = 0;
						goto IL_0196;
						IL_0196:
						if (num8 <= num7)
						{
							goto IL_0145;
						}
						goto IL_019c;
						IL_019c:
						num2 = 15;
						num9 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0241;
						IL_0241:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_04dc;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num11 = 0;
						goto IL_022c;
						IL_022c:
						if (num11 <= num10)
						{
							goto IL_01d0;
						}
						goto IL_0232;
						IL_0232:
						num2 = 19;
						DC_Main.i++;
						goto IL_0241;
						IL_01d0:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_DETL)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0223;
						IL_0223:
						num2 = 18;
						num11++;
						goto IL_022c;
						IL_0145:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_DETL).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_018d;
						IL_018d:
						num2 = 14;
						num8++;
						goto IL_0196;
						IL_0254:
						num2 = 21;
						num12 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_02bc;
						IL_02bc:
						if (num6 <= num12)
						{
							goto IL_026b;
						}
						goto IL_02c2;
						IL_02c2:
						num2 = 24;
						num13 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_04cf;
						IL_04cf:
						if (DC_Main.i <= num13)
						{
							goto IL_02df;
						}
						goto IL_04dc;
						IL_04dc:
						num2 = 41;
						colorConverter = new ColorConverter();
						goto IL_04e6;
						IL_04e6:
						num2 = 42;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0539;
						IL_0539:
						num2 = 43;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_058e;
						IL_058e:
						num2 = 44;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_05e6;
						IL_05e6:
						num2 = 45;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0654;
						IL_0654:
						num2 = 46;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0697;
						IL_0697:
						num2 = 47;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_06c6;
						IL_06c6:
						num2 = 48;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0709;
						IL_0709:
						num2 = 49;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_074a;
						IL_074a:
						num2 = 50;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_076b;
						IL_076b:
						num2 = 51;
						Cursor.Current = Cursors.Default;
						goto IL_0779;
						IL_0779:
						num2 = 52;
						NewLateBinding.LateCall(obj2, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0793;
						IL_0793:
						num2 = 53;
						obj = null;
						goto IL_0799;
						IL_0799:
						num2 = 54;
						obj3 = null;
						goto IL_079f;
						IL_079f:
						num2 = 55;
						obj2 = null;
						break;
						IL_02df:
						num2 = 25;
						num14 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_04b7;
						IL_04b7:
						if (num5 <= num14)
						{
							goto IL_02f9;
						}
						goto IL_04c0;
						IL_04c0:
						num2 = 39;
						DC_Main.i++;
						goto IL_04cf;
						IL_02f9:
						num2 = 26;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_0318;
						}
						goto IL_045a;
						IL_0318:
						num2 = 27;
						if (num5 == 1)
						{
							goto IL_0326;
						}
						goto IL_0393;
						IL_0326:
						num2 = 28;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							Strings.Format((object)Conversions.ToDate(((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()), "dd/MM/yyyy")
						}, (string[])null, (Type[])null);
						goto IL_04ae;
						IL_0393:
						num2 = 30;
						if (num5 == 6)
						{
							goto IL_03a1;
						}
						goto IL_0402;
						IL_03a1:
						num2 = 31;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							Conversions.ToDouble(((DataGridView)DGV)[num5, DC_Main.i].Value.ToString())
						}, (string[])null, (Type[])null);
						goto IL_04ae;
						IL_0402:
						num2 = 33;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_04ae;
						end_IL_0001_2:
						break;
					}
					num2 = 56;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 2214;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	private void RP_MOVEMENT_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Expected O, but got Unknown
		//IL_0d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2b: Expected O, but got Unknown
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de6: Expected O, but got Unknown
		//IL_0e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7d: Expected O, but got Unknown
		//IL_0eef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efa: Expected O, but got Unknown
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbb: Expected O, but got Unknown
		//IL_0fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe9: Expected O, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1017: Expected O, but got Unknown
		//IL_1099: Unknown result type (might be due to invalid IL or missing references)
		//IL_109e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a8: Expected O, but got Unknown
		//IL_10c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d6: Expected O, but got Unknown
		//IL_10f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1104: Expected O, but got Unknown
		//IL_1186: Unknown result type (might be due to invalid IL or missing references)
		//IL_118b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1195: Expected O, but got Unknown
		//IL_11b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c3: Expected O, but got Unknown
		//IL_11e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f1: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)Panel1).Controls)
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
				object? obj2 = colorConverter.ConvertFromString("Gainsboro");
				((Form)this).BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
				Label obj3 = lblBook;
				object? obj4 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj3).BackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
				Label obj5 = lblBook;
				object? obj6 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj5).ForeColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				ComboBox obj14 = cboItemTyp;
				object? obj15 = colorConverter.ConvertFromString("243, 240, 239");
				obj14.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj16 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj17 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj19 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj21 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				Panel panel = Panel1;
				object? obj23 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				ComboBox obj24 = cboItemTyp;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				obj24.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj26 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj27 = lblBook;
				object? obj28 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj27).ForeColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj29 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV3 = DGV;
				object? obj30 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj32 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj34 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj35 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				Panel panel2 = Panel1;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mFromDt).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font2 = ((Control)mFromDt).Font;
				try
				{
					foreach (object control5 in ((Control)Panel1).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font3 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_VCH).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_VCH).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_VCH).RowTemplate.Height * (1.0 + num2));
				}
			}
			cboItemTyp.Items.Add((object)"");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"RealStone");
			cboItemTyp.Items.Add((object)"Emetation");
			cboItemTyp.Items.Add((object)"Other");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 1;
			}
			else
			{
				cboItemTyp.SelectedIndex = 2;
			}
			cboMoveType.Items.Add((object)"Amount");
			cboMoveType.Items.Add((object)"NetWt");
			cboMoveType.Items.Add((object)"FineWt");
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				cboMoveType.SelectedIndex = 2;
			}
			else
			{
				cboMoveType.SelectedIndex = 1;
			}
			cboSalesType.Items.Add((object)"");
			cboSalesType.Items.Add((object)"Retail");
			cboSalesType.Items.Add((object)"WhSale");
			cboSalesType.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_CITY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCity.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_STATE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_STATE ORDER BY AC_STATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboState.Items.Clear();
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
				{
					cboState.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_STATE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboState.Items.Add((object)"");
			}
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
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
		mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 1;
		}
		else
		{
			cboItemTyp.SelectedIndex = 2;
		}
		if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
		{
			cboMoveType.SelectedIndex = 2;
		}
		else
		{
			cboMoveType.SelectedIndex = 1;
		}
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
		DGV_CLEAR();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
		{
			((DataGridView)DGV_VCH).DataSource = null;
			((DataGridView)DGV_VCH).ClearSelection();
			((DataGridView)DGV_VCH).Rows.Clear();
			((Control)DGV_VCH).Refresh();
			BtnExit.Text = "&Back";
			((Control)DGV_DETL).Visible = true;
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((Control)DGV_DETL).Refresh();
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_MOVEMENT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_MOVEMENT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_MOVEMENT_KeyDown(object sender, KeyEventArgs e)
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
		if ((((int)e.KeyCode == 38) | ((int)e.KeyCode == 40)) && !((Control)PnlIt).Visible)
		{
			((Control)DGV).Focus();
		}
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

	private void RP_MOVEMENT_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void RP_LEDR_Closed(object sender, EventArgs e)
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

	private void DGV_VCH_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)
		{
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "'  AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[12].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[3].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL2 = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL2).Show();
			((Control)tR_TAG_OPBL2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "STOCK ADJUST", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN2).Show();
			((Control)tR_TAG_CAN2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "APR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON ISU", false) == 0))
		{
			TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
			((Form)tR_APR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU).Show();
			((Control)tR_APR_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "APR RTN", false) == 0)
		{
			TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
			((Form)tR_APR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU2).Show();
			((Control)tR_APR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN3 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN3).Show();
			((Control)tR_TAG_CAN3).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CARD ADJUST", false) == 0)
		{
			TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
			((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CARD_REC).Show();
			((Control)tR_CARD_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
	}

	private void chkWtType_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
	}

	private void tLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE";
				DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 70.0;
				DC_Main.ColWidth[1] = 280.0;
				DC_Main.ColWidth[2] = 300.0;
				DC_Main.ColWidth[3] = 250.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tLcCode.Text = DC_Main.ColValue[0];
					((TextBoxBase)tLcCode).SelectAll();
				}
			}
		}
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		DGV_CLEAR();
	}

	private void ChkItmSelect_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkItmSelect_Click(object sender, EventArgs e)
	{
		if (chkItmSelect.Checked)
		{
			((DataGridView)DGV_ITM).DataSource = null;
			((DataGridView)DGV_ITM).ClearSelection();
			((DataGridView)DGV_ITM).Rows.Clear();
			((Control)DGV_ITM).Refresh();
			SelectIt = "";
			ItmList();
			((Control)PnlIt).Visible = true;
		}
		else
		{
			((DataGridView)DGV_ITM).DataSource = null;
			((DataGridView)DGV_ITM).ClearSelection();
			((DataGridView)DGV_ITM).Rows.Clear();
			((Control)DGV_ITM).Refresh();
			SelectIt = "";
			((Control)PnlIt).Visible = false;
		}
	}

	private void ItmList()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" ORDER BY A.IT_NAME "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV_ITM).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_ITM = DGV_ITM;
				((DataGridView)dGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV_ITM).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV_ITM).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV_ITM).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "Sr");
				((DataGridView)dGV_ITM).Columns[1].Width = 40;
				((DataGridView)dGV_ITM).Columns.Add("", "Itm Name");
				((DataGridView)dGV_ITM).Columns[2].Width = 224;
				((DataGridView)dGV_ITM).Columns.Add("", "It Code");
				((DataGridView)dGV_ITM).Columns[3].Width = 80;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV_ITM).Rows.Add();
					((DataGridView)dGV_ITM)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV_ITM)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"]);
					((DataGridView)dGV_ITM)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]);
					DC_Main.i++;
				}
				dGV_ITM = null;
			}
		}
	}

	private void BtnItCancel_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		chkItmSelect.Checked = false;
		((Control)PnlIt).Visible = false;
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		SelectIt = "";
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false))
				{
					SelectIt = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(SelectIt + "'"), ((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells[3].Value), (object)"',"));
				}
				DC_Main.M++;
			}
			if (Operators.CompareString(SelectIt, "", false) == 0)
			{
				Interaction.MsgBox((object)"Item Selection Not Done...", (MsgBoxStyle)0, (object)null);
				((Control)PnlIt).Visible = false;
			}
			else
			{
				SelectIt = Strings.Mid(SelectIt, 1, Strings.Len(SelectIt) - 1);
				((Control)PnlIt).Visible = false;
			}
		}
	}

	private void BtnAll_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value = true;
				DC_Main.M++;
			}
		}
	}

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_GR = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_GR_NAME As GrNameL,AC_GR as GrCodeL,AC_SUB_GR as GroupTypeL FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY AC_GR";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tGrCode.Text = DC_Main.ColValue[1];
					tGrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_GR_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		//IL_12dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e7: Expected O, but got Unknown
		//IL_1319: Unknown result type (might be due to invalid IL or missing references)
		//IL_131e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1328: Expected O, but got Unknown
		//IL_133e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1343: Unknown result type (might be due to invalid IL or missing references)
		//IL_134d: Expected O, but got Unknown
		//IL_1363: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Unknown result type (might be due to invalid IL or missing references)
		//IL_1372: Expected O, but got Unknown
		//IL_1b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b27: Expected O, but got Unknown
		((Control)DGV_DETL).Visible = false;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Columns.Clear();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Back1";
		int columnIndex = ((DataGridView)DGV_DETL).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
		if (Operators.CompareString(StkType, "Party", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		else if (Operators.CompareString(StkType, "Karigar", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.KR_NAME = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		else if (Operators.CompareString(StkType, "Employe", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.EMP_CODE = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		else if (Operators.CompareString(StkType, "City", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.AC_CITY = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		else if (Operators.CompareString(StkType, "State", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.AC_STATE = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		else if (Operators.CompareString(StkType, "Area", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.AC_AREA = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		else if (Operators.CompareString(StkType, "Product", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,A.NET_AMT,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND D.PR_CODE = '"), ((DataGridView)DGV_DETL)[11, index].Value), (object)"' AND C.KR_NAME = '"), ((DataGridView)DGV_DETL)[9, index].Value), (object)"' AND A.TR_TYPE = 'S' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE NOT IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
		}
		RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsStk);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_VCH).MultiSelect = false;
		((DataGridView)DGV_VCH).AutoGenerateColumns = false;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_VCH).ColumnCount = 16;
		checked
		{
			((DataGridView)DGV_VCH).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV_VCH).Rows.Count);
			((DataGridView)DGV_VCH).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_VCH).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[1].DataPropertyName = "BOOK_SNAME";
			((DataGridView)DGV_VCH).Columns[1].HeaderText = "Vchtype";
			((DataGridView)DGV_VCH).Columns[2].Width = (int)Math.Round(175.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[2].DataPropertyName = "AC_NAME";
			((DataGridView)DGV_VCH).Columns[2].HeaderText = "Party Name";
			((DataGridView)DGV_VCH).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[3].DataPropertyName = "VCH_NO";
			((DataGridView)DGV_VCH).Columns[3].HeaderText = "VchNo";
			((DataGridView)DGV_VCH).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[4].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV_VCH).Columns[4].HeaderText = "VchDate";
			((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[5].DataPropertyName = "TAG_NO";
			((DataGridView)DGV_VCH).Columns[5].HeaderText = "TagNo";
			((DataGridView)DGV_VCH).Columns[6].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[6].DataPropertyName = "IT_NAME";
			((DataGridView)DGV_VCH).Columns[6].HeaderText = "ItName";
			((DataGridView)DGV_VCH).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[7].DataPropertyName = "ITM_PCS";
			((DataGridView)DGV_VCH).Columns[7].HeaderText = "Pcs";
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[8].DataPropertyName = "ITM_GWT";
			((DataGridView)DGV_VCH).Columns[8].HeaderText = "GrWt";
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DataPropertyName = "ITM_NWT";
			((DataGridView)DGV_VCH).Columns[9].HeaderText = "NetWt";
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DataPropertyName = "ITM_FINE";
			((DataGridView)DGV_VCH).Columns[10].HeaderText = "Fine";
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DataPropertyName = "NET_AMT";
			((DataGridView)DGV_VCH).Columns[11].HeaderText = "NetAmt";
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns[12].Visible = false;
			((DataGridView)DGV_VCH).Columns[12].DataPropertyName = "CO_BOOK";
			((DataGridView)DGV_VCH).Columns[12].HeaderText = "Book";
			((DataGridView)DGV_VCH).Columns[13].Visible = false;
			((DataGridView)DGV_VCH).Columns[13].DataPropertyName = "MAIN_BOOK";
			((DataGridView)DGV_VCH).Columns[13].HeaderText = "BooKName";
			((DataGridView)DGV_VCH).Columns[14].Visible = false;
			((DataGridView)DGV_VCH).Columns[14].DataPropertyName = "IT_CODE";
			((DataGridView)DGV_VCH).Columns[14].HeaderText = "ItCode";
			((DataGridView)DGV_VCH).Columns[15].Visible = false;
			((DataGridView)DGV_VCH).Columns[15].DataPropertyName = "AC_CODE";
			((DataGridView)DGV_VCH).Columns[15].HeaderText = "AcCode";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV_VCH).DataSource = dataView;
			if (((DataGridView)DGV_VCH).Rows.Count >= 1)
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			int num6 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			for (int i = 0; i <= num6; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV_VCH).Rows[i].Cells[0].Value = i + 1;
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""));
				}
			}
			if (((DataGridView)DGV_VCH).Rows.Count > 1)
			{
				int num7 = ((DataGridView)DGV_VCH).Rows.Count - 1;
				((DataGridView)DGV_VCH).Rows[num7].Cells[2].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num7].Cells[7].Value = num;
				((DataGridView)DGV_VCH).Rows[num7].Cells[8].Value = num2;
				((DataGridView)DGV_VCH).Rows[num7].Cells[9].Value = num3;
				((DataGridView)DGV_VCH).Rows[num7].Cells[10].Value = num4;
				((DataGridView)DGV_VCH).Rows[num7].Cells[11].Value = num5;
			}
		}
	}

	private void BtnState_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "State";
		PartySales();
	}
}
