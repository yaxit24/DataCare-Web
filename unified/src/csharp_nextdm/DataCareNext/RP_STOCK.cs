using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_STOCK : Form
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
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DataGridViewX _DGV_VCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGroup")]
	private QButton _BtnGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnProduct")]
	private QButton _BtnProduct;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItem")]
	private QButton _BtnItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDesign")]
	private QButton _BtnDesign;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSafe")]
	private QButton _BtnSafe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTable")]
	private QButton _BtnTable;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTrading")]
	private QButton _BtnTrading;

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
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItCancel")]
	private QButton _btnItCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAll")]
	private QButton _btnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSiz")]
	private QButton _BtnSiz;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDesignNo")]
	private TextBox _tDesignNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWithOth")]
	private SimpleButton _btnWithOth;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private bool DgvLoad;

	private string SelectIt;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string StkType;

	private string[] AryTableCode;

	private const int cMSrNo = 0;

	private const int cMItCode = 1;

	private const int cMItName = 2;

	private const int cMItType = 3;

	private const int cMOpPcs = 4;

	private const int cMOpWt = 5;

	private const int cMPrPcs = 6;

	private const int cMPrWt = 7;

	private const int cMInPcs = 8;

	private const int cMInWt = 9;

	private const int cMOutPcs = 10;

	private const int cMOutWt = 11;

	private const int cMSlPcs = 12;

	private const int cMSlWt = 13;

	private const int cMClPcs = 14;

	private const int cMClWt = 15;

	private const int cMTOutPcs = 16;

	private const int cMTOutWt = 17;

	private const int cMTInPcs = 18;

	private const int cMTInWt = 19;

	private const int cMTDifP = 20;

	private const int cMTDifW = 21;

	private const int cSrNo = 0;

	private const int cBookType = 1;

	private const int cLdAcName = 2;

	private const int cVchNo = 3;

	private const int cVchDate = 4;

	private const int cTagNo = 5;

	private const int cItemName = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cNetWt = 9;

	private const int cFine = 10;

	private const int cSign = 11;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_CellContentClick);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewX val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((DataGridView)val3).CellFormatting -= val2;
			}
			_DGV = value;
			val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick += val;
				((Control)val3).DoubleClick += eventHandler;
				((DataGridView)val3).CellFormatting += val2;
			}
		}
	}

	internal virtual SearchControl tSerchAll
	{
		[CompilerGenerated]
		get
		{
			return _tSerchAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSerchAll_TextChanged;
			SearchControl val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSerchAll = value;
			val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboStockType")]
	private virtual ComboBox _cboStockType;

	internal virtual ComboBox cboStockType
	{
		get
		{
			return _cboStockType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboStockType = value;
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

	internal virtual DataGridViewX DGV_VCH
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_VCH_CellContentClick);
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			DataGridViewX val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick -= val;
				((DataGridView)val3).CellFormatting -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV_VCH = value;
			val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick += val;
				((DataGridView)val3).CellFormatting += val2;
				((Control)val3).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual QButton BtnGroup
	{
		[CompilerGenerated]
		get
		{
			return _BtnGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGroup_Click;
			QButton val = _BtnGroup;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGroup = value;
			val = _BtnGroup;
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

	internal virtual QButton BtnItem
	{
		[CompilerGenerated]
		get
		{
			return _BtnItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItem_Click;
			QButton val = _BtnItem;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItem = value;
			val = _BtnItem;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnDesign
	{
		[CompilerGenerated]
		get
		{
			return _BtnDesign;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDesign_Click;
			QButton val = _BtnDesign;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDesign = value;
			val = _BtnDesign;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnSafe
	{
		[CompilerGenerated]
		get
		{
			return _BtnSafe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSafe_Click;
			QButton val = _BtnSafe;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSafe = value;
			val = _BtnSafe;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnTable
	{
		[CompilerGenerated]
		get
		{
			return _BtnTable;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTable_Click;
			QButton val = _BtnTable;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTable = value;
			val = _BtnTable;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnTrading
	{
		[CompilerGenerated]
		get
		{
			return _BtnTrading;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTrading_Click;
			QButton val = _BtnTrading;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTrading = value;
			val = _BtnTrading;
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
			EventHandler eventHandler = tGrCode_TextChanged;
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox tPrCode
	{
		[CompilerGenerated]
		get
		{
			return _tPrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrCode_KeyDown);
			EventHandler eventHandler = tPrCode_TextChanged;
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSafe")]
	private virtual ComboBox _cboSafe;

	internal virtual ComboBox cboSafe
	{
		get
		{
			return _cboSafe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSafe = value;
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
	[AccessedThroughProperty("cboTable")]
	private virtual ComboBox _cboTable;

	internal virtual ComboBox cboTable
	{
		get
		{
			return _cboTable;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTable = value;
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
			EventHandler eventHandler = btnOk_Click;
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
	private virtual DataGridViewX _DGV_ITM;

	internal virtual DataGridViewX DGV_ITM
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
			EventHandler eventHandler = btnItCancel_Click;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagNo")]
	private virtual TextBox _tTagNo;

	internal virtual TextBox tTagNo
	{
		get
		{
			return _tTagNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTagNo = value;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tLcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tLcCode_KeyDown);
			TextBox val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tLcCode = value;
			val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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

	internal virtual QButton BtnSiz
	{
		[CompilerGenerated]
		get
		{
			return _BtnSiz;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSiz_Click;
			QButton val = _BtnSiz;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSiz = value;
			val = _BtnSiz;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tItCode
	{
		[CompilerGenerated]
		get
		{
			return _tItCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItCode = value;
			val2 = _tItCode;
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

	internal virtual TextBox tDesignNo
	{
		[CompilerGenerated]
		get
		{
			return _tDesignNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tDesignNo_KeyDown);
			TextBox val2 = _tDesignNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tDesignNo = value;
			val2 = _tDesignNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton btnWithOth
	{
		[CompilerGenerated]
		get
		{
			return _btnWithOth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnWithOth_Click;
			SimpleButton val = _btnWithOth;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWithOth = value;
			val = _btnWithOth;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

	public RP_STOCK()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_STOCK_Load;
		((Form)this).Deactivate += RP_STOCK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_STOCK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_STOCK_KeyDown);
		((Form)this).Activated += RP_STOCK_Activated;
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
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Expected O, but got Unknown
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Expected O, but got Unknown
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Expected O, but got Unknown
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_091d: Expected O, but got Unknown
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_098a: Expected O, but got Unknown
		//IL_0a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Expected O, but got Unknown
		//IL_0aa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aaa: Expected O, but got Unknown
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected O, but got Unknown
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c11: Expected O, but got Unknown
		//IL_0ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Expected O, but got Unknown
		//IL_0d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d89: Expected O, but got Unknown
		//IL_0e07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e11: Expected O, but got Unknown
		//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efd: Expected O, but got Unknown
		//IL_0f66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f70: Expected O, but got Unknown
		//IL_1031: Unknown result type (might be due to invalid IL or missing references)
		//IL_103b: Expected O, but got Unknown
		//IL_10b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bf: Expected O, but got Unknown
		//IL_10c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c7: Expected O, but got Unknown
		//IL_1138: Unknown result type (might be due to invalid IL or missing references)
		//IL_1142: Expected O, but got Unknown
		//IL_11ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b5: Expected O, but got Unknown
		//IL_15ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1613: Unknown result type (might be due to invalid IL or missing references)
		//IL_1637: Unknown result type (might be due to invalid IL or missing references)
		//IL_165b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1684: Unknown result type (might be due to invalid IL or missing references)
		//IL_168e: Expected O, but got Unknown
		//IL_16b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1915: Unknown result type (might be due to invalid IL or missing references)
		//IL_1939: Unknown result type (might be due to invalid IL or missing references)
		//IL_195d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1981: Unknown result type (might be due to invalid IL or missing references)
		//IL_19aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b4: Expected O, but got Unknown
		//IL_19da: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cdd: Expected O, but got Unknown
		//IL_1d03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da3: Expected O, but got Unknown
		//IL_1e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e49: Expected O, but got Unknown
		//IL_1ecf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed9: Expected O, but got Unknown
		//IL_1fb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbd: Expected O, but got Unknown
		//IL_2026: Unknown result type (might be due to invalid IL or missing references)
		//IL_2030: Expected O, but got Unknown
		//IL_2102: Unknown result type (might be due to invalid IL or missing references)
		//IL_210c: Expected O, but got Unknown
		//IL_21a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b2: Expected O, but got Unknown
		//IL_2238: Unknown result type (might be due to invalid IL or missing references)
		//IL_2242: Expected O, but got Unknown
		//IL_2329: Unknown result type (might be due to invalid IL or missing references)
		//IL_2333: Expected O, but got Unknown
		//IL_239c: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a6: Expected O, but got Unknown
		//IL_2454: Unknown result type (might be due to invalid IL or missing references)
		//IL_245e: Expected O, but got Unknown
		//IL_24c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d1: Expected O, but got Unknown
		//IL_276c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2790: Unknown result type (might be due to invalid IL or missing references)
		//IL_27b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2801: Unknown result type (might be due to invalid IL or missing references)
		//IL_280b: Expected O, but got Unknown
		//IL_282b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ad6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b2f: Expected O, but got Unknown
		//IL_2b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e21: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e54: Expected O, but got Unknown
		//IL_2e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_30da: Unknown result type (might be due to invalid IL or missing references)
		//IL_30fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_3122: Unknown result type (might be due to invalid IL or missing references)
		//IL_3146: Unknown result type (might be due to invalid IL or missing references)
		//IL_316f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3179: Expected O, but got Unknown
		//IL_319c: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3423: Unknown result type (might be due to invalid IL or missing references)
		//IL_3447: Unknown result type (might be due to invalid IL or missing references)
		//IL_346b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3494: Unknown result type (might be due to invalid IL or missing references)
		//IL_349e: Expected O, but got Unknown
		//IL_34c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3725: Unknown result type (might be due to invalid IL or missing references)
		//IL_3749: Unknown result type (might be due to invalid IL or missing references)
		//IL_376d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3791: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_37c4: Expected O, but got Unknown
		//IL_37e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a93: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aea: Expected O, but got Unknown
		//IL_3b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b84: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b8e: Expected O, but got Unknown
		//IL_3c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c2c: Expected O, but got Unknown
		//IL_3caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cb9: Expected O, but got Unknown
		//IL_3d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d7d: Expected O, but got Unknown
		//IL_3e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e37: Expected O, but got Unknown
		//IL_3ee5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eef: Expected O, but got Unknown
		//IL_3f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f66: Expected O, but got Unknown
		//IL_4014: Unknown result type (might be due to invalid IL or missing references)
		//IL_401e: Expected O, but got Unknown
		//IL_408b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4095: Expected O, but got Unknown
		//IL_414d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4157: Expected O, but got Unknown
		//IL_41d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_41dc: Expected O, but got Unknown
		//IL_4297: Unknown result type (might be due to invalid IL or missing references)
		//IL_42a1: Expected O, but got Unknown
		//IL_431c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4326: Expected O, but got Unknown
		//IL_43c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_43cd: Expected O, but got Unknown
		//IL_446a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4474: Expected O, but got Unknown
		//IL_44f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4500: Expected O, but got Unknown
		//IL_47a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_47c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_47e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_480c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4835: Unknown result type (might be due to invalid IL or missing references)
		//IL_483f: Expected O, but got Unknown
		//IL_4862: Unknown result type (might be due to invalid IL or missing references)
		//IL_48c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_48d2: Expected O, but got Unknown
		//IL_496f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4979: Expected O, but got Unknown
		//IL_49e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_49f1: Expected O, but got Unknown
		//IL_4a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4aa9: Expected O, but got Unknown
		//IL_4b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b20: Expected O, but got Unknown
		//IL_4bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bd8: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_STOCK));
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
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnWithOth = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV = new DataGridViewX();
		tSerchAll = new SearchControl();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		PnlIt = new Panel();
		btnAll = new QButton();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DataGridViewX();
		DGV_VCH = new DataGridViewX();
		cboStockType = new ComboBox();
		Label1 = new Label();
		BtnGroup = new QButton();
		BtnProduct = new QButton();
		BtnItem = new QButton();
		BtnDesign = new QButton();
		BtnSafe = new QButton();
		BtnTable = new QButton();
		BtnTrading = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		chkWtType = new CheckBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		Label9 = new Label();
		tPrCode = new TextBox();
		Label4 = new Label();
		cboSafe = new ComboBox();
		Label14 = new Label();
		cboTable = new ComboBox();
		Label5 = new Label();
		Label6 = new Label();
		tTagNo = new TextBox();
		tLcCode = new TextBox();
		BtnSiz = new QButton();
		Label7 = new Label();
		tAcCode = new TextBox();
		Label8 = new Label();
		tItCode = new TextBox();
		Label11 = new Label();
		tDesignNo = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((Control)Panel1).SuspendLayout();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
		((ISupportInitialize)DGV_VCH).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnWithOth);
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
		BtnDelete.Text = "&InOut";
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
		((BaseStyleControl)btnWithOth).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnWithOth).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnWithOth).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnWithOth).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnWithOth.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnWithOth.ImageOptions.SvgImage");
		((Control)btnWithOth).Location = new Point(730, 3);
		((BaseControl)btnWithOth).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnWithOth).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnWithOth).Name = "btnWithOth";
		((Control)btnWithOth).Size = new Size(91, 37);
		((Control)btnWithOth).TabIndex = 11;
		btnWithOth.Text = "OthDtl";
		((BaseButton)btnWithOth).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnWithOth).Visible = false;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(696, 3);
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
		lblBook.Text = "Stock Report";
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
		((Control)DGV).Location = new Point(11, 10);
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
		((Control)DGV).Size = new Size(1160, 408);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 2;
		((Control)tSerchAll).Location = new Point(61, 70);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((RepositoryItem)tSerchAll.Properties).BorderStyle = (BorderStyles)1;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Advance Search";
		((Control)tSerchAll).Size = new Size(158, 22);
		((Control)tSerchAll).TabIndex = 2;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(336, 41);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(99, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(245, 40);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(81, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.FromArgb(255, 224, 192);
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)PnlIt);
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Controls.Add((Control)(object)DGV_VCH);
		((Control)Panel1).Location = new Point(0, 133);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 431);
		((Control)Panel1).TabIndex = 110;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnAll);
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(713, 120);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1206;
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
		((Control)btnAll).Location = new Point(53, 249);
		((Control)btnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAll).Name = "btnAll";
		((Control)btnAll).Size = new Size(100, 38);
		((Control)btnAll).TabIndex = 1159;
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
		((Control)btnItCancel).Location = new Point(317, 249);
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
		((Control)btnOk).Location = new Point(184, 249);
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
		((DataGridView)DGV_VCH).AllowUserToAddRows = false;
		((DataGridView)DGV_VCH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_VCH).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_VCH).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_VCH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_VCH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_VCH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_VCH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).DefaultCellStyle = val13;
		((DataGridView)DGV_VCH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_VCH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_VCH).Location = new Point(11, 11);
		((Control)DGV_VCH).Name = "DGV_VCH";
		DGV_VCH.PaintEnhancedSelection = false;
		((DataGridView)DGV_VCH).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_VCH).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_VCH).RowHeadersVisible = false;
		((DataGridView)DGV_VCH).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_VCH).RowsDefaultCellStyle = val15;
		DGV_VCH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_VCH.SelectAllSignVisible = false;
		((DataGridView)DGV_VCH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_VCH).Size = new Size(1158, 406);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 3;
		cboStockType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboStockType).Font = new Font("Tahoma", 9f);
		((ListControl)cboStockType).FormattingEnabled = true;
		((Control)cboStockType).Location = new Point(337, 70);
		((Control)cboStockType).Name = "cboStockType";
		((Control)cboStockType).Size = new Size(98, 22);
		((Control)cboStockType).TabIndex = 4;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(235, 68);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(91, 20);
		((Control)Label1).TabIndex = 112;
		Label1.Text = "Stock Type";
		Label1.TextAlign = (ContentAlignment)64;
		((QControl)BtnGroup).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGroup).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroup).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGroup).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGroup).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGroup).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroup).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGroup).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGroup).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGroup).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGroup).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGroup).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGroup).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGroup).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGroup.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Image = null;
		((QControl)BtnGroup).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGroup).Location = new Point(27, 101);
		((Control)BtnGroup).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroup).Name = "BtnGroup";
		((Control)BtnGroup).Size = new Size(130, 37);
		((Control)BtnGroup).TabIndex = 7;
		BtnGroup.Text = "&Group";
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
		((QControl)BtnProduct).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)BtnProduct).Location = new Point(311, 101);
		((Control)BtnProduct).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnProduct).Name = "BtnProduct";
		((Control)BtnProduct).Size = new Size(130, 37);
		((Control)BtnProduct).TabIndex = 6;
		BtnProduct.Text = "&Product";
		((QControl)BtnItem).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnItem).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItem).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnItem).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnItem).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnItem).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItem).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItem).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnItem).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnItem).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnItem).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItem).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnItem).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnItem).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnItem.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Image = null;
		((QControl)BtnItem).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnItem).Location = new Point(453, 101);
		((Control)BtnItem).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItem).Name = "BtnItem";
		((Control)BtnItem).Size = new Size(130, 37);
		((Control)BtnItem).TabIndex = 5;
		BtnItem.Text = "&Item";
		((QControl)BtnDesign).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDesign).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDesign).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDesign).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDesign).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDesign).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDesign).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDesign).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDesign).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDesign).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDesign).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDesign).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDesign).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDesign).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDesign.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDesign.Image = null;
		((QControl)BtnDesign).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDesign).Location = new Point(595, 101);
		((Control)BtnDesign).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDesign).Name = "BtnDesign";
		((Control)BtnDesign).Size = new Size(130, 37);
		((Control)BtnDesign).TabIndex = 8;
		BtnDesign.Text = "&Design";
		((QControl)BtnSafe).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSafe).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSafe).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSafe).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSafe).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSafe).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSafe).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSafe).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSafe).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSafe).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSafe).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSafe).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSafe).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSafe).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSafe.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSafe.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSafe.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSafe.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSafe.Image = null;
		((QControl)BtnSafe).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSafe).Location = new Point(879, 101);
		((Control)BtnSafe).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSafe).Name = "BtnSafe";
		((Control)BtnSafe).Size = new Size(130, 37);
		((Control)BtnSafe).TabIndex = 9;
		BtnSafe.Text = "&Safe";
		((QControl)BtnTable).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTable).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTable).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTable).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTable).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTable).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTable).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTable).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTable).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTable).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTable).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTable).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTable).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTable).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTable.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTable.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTable.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTable.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTable.Image = null;
		((QControl)BtnTable).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTable).Location = new Point(169, 101);
		((Control)BtnTable).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTable).Name = "BtnTable";
		((Control)BtnTable).Size = new Size(130, 37);
		((Control)BtnTable).TabIndex = 10;
		BtnTable.Text = "&Counter";
		((QControl)BtnTrading).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTrading).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTrading).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTrading).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTrading).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTrading).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTrading).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTrading).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTrading).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTrading).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTrading).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTrading).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTrading).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTrading).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTrading.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Image = null;
		((QControl)BtnTrading).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTrading).Location = new Point(1021, 101);
		((Control)BtnTrading).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTrading).Name = "BtnTrading";
		((Control)BtnTrading).Size = new Size(130, 37);
		((Control)BtnTrading).TabIndex = 11;
		BtnTrading.Text = "T&rading";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(61, 40);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(143, 40);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 41);
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
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(459, 39);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 20);
		((Control)Label10).TabIndex = 1167;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(529, 41);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(53, 22);
		((Control)tGrCode).TabIndex = 1166;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(461, 68);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(60, 20);
		((Control)Label9).TabIndex = 1164;
		Label9.Text = "Pr Code";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(529, 70);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(53, 22);
		((Control)tPrCode).TabIndex = 1163;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(11, 70);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(44, 20);
		((Control)Label4).TabIndex = 1169;
		Label4.Text = "Item";
		Label4.TextAlign = (ContentAlignment)64;
		cboSafe.AutoCompleteMode = (AutoCompleteMode)3;
		cboSafe.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSafe).Font = new Font("Tahoma", 9f);
		((ListControl)cboSafe).FormattingEnabled = true;
		((Control)cboSafe).Location = new Point(836, 41);
		cboSafe.MaxLength = 25;
		((Control)cboSafe).Name = "cboSafe";
		((Control)cboSafe).Size = new Size(112, 22);
		((Control)cboSafe).TabIndex = 1170;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(756, 42);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(72, 20);
		((Control)Label14).TabIndex = 1171;
		Label14.Text = "Safe";
		Label14.TextAlign = (ContentAlignment)64;
		cboTable.AutoCompleteMode = (AutoCompleteMode)3;
		cboTable.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTable).Font = new Font("Tahoma", 9f);
		((ListControl)cboTable).FormattingEnabled = true;
		((Control)cboTable).Location = new Point(837, 70);
		cboTable.MaxLength = 25;
		((Control)cboTable).Name = "cboTable";
		((Control)cboTable).Size = new Size(111, 22);
		((Control)cboTable).TabIndex = 1172;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(756, 70);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(73, 20);
		((Control)Label5).TabIndex = 1173;
		Label5.Text = "Counter";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(962, 42);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(61, 20);
		((Control)Label6).TabIndex = 1175;
		Label6.Text = "TagNo";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(1029, 41);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(83, 22);
		((Control)tTagNo).TabIndex = 1174;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1069, 6);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1176;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((QControl)BtnSiz).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSiz).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSiz).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSiz).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSiz).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSiz).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSiz).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSiz).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSiz).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSiz).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSiz).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSiz).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSiz).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSiz).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSiz.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSiz.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSiz.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSiz.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSiz.Image = null;
		((QControl)BtnSiz).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSiz).Location = new Point(737, 101);
		((Control)BtnSiz).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSiz).Name = "BtnSiz";
		((Control)BtnSiz).Size = new Size(130, 37);
		((Control)BtnSiz).TabIndex = 1177;
		BtnSiz.Text = "&Size";
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(955, 72);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(69, 20);
		((Control)Label7).TabIndex = 1179;
		Label7.Text = "AcCode";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(1029, 70);
		((TextBoxBase)tAcCode).MaxLength = 15;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(83, 22);
		((Control)tAcCode).TabIndex = 1178;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(586, 42);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(64, 20);
		((Control)Label8).TabIndex = 1181;
		Label8.Text = "It Code";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9f);
		((Control)tItCode).Location = new Point(656, 41);
		((TextBoxBase)tItCode).MaxLength = 6;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(97, 22);
		((Control)tItCode).TabIndex = 1180;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(586, 69);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(64, 20);
		((Control)Label11).TabIndex = 1183;
		Label11.Text = "Design";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tDesignNo).BackColor = Color.White;
		((Control)tDesignNo).Font = new Font("Tahoma", 9f);
		((Control)tDesignNo).Location = new Point(656, 70);
		((TextBoxBase)tDesignNo).MaxLength = 15;
		((Control)tDesignNo).Name = "tDesignNo";
		((Control)tDesignNo).Size = new Size(97, 22);
		((Control)tDesignNo).TabIndex = 1182;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)tDesignNo);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)BtnSiz);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tTagNo);
		((Control)this).Controls.Add((Control)(object)cboTable);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)cboSafe);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)chkWtType);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)cboStockType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tSerchAll);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)BtnGroup);
		((Control)this).Controls.Add((Control)(object)BtnProduct);
		((Control)this).Controls.Add((Control)(object)BtnItem);
		((Control)this).Controls.Add((Control)(object)BtnDesign);
		((Control)this).Controls.Add((Control)(object)BtnSafe);
		((Control)this).Controls.Add((Control)(object)BtnTable);
		((Control)this).Controls.Add((Control)(object)BtnTrading);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_STOCK";
		((Form)this).Text = "Stock Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_261b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2625: Expected O, but got Unknown
		//IL_2657: Unknown result type (might be due to invalid IL or missing references)
		//IL_265c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2666: Expected O, but got Unknown
		//IL_267c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2681: Unknown result type (might be due to invalid IL or missing references)
		//IL_268b: Expected O, but got Unknown
		//IL_26a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b0: Expected O, but got Unknown
		//IL_2ebd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ec7: Expected O, but got Unknown
		((Control)DGV).Visible = false;
		((Control)tSerchAll).Enabled = false;
		BtnExit.Text = "&Back";
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		string text = "C.IT_CODE";
		string text2 = "H.IT_CODE";
		if (Operators.CompareString(StkType, "Item", false) == 0)
		{
			text = "C.IT_CODE";
			text2 = "H.IT_CODE";
		}
		else if (Operators.CompareString(StkType, "Product", false) == 0)
		{
			text = "C.PR_CODE";
			text2 = "H.PR_CODE";
		}
		else if (Operators.CompareString(StkType, "Group", false) == 0)
		{
			text = "C.GR_CODE";
			text2 = "H.GR_CODE";
		}
		else if (Operators.CompareString(StkType, "ItmSafe", false) == 0)
		{
			if ((Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0) | (Operators.CompareString(DC_Main.MsMeltingLotGenrate, "Y", false) == 0))
			{
				text = "A.ITM_LOT";
				text2 = "F.ITM_LOT";
			}
			else
			{
				text = "C.SAFE_NAME";
				text2 = "H.SAFE_NAME";
			}
		}
		else if (Operators.CompareString(StkType, "ItmSize", false) == 0)
		{
			text = "A.ITM_SIZE";
			text2 = "F.ITM_SIZE";
		}
		else if (Operators.CompareString(StkType, "Design", false) == 0)
		{
			text = "A.DESIGN_NO";
			text2 = "F.DESIGN_NO";
		}
		else if (Operators.CompareString(StkType, "Table", false) == 0)
		{
			text = "A.TBL_CODE";
			text2 = "F.TBL_CODE";
		}
		else if (Operators.CompareString(StkType, "Trad", false) == 0)
		{
			text = "C.TRAD_TYPE";
			text2 = "H.TRAD_TYPE";
		}
		DC_Main.RsQry = "SELECT TAG_NO,IT_CODE,ITM_PCS FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = 'EMP ISU' AND TAG_NO <> 'N' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if ((DC_Main.Tbl.Rows.Count == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) == 0))
		{
			switch (columnIndex)
			{
			default:
				return;
			case 4:
			case 5:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 6:
			case 7:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 8:
			case 9:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 10:
			case 11:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'-' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP ISU' AND F.ISU_REC = 'N' AND F.TAG_NO <> 'N' AND F.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), (object)" UNION ALL SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 12:
			case 13:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 14:
			case 15:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			}
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			if (columnIndex == 10 || columnIndex == 11)
			{
				DC_Main.RsQry += "ORDER BY F.VCH_DATE ";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.VCH_DATE ";
			}
		}
		else
		{
			switch (columnIndex)
			{
			default:
				return;
			case 4:
			case 5:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'+' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP REC' AND F.TAG_NO <> 'N' AND F.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" UNION ALL SELECT G.BOOK_SNAME,I.EMP_NAME As AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'-' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP ISU' AND F.TAG_NO <> 'N' AND F.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"), (object)" UNION ALL SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 6:
			case 7:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 8:
			case 9:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'+' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP REC' AND F.TAG_NO <> 'N' AND F.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), (object)" UNION ALL SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'+' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((RATE_CUT_ISU AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'TOUR SALES' AND F.TAG_NO <> 'N' AND F.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND F.ISU_DBCD = '500' "), (object)" UNION ALL SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 10:
			case 11:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'-' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP ISU' AND F.TAG_NO <> 'N' AND F.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), (object)" UNION ALL SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 12:
			case 13:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 14:
			case 15:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'+' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP REC' AND F.TAG_NO <> 'N' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" UNION ALL SELECT G.BOOK_SNAME,I.EMP_NAME As AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'-' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((APR_DETL AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'EMP ISU' AND F.TAG_NO <> 'N' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), (object)" UNION ALL SELECT G.BOOK_SNAME,I.EMP_NAME AS AC_NAME,F.VCH_NO,F.VCH_DATE,F.TAG_NO,H.IT_NAME,F.ITM_LOT,F.ITM_PCS,F.ITM_GWT,F.ITM_NWT,F.ITM_FINE As ItmFine,'+' AS ITM_SIGN,F.CO_BOOK,G.MAIN_BOOK,F.IT_CODE,F.AC_CODE FROM ((RATE_CUT_ISU AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK) LEFT JOIN ITEM_MAST AS H ON F.CO_CODE = H.CO_CODE AND F.IT_CODE = H.IT_CODE) LEFT JOIN EMP_MAST AS I ON F.CO_CODE = I.CO_CODE AND F.AC_CODE = I.EMP_CODE  WHERE F.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND F.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND "), (object)text2), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  H.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND F.BOOK_NAME = 'TOUR SALES' AND F.TAG_NO <> 'N' AND F.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND F.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND F.ISU_DBCD = '500' "), (object)" UNION ALL SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_LOT,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" "), (object)text), (object)" ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			}
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			if (columnIndex == 4 || columnIndex == 5)
			{
				DC_Main.RsQry += "ORDER BY F.VCH_DATE ";
			}
			else if (columnIndex == 6 || columnIndex == 7)
			{
				DC_Main.RsQry += "ORDER BY A.VCH_DATE ";
			}
			else if (columnIndex == 10 || columnIndex == 11)
			{
				DC_Main.RsQry += "ORDER BY F.VCH_DATE ";
			}
			else if (columnIndex == 8 || columnIndex == 9)
			{
				DC_Main.RsQry += "ORDER BY F.VCH_DATE ";
			}
			else if (columnIndex == 14 || columnIndex == 15)
			{
				DC_Main.RsQry += "ORDER BY F.VCH_DATE ";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.VCH_DATE ";
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
			((DataGridView)DGV_VCH).Columns[2].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[2].DataPropertyName = "AC_NAME";
			((DataGridView)DGV_VCH).Columns[2].HeaderText = "Party Name";
			((DataGridView)DGV_VCH).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[3].DataPropertyName = "VCH_NO";
			((DataGridView)DGV_VCH).Columns[3].HeaderText = "VchNo";
			((DataGridView)DGV_VCH).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[4].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV_VCH).Columns[4].HeaderText = "VchDate";
			if (Operators.CompareString(StkType, "ItmSafe", false) == 0)
			{
				((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_VCH).Columns[5].DataPropertyName = "ITM_LOT";
				((DataGridView)DGV_VCH).Columns[5].HeaderText = "Itm Lot";
			}
			else
			{
				((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_VCH).Columns[5].DataPropertyName = "TAG_NO";
				((DataGridView)DGV_VCH).Columns[5].HeaderText = "TagNo";
			}
			((DataGridView)DGV_VCH).Columns[6].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[6].DataPropertyName = "IT_NAME";
			((DataGridView)DGV_VCH).Columns[6].HeaderText = "ItName";
			((DataGridView)DGV_VCH).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[7].DataPropertyName = "ITM_PCS";
			((DataGridView)DGV_VCH).Columns[7].HeaderText = "Pcs";
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[8].DataPropertyName = "ITM_GWT";
			((DataGridView)DGV_VCH).Columns[8].HeaderText = "GrWt";
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DataPropertyName = "ITM_NWT";
			((DataGridView)DGV_VCH).Columns[9].HeaderText = "NetWt";
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DataPropertyName = "ItmFine";
			((DataGridView)DGV_VCH).Columns[10].HeaderText = "Fine";
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DataPropertyName = "ITM_SIGN";
			((DataGridView)DGV_VCH).Columns[11].HeaderText = "Sign";
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
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
			int num5 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			for (int i = 0; i <= num5; i++)
			{
				if (!Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					continue;
				}
				((DataGridView)DGV_VCH).Rows[i].Cells[0].Value = i + 1;
				unchecked
				{
					if (columnIndex == 14 || columnIndex == 15)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""), (object)"+", false))
						{
							num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
							num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
							num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
							num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
						}
						else
						{
							num -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
							num2 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
							num3 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
							num4 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
						}
					}
					else if (columnIndex == 4 || columnIndex == 5)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""), (object)"+", false))
						{
							num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
							num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
							num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
							num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
						}
						else
						{
							num -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
							num2 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
							num3 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
							num4 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
						}
					}
					else
					{
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
					}
				}
			}
			if (((DataGridView)DGV_VCH).Rows.Count > 1)
			{
				int num6 = ((DataGridView)DGV_VCH).Rows.Count - 1;
				((DataGridView)DGV_VCH).Rows[num6].Cells[2].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num6].Cells[7].Value = num;
				((DataGridView)DGV_VCH).Rows[num6].Cells[8].Value = num2;
				((DataGridView)DGV_VCH).Rows[num6].Cells[9].Value = num3;
				((DataGridView)DGV_VCH).Rows[num6].Cells[10].Value = num4;
			}
		}
	}

	private void DGV_VCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
		object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
		objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
		NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
		checked
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				int num = ((DataGridView)DGV_VCH).ColumnCount - 1;
				for (int i = 0; i <= num; i++)
				{
					NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
					{
						1,
						i + 1,
						((DataGridView)DGV_VCH).Columns[i].HeaderText
					}, (string[])null, (Type[])null);
				}
				int num2 = ((DataGridView)DGV_VCH).RowCount - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num2)
				{
					int num3 = ((DataGridView)DGV_VCH).ColumnCount - 1;
					for (int j = 0; j <= num3; j++)
					{
						if (((DataGridView)DGV_VCH)[j, DC_Main.i].Value != null)
						{
							NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
							{
								DC_Main.i + 2,
								j + 1,
								((DataGridView)DGV_VCH)[j, DC_Main.i].Value.ToString()
							}, (string[])null, (Type[])null);
						}
					}
					DC_Main.i++;
				}
			}
			else
			{
				int num4 = ((DataGridView)DGV).ColumnCount - 1;
				for (int k = 0; k <= num4; k++)
				{
					NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
					{
						1,
						k + 1,
						((DataGridView)DGV).Columns[k].HeaderText
					}, (string[])null, (Type[])null);
				}
				int num5 = ((DataGridView)DGV).RowCount - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num5)
				{
					int num6 = ((DataGridView)DGV).ColumnCount - 1;
					for (int l = 0; l <= num6; l++)
					{
						if (((DataGridView)DGV)[l, DC_Main.i].Value != null)
						{
							NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
							{
								DC_Main.i + 2,
								l + 1,
								((DataGridView)DGV)[l, DC_Main.i].Value.ToString()
							}, (string[])null, (Type[])null);
						}
					}
					DC_Main.i++;
				}
			}
			ColorConverter colorConverter = new ColorConverter();
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateSet(objectValue, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
			Cursor.Current = Cursors.Default;
			objectValue3 = null;
			objectValue2 = null;
			objectValue = null;
			GC.Collect();
		}
	}

	private void RP_STOCK_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0e04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0b: Expected O, but got Unknown
		//IL_0e86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e95: Expected O, but got Unknown
		//IL_0f45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f50: Expected O, but got Unknown
		//IL_0fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe7: Expected O, but got Unknown
		//IL_19e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1059: Unknown result type (might be due to invalid IL or missing references)
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Expected O, but got Unknown
		//IL_1116: Unknown result type (might be due to invalid IL or missing references)
		//IL_111b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1125: Expected O, but got Unknown
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_1149: Unknown result type (might be due to invalid IL or missing references)
		//IL_1153: Expected O, but got Unknown
		//IL_1172: Unknown result type (might be due to invalid IL or missing references)
		//IL_1177: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Expected O, but got Unknown
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_1208: Unknown result type (might be due to invalid IL or missing references)
		//IL_1212: Expected O, but got Unknown
		//IL_1231: Unknown result type (might be due to invalid IL or missing references)
		//IL_1236: Unknown result type (might be due to invalid IL or missing references)
		//IL_1240: Expected O, but got Unknown
		//IL_125f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1264: Unknown result type (might be due to invalid IL or missing references)
		//IL_126e: Expected O, but got Unknown
		//IL_12f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ff: Expected O, but got Unknown
		//IL_131e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1323: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Expected O, but got Unknown
		//IL_134c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1351: Unknown result type (might be due to invalid IL or missing references)
		//IL_135b: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
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
			foreach (object control4 in ((Control)PnlIt).Controls)
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
				DataGridViewX dGV = DGV;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewX dGV_VCH = DGV_VCH;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				ComboBox obj12 = cboItemTyp;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				obj12.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				ComboBox obj14 = cboStockType;
				object? obj15 = colorConverter.ConvertFromString("243, 240, 239");
				obj14.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				CheckBox obj16 = chkWtType;
				object? obj17 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj16).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj18 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV2 = DGV;
				object? obj19 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj21 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				Panel panel = Panel1;
				object? obj23 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				ComboBox obj24 = cboItemTyp;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				obj24.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				ComboBox obj26 = cboStockType;
				object? obj27 = colorConverter.ConvertFromString("233, 235, 240");
				obj26.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				((ButtonBase)chkWtType).BackColor = Color.LightSlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj28 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj29 = lblBook;
				object? obj30 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj29).ForeColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj31 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj32 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj34 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj35 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				Panel panel2 = Panel1;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
				cboStockType.BackColor = Color.Cornsilk;
				((ButtonBase)chkWtType).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is SearchControl || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tGrCode).Font;
				try
				{
					foreach (object control6 in ((Control)PnlIt).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control7 in ((Control)PnlBotam).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
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
					((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_VCH).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_VCH).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_VCH).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_ITM).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_ITM).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_ITM).RowTemplate.Height * (1.0 + num2));
				}
			}
			cboItemTyp.Items.Add((object)"");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 1;
			}
			else
			{
				cboItemTyp.SelectedIndex = 2;
			}
			cboStockType.Items.Add((object)"All");
			cboStockType.Items.Add((object)"Tag");
			cboStockType.Items.Add((object)"Item");
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD008NPDD", false) == 0)
			{
				cboStockType.SelectedIndex = 1;
			}
			else
			{
				cboStockType.SelectedIndex = 0;
			}
			if (Operators.CompareString(DC_Main.MsStkRptType, "G", false) == 0)
			{
				chkWtType.Checked = true;
			}
			DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET STK_DISPLAY = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND STK_DISPLAY IS NULL");
			DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET SAFE_NAME = 'MAIN' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SAFE_NAME IS NULL");
			DC_Main.ExeQuteDc("UPDATE MAIN_STOCK SET TBL_CODE = '001' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TBL_CODE IS NULL OR TBL_CODE = ''");
			cboSafe.Items.Clear();
			DC_Main.RsQry = "SELECT SAFE_NAME FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY SAFE_NAME ORDER BY SAFE_NAME ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			cboSafe.Items.Add((object)"");
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboSafe.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["SAFE_NAME"], (object)""));
					DC_Main.X++;
				}
			}
			cboSafe.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT TABLE_NAME,TABLE_CODE FROM TABLE_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY TABLE_NAME";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryTableCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryTableCode[DC_Main.X] = "";
				cboTable.Items.Add((object)"");
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
				{
					cboTable.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["TABLE_NAME"], (object)""));
					AryTableCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["TABLE_CODE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboTable.Items.Add((object)"");
				AryTableCode[DC_Main.X] = "";
			}
			cboTable.SelectedIndex = 0;
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM641NUKU", false) == 0))
			{
				((Control)btnWithOth).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0) | (Operators.CompareString(DC_Main.MsMeltingLotGenrate, "Y", false) == 0))
			{
				BtnSafe.Text = "Item Lot";
			}
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) != 0)
			{
				DC_Main.RsQry = "SELECT TOP 1 A.VCH_DATE,B.BOOK_NAME,A.VCH_NO FROM MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' And A.LC_CODE = '" + tLcCode.Text + "' AND A.VCH_DATE > '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "' ORDER BY A.VCH_DATE DESC";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = ", DC_Main.Tbl.Rows[0]["BOOK_NAME"]), (object)" And VchNo = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"...."), (MsgBoxStyle)0, (object)null);
					mToDt.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["VCH_DATE"]);
				}
			}
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
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		DGV_CLEAR();
		((Control)tSerchAll).Focus();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
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
					if ((uint)(columnIndex - 4) <= 17u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
			{
				DGV_FILL();
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsStkSum);
				dataView.RowFilter = "Name Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV).Rows.Count);
					((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV).Columns[1].Visible = false;
					((DataGridView)DGV).Columns[1].DataPropertyName = "Code";
					((DataGridView)DGV).Columns[1].HeaderText = "Code";
					((DataGridView)DGV).Columns[2].Width = (int)Math.Round(325.0 * ColCon);
					((DataGridView)DGV).Columns[2].DataPropertyName = "Name";
					((DataGridView)DGV).Columns[2].HeaderText = "Item Name";
					((DataGridView)DGV).Columns[3].Visible = false;
					((DataGridView)DGV).Columns[3].DataPropertyName = "ItType";
					((DataGridView)DGV).Columns[3].HeaderText = "ItType";
					((DataGridView)DGV).Columns[4].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[4].DataPropertyName = "OpPcs";
					((DataGridView)DGV).Columns[4].HeaderText = "OpPcs";
					((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[5].DataPropertyName = "OpWt";
					((DataGridView)DGV).Columns[5].HeaderText = "OpWt";
					((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[6].DataPropertyName = "PrPcs";
					((DataGridView)DGV).Columns[6].HeaderText = "PrPcs";
					((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[7].DataPropertyName = "PrWt";
					((DataGridView)DGV).Columns[7].HeaderText = "PrWt";
					((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[8].DataPropertyName = "InPcs";
					((DataGridView)DGV).Columns[8].HeaderText = "InPcs";
					((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[9].DataPropertyName = "InWt";
					((DataGridView)DGV).Columns[9].HeaderText = "InWt";
					((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[10].DataPropertyName = "OutPcs";
					((DataGridView)DGV).Columns[10].HeaderText = "OutPcs";
					((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[11].DataPropertyName = "OutWt";
					((DataGridView)DGV).Columns[11].HeaderText = "OutWt";
					((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[12].DataPropertyName = "SlPcs";
					((DataGridView)DGV).Columns[12].HeaderText = "SlPcs";
					((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[13].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[13].DataPropertyName = "SlWt";
					((DataGridView)DGV).Columns[13].HeaderText = "SlWt";
					((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns[14].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[14].DataPropertyName = "ClPcs";
					((DataGridView)DGV).Columns[14].HeaderText = "ClPcs";
					((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[15].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[15].DataPropertyName = "ClWt";
					((DataGridView)DGV).Columns[15].HeaderText = "ClWt";
					((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((Control)tSerchAll).Enabled = true;
			((DataGridView)DGV_VCH).DataSource = null;
			((DataGridView)DGV_VCH).ClearSelection();
			((DataGridView)DGV_VCH).Rows.Clear();
			((Control)DGV_VCH).Refresh();
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_STOCK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_STOCK_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_STOCK_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		Keys keyCode = e.KeyCode;
		if ((int)keyCode != 71)
		{
			if ((int)keyCode != 73)
			{
				if ((int)keyCode == 80)
				{
					BtnProduct_Click(BtnProduct, new EventArgs());
					((Control)BtnProduct).Focus();
				}
			}
			else
			{
				BtnItem_Click(BtnItem, new EventArgs());
				((Control)BtnItem).Focus();
			}
		}
		else
		{
			BtnGroup_Click(BtnGroup, new EventArgs());
			((Control)BtnGroup).Focus();
		}
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((Control)tSerchAll).Enabled = true;
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((Control)DGV_VCH).Refresh();
				BtnExit.Text = "&Exit";
				((Control)DGV).Visible = true;
			}
			else
			{
				((Form)this).Close();
			}
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e69: Invalid comparison between Unknown and I4
		//IL_0bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb1: Invalid comparison between Unknown and I4
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "ItemStkRpt";
		string text2;
		switch (StkType)
		{
		case "Group":
			text = "GroupStkRpt";
			text2 = "Group Wise Stock From Date  ";
			break;
		case "Product":
			text = "ProdStkRpt";
			text2 = "Product Wise Stock From Date  ";
			break;
		case "Table":
			text = "TableStkGwtRpt";
			text2 = "Counter Wise Stock From Date  ";
			break;
		case "ItmSafe":
			text = "SafeStkRpt";
			text2 = "Safe Wise Stock From Date  ";
			break;
		default:
			text = "ItemStkRpt";
			text2 = "Item Wise Stock From Date  ";
			break;
		}
		DC_Main.RsQry = "SELECT TAG_NO,IT_CODE,ITM_PCS FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = 'EMP ISU' AND ISU_REC = 'N' AND TAG_NO <> 'N' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DataGridViewX dGV = DGV;
				int num = ((DataGridView)dGV).RowCount - 3;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13,COL_14,COL_15)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[0, DC_Main.X].Value), "0000") + "','"), ((DataGridView)dGV)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[3, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[5, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[7, DC_Main.X].Value), (object)"', "), (object)" '"), ((DataGridView)dGV)[8, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[9, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[10, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[11, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[12, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[13, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[14, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[15, DC_Main.X].Value), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				dGV = null;
				DC_Main.RsQry = "SELECT * FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY SR_NO";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'" + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "ItmStkWithGrid";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
					return;
				}
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItmStkWithGrid.RPT";
				CurFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
				if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
				{
					Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					Cr[(short)0] = "RptTitel = '" + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				return;
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr[(short)0] = "";
				Cr[(short)1] = "";
				Cr[(short)2] = "";
				Cr[(short)3] = "";
				Cr[(short)4] = "";
				Cr[(short)5] = "";
				Cr[(short)6] = "";
				Cr[(short)7] = "";
			}
			if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				CurFormula = "{MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.TBL_CODE} =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (cboStockType.SelectedIndex == 1)
			{
				CurFormula += " And {MAIN_STOCK.TAG_NO} <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				CurFormula += " And {MAIN_STOCK.TAG_NO} = 'N'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {ITEM_MAST.SAFE_NAME} =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			if (Operators.CompareString(text, "SafeStkRpt", false) == 0)
			{
				if ((int)Interaction.MsgBox((object)"Safe Wise Summ Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					DC_Main.RptName = "SafeStkSumm";
				}
				else
				{
					DC_Main.RptName = text;
				}
			}
			else
			{
				DC_Main.RptName = text;
			}
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'" + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			DC_Main.MsCrForName1 = "FromDate";
			DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
			DC_Main.MsCrForName2 = "ToDate";
			DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
		}
		else
		{
			if (Operators.CompareString(text, "SafeStkRpt", false) == 0)
			{
				if ((int)Interaction.MsgBox((object)"Safe Wise Summ Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					text = "SafeStkSumm";
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";
				}
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";
			}
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = '" + text2 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_STOCK_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
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

	private void Stock_Summ(string RptType)
	{
		string text = "MAIN_STOCK";
		string text2 = ((!chkWtType.Checked) ? "A.ITM_NWT" : "A.ITM_GWT");
		switch (RptType)
		{
		case "Group":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.GR_CODE AS Code ,C.GR_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM (" + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N'"));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE ORDER BY C.GR_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Product":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.PR_CODE AS Code ,C.PR_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM (" + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN PRODUCT_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.PR_CODE = C.PR_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N'"));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY B.PR_CODE,C.PR_NAME,B.IT_TYPE ORDER BY C.PR_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Item":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code ,B.IT_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM " + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE ORDER BY B.IT_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "ItmSafe":
			if ((Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0) | (Operators.CompareString(DC_Main.MsMeltingLotGenrate, "Y", false) == 0))
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.ITM_LOT AS Code ,A.ITM_LOT AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM " + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' AND A.ITM_LOT <> '' "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.SAFE_NAME AS Code ,B.SAFE_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM " + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
			}
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			if ((Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0) | (Operators.CompareString(DC_Main.MsMeltingLotGenrate, "Y", false) == 0))
			{
				DC_Main.RsQry += "GROUP BY A.ITM_LOT,A.ITM_LOT,B.IT_TYPE ORDER BY A.ITM_LOT";
			}
			else
			{
				DC_Main.RsQry += "GROUP BY B.SAFE_NAME,B.SAFE_NAME,B.IT_TYPE ORDER BY B.SAFE_NAME";
			}
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "ItmSize":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.ITM_SIZE AS Code ,A.ITM_SIZE AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM " + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY A.ITM_SIZE,A.ITM_SIZE,B.IT_TYPE ORDER BY A.ITM_SIZE";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Design":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.DESIGN_NO AS Code ,A.DESIGN_NO AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM " + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY A.DESIGN_NO,A.DESIGN_NO,B.IT_TYPE ORDER BY A.DESIGN_NO";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Table":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TBL_CODE AS Code ,C.TABLE_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM (" + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN TABLE_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TBL_CODE = C.TABLE_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY A.TBL_CODE,C.TABLE_NAME,B.IT_TYPE ORDER BY C.TABLE_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Trad":
			DC_Main.RsQry = "UPDATE A SET A.TRAD_TYPE = B.TRAD_TYPE FROM ITEM_MAST AS A,GROUP_MAST AS B WHERE A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND (A.TRAD_TYPE IS NULL OR A.TRAD_TYPE = '') ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.TRAD_TYPE AS Code ,C.TRAD_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN " + text2 + " ELSE -" + text2 + " END) ELSE 0 END) AS ClWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TInPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TInWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TOutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'T' THEN " + text2 + " ELSE 0 END) ELSE 0 END) AS TOutWt FROM (" + text + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N'"));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (cboItemTyp.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
			}
			if (Operators.CompareString(cboSafe.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY B.TRAD_TYPE,C.TRAD_NAME,B.IT_TYPE ORDER BY C.TRAD_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		}
		DGV_FILL();
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d60: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsStkSum);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).ColumnCount = 22;
		string text = "N";
		DC_Main.RsQry = "SELECT VCH_NO FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME = 'EMP ISU'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			text = "Y";
		}
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV).Rows.Count);
			((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV).Columns[1].Visible = false;
			((DataGridView)DGV).Columns[1].DataPropertyName = "Code";
			((DataGridView)DGV).Columns[1].HeaderText = "Code";
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV).Columns[2].DataPropertyName = "Name";
			((DataGridView)DGV).Columns[2].HeaderText = "Item Name";
			((DataGridView)DGV).Columns[3].Visible = false;
			((DataGridView)DGV).Columns[3].DataPropertyName = "ItType";
			((DataGridView)DGV).Columns[3].HeaderText = "ItType";
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[4].DataPropertyName = "OpPcs";
			((DataGridView)DGV).Columns[4].HeaderText = "OpPcs";
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[5].DataPropertyName = "OpWt";
			((DataGridView)DGV).Columns[5].HeaderText = "OpWt";
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[6].DataPropertyName = "PrPcs";
			((DataGridView)DGV).Columns[6].HeaderText = "PrPcs";
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[7].DataPropertyName = "PrWt";
			((DataGridView)DGV).Columns[7].HeaderText = "PrWt";
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[8].DataPropertyName = "InPcs";
			((DataGridView)DGV).Columns[8].HeaderText = "InPcs";
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[9].DataPropertyName = "InWt";
			((DataGridView)DGV).Columns[9].HeaderText = "InWt";
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[10].DataPropertyName = "OutPcs";
			((DataGridView)DGV).Columns[10].HeaderText = "OuPcs";
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[11].DataPropertyName = "OutWt";
			((DataGridView)DGV).Columns[11].HeaderText = "OuWt";
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[12].DataPropertyName = "SlPcs";
			((DataGridView)DGV).Columns[12].HeaderText = "SlPcs";
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[13].DataPropertyName = "SlWt";
			((DataGridView)DGV).Columns[13].HeaderText = "SlWt";
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[14].DataPropertyName = "ClPcs";
			((DataGridView)DGV).Columns[14].HeaderText = "ClPcs";
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[15].DataPropertyName = "ClWt";
			((DataGridView)DGV).Columns[15].HeaderText = "ClWt";
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[16].Visible = false;
			((DataGridView)DGV).Columns[16].DataPropertyName = "TOutPcs";
			((DataGridView)DGV).Columns[16].HeaderText = "TuOPcs";
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].Visible = false;
			((DataGridView)DGV).Columns[17].DataPropertyName = "TOutWt";
			((DataGridView)DGV).Columns[17].HeaderText = "TuOWt";
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[18].Visible = false;
			((DataGridView)DGV).Columns[18].DataPropertyName = "TInPcs";
			((DataGridView)DGV).Columns[18].HeaderText = "TuInPcs";
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].Visible = false;
			((DataGridView)DGV).Columns[19].DataPropertyName = "TInWt";
			((DataGridView)DGV).Columns[19].HeaderText = "TuInWt";
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[20].Visible = false;
			((DataGridView)DGV).Columns[20].DataPropertyName = "";
			((DataGridView)DGV).Columns[20].HeaderText = "TPanPcs";
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].Visible = false;
			((DataGridView)DGV).Columns[21].DataPropertyName = "";
			((DataGridView)DGV).Columns[21].HeaderText = "TPanWt";
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N3";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV).DataSource = dataView;
			string text2 = "";
			if (Operators.CompareString(StkType, "Item", false) == 0)
			{
				text2 = "A.IT_CODE";
			}
			else if (Operators.CompareString(StkType, "Product", false) == 0)
			{
				text2 = "B.PR_CODE";
			}
			else if (Operators.CompareString(StkType, "Group", false) == 0)
			{
				text2 = "B.GR_CODE";
			}
			else if (Operators.CompareString(StkType, "ItmSafe", false) == 0)
			{
				text2 = "B.SAFE_NAME";
			}
			else if (Operators.CompareString(StkType, "ItmSize", false) == 0)
			{
				text2 = "A.ITM_SIZE";
			}
			else if (Operators.CompareString(StkType, "Design", false) == 0)
			{
				text2 = "A.DESIGN_NO";
			}
			else if (Operators.CompareString(StkType, "Table", false) == 0)
			{
				text2 = "A.TBL_CODE";
			}
			else if (Operators.CompareString(StkType, "Trad", false) == 0)
			{
				text2 = "B.TRAD_TYPE";
			}
			string text3 = ((!chkWtType.Checked) ? "A.ITM_NWT" : "A.ITM_GWT");
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) == 0)
			{
				int num = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT " + text2 + ",SUM(A.ITM_PCS) As Pcs,SUM(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As Nwt   FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_REC = 'N' AND BOOK_NAME = 'EMP ISU' AND " + text2 + " = '"), ((DataGridView)DGV).Rows[DC_Main.X].Cells[1].Value), (object)"' "), Interaction.IIf(Operators.CompareString(tTagNo.Text, "", false) == 0, (object)"", (object)("AND TAG_NO = '" + tTagNo.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
					if (cboStockType.SelectedIndex == 1)
					{
						DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
					}
					else if (cboStockType.SelectedIndex == 2)
					{
						DC_Main.RsQry += "AND A.TAG_NO = 'N'";
					}
					DC_Main.RsQry += "GROUP BY " + text2;
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						DataGridViewCell val;
						(val = ((DataGridView)DGV)[10, DC_Main.X]).Value = Operators.AddObject(val.Value, DC_Main.Tbl.Rows[0]["Pcs"]);
						(val = ((DataGridView)DGV)[14, DC_Main.X]).Value = Operators.SubtractObject(val.Value, DC_Main.Tbl.Rows[0]["Pcs"]);
						if (chkWtType.Checked)
						{
							(val = ((DataGridView)DGV)[11, DC_Main.X]).Value = Operators.AddObject(val.Value, DC_Main.Tbl.Rows[0]["Gwt"]);
							(val = ((DataGridView)DGV)[15, DC_Main.X]).Value = Operators.SubtractObject(val.Value, DC_Main.Tbl.Rows[0]["Gwt"]);
						}
						else
						{
							(val = ((DataGridView)DGV)[11, DC_Main.X]).Value = Operators.AddObject(val.Value, DC_Main.Tbl.Rows[0]["Nwt"]);
							(val = ((DataGridView)DGV)[15, DC_Main.X]).Value = Operators.SubtractObject(val.Value, DC_Main.Tbl.Rows[0]["Nwt"]);
						}
					}
					DC_Main.X++;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT TAG_NO,IT_CODE,ITM_PCS FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = 'EMP ISU' AND TAG_NO <> 'N' ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num2 = ((DataGridView)DGV).Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num2)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT " + text2 + ", SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN BOOK_NAME = 'EMP ISU' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN BOOK_NAME = 'EMP ISU' THEN " + text3 + " ELSE -" + text3 + " END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN BOOK_NAME = 'EMP ISU' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN BOOK_NAME = 'EMP ISU' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN BOOK_NAME = 'EMP REC' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN BOOK_NAME = 'EMP REC' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN BOOK_NAME = 'EMP ISU' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN BOOK_NAME = 'EMP ISU' THEN " + text3 + " ELSE -" + text3 + " END) ELSE 0 END) AS ClWt  FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND BOOK_NAME IN ('EMP ISU','EMP REC')  And " + text2 + " = '"), ((DataGridView)DGV).Rows[DC_Main.X].Cells[1].Value), (object)"' "), Interaction.IIf(Operators.CompareString(tTagNo.Text, "", false) == 0, (object)"", (object)("AND TAG_NO = '" + tTagNo.Text + "'"))), (object)""));
						if (cboStockType.SelectedIndex == 1)
						{
							DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
						}
						else if (cboStockType.SelectedIndex == 2)
						{
							DC_Main.RsQry += "AND A.TAG_NO = 'N'";
						}
						if (Operators.CompareString(tAcCode.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
						}
						if (Operators.CompareString(tTagNo.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
						}
						if (cboItemTyp.SelectedIndex != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
						}
						if (Operators.CompareString(tPrCode.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
						}
						if (Operators.CompareString(tGrCode.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
						}
						if (Operators.CompareString(tItCode.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
						}
						if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
						}
						if (Operators.CompareString(cboSafe.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
						}
						if (Operators.CompareString(cboTable.Text, "", false) != 0)
						{
							DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
						}
						DC_Main.RsQry += "GROUP BY " + text2;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							DataGridViewCell val;
							(val = ((DataGridView)DGV)[4, DC_Main.X]).Value = Operators.SubtractObject(val.Value, DC_Main.Tbl.Rows[0]["OpPcs"]);
							(val = ((DataGridView)DGV)[5, DC_Main.X]).Value = Operators.SubtractObject(val.Value, DC_Main.Tbl.Rows[0]["OpWt"]);
							double num3 = 0.0;
							double num4 = 0.0;
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT " + text2 + ", SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN A.ITM_PCS ELSE  0 END) AS EmOpSl,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN " + text3 + " ELSE 0 END) AS EmOpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN A.ITM_PCS ELSE 0 END) AS EmSlPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN " + text3 + " ELSE 0 END)AS EmSlWt FROM (RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) INNER JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.ISU_DBCD = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' And " + text2 + " = '"), ((DataGridView)DGV).Rows[DC_Main.X].Cells[1].Value), (object)"' AND C.MAIN_BOOK = 'EMP ISU' GROUP BY "), (object)text2), (object)" "));
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								(val = ((DataGridView)DGV)[4, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmOpSl"])));
								(val = ((DataGridView)DGV)[5, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmOpWt"])));
								num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmOpSl"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmSlPcs"]));
								num4 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmOpWt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmSlWt"]));
							}
							(val = ((DataGridView)DGV)[8, DC_Main.X]).Value = Operators.AddObject(val.Value, DC_Main.Tbl.Rows[0]["InPcs"]);
							(val = ((DataGridView)DGV)[9, DC_Main.X]).Value = Operators.AddObject(val.Value, DC_Main.Tbl.Rows[0]["InWt"]);
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT " + text2 + ", SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN C.MAIN_BOOK = 'EMP ISU' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS TurInPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN C.MAIN_BOOK = 'EMP ISU' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS TurInWt FROM (RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) INNER JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.ISU_DBCD = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' And " + text2 + " = '"), ((DataGridView)DGV).Rows[DC_Main.X].Cells[1].Value), (object)"' AND C.MAIN_BOOK = 'EMP ISU' GROUP BY "), (object)text2), (object)" "));
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								(val = ((DataGridView)DGV)[8, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TurInPcs"])));
								(val = ((DataGridView)DGV)[9, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TurInWt"])));
								(val = ((DataGridView)DGV)[10, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["OutPcs"])));
								(val = ((DataGridView)DGV)[11, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["OutWt"])));
							}
							else
							{
								(val = ((DataGridView)DGV)[10, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["OutPcs"])));
								(val = ((DataGridView)DGV)[11, DC_Main.X]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["OutWt"])));
							}
							(val = ((DataGridView)DGV)[14, DC_Main.X]).Value = Operators.SubtractObject(val.Value, Operators.SubtractObject(DC_Main.Tbl.Rows[0]["ClPcs"], (object)num3));
							(val = ((DataGridView)DGV)[15, DC_Main.X]).Value = Operators.SubtractObject(val.Value, Operators.SubtractObject(DC_Main.Tbl.Rows[0]["ClWt"], (object)num4));
						}
						DC_Main.X++;
					}
				}
			}
			if (((DataGridView)DGV).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[2].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[2].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			num5 = 0.0;
			int num23 = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num23; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[4].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[5].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[6].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[7].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[8].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[9].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[10].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[11].Value, (object)""));
					num13 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[12].Value, (object)""));
					num14 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[13].Value, (object)""));
					num15 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[14].Value, (object)""));
					num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[15].Value, (object)""));
					num17 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[18].Value, (object)""));
					num18 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[19].Value, (object)""));
					num19 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[16].Value, (object)""));
					num20 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[17].Value, (object)""));
					num21 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[20].Value, (object)""));
					num22 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[21].Value, (object)""));
				}
			}
			int num24 = ((DataGridView)DGV).Rows.Count - 1;
			((DataGridView)DGV).Rows[num24].Cells[2].Value = "Total :";
			((DataGridView)DGV).Rows[num24].Cells[4].Value = num5;
			((DataGridView)DGV).Rows[num24].Cells[5].Value = num6;
			((DataGridView)DGV).Rows[num24].Cells[6].Value = num7;
			((DataGridView)DGV).Rows[num24].Cells[7].Value = num8;
			((DataGridView)DGV).Rows[num24].Cells[8].Value = num9;
			((DataGridView)DGV).Rows[num24].Cells[9].Value = num10;
			((DataGridView)DGV).Rows[num24].Cells[10].Value = num11;
			((DataGridView)DGV).Rows[num24].Cells[11].Value = num12;
			((DataGridView)DGV).Rows[num24].Cells[12].Value = num13;
			((DataGridView)DGV).Rows[num24].Cells[13].Value = num14;
			((DataGridView)DGV).Rows[num24].Cells[14].Value = num15;
			((DataGridView)DGV).Rows[num24].Cells[15].Value = num16;
			((DataGridView)DGV).Rows[num24].Cells[18].Value = num17;
			((DataGridView)DGV).Rows[num24].Cells[19].Value = num18;
			((DataGridView)DGV).Rows[num24].Cells[16].Value = num19;
			((DataGridView)DGV).Rows[num24].Cells[17].Value = num20;
			((DataGridView)DGV).Rows[num24].Cells[20].Value = num21;
			((DataGridView)DGV).Rows[num24].Cells[21].Value = num22;
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

	private void BtnGroup_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Group";
		Stock_Summ("Group");
	}

	private void BtnProduct_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Product";
		Stock_Summ("Product");
	}

	private void BtnItem_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Item";
		Stock_Summ("Item");
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
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 || Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)
		{
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[12].Value), (object)""), (object)"' "));
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
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable2 = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (dataTable2.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[0]["FRM_VIEW"], (object)""), (object)"N", false))
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights...", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[3].Value, (object)""));
		if (Strings.Len(DC_Main.CurBookVch) < 3)
		{
			DC_Main.CurBook = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookInOut = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookSname = "";
			DC_Main.MsUserRightForm = "";
			DC_Main.CurBookVch = "";
			Interaction.MsgBox((object)"This Is a Item Wise Opening Stock Voucher You Cant Zoom ....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			if (Strings.Len(DC_Main.CurBookVch) != 1)
			{
				((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)MyProject.Forms.TR_TAG_OPBL).Show();
				((Control)MyProject.Forms.TR_TAG_OPBL).Focus();
			}
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG MINO ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG MINO REC", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
			{
				TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC = new TR_MFG_KR_ISU_REC();
				((Form)tR_MFG_KR_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_KR_ISU_REC).Show();
				((Control)tR_MFG_KR_ISU_REC).Focus();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				TR_MFG_GHAT_REC tR_MFG_GHAT_REC = new TR_MFG_GHAT_REC();
				((Form)tR_MFG_GHAT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_GHAT_REC).Show();
				((Control)tR_MFG_GHAT_REC).Focus();
			}
			else
			{
				TR_MFG_ISU_REC tR_MFG_ISU_REC = new TR_MFG_ISU_REC();
				((Form)tR_MFG_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ISU_REC).Show();
				((Control)tR_MFG_ISU_REC).Focus();
			}
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG STNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH ISU", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
			{
				TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC2 = new TR_MFG_KR_ISU_REC();
				((Form)tR_MFG_KR_ISU_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_KR_ISU_REC2).Show();
				((Control)tR_MFG_KR_ISU_REC2).Focus();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
			{
				TR_MFG_WITH_LOT tR_MFG_WITH_LOT = new TR_MFG_WITH_LOT();
				((Form)tR_MFG_WITH_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_WITH_LOT).Show();
				((Control)tR_MFG_WITH_LOT).Focus();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				TR_MFG_ORD_REC tR_MFG_ORD_REC = new TR_MFG_ORD_REC();
				((Form)tR_MFG_ORD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ORD_REC).Show();
				((Control)tR_MFG_ORD_REC).Focus();
			}
			else
			{
				TR_MFG_ISU_REC tR_MFG_ISU_REC2 = new TR_MFG_ISU_REC();
				((Form)tR_MFG_ISU_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ISU_REC2).Show();
				((Control)tR_MFG_ISU_REC2).Focus();
			}
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG STNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG NAKSHI REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG PREP REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG FILE REC", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
			{
				TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC3 = new TR_MFG_KR_ISU_REC();
				((Form)tR_MFG_KR_ISU_REC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_KR_ISU_REC3).Show();
				((Control)tR_MFG_KR_ISU_REC3).Focus();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
			{
				TR_MFG_WITH_LOT tR_MFG_WITH_LOT2 = new TR_MFG_WITH_LOT();
				((Form)tR_MFG_WITH_LOT2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_WITH_LOT2).Show();
				((Control)tR_MFG_WITH_LOT2).Focus();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				TR_MFG_ORD_REC tR_MFG_ORD_REC2 = new TR_MFG_ORD_REC();
				((Form)tR_MFG_ORD_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ORD_REC2).Show();
				((Control)tR_MFG_ORD_REC2).Focus();
			}
			else
			{
				TR_MFG_ISU_REC tR_MFG_ISU_REC3 = new TR_MFG_ISU_REC();
				((Form)tR_MFG_ISU_REC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ISU_REC3).Show();
				((Control)tR_MFG_ISU_REC3).Focus();
			}
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
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
	}

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tPrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT PR_NAME As PrNameL,PR_CODE as PrCodeL FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[3];
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tPrCode.Text = DC_Main.ColValue[1];
			}
			((TextBoxBase)tPrCode).SelectAll();
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
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
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
			}
			((TextBoxBase)tGrCode).SelectAll();
		}
	}

	private void BtnTable_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Table";
		Stock_Summ("Table");
	}

	private void BtnDesign_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Design";
		Stock_Summ("Design");
	}

	private void BtnSafe_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "ItmSafe";
		Stock_Summ("ItmSafe");
	}

	private void BtnTrading_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "Trad";
		Stock_Summ("Trad");
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		((Control)PnlIt).Visible = true;
		ItmList();
	}

	private void ItmList()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' ORDER BY A.IT_NAME ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV_ITM).Rows.Count <= 0)
			{
				DataGridViewX dGV_ITM = DGV_ITM;
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
				((DataGridView)dGV_ITM).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "Sr");
				((DataGridView)dGV_ITM).Columns[1].Width = (int)Math.Round(40.0 * ColCon);
				((DataGridView)dGV_ITM).Columns.Add("", "Itm Name");
				((DataGridView)dGV_ITM).Columns[2].Width = (int)Math.Round(224.0 * ColCon);
				((DataGridView)dGV_ITM).Columns.Add("", "It Code");
				((DataGridView)dGV_ITM).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
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

	private void btnOk_Click(object sender, EventArgs e)
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
				return;
			}
			SelectIt = Strings.Mid(SelectIt, 1, Strings.Len(SelectIt) - 1);
			((Control)PnlIt).Visible = false;
			((DataGridView)DGV_ITM).DataSource = null;
			((DataGridView)DGV_ITM).ClearSelection();
			((DataGridView)DGV_ITM).Rows.Clear();
			((Control)DGV_ITM).Refresh();
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItemLedger.RPT";
			CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
			}
			CurFormula = CurFormula + " And {MAIN_STOCK.IT_CODE} in [" + SelectIt + "]";
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Stock Ledger Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'Stock Ledger Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void btnItCancel_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
	}

	private void tLcCode_TextChanged(object sender, EventArgs e)
	{
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
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 1;
		}
		else
		{
			cboItemTyp.SelectedIndex = 2;
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		DGV_CLEAR();
		((TextBoxBase)tLcCode).SelectAll();
		((Control)tLcCode).Focus();
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

	private void BtnSiz_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		StkType = "ItmSize";
		Stock_Summ("ItmSize");
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
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
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[1];
					}
					((Control)tAcCode).Focus();
				}
				return;
			}
			BtnItem_Click(BtnItem, new EventArgs());
		}
		else
		{
			BtnItem_Click(BtnItem, new EventArgs());
		}
		((TextBoxBase)tAcCode).SelectAll();
	}

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT IT_NAME As ItNameL,IT_CODE as ItCodeL,IT_TYPE as TypeL,GR_CODE As GrCodeL FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_TYPE,IT_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
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
				tItCode.Text = DC_Main.ColValue[1];
			}
			((TextBoxBase)tItCode).SelectAll();
		}
	}

	private void tDesignNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select DESIGN_NO From MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DESIGN_NO = '" + tDesignNo.Text + "' GROUP BY DESIGN_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,B.IT_CODE as ItCodeL,B.IT_TYPE as TypeL FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.DESIGN_NO <> '' GROUP BY A.DESIGN_NO ,B.IT_NAME,B.IT_CODE,B.IT_TYPE ORDER BY A.DESIGN_NO,B.IT_NAME,B.IT_TYPE";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 150.0;
		DC_Main.ColWidth[1] = 250.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 90.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tDesignNo.Text = DC_Main.ColValue[0];
			}
			((TextBoxBase)tDesignNo).SelectAll();
		}
	}

	private void btnWithOth_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "Counter Wise Stock From Date";
		DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (Operators.CompareString(StkType, "Item", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.MAIN_IT_CODE As Code,A.TBL_CODE, SUM(Case When A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN DM_SIGN = '+' THEN  A.DM_PCS ELSE  -A.DM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '+' THEN A.DM_WT ELSE 0 END ELSE 0 END)-SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '-' THEN A.DM_WT ELSE 0 END ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN DM_SIGN = '+' THEN A.DM_PCS ELSE -A.DM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '+' THEN A.DM_WT ELSE 0 END ELSE 0 END) -SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '-' THEN A.DM_WT ELSE 0 END ELSE 0 END) AS ClWt FROM (DM_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.MAIN_IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
		}
		else if (Operators.CompareString(StkType, "Product", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.PR_CODE As Code , SUM(Case When A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN DM_SIGN = '+' THEN  A.DM_PCS ELSE  -A.DM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '+' THEN A.DM_WT ELSE 0 END ELSE 0 END)-SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '-' THEN A.DM_WT ELSE 0 END ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN DM_SIGN = '+' THEN A.DM_PCS ELSE -A.DM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '+' THEN A.DM_WT ELSE 0 END ELSE 0 END) -SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '-' THEN A.DM_WT ELSE 0 END ELSE 0 END) AS ClWt FROM (DM_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.MAIN_IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
		}
		else if (Operators.CompareString(StkType, "Table", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TBL_CODE As Code , SUM(Case When A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN DM_SIGN = '+' THEN  A.DM_PCS ELSE  -A.DM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '+' THEN A.DM_WT ELSE 0 END ELSE 0 END)-SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '-' THEN A.DM_WT ELSE 0 END ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'P' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '+' AND INOUT_TYPE = 'I' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'O' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN DM_SIGN = '-' AND INOUT_TYPE = 'S' THEN A.DM_WT ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN DM_SIGN = '+' THEN A.DM_PCS ELSE -A.DM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '+' THEN A.DM_WT ELSE 0 END ELSE 0 END) -SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN DM_SIGN = '-' THEN A.DM_WT ELSE 0 END ELSE 0 END) AS ClWt FROM (DM_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.MAIN_IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
		}
		if (cboStockType.SelectedIndex == 1)
		{
			DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
		}
		else if (cboStockType.SelectedIndex == 2)
		{
			DC_Main.RsQry += "AND A.TAG_NO = 'N'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
		}
		if (cboItemTyp.SelectedIndex != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.MAIN_IT_CODE =  '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboSafe.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
		}
		if (Operators.CompareString(cboTable.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
		}
		if (Operators.CompareString(StkType, "Item", false) == 0)
		{
			DC_Main.RsQry += "GROUP BY A.MAIN_IT_CODE,A.TBL_CODE";
		}
		else if (Operators.CompareString(StkType, "Product", false) == 0)
		{
			DC_Main.RsQry += "GROUP BY B.PR_CODE";
		}
		else
		{
			DC_Main.RsQry += "GROUP BY A.TBL_CODE";
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(DC_Main.Tbl);
		string text2 = "MAIN_STOCK";
		string text3 = ((!chkWtType.Checked) ? "A.ITM_NWT" : "A.ITM_GWT");
		int num = 1;
		checked
		{
			int num2 = ((DataGridView)DGV).RowCount - 2;
			DC_Main.i = 0;
			while (DC_Main.i <= num2)
			{
				if (Operators.CompareString(StkType, "Item", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code ,B.IT_NAME AS Name,B.IT_TYPE As ItType,A.TBL_CODE As TblCode, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN ITM_SIGN = '+' THEN " + text3 + " ELSE 0 END ELSE 0 END)-SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN ITM_SIGN = '-' THEN " + text3 + " ELSE 0 END ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS PrPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS PrWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS InWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS OutPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS OutWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SlPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN " + text3 + " ELSE 0 END) ELSE 0 END) AS SlWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN ITM_SIGN = '+' THEN " + text3 + " ELSE 0 END ELSE 0 END) -SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN CASE WHEN ITM_SIGN = '-' THEN " + text3 + " ELSE 0 END ELSE 0 END) AS ClWt FROM " + text2 + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" A.LC_CODE = '" + tLcCode.Text + "' AND"))), (object)" A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.STK_DISPLAY <> 'N' "));
					DC_Main.RsQry = Conversions.ToString(Operators.AddObject((object)DC_Main.RsQry, Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AND A.IT_CODE =  '", ((DataGridView)DGV)[1, DC_Main.i].Value), (object)"'")));
					if (cboStockType.SelectedIndex == 1)
					{
						DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
					}
					else if (cboStockType.SelectedIndex == 2)
					{
						DC_Main.RsQry += "AND A.TAG_NO = 'N'";
					}
					if (Operators.CompareString(tAcCode.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE =  '" + tAcCode.Text + "'";
					}
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
					}
					if (cboItemTyp.SelectedIndex != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND  B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					}
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					}
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					}
					if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.DESIGN_NO =  '" + tDesignNo.Text + "'";
					}
					if (Operators.CompareString(cboSafe.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND B.SAFE_NAME =  '" + cboSafe.Text + "'";
					}
					if (Operators.CompareString(cboTable.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
					}
					DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE,A.TBL_CODE";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					int num3 = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num3)
					{
						dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Code = '", DC_Main.Tbl.Rows[DC_Main.M]["Code"]), (object)"' AND TBL_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["TblCode"]), (object)"' "));
						if (dataView.Count > 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5, COL_6,COL_7,COL_8,  COL_9,COL_10,COL_11, COL_12,COL_13,COL_14 ,COL_15,COL_16,COL_17 ,COL_18,COL_19,COL_20,COL_21)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "'," + Conversions.ToString(num) + ",'"), DC_Main.Tbl.Rows[DC_Main.M]["Code"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.M]["Name"]), (object)"',"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OpPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OpWt"], (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["OpWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["PrPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["PrWt"], (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["PrWt"])), "0.000")), (object)", "), (object)" "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["InPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["InWt"], (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["InWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OutPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OutWt"], (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["OutWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["SlPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["SlWt"], (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["SlWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["ClPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["ClWt"], (object)"")), "0.000")), (object)" ,"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["ClWt"])), "0.000")), (object)",'"), dataView[0]["TBL_CODE"]), (object)"')"));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5, COL_6,COL_7,COL_8,  COL_9,COL_10,COL_11, COL_12,COL_13,COL_14 ,COL_15,COL_16,COL_17 ,COL_18,COL_19,COL_20,COL_21)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "'," + Conversions.ToString(num) + ",'"), DC_Main.Tbl.Rows[DC_Main.M]["Code"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.M]["Name"]), (object)"',"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OpPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OpWt"], (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["PrPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["PrWt"], (object)"")), "0.000")), (object)",0, "), (object)" "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["InPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["InWt"], (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OutPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OutWt"], (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["SlPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["SlWt"], (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["ClPcs"], (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["ClWt"], (object)"")), "0.000")), (object)" ,0,'')"));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						num++;
						DC_Main.M++;
					}
				}
				else
				{
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Code = '", ((DataGridView)DGV)[1, DC_Main.i].Value), (object)"'"));
					if (dataView.Count > 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5, COL_6,COL_7,COL_8,  COL_9,COL_10,COL_11, COL_12,COL_13,COL_14 ,COL_15,COL_16,COL_17 ,COL_18,COL_19,COL_20,COL_21)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)DGV)[0, DC_Main.i].Value), (object)"','"), ((DataGridView)DGV)[1, DC_Main.i].Value), (object)"','"), ((DataGridView)DGV)[2, DC_Main.i].Value), (object)"',"), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[4, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[5, DC_Main.i].Value, (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["OpWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[6, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[7, DC_Main.i].Value, (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["PrWt"])), "0.000")), (object)", "), (object)" "), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[8, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[9, DC_Main.i].Value, (object)"")), "0.000")), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["InWt"]))), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[10, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[11, DC_Main.i].Value, (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["OutWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[12, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[13, DC_Main.i].Value, (object)"")), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["SlWt"])), "0.000")), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[14, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[15, DC_Main.i].Value, (object)"")), "0.000")), (object)" ,"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["ClWt"])), "0.000")), (object)",'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5, COL_6,COL_7,COL_8,  COL_9,COL_10,COL_11, COL_12,COL_13,COL_14 ,COL_15,COL_16,COL_17 ,COL_18,COL_19,COL_20,COL_21)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)DGV)[0, DC_Main.i].Value), (object)"','"), ((DataGridView)DGV)[1, DC_Main.i].Value), (object)"','"), ((DataGridView)DGV)[2, DC_Main.i].Value), (object)"',"), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[4, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[5, DC_Main.i].Value, (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[6, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[7, DC_Main.i].Value, (object)"")), "0.000")), (object)",0, "), (object)" "), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[8, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[9, DC_Main.i].Value, (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[10, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[11, DC_Main.i].Value, (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[12, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[13, DC_Main.i].Value, (object)"")), "0.000")), (object)",0,"), (object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[14, DC_Main.i].Value, (object)""))), (object)","), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV)[15, DC_Main.i].Value, (object)"")), "0.000")), (object)" ,0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY SR_NO";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItmStkWithOthWt.RPT";
			CurFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void tGrCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tPrCode_TextChanged(object sender, EventArgs e)
	{
	}
}
