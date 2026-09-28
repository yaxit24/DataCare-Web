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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_SLPR_ZOOM : Form
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
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkSalesRtn")]
	private CheckBox _chkSalesRtn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSize")]
	private QButton _BtnSize;

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
	[AccessedThroughProperty("DGV_DATE")]
	private DataGridViewX _DGV_DATE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnState")]
	private QButton _btnState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBookSelect")]
	private CheckBox _chkBookSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private bool DgvLoad;

	private bool BillItmColor;

	private string ScelectBook;

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

	private const int cMItmAmt = 7;

	private const int cMLbrAmt = 8;

	private const int cMOthAmt = 9;

	private const int cMDiscAmt = 10;

	private const int cMTaxAmt = 11;

	private const int cMNetAmt = 12;

	private const int cMSlPrc = 13;

	private const int cMItCode = 14;

	private const int cMItType = 15;

	private const int cMAcMobile = 16;

	private const int cMAdd1 = 17;

	private const int cMAdd2 = 18;

	private const int cMAdd3 = 19;

	private const int cMArea = 20;

	private const int cMCity = 21;

	private const int cMPinCode = 22;

	private const int cDSrNo = 0;

	private const int cDDay = 1;

	private const int cDVchDate = 2;

	private const int cDQty = 3;

	private const int cDPcs = 4;

	private const int cDGrWt = 5;

	private const int cDNetWt = 6;

	private const int cDFine = 7;

	private const int cDItmAmt = 8;

	private const int cDLbrAmt = 9;

	private const int cDOthAmt = 10;

	private const int cDDiscAmt = 11;

	private const int cDTaxAmt = 12;

	private const int cDNetAmt = 13;

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

	private const int cTagRate = 16;

	private const int cTagAmt = 17;

	private const int cTagOthAmt = 18;

	private const int cTagDisc = 19;

	private const int cItSrNo = 0;

	private const int cItDate = 1;

	private const int cItBook = 2;

	private const int cItVchNo = 3;

	private const int cItAcName = 4;

	private const int cItMobile = 5;

	private const int cItTagNo = 6;

	private const int cItDesign = 7;

	private const int cItItName = 8;

	private const int cItPcs = 9;

	private const int cItGwt = 10;

	private const int cItNwt = 11;

	private const int cItRate = 12;

	private const int cItLRate = 13;

	private const int cItLAmt = 14;

	private const int cItOth = 15;

	private const int cItNetAmt = 16;

	private const int cItPrCost = 17;

	private const int cItDiscAmt = 18;

	private const int cItTax = 19;

	private const int cItTcs = 20;

	private const int cItTds = 21;

	private const int cItTotAmt = 22;

	private const int cItCash = 23;

	private const int cItCard = 24;

	private const int cItChq = 25;

	private const int cItUpiAmt = 26;

	private const int cItAdv = 27;

	private const int cItOldGl = 28;

	private const int cItOldSl = 29;

	private const int cItSchme = 30;

	private const int cItPaid = 31;

	private const int cItKasar = 32;

	private const int cItOs = 33;

	private const int cItGstNo = 34;

	private const int cItEmpCode = 35;

	private const int cItBillGlAmt = 36;

	private const int cItBillSlAmt = 37;

	private const int cItBillOthAmt = 38;

	private const int cItAcCity = 39;

	private const int cItAcAdd1 = 40;

	private const int cItAcAdd2 = 41;

	private const int cItAcAdd3 = 42;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_CellContentClick);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val3 = _DGV;
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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_VCH_CellContentClick);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			DataGridViewX val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).CellContentClick -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV_VCH = value;
			val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).CellContentClick += val2;
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

	internal virtual CheckBox chkSalesRtn
	{
		[CompilerGenerated]
		get
		{
			return _chkSalesRtn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkWtType_Click;
			EventHandler eventHandler2 = chkSalesRtn_CheckedChanged;
			CheckBox val = _chkSalesRtn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				val.CheckedChanged -= eventHandler2;
			}
			_chkSalesRtn = value;
			val = _chkSalesRtn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				val.CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual QButton BtnSize
	{
		[CompilerGenerated]
		get
		{
			return _BtnSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSize_Click;
			QButton val = _BtnSize;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSize = value;
			val = _BtnSize;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TGrCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tGrCode_KeyDown);
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual DataGridViewX DGV_DATE
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DATE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = DGV_DATE_DoubleClick;
			DataGridViewX val = _DGV_DATE;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV_DATE = value;
			val = _DGV_DATE;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual QButton btnState
	{
		[CompilerGenerated]
		get
		{
			return _btnState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnState_Click;
			QButton val = _btnState;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnState = value;
			val = _btnState;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOnlyTag")]
	private virtual CheckBox _chkOnlyTag;

	internal virtual CheckBox chkOnlyTag
	{
		get
		{
			return _chkOnlyTag;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOnlyTag = value;
		}
	}

	internal virtual TextBox tBookCode
	{
		[CompilerGenerated]
		get
		{
			return _tBookCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBookCode_KeyDown);
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBookCode = value;
			val2 = _tBookCode;
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

	internal virtual CheckBox chkBookSelect
	{
		[CompilerGenerated]
		get
		{
			return _chkBookSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkBookSelect_Click;
			CheckBox val = _chkBookSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkBookSelect = value;
			val = _chkBookSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Panel2")]
	private virtual Panel _Panel2;

	internal virtual Panel Panel2
	{
		get
		{
			return _Panel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel2 = value;
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

	public RP_SLPR_ZOOM()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_SLPR_ZOOM_Load;
		((Form)this).Deactivate += RP_SLPR_ZOOM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_SLPR_ZOOM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_SLPR_ZOOM_KeyDown);
		((Form)this).Activated += RP_SLPR_ZOOM_Activated;
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
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Expected O, but got Unknown
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected O, but got Unknown
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected O, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_094e: Expected O, but got Unknown
		//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected O, but got Unknown
		//IL_0a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa7: Expected O, but got Unknown
		//IL_0b76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Expected O, but got Unknown
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1f: Expected O, but got Unknown
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Expected O, but got Unknown
		//IL_0d89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d93: Expected O, but got Unknown
		//IL_0dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e06: Expected O, but got Unknown
		//IL_0eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed4: Expected O, but got Unknown
		//IL_0f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f58: Expected O, but got Unknown
		//IL_0f5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f60: Expected O, but got Unknown
		//IL_0fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd8: Expected O, but got Unknown
		//IL_1041: Unknown result type (might be due to invalid IL or missing references)
		//IL_104b: Expected O, but got Unknown
		//IL_148a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_151f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1529: Expected O, but got Unknown
		//IL_154c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_181c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1845: Unknown result type (might be due to invalid IL or missing references)
		//IL_184f: Expected O, but got Unknown
		//IL_1875: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b78: Expected O, but got Unknown
		//IL_1b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3e: Expected O, but got Unknown
		//IL_1cda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce4: Expected O, but got Unknown
		//IL_1d6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d74: Expected O, but got Unknown
		//IL_1e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e58: Expected O, but got Unknown
		//IL_1ec1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ecb: Expected O, but got Unknown
		//IL_1f9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa7: Expected O, but got Unknown
		//IL_2043: Unknown result type (might be due to invalid IL or missing references)
		//IL_204d: Expected O, but got Unknown
		//IL_20d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20dd: Expected O, but got Unknown
		//IL_21c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ce: Expected O, but got Unknown
		//IL_2237: Unknown result type (might be due to invalid IL or missing references)
		//IL_2241: Expected O, but got Unknown
		//IL_2313: Unknown result type (might be due to invalid IL or missing references)
		//IL_231d: Expected O, but got Unknown
		//IL_23b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c3: Expected O, but got Unknown
		//IL_2449: Unknown result type (might be due to invalid IL or missing references)
		//IL_2453: Expected O, but got Unknown
		//IL_253a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2544: Expected O, but got Unknown
		//IL_25ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b7: Expected O, but got Unknown
		//IL_2846: Unknown result type (might be due to invalid IL or missing references)
		//IL_286a: Unknown result type (might be due to invalid IL or missing references)
		//IL_288e: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28db: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e5: Expected O, but got Unknown
		//IL_2908: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c0a: Expected O, but got Unknown
		//IL_2c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f2f: Expected O, but got Unknown
		//IL_2f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_31b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_31fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3221: Unknown result type (might be due to invalid IL or missing references)
		//IL_324a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3254: Expected O, but got Unknown
		//IL_3277: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_32f7: Expected O, but got Unknown
		//IL_338b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3395: Expected O, but got Unknown
		//IL_3418: Unknown result type (might be due to invalid IL or missing references)
		//IL_3422: Expected O, but got Unknown
		//IL_34dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_34e6: Expected O, but got Unknown
		//IL_3789: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_37d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_37f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_381e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3828: Expected O, but got Unknown
		//IL_384b: Unknown result type (might be due to invalid IL or missing references)
		//IL_38c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_38cc: Expected O, but got Unknown
		//IL_397f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3989: Expected O, but got Unknown
		//IL_3a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a43: Expected O, but got Unknown
		//IL_3ac4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ace: Expected O, but got Unknown
		//IL_3b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b95: Expected O, but got Unknown
		//IL_3bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c09: Expected O, but got Unknown
		//IL_3ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f10: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f43: Expected O, but got Unknown
		//IL_3f66: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fea: Expected O, but got Unknown
		//IL_40aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_40b4: Expected O, but got Unknown
		//IL_4135: Unknown result type (might be due to invalid IL or missing references)
		//IL_413f: Expected O, but got Unknown
		//IL_41f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_41fa: Expected O, but got Unknown
		//IL_433d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4347: Expected O, but got Unknown
		//IL_43c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_43d2: Expected O, but got Unknown
		//IL_4457: Unknown result type (might be due to invalid IL or missing references)
		//IL_4461: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_SLPR_ZOOM));
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
		DGV_DATE = new DataGridViewX();
		DGV_VCH = new DataGridViewX();
		BtnGroup = new QButton();
		BtnProduct = new QButton();
		BtnItem = new QButton();
		BtnDesign = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		chkSalesRtn = new CheckBox();
		BtnSize = new QButton();
		tLcCode = new TextBox();
		chkItmSelect = new CheckBox();
		tGrCode = new TextBox();
		Label7 = new Label();
		cboSalesType = new ComboBox();
		Label1 = new Label();
		btnState = new QButton();
		chkOnlyTag = new CheckBox();
		tBookCode = new TextBox();
		Label4 = new Label();
		chkBookSelect = new CheckBox();
		Panel2 = new Panel();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label5 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((Control)Panel1).SuspendLayout();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
		((ISupportInitialize)DGV_DATE).BeginInit();
		((ISupportInitialize)DGV_VCH).BeginInit();
		((Control)Panel2).SuspendLayout();
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
		lblBook.Text = "Sales Zoom Report";
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
		((Control)DGV).Size = new Size(1160, 420);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 2;
		((Control)tSerchAll).Location = new Point(232, 45);
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
		((Control)tSerchAll).Size = new Size(113, 22);
		((Control)tSerchAll).TabIndex = 2;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(442, 46);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(109, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(353, 46);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(79, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.PeachPuff;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)PnlIt);
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Controls.Add((Control)(object)DGV_DATE);
		((Control)Panel1).Controls.Add((Control)(object)DGV_VCH);
		((Control)Panel1).Location = new Point(0, 119);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 447);
		((Control)Panel1).TabIndex = 110;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnAll);
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(537, 13);
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
		((DataGridView)DGV_DATE).AllowUserToAddRows = false;
		((DataGridView)DGV_DATE).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DATE).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_DATE).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DATE).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DATE).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_DATE).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DATE).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DATE).DefaultCellStyle = val13;
		((DataGridView)DGV_DATE).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DATE).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DATE).Location = new Point(10, 13);
		((Control)DGV_DATE).Name = "DGV_DATE";
		DGV_DATE.PaintEnhancedSelection = false;
		((DataGridView)DGV_DATE).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DATE).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_DATE).RowHeadersVisible = false;
		((DataGridView)DGV_DATE).RowHeadersWidth = 20;
		val15.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DATE).RowsDefaultCellStyle = val15;
		DGV_DATE.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DATE.SelectAllSignVisible = false;
		((DataGridView)DGV_DATE).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DATE).Size = new Size(1160, 420);
		((DataGridView)DGV_DATE).StandardTab = true;
		((Control)DGV_DATE).TabIndex = 1208;
		((Control)DGV_DATE).Visible = false;
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
		((Control)DGV_VCH).Location = new Point(11, 13);
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
		((Control)DGV_VCH).Size = new Size(1158, 419);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 3;
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
		((Control)BtnGroup).Location = new Point(217, 86);
		((Control)BtnGroup).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroup).Name = "BtnGroup";
		((Control)BtnGroup).Size = new Size(143, 37);
		((Control)BtnGroup).TabIndex = 7;
		BtnGroup.Text = "&Month Wise";
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
		((Control)BtnProduct).Location = new Point(534, 86);
		((Control)BtnProduct).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnProduct).Name = "BtnProduct";
		((Control)BtnProduct).Size = new Size(143, 37);
		((Control)BtnProduct).TabIndex = 6;
		BtnProduct.Text = "&City Wise";
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
		((Control)BtnItem).Location = new Point(693, 86);
		((Control)BtnItem).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItem).Name = "BtnItem";
		((Control)BtnItem).Size = new Size(143, 37);
		((Control)BtnItem).TabIndex = 5;
		BtnItem.Text = "&Party Wise";
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
		((Control)BtnDesign).Location = new Point(852, 86);
		((Control)BtnDesign).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDesign).Name = "BtnDesign";
		((Control)BtnDesign).Size = new Size(143, 37);
		((Control)BtnDesign).TabIndex = 8;
		BtnDesign.Text = "&Item Wise";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(61, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(147, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 45);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(44, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "Date";
		Label2.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkSalesRtn).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkSalesRtn).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkSalesRtn).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkSalesRtn).Location = new Point(16, 7);
		((Control)chkSalesRtn).Name = "chkSalesRtn";
		((Control)chkSalesRtn).RightToLeft = (RightToLeft)0;
		((Control)chkSalesRtn).Size = new Size(159, 19);
		((Control)chkSalesRtn).TabIndex = 1136;
		((ButtonBase)chkSalesRtn).Text = "Sales Return";
		((ButtonBase)chkSalesRtn).UseVisualStyleBackColor = false;
		((QControl)BtnSize).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSize).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSize).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSize).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSize).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSize).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSize).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSize).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSize).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSize).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSize).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSize).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSize).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSize).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSize.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSize.Image = null;
		((QControl)BtnSize).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSize).Location = new Point(1011, 86);
		((Control)BtnSize).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSize).Name = "BtnSize";
		((Control)BtnSize).Size = new Size(143, 37);
		((Control)BtnSize).TabIndex = 9;
		BtnSize.Text = "-";
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
		((Control)chkItmSelect).Location = new Point(566, 47);
		((Control)chkItmSelect).Name = "chkItmSelect";
		((Control)chkItmSelect).RightToLeft = (RightToLeft)0;
		((Control)chkItmSelect).Size = new Size(105, 19);
		((Control)chkItmSelect).TabIndex = 1204;
		((ButtonBase)chkItmSelect).Text = "Select Item";
		((ButtonBase)chkItmSelect).UseVisualStyleBackColor = false;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrCode).Location = new Point(748, 45);
		((TextBoxBase)tGrCode).MaxLength = 8;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(53, 23);
		((Control)tGrCode).TabIndex = 1205;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(683, 47);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(60, 20);
		((Control)Label7).TabIndex = 1206;
		Label7.Text = "Gr Code";
		Label7.TextAlign = (ContentAlignment)64;
		cboSalesType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboSalesType).Font = new Font("Tahoma", 9f);
		((ListControl)cboSalesType).FormattingEnabled = true;
		((Control)cboSalesType).Location = new Point(94, 89);
		((Control)cboSalesType).Name = "cboSalesType";
		((Control)cboSalesType).Size = new Size(110, 22);
		((Control)cboSalesType).TabIndex = 1208;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(-4, 88);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(92, 20);
		((Control)Label1).TabIndex = 1209;
		Label1.Text = "Sales Type";
		Label1.TextAlign = (ContentAlignment)64;
		((QControl)btnState).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnState).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnState).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnState).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnState).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnState).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnState).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnState).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnState).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnState).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnState).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnState).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnState).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnState).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnState.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnState.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnState.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnState.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnState.Image = null;
		((QControl)btnState).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnState).Location = new Point(375, 86);
		((Control)btnState).Margin = new Padding(3, 6, 3, 6);
		((Control)btnState).Name = "btnState";
		((Control)btnState).Size = new Size(143, 37);
		((Control)btnState).TabIndex = 1210;
		btnState.Text = "&State Wise";
		((ButtonBase)chkOnlyTag).BackColor = Color.Transparent;
		((Control)chkOnlyTag).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOnlyTag).ForeColor = Color.Black;
		((Control)chkOnlyTag).Location = new Point(979, 38);
		((Control)chkOnlyTag).Name = "chkOnlyTag";
		((Control)chkOnlyTag).RightToLeft = (RightToLeft)0;
		((Control)chkOnlyTag).Size = new Size(133, 22);
		((Control)chkOnlyTag).TabIndex = 1211;
		((ButtonBase)chkOnlyTag).Text = "Only Tag Sales";
		((ButtonBase)chkOnlyTag).UseVisualStyleBackColor = false;
		((Control)chkOnlyTag).Visible = false;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(899, 45);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(62, 23);
		((Control)tBookCode).TabIndex = 1212;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(811, 46);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(80, 20);
		((Control)Label4).TabIndex = 1213;
		Label4.Text = "Book Code";
		Label4.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkBookSelect).BackColor = Color.Transparent;
		((Control)chkBookSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBookSelect).ForeColor = Color.Black;
		((Control)chkBookSelect).Location = new Point(979, 61);
		((Control)chkBookSelect).Name = "chkBookSelect";
		((Control)chkBookSelect).RightToLeft = (RightToLeft)0;
		((Control)chkBookSelect).Size = new Size(105, 19);
		((Control)chkBookSelect).TabIndex = 1214;
		((ButtonBase)chkBookSelect).Text = "Select Book";
		((ButtonBase)chkBookSelect).UseVisualStyleBackColor = false;
		((Control)Panel2).Controls.Add((Control)(object)tAcCode);
		((Control)Panel2).Controls.Add((Control)(object)tAcName);
		((Control)Panel2).Controls.Add((Control)(object)Label5);
		((Control)Panel2).Location = new Point(0, 72);
		((Control)Panel2).Name = "Panel2";
		((Control)Panel2).Size = new Size(687, 46);
		((Control)Panel2).TabIndex = 1215;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(146, 13);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 1166;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(231, 13);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1167;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(52, 16);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(85, 20);
		((Control)Label5).TabIndex = 1168;
		Label5.Text = "Party Code";
		Label5.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Panel2);
		((Control)this).Controls.Add((Control)(object)chkBookSelect);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)chkOnlyTag);
		((Control)this).Controls.Add((Control)(object)cboSalesType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)chkItmSelect);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)chkSalesRtn);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tSerchAll);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)BtnGroup);
		((Control)this).Controls.Add((Control)(object)BtnProduct);
		((Control)this).Controls.Add((Control)(object)BtnItem);
		((Control)this).Controls.Add((Control)(object)BtnDesign);
		((Control)this).Controls.Add((Control)(object)BtnSize);
		((Control)this).Controls.Add((Control)(object)btnState);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_SLPR_ZOOM";
		((Form)this).Text = "Sales Zoom Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((ISupportInitialize)DGV_DATE).EndInit();
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)Panel2).ResumeLayout(false);
		((Control)Panel2).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnGroup_Click(object sender, EventArgs e)
	{
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MONTH(A.VCH_DATE) As Code,CONVERT(varchar(3), A.VCH_DATE, 100) As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,0 As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE)   LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("And B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" And A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
			DC_Main.RsQry += "GROUP BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100) ORDER BY MONTH(A.VCH_DATE)";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MONTH(A.VCH_DATE) As Code,CONVERT(varchar(3), A.VCH_DATE, 100) As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.ITM_DISC) As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE)  LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(cboSalesType.SelectedIndex == 4, (object)"AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O'", RuntimeHelpers.GetObjectValue(Interaction.IIf(chkSalesRtn.Checked, (object)"AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' ", (object)" And A.ITM_SIGN = '-' AND A.TR_TYPE = 'S'")))), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" And D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES','TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "GROUP BY MONTH(A.VCH_DATE),CONVERT(varchar(3), A.VCH_DATE, 100) ORDER BY MONTH(A.VCH_DATE)";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
		StkType = "Month";
	}

	private void BtnProduct_Click(object sender, EventArgs e)
	{
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_CITY As Code,C.AC_CITY As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,0 As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)"   "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY C.AC_CITY ORDER BY C.AC_CITY";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_CITY As Code,C.AC_CITY As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.ITM_DISC)  As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(cboSalesType.SelectedIndex == 4, (object)"AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O'", RuntimeHelpers.GetObjectValue(Interaction.IIf(chkSalesRtn.Checked, (object)"AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' ", (object)" And A.ITM_SIGN = '-' AND A.TR_TYPE = 'S'")))), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "GROUP BY C.AC_CITY ORDER BY C.AC_CITY";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
		StkType = "City";
	}

	private void BtnItem_Click(object sender, EventArgs e)
	{
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE As Code,C.AC_NAME As AcName,C.AC_MOBILE As AcMobile,C.AC_ADD1 As Add1,C.AC_ADD2 As Add2,C.AC_ADD3 As Add3,C.AC_AREA As Area,C.AC_CITY As City,C.AC_PIN As PinCode,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,0 As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY A.AC_CODE,C.AC_NAME,C.AC_MOBILE,C.AC_ADD1,C.AC_ADD2,C.AC_ADD3,C.AC_AREA,C.AC_CITY,C.AC_PIN ORDER BY C.AC_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE As Code,C.AC_NAME As AcName,C.AC_MOBILE As AcMobile,C.AC_ADD1 As Add1,C.AC_ADD2 As Add2,C.AC_ADD3 As Add3,C.AC_AREA As Area,C.AC_CITY As City,C.AC_PIN As PinCode, SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.ITM_DISC)  As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(cboSalesType.SelectedIndex == 4, (object)"AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O'", RuntimeHelpers.GetObjectValue(Interaction.IIf(chkSalesRtn.Checked, (object)"AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' ", (object)" And A.ITM_SIGN = '-' AND A.TR_TYPE = 'S'")))), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "GROUP BY A.AC_CODE,C.AC_NAME,C.AC_MOBILE,C.AC_ADD1,C.AC_ADD2,C.AC_ADD3,C.AC_AREA,C.AC_CITY,C.AC_PIN ORDER BY C.AC_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		StkType = "Party";
		DGV_FILL();
	}

	private void BtnDesign_Click(object sender, EventArgs e)
	{
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,0 As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY D.IT_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As Code,D.IT_NAME As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.ITM_DISC)  As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(cboSalesType.SelectedIndex == 4, (object)"AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O'", RuntimeHelpers.GetObjectValue(Interaction.IIf(chkSalesRtn.Checked, (object)"AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' ", (object)" And A.ITM_SIGN = '-' AND A.TR_TYPE = 'S'")))), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)" "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "GROUP BY A.IT_CODE,D.IT_NAME ORDER BY D.IT_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
		StkType = "Item";
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
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_10d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e2: Expected O, but got Unknown
		DGV_CLEAR();
		Application.DoEvents();
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
		((DataGridView)DGV).ColumnCount = 23;
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV).Rows.Count);
			((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV).Columns[1].DataPropertyName = "AcName";
			((DataGridView)DGV).Columns[1].HeaderText = "Item Name";
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV).Columns[2].DataPropertyName = "Qty";
			((DataGridView)DGV).Columns[2].HeaderText = "Qty";
			((DataGridView)DGV).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[2].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV).Columns[3].DataPropertyName = "Pcs";
			((DataGridView)DGV).Columns[3].HeaderText = "Pcs";
			((DataGridView)DGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[3].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[4].DataPropertyName = "Gwt";
			((DataGridView)DGV).Columns[4].HeaderText = "GrWt";
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[5].DataPropertyName = "NetWt";
			((DataGridView)DGV).Columns[5].HeaderText = "NetWt";
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[6].DataPropertyName = "FineWt";
			((DataGridView)DGV).Columns[6].HeaderText = "Fine";
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[7].DataPropertyName = "ItmAmt";
			((DataGridView)DGV).Columns[7].HeaderText = "ItAmt";
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[8].DataPropertyName = "LbrAmt";
			((DataGridView)DGV).Columns[8].HeaderText = "LbrAmt";
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[9].DataPropertyName = "OthAmt";
			((DataGridView)DGV).Columns[9].HeaderText = "OthAmt";
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[10].DataPropertyName = "DiscAmt";
			((DataGridView)DGV).Columns[10].HeaderText = "DiscAmt";
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[11].DataPropertyName = "TaxAmt";
			((DataGridView)DGV).Columns[11].HeaderText = "TaxAmt";
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV).Columns[12].DataPropertyName = "NetAmt";
			((DataGridView)DGV).Columns[12].HeaderText = "NetAmt";
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[13].Visible = false;
			((DataGridView)DGV).Columns[13].DataPropertyName = "SlPrc";
			((DataGridView)DGV).Columns[13].HeaderText = "Sal%";
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns[14].Visible = false;
			((DataGridView)DGV).Columns[14].DataPropertyName = "Code";
			((DataGridView)DGV).Columns[14].HeaderText = "Code";
			((DataGridView)DGV).Columns[15].Visible = false;
			((DataGridView)DGV).Columns[15].DataPropertyName = "ItType";
			((DataGridView)DGV).Columns[15].HeaderText = "ItType";
			if (Operators.CompareString(StkType, "Party", false) == 0)
			{
				((DataGridView)DGV).Columns[16].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[16].DataPropertyName = "AcMobile";
				((DataGridView)DGV).Columns[16].HeaderText = "Mobile";
				((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV).Columns[17].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)DGV).Columns[17].DataPropertyName = "Add1";
				((DataGridView)DGV).Columns[17].HeaderText = "Add1";
				((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
				((DataGridView)DGV).Columns[18].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)DGV).Columns[18].DataPropertyName = "Add2";
				((DataGridView)DGV).Columns[18].HeaderText = "Add2";
				((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
				((DataGridView)DGV).Columns[19].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)DGV).Columns[19].DataPropertyName = "Add3";
				((DataGridView)DGV).Columns[19].HeaderText = "Add3";
				((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
				((DataGridView)DGV).Columns[20].Width = (int)Math.Round(130.0 * ColCon);
				((DataGridView)DGV).Columns[20].DataPropertyName = "Area";
				((DataGridView)DGV).Columns[20].HeaderText = "Area";
				((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
				((DataGridView)DGV).Columns[21].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)DGV).Columns[21].DataPropertyName = "City";
				((DataGridView)DGV).Columns[21].HeaderText = "City";
				((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
				((DataGridView)DGV).Columns[22].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV).Columns[22].DataPropertyName = "PinCode";
				((DataGridView)DGV).Columns[22].HeaderText = "PinCode";
				((DataGridView)DGV).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
			}
			else
			{
				((DataGridView)DGV).Columns[16].Visible = false;
				((DataGridView)DGV).Columns[16].DataPropertyName = "";
				((DataGridView)DGV).Columns[16].HeaderText = "Mobile";
				((DataGridView)DGV).Columns[17].Visible = false;
				((DataGridView)DGV).Columns[17].DataPropertyName = "";
				((DataGridView)DGV).Columns[17].HeaderText = "Add1";
				((DataGridView)DGV).Columns[18].Visible = false;
				((DataGridView)DGV).Columns[18].DataPropertyName = "";
				((DataGridView)DGV).Columns[18].HeaderText = "Add2";
				((DataGridView)DGV).Columns[19].Visible = false;
				((DataGridView)DGV).Columns[19].DataPropertyName = "";
				((DataGridView)DGV).Columns[19].HeaderText = "Add3";
				((DataGridView)DGV).Columns[20].Visible = false;
				((DataGridView)DGV).Columns[20].DataPropertyName = "";
				((DataGridView)DGV).Columns[20].HeaderText = "Area";
				((DataGridView)DGV).Columns[21].Visible = false;
				((DataGridView)DGV).Columns[21].DataPropertyName = "";
				((DataGridView)DGV).Columns[21].HeaderText = "City";
				((DataGridView)DGV).Columns[22].Visible = false;
				((DataGridView)DGV).Columns[22].DataPropertyName = "";
				((DataGridView)DGV).Columns[22].HeaderText = "PinCode";
			}
			((DataGridView)DGV).Columns[0].Frozen = true;
			((DataGridView)DGV).Columns[1].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV).DataSource = dataView;
			if (((DataGridView)DGV).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			num = 0.0;
			int num13 = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num13; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[2].Value, (object)""));
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[3].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[4].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[5].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[6].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[7].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[8].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[9].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[10].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[11].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[12].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[13].Value, (object)""));
				}
			}
			int num14 = ((DataGridView)DGV).Rows.Count - 1;
			((DataGridView)DGV).Rows[num14].Cells[1].Value = "Total :";
			((DataGridView)DGV).Rows[num14].Cells[2].Value = num12;
			((DataGridView)DGV).Rows[num14].Cells[3].Value = num;
			((DataGridView)DGV).Rows[num14].Cells[4].Value = num2;
			((DataGridView)DGV).Rows[num14].Cells[5].Value = num3;
			((DataGridView)DGV).Rows[num14].Cells[6].Value = num4;
			((DataGridView)DGV).Rows[num14].Cells[7].Value = num5;
			((DataGridView)DGV).Rows[num14].Cells[8].Value = num6;
			((DataGridView)DGV).Rows[num14].Cells[9].Value = num7;
			((DataGridView)DGV).Rows[num14].Cells[10].Value = num8;
			((DataGridView)DGV).Rows[num14].Cells[11].Value = num9;
			((DataGridView)DGV).Rows[num14].Cells[12].Value = num10;
			((DataGridView)DGV).Rows[num14].Cells[13].Value = num11;
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
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(BtnSize.Text, "Bill Wise", false) == 0)
					{
						switch (e.ColumnIndex)
						{
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
						case 14:
						case 15:
						case 16:
						case 18:
						case 19:
						case 20:
						case 21:
						case 22:
						case 23:
						case 24:
						case 25:
						case 26:
						case 27:
						case 28:
						case 29:
						case 30:
						case 31:
						case 32:
						case 33:
						case 36:
						case 37:
						case 38:
							if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
							{
								((ConvertEventArgs)e).Value = "";
								e.FormattingApplied = true;
							}
							break;
						case 17:
						case 34:
						case 35:
							break;
						}
					}
					else
					{
						int columnIndex = e.ColumnIndex;
						if ((uint)(columnIndex - 2) <= 11u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					break;
				case 356:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_019a;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 356;
				continue;
			}
			break;
			IL_019a:
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
					if ((uint)(columnIndex - 7) <= 3u && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 86:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_008c;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 86;
				continue;
			}
			break;
			IL_008c:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DgvDate_Fil()
	{
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Expected O, but got Unknown
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_0e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e75: Expected O, but got Unknown
		((DataGridView)DGV_DATE).DataSource = null;
		((DataGridView)DGV_DATE).ClearSelection();
		((DataGridView)DGV_DATE).Rows.Clear();
		((DataGridView)DGV_DATE).Columns.Clear();
		((Control)DGV_DATE).Refresh();
		((Control)DGV).Visible = false;
		((Control)tSerchAll).Enabled = false;
		BtnExit.Text = "&Back1";
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		string text;
		string text2;
		if (chkSalesRtn.Checked)
		{
			text = "+";
			text2 = "I";
		}
		else
		{
			text = "-";
			text2 = "S";
		}
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			text = "+";
			text2 = "P";
		}
		if (Operators.CompareString(StkType, "Month", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT FORMAT(A.VCH_DATE,'ddd') As CurDay,Format(A.VCH_DATE,'dd/MM/yyyy') As VchDate,SUM(1) As Qty1,SUM(A.ITM_PCS) As Pcs1,SUM(A.ITM_GWT) As GrWt,SUM(A.ITM_NWT) As NetWt,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.KR_FINE ELSE A.ITM_FINE END) As ItmFine,SUM(A.ITM_AMT) As ItAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(OTH_AMT) As OthAmt,0 As DiscAmt,0 As TaxAmt,SUM(NET_AMT) As NetAmt  FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.ITM_SIGN = '"), (object)text), (object)"' AND A.TR_TYPE = '"), (object)text2), (object)"' AND MONTH(A.VCH_DATE) = '"), ((DataGridView)DGV)[14, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
			{
				DC_Main.RsQry += "AND A.TR_TYPE = 'P'";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "GROUP BY A.VCH_DATE ORDER BY A.VCH_DATE";
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DataView dataView = new DataView(RsStk);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_DATE).MultiSelect = false;
		((DataGridView)DGV_DATE).AutoGenerateColumns = false;
		((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DATE).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DATE).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_DATE).ColumnCount = 14;
		checked
		{
			((DataGridView)DGV_DATE).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV_DATE).Rows.Count);
			((DataGridView)DGV_DATE).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_DATE).Columns[1].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[1].DataPropertyName = "CurDay";
			((DataGridView)DGV_DATE).Columns[1].HeaderText = "Day";
			((DataGridView)DGV_DATE).Columns[2].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[2].DataPropertyName = "VchDate";
			((DataGridView)DGV_DATE).Columns[2].HeaderText = "Date";
			((DataGridView)DGV_DATE).Columns[3].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[3].DataPropertyName = "Qty1";
			((DataGridView)DGV_DATE).Columns[3].HeaderText = "Qty";
			((DataGridView)DGV_DATE).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[3].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DATE).Columns[4].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[4].DataPropertyName = "Pcs1";
			((DataGridView)DGV_DATE).Columns[4].HeaderText = "Pcs";
			((DataGridView)DGV_DATE).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[4].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_DATE).Columns[5].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[5].DataPropertyName = "GrWt";
			((DataGridView)DGV_DATE).Columns[5].HeaderText = "GrWt";
			((DataGridView)DGV_DATE).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DATE).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[6].DataPropertyName = "NetWt";
			((DataGridView)DGV_DATE).Columns[6].HeaderText = "NetWt";
			((DataGridView)DGV_DATE).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DATE).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[7].DataPropertyName = "ItmFine";
			((DataGridView)DGV_DATE).Columns[7].HeaderText = "ItmFine";
			((DataGridView)DGV_DATE).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DATE).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[8].DataPropertyName = "ItmAmt";
			((DataGridView)DGV_DATE).Columns[8].HeaderText = "ItAmt";
			((DataGridView)DGV_DATE).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DATE).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[9].DataPropertyName = "LbrAmt";
			((DataGridView)DGV_DATE).Columns[9].HeaderText = "LbrAmt";
			((DataGridView)DGV_DATE).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DATE).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[10].DataPropertyName = "OthAmt";
			((DataGridView)DGV_DATE).Columns[10].HeaderText = "OthAmt";
			((DataGridView)DGV_DATE).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DATE).Columns[11].Visible = false;
			((DataGridView)DGV_DATE).Columns[11].DataPropertyName = "DiscAmt";
			((DataGridView)DGV_DATE).Columns[11].HeaderText = "DiscAmt";
			((DataGridView)DGV_DATE).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DATE).Columns[12].Visible = false;
			((DataGridView)DGV_DATE).Columns[12].DataPropertyName = "TaxAmt";
			((DataGridView)DGV_DATE).Columns[12].HeaderText = "TaxAmt";
			((DataGridView)DGV_DATE).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DATE).Columns[13].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DATE).Columns[13].DataPropertyName = "NetAmt";
			((DataGridView)DGV_DATE).Columns[13].HeaderText = "NetAmt";
			((DataGridView)DGV_DATE).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DATE).Columns[13].DefaultCellStyle.Format = "N2";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV_DATE).DataSource = dataView;
			if (((DataGridView)DGV_DATE).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[((DataGridView)DGV_DATE).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[((DataGridView)DGV_DATE).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			num2 = 0.0;
			int num13 = ((DataGridView)DGV_DATE).Rows.Count - 1;
			for (int i = 0; i <= num13; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV_DATE).Rows[i].Cells[0].Value = i + 1;
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[3].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[4].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[5].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[6].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[7].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[8].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[9].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[10].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[11].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[12].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[13].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DATE).Rows[i].Cells[13].Value, (object)""));
				}
			}
			int num14 = ((DataGridView)DGV_DATE).Rows.Count - 1;
			((DataGridView)DGV_DATE).Rows[num14].Cells[1].Value = "Total :";
			((DataGridView)DGV_DATE).Rows[num14].Cells[3].Value = num;
			((DataGridView)DGV_DATE).Rows[num14].Cells[4].Value = num2;
			((DataGridView)DGV_DATE).Rows[num14].Cells[5].Value = num3;
			((DataGridView)DGV_DATE).Rows[num14].Cells[6].Value = num4;
			((DataGridView)DGV_DATE).Rows[num14].Cells[7].Value = num5;
			((DataGridView)DGV_DATE).Rows[num14].Cells[8].Value = num6;
			((DataGridView)DGV_DATE).Rows[num14].Cells[9].Value = num7;
			((DataGridView)DGV_DATE).Rows[num14].Cells[10].Value = num8;
			((DataGridView)DGV_DATE).Rows[num14].Cells[11].Value = num9;
			((DataGridView)DGV_DATE).Rows[num14].Cells[12].Value = num10;
			((DataGridView)DGV_DATE).Rows[num14].Cells[13].Value = num11;
			((DataGridView)DGV_DATE).Rows[num14].Cells[13].Value = num12;
		}
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_180e: Expected O, but got Unknown
		//IL_1840: Unknown result type (might be due to invalid IL or missing references)
		//IL_1845: Unknown result type (might be due to invalid IL or missing references)
		//IL_184f: Expected O, but got Unknown
		//IL_1865: Unknown result type (might be due to invalid IL or missing references)
		//IL_186a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1874: Expected O, but got Unknown
		//IL_188a: Unknown result type (might be due to invalid IL or missing references)
		//IL_188f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1899: Expected O, but got Unknown
		//IL_27b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ba: Expected O, but got Unknown
		((Control)DGV).Visible = false;
		((Control)tSerchAll).Enabled = false;
		BtnExit.Text = "&Back";
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		string text;
		string text2;
		if (chkSalesRtn.Checked)
		{
			text = "+";
			text2 = "I";
		}
		else
		{
			text = "-";
			text2 = ((cboSalesType.SelectedIndex != 4) ? "S" : "O");
		}
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			text = "+";
			text2 = "P";
		}
		if (Operators.CompareString(StkType, "Month", false) == 0)
		{
			if (!((Control)DGV_DATE).Visible)
			{
				((Control)DGV_DATE).Visible = true;
				DgvDate_Fil();
				return;
			}
			((Control)DGV_DATE).Visible = false;
			BtnExit.Text = "&Back";
			int index2 = ((DataGridViewBand)((DataGridView)DGV_DATE).CurrentRow).Index;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_RATE,A.ITM_AMT,A.OTH_AMT,A.ITM_DISC,CASE WHEN A.ITM_SIGN = '+' THEN A.KR_FINE ELSE A.ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.ITM_SIGN = '"), (object)text), (object)"' AND A.TR_TYPE = '"), (object)text2), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)DGV_DATE)[2, index2].Value), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
			{
				DC_Main.RsQry += "AND A.TR_TYPE = 'P'";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "ORDER BY A.CO_BOOK,A.VCH_NO";
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(StkType, "State", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN A.KR_FINE ELSE A.ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.ITM_SIGN = '"), (object)text), (object)"' AND A.TR_TYPE = '"), (object)text2), (object)"' AND E.AC_STATE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
			{
				DC_Main.RsQry += "AND A.TR_TYPE = 'P'";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(StkType, "City", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN A.KR_FINE ELSE A.ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.ITM_SIGN = '"), (object)text), (object)"' AND A.TR_TYPE = '"), (object)text2), (object)"' AND E.AC_CITY = '"), ((DataGridView)DGV)[14, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
			{
				DC_Main.RsQry += "AND A.TR_TYPE = 'P'";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(StkType, "Party", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN A.KR_FINE ELSE A.ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.ITM_SIGN = '"), (object)text), (object)"' AND A.TR_TYPE = '"), (object)text2), (object)"' AND A.AC_CODE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
			{
				DC_Main.RsQry += "AND A.TR_TYPE = 'P'";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(StkType, "Item", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,D.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN A.KR_FINE ELSE A.ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE And A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.ITM_SIGN = '"), (object)text), (object)"' AND A.TR_TYPE = '"), (object)text2), (object)"' AND A.IT_CODE = '"), ((DataGridView)DGV)[14, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
			{
				DC_Main.RsQry += "AND A.TR_TYPE = 'P'";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		if (Operators.CompareString(StkType, "OldStock", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,C.VCH_NO,C.VCH_DATE,A.TAG_NO,D.IT_NAME,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE As ItmFine,'+' AS ITM_SIGN,C.CO_BOOK,B.MAIN_BOOK,C.IT_CODE,C.AC_CODE  FROM (((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN BOOK_DATA AS B ON C.CO_CODE = B.CO_CODE And C.LC_CODE = B.LC_CODE And C.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE) LEFT JOIN AC_MAST AS E ON C.CO_CODE = E.CO_CODE And C.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.IT_CODE = '"), ((DataGridView)DGV)[2, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.AC_GR = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND C.KR_NAME = '" + tAcCode.Text + "'"))), (object)" AND C.STK_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" AND YEAR(C.STK_DATE) = '"), (object)"20"), (object)Strings.Mid(((DataGridView)DGV).Columns[columnIndex].HeaderText, 1, 2)), (object)"' AND  MONTH(C.STK_DATE) = '"), (object)Strings.Mid(((DataGridView)DGV).Columns[columnIndex].HeaderText, 4, 2)), (object)"' "), (object)" GROUP BY B.BOOK_SNAME,E.AC_NAME,C.VCH_NO,C.VCH_DATE,A.TAG_NO,D.IT_NAME,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE,C.CO_BOOK,B.MAIN_BOOK,C.IT_CODE,C.AC_CODE HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 "));
			RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DataView dataView = new DataView(RsStk);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
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
		((DataGridView)DGV_VCH).ColumnCount = 20;
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
			((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[5].DataPropertyName = "TAG_NO";
			((DataGridView)DGV_VCH).Columns[5].HeaderText = "TagNo";
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
			if (Operators.CompareString(StkType, "Month", false) == 0)
			{
				if (Operators.CompareString(CurRpt, "Sale Zoom", false) == 0)
				{
					((DataGridView)DGV_VCH).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_VCH).Columns[16].DataPropertyName = "ITM_RATE";
					((DataGridView)DGV_VCH).Columns[16].HeaderText = "ItmRate";
					((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_VCH).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_VCH).Columns[17].DataPropertyName = "ITM_AMT";
					((DataGridView)DGV_VCH).Columns[17].HeaderText = "ItmAmt";
					((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_VCH).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_VCH).Columns[18].DataPropertyName = "OTH_AMT";
					((DataGridView)DGV_VCH).Columns[18].HeaderText = "OthRate";
					((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_VCH).Columns[19].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_VCH).Columns[19].DataPropertyName = "ITM_DISC";
					((DataGridView)DGV_VCH).Columns[19].HeaderText = "DiscAmt";
					((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Format = "N2";
				}
				else
				{
					((DataGridView)DGV_VCH).Columns[16].Visible = false;
					((DataGridView)DGV_VCH).Columns[16].DataPropertyName = "ITM_RATE";
					((DataGridView)DGV_VCH).Columns[16].HeaderText = "ItmRate";
					((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_VCH).Columns[17].Visible = false;
					((DataGridView)DGV_VCH).Columns[17].DataPropertyName = "ITM_AMT";
					((DataGridView)DGV_VCH).Columns[17].HeaderText = "ItmAmt";
					((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_VCH).Columns[18].Visible = false;
					((DataGridView)DGV_VCH).Columns[18].DataPropertyName = "OTH_AMT";
					((DataGridView)DGV_VCH).Columns[18].HeaderText = "OthRate";
					((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_VCH).Columns[19].Visible = false;
					((DataGridView)DGV_VCH).Columns[19].DataPropertyName = "ITM_DISC";
					((DataGridView)DGV_VCH).Columns[19].HeaderText = "OthRate";
					((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Format = "N2";
				}
			}
			else
			{
				((DataGridView)DGV_VCH).Columns[16].Visible = false;
				((DataGridView)DGV_VCH).Columns[16].DataPropertyName = "ITM_RATE";
				((DataGridView)DGV_VCH).Columns[16].HeaderText = "ItmRate";
				((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_VCH).Columns[17].Visible = false;
				((DataGridView)DGV_VCH).Columns[17].DataPropertyName = "ITM_AMT";
				((DataGridView)DGV_VCH).Columns[17].HeaderText = "ItmAmt";
				((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_VCH).Columns[18].Visible = false;
				((DataGridView)DGV_VCH).Columns[18].DataPropertyName = "OTH_AMT";
				((DataGridView)DGV_VCH).Columns[18].HeaderText = "OthRate";
				((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_VCH).Columns[19].Visible = false;
				((DataGridView)DGV_VCH).Columns[19].DataPropertyName = "ITM_DISC";
				((DataGridView)DGV_VCH).Columns[19].HeaderText = "OthRate";
				((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Format = "N2";
			}
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
			double num6 = 0.0;
			double num7 = 0.0;
			int num8 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			for (int i = 0; i <= num8; i++)
			{
				if (!Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					continue;
				}
				((DataGridView)DGV_VCH).Rows[i].Cells[0].Value = i + 1;
				if (unchecked(columnIndex == 13 || columnIndex == 2))
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[11].Value, (object)""), (object)"+", false))
					{
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
						num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[18].Value, (object)""));
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[17].Value, (object)""));
						num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[19].Value, (object)""));
					}
					else
					{
						num -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
						num2 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
						num3 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
						num4 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
						num5 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[18].Value, (object)""));
						num6 -= Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[17].Value, (object)""));
						num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[19].Value, (object)""));
					}
				}
				else
				{
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[7].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[8].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[9].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[10].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[18].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[17].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[i].Cells[19].Value, (object)""));
				}
			}
			if (((DataGridView)DGV_VCH).Rows.Count > 1)
			{
				int num9 = ((DataGridView)DGV_VCH).Rows.Count - 1;
				((DataGridView)DGV_VCH).Rows[num9].Cells[2].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num9].Cells[7].Value = num;
				((DataGridView)DGV_VCH).Rows[num9].Cells[8].Value = num2;
				((DataGridView)DGV_VCH).Rows[num9].Cells[9].Value = num3;
				((DataGridView)DGV_VCH).Rows[num9].Cells[10].Value = num4;
				((DataGridView)DGV_VCH).Rows[num9].Cells[18].Value = num5;
				((DataGridView)DGV_VCH).Rows[num9].Cells[17].Value = num6;
				((DataGridView)DGV_VCH).Rows[num9].Cells[19].Value = num7;
			}
		}
	}

	private void DGV_VCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
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
					case 2259:
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
							case 37:
								goto IL_047d;
							case 29:
							case 32:
							case 34:
							case 35:
							case 38:
							case 39:
							case 40:
								goto IL_04d3;
							case 41:
								goto IL_04e5;
							case 20:
							case 42:
							case 43:
								goto IL_0501;
							case 44:
								goto IL_050b;
							case 45:
								goto IL_055e;
							case 46:
								goto IL_05b3;
							case 47:
								goto IL_060b;
							case 48:
								goto IL_0679;
							case 49:
								goto IL_06bc;
							case 50:
								goto IL_06eb;
							case 51:
								goto IL_072e;
							case 52:
								goto IL_076f;
							case 53:
								goto IL_0790;
							case 54:
								goto IL_079e;
							case 55:
								goto IL_07b8;
							case 56:
								goto IL_07be;
							case 57:
								goto IL_07c4;
							case 58:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 59:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_04d3:
						num2 = 40;
						num5++;
						goto IL_04dc;
						IL_026b:
						num2 = 22;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02b3;
						IL_047d:
						num2 = 37;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_04d3;
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
						num7 = ((DataGridView)DGV_VCH).ColumnCount - 1;
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
						num9 = ((DataGridView)DGV_VCH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0241;
						IL_0241:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_0501;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_VCH).ColumnCount - 1;
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
							((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString()
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
							((DataGridView)DGV_VCH).Columns[num8].HeaderText
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
						goto IL_04f4;
						IL_04f4:
						if (DC_Main.i <= num13)
						{
							goto IL_02df;
						}
						goto IL_0501;
						IL_0501:
						num2 = 43;
						colorConverter = new ColorConverter();
						goto IL_050b;
						IL_050b:
						num2 = 44;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_055e;
						IL_055e:
						num2 = 45;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_05b3;
						IL_05b3:
						num2 = 46;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_060b;
						IL_060b:
						num2 = 47;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0679;
						IL_0679:
						num2 = 48;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_06bc;
						IL_06bc:
						num2 = 49;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_06eb;
						IL_06eb:
						num2 = 50;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_072e;
						IL_072e:
						num2 = 51;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_076f;
						IL_076f:
						num2 = 52;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0790;
						IL_0790:
						num2 = 53;
						Cursor.Current = Cursors.Default;
						goto IL_079e;
						IL_079e:
						num2 = 54;
						NewLateBinding.LateCall(obj2, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_07b8;
						IL_07b8:
						num2 = 55;
						obj = null;
						goto IL_07be;
						IL_07be:
						num2 = 56;
						obj3 = null;
						goto IL_07c4;
						IL_07c4:
						num2 = 57;
						obj2 = null;
						break;
						IL_02df:
						num2 = 25;
						num14 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_04dc;
						IL_04dc:
						if (num5 <= num14)
						{
							goto IL_02f9;
						}
						goto IL_04e5;
						IL_04e5:
						num2 = 41;
						DC_Main.i++;
						goto IL_04f4;
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
						goto IL_04d3;
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
						goto IL_04d3;
						IL_0402:
						num2 = 33;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_04d3;
						IL_045a:
						num2 = 36;
						if (((DataGridView)DGV)[num5, DC_Main.i].Value != null)
						{
							goto IL_047d;
						}
						goto IL_04d3;
						end_IL_0001_2:
						break;
					}
					num2 = 58;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 2259;
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

	private void RP_SLPR_ZOOM_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbf: Expected O, but got Unknown
		//IL_0e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e49: Expected O, but got Unknown
		//IL_0ed1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee0: Expected O, but got Unknown
		//IL_0f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5d: Expected O, but got Unknown
		//IL_100f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1014: Unknown result type (might be due to invalid IL or missing references)
		//IL_101e: Expected O, but got Unknown
		//IL_103d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1042: Unknown result type (might be due to invalid IL or missing references)
		//IL_104c: Expected O, but got Unknown
		//IL_106b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1070: Unknown result type (might be due to invalid IL or missing references)
		//IL_107a: Expected O, but got Unknown
		//IL_10fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1101: Unknown result type (might be due to invalid IL or missing references)
		//IL_110b: Expected O, but got Unknown
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_112f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1139: Expected O, but got Unknown
		//IL_1158: Unknown result type (might be due to invalid IL or missing references)
		//IL_115d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1167: Expected O, but got Unknown
		//IL_11e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f8: Expected O, but got Unknown
		//IL_1217: Unknown result type (might be due to invalid IL or missing references)
		//IL_121c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1226: Expected O, but got Unknown
		//IL_1245: Unknown result type (might be due to invalid IL or missing references)
		//IL_124a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1254: Expected O, but got Unknown
		//IL_12d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12db: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e5: Expected O, but got Unknown
		//IL_1304: Unknown result type (might be due to invalid IL or missing references)
		//IL_1309: Unknown result type (might be due to invalid IL or missing references)
		//IL_1313: Expected O, but got Unknown
		//IL_1332: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Unknown result type (might be due to invalid IL or missing references)
		//IL_1341: Expected O, but got Unknown
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
				CheckBox obj14 = chkSalesRtn;
				object? obj15 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj16 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV2 = DGV;
				object? obj17 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj19 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				Panel panel = Panel1;
				object? obj21 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				ComboBox obj22 = cboItemTyp;
				object? obj23 = colorConverter.ConvertFromString("233, 235, 240");
				obj22.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((ButtonBase)chkSalesRtn).BackColor = Color.LightSlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj24 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj25 = lblBook;
				object? obj26 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj25).ForeColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj27 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj28 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj29 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj30 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				Panel panel2 = Panel1;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
				((ButtonBase)chkSalesRtn).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mToDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mToDt).Font;
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
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DATE).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DATE).Font.Style);
					((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DATE).Font.Style);
					((DataGridView)DGV_DATE).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DATE).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DATE).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DATE).RowTemplate.Height * (1.0 + num2));
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
			cboItemTyp.SelectedIndex = 0;
			cboSalesType.Items.Add((object)"");
			cboSalesType.Items.Add((object)"Retail");
			cboSalesType.Items.Add((object)"WhSale");
			cboSalesType.Items.Add((object)"TourSale");
			cboSalesType.Items.Add((object)"LbrWork");
			cboSalesType.SelectedIndex = 0;
			if (Operators.CompareString(CurRpt, "Old Stock", false) == 0)
			{
				((Control)BtnGroup).Visible = false;
				((Control)BtnProduct).Visible = false;
				((Control)BtnItem).Visible = false;
				((Control)BtnDesign).Visible = false;
				((Control)chkSalesRtn).Visible = false;
				BtnSize.Text = "Ok";
				cboItemTyp.SelectedIndex = 1;
				((Control)tGrCode).Visible = false;
				((Control)Label7).Visible = false;
				((Control)Label1).Visible = false;
				((Control)cboSalesType).Visible = false;
				((Control)btnState).Visible = false;
				((Control)Label4).Visible = false;
				((Control)tBookCode).Visible = false;
				((Control)chkBookSelect).Visible = false;
				((Control)Panel2).Visible = true;
			}
			else
			{
				((Control)Panel2).Visible = false;
				BookMast();
				if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
				{
					((Control)Label1).Visible = false;
					((Control)cboSalesType).Visible = false;
					((Control)chkSalesRtn).Visible = false;
				}
				else
				{
					((Control)chkOnlyTag).Visible = true;
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					BtnSize.Text = "Bill Wise";
				}
				else if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					BtnSize.Text = "Invoice";
				}
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
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		ScelectBook = "";
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
		DGV_CLEAR();
		((Control)tSerchAll).Focus();
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		DataView dataView = default(DataView);
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
					case 2913:
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
								goto IL_002a;
							case 5:
							case 6:
								goto IL_003a;
							case 7:
								goto IL_005e;
							case 8:
								goto IL_0067;
							case 9:
								goto IL_0076;
							case 10:
								goto IL_009b;
							case 11:
								goto IL_00b1;
							case 12:
								goto IL_00e1;
							case 13:
								goto IL_0110;
							case 14:
								goto IL_012f;
							case 15:
								goto IL_014b;
							case 16:
								goto IL_016b;
							case 17:
								goto IL_018b;
							case 18:
								goto IL_01bb;
							case 19:
								goto IL_01da;
							case 20:
								goto IL_01f9;
							case 21:
								goto IL_0215;
							case 22:
								goto IL_0235;
							case 23:
								goto IL_0255;
							case 24:
								goto IL_0285;
							case 25:
								goto IL_02a4;
							case 26:
								goto IL_02c3;
							case 27:
								goto IL_02e4;
							case 28:
								goto IL_0314;
							case 29:
								goto IL_0333;
							case 30:
								goto IL_0352;
							case 31:
								goto IL_0373;
							case 32:
								goto IL_0397;
							case 33:
								goto IL_03c7;
							case 34:
								goto IL_03e6;
							case 35:
								goto IL_0405;
							case 36:
								goto IL_0426;
							case 37:
								goto IL_0456;
							case 38:
								goto IL_0475;
							case 39:
								goto IL_0494;
							case 40:
								goto IL_04b5;
							case 41:
								goto IL_04d9;
							case 42:
								goto IL_0509;
							case 43:
								goto IL_0528;
							case 44:
								goto IL_0547;
							case 45:
								goto IL_0568;
							case 46:
								goto IL_0598;
							case 47:
								goto IL_05b7;
							case 48:
								goto IL_05d6;
							case 49:
								goto IL_05f7;
							case 50:
								goto IL_061b;
							case 51:
								goto IL_064c;
							case 52:
								goto IL_066c;
							case 53:
								goto IL_068c;
							case 54:
								goto IL_06ae;
							case 55:
								goto IL_06df;
							case 56:
								goto IL_06ff;
							case 57:
								goto IL_071f;
							case 58:
								goto IL_0741;
							case 59:
								goto IL_0766;
							case 60:
								goto IL_0797;
							case 61:
								goto IL_07b7;
							case 62:
								goto IL_07d7;
							case 63:
								goto IL_07f9;
							case 64:
								goto IL_082a;
							case 65:
								goto IL_084a;
							case 66:
								goto IL_086a;
							case 67:
								goto IL_088c;
							case 68:
								goto IL_08b1;
							case 69:
								goto IL_08e2;
							case 70:
								goto IL_0902;
							case 71:
								goto IL_0922;
							case 72:
								goto IL_0944;
							case 73:
								goto IL_0974;
							case 74:
								goto IL_0993;
							case 75:
								goto IL_09b2;
							case 76:
								goto IL_09d3;
							case 77:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 4:
							case 78:
							case 79:
							case 80:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0993:
						num2 = 74;
						((DataGridView)DGV).Columns[2].HeaderText = "ClWt";
						goto IL_09b2;
						IL_09b2:
						num2 = 75;
						((DataGridView)DGV).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_09d3;
						IL_0974:
						num2 = 73;
						((DataGridView)DGV).Columns[2].DataPropertyName = "ClWt";
						goto IL_0993;
						IL_09d3:
						num2 = 76;
						((DataGridView)DGV).Columns[2].DefaultCellStyle.Format = "N3";
						break;
						IL_000b:
						num2 = 2;
						if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
						{
							goto IL_002a;
						}
						goto IL_003a;
						IL_002a:
						num2 = 3;
						DGV_FILL();
						goto end_IL_0001_3;
						IL_003a:
						num2 = 6;
						if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_005e;
						IL_005e:
						num2 = 7;
						DGV_CLEAR();
						goto IL_0067;
						IL_0067:
						num2 = 8;
						dataView = new DataView(RsStkSum);
						goto IL_0076;
						IL_0076:
						num2 = 9;
						dataView.RowFilter = "AcName Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";
						goto IL_009b;
						IL_009b:
						num2 = 10;
						if (dataView.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_00b1;
						IL_00b1:
						num2 = 11;
						((DataGridView)DGV).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
						goto IL_00e1;
						IL_00e1:
						num2 = 12;
						((DataGridView)DGV).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV).Rows.Count);
						goto IL_0110;
						IL_0110:
						num2 = 13;
						((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
						goto IL_012f;
						IL_012f:
						num2 = 14;
						((DataGridView)DGV).Columns[14].Visible = false;
						goto IL_014b;
						IL_014b:
						num2 = 15;
						((DataGridView)DGV).Columns[14].DataPropertyName = "Code";
						goto IL_016b;
						IL_016b:
						num2 = 16;
						((DataGridView)DGV).Columns[14].HeaderText = "Code";
						goto IL_018b;
						IL_018b:
						num2 = 17;
						((DataGridView)DGV).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
						goto IL_01bb;
						IL_01bb:
						num2 = 18;
						((DataGridView)DGV).Columns[1].DataPropertyName = "Name";
						goto IL_01da;
						IL_01da:
						num2 = 19;
						((DataGridView)DGV).Columns[1].HeaderText = "Item Name";
						goto IL_01f9;
						IL_01f9:
						num2 = 20;
						((DataGridView)DGV).Columns[15].Visible = false;
						goto IL_0215;
						IL_0215:
						num2 = 21;
						((DataGridView)DGV).Columns[15].DataPropertyName = "ItType";
						goto IL_0235;
						IL_0235:
						num2 = 22;
						((DataGridView)DGV).Columns[15].HeaderText = "ItType";
						goto IL_0255;
						IL_0255:
						num2 = 23;
						((DataGridView)DGV).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_0285;
						IL_0285:
						num2 = 24;
						((DataGridView)DGV).Columns[3].DataPropertyName = "OpPcs";
						goto IL_02a4;
						IL_02a4:
						num2 = 25;
						((DataGridView)DGV).Columns[3].HeaderText = "OpPcs";
						goto IL_02c3;
						IL_02c3:
						num2 = 26;
						((DataGridView)DGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_02e4;
						IL_02e4:
						num2 = 27;
						((DataGridView)DGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0314;
						IL_0314:
						num2 = 28;
						((DataGridView)DGV).Columns[4].DataPropertyName = "OpWt";
						goto IL_0333;
						IL_0333:
						num2 = 29;
						((DataGridView)DGV).Columns[4].HeaderText = "OpWt";
						goto IL_0352;
						IL_0352:
						num2 = 30;
						((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0373;
						IL_0373:
						num2 = 31;
						((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N3";
						goto IL_0397;
						IL_0397:
						num2 = 32;
						((DataGridView)DGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_03c7;
						IL_03c7:
						num2 = 33;
						((DataGridView)DGV).Columns[5].DataPropertyName = "PrPcs";
						goto IL_03e6;
						IL_03e6:
						num2 = 34;
						((DataGridView)DGV).Columns[5].HeaderText = "PrPcs";
						goto IL_0405;
						IL_0405:
						num2 = 35;
						((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0426;
						IL_0426:
						num2 = 36;
						((DataGridView)DGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0456;
						IL_0456:
						num2 = 37;
						((DataGridView)DGV).Columns[6].DataPropertyName = "PrWt";
						goto IL_0475;
						IL_0475:
						num2 = 38;
						((DataGridView)DGV).Columns[6].HeaderText = "PrWt";
						goto IL_0494;
						IL_0494:
						num2 = 39;
						((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_04b5;
						IL_04b5:
						num2 = 40;
						((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
						goto IL_04d9;
						IL_04d9:
						num2 = 41;
						((DataGridView)DGV).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_0509;
						IL_0509:
						num2 = 42;
						((DataGridView)DGV).Columns[7].DataPropertyName = "InPcs";
						goto IL_0528;
						IL_0528:
						num2 = 43;
						((DataGridView)DGV).Columns[7].HeaderText = "InPcs";
						goto IL_0547;
						IL_0547:
						num2 = 44;
						((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0568;
						IL_0568:
						num2 = 45;
						((DataGridView)DGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0598;
						IL_0598:
						num2 = 46;
						((DataGridView)DGV).Columns[8].DataPropertyName = "InWt";
						goto IL_05b7;
						IL_05b7:
						num2 = 47;
						((DataGridView)DGV).Columns[8].HeaderText = "InWt";
						goto IL_05d6;
						IL_05d6:
						num2 = 48;
						((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_05f7;
						IL_05f7:
						num2 = 49;
						((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N3";
						goto IL_061b;
						IL_061b:
						num2 = 50;
						((DataGridView)DGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_064c;
						IL_064c:
						num2 = 51;
						((DataGridView)DGV).Columns[9].DataPropertyName = "OutPcs";
						goto IL_066c;
						IL_066c:
						num2 = 52;
						((DataGridView)DGV).Columns[9].HeaderText = "OutPcs";
						goto IL_068c;
						IL_068c:
						num2 = 53;
						((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_06ae;
						IL_06ae:
						num2 = 54;
						((DataGridView)DGV).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_06df;
						IL_06df:
						num2 = 55;
						((DataGridView)DGV).Columns[10].DataPropertyName = "OutWt";
						goto IL_06ff;
						IL_06ff:
						num2 = 56;
						((DataGridView)DGV).Columns[10].HeaderText = "OutWt";
						goto IL_071f;
						IL_071f:
						num2 = 57;
						((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0741;
						IL_0741:
						num2 = 58;
						((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
						goto IL_0766;
						IL_0766:
						num2 = 59;
						((DataGridView)DGV).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_0797;
						IL_0797:
						num2 = 60;
						((DataGridView)DGV).Columns[11].DataPropertyName = "SlPcs";
						goto IL_07b7;
						IL_07b7:
						num2 = 61;
						((DataGridView)DGV).Columns[11].HeaderText = "SlPcs";
						goto IL_07d7;
						IL_07d7:
						num2 = 62;
						((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_07f9;
						IL_07f9:
						num2 = 63;
						((DataGridView)DGV).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_082a;
						IL_082a:
						num2 = 64;
						((DataGridView)DGV).Columns[12].DataPropertyName = "SlWt";
						goto IL_084a;
						IL_084a:
						num2 = 65;
						((DataGridView)DGV).Columns[12].HeaderText = "SlWt";
						goto IL_086a;
						IL_086a:
						num2 = 66;
						((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_088c;
						IL_088c:
						num2 = 67;
						((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
						goto IL_08b1;
						IL_08b1:
						num2 = 68;
						((DataGridView)DGV).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_08e2;
						IL_08e2:
						num2 = 69;
						((DataGridView)DGV).Columns[13].DataPropertyName = "ClPcs";
						goto IL_0902;
						IL_0902:
						num2 = 70;
						((DataGridView)DGV).Columns[13].HeaderText = "ClPcs";
						goto IL_0922;
						IL_0922:
						num2 = 71;
						((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0944;
						IL_0944:
						num2 = 72;
						((DataGridView)DGV).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0974;
						end_IL_0001_2:
						break;
					}
					num2 = 77;
					((DataGridView)DGV).DataSource = dataView;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 2913;
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

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			if (Operators.CompareString(StkType, "Month", false) == 0)
			{
				((Control)tSerchAll).Enabled = false;
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((Control)DGV_VCH).Refresh();
				BtnExit.Text = "&Back1";
				((Control)DGV_DATE).Visible = true;
			}
			else
			{
				((Control)tSerchAll).Enabled = true;
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((Control)DGV_VCH).Refresh();
				BtnExit.Text = "&Exit";
				((Control)DGV).Visible = true;
			}
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
		{
			((Control)tSerchAll).Enabled = true;
			((DataGridView)DGV_DATE).DataSource = null;
			((DataGridView)DGV_DATE).ClearSelection();
			((DataGridView)DGV_DATE).Rows.Clear();
			((Control)DGV_DATE).Refresh();
			((Control)DGV_DATE).Visible = false;
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_SLPR_ZOOM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_SLPR_ZOOM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_SLPR_ZOOM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Invalid comparison between Unknown and I4
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
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
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

	private void RP_SLPR_ZOOM_Activated(object sender, EventArgs e)
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
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
	}

	private void BtnSize_Click(object sender, EventArgs e)
	{
		//IL_3309: Unknown result type (might be due to invalid IL or missing references)
		//IL_3313: Expected O, but got Unknown
		//IL_3345: Unknown result type (might be due to invalid IL or missing references)
		//IL_334a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3354: Expected O, but got Unknown
		//IL_336a: Unknown result type (might be due to invalid IL or missing references)
		//IL_336f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3379: Expected O, but got Unknown
		//IL_338f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3394: Unknown result type (might be due to invalid IL or missing references)
		//IL_339e: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_37cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_37d9: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_19e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f2: Expected O, but got Unknown
		checked
		{
			if (Operators.CompareString(CurRpt, "Sale Zoom", false) == 0 && Operators.CompareString(CurRpt, "Purc Zoom", false) != 0)
			{
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					DGV_CLEAR();
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
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
					double num23 = 0.0;
					double num24 = 0.0;
					double num25 = 0.0;
					double num26 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO,VCH_SRNO,KR_COST FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO IN (SELECT TAG_NO FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "') ORDER BY VCH_TIME DESC ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DataView dataView = new DataView(DC_Main.Tbl);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT D.BOOK_SNAME,A.VCH_DATE,A.VCH_NO,A.AC_NAME,CASE WHEN A.MOBILE = '' THEN E.AC_MOBILE ELSE A.MOBILE END AS CustMobile,B.TAG_NO,C.IT_NAME,B.ITM_PCS,B.ITM_GWT,B.ITM_NWT,B.ITM_RATE,B.LBR_RATE,B.LBR_AMT,B.OTH_AMT,B.NET_AMT,E.AC_CITY,E.AC_ADD1,E.AC_ADD2,AC_ADD3,  A.DISC_AMT,A.TAX_AMT,A.TCS_AMT,A.TDS_AMT,A.TOT_AMT,A.CASH_AMT,A.CARD_AMT,A.CHQ_AMT,A.ADV_AMT,A.OLD_GL_AMT,A.OLD_SL_AMT,A.SCHM_AMT,A.CASH_PAID,A.UPI_AMT,A.KASAR_AMT,A.BILL_OS,A.CO_BOOK,D.MAIN_BOOK,E.AC_GSTNO,F.EMP_NAME,B.DESIGN_NO,B.VCH_SRNO  FROM ((((SL_DATA AS A INNER JOIN SL_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE)  LEFT JOIN ITEM_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK)LEFT JOIN EMP_MAST AS F ON A.CO_CODE = F.CO_CODE AND A.EMP_CODE = F.EMP_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
					if (Operators.CompareString(ScelectBook, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
					}
					if (Operators.CompareString(tLcCode.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + " AND A.LC_CODE = '" + tLcCode.Text + "'";
					}
					if (chkOnlyTag.Checked)
					{
						DC_Main.RsQry += "AND B.TAG_NO <> 'N'";
					}
					if (chkOnlyTag.Checked)
					{
						DC_Main.RsQry += "AND B.TAG_NO <> 'N'";
					}
					DC_Main.RsQry += " ORDER BY A.CO_BOOK,A.VCH_NO";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
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
					((DataGridView)DGV).Columns.Add("", "Sr");
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(35.0 * ColCon);
					((DataGridView)DGV).Columns[0].Frozen = true;
					((DataGridView)DGV).Columns.Add("", "Date");
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(95.0 * ColCon);
					((DataGridView)DGV).Columns[1].Frozen = true;
					((DataGridView)DGV).Columns.Add("", "Type");
					((DataGridView)DGV).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV).Columns[2].Frozen = true;
					((DataGridView)DGV).Columns.Add("", "VchNo");
					((DataGridView)DGV).Columns[3].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV).Columns[3].Frozen = true;
					((DataGridView)DGV).Columns.Add("", "Ac Name");
					((DataGridView)DGV).Columns[4].Width = (int)Math.Round(200.0 * ColCon);
					((DataGridView)DGV).Columns[4].Frozen = true;
					((DataGridView)DGV).Columns.Add("", "Mobile");
					((DataGridView)DGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "TagNo");
					((DataGridView)DGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "Design");
					((DataGridView)DGV).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "ItName");
					((DataGridView)DGV).Columns[8].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "Pcs");
					((DataGridView)DGV).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N0";
					((DataGridView)DGV).Columns.Add("", "Gwt");
					((DataGridView)DGV).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns.Add("", "NetWt");
					((DataGridView)DGV).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV).Columns.Add("", "Rate");
					((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "LbrRate");
					((DataGridView)DGV).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "LbrAmt");
					((DataGridView)DGV).Columns[14].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "OthAmt");
					((DataGridView)DGV).Columns[15].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "NetAmt");
					((DataGridView)DGV).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
					{
						((DataGridView)DGV).Columns.Add("", "TagCost");
						((DataGridView)DGV).Columns[17].Width = (int)Math.Round(90.0 * ColCon);
						((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
					}
					else
					{
						((DataGridView)DGV).Columns.Add("", "TagCost");
						((DataGridView)DGV).Columns[17].Visible = false;
						((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
					}
					((DataGridView)DGV).Columns.Add("", "DiscAmt");
					((DataGridView)DGV).Columns[18].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "TaxAmt");
					((DataGridView)DGV).Columns[19].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "TcsTax");
					((DataGridView)DGV).Columns[20].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[20].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "TdsTax");
					((DataGridView)DGV).Columns[21].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "TotAmt");
					((DataGridView)DGV).Columns[22].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[22].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "CashAmt");
					((DataGridView)DGV).Columns[23].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[23].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "CardAmt");
					((DataGridView)DGV).Columns[24].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[24].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[24].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "ChqAmt");
					((DataGridView)DGV).Columns[25].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[25].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[25].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "UpiAmt");
					((DataGridView)DGV).Columns[26].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[26].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "AdvAmt");
					((DataGridView)DGV).Columns[27].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[27].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[27].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "OldGl");
					((DataGridView)DGV).Columns[28].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[28].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[28].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "OldSlv");
					((DataGridView)DGV).Columns[29].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[29].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[29].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "SchmAmt");
					((DataGridView)DGV).Columns[30].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[30].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[30].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "PaidAmt");
					((DataGridView)DGV).Columns[31].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[31].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[31].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "Kasar");
					((DataGridView)DGV).Columns[32].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)DGV).Columns[32].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[32].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "OsAmt");
					((DataGridView)DGV).Columns[33].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[33].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[33].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "GstNo");
					((DataGridView)DGV).Columns[34].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "EmpName");
					((DataGridView)DGV).Columns[35].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "VchGlWt");
					((DataGridView)DGV).Columns[36].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[36].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[36].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "VchSlWt");
					((DataGridView)DGV).Columns[37].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[37].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[37].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "VchOtWt");
					((DataGridView)DGV).Columns[38].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV).Columns[38].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[38].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns.Add("", "AcCity");
					((DataGridView)DGV).Columns[39].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "AcAdd1");
					((DataGridView)DGV).Columns[40].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "AcAdd2");
					((DataGridView)DGV).Columns[41].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV).Columns.Add("", "AcAdd3");
					((DataGridView)DGV).Columns[42].Width = (int)Math.Round(150.0 * ColCon);
					if (DC_Main.ScreenHight > 1.0)
					{
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
					}
					DC_Main.i = 0;
					string text = "";
					string text2 = "";
					if (dataTable.Rows.Count <= 0)
					{
						return;
					}
					int num27 = dataTable.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num27)
					{
						DataGridViewX dGV = DGV;
						((DataGridView)DGV).Rows.Add();
						BillItmColor = false;
						if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual((object)text, Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["BOOK_SNAME"], (object)""), false), Operators.CompareObjectNotEqual((object)text2, Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["VCH_NO"], (object)""), false))))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["BOOK_SNAME"], (object)""));
							text2 = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["VCH_NO"], (object)""));
							BillItmColor = true;
							((DataGridView)dGV).Rows[DC_Main.i].DefaultCellStyle.ForeColor = Color.Maroon;
							((DataGridView)dGV)[18, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["DISC_AMT"], (object)""));
							((DataGridView)dGV)[19, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["TAX_AMT"], (object)""));
							((DataGridView)dGV)[20, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["TCS_AMT"], (object)""));
							((DataGridView)dGV)[21, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["TDS_AMT"], (object)""));
							((DataGridView)dGV)[22, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["TOT_AMT"], (object)""));
							((DataGridView)dGV)[23, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["CASH_AMT"], (object)""));
							((DataGridView)dGV)[24, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["CARD_AMT"], (object)""));
							((DataGridView)dGV)[25, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["CHQ_AMT"], (object)""));
							((DataGridView)dGV)[26, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["UPI_AMT"], (object)""));
							((DataGridView)dGV)[27, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ADV_AMT"], (object)""));
							((DataGridView)dGV)[28, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["OLD_GL_AMT"], (object)""));
							((DataGridView)dGV)[29, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["OLD_SL_AMT"], (object)""));
							((DataGridView)dGV)[30, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["SCHM_AMT"], (object)""));
							((DataGridView)dGV)[31, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["CASH_PAID"], (object)""));
							((DataGridView)dGV)[32, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["KASAR_AMT"], (object)""));
							((DataGridView)dGV)[33, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["BILL_OS"], (object)""));
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(CASE WHEN B.IT_TYPE = 'G' THEN A.ITM_GWT ELSE 0 END) As BillGlAmt,SUM(CASE WHEN B.IT_TYPE = 'S' THEN A.ITM_GWT ELSE 0 END) As BillSlAmt,SUM(CASE WHEN B.IT_TYPE NOT IN ('G','S') THEN A.ITM_GWT ELSE 0 END) As BillOtAmt FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.i]["VCH_NO"]), (object)"'"));
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								((DataGridView)dGV)[36, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BillGlAmt"], (object)""));
								((DataGridView)dGV)[37, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BillSlAmt"], (object)""));
								((DataGridView)dGV)[38, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BillOtAmt"], (object)""));
								num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[36, DC_Main.i].Value));
								num24 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[37, DC_Main.i].Value));
								num25 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[38, DC_Main.i].Value));
							}
							num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, DC_Main.i].Value));
							num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[19, DC_Main.i].Value));
							num20 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[20, DC_Main.i].Value));
							num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.i].Value));
							num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[22, DC_Main.i].Value));
							num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[23, DC_Main.i].Value));
							num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[24, DC_Main.i].Value));
							num12 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[25, DC_Main.i].Value));
							num13 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[27, DC_Main.i].Value));
							num26 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[26, DC_Main.i].Value));
							num14 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[28, DC_Main.i].Value));
							num15 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[29, DC_Main.i].Value));
							num16 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[30, DC_Main.i].Value));
							num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[31, DC_Main.i].Value));
							num18 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[32, DC_Main.i].Value));
							num19 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[33, DC_Main.i].Value));
						}
						if (!BillItmColor)
						{
							((DataGridView)dGV).Rows[DC_Main.i].DefaultCellStyle.ForeColor = Color.Gray;
						}
						((DataGridView)dGV)[0, DC_Main.i].Value = DC_Main.i + 1;
						((DataGridView)dGV)[1, DC_Main.i].Value = Strings.Format((object)Conversions.ToDate(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["VCH_DATE"], (object)"")), "dd/MM/yyyy");
						((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["BOOK_SNAME"], (object)"");
						((DataGridView)dGV)[3, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["VCH_NO"], (object)"");
						((DataGridView)dGV)[4, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_NAME"], (object)"");
						((DataGridView)dGV)[5, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["CustMobile"], (object)"");
						((DataGridView)dGV)[6, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["TAG_NO"], (object)"");
						((DataGridView)dGV)[7, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["DESIGN_NO"], (object)"");
						((DataGridView)dGV)[8, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["IT_NAME"], (object)"");
						((DataGridView)dGV)[34, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_GSTNO"], (object)"");
						((DataGridView)dGV)[9, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ITM_PCS"], (object)""));
						((DataGridView)dGV)[10, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ITM_GWT"], (object)""));
						((DataGridView)dGV)[11, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ITM_NWT"], (object)""));
						((DataGridView)dGV)[12, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ITM_RATE"], (object)""));
						((DataGridView)dGV)[13, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["LBR_RATE"], (object)""));
						((DataGridView)dGV)[14, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["LBR_AMT"], (object)""));
						((DataGridView)dGV)[15, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["OTH_AMT"], (object)""));
						((DataGridView)dGV)[16, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["NET_AMT"], (object)""));
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
						{
							dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", dataTable.Rows[DC_Main.i]["TAG_NO"]), (object)""), (object)"' AND VCH_SRNO = "), dataTable.Rows[DC_Main.i]["VCH_SRNO"]), (object)""), (object)" "));
							if (dataView.Count > 0)
							{
								((DataGridView)dGV)[17, DC_Main.i].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["KR_COST"], (object)""));
							}
						}
						((DataGridView)dGV)[35, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["EMP_NAME"], (object)"");
						((DataGridView)dGV)[39, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_CITY"], (object)"");
						((DataGridView)dGV)[40, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_ADD1"], (object)"");
						((DataGridView)dGV)[41, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_ADD2"], (object)"");
						((DataGridView)dGV)[42, DC_Main.i].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["AC_ADD3"], (object)"");
						num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV)[9, DC_Main.i].Value));
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV)[10, DC_Main.i].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[11, DC_Main.i].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV)[15, DC_Main.i].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV)[14, DC_Main.i].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV)[16, DC_Main.i].Value));
						num22 = Conversions.ToDouble(Operators.AddObject((object)num22, ((DataGridView)dGV)[17, DC_Main.i].Value));
						dGV = null;
						DC_Main.i++;
					}
					((DataGridView)DGV).Rows.Add();
					((DataGridView)DGV).Rows.Add();
					if (((DataGridView)DGV).Rows.Count - 1 > 1)
					{
						int num28 = ((DataGridView)DGV).Rows.Count - 1;
						((DataGridView)DGV).Rows[num28].Cells[4].Value = "Total :";
						((DataGridView)DGV).Rows[num28].Cells[9].Value = num;
						((DataGridView)DGV).Rows[num28].Cells[10].Value = Strings.Format((object)num2, "0.00");
						((DataGridView)DGV).Rows[num28].Cells[11].Value = Strings.Format((object)num3, "0.00");
						((DataGridView)DGV).Rows[num28].Cells[15].Value = Strings.Format((object)num4, "0");
						((DataGridView)DGV).Rows[num28].Cells[14].Value = Strings.Format((object)num5, "0");
						((DataGridView)DGV).Rows[num28].Cells[16].Value = Strings.Format((object)num6, "0");
						((DataGridView)DGV).Rows[num28].Cells[17].Value = Strings.Format((object)num22, "0");
						((DataGridView)DGV).Rows[num28].Cells[18].Value = Strings.Format((object)num7, "0");
						((DataGridView)DGV).Rows[num28].Cells[19].Value = Strings.Format((object)num8, "0");
						((DataGridView)DGV).Rows[num28].Cells[20].Value = Strings.Format((object)num20, "0");
						((DataGridView)DGV).Rows[num28].Cells[21].Value = Strings.Format((object)num21, "0");
						((DataGridView)DGV).Rows[num28].Cells[22].Value = Strings.Format((object)num9, "0");
						((DataGridView)DGV).Rows[num28].Cells[23].Value = Strings.Format((object)num10, "0");
						((DataGridView)DGV).Rows[num28].Cells[24].Value = Strings.Format((object)num11, "0");
						((DataGridView)DGV).Rows[num28].Cells[25].Value = Strings.Format((object)num12, "0");
						((DataGridView)DGV).Rows[num28].Cells[27].Value = Strings.Format((object)num13, "0");
						((DataGridView)DGV).Rows[num28].Cells[26].Value = Strings.Format((object)num26, "0");
						((DataGridView)DGV).Rows[num28].Cells[28].Value = Strings.Format((object)num14, "0");
						((DataGridView)DGV).Rows[num28].Cells[29].Value = Strings.Format((object)num15, "0");
						((DataGridView)DGV).Rows[num28].Cells[30].Value = Strings.Format((object)num16, "0");
						((DataGridView)DGV).Rows[num28].Cells[31].Value = Strings.Format((object)num17, "0");
						((DataGridView)DGV).Rows[num28].Cells[32].Value = Strings.Format((object)num18, "0");
						((DataGridView)DGV).Rows[num28].Cells[33].Value = Strings.Format((object)num19, "0");
						((DataGridView)DGV).Rows[num28].Cells[36].Value = Strings.Format((object)num23, "0.000");
						((DataGridView)DGV).Rows[num28].Cells[37].Value = Strings.Format((object)num24, "0.00");
						((DataGridView)DGV).Rows[num28].Cells[38].Value = Strings.Format((object)num25, "0");
					}
				}
				else
				{
					if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
					{
						return;
					}
					((Control)tSerchAll).Enabled = true;
					((DataGridView)DGV_VCH).DataSource = null;
					((DataGridView)DGV_VCH).ClearSelection();
					((DataGridView)DGV_VCH).Rows.Clear();
					((Control)DGV_VCH).Refresh();
					BtnExit.Text = "&Exit";
					((Control)DGV).Visible = true;
					DGV_CLEAR();
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_DATE,A.CO_BOOK,A.VCH_NO,CASE WHEN A.CASH_AMT <> 0 AND A.CARD_AMT <> 0 THEN 'CASH/CARD' ELSE CASE WHEN A.CASH_AMT <> 0 THEN 'CASH' ELSE 'CARD' END END AS CashBank,'SALES' AS TRN_TYPE,A.TOT_AMT,B.AC_PANNO,B.AC_NAME FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
					if (Operators.CompareString(ScelectBook, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
					}
					DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
					RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DataView dataView2 = new DataView(RsStkSum);
					if (dataView2.Count <= 0)
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
					((DataGridView)DGV).ColumnCount = 9;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)DGV).Rows.Count);
					((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "VCH_DATE";
					((DataGridView)DGV).Columns[1].HeaderText = "VchDate";
					((DataGridView)DGV).Columns[2].Visible = false;
					((DataGridView)DGV).Columns[2].DataPropertyName = "CO_BOOK";
					((DataGridView)DGV).Columns[2].HeaderText = "Book";
					((DataGridView)DGV).Columns[3].Width = (int)Math.Round(120.0 * ColCon);
					((DataGridView)DGV).Columns[3].DataPropertyName = "VCH_NO";
					((DataGridView)DGV).Columns[3].HeaderText = "InvoiceNo";
					((DataGridView)DGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV).Columns[4].DataPropertyName = "CashBank";
					((DataGridView)DGV).Columns[4].HeaderText = "Payment Mode";
					((DataGridView)DGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[5].DataPropertyName = "TRN_TYPE";
					((DataGridView)DGV).Columns[5].HeaderText = "InvoicMode";
					((DataGridView)DGV).Columns[6].Width = (int)Math.Round(120.0 * ColCon);
					((DataGridView)DGV).Columns[6].DataPropertyName = "TOT_AMT";
					((DataGridView)DGV).Columns[6].HeaderText = "Total Amount";
					((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV).Columns[7].Width = (int)Math.Round(160.0 * ColCon);
					((DataGridView)DGV).Columns[7].DataPropertyName = "AC_PANNO";
					((DataGridView)DGV).Columns[7].HeaderText = "Civil Id";
					((DataGridView)DGV).Columns[8].Width = (int)Math.Round(275.0 * ColCon);
					((DataGridView)DGV).Columns[8].DataPropertyName = "AC_NAME";
					((DataGridView)DGV).Columns[8].HeaderText = "Customer Name";
					if (DC_Main.ScreenHight > 1.0)
					{
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
					}
					((DataGridView)DGV).DataSource = dataView2;
					if (((DataGridView)DGV).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
					{
						dataView2.AddNew();
						dataView2.AddNew();
					}
					double num29 = 0.0;
					int num30 = ((DataGridView)DGV).Rows.Count - 1;
					for (int i = 0; i <= num30; i++)
					{
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[3].Value, (object)""), (object)"Total :", false))
						{
							((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
							num29 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[5].Value, (object)""));
						}
					}
					int num31 = ((DataGridView)DGV).Rows.Count - 1;
					((DataGridView)DGV).Rows[num31].Cells[3].Value = "Total :";
					((DataGridView)DGV).Rows[num31].Cells[5].Value = num29;
					StkType = "Invoice";
				}
			}
			else
			{
				if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
				{
					return;
				}
				((Control)tSerchAll).Enabled = true;
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((Control)DGV_VCH).Refresh();
				BtnExit.Text = "&Exit";
				((Control)DGV).Visible = true;
				DGV_CLEAR();
				Old_ColSet();
				if (Operators.CompareString(CurRpt, "Old Stock", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,C.IT_NAME,YEAR(B.STK_DATE) as YrCode,MONTH(B.STK_DATE) AS MnCode,SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE - 1 end) AS Pcs  FROM (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND B.KR_NAME = '" + tAcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND B.STK_DATE IS NOT NULL AND A.STK_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND C.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"'  "), (object)" GROUP BY A.IT_CODE,C.IT_NAME,YEAR(B.STK_DATE),MONTH(B.STK_DATE) HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY C.IT_NAME,YEAR(B.STK_DATE),MONth(B.STK_DATE) "));
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				string text3 = "";
				DC_Main.R = -1;
				int num32 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				double num33 = default(double);
				while (DC_Main.M <= num32)
				{
					DataGridViewX dGV2 = DGV;
					if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"], (object)text3, false))
					{
						text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"], (object)""));
						num33 = 0.0;
						DC_Main.R++;
						((DataGridView)dGV2).Rows.Add();
						((DataGridView)dGV2)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"]);
						((DataGridView)dGV2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"]);
					}
					int num34 = ((BaseCollection)((DataGridView)dGV2).Columns).Count - 1;
					DC_Main.X = 3;
					while (DC_Main.X <= num34)
					{
						if (Operators.CompareString(Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.M]["YrCode"]), 3, 2) + "/" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["MnCode"]), "00"), ((DataGridView)DGV).Columns[DC_Main.X].HeaderText ?? "", false) == 0)
						{
							((DataGridView)dGV2)[DC_Main.X, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["Pcs"]);
							num33 = Conversions.ToDouble(Operators.AddObject((object)num33, DC_Main.Rshlp.Rows[DC_Main.M]["Pcs"]));
							ref double reference = ref TotPcs[DC_Main.X];
							reference = Conversions.ToDouble(Operators.AddObject((object)reference, DC_Main.Rshlp.Rows[DC_Main.M]["Pcs"]));
							((DataGridView)dGV2)[((BaseCollection)((DataGridView)dGV2).Columns).Count - 1, DC_Main.R].Value = num33;
							break;
						}
						DC_Main.X++;
					}
					dGV2 = null;
					DC_Main.M++;
				}
				DC_Main.Rshlp.Clear();
				int num35 = 0;
				((DataGridView)DGV).Rows.Add();
				((DataGridView)DGV).Rows.Add();
				DC_Main.R = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV)[1, DC_Main.R].Value = "Total :";
				int num36 = ((BaseCollection)((DataGridView)DGV).Columns).Count - 1;
				DC_Main.M = 3;
				while (DC_Main.M <= num36)
				{
					num35 = 0;
					int num37 = ((DataGridView)DGV).Rows.Count - 2;
					DC_Main.X = 0;
					while (DC_Main.X <= num37)
					{
						num35 = (int)Math.Round((double)num35 + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[DC_Main.M, DC_Main.X].Value)));
						DC_Main.X++;
					}
					((DataGridView)DGV)[DC_Main.M, DC_Main.X].Value = num35;
					DC_Main.M++;
				}
				StkType = "OldStock";
			}
		}
	}

	private void Old_ColSet()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		DataGridViewX dGV = DGV;
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT YEAR(B.STK_DATE) as YrCode,MONTH(B.STK_DATE) AS MnCode FROM (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND B.KR_NAME = '" + tAcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND B.STK_DATE IS NOT NULL AND A.STK_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND C.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"'  "), (object)" GROUP BY YEAR(B.STK_DATE),MONTH(B.STK_DATE) HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY YEAR(B.STK_DATE),MONth(B.STK_DATE) "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				TotPcs = new double[DC_Main.Tbl.Rows.Count + 4 + 1];
			}
			((DataGridView)DGV).Columns.Add("", "Sr");
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ItName");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(230.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ItCode");
			((DataGridView)DGV).Columns[2].Visible = false;
			DC_Main.i = 3;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV).Columns.Add("", Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["YrCode"]), 3, 2) + "/" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["MnCode"]), "00"));
				((DataGridView)DGV).Columns[DC_Main.i].Width = (int)Math.Round(55.0 * ColCon);
				((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				DC_Main.i++;
				DC_Main.M++;
			}
			((DataGridView)DGV).Columns.Add("", "Total");
			((DataGridView)DGV).Columns[DC_Main.i].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.Tbl.Clear();
			dGV = null;
		}
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
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
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
			((DataGridView)DGV_ITM).Columns.Clear();
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
			((DataGridView)DGV_ITM).Columns.Clear();
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
				((DataGridView)dGV_ITM).Columns[0].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "Sr");
				((DataGridView)dGV_ITM).Columns[1].Width = (int)Math.Round(40.0 * DC_Main.ScreenHight);
				((DataGridView)dGV_ITM).Columns.Add("", "Itm Name");
				((DataGridView)dGV_ITM).Columns[2].Width = (int)Math.Round(224.0 * DC_Main.ScreenHight);
				((DataGridView)dGV_ITM).Columns.Add("", "It Code");
				((DataGridView)dGV_ITM).Columns[3].Width = (int)Math.Round(80.0 * DC_Main.ScreenHight);
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
		((DataGridView)DGV_ITM).Columns.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		ScelectBook = "";
		chkItmSelect.Checked = false;
		chkBookSelect.Checked = false;
		((Control)PnlIt).Visible = false;
	}

	private void BookMast()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.CO_BOOK,A.BOOK_NAME FROM BOOK_DATA  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.CO_BOOK ";
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
				((DataGridView)dGV_ITM).Columns[0].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "CO_BOOK");
				((DataGridView)dGV_ITM).Columns[1].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridView)dGV_ITM).Columns.Add("", "BOOK_NAME");
				((DataGridView)dGV_ITM).Columns[2].Width = (int)Math.Round(250.0 * DC_Main.ScreenHight);
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV_ITM).Rows.Add();
					((DataGridView)dGV_ITM)[1, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["CO_BOOK"]);
					((DataGridView)dGV_ITM)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["BOOK_NAME"]);
					DC_Main.i++;
				}
				dGV_ITM = null;
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (chkBookSelect.Checked)
			{
				ScelectBook = "";
				int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false) && chkBookSelect.Checked)
					{
						ScelectBook = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(ScelectBook + "'"), ((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells[1].Value), (object)"',"));
					}
					DC_Main.M++;
				}
				if (chkBookSelect.Checked)
				{
					if (Operators.CompareString(ScelectBook, "", false) == 0)
					{
						Interaction.MsgBox((object)"Book Selection Not Done...", (MsgBoxStyle)0, (object)null);
						((Control)PnlIt).Visible = false;
					}
					else
					{
						ScelectBook = Strings.Mid(ScelectBook, 1, Strings.Len(ScelectBook) - 1);
						Interaction.MsgBox((object)"Book Selection is Ok...", (MsgBoxStyle)0, (object)null);
						((Control)PnlIt).Visible = false;
					}
				}
				return;
			}
			SelectIt = "";
			int num2 = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
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

	private void TGrCode_TextChanged(object sender, EventArgs e)
	{
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
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void DGV_DATE_DoubleClick(object sender, EventArgs e)
	{
		DGV_DoubleClick(DGV_DATE, new EventArgs());
	}

	private void btnState_Click(object sender, EventArgs e)
	{
		((Control)tSerchAll).Enabled = true;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		if (Operators.CompareString(CurRpt, "Purc Zoom", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_STATE As Code,C.AC_STATE As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,0 As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" AND D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)"   "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.RsQry += "GROUP BY C.AC_STATE ORDER BY C.AC_STATE";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_STATE As Code,C.AC_STATE As AcName,SUM(1) As Qty,SUM(ITM_PCS) As Pcs,  Sum(A.ITM_GWT) As Gwt,SUM(A.ITM_NWT) As NetWt,SUM(A.ITM_FINE) As FineWt,SUM(A.ITM_AMT) As ItmAmt,SUM(A.LBR_AMT) As LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.ITM_DISC)  As DiscAmt,0 As TaxAmt,0 As SlPrc,SUM(A.NET_AMT) As NetAmt  from ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE And A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(cboSalesType.SelectedIndex == 4, (object)"AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O'", RuntimeHelpers.GetObjectValue(Interaction.IIf(chkSalesRtn.Checked, (object)"AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' ", (object)" And A.ITM_SIGN = '-' AND A.TR_TYPE = 'S'")))), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)(" And D.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND A.IT_CODE IN (" + SelectIt + ")"))), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND C.AC_GR = '" + tGrCode.Text + "'"))), (object)"  "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK IN (" + ScelectBook + ")";
			}
			if (cboSalesType.SelectedIndex == 4)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('LABOUR WORK')";
			}
			else if (cboSalesType.SelectedIndex == 3)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('WH SALES','TOUR SALES')";
			}
			else if (cboSalesType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE')";
			}
			else
			{
				DC_Main.RsQry += "AND B.MAIN_BOOK IN ('SALES','SALES RETURNE','E INVOICE','WH SALES','OLD ITEM SALES','LABOUR WORK','TOUR SALES')";
			}
			if (chkOnlyTag.Checked)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			DC_Main.RsQry += "GROUP BY C.AC_STATE ORDER BY C.AC_STATE";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
		StkType = "State";
	}

	private void chkSalesRtn_CheckedChanged(object sender, EventArgs e)
	{
		if (chkSalesRtn.Checked)
		{
			BtnSize.Text = "-";
			((Control)BtnSize).Enabled = false;
		}
		else
		{
			BtnSize.Text = "Bill Wise";
			((Control)BtnSize).Enabled = true;
		}
	}

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.BOOK_NAME";
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
						tBookCode.Text = DC_Main.ColValue[1];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void chkBookSelect_Click(object sender, EventArgs e)
	{
		if (chkBookSelect.Checked)
		{
			((DataGridView)DGV_ITM).DataSource = null;
			((DataGridView)DGV_ITM).ClearSelection();
			((DataGridView)DGV_ITM).Rows.Clear();
			((DataGridView)DGV_ITM).Columns.Clear();
			((Control)DGV_ITM).Refresh();
			SelectIt = "";
			BookMast();
			((Control)PnlIt).Visible = true;
		}
		else
		{
			((DataGridView)DGV_ITM).DataSource = null;
			((DataGridView)DGV_ITM).ClearSelection();
			((DataGridView)DGV_ITM).Rows.Clear();
			((DataGridView)DGV_ITM).Columns.Clear();
			((Control)DGV_ITM).Refresh();
			SelectIt = "";
			((Control)PnlIt).Visible = false;
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
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
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,", Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0, (object)"AC_SHORT", (object)"''")), (object)" As ShortLB.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND AC_SHORT <> '' ORDER BY A.LC_CODE,A.AC_NAME"));
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,", Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0, (object)"AC_SHORT", (object)"''")), (object)" As ShortLD.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND AC_SHORT <> '' AND CAST(C.AC_CODE AS INT) < 100  "), (object)" UNION ALL SELECT A.AC_NAME,A.AC_CODE,"), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0, (object)"AC_SHORT", (object)"''")), (object)" As ShortLB.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND AC_SHORT <> '' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,", Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0, (object)"AC_SHORT", (object)"''")), (object)" As ShortL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND AC_SHORT <> '' ORDER BY A.AC_NAME"));
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[9];
			DC_Main.ColWidth[0] = 270.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 170.0;
			DC_Main.ColWidth[4] = 180.0;
			DC_Main.ColWidth[5] = 220.0;
			DC_Main.ColWidth[6] = 160.0;
			DC_Main.ColWidth[7] = 110.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[2];
					tAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
		}
	}
}
