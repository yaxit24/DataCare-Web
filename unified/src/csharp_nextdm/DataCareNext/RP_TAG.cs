using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_TAG : XtraForm
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
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private GridControl _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GridView1")]
	private GridView _GridView1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnStock")]
	private QButton _BtnStock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnOut")]
	private QButton _BtnOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnIn")]
	private QButton _BtnIn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnMrp")]
	private QButton _BtnMrp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnApr")]
	private QButton _BtnApr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAll")]
	private QButton _BtnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSumm")]
	private SimpleButton _BtnSumm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagNo")]
	private TextBox _tTagNo;

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
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkZeroId")]
	private CheckBox _chkZeroId;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkDuplicatTag")]
	private CheckBox _chkDuplicatTag;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkDoubelTag")]
	private CheckBox _chkDoubelTag;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRptType")]
	private ComboBox _cboRptType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTagLessNotStk")]
	private CheckBox _chkTagLessNotStk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkSlWtDiff")]
	private CheckBox _chkSlWtDiff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItDiff")]
	private CheckBox _chkItDiff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlDiff")]
	private Panel _pnlDiff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTagPcsDiff")]
	private CheckBox _chkTagPcsDiff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblX")]
	private Label _lblX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAdjust")]
	private SimpleButton _btnAdjust;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTagNotInBarDetl")]
	private CheckBox _chkTagNotInBarDetl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkslandStk")]
	private CheckBox _chkslandStk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSplit")]
	private SimpleButton _btnTagSplit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagWtChange")]
	private SimpleButton _btnTagWtChange;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ADJUST")]
	private DataGridViewX _DGV_ADJUST;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private double ColCon;

	private double HightCon;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string IdtlWithName;

	private string Col1;

	private string Col2;

	private string Col3;

	private string Col4;

	private string RptType;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1Pcs = 3;

	private const int c1GrWt = 4;

	private const int c1ConPrc = 5;

	private const int c1RateType = 6;

	private const int c1ItRate = 7;

	private const int c1ItmAmt = 8;

	private const int c1LbrRate = 9;

	private const int c1LbrAmt = 10;

	private const int c1NetAmt = 11;

	private const int c1ConWt = 12;

	private const int c1KrWt = 13;

	private const int c1KrConWt = 14;

	private const int c1ItType = 15;

	private const int c1RowSr = 16;

	private const int cAdjSrNo = 0;

	private const int cAdjTagNo = 1;

	private const int cAdjVchSrNo = 2;

	private const int cAdjCoBook = 3;

	private const int cAdjBookName = 4;

	private const int cAdjVchNo = 5;

	private const int cAdjDate = 6;

	private const int cAdjRowSr = 7;

	private const int cAdjItCode = 8;

	private const int cAdjTable = 9;

	private const int cAdjGwt = 10;

	private const int cAdjMainBook = 11;

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

	internal virtual GridControl DGV
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
			EventHandler eventHandler = DGV_DoubleClick;
			GridControl val = _DGV;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val = _DGV;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual GridView GridView1
	{
		[CompilerGenerated]
		get
		{
			return _GridView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			FocusedRowChangedEventHandler val = new FocusedRowChangedEventHandler(GridView1_FocusedRowChanged);
			GridView val2 = _GridView1;
			if (val2 != null)
			{
				((ColumnView)val2).FocusedRowChanged -= val;
			}
			_GridView1 = value;
			val2 = _GridView1;
			if (val2 != null)
			{
				((ColumnView)val2).FocusedRowChanged += val;
			}
		}
	}

	internal virtual QButton BtnStock
	{
		[CompilerGenerated]
		get
		{
			return _BtnStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnStock_Click;
			QButton val = _BtnStock;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnStock = value;
			val = _BtnStock;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnOut
	{
		[CompilerGenerated]
		get
		{
			return _BtnOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOut_Click;
			QButton val = _BtnOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnOut = value;
			val = _BtnOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnIn
	{
		[CompilerGenerated]
		get
		{
			return _BtnIn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIn_Click;
			QButton val = _BtnIn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnIn = value;
			val = _BtnIn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnMrp
	{
		[CompilerGenerated]
		get
		{
			return _BtnMrp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMrp_Click;
			QButton val = _BtnMrp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnMrp = value;
			val = _BtnMrp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnApr
	{
		[CompilerGenerated]
		get
		{
			return _BtnApr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnApr_Click;
			QButton val = _BtnApr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnApr = value;
			val = _BtnApr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnAll
	{
		[CompilerGenerated]
		get
		{
			return _BtnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAll_Click;
			QButton val = _BtnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAll = value;
			val = _BtnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual SimpleButton BtnSumm
	{
		[CompilerGenerated]
		get
		{
			return _BtnSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSumm_Click;
			SimpleButton val = _BtnSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSumm = value;
			val = _BtnSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tTagNo
	{
		[CompilerGenerated]
		get
		{
			return _tTagNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tTagNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tTagNo_KeyDown);
			TextBox val2 = _tTagNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tTagNo = value;
			val2 = _tTagNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_IDTL")]
	private virtual DataGridViewX _DGV_IDTL;

	internal virtual DataGridViewX DGV_IDTL
	{
		get
		{
			return _DGV_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_IDTL = value;
		}
	}

	internal virtual PictureBox PicImage
	{
		[CompilerGenerated]
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicImage_DoubleClick;
			PictureBox val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicImage = value;
			val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual PictureBox PicZoom
	{
		[CompilerGenerated]
		get
		{
			return _PicZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicZoom_DoubleClick;
			PictureBox val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicZoom = value;
			val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrName")]
	private virtual TextBox _tPrName;

	internal virtual TextBox tPrName
	{
		get
		{
			return _tPrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPrName = value;
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
			EventHandler eventHandler = tPrCode_LostFocus;
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).LostFocus -= eventHandler;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).LostFocus += eventHandler;
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
			EventHandler eventHandler = tGrCode_LostFocus;
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).LostFocus -= eventHandler;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).LostFocus += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkZeroId
	{
		[CompilerGenerated]
		get
		{
			return _chkZeroId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkZeroId_CheckedChanged;
			EventHandler eventHandler2 = chkZeroId_Click;
			CheckBox val = _chkZeroId;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkZeroId = value;
			val = _chkZeroId;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	internal virtual CheckBox chkDuplicatTag
	{
		[CompilerGenerated]
		get
		{
			return _chkDuplicatTag;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkDuplicatTag_CheckedChanged;
			EventHandler eventHandler2 = chkDuplicatTag_Click;
			CheckBox val = _chkDuplicatTag;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkDuplicatTag = value;
			val = _chkDuplicatTag;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	internal virtual CheckBox chkDoubelTag
	{
		[CompilerGenerated]
		get
		{
			return _chkDoubelTag;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkDoubelTag_CheckedChanged;
			EventHandler eventHandler2 = chkDoubelTag_Click;
			CheckBox val = _chkDoubelTag;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkDoubelTag = value;
			val = _chkDoubelTag;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
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
	[AccessedThroughProperty("tItName")]
	private virtual TextBox _tItName;

	internal virtual TextBox tItName
	{
		get
		{
			return _tItName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItName = value;
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

	internal virtual ComboBox cboRptType
	{
		[CompilerGenerated]
		get
		{
			return _cboRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CboRptType_SelectedIndexChanged;
			ComboBox val = _cboRptType;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_cboRptType = value;
			val = _cboRptType;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
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

	internal virtual CheckBox chkTagLessNotStk
	{
		[CompilerGenerated]
		get
		{
			return _chkTagLessNotStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkTagLessNotStk_CheckedChanged;
			EventHandler eventHandler2 = chkTagLessNotStk_Click;
			CheckBox val = _chkTagLessNotStk;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkTagLessNotStk = value;
			val = _chkTagLessNotStk;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSize")]
	private virtual ComboBox _cboSize;

	internal virtual ComboBox cboSize
	{
		get
		{
			return _cboSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSize = value;
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

	internal virtual CheckBox chkSlWtDiff
	{
		[CompilerGenerated]
		get
		{
			return _chkSlWtDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkSlWtDiff_CheckedChanged;
			EventHandler eventHandler2 = chkSlWtDiff_Click;
			CheckBox val = _chkSlWtDiff;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkSlWtDiff = value;
			val = _chkSlWtDiff;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	internal virtual CheckBox chkItDiff
	{
		[CompilerGenerated]
		get
		{
			return _chkItDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkItDiff_CheckedChanged;
			EventHandler eventHandler2 = chkItDiff_Click;
			CheckBox val = _chkItDiff;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkItDiff = value;
			val = _chkItDiff;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	internal virtual Panel pnlDiff
	{
		[CompilerGenerated]
		get
		{
			return _pnlDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = pnlDiff_DoubleClick;
			Panel val = _pnlDiff;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_pnlDiff = value;
			val = _pnlDiff;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkTagPcsDiff
	{
		[CompilerGenerated]
		get
		{
			return _chkTagPcsDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkTagPcsDiff_CheckedChanged;
			EventHandler eventHandler2 = chkTagPcsDiff_Click;
			CheckBox val = _chkTagPcsDiff;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkTagPcsDiff = value;
			val = _chkTagPcsDiff;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkEmpIsuLess")]
	private virtual CheckBox _chkEmpIsuLess;

	internal virtual CheckBox chkEmpIsuLess
	{
		get
		{
			return _chkEmpIsuLess;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkEmpIsuLess = value;
		}
	}

	internal virtual Label lblX
	{
		[CompilerGenerated]
		get
		{
			return _lblX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblX_Click;
			Label val = _lblX;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_lblX = value;
			val = _lblX;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnAdjust
	{
		[CompilerGenerated]
		get
		{
			return _btnAdjust;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAdjust_Click;
			SimpleButton val = _btnAdjust;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAdjust = value;
			val = _btnAdjust;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkTagNotInBarDetl
	{
		[CompilerGenerated]
		get
		{
			return _chkTagNotInBarDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkTagNotInBarDetl_CheckedChanged;
			EventHandler eventHandler2 = chkTagNotInBarDetl_Click;
			CheckBox val = _chkTagNotInBarDetl;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
				((Control)val).Click -= eventHandler2;
			}
			_chkTagNotInBarDetl = value;
			val = _chkTagNotInBarDetl;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
				((Control)val).Click += eventHandler2;
			}
		}
	}

	internal virtual CheckBox chkslandStk
	{
		[CompilerGenerated]
		get
		{
			return _chkslandStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkslandStk_Click;
			CheckBox val = _chkslandStk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkslandStk = value;
			val = _chkslandStk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnTagSplit
	{
		[CompilerGenerated]
		get
		{
			return _btnTagSplit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagSplit_Click;
			SimpleButton val = _btnTagSplit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagSplit = value;
			val = _btnTagSplit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnTagWtChange
	{
		[CompilerGenerated]
		get
		{
			return _btnTagWtChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagWtChange_Click;
			SimpleButton val = _btnTagWtChange;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagWtChange = value;
			val = _btnTagWtChange;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DataGridViewX DGV_ADJUST
	{
		[CompilerGenerated]
		get
		{
			return _DGV_ADJUST;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_ADJUST_CellContentClick);
			EventHandler eventHandler = DGV_ADJUST_DoubleClick;
			DataGridViewX val2 = _DGV_ADJUST;
			if (val2 != null)
			{
				((DataGridView)val2).CellContentClick -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_ADJUST = value;
			val2 = _DGV_ADJUST;
			if (val2 != null)
			{
				((DataGridView)val2).CellContentClick += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

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
			((XtraForm)this).Dispose(disposing);
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
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected O, but got Unknown
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected O, but got Unknown
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected O, but got Unknown
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0874: Expected O, but got Unknown
		//IL_097f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Expected O, but got Unknown
		//IL_09ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Expected O, but got Unknown
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Expected O, but got Unknown
		//IL_0b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b16: Expected O, but got Unknown
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc9: Expected O, but got Unknown
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected O, but got Unknown
		//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df6: Expected O, but got Unknown
		//IL_0eb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebd: Expected O, but got Unknown
		//IL_0f79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f83: Expected O, but got Unknown
		//IL_1043: Unknown result type (might be due to invalid IL or missing references)
		//IL_104d: Expected O, but got Unknown
		//IL_1130: Unknown result type (might be due to invalid IL or missing references)
		//IL_113a: Expected O, but got Unknown
		//IL_11a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b2: Expected O, but got Unknown
		//IL_1283: Unknown result type (might be due to invalid IL or missing references)
		//IL_128d: Expected O, but got Unknown
		//IL_12f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ff: Expected O, but got Unknown
		//IL_1301: Unknown result type (might be due to invalid IL or missing references)
		//IL_1307: Expected O, but got Unknown
		//IL_135b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1365: Expected O, but got Unknown
		//IL_1683: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1718: Unknown result type (might be due to invalid IL or missing references)
		//IL_1722: Expected O, but got Unknown
		//IL_1745: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a89: Expected O, but got Unknown
		//IL_1aac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df1: Expected O, but got Unknown
		//IL_1e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_20da: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2122: Unknown result type (might be due to invalid IL or missing references)
		//IL_214b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2155: Expected O, but got Unknown
		//IL_2178: Unknown result type (might be due to invalid IL or missing references)
		//IL_241e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2442: Unknown result type (might be due to invalid IL or missing references)
		//IL_2466: Unknown result type (might be due to invalid IL or missing references)
		//IL_248a: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24bd: Expected O, but got Unknown
		//IL_24e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2786: Unknown result type (might be due to invalid IL or missing references)
		//IL_27aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_281b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2825: Expected O, but got Unknown
		//IL_2848: Unknown result type (might be due to invalid IL or missing references)
		//IL_28cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d5: Expected O, but got Unknown
		//IL_293e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2948: Expected O, but got Unknown
		//IL_29e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ec: Expected O, but got Unknown
		//IL_2a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a90: Expected O, but got Unknown
		//IL_2afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b04: Expected O, but got Unknown
		//IL_2ba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bab: Expected O, but got Unknown
		//IL_2c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c52: Expected O, but got Unknown
		//IL_2d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d0a: Expected O, but got Unknown
		//IL_2da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dab: Expected O, but got Unknown
		//IL_2e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e66: Expected O, but got Unknown
		//IL_2efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f05: Expected O, but got Unknown
		//IL_2f83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f8d: Expected O, but got Unknown
		//IL_3072: Unknown result type (might be due to invalid IL or missing references)
		//IL_307c: Expected O, but got Unknown
		//IL_30e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_30ef: Expected O, but got Unknown
		//IL_32b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ba: Expected O, but got Unknown
		//IL_333c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3346: Expected O, but got Unknown
		//IL_33c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ce: Expected O, but got Unknown
		//IL_3450: Unknown result type (might be due to invalid IL or missing references)
		//IL_345a: Expected O, but got Unknown
		//IL_34db: Unknown result type (might be due to invalid IL or missing references)
		//IL_34e5: Expected O, but got Unknown
		//IL_3595: Unknown result type (might be due to invalid IL or missing references)
		//IL_359f: Expected O, but got Unknown
		//IL_364f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3659: Expected O, but got Unknown
		//IL_3709: Unknown result type (might be due to invalid IL or missing references)
		//IL_3713: Expected O, but got Unknown
		//IL_3792: Unknown result type (might be due to invalid IL or missing references)
		//IL_379c: Expected O, but got Unknown
		//IL_3809: Unknown result type (might be due to invalid IL or missing references)
		//IL_3813: Expected O, but got Unknown
		//IL_38d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_38da: Expected O, but got Unknown
		//IL_3947: Unknown result type (might be due to invalid IL or missing references)
		//IL_3951: Expected O, but got Unknown
		//IL_39ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_39f8: Expected O, but got Unknown
		//IL_3a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9f: Expected O, but got Unknown
		//IL_3b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b6f: Expected O, but got Unknown
		//IL_3bdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_3be9: Expected O, but got Unknown
		//IL_3e17: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e21: Expected O, but got Unknown
		//IL_3ee1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eeb: Expected O, but got Unknown
		//IL_3f8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f99: Expected O, but got Unknown
		//IL_408e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4098: Expected O, but got Unknown
		//IL_4149: Unknown result type (might be due to invalid IL or missing references)
		//IL_4153: Expected O, but got Unknown
		//IL_4222: Unknown result type (might be due to invalid IL or missing references)
		//IL_422c: Expected O, but got Unknown
		//IL_4307: Unknown result type (might be due to invalid IL or missing references)
		//IL_4311: Expected O, but got Unknown
		//IL_43ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b7: Expected O, but got Unknown
		//IL_443d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4447: Expected O, but got Unknown
		//IL_4534: Unknown result type (might be due to invalid IL or missing references)
		//IL_453e: Expected O, but got Unknown
		//IL_45a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b1: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_TAG));
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
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSumm = new SimpleButton();
		btnTagWtChange = new SimpleButton();
		btnTagSplit = new SimpleButton();
		chkDuplicatTag = new CheckBox();
		chkTagLessNotStk = new CheckBox();
		chkSlWtDiff = new CheckBox();
		chkItDiff = new CheckBox();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tSerchAll = new SearchControl();
		DGV = new GridControl();
		GridView1 = new GridView();
		BtnStock = new QButton();
		BtnOut = new QButton();
		BtnIn = new QButton();
		BtnMrp = new QButton();
		BtnApr = new QButton();
		BtnAll = new QButton();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Label1 = new Label();
		tTagNo = new TextBox();
		Label2 = new Label();
		Label4 = new Label();
		Label5 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		DGV_IDTL = new DataGridViewX();
		PicImage = new PictureBox();
		PicZoom = new PictureBox();
		tPrName = new TextBox();
		tPrCode = new TextBox();
		tGrName = new TextBox();
		tGrCode = new TextBox();
		chkZeroId = new CheckBox();
		chkDoubelTag = new CheckBox();
		tLcCode = new TextBox();
		tItName = new TextBox();
		tItCode = new TextBox();
		Label6 = new Label();
		cboRptType = new ComboBox();
		Label7 = new Label();
		Label8 = new Label();
		tBookCode = new TextBox();
		cboSize = new ComboBox();
		Label9 = new Label();
		pnlDiff = new Panel();
		chkslandStk = new CheckBox();
		chkTagNotInBarDetl = new CheckBox();
		btnAdjust = new SimpleButton();
		lblX = new Label();
		chkTagPcsDiff = new CheckBox();
		chkEmpIsuLess = new CheckBox();
		DGV_ADJUST = new DataGridViewX();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)GridView1).BeginInit();
		((ISupportInitialize)DGV_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((Control)pnlDiff).SuspendLayout();
		((ISupportInitialize)DGV_ADJUST).BeginInit();
		((XtraForm)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSumm);
		((Control)PnlBotam).Controls.Add((Control)(object)btnTagWtChange);
		((Control)PnlBotam).Controls.Add((Control)(object)btnTagSplit);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 13;
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
		((Control)BtnExit).TabIndex = 5;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1118, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 3;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(1021, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 2;
		BtnSave.Text = "&Excel";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)BtnDelete).Location = new Point(924, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 4;
		BtnDelete.Text = "Counter";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
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
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSumm).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSumm).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSumm).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSumm).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSumm.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSumm.ImageOptions.SvgImage");
		((Control)BtnSumm).Location = new Point(730, 3);
		((BaseControl)BtnSumm).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSumm).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSumm).Name = "BtnSumm";
		((Control)BtnSumm).Size = new Size(91, 37);
		((Control)BtnSumm).TabIndex = 1;
		BtnSumm.Text = "&Summ";
		((BaseButton)BtnSumm).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnTagWtChange).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagWtChange).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTagWtChange).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagWtChange).Appearance.Options.UseForeColor = true;
		((Control)btnTagWtChange).Location = new Point(608, 3);
		((BaseControl)btnTagWtChange).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTagWtChange).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagWtChange).Name = "btnTagWtChange";
		((Control)btnTagWtChange).Size = new Size(116, 37);
		((Control)btnTagWtChange).TabIndex = 7;
		btnTagWtChange.Text = "tag Wt Change";
		((BaseButton)btnTagWtChange).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnTagSplit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagSplit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTagSplit).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagSplit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnTagSplit.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)btnTagSplit).Location = new Point(511, 3);
		((BaseControl)btnTagSplit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTagSplit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSplit).Name = "btnTagSplit";
		((Control)btnTagSplit).Size = new Size(91, 37);
		((Control)btnTagSplit).TabIndex = 6;
		btnTagSplit.Text = "tag Split";
		((BaseButton)btnTagSplit).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnTagSplit).Visible = false;
		((ButtonBase)chkDuplicatTag).BackColor = Color.Transparent;
		((Control)chkDuplicatTag).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkDuplicatTag).ForeColor = Color.Black;
		((Control)chkDuplicatTag).Location = new Point(20, 192);
		((Control)chkDuplicatTag).Name = "chkDuplicatTag";
		((Control)chkDuplicatTag).RightToLeft = (RightToLeft)0;
		((Control)chkDuplicatTag).Size = new Size(116, 31);
		((Control)chkDuplicatTag).TabIndex = 1173;
		((ButtonBase)chkDuplicatTag).Text = "Duplicat Tag";
		((ButtonBase)chkDuplicatTag).UseVisualStyleBackColor = false;
		((Control)chkDuplicatTag).Visible = false;
		((ButtonBase)chkTagLessNotStk).BackColor = Color.Transparent;
		((Control)chkTagLessNotStk).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkTagLessNotStk).ForeColor = Color.Maroon;
		((Control)chkTagLessNotStk).Location = new Point(20, 6);
		((Control)chkTagLessNotStk).Name = "chkTagLessNotStk";
		((Control)chkTagLessNotStk).RightToLeft = (RightToLeft)0;
		((Control)chkTagLessNotStk).Size = new Size(256, 31);
		((Control)chkTagLessNotStk).TabIndex = 1174;
		((ButtonBase)chkTagLessNotStk).Text = "Tag Less But Tag Id Diff";
		((ButtonBase)chkTagLessNotStk).UseVisualStyleBackColor = false;
		((Control)chkTagLessNotStk).Visible = false;
		((ButtonBase)chkSlWtDiff).BackColor = Color.Transparent;
		((Control)chkSlWtDiff).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkSlWtDiff).ForeColor = Color.Black;
		((Control)chkSlWtDiff).Location = new Point(20, 130);
		((Control)chkSlWtDiff).Name = "chkSlWtDiff";
		((Control)chkSlWtDiff).RightToLeft = (RightToLeft)0;
		((Control)chkSlWtDiff).Size = new Size(169, 31);
		((Control)chkSlWtDiff).TabIndex = 1175;
		((ButtonBase)chkSlWtDiff).Text = "Tag Wt And Sl Wt Diff";
		((ButtonBase)chkSlWtDiff).UseVisualStyleBackColor = false;
		((Control)chkSlWtDiff).Visible = false;
		((ButtonBase)chkItDiff).BackColor = Color.Transparent;
		((Control)chkItDiff).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItDiff).ForeColor = Color.Black;
		((Control)chkItDiff).Location = new Point(20, 99);
		((Control)chkItDiff).Name = "chkItDiff";
		((Control)chkItDiff).RightToLeft = (RightToLeft)0;
		((Control)chkItDiff).Size = new Size(216, 31);
		((Control)chkItDiff).TabIndex = 1177;
		((ButtonBase)chkItDiff).Text = "Tag Sam But  It Code Diff";
		((ButtonBase)chkItDiff).UseVisualStyleBackColor = false;
		((Control)chkItDiff).Visible = false;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1215, 458);
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
		lblBook.Text = "Tag Stock Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)tSerchAll).Location = new Point(78, 69);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Tag Search";
		((Control)tSerchAll).Size = new Size(158, 22);
		((Control)tSerchAll).TabIndex = 2;
		((Control)DGV).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DGV).Location = new Point(12, 136);
		DGV.MainView = (BaseView)(object)GridView1;
		((Control)DGV).Name = "DGV";
		((Control)DGV).Size = new Size(1161, 294);
		((Control)DGV).TabIndex = 7;
		DGV.ViewCollection.AddRange((BaseView[])(object)new BaseView[1] { (BaseView)GridView1 });
		((BaseView)GridView1).GridControl = DGV;
		((BaseView)GridView1).Name = "GridView1";
		((ColumnViewOptionsBehavior)GridView1.OptionsBehavior).Editable = false;
		GridView1.OptionsView.ShowFooter = true;
		((QControl)BtnStock).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnStock).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnStock).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnStock).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnStock).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnStock).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnStock).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnStock).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnStock).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnStock).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnStock).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnStock).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnStock).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnStock).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnStock).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnStock).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnStock.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Image = null;
		((QControl)BtnStock).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnStock).Location = new Point(435, 106);
		((Control)BtnStock).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnStock).Name = "BtnStock";
		((Control)BtnStock).Size = new Size(143, 37);
		((Control)BtnStock).TabIndex = 7;
		BtnStock.Text = "&Stock Tag";
		((QControl)BtnOut).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnOut).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOut).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnOut).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnOut).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOut).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOut).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOut).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnOut).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnOut).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnOut).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnOut).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOut).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOut).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnOut).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnOut).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnOut.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Image = null;
		((QControl)BtnOut).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnOut).Location = new Point(254, 106);
		((Control)BtnOut).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnOut).Name = "BtnOut";
		((Control)BtnOut).Size = new Size(143, 37);
		((Control)BtnOut).TabIndex = 9;
		BtnOut.Text = "&Out Tag";
		((QControl)BtnIn).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnIn).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnIn).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnIn).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnIn).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnIn).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnIn).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnIn).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnIn).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnIn).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnIn).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnIn).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnIn).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnIn).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnIn).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnIn).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnIn.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Image = null;
		((QControl)BtnIn).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnIn).Location = new Point(77, 106);
		((Control)BtnIn).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnIn).Name = "BtnIn";
		((Control)BtnIn).Size = new Size(143, 37);
		((Control)BtnIn).TabIndex = 8;
		BtnIn.Text = "&In Tag";
		((QControl)BtnMrp).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnMrp).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnMrp).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnMrp).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnMrp).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnMrp).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnMrp).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnMrp).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnMrp).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnMrp).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnMrp).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnMrp).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnMrp).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnMrp).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnMrp).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnMrp).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnMrp.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMrp.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMrp.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMrp.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnMrp.Image = null;
		((QControl)BtnMrp).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnMrp).Location = new Point(608, 106);
		((Control)BtnMrp).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnMrp).Name = "BtnMrp";
		((Control)BtnMrp).Size = new Size(143, 37);
		((Control)BtnMrp).TabIndex = 10;
		BtnMrp.Text = "&Mrp Tag";
		((QControl)BtnApr).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnApr).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnApr).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnApr).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnApr).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnApr).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnApr).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnApr).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnApr).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnApr).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnApr).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnApr).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnApr).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnApr).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnApr).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnApr).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnApr.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnApr.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnApr.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnApr.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnApr.Image = null;
		((QControl)BtnApr).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnApr).Location = new Point(785, 106);
		((Control)BtnApr).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnApr).Name = "BtnApr";
		((Control)BtnApr).Size = new Size(143, 37);
		((Control)BtnApr).TabIndex = 11;
		BtnApr.Text = "&Apr Pending";
		((QControl)BtnAll).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnAll).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAll).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnAll).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnAll).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnAll).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAll).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAll).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnAll).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnAll).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnAll).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnAll).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAll).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnAll).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnAll).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnAll).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnAll.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Image = null;
		((QControl)BtnAll).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnAll).Location = new Point(962, 106);
		((Control)BtnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnAll).Name = "BtnAll";
		((Control)BtnAll).Size = new Size(143, 37);
		((Control)BtnAll).TabIndex = 12;
		BtnAll.Text = "&All Tag";
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(848, 41);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(103, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(775, 40);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(64, 20);
		((Control)Label3).TabIndex = 124;
		Label3.Text = "It Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(247, 69);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(65, 20);
		((Control)Label1).TabIndex = 126;
		Label1.Text = "PrCode";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(1052, 69);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(82, 22);
		((Control)tTagNo).TabIndex = 6;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(984, 69);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(57, 20);
		((Control)Label2).TabIndex = 128;
		Label2.Text = "TagNo";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(242, 43);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(70, 20);
		((Control)Label4).TabIndex = 130;
		Label4.Text = "Group";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(29, 42);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(44, 20);
		((Control)Label5).TabIndex = 133;
		Label5.Text = "Date";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(160, 41);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(78, 41);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((DataGridView)DGV_IDTL).AllowUserToAddRows = false;
		((DataGridView)DGV_IDTL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_IDTL).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_IDTL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_IDTL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_IDTL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_IDTL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_IDTL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(30, 57, 91);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_IDTL).DefaultCellStyle = val3;
		((DataGridView)DGV_IDTL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_IDTL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_IDTL).Location = new Point(12, 436);
		((Control)DGV_IDTL).Name = "DGV_IDTL";
		DGV_IDTL.PaintEnhancedSelection = false;
		((DataGridView)DGV_IDTL).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_IDTL).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_IDTL).RowHeadersVisible = false;
		((DataGridView)DGV_IDTL).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_IDTL).RowsDefaultCellStyle = val5;
		DGV_IDTL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_IDTL.SelectAllSignVisible = false;
		((DataGridView)DGV_IDTL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_IDTL).Size = new Size(990, 120);
		((DataGridView)DGV_IDTL).StandardTab = true;
		((Control)DGV_IDTL).TabIndex = 1142;
		((Control)PicImage).BackColor = Color.LavenderBlush;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(1012, 436);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(161, 120);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1143;
		PicImage.TabStop = false;
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1158, 82);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(12, 32);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1157;
		PicZoom.TabStop = false;
		((TextBoxBase)tPrName).BackColor = Color.PapayaWhip;
		((Control)tPrName).Font = new Font("Tahoma", 9f);
		((Control)tPrName).Location = new Point(373, 69);
		((TextBoxBase)tPrName).MaxLength = 50;
		((Control)tPrName).Name = "tPrName";
		((Control)tPrName).Size = new Size(140, 22);
		((Control)tPrName).TabIndex = 1168;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(322, 69);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(48, 22);
		((Control)tPrCode).TabIndex = 1166;
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		((Control)tGrName).Font = new Font("Tahoma", 9f);
		((Control)tGrName).Location = new Point(373, 43);
		((TextBoxBase)tGrName).MaxLength = 50;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(140, 22);
		((Control)tGrName).TabIndex = 1170;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(322, 43);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(48, 22);
		((Control)tGrCode).TabIndex = 1169;
		((ButtonBase)chkZeroId).BackColor = Color.Transparent;
		((Control)chkZeroId).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkZeroId).ForeColor = Color.Black;
		((Control)chkZeroId).Location = new Point(20, 223);
		((Control)chkZeroId).Name = "chkZeroId";
		((Control)chkZeroId).RightToLeft = (RightToLeft)0;
		((Control)chkZeroId).Size = new Size(102, 31);
		((Control)chkZeroId).TabIndex = 1171;
		((ButtonBase)chkZeroId).Text = "Zero Tag Id";
		((ButtonBase)chkZeroId).UseVisualStyleBackColor = false;
		((ButtonBase)chkDoubelTag).BackColor = Color.Transparent;
		((Control)chkDoubelTag).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkDoubelTag).ForeColor = Color.Black;
		((Control)chkDoubelTag).Location = new Point(20, 68);
		((Control)chkDoubelTag).Name = "chkDoubelTag";
		((Control)chkDoubelTag).RightToLeft = (RightToLeft)0;
		((Control)chkDoubelTag).Size = new Size(146, 31);
		((Control)chkDoubelTag).TabIndex = 1172;
		((ButtonBase)chkDoubelTag).Text = "Tag Less 2 Time";
		((ButtonBase)chkDoubelTag).UseVisualStyleBackColor = false;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1090, 5);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1177;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((TextBoxBase)tItName).BackColor = Color.PapayaWhip;
		((Control)tItName).Font = new Font("Tahoma", 9f);
		((Control)tItName).Location = new Point(638, 42);
		((TextBoxBase)tItName).MaxLength = 50;
		((Control)tItName).Name = "tItName";
		((Control)tItName).Size = new Size(114, 22);
		((Control)tItName).TabIndex = 1180;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9f);
		((Control)tItCode).Location = new Point(586, 42);
		((TextBoxBase)tItCode).MaxLength = 6;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(48, 22);
		((Control)tItCode).TabIndex = 1179;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(520, 42);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(58, 20);
		((Control)Label6).TabIndex = 1178;
		Label6.Text = "ItCode";
		Label6.TextAlign = (ContentAlignment)64;
		cboRptType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboRptType).Font = new Font("Tahoma", 9f);
		((ListControl)cboRptType).FormattingEnabled = true;
		((Control)cboRptType).Location = new Point(848, 69);
		((Control)cboRptType).Name = "cboRptType";
		((Control)cboRptType).Size = new Size(103, 22);
		((Control)cboRptType).TabIndex = 1181;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(768, 69);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(71, 20);
		((Control)Label7).TabIndex = 1182;
		Label7.Text = "RptType";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(968, 41);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(73, 20);
		((Control)Label8).TabIndex = 1184;
		Label8.Text = "Book No";
		Label8.TextAlign = (ContentAlignment)64;
		((Control)tBookCode).Font = new Font("Tahoma", 9f);
		((Control)tBookCode).Location = new Point(1052, 41);
		((TextBoxBase)tBookCode).MaxLength = 15;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(82, 22);
		((Control)tBookCode).TabIndex = 1183;
		tBookCode.TextAlign = (HorizontalAlignment)2;
		cboSize.AutoCompleteMode = (AutoCompleteMode)3;
		cboSize.AutoCompleteSource = (AutoCompleteSource)256;
		cboSize.BackColor = Color.FromArgb(255, 224, 192);
		cboSize.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboSize).Font = new Font("Tahoma", 9f);
		((ListControl)cboSize).FormattingEnabled = true;
		((Control)cboSize).Location = new Point(586, 69);
		((Control)cboSize).Name = "cboSize";
		((Control)cboSize).Size = new Size(165, 22);
		((Control)cboSize).TabIndex = 1188;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(526, 69);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(52, 20);
		((Control)Label9).TabIndex = 1189;
		Label9.Text = "Size";
		Label9.TextAlign = (ContentAlignment)64;
		((Control)pnlDiff).BackColor = SystemColors.Control;
		pnlDiff.BorderStyle = (BorderStyle)1;
		((Control)pnlDiff).Controls.Add((Control)(object)chkslandStk);
		((Control)pnlDiff).Controls.Add((Control)(object)chkTagNotInBarDetl);
		((Control)pnlDiff).Controls.Add((Control)(object)btnAdjust);
		((Control)pnlDiff).Controls.Add((Control)(object)lblX);
		((Control)pnlDiff).Controls.Add((Control)(object)chkTagPcsDiff);
		((Control)pnlDiff).Controls.Add((Control)(object)chkTagLessNotStk);
		((Control)pnlDiff).Controls.Add((Control)(object)chkItDiff);
		((Control)pnlDiff).Controls.Add((Control)(object)chkSlWtDiff);
		((Control)pnlDiff).Controls.Add((Control)(object)chkDuplicatTag);
		((Control)pnlDiff).Controls.Add((Control)(object)chkDoubelTag);
		((Control)pnlDiff).Controls.Add((Control)(object)chkZeroId);
		((Control)pnlDiff).Location = new Point(12, 265);
		((Control)pnlDiff).Name = "pnlDiff";
		((Control)pnlDiff).Size = new Size(344, 291);
		((Control)pnlDiff).TabIndex = 1190;
		((Control)pnlDiff).Visible = false;
		((ButtonBase)chkslandStk).BackColor = Color.Transparent;
		((Control)chkslandStk).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkslandStk).ForeColor = Color.Black;
		((Control)chkslandStk).Location = new Point(20, 255);
		((Control)chkslandStk).Name = "chkslandStk";
		((Control)chkslandStk).RightToLeft = (RightToLeft)0;
		((Control)chkslandStk).Size = new Size(203, 31);
		((Control)chkslandStk).TabIndex = 1182;
		((ButtonBase)chkslandStk).Text = "Present Sl And Stock Both";
		((ButtonBase)chkslandStk).UseVisualStyleBackColor = false;
		((Control)chkslandStk).Visible = false;
		((ButtonBase)chkTagNotInBarDetl).BackColor = Color.Transparent;
		((Control)chkTagNotInBarDetl).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkTagNotInBarDetl).ForeColor = Color.Maroon;
		((Control)chkTagNotInBarDetl).Location = new Point(20, 37);
		((Control)chkTagNotInBarDetl).Name = "chkTagNotInBarDetl";
		((Control)chkTagNotInBarDetl).RightToLeft = (RightToLeft)0;
		((Control)chkTagNotInBarDetl).Size = new Size(256, 31);
		((Control)chkTagNotInBarDetl).TabIndex = 1181;
		((ButtonBase)chkTagNotInBarDetl).Text = "Tag Not In BarDetail";
		((ButtonBase)chkTagNotInBarDetl).UseVisualStyleBackColor = false;
		((BaseStyleControl)btnAdjust).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnAdjust).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnAdjust).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnAdjust).Appearance.Options.UseForeColor = true;
		((Control)btnAdjust).Location = new Point(241, 239);
		((BaseControl)btnAdjust).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnAdjust).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnAdjust).Name = "btnAdjust";
		((Control)btnAdjust).Size = new Size(91, 37);
		((Control)btnAdjust).TabIndex = 1180;
		btnAdjust.Text = "Adjust";
		((BaseButton)btnAdjust).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)lblX).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblX).ForeColor = Color.Black;
		lblX.ImeMode = (ImeMode)0;
		((Control)lblX).Location = new Point(302, 13);
		((Control)lblX).Name = "lblX";
		((Control)lblX).Size = new Size(25, 20);
		((Control)lblX).TabIndex = 1179;
		lblX.Text = "X";
		lblX.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkTagPcsDiff).BackColor = Color.Transparent;
		((Control)chkTagPcsDiff).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkTagPcsDiff).ForeColor = Color.Black;
		((Control)chkTagPcsDiff).Location = new Point(20, 161);
		((Control)chkTagPcsDiff).Name = "chkTagPcsDiff";
		((Control)chkTagPcsDiff).RightToLeft = (RightToLeft)0;
		((Control)chkTagPcsDiff).Size = new Size(169, 31);
		((Control)chkTagPcsDiff).TabIndex = 1178;
		((ButtonBase)chkTagPcsDiff).Text = "Tag Pcs And Sl Pcs Diff";
		((ButtonBase)chkTagPcsDiff).UseVisualStyleBackColor = false;
		((Control)chkTagPcsDiff).Visible = false;
		((ButtonBase)chkEmpIsuLess).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkEmpIsuLess).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkEmpIsuLess).ForeColor = Color.Black;
		((Control)chkEmpIsuLess).Location = new Point(941, 7);
		((Control)chkEmpIsuLess).Name = "chkEmpIsuLess";
		((Control)chkEmpIsuLess).RightToLeft = (RightToLeft)0;
		((Control)chkEmpIsuLess).Size = new Size(123, 20);
		((Control)chkEmpIsuLess).TabIndex = 1191;
		((ButtonBase)chkEmpIsuLess).Text = "Emp Isu Less";
		((ButtonBase)chkEmpIsuLess).UseVisualStyleBackColor = false;
		((Control)chkEmpIsuLess).Visible = false;
		((DataGridView)DGV_ADJUST).AllowUserToAddRows = false;
		((DataGridView)DGV_ADJUST).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ADJUST).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ADJUST).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_ADJUST).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ADJUST).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ADJUST).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ADJUST).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_ADJUST).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ADJUST).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(30, 57, 91);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ADJUST).DefaultCellStyle = val8;
		((DataGridView)DGV_ADJUST).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ADJUST).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ADJUST).Location = new Point(1179, 136);
		((Control)DGV_ADJUST).Name = "DGV_ADJUST";
		DGV_ADJUST.PaintEnhancedSelection = false;
		((DataGridView)DGV_ADJUST).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ADJUST).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_ADJUST).RowHeadersVisible = false;
		((DataGridView)DGV_ADJUST).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ADJUST).RowsDefaultCellStyle = val10;
		DGV_ADJUST.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_ADJUST.SelectAllSignVisible = false;
		((DataGridView)DGV_ADJUST).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ADJUST).Size = new Size(282, 147);
		((DataGridView)DGV_ADJUST).StandardTab = true;
		((Control)DGV_ADJUST).TabIndex = 1192;
		((Control)DGV_ADJUST).Visible = false;
		((XtraForm)this).Appearance.BackColor = SystemColors.ButtonHighlight;
		((XtraForm)this).Appearance.Options.UseBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)DGV_ADJUST);
		((Control)this).Controls.Add((Control)(object)chkEmpIsuLess);
		((Control)this).Controls.Add((Control)(object)pnlDiff);
		((Control)this).Controls.Add((Control)(object)cboSize);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)cboRptType);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tItName);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)DGV_IDTL);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tTagNo);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)BtnAll);
		((Control)this).Controls.Add((Control)(object)BtnApr);
		((Control)this).Controls.Add((Control)(object)BtnMrp);
		((Control)this).Controls.Add((Control)(object)BtnIn);
		((Control)this).Controls.Add((Control)(object)BtnOut);
		((Control)this).Controls.Add((Control)(object)BtnStock);
		((Control)this).Controls.Add((Control)(object)tSerchAll);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_TAG";
		((XtraForm)this).Text = "Tag Stock Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)GridView1).EndInit();
		((ISupportInitialize)DGV_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((Control)pnlDiff).ResumeLayout(false);
		((ISupportInitialize)DGV_ADJUST).EndInit();
		((XtraForm)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public RP_TAG()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		((Form)this).Load += RP_TAG_Load;
		((Form)this).Deactivate += RP_TAG_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_TAG_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_TAG_KeyDown);
		((Form)this).Activated += RP_TAG_Activated;
		((Form)this).Closed += RP_TAG_Closed;
		Col1 = "C1";
		Col2 = "C2";
		Col3 = "C3";
		Col4 = "C4";
		InitializeComponent();
	}

	private void Dgv_Adj_Feel()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		((DataGridView)DGV_ADJUST).DataSource = null;
		((DataGridView)DGV_ADJUST).ClearSelection();
		((DataGridView)DGV_ADJUST).Rows.Clear();
		((DataGridView)DGV_ADJUST).Columns.Clear();
		((Control)DGV_ADJUST).Refresh();
		((Control)DGV_ADJUST).Width = ((Control)DGV).Width;
		checked
		{
			((Control)DGV_ADJUST).Height = ((Control)DGV).Height + 10;
			((Control)DGV_ADJUST).Top = ((Control)DGV).Top;
			((Control)DGV_ADJUST).Left = ((Control)DGV).Left;
			((Control)DGV_ADJUST).Visible = true;
			((DataGridView)DGV_ADJUST).MultiSelect = false;
			((DataGridView)DGV_ADJUST).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 9f, (FontStyle)1);
			if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
			{
				((DataGridView)DGV_ADJUST).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_ADJUST).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_ADJUST).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_ADJUST).RowTemplate.Height = DC_Main.MsGridRowHeight;
			}
			((DataGridView)DGV_ADJUST).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
			((DataGridView)DGV_ADJUST).AutoGenerateColumns = false;
			((DataGridView)DGV_ADJUST).Columns.Add("", "Sr");
			((DataGridView)DGV_ADJUST).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "TagNo");
			((DataGridView)DGV_ADJUST).Columns[1].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "TagId");
			((DataGridView)DGV_ADJUST).Columns[2].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_ADJUST).Columns.Add("", "Book");
			((DataGridView)DGV_ADJUST).Columns[3].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "BookName");
			((DataGridView)DGV_ADJUST).Columns[4].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "VchNo");
			((DataGridView)DGV_ADJUST).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "VchDate");
			((DataGridView)DGV_ADJUST).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "RowSr");
			((DataGridView)DGV_ADJUST).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_ADJUST).Columns.Add("", "ItCode");
			((DataGridView)DGV_ADJUST).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "TblCode");
			((DataGridView)DGV_ADJUST).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns.Add("", "GrWt");
			((DataGridView)DGV_ADJUST).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_ADJUST).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_ADJUST).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_ADJUST).Columns.Add("", "MainBook");
			((DataGridView)DGV_ADJUST).Columns[11].Visible = false;
			DC_Main.RsQry = "SELECT TAG_NO,VCH_SRNO,COUNT(*) As Record FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_SIGN = '-' AND TAG_NO <> 'N' AND BOOK_NAME NOT IN ('APR ISU','SALES ORDER')  GROUP BY TAG_NO,VCH_SRNO HAVING COUNT(*) > 1 ORDER BY COUNT(*) DESC";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			int num = 0;
			int num2 = RsStkSum.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_NAME As BookName,B.MAIN_BOOK FROM MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), RsStkSum.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND A.VCH_SRNO = "), RsStkSum.Rows[DC_Main.M]["VCH_SRNO"]), (object)" AND ITM_SIGN = '-' ORDER BY VCH_DATE,CO_BOOK,VCH_NO "));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				int num3 = 0;
				while (num3 < dataTable.Rows.Count)
				{
					DataGridViewX dGV_ADJUST = DGV_ADJUST;
					((DataGridView)dGV_ADJUST).Rows.Add();
					((DataGridView)dGV_ADJUST)[0, num].Value = num + 1;
					((DataGridView)dGV_ADJUST)[3, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["CO_BOOK"], (object)"");
					((DataGridView)dGV_ADJUST)[4, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["BookName"], (object)"");
					((DataGridView)dGV_ADJUST)[6, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["VCH_DATE"], (object)"");
					((DataGridView)dGV_ADJUST)[5, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["VCH_NO"], (object)"");
					((DataGridView)dGV_ADJUST)[7, num].Value = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[num3]["SR_NO"], (object)""));
					((DataGridView)dGV_ADJUST)[8, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["IT_CODE"], (object)"");
					((DataGridView)dGV_ADJUST)[9, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["TBL_CODE"], (object)"");
					((DataGridView)dGV_ADJUST)[1, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["TAG_NO"], (object)"");
					((DataGridView)dGV_ADJUST)[2, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["VCH_SRNO"], (object)"");
					((DataGridView)dGV_ADJUST)[10, num].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[num3]["ITM_GWT"], (object)"")), "0.000");
					((DataGridView)dGV_ADJUST)[11, num].Value = Operators.ConcatenateObject(dataTable.Rows[num3]["MAIN_BOOK"], (object)"");
					num3++;
					num++;
					dGV_ADJUST = null;
				}
				DC_Main.M++;
			}
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "output.xlsx";
		DGV.ExportToXlsx(text);
		Process.Start(text);
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		Stk_Insert();
		string text = "";
		string text2 = "";
		if (Operators.CompareString(CurRpt, "Tag Detail", false) != 0)
		{
			if ((int)Interaction.MsgBox((object)"'Yes' Then Counter Wise Summ Report?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				text = "Counter Wise Tag Stock As on Date ";
				text2 = "CntrTagSumRpt";
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text2 + ".RPT";
				if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
				else
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
			}
			else
			{
				text = "Counter Wise Tag Stock As on Date ";
				text2 = "CntrTagStkRpt";
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text2 + ".RPT";
				if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
				else
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
			}
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			DC_Main.RptName = text2;
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			Cr.Action = -1;
			CurFormula = "";
		}
	}

	private void RP_TAG_Load(object sender, EventArgs e)
	{
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_0b51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b58: Expected O, but got Unknown
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1c: Expected O, but got Unknown
		//IL_0c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3e: Expected O, but got Unknown
		//IL_0c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c84: Expected O, but got Unknown
		//IL_0c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Expected O, but got Unknown
		//IL_0cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected O, but got Unknown
		//IL_0cdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Expected O, but got Unknown
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0c: Expected O, but got Unknown
		//IL_0d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2e: Expected O, but got Unknown
		//IL_0d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d50: Expected O, but got Unknown
		//IL_0d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d72: Expected O, but got Unknown
		//IL_0d85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d94: Expected O, but got Unknown
		//IL_0da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db6: Expected O, but got Unknown
		//IL_0bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Expected O, but got Unknown
		//IL_0e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e43: Expected O, but got Unknown
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eda: Expected O, but got Unknown
		//IL_0f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f57: Expected O, but got Unknown
		//IL_1009: Unknown result type (might be due to invalid IL or missing references)
		//IL_100e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1018: Expected O, but got Unknown
		//IL_1037: Unknown result type (might be due to invalid IL or missing references)
		//IL_103c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1046: Expected O, but got Unknown
		//IL_1065: Unknown result type (might be due to invalid IL or missing references)
		//IL_106a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1074: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
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
		((XtraForm)this).SuspendLayout();
		((XtraForm)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		ColCon = 1.0 + num;
		HightCon = 1.0 + num2;
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
			foreach (object control3 in ((Control)pnlDiff).Controls)
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
			if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
			{
				lblBook.Text = "Tag Detail Report";
				((Control)chkDoubelTag).Visible = false;
				((Control)chkZeroId).Visible = false;
			}
			else if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
			{
				lblBook.Text = "Jadtar Tag Detail Report";
				((Control)chkDoubelTag).Visible = false;
				((Control)chkZeroId).Visible = false;
				BtnMrp.Text = "-";
				BtnApr.Text = "-";
			}
			else
			{
				((Control)DGV).Height = (int)Math.Round(413.0 * HightCon);
				((Control)DGV_IDTL).Visible = false;
				((Control)PicImage).Visible = false;
			}
			DC_Main.MsUserRightForm = "";
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((XtraForm)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				CheckBox obj4 = chkEmpIsuLess;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				Label obj6 = lblBook;
				object? obj7 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj6).ForeColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj8 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				ComboBox obj9 = cboItemTyp;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				obj9.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				TextBox obj11 = tPrName;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj11).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				TextBox obj13 = tGrName;
				object? obj14 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj13).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((XtraForm)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((ButtonBase)chkEmpIsuLess).BackColor = Color.LightSlateGray;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				ComboBox obj16 = cboItemTyp;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				obj16.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				TextBox obj18 = tPrName;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj18).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				TextBox obj20 = tGrName;
				object? obj21 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj20).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj22 = colorConverter.ConvertFromString("205, 220, 220");
				((XtraForm)this).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				((ButtonBase)chkEmpIsuLess).BackColor = Color.Cornsilk;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj23 = lblBook;
				object? obj24 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj23).ForeColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj25 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				ComboBox obj26 = cboItemTyp;
				object? obj27 = colorConverter.ConvertFromString("238, 244, 236");
				obj26.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				TextBox obj28 = tPrName;
				object? obj29 = colorConverter.ConvertFromString("238, 244, 236");
				((TextBoxBase)obj28).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				TextBox obj30 = tGrName;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				((TextBoxBase)obj30).BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is MaskedTextBox || val3 is Label || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) | (Operators.CompareString(val3.Name, "GridView1", false) != 0)))
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					((Control)tLcCode).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)tGrName).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((TextBoxBase)tGrCode).AutoSize = false;
					((Control)tGrCode).Height = ((Control)tGrName).Height;
					((Control)tPrCode).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)tPrName).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)tItCode).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)tItName).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)cboSize).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)cboItemTyp).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)cboRptType).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)tBookCode).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)tTagNo).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((BaseEdit)tSerchAll).Font = new Font(font.FontFamily, (float)num3, font.Style);
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tGrCode).Font;
				try
				{
					foreach (object control5 in ((Control)pnlDiff).Controls)
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
					((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_IDTL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_IDTL).Font.Style);
					((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_IDTL).Font.Style);
					((DataGridView)DGV_IDTL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_IDTL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_IDTL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_IDTL).RowTemplate.Height * (1.0 + num2));
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
			cboRptType.Items.Add((object)"Tag Wise");
			cboRptType.Items.Add((object)"Tag Summ");
			cboRptType.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT ITM_SIZE FROM BAR_DETL  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_SIZE <> '' GROUP BY ITM_SIZE  ORDER BY ITM_SIZE";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboSize.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboSize.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["ITM_SIZE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboSize.Items.Add((object)"");
			}
			cboSize.SelectedIndex = 0;
			if ((Operators.CompareString(CurRpt, "Tag Detail", false) == 0) | (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0))
			{
				DC_Main.RsQry = "SELECT IT_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_IDTL_COL = 'Y'  ORDER BY IT_CODE";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.X = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					int num5 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num5)
					{
						if (DC_Main.X == 0)
						{
							Col1 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["IT_CODE"], (object)""));
						}
						else if (DC_Main.X == 1)
						{
							Col2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["IT_CODE"], (object)""));
						}
						else if (DC_Main.X == 2)
						{
							Col3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["IT_CODE"], (object)""));
						}
						else if (DC_Main.X == 3)
						{
							Col4 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["IT_CODE"], (object)""));
						}
						DC_Main.X++;
					}
				}
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				((Control)chkEmpIsuLess).Visible = true;
				chkEmpIsuLess.Checked = true;
			}
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
			else
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
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
		((Control)pnlDiff).Visible = false;
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		DGV_CLEAR();
		((Control)DGV_ADJUST).Visible = false;
		((DataGridView)DGV_ADJUST).DataSource = null;
		((Control)mFromDt).Focus();
	}

	private void DGV_CLEAR()
	{
		DGV.DataSource = null;
		((CollectionBase)(object)((ColumnView)GridView1).Columns).Clear();
		((ColumnView)GridView1).RefreshData();
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
					if ((uint)(columnIndex - 4) <= 5u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
		{
			DGV_FILL();
		}
		else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsStkSum);
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
			{
				dataView.RowFilter = "Design Like  '" + ((TextEdit)tSerchAll).Text + "%' ";
			}
			else
			{
				dataView.RowFilter = "TagNo Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";
			}
			if (dataView.Count > 0)
			{
				DGV.DataSource = dataView;
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_TAG_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_TAG_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_TAG_KeyDown(object sender, KeyEventArgs e)
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

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_TAG_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		DC_Main.MsTagVchSrnoUpdate = false;
		CurActCtrl.Focus();
	}

	private void ItemSub_Detl(string RptType)
	{
		string text = "(Select IT_CODE FROM BAR_IDTL AS L WHERE C.CO_CODE = L.CO_CODE And C.LC_CODE = L.LC_CODE And C.TAG_NO = L.TAG_NO And C.VCH_SRNO = L.VCH_SRNO And L.ISR_NO = 1 GROUP BY L.IT_CODE ) As It1,  (Select SUM(D.IT_PCS) FROM BAR_IDTL As D WHERE C.CO_CODE = D.CO_CODE And C.LC_CODE = D.LC_CODE And C.TAG_NO = D.TAG_NO And C.VCH_SRNO = D.VCH_SRNO And D.IT_PCS <> 0 And D.ISR_NO = 1) As It1P,  (Select SUM(E.IT_GWT) FROM BAR_IDTL As E WHERE C.CO_CODE = E.CO_CODE And C.LC_CODE = E.LC_CODE And C.TAG_NO = E.TAG_NO And C.VCH_SRNO = E.VCH_SRNO And E.IT_GWT <> 0 And E.ISR_NO = 1) As It1Wt,  (Select IT_CODE FROM BAR_IDTL As L WHERE C.CO_CODE = L.CO_CODE And C.LC_CODE = L.LC_CODE And C.TAG_NO = L.TAG_NO And C.VCH_SRNO = L.VCH_SRNO And L.ISR_NO = 2 GROUP BY L.IT_CODE ) As It2,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE And C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.ISR_NO = 2) As It2P,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE And C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.ISR_NO = 2) As It2Wt,  (Select IT_CODE FROM BAR_IDTL As L WHERE C.CO_CODE = L.CO_CODE And C.LC_CODE = L.LC_CODE And C.TAG_NO = L.TAG_NO And C.VCH_SRNO = L.VCH_SRNO And L.ISR_NO = 3 GROUP BY L.IT_CODE ) As It3,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE And C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.ISR_NO = 3) As It3P,  (Select SUM(I.IT_GWT) FROM BAR_IDTL As I WHERE C.CO_CODE = I.CO_CODE And C.LC_CODE = I.LC_CODE And C.TAG_NO = I.TAG_NO And C.VCH_SRNO = I.VCH_SRNO And I.IT_GWT <> 0 And I.ISR_NO = 3) As It3Wt,  (Select IT_CODE FROM BAR_IDTL As L WHERE C.CO_CODE = L.CO_CODE And C.LC_CODE = L.LC_CODE And C.TAG_NO = L.TAG_NO And C.VCH_SRNO = L.VCH_SRNO And L.ISR_NO = 4 GROUP BY L.IT_CODE ) As It4,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE And C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.ISR_NO = 4) As It4P,  (Select SUM(K.IT_GWT) FROM BAR_IDTL As K WHERE C.CO_CODE = K.CO_CODE And C.LC_CODE = K.LC_CODE And C.TAG_NO = K.TAG_NO And C.VCH_SRNO = K.VCH_SRNO And K.IT_GWT <> 0 And K.ISR_NO = 4) As It4Wt,  (Select IT_CODE FROM BAR_IDTL As L WHERE C.CO_CODE = L.CO_CODE And C.LC_CODE = L.LC_CODE And C.TAG_NO = L.TAG_NO And C.VCH_SRNO = L.VCH_SRNO And L.ISR_NO = 5 GROUP BY L.IT_CODE ) As It5,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE And C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.ISR_NO = 5) As It5P,  (Select SUM(K.IT_GWT) FROM BAR_IDTL As K WHERE C.CO_CODE = K.CO_CODE And C.LC_CODE = K.LC_CODE And C.TAG_NO = K.TAG_NO And C.VCH_SRNO = K.VCH_SRNO And K.IT_GWT <> 0 And K.ISR_NO = 5) As It5Wt, ";
		if (Operators.CompareString(RptType, "In", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.VCH_DATE As VchDate,C.TAG_NO As TagNo,C.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS As Pcs,C.ITM_GWT As Grwt,C.ITM_NWT As NetWt,C.LBR_PRC As Lbrprc,C.LBR_RATE As LbrRate,C.LBR_AMT LbrAmt,C.OTH_AMT OthAmt,C.CO_BOOK As Book,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,  " + text + "  C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from BAR_DETL AS C INNER JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND C.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND C.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
		}
		else if (Operators.CompareString(RptType, "Out", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,C.CO_BOOK As Book,  " + text + "  C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
		}
		else if ((Operators.CompareString(RptType, "Stock", false) == 0) | (Operators.CompareString(RptType, "Mrp", false) == 0))
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.LC_CODE As LcCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.VCH_SRNO As TagId,  " + text + "  C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(!chkEmpIsuLess.Checked, (object)"", (object)"AND C.EMP_ISU <> 'Y'")), (object)" "));
		}
		else if (Operators.CompareString(RptType, "Apr", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,D.AC_NAME As PartyName,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.TBL_CODE As Counter,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT As LbrAmt,C.OTH_AMT OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,C.VCH_SRNO As TagId,  " + text + "  C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from ((APR_DETL AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N' "));
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(cboSize.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(RptType, "Mrp", false) == 0)
		{
			DC_Main.RsQry += "AND C.ITM_MRP <> 0";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
		}
		if (Operators.CompareString(RptType, "In", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY C.TAG_NO";
			}
		}
		else if ((Operators.CompareString(RptType, "Stock", false) == 0) | (Operators.CompareString(RptType, "Mrp", false) == 0))
		{
			DC_Main.RsQry += " GROUP BY C.CO_CODE,C.LC_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_STYLE,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,C.LBR_PRC,C.LBR_AMT,C.OTH_AMT,  C.KR_COST,C.ITM_MRP,C.KR_NAME,C.ITM_REMARK,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO,C.KR_NAME,C.KR_COST,C.ITM_MRP,C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE ";
			DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ";
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY C.TAG_NO";
			}
		}
		else if (Operators.CompareString(RptType, "Out", false) == 0)
		{
			DC_Main.RsQry += "ORDER BY A.VCH_TYPE,A.VCH_NO";
		}
		else if (Operators.CompareString(RptType, "Apr", false) == 0)
		{
			DC_Main.RsQry += "ORDER BY A.CO_YEAR,A.VCH_NO,A.TAG_NO";
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void Tag_Summ(string RptType)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_08e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Invalid comparison between Unknown and I4
		//IL_1c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c13: Invalid comparison between Unknown and I4
		//IL_1a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a85: Invalid comparison between Unknown and I4
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1114: Invalid comparison between Unknown and I4
		//IL_1b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b40: Invalid comparison between Unknown and I4
		if (Operators.CompareString(RptType, "In", false) == 0)
		{
			if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
			{
				if ((int)Interaction.MsgBox((object)"Report With Other Detail Item Name...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					IdtlWithName = "Y";
					ItemSub_Detl(RptType);
					return;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.VCH_DATE As VchDate,C.TAG_NO As TagNo,C.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 AS Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_PRC As Lbrprc,C.LBR_RATE As LbrRate,C.LBR_AMT LbrAmt,C.OTH_AMT OthAmt,C.CO_BOOK As Book,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,  (Select SUM(D.IT_PCS) FROM BAR_IDTL AS D WHERE C.CO_CODE = D.CO_CODE AND C.LC_CODE = D.LC_CODE AND C.TAG_NO = D.TAG_NO AND C.VCH_SRNO = D.VCH_SRNO AND D.IT_PCS <> 0 AND D.IT_CODE = '" + Col1 + "') As " + Col1 + "pc,  (Select SUM(E.IT_GWT) FROM BAR_IDTL AS E WHERE C.CO_CODE = E.CO_CODE AND C.LC_CODE = E.LC_CODE AND C.TAG_NO = E.TAG_NO AND C.VCH_SRNO = E.VCH_SRNO AND E.IT_GWT <> 0 AND E.IT_CODE = '" + Col1 + "') As " + Col1 + "wt,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE AND C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.IT_CODE = '" + Col2 + "') As " + Col2 + "pc,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE AND C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.IT_CODE = '" + Col2 + "') As " + Col2 + "wt,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE AND C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.IT_CODE = '" + Col3 + "') As " + Col3 + "pc,  (Select SUM(I.IT_GWT) FROM BAR_IDTL AS I WHERE C.CO_CODE = I.CO_CODE AND C.LC_CODE = I.LC_CODE AND C.TAG_NO = I.TAG_NO AND C.VCH_SRNO = I.VCH_SRNO AND I.IT_GWT <> 0 AND I.IT_CODE = '" + Col3 + "') As " + Col3 + "wt,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE AND C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.IT_CODE = '" + Col4 + "') As " + Col4 + "pc,  (Select SUM(K.IT_GWT) FROM BAR_IDTL AS K WHERE C.CO_CODE = K.CO_CODE AND C.LC_CODE = K.LC_CODE AND C.TAG_NO = K.TAG_NO AND C.VCH_SRNO = K.VCH_SRNO AND K.IT_GWT <> 0 AND K.IT_CODE = '" + Col4 + "') As " + Col4 + "wt,C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from BAR_DETL AS C LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND C.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND C.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),format(A.VCH_DATE,'yyyy-MM-dd')) As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.DESIGN_NO As Design,C.ITM_STYLE As Style,A.TBL_CODE As Counter,C.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_TOUCH As Touch,A.ITM_WEST As West,A.ITM_FINE As Fine,C.KR_NET_WT As KrNwt,C.KR_TOUCH As KrTch,C.KR_WEST_PRC As KrWest,C.KR_FINE As KrFine,C.KR_OTH_FINE As OthFine,C.KR_TOT_FINE As TotFine,C.KR_GWT_TOUCH As GrTouch,C.SL_TYPE As TagType,format((A.ITM_FINE)-(C.KR_FINE+C.KR_OTH_FINE),'0.000') As TagProfit,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.VCH_DATE As VchDate,DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),'" + Strings.Format((object)DC_Main.MsSysDate, "yyyy-MM-dd") + "') As Day,C.TAG_NO As TagNo,C.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 AS Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_PRC As Lbrprc,C.LBR_RATE As LbrRate,C.LBR_AMT LbrAmt,C.OTH_AMT OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.ITM_REMARK As Remark,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,B.SAFE_NAME As SafeName  from BAR_DETL AS C LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND C.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND C.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(cboSize.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY C.TAG_NO";
			}
		}
		else if (Operators.CompareString(RptType, "Out", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  C.KR_COST As PrCost,A.ITM_MRP As Mrp,'' As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId  from (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE  A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
			{
				if ((int)Interaction.MsgBox((object)"Report With Other Detail Item Name...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					IdtlWithName = "Y";
					ItemSub_Detl(RptType);
					return;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,C.CO_BOOK As Book,  C.KR_COST As PrCost,A.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,  (Select SUM(D.IT_PCS) FROM BAR_IDTL AS D WHERE C.CO_CODE = D.CO_CODE AND C.LC_CODE = D.LC_CODE AND C.TAG_NO = D.TAG_NO AND C.VCH_SRNO = D.VCH_SRNO AND D.IT_PCS <> 0 AND D.IT_CODE = '" + Col1 + "') As " + Col1 + "pc,  (Select SUM(E.IT_GWT) FROM BAR_IDTL AS E WHERE C.CO_CODE = E.CO_CODE AND C.LC_CODE = E.LC_CODE AND C.TAG_NO = E.TAG_NO AND C.VCH_SRNO = E.VCH_SRNO AND E.IT_GWT <> 0 AND E.IT_CODE = '" + Col1 + "') As " + Col1 + "wt,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE AND C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.IT_CODE = '" + Col2 + "') As " + Col2 + "pc,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE AND C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.IT_CODE = '" + Col2 + "') As " + Col2 + "wt,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE AND C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.IT_CODE = '" + Col3 + "') As " + Col3 + "pc,  (Select SUM(I.IT_GWT) FROM BAR_IDTL AS I WHERE C.CO_CODE = I.CO_CODE AND C.LC_CODE = I.LC_CODE AND C.TAG_NO = I.TAG_NO AND C.VCH_SRNO = I.VCH_SRNO AND I.IT_GWT <> 0 AND I.IT_CODE = '" + Col3 + "') As " + Col3 + "wt,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE AND C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.IT_CODE = '" + Col4 + "') As " + Col4 + "pc,  (Select SUM(K.IT_GWT) FROM BAR_IDTL AS K WHERE C.CO_CODE = K.CO_CODE AND C.LC_CODE = K.LC_CODE AND C.TAG_NO = K.TAG_NO AND C.VCH_SRNO = K.VCH_SRNO AND K.IT_GWT <> 0 AND K.IT_CODE = '" + Col4 + "') As " + Col4 + "wt,A.SR_NO As SrNo,C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),format(A.VCH_DATE,'yyyy-MM-dd')) As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.DESIGN_NO As Design,C.ITM_STYLE As Style,A.TBL_CODE As Counter,C.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_TOUCH As Touch,A.ITM_WEST As West,A.ITM_FINE As Fine,C.KR_NET_WT As KrNwt,C.KR_TOUCH As KrTch,C.KR_WEST_PRC As KrWest,C.KR_FINE As KrFine,C.KR_OTH_FINE As OthFine,C.KR_TOT_FINE As TotFine,C.KR_GWT_TOUCH As GrTouch,C.SL_TYPE As TagType,format((A.ITM_FINE)-(C.KR_FINE+C.KR_OTH_FINE),'0.000') As TagProfit,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),format(A.VCH_DATE,'yyyy-MM-dd')) As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  C.KR_COST As PrCost,A.ITM_MRP As Mrp,C.KR_NAME As KrName,C.ITM_REMARK As Remark,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,B.SAFE_NAME As SafeName  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(cboSize.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			DC_Main.RsQry += "ORDER BY A.VCH_TYPE,A.VCH_NO";
		}
		else if ((Operators.CompareString(RptType, "Stock", false) == 0) | (Operators.CompareString(RptType, "Mrp", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId  from (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE  A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
			{
				if ((int)Interaction.MsgBox((object)"Report With Other Detail Item Name...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					IdtlWithName = "Y";
					ItemSub_Detl(RptType);
					return;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.LC_CODE As LcCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.VCH_SRNO As TagId,  (Select SUM(D.IT_PCS) FROM BAR_IDTL AS D WHERE C.CO_CODE = D.CO_CODE AND C.LC_CODE = D.LC_CODE AND C.TAG_NO = D.TAG_NO AND C.VCH_SRNO = D.VCH_SRNO AND D.IT_PCS <> 0 AND D.IT_CODE = '" + Col1 + "') As " + Col1 + "pc,  (Select SUM(E.IT_GWT) FROM BAR_IDTL AS E WHERE C.CO_CODE = E.CO_CODE AND C.LC_CODE = E.LC_CODE AND C.TAG_NO = E.TAG_NO AND C.VCH_SRNO = E.VCH_SRNO AND E.IT_GWT <> 0 AND E.IT_CODE = '" + Col1 + "') As " + Col1 + "wt,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE AND C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.IT_CODE = '" + Col2 + "') As " + Col2 + "pc,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE AND C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.IT_CODE = '" + Col2 + "') As " + Col2 + "wt,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE AND C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.IT_CODE = '" + Col3 + "') As " + Col3 + "pc,  (Select SUM(I.IT_GWT) FROM BAR_IDTL AS I WHERE C.CO_CODE = I.CO_CODE AND C.LC_CODE = I.LC_CODE AND C.TAG_NO = I.TAG_NO AND C.VCH_SRNO = I.VCH_SRNO AND I.IT_GWT <> 0 AND I.IT_CODE = '" + Col3 + "') As " + Col3 + "wt,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE AND C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.IT_CODE = '" + Col4 + "') As " + Col4 + "pc,  (Select SUM(K.IT_GWT) FROM BAR_IDTL AS K WHERE C.CO_CODE = K.CO_CODE AND C.LC_CODE = K.LC_CODE AND C.TAG_NO = K.TAG_NO AND C.VCH_SRNO = K.VCH_SRNO AND K.IT_GWT <> 0 AND K.IT_CODE = '" + Col4 + "') As " + Col4 + "wt,C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(!chkEmpIsuLess.Checked, (object)"", (object)"AND C.EMP_ISU <> 'Y'")), (object)" "));
			}
			else if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As VchDate,DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),'" + Strings.Format((object)DC_Main.MsSysDate, "yyyy-MM-dd") + "') As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.KR_NET_WT AS KrNwt,format(SUM(C.ITM_NWT-C.KR_NET_WT),'0.000') As KrDif,C.KR_TOUCH As KrTch,C.KR_WEST_PRC As KrWest,C.KR_FINE AS KrFine,C.KR_OTH_FINE As OthFine,C.KR_TOT_FINE As TotFine,C.KR_GWT_TOUCH As GrTouch,C.SL_TYPE As TagType, C.LBR_AMT As LbrAmt,C.OTH_AMT As OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(!chkEmpIsuLess.Checked, (object)"", (object)"AND C.EMP_ISU <> 'Y'")), (object)" "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.LC_CODE As LcCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As VchDate,DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),'" + Strings.Format((object)DC_Main.MsSysDate, "yyyy-MM-dd") + "') As Day,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.ITM_REMARK As Remark,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,B.SAFE_NAME As SafeName  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(!chkEmpIsuLess.Checked, (object)"", (object)"AND C.EMP_ISU <> 'Y'")), (object)" "));
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(cboSize.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(RptType, "Mrp", false) == 0)
			{
				DC_Main.RsQry += "AND C.ITM_MRP <> 0";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
			{
				DC_Main.RsQry += " GROUP BY C.CO_CODE,C.LC_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_STYLE,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,C.LBR_PRC,C.LBR_AMT,C.OTH_AMT,  C.KR_COST,C.ITM_MRP,C.KR_NAME,C.ITM_REMARK,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO,C.KR_NAME,C.KR_COST,C.ITM_MRP,C.HM_ID,C.HM_ID2,C.HM_ID3,C.HM_ID4,B.GR_CODE ";
				DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ";
				if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
				{
					DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
				}
				else
				{
					DC_Main.RsQry += "ORDER BY C.TAG_NO";
				}
			}
			else if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				DC_Main.RsQry += " GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_STYLE,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_NWT,C.KR_NET_WT,C.KR_TOUCH,C.KR_WEST_PRC,C.KR_FINE,C.KR_OTH_FINE,C.KR_TOT_FINE,C.KR_GWT_TOUCH,C.SL_TYPE,C.LBR_AMT,C.OTH_AMT,  C.KR_COST,C.ITM_MRP,C.KR_NAME,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO ";
				DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ";
				if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
				{
					DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
				}
				else
				{
					DC_Main.RsQry += "ORDER BY C.TAG_NO";
				}
			}
			else
			{
				DC_Main.RsQry += " GROUP BY C.CO_CODE,C.LC_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_STYLE,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,C.LBR_PRC,C.LBR_AMT,C.OTH_AMT,  C.KR_COST,C.ITM_MRP,C.KR_NAME,C.ITM_REMARK,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO,B.SAFE_NAME ";
				DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0";
				if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
				{
					DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
				}
				else
				{
					DC_Main.RsQry += "ORDER BY C.TAG_NO";
				}
			}
		}
		else if (Operators.CompareString(RptType, "Apr", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TAG_NO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND EMP_ISU = 'Y'"));
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				if ((int)Interaction.MsgBox((object)"Tour Outword Stock Show....?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,D.EMP_NAME As EmpName,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.TBL_CODE As Counter,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT As LbrAmt,C.OTH_AMT OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,C.VCH_SRNO As TagId  from ((APR_DETL AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN EMP_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.EMP_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME = 'EMP ISU'  AND A.ISU_REC = 'N' "));
				}
				else
				{
					if ((int)Interaction.MsgBox((object)"Report With Other Detail Item Name...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
					{
						IdtlWithName = "Y";
						ItemSub_Detl(RptType);
						return;
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,D.AC_NAME As PartyName,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.TBL_CODE As Counter,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT As LbrAmt,C.OTH_AMT OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,C.VCH_SRNO As TagId  from ((APR_DETL AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N' "));
				}
			}
			else
			{
				if ((int)Interaction.MsgBox((object)"Report With Other Detail Item Name...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					IdtlWithName = "Y";
					ItemSub_Detl(RptType);
					return;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,D.AC_NAME As PartyName,C.DESIGN_NO As Design,C.ITM_STYLE As Style,C.TBL_CODE As Counter,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT As LbrAmt,C.OTH_AMT OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,C.VCH_SRNO As TagId  from ((APR_DETL AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N' "));
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(cboSize.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY A.CO_YEAR,A.VCH_NO,C.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.CO_YEAR,A.VCH_NO,A.TAG_NO";
			}
		}
		else if (Operators.CompareString(RptType, "All", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,A.DESIGN_NO As Design,A.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,0 As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_MRP As Mrp,'' As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,A.ITM_SIGN As Sign  from MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE  A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,A.DESIGN_NO As Design,A.ITM_SIZE As Size,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,  A.ITM_TOUCH As Touch,A.ITM_WEST As West,A.ITM_FINE As Fine,C.KR_TOUCH As KrTch,C.KR_WEST_PRC As KrWest,C.KR_FINE As KrFine,format((A.ITM_FINE)-(C.KR_FINE),'0.000') As TagProfit,  C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,A.ITM_SIGN As Sign,C.EMP_ISU As EmpIsu  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,A.DESIGN_NO As Design,A.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,0 As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,A.ITM_SIGN As Sign,C.EMP_ISU As EmpIsu,B.SAFE_NAME As SafeName  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) == 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "And A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			}
			if (Operators.CompareString(cboSize.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_SIZE = '" + cboSize.Text + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY A.VCH_DATE,C.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.TAG_NO";
			}
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_FILL()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_17b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c3: Expected O, but got Unknown
		//IL_1803: Unknown result type (might be due to invalid IL or missing references)
		//IL_180d: Expected O, but got Unknown
		//IL_182c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1836: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataView dataView = default(DataView);
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
				case 7040:
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
							goto IL_0019;
						case 4:
							goto IL_0040;
						case 5:
							goto IL_005d;
						case 6:
							goto IL_0084;
						case 7:
							goto IL_0094;
						case 8:
							goto IL_00af;
						case 9:
						case 10:
							goto IL_00e3;
						case 11:
							goto IL_00f5;
						case 12:
							goto IL_0105;
						case 13:
						case 15:
						case 16:
							goto IL_011e;
						case 17:
							goto IL_0133;
						case 18:
							goto IL_0143;
						case 19:
							goto IL_014c;
						case 20:
							goto IL_0168;
						case 21:
							goto IL_017f;
						case 22:
							goto IL_01a0;
						case 23:
						case 24:
						case 25:
						case 26:
							goto IL_01c5;
						case 27:
							goto IL_01e6;
						case 28:
							goto IL_0205;
						case 29:
							goto IL_0226;
						case 30:
							goto IL_0245;
						case 31:
							goto IL_0266;
						case 32:
							goto IL_0285;
						case 33:
							goto IL_02a1;
						case 34:
							goto IL_02c2;
						case 35:
						case 36:
							goto IL_02e3;
						case 37:
							goto IL_0316;
						case 38:
							goto IL_0337;
						case 39:
							goto IL_0356;
						case 40:
							goto IL_0377;
						case 41:
						case 42:
							goto IL_0398;
						case 43:
							goto IL_03b9;
						case 44:
							goto IL_03e7;
						case 45:
							goto IL_0408;
						case 46:
							goto IL_0436;
						case 47:
							goto IL_0457;
						case 48:
							goto IL_047b;
						case 49:
							goto IL_04a3;
						case 50:
						case 51:
							goto IL_04d3;
						case 52:
							goto IL_04f4;
						case 53:
							goto IL_0518;
						case 54:
							goto IL_0540;
						case 55:
						case 56:
							goto IL_0570;
						case 57:
							goto IL_0591;
						case 58:
							goto IL_05bf;
						case 59:
							goto IL_05e0;
						case 60:
							goto IL_060e;
						case 61:
							goto IL_062f;
						case 62:
							goto IL_0658;
						case 63:
							goto IL_0679;
						case 64:
							goto IL_06a2;
						case 65:
							goto IL_06c1;
						case 66:
							goto IL_06e5;
						case 67:
							goto IL_0709;
						case 68:
							goto IL_0731;
						case 69:
							goto IL_075f;
						case 70:
						case 71:
							goto IL_078a;
						case 72:
							goto IL_07ae;
						case 73:
							goto IL_07d2;
						case 74:
							goto IL_07fa;
						case 75:
							goto IL_0828;
						case 76:
						case 77:
							goto IL_0853;
						case 78:
							goto IL_0872;
						case 79:
							goto IL_0896;
						case 80:
							goto IL_08ba;
						case 81:
							goto IL_08e2;
						case 82:
							goto IL_0910;
						case 83:
						case 84:
							goto IL_093b;
						case 85:
							goto IL_095f;
						case 86:
							goto IL_0983;
						case 87:
							goto IL_09ab;
						case 88:
							goto IL_09d9;
						case 91:
							goto IL_0a0b;
						case 92:
							goto IL_0a2c;
						case 93:
							goto IL_0a4b;
						case 94:
							goto IL_0a6c;
						case 95:
							goto IL_0a8b;
						case 96:
							goto IL_0aac;
						case 97:
							goto IL_0acb;
						case 98:
							goto IL_0aec;
						case 89:
						case 90:
						case 99:
						case 100:
							goto IL_0b0c;
						case 101:
							goto IL_0b30;
						case 102:
							goto IL_0b54;
						case 103:
							goto IL_0b7c;
						case 104:
							goto IL_0baa;
						case 105:
						case 106:
							goto IL_0bd5;
						case 107:
							goto IL_0bf9;
						case 108:
							goto IL_0c1d;
						case 109:
							goto IL_0c45;
						case 110:
							goto IL_0c73;
						case 111:
						case 112:
							goto IL_0c9e;
						case 113:
							goto IL_0cbf;
						case 114:
							goto IL_0ce3;
						case 115:
							goto IL_0d0b;
						case 116:
						case 117:
							goto IL_0d3b;
						case 118:
							goto IL_0d57;
						case 119:
							goto IL_0d78;
						case 120:
						case 121:
						case 122:
							goto IL_0d9b;
						case 123:
							goto IL_0dbc;
						case 124:
							goto IL_0de0;
						case 125:
							goto IL_0e08;
						case 126:
						case 127:
							goto IL_0e38;
						case 128:
							goto IL_0e5c;
						case 129:
							goto IL_0e83;
						case 130:
							goto IL_0eae;
						case 131:
						case 132:
							goto IL_0ee1;
						case 133:
							goto IL_0f04;
						case 134:
							goto IL_0f28;
						case 135:
							goto IL_0f4a;
						case 136:
							goto IL_0f6e;
						case 137:
							goto IL_0f90;
						case 138:
							goto IL_0fb4;
						case 139:
							goto IL_0fd6;
						case 140:
							goto IL_0ffa;
						case 141:
							goto IL_101c;
						case 142:
							goto IL_103f;
						case 143:
							goto IL_1063;
						case 144:
							goto IL_1094;
						case 145:
							goto IL_10b8;
						case 146:
							goto IL_10e9;
						case 147:
							goto IL_110d;
						case 148:
							goto IL_113e;
						case 149:
							goto IL_1162;
						case 150:
							goto IL_1193;
						case 151:
							goto IL_11b7;
						case 152:
							goto IL_11e8;
						case 153:
							goto IL_120c;
						case 154:
							goto IL_123d;
						case 155:
							goto IL_1261;
						case 156:
							goto IL_1292;
						case 157:
							goto IL_12b6;
						case 158:
							goto IL_12e7;
						case 159:
							goto IL_130b;
						case 160:
							goto IL_133c;
						case 161:
							goto IL_1360;
						case 163:
							goto IL_1398;
						case 164:
							goto IL_13c7;
						case 165:
							goto IL_140e;
						case 166:
							goto IL_143d;
						case 167:
							goto IL_1484;
						case 168:
							goto IL_14b3;
						case 169:
							goto IL_14fa;
						case 170:
							goto IL_1529;
						case 171:
							goto IL_1570;
						case 172:
							goto IL_159f;
						case 173:
							goto IL_15e6;
						case 174:
							goto IL_1615;
						case 175:
							goto IL_165c;
						case 176:
							goto IL_168b;
						case 177:
							goto IL_16d2;
						case 178:
							goto IL_1701;
						case 162:
						case 179:
						case 180:
						case 181:
							goto IL_174b;
						case 182:
							goto IL_177e;
						case 183:
							goto IL_179b;
						case 184:
							goto IL_17c4;
						case 185:
							goto IL_17e5;
						case 186:
							goto IL_180e;
						case 187:
							goto IL_1837;
						case 188:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 14:
						case 189:
						case 190:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_17e5:
					num2 = 185;
					GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_180e;
					IL_180e:
					num2 = 186;
					GridView1.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_1837;
					IL_17c4:
					num2 = 184;
					GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
					goto IL_17e5;
					IL_1837:
					num2 = 187;
					GridView1.RowHeight = checked((int)Math.Round(22.0 * DC_Main.ScreenHight));
					break;
					IL_000b:
					num2 = 2;
					dataView = new DataView(RsStkSum);
					goto IL_0019;
					IL_0019:
					num2 = 3;
					GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 9f);
					goto IL_0040;
					IL_0040:
					num2 = 4;
					GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
					goto IL_005d;
					IL_005d:
					num2 = 5;
					GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", 8.7f);
					goto IL_0084;
					IL_0084:
					num2 = 6;
					GridView1.RowHeight = 22;
					goto IL_0094;
					IL_0094:
					num2 = 7;
					if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
					{
						goto IL_00af;
					}
					goto IL_00e3;
					IL_00af:
					num2 = 8;
					GridView1.Appearance.Row.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize - 1f, DC_Main.MsFontStyle);
					goto IL_00e3;
					IL_00e3:
					num2 = 10;
					if (dataView.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00f5;
					IL_00f5:
					num2 = 11;
					DGV.DataSource = dataView;
					goto IL_0105;
					IL_0105:
					num2 = 12;
					DGV.ForceInitialize();
					goto IL_011e;
					IL_011e:
					num2 = 16;
					GridView1.OptionsView.ColumnAutoWidth = false;
					goto IL_0133;
					IL_0133:
					num2 = 17;
					GridView1.HorzScrollVisibility = (ScrollVisibility)(-1);
					goto IL_0143;
					IL_0143:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_014c;
					IL_014c:
					num2 = 19;
					if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) != 0)
					{
						goto IL_0168;
					}
					goto IL_01c5;
					IL_0168:
					num2 = 20;
					if (!chkSlWtDiff.Checked)
					{
						goto IL_017f;
					}
					goto IL_01c5;
					IL_017f:
					num2 = 21;
					if (((ColumnView)GridView1).Columns["CoCode"] != null)
					{
						goto IL_01a0;
					}
					goto IL_01c5;
					IL_01a0:
					num2 = 22;
					((ColumnView)GridView1).Columns["CoCode"].Visible = false;
					goto IL_01c5;
					IL_01c5:
					num2 = 26;
					if (((ColumnView)GridView1).Columns["Book"] != null)
					{
						goto IL_01e6;
					}
					goto IL_0205;
					IL_01e6:
					num2 = 27;
					((ColumnView)GridView1).Columns["Book"].Visible = false;
					goto IL_0205;
					IL_0205:
					num2 = 28;
					if (((ColumnView)GridView1).Columns["BookName"] != null)
					{
						goto IL_0226;
					}
					goto IL_0245;
					IL_0226:
					num2 = 29;
					((ColumnView)GridView1).Columns["BookName"].Visible = false;
					goto IL_0245;
					IL_0245:
					num2 = 30;
					if (((ColumnView)GridView1).Columns["AcCode"] != null)
					{
						goto IL_0266;
					}
					goto IL_0285;
					IL_0266:
					num2 = 31;
					((ColumnView)GridView1).Columns["AcCode"].Visible = false;
					goto IL_0285;
					IL_0285:
					num2 = 32;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0)
					{
						goto IL_02a1;
					}
					goto IL_02e3;
					IL_02a1:
					num2 = 33;
					if (((ColumnView)GridView1).Columns["Remark"] != null)
					{
						goto IL_02c2;
					}
					goto IL_02e3;
					IL_02c2:
					num2 = 34;
					((ColumnView)GridView1).Columns["Remark"].Visible = false;
					goto IL_02e3;
					IL_02e3:
					num2 = 36;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM086NSDG", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "DM066NEDM", false) == 0))
					{
						goto IL_0316;
					}
					goto IL_0398;
					IL_0316:
					num2 = 37;
					if (((ColumnView)GridView1).Columns["VchDate"] != null)
					{
						goto IL_0337;
					}
					goto IL_0356;
					IL_0337:
					num2 = 38;
					((ColumnView)GridView1).Columns["VchDate"].Visible = false;
					goto IL_0356;
					IL_0356:
					num2 = 39;
					if (((ColumnView)GridView1).Columns["Day"] != null)
					{
						goto IL_0377;
					}
					goto IL_0398;
					IL_0377:
					num2 = 40;
					((ColumnView)GridView1).Columns["Day"].Visible = false;
					goto IL_0398;
					IL_0398:
					num2 = 42;
					if (((ColumnView)GridView1).Columns["Qty"] != null)
					{
						goto IL_03b9;
					}
					goto IL_03e7;
					IL_03b9:
					num2 = 43;
					((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");
					goto IL_03e7;
					IL_03e7:
					num2 = 44;
					if (((ColumnView)GridView1).Columns["Pcs"] != null)
					{
						goto IL_0408;
					}
					goto IL_0436;
					IL_0408:
					num2 = 45;
					((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
					goto IL_0436;
					IL_0436:
					num2 = 46;
					if (((ColumnView)GridView1).Columns["Grwt"] != null)
					{
						goto IL_0457;
					}
					goto IL_04d3;
					IL_0457:
					num2 = 47;
					((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_047b;
					IL_047b:
					num2 = 48;
					((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_04a3;
					IL_04a3:
					num2 = 49;
					((ColumnView)GridView1).Columns["Grwt"].Summary.Add((SummaryItemType)0, "Grwt", "{0}");
					goto IL_04d3;
					IL_04d3:
					num2 = 51;
					if (((ColumnView)GridView1).Columns["NetWt"] != null)
					{
						goto IL_04f4;
					}
					goto IL_0570;
					IL_04f4:
					num2 = 52;
					((ColumnView)GridView1).Columns["NetWt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0518;
					IL_0518:
					num2 = 53;
					((ColumnView)GridView1).Columns["NetWt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_0540;
					IL_0540:
					num2 = 54;
					((ColumnView)GridView1).Columns["NetWt"].Summary.Add((SummaryItemType)0, "NetWt", "{0}");
					goto IL_0570;
					IL_0570:
					num2 = 56;
					if (((ColumnView)GridView1).Columns["Mrp"] != null)
					{
						goto IL_0591;
					}
					goto IL_05bf;
					IL_0591:
					num2 = 57;
					((ColumnView)GridView1).Columns["Mrp"].Summary.Add((SummaryItemType)0, "Mrp", "{0}");
					goto IL_05bf;
					IL_05bf:
					num2 = 58;
					if (((ColumnView)GridView1).Columns["PrCost"] != null)
					{
						goto IL_05e0;
					}
					goto IL_060e;
					IL_05e0:
					num2 = 59;
					((ColumnView)GridView1).Columns["PrCost"].Summary.Add((SummaryItemType)0, "PrCost", "{0}");
					goto IL_060e;
					IL_060e:
					num2 = 60;
					if (((ColumnView)GridView1).Columns["Grwt"] != null)
					{
						goto IL_062f;
					}
					goto IL_0658;
					IL_062f:
					num2 = 61;
					((AppearanceObject)((ColumnView)GridView1).Columns["Grwt"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_0658;
					IL_0658:
					num2 = 62;
					if (((ColumnView)GridView1).Columns["NetWt"] != null)
					{
						goto IL_0679;
					}
					goto IL_06a2;
					IL_0679:
					num2 = 63;
					((AppearanceObject)((ColumnView)GridView1).Columns["NetWt"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_06a2;
					IL_06a2:
					num2 = 64;
					if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
					{
						goto IL_06c1;
					}
					goto IL_0d9b;
					IL_06c1:
					num2 = 65;
					if (((ColumnView)GridView1).Columns["Fine"] != null)
					{
						goto IL_06e5;
					}
					goto IL_078a;
					IL_06e5:
					num2 = 66;
					((ColumnView)GridView1).Columns["Fine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0709;
					IL_0709:
					num2 = 67;
					((ColumnView)GridView1).Columns["Fine"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_0731;
					IL_0731:
					num2 = 68;
					((ColumnView)GridView1).Columns["Fine"].Summary.Add((SummaryItemType)0, "Fine", "{0}");
					goto IL_075f;
					IL_075f:
					num2 = 69;
					((AppearanceObject)((ColumnView)GridView1).Columns["Fine"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_078a;
					IL_078a:
					num2 = 71;
					if (((ColumnView)GridView1).Columns["KrFine"] != null)
					{
						goto IL_07ae;
					}
					goto IL_0853;
					IL_07ae:
					num2 = 72;
					((ColumnView)GridView1).Columns["KrFine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_07d2;
					IL_07d2:
					num2 = 73;
					((ColumnView)GridView1).Columns["KrFine"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_07fa;
					IL_07fa:
					num2 = 74;
					((ColumnView)GridView1).Columns["KrFine"].Summary.Add((SummaryItemType)0, "KrFine", "{0}");
					goto IL_0828;
					IL_0828:
					num2 = 75;
					((AppearanceObject)((ColumnView)GridView1).Columns["KrFine"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_0853;
					IL_0853:
					num2 = 77;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
					{
						goto IL_0872;
					}
					goto IL_0a0b;
					IL_0872:
					num2 = 78;
					if (((ColumnView)GridView1).Columns["OthFine"] != null)
					{
						goto IL_0896;
					}
					goto IL_093b;
					IL_0896:
					num2 = 79;
					((ColumnView)GridView1).Columns["OthFine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_08ba;
					IL_08ba:
					num2 = 80;
					((ColumnView)GridView1).Columns["OthFine"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_08e2;
					IL_08e2:
					num2 = 81;
					((ColumnView)GridView1).Columns["OthFine"].Summary.Add((SummaryItemType)0, "OthFine", "{0}");
					goto IL_0910;
					IL_0910:
					num2 = 82;
					((AppearanceObject)((ColumnView)GridView1).Columns["OthFine"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_093b;
					IL_093b:
					num2 = 84;
					if (((ColumnView)GridView1).Columns["TotFine"] != null)
					{
						goto IL_095f;
					}
					goto IL_0b0c;
					IL_095f:
					num2 = 85;
					((ColumnView)GridView1).Columns["TotFine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0983;
					IL_0983:
					num2 = 86;
					((ColumnView)GridView1).Columns["TotFine"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_09ab;
					IL_09ab:
					num2 = 87;
					((ColumnView)GridView1).Columns["TotFine"].Summary.Add((SummaryItemType)0, "TotFine", "{0}");
					goto IL_09d9;
					IL_09d9:
					num2 = 88;
					((AppearanceObject)((ColumnView)GridView1).Columns["TotFine"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_0b0c;
					IL_0a0b:
					num2 = 91;
					if (((ColumnView)GridView1).Columns["OthFine"] != null)
					{
						goto IL_0a2c;
					}
					goto IL_0a4b;
					IL_0a2c:
					num2 = 92;
					((ColumnView)GridView1).Columns["OthFine"].Visible = false;
					goto IL_0a4b;
					IL_0a4b:
					num2 = 93;
					if (((ColumnView)GridView1).Columns["TotFine"] != null)
					{
						goto IL_0a6c;
					}
					goto IL_0a8b;
					IL_0a6c:
					num2 = 94;
					((ColumnView)GridView1).Columns["TotFine"].Visible = false;
					goto IL_0a8b;
					IL_0a8b:
					num2 = 95;
					if (((ColumnView)GridView1).Columns["GrTouch"] != null)
					{
						goto IL_0aac;
					}
					goto IL_0acb;
					IL_0aac:
					num2 = 96;
					((ColumnView)GridView1).Columns["GrTouch"].Visible = false;
					goto IL_0acb;
					IL_0acb:
					num2 = 97;
					if (((ColumnView)GridView1).Columns["TagType"] != null)
					{
						goto IL_0aec;
					}
					goto IL_0b0c;
					IL_0aec:
					num2 = 98;
					((ColumnView)GridView1).Columns["TagType"].Visible = false;
					goto IL_0b0c;
					IL_0b0c:
					num2 = 100;
					if (((ColumnView)GridView1).Columns["KrNwt"] != null)
					{
						goto IL_0b30;
					}
					goto IL_0bd5;
					IL_0b30:
					num2 = 101;
					((ColumnView)GridView1).Columns["KrNwt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0b54;
					IL_0b54:
					num2 = 102;
					((ColumnView)GridView1).Columns["KrNwt"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_0b7c;
					IL_0b7c:
					num2 = 103;
					((ColumnView)GridView1).Columns["KrNwt"].Summary.Add((SummaryItemType)0, "KrNwt", "{0}");
					goto IL_0baa;
					IL_0baa:
					num2 = 104;
					((AppearanceObject)((ColumnView)GridView1).Columns["KrNwt"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_0bd5;
					IL_0bd5:
					num2 = 106;
					if (((ColumnView)GridView1).Columns["TagProfit"] != null)
					{
						goto IL_0bf9;
					}
					goto IL_0c9e;
					IL_0bf9:
					num2 = 107;
					((ColumnView)GridView1).Columns["TagProfit"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0c1d;
					IL_0c1d:
					num2 = 108;
					((ColumnView)GridView1).Columns["TagProfit"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_0c45;
					IL_0c45:
					num2 = 109;
					((ColumnView)GridView1).Columns["TagProfit"].Summary.Add((SummaryItemType)0, "TagProfit", "{0}");
					goto IL_0c73;
					IL_0c73:
					num2 = 110;
					((AppearanceObject)((ColumnView)GridView1).Columns["TagProfit"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_0c9e;
					IL_0c9e:
					num2 = 112;
					if (((ColumnView)GridView1).Columns["KrDif"] != null)
					{
						goto IL_0cbf;
					}
					goto IL_0d3b;
					IL_0cbf:
					num2 = 113;
					((ColumnView)GridView1).Columns["KrDif"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0ce3;
					IL_0ce3:
					num2 = 114;
					((ColumnView)GridView1).Columns["KrDif"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_0d0b;
					IL_0d0b:
					num2 = 115;
					((ColumnView)GridView1).Columns["KrDif"].Summary.Add((SummaryItemType)0, "KrDif", "{0}");
					goto IL_0d3b;
					IL_0d3b:
					num2 = 117;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VS071NSBU", false) != 0)
					{
						goto IL_0d57;
					}
					goto IL_0d9b;
					IL_0d57:
					num2 = 118;
					if (((ColumnView)GridView1).Columns["KrDif"] != null)
					{
						goto IL_0d78;
					}
					goto IL_0d9b;
					IL_0d78:
					num2 = 119;
					((ColumnView)GridView1).Columns["KrDif"].Visible = false;
					goto IL_0d9b;
					IL_0d9b:
					num2 = 122;
					if (((ColumnView)GridView1).Columns["LbrAmt"] != null)
					{
						goto IL_0dbc;
					}
					goto IL_0e38;
					IL_0dbc:
					num2 = 123;
					((ColumnView)GridView1).Columns["LbrAmt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0de0;
					IL_0de0:
					num2 = 124;
					((ColumnView)GridView1).Columns["LbrAmt"].DisplayFormat.FormatString = "{0:n0}";
					goto IL_0e08;
					IL_0e08:
					num2 = 125;
					((ColumnView)GridView1).Columns["LbrAmt"].Summary.Add((SummaryItemType)0, "LbrAmt", "{0}");
					goto IL_0e38;
					IL_0e38:
					num2 = 127;
					if (((ColumnView)GridView1).Columns["OthAmt"] != null)
					{
						goto IL_0e5c;
					}
					goto IL_0ee1;
					IL_0e5c:
					num2 = 128;
					((ColumnView)GridView1).Columns["OthAmt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_0e83;
					IL_0e83:
					num2 = 129;
					((ColumnView)GridView1).Columns["OthAmt"].DisplayFormat.FormatString = "{0:n0}";
					goto IL_0eae;
					IL_0eae:
					num2 = 130;
					((ColumnView)GridView1).Columns["OthAmt"].Summary.Add((SummaryItemType)0, "OthAmt", "{0}");
					goto IL_0ee1;
					IL_0ee1:
					num2 = 132;
					if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
					{
						goto IL_0f04;
					}
					goto IL_174b;
					IL_0f04:
					num2 = 133;
					if (((ColumnView)GridView1).Columns["Qty"] != null)
					{
						goto IL_0f28;
					}
					goto IL_0f4a;
					IL_0f28:
					num2 = 134;
					((ColumnView)GridView1).Columns["Qty"].Visible = false;
					goto IL_0f4a;
					IL_0f4a:
					num2 = 135;
					if (((ColumnView)GridView1).Columns["LbrRate"] != null)
					{
						goto IL_0f6e;
					}
					goto IL_0f90;
					IL_0f6e:
					num2 = 136;
					((ColumnView)GridView1).Columns["LbrRate"].Visible = false;
					goto IL_0f90;
					IL_0f90:
					num2 = 137;
					if (((ColumnView)GridView1).Columns["Lbrprc"] != null)
					{
						goto IL_0fb4;
					}
					goto IL_0fd6;
					IL_0fb4:
					num2 = 138;
					((ColumnView)GridView1).Columns["Lbrprc"].Visible = false;
					goto IL_0fd6;
					IL_0fd6:
					num2 = 139;
					if (((ColumnView)GridView1).Columns["TagId"] != null)
					{
						goto IL_0ffa;
					}
					goto IL_101c;
					IL_0ffa:
					num2 = 140;
					((ColumnView)GridView1).Columns["TagId"].Visible = false;
					goto IL_101c;
					IL_101c:
					num2 = 141;
					if (Operators.CompareString(IdtlWithName, "Y", false) == 0)
					{
						goto IL_103f;
					}
					goto IL_1398;
					IL_103f:
					num2 = 142;
					if (((ColumnView)GridView1).Columns["It1P"] != null)
					{
						goto IL_1063;
					}
					goto IL_1094;
					IL_1063:
					num2 = 143;
					((ColumnView)GridView1).Columns["It1P"].Summary.Add((SummaryItemType)0, "It1P", "{0}");
					goto IL_1094;
					IL_1094:
					num2 = 144;
					if (((ColumnView)GridView1).Columns["It1Wt"] != null)
					{
						goto IL_10b8;
					}
					goto IL_10e9;
					IL_10b8:
					num2 = 145;
					((ColumnView)GridView1).Columns["It1Wt"].Summary.Add((SummaryItemType)0, "It1Wt", "{0}");
					goto IL_10e9;
					IL_10e9:
					num2 = 146;
					if (((ColumnView)GridView1).Columns["It2P"] != null)
					{
						goto IL_110d;
					}
					goto IL_113e;
					IL_110d:
					num2 = 147;
					((ColumnView)GridView1).Columns["It2P"].Summary.Add((SummaryItemType)0, "It2P", "{0}");
					goto IL_113e;
					IL_113e:
					num2 = 148;
					if (((ColumnView)GridView1).Columns["It2Wt"] != null)
					{
						goto IL_1162;
					}
					goto IL_1193;
					IL_1162:
					num2 = 149;
					((ColumnView)GridView1).Columns["It2Wt"].Summary.Add((SummaryItemType)0, "It2Wt", "{0}");
					goto IL_1193;
					IL_1193:
					num2 = 150;
					if (((ColumnView)GridView1).Columns["It3P"] != null)
					{
						goto IL_11b7;
					}
					goto IL_11e8;
					IL_11b7:
					num2 = 151;
					((ColumnView)GridView1).Columns["It3P"].Summary.Add((SummaryItemType)0, "It3P", "{0}");
					goto IL_11e8;
					IL_11e8:
					num2 = 152;
					if (((ColumnView)GridView1).Columns["It3Wt"] != null)
					{
						goto IL_120c;
					}
					goto IL_123d;
					IL_120c:
					num2 = 153;
					((ColumnView)GridView1).Columns["It3Wt"].Summary.Add((SummaryItemType)0, "It3Wt", "{0}");
					goto IL_123d;
					IL_123d:
					num2 = 154;
					if (((ColumnView)GridView1).Columns["It4P"] != null)
					{
						goto IL_1261;
					}
					goto IL_1292;
					IL_1261:
					num2 = 155;
					((ColumnView)GridView1).Columns["It4P"].Summary.Add((SummaryItemType)0, "It4P", "{0}");
					goto IL_1292;
					IL_1292:
					num2 = 156;
					if (((ColumnView)GridView1).Columns["It4Wt"] != null)
					{
						goto IL_12b6;
					}
					goto IL_12e7;
					IL_12b6:
					num2 = 157;
					((ColumnView)GridView1).Columns["It4Wt"].Summary.Add((SummaryItemType)0, "It4Wt", "{0}");
					goto IL_12e7;
					IL_12e7:
					num2 = 158;
					if (((ColumnView)GridView1).Columns["It5P"] != null)
					{
						goto IL_130b;
					}
					goto IL_133c;
					IL_130b:
					num2 = 159;
					((ColumnView)GridView1).Columns["It5P"].Summary.Add((SummaryItemType)0, "It5P", "{0}");
					goto IL_133c;
					IL_133c:
					num2 = 160;
					if (((ColumnView)GridView1).Columns["It5Wt"] != null)
					{
						goto IL_1360;
					}
					goto IL_174b;
					IL_1360:
					num2 = 161;
					((ColumnView)GridView1).Columns["It5Wt"].Summary.Add((SummaryItemType)0, "It5Wt", "{0}");
					goto IL_174b;
					IL_1398:
					num2 = 163;
					if (((ColumnView)GridView1).Columns[Col1 + "pc"] != null)
					{
						goto IL_13c7;
					}
					goto IL_140e;
					IL_13c7:
					num2 = 164;
					((ColumnView)GridView1).Columns[Col1 + "pc"].Summary.Add((SummaryItemType)0, Col1 + "pc", "{0}");
					goto IL_140e;
					IL_140e:
					num2 = 165;
					if (((ColumnView)GridView1).Columns[Col1 + "wt"] != null)
					{
						goto IL_143d;
					}
					goto IL_1484;
					IL_143d:
					num2 = 166;
					((ColumnView)GridView1).Columns[Col1 + "wt"].Summary.Add((SummaryItemType)0, Col1 + "wt", "{0}");
					goto IL_1484;
					IL_1484:
					num2 = 167;
					if (((ColumnView)GridView1).Columns[Col2 + "pc"] != null)
					{
						goto IL_14b3;
					}
					goto IL_14fa;
					IL_14b3:
					num2 = 168;
					((ColumnView)GridView1).Columns[Col2 + "pc"].Summary.Add((SummaryItemType)0, Col2 + "pc", "{0}");
					goto IL_14fa;
					IL_14fa:
					num2 = 169;
					if (((ColumnView)GridView1).Columns[Col2 + "wt"] != null)
					{
						goto IL_1529;
					}
					goto IL_1570;
					IL_1529:
					num2 = 170;
					((ColumnView)GridView1).Columns[Col2 + "wt"].Summary.Add((SummaryItemType)0, Col2 + "wt", "{0}");
					goto IL_1570;
					IL_1570:
					num2 = 171;
					if (((ColumnView)GridView1).Columns[Col3 + "pc"] != null)
					{
						goto IL_159f;
					}
					goto IL_15e6;
					IL_159f:
					num2 = 172;
					((ColumnView)GridView1).Columns[Col3 + "pc"].Summary.Add((SummaryItemType)0, Col3 + "pc", "{0}");
					goto IL_15e6;
					IL_15e6:
					num2 = 173;
					if (((ColumnView)GridView1).Columns[Col3 + "wt"] != null)
					{
						goto IL_1615;
					}
					goto IL_165c;
					IL_1615:
					num2 = 174;
					((ColumnView)GridView1).Columns[Col3 + "wt"].Summary.Add((SummaryItemType)0, Col3 + "wt", "{0}");
					goto IL_165c;
					IL_165c:
					num2 = 175;
					if (((ColumnView)GridView1).Columns[Col4 + "pc"] != null)
					{
						goto IL_168b;
					}
					goto IL_16d2;
					IL_168b:
					num2 = 176;
					((ColumnView)GridView1).Columns[Col4 + "pc"].Summary.Add((SummaryItemType)0, Col4 + "pc", "{0}");
					goto IL_16d2;
					IL_16d2:
					num2 = 177;
					if (((ColumnView)GridView1).Columns[Col4 + "wt"] != null)
					{
						goto IL_1701;
					}
					goto IL_174b;
					IL_1701:
					num2 = 178;
					((ColumnView)GridView1).Columns[Col4 + "wt"].Summary.Add((SummaryItemType)0, Col4 + "wt", "{0}");
					goto IL_174b;
					IL_174b:
					num2 = 181;
					if (!((Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0) & (DC_Main.ScreenHight > 1.0)))
					{
						goto end_IL_0001_3;
					}
					goto IL_177e;
					IL_177e:
					num2 = 182;
					num5 = checked((int)Math.Ceiling(9.0 * DC_Main.ScreenHight));
					goto IL_179b;
					IL_179b:
					num2 = 183;
					GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_17c4;
					end_IL_0001_2:
					break;
				}
				num2 = 188;
				GridView1.BestFitColumns(true);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7040;
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

	private void RP_TAG_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void BtnStock_Click(object sender, EventArgs e)
	{
		IdtlWithName = "N";
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (cboRptType.SelectedIndex == 1)
		{
			RptType = "";
			Itm_Summ("Stock");
		}
		else if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
		{
			RptType = "TagStk";
			Jdt_Tag_Detalil("Stock");
		}
		else
		{
			RptType = "TagStk";
			Tag_Summ("Stock");
		}
	}

	private void Jdt_Tag_Detalil(string RptType)
	{
		//IL_11fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1205: Expected O, but got Unknown
		//IL_1241: Unknown result type (might be due to invalid IL or missing references)
		//IL_124b: Expected O, but got Unknown
		//IL_129c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ab: Expected O, but got Unknown
		//IL_27e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_27eb: Expected O, but got Unknown
		//IL_282b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2835: Expected O, but got Unknown
		//IL_2854: Unknown result type (might be due to invalid IL or missing references)
		//IL_285e: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataView dataView = default(DataView);
		GridView val = default(GridView);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (Operators.CompareString(RptType, "In", false) == 0)
					{
						goto IL_001c;
					}
					goto IL_049f;
				case 11544:
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
							goto IL_001c;
						case 3:
							goto IL_0272;
						case 4:
							goto IL_0293;
						case 5:
						case 6:
							goto IL_02bb;
						case 7:
							goto IL_02dc;
						case 8:
						case 9:
							goto IL_0304;
						case 10:
							goto IL_0326;
						case 11:
						case 12:
							goto IL_034f;
						case 13:
							goto IL_0371;
						case 14:
						case 15:
							goto IL_039a;
						case 16:
							goto IL_03bc;
						case 17:
						case 18:
							goto IL_03e5;
						case 19:
							goto IL_0407;
						case 20:
						case 21:
							goto IL_0437;
						case 22:
							goto IL_0459;
						case 23:
						case 24:
							goto IL_0482;
						case 26:
							goto IL_049f;
						case 27:
							goto IL_04ba;
						case 28:
							goto IL_0711;
						case 29:
							goto IL_0733;
						case 30:
						case 31:
							goto IL_075c;
						case 32:
							goto IL_077e;
						case 33:
						case 34:
							goto IL_07a7;
						case 35:
							goto IL_07c9;
						case 36:
						case 37:
							goto IL_07f2;
						case 38:
							goto IL_0814;
						case 39:
						case 40:
							goto IL_083d;
						case 41:
							goto IL_085f;
						case 42:
						case 43:
							goto IL_0888;
						case 44:
							goto IL_08aa;
						case 45:
						case 46:
							goto IL_08d3;
						case 47:
							goto IL_08f5;
						case 48:
						case 49:
							goto IL_0925;
						case 51:
							goto IL_0942;
						case 52:
							goto IL_096d;
						case 53:
							goto IL_0b96;
						case 54:
							goto IL_0bb8;
						case 55:
						case 56:
							goto IL_0be1;
						case 57:
							goto IL_0c03;
						case 58:
						case 59:
							goto IL_0c2c;
						case 60:
							goto IL_0c4e;
						case 61:
						case 62:
							goto IL_0c77;
						case 63:
							goto IL_0c99;
						case 64:
						case 65:
							goto IL_0cc2;
						case 66:
							goto IL_0ce4;
						case 67:
						case 68:
							goto IL_0d0d;
						case 69:
							goto IL_0d2f;
						case 70:
						case 71:
							goto IL_0d5f;
						case 72:
							goto IL_0d77;
						case 73:
						case 74:
							goto IL_0d90;
						case 75:
							goto IL_0db2;
						case 76:
						case 77:
							goto IL_0ddb;
						case 78:
							goto IL_0df2;
						case 80:
							goto IL_0e0f;
						case 81:
							goto IL_0e2a;
						case 82:
							goto IL_0eeb;
						case 83:
							goto IL_0f0d;
						case 84:
						case 85:
							goto IL_0f36;
						case 86:
							goto IL_0f58;
						case 87:
						case 88:
							goto IL_0fd1;
						case 89:
							goto IL_0ff3;
						case 90:
						case 91:
							goto IL_101c;
						case 92:
							goto IL_103e;
						case 93:
						case 94:
							goto IL_1067;
						case 95:
							goto IL_1089;
						case 96:
						case 97:
							goto IL_10b2;
						case 98:
							goto IL_10d4;
						case 99:
						case 100:
							goto IL_10fd;
						case 101:
							goto IL_111f;
						case 102:
						case 103:
							goto IL_114f;
						case 104:
							goto IL_1171;
						case 105:
						case 106:
							goto IL_119a;
						case 25:
						case 50:
						case 79:
						case 107:
						case 108:
							goto IL_11b2;
						case 109:
							goto IL_11c5;
						case 110:
							goto IL_11cf;
						case 111:
							goto IL_11de;
						case 112:
							goto IL_1206;
						case 113:
							goto IL_1224;
						case 114:
							goto IL_124c;
						case 115:
							goto IL_125d;
						case 116:
							goto IL_1279;
						case 117:
						case 118:
							goto IL_12ae;
						case 119:
							goto IL_12c0;
						case 120:
							goto IL_12d0;
						case 121:
						case 123:
						case 124:
							goto IL_12e9;
						case 125:
							goto IL_12fe;
						case 126:
							goto IL_130e;
						case 127:
							goto IL_132f;
						case 128:
							goto IL_133a;
						case 129:
							goto IL_1359;
						case 130:
							goto IL_1378;
						case 131:
							goto IL_1397;
						case 132:
							goto IL_13b6;
						case 133:
							goto IL_13d5;
						case 134:
							goto IL_13f4;
						case 135:
							goto IL_1413;
						case 136:
							goto IL_1432;
						case 137:
							goto IL_1451;
						case 138:
							goto IL_1470;
						case 139:
							goto IL_148f;
						case 140:
							goto IL_14ae;
						case 141:
							goto IL_14cd;
						case 142:
							goto IL_14ec;
						case 143:
							goto IL_150b;
						case 144:
							goto IL_152a;
						case 145:
							goto IL_1549;
						case 146:
							goto IL_1568;
						case 147:
							goto IL_1587;
						case 148:
							goto IL_15a6;
						case 149:
							goto IL_15c5;
						case 150:
							goto IL_15e4;
						case 151:
							goto IL_1603;
						case 152:
							goto IL_1622;
						case 153:
							goto IL_1641;
						case 154:
							goto IL_1660;
						case 155:
							goto IL_167f;
						case 156:
							goto IL_169e;
						case 157:
							goto IL_16be;
						case 158:
						case 159:
							goto IL_16c3;
						case 160:
							goto IL_16cc;
						case 161:
							goto IL_16eb;
						case 162:
						case 163:
							goto IL_170f;
						case 164:
							goto IL_1733;
						case 165:
							goto IL_1755;
						case 166:
							goto IL_1779;
						case 167:
							goto IL_179b;
						case 168:
							goto IL_17bf;
						case 169:
							goto IL_17e1;
						case 170:
							goto IL_1805;
						case 171:
							goto IL_1836;
						case 172:
							goto IL_185a;
						case 173:
							goto IL_188b;
						case 174:
							goto IL_18b2;
						case 175:
							goto IL_18d9;
						case 176:
							goto IL_1904;
						case 177:
						case 178:
							goto IL_1937;
						case 179:
							goto IL_195e;
						case 180:
							goto IL_1985;
						case 181:
							goto IL_19b0;
						case 182:
						case 183:
							goto IL_19e3;
						case 184:
							goto IL_1a0a;
						case 185:
							goto IL_1a31;
						case 186:
							goto IL_1a5c;
						case 187:
						case 188:
							goto IL_1a8f;
						case 189:
							goto IL_1ab6;
						case 190:
							goto IL_1add;
						case 191:
							goto IL_1b08;
						case 192:
						case 193:
							goto IL_1b3b;
						case 194:
							goto IL_1b62;
						case 195:
							goto IL_1b89;
						case 196:
							goto IL_1bb4;
						case 197:
						case 198:
							goto IL_1be7;
						case 199:
							goto IL_1c0e;
						case 200:
							goto IL_1c35;
						case 201:
							goto IL_1c60;
						case 202:
						case 203:
							goto IL_1c93;
						case 204:
							goto IL_1cba;
						case 205:
							goto IL_1ce1;
						case 206:
							goto IL_1d0c;
						case 207:
						case 208:
							goto IL_1d3f;
						case 209:
							goto IL_1d66;
						case 210:
							goto IL_1d8d;
						case 211:
							goto IL_1db8;
						case 212:
						case 213:
							goto IL_1deb;
						case 214:
							goto IL_1e12;
						case 215:
							goto IL_1e39;
						case 216:
							goto IL_1e64;
						case 217:
						case 218:
							goto IL_1e97;
						case 219:
							goto IL_1ebe;
						case 220:
							goto IL_1ee5;
						case 221:
							goto IL_1f10;
						case 222:
						case 223:
							goto IL_1f43;
						case 224:
							goto IL_1f6a;
						case 225:
							goto IL_1f91;
						case 226:
							goto IL_1fbc;
						case 227:
						case 228:
							goto IL_1fef;
						case 229:
							goto IL_2013;
						case 230:
							goto IL_203a;
						case 231:
						case 232:
							goto IL_2067;
						case 233:
							goto IL_208e;
						case 234:
							goto IL_20b5;
						case 235:
							goto IL_20e0;
						case 236:
						case 237:
							goto IL_2113;
						case 238:
							goto IL_213a;
						case 239:
							goto IL_2161;
						case 240:
							goto IL_218c;
						case 241:
						case 242:
							goto IL_21bf;
						case 243:
							goto IL_21e6;
						case 244:
							goto IL_220d;
						case 245:
							goto IL_2238;
						case 246:
						case 247:
							goto IL_226b;
						case 248:
							goto IL_2292;
						case 249:
							goto IL_22b9;
						case 250:
							goto IL_22e4;
						case 251:
						case 252:
							goto IL_2317;
						case 253:
							goto IL_233e;
						case 254:
							goto IL_2365;
						case 255:
							goto IL_2390;
						case 256:
						case 257:
							goto IL_23c3;
						case 258:
							goto IL_23f2;
						case 259:
							goto IL_2439;
						case 260:
							goto IL_2468;
						case 261:
							goto IL_24af;
						case 262:
							goto IL_24de;
						case 263:
							goto IL_2525;
						case 264:
							goto IL_2554;
						case 265:
							goto IL_259b;
						case 266:
							goto IL_25ca;
						case 267:
							goto IL_2611;
						case 268:
							goto IL_2640;
						case 269:
							goto IL_2687;
						case 270:
							goto IL_26b6;
						case 271:
							goto IL_26fd;
						case 272:
							goto IL_272c;
						case 273:
							goto IL_2773;
						case 274:
							goto IL_27a6;
						case 275:
							goto IL_27c3;
						case 276:
							goto IL_27ec;
						case 277:
							goto IL_280d;
						case 278:
							goto IL_2836;
						case 279:
							goto IL_285f;
						case 280:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 122:
						case 281:
						case 282:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_280d:
					num2 = 277;
					GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_2836;
					IL_2836:
					num2 = 278;
					GridView1.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_285f;
					IL_27ec:
					num2 = 276;
					GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
					goto IL_280d;
					IL_285f:
					num2 = 279;
					GridView1.RowHeight = checked((int)Math.Round(22.0 * DC_Main.ScreenHight));
					break;
					IL_001c:
					num2 = 2;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.VCH_DATE As VchDate,C.TAG_NO As TagNo,C.IT_CODE As ItCode,C.TBL_CODE As Counter,C.ITM_SIZE As Size,C.DESIGN_NO As Design,C.ITM_NWT AS NetWt,1 AS Qty,C.ITM_PCS as Pcs,  C.ITM_GWT As Grwt,C.JDT_JDT_WT As JdtWt,C.JDT_GHT_WT As JGhtWt,C.JDT_KUN_WT As Kundan,C.KR_NET_WT As KrNWt,  C.KR_WAX_WT As KrWax,C.JDT_WAX_WT As Wax,C.ITM_TOUCH As Touch,C.ITM_WEST_PRC As West,C.ITM_FINE AS Fine,C.KR_FINE As KrFine,C.ITM_FINE-C.KR_FINE As PfFine,CASE WHEN C.ITM_FINE-C.KR_FINE <> 0 THEN ((C.ITM_FINE*100)/C.KR_FINE)-100 ELSE 0 END As PfPrc,C.LBR_AMT LbrAmt,C.KR_LBR_AMT As KrLbr,C.OTH_AMT OthAmt,C.KR_OTH_AMT As KrOth,C.OTH_AMT -C.KR_OTH_AMT As OthPf,  C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,  (Select SUM(D.IT_PCS) FROM BAR_IDTL AS D WHERE C.CO_CODE = D.CO_CODE And C.LC_CODE = D.LC_CODE And C.TAG_NO = D.TAG_NO And C.VCH_SRNO = D.VCH_SRNO And D.IT_PCS <> 0 And D.IT_CODE = '" + Col1 + "') As " + Col1 + "pc,  (Select SUM(E.IT_GWT) FROM BAR_IDTL AS E WHERE C.CO_CODE = E.CO_CODE And C.LC_CODE = E.LC_CODE AND C.TAG_NO = E.TAG_NO AND C.VCH_SRNO = E.VCH_SRNO AND E.IT_GWT <> 0 AND E.IT_CODE = '" + Col1 + "') As " + Col1 + "wt,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE And C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.IT_CODE = '" + Col2 + "') As " + Col2 + "pc,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE And C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.IT_CODE = '" + Col2 + "') As " + Col2 + "wt,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE And C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.IT_CODE = '" + Col3 + "') As " + Col3 + "pc,  (Select SUM(I.IT_GWT) FROM BAR_IDTL AS I WHERE C.CO_CODE = I.CO_CODE And C.LC_CODE = I.LC_CODE AND C.TAG_NO = I.TAG_NO AND C.VCH_SRNO = I.VCH_SRNO AND I.IT_GWT <> 0 AND I.IT_CODE = '" + Col3 + "') As " + Col3 + "wt,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE And C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.IT_CODE = '" + Col4 + "') As " + Col4 + "pc,  (Select SUM(K.IT_GWT) FROM BAR_IDTL AS K WHERE C.CO_CODE = K.CO_CODE And C.LC_CODE = K.LC_CODE AND C.TAG_NO = K.TAG_NO AND C.VCH_SRNO = K.VCH_SRNO AND K.IT_GWT <> 0 AND K.IT_CODE = '" + Col4 + "') As " + Col4 + "wt  from BAR_DETL AS C LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND C.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND C.TAG_NO <> 'N' AND C.KR_FINE > 0 AND C.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND C.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_0272;
					IL_0272:
					num2 = 3;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0293;
					}
					goto IL_02bb;
					IL_0293:
					num2 = 4;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_02bb;
					IL_02bb:
					num2 = 6;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_02dc;
					}
					goto IL_0304;
					IL_02dc:
					num2 = 7;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_0304;
					IL_0304:
					num2 = 9;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_0326;
					}
					goto IL_034f;
					IL_0326:
					num2 = 10;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_034f;
					IL_034f:
					num2 = 12;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_0371;
					}
					goto IL_039a;
					IL_0371:
					num2 = 13;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_039a;
					IL_039a:
					num2 = 15;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_03bc;
					}
					goto IL_03e5;
					IL_03bc:
					num2 = 16;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_03e5;
					IL_03e5:
					num2 = 18;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_0407;
					}
					goto IL_0437;
					IL_0407:
					num2 = 19;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_0437;
					IL_0437:
					num2 = 21;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_0459;
					}
					goto IL_0482;
					IL_0459:
					num2 = 22;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_0482;
					IL_0482:
					num2 = 24;
					DC_Main.RsQry += "ORDER BY C.TAG_NO";
					goto IL_11b2;
					IL_049f:
					num2 = 26;
					if (Operators.CompareString(RptType, "Out", false) == 0)
					{
						goto IL_04ba;
					}
					goto IL_0942;
					IL_04ba:
					num2 = 27;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.ITM_SIZE As Size,C.DESIGN_NO As Design,C.ITM_NWT AS NetWt,1 AS Qty,A.ITM_PCS as Pcs,  A.ITM_GWT As Grwt,C.JDT_JDT_WT As JdtWt,C.JDT_GHT_WT As JGhtWt,C.JDT_KUN_WT As Kundan,C.KR_NET_WT As KrNWt,  C.KR_WAX_WT As KrWax,C.JDT_WAX_WT As Wax,A.ITM_TOUCH As Touch,A.ITM_WEST As West,A.ITM_FINE AS Fine,C.KR_FINE As KrFine,A.ITM_FINE-C.KR_FINE As PfFine,CASE WHEN C.ITM_FINE-C.KR_FINE <> 0 THEN ((A.ITM_FINE*100)/C.KR_FINE)-100 ELSE 0 END As PfPrc,A.LBR_AMT LbrAmt,C.KR_LBR_AMT As KrLbr,A.OTH_AMT OthAmt,C.KR_OTH_AMT As KrOth,A.OTH_AMT -C.KR_OTH_AMT As OthPf,  C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,  (Select SUM(D.IT_PCS) FROM BAR_IDTL AS D WHERE C.CO_CODE = D.CO_CODE And C.LC_CODE = D.LC_CODE And C.TAG_NO = D.TAG_NO And C.VCH_SRNO = D.VCH_SRNO And D.IT_PCS <> 0 And D.IT_CODE = '" + Col1 + "') As " + Col1 + "pc,  (Select SUM(E.IT_GWT) FROM BAR_IDTL AS E WHERE C.CO_CODE = E.CO_CODE And C.LC_CODE = E.LC_CODE AND C.TAG_NO = E.TAG_NO AND C.VCH_SRNO = E.VCH_SRNO AND E.IT_GWT <> 0 AND E.IT_CODE = '" + Col1 + "') As " + Col1 + "wt,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE And C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.IT_CODE = '" + Col2 + "') As " + Col2 + "pc,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE And C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.IT_CODE = '" + Col2 + "') As " + Col2 + "wt,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE And C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.IT_CODE = '" + Col3 + "') As " + Col3 + "pc,  (Select SUM(I.IT_GWT) FROM BAR_IDTL AS I WHERE C.CO_CODE = I.CO_CODE And C.LC_CODE = I.LC_CODE AND C.TAG_NO = I.TAG_NO AND C.VCH_SRNO = I.VCH_SRNO AND I.IT_GWT <> 0 AND I.IT_CODE = '" + Col3 + "') As " + Col3 + "wt,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE And C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.IT_CODE = '" + Col4 + "') As " + Col4 + "pc,  (Select SUM(K.IT_GWT) FROM BAR_IDTL AS K WHERE C.CO_CODE = K.CO_CODE And C.LC_CODE = K.LC_CODE AND C.TAG_NO = K.TAG_NO AND C.VCH_SRNO = K.VCH_SRNO AND K.IT_GWT <> 0 AND K.IT_CODE = '" + Col4 + "') As " + Col4 + "wt  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND C.KR_FINE > 0 AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_0711;
					IL_0711:
					num2 = 28;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0733;
					}
					goto IL_075c;
					IL_0733:
					num2 = 29;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_075c;
					IL_075c:
					num2 = 31;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_077e;
					}
					goto IL_07a7;
					IL_077e:
					num2 = 32;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_07a7;
					IL_07a7:
					num2 = 34;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_07c9;
					}
					goto IL_07f2;
					IL_07c9:
					num2 = 35;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_07f2;
					IL_07f2:
					num2 = 37;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_0814;
					}
					goto IL_083d;
					IL_0814:
					num2 = 38;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_083d;
					IL_083d:
					num2 = 40;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_085f;
					}
					goto IL_0888;
					IL_085f:
					num2 = 41;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_0888;
					IL_0888:
					num2 = 43;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_08aa;
					}
					goto IL_08d3;
					IL_08aa:
					num2 = 44;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_08d3;
					IL_08d3:
					num2 = 46;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_08f5;
					}
					goto IL_0925;
					IL_08f5:
					num2 = 47;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_0925;
					IL_0925:
					num2 = 49;
					DC_Main.RsQry += "ORDER BY A.VCH_TYPE,A.VCH_NO";
					goto IL_11b2;
					IL_0942:
					num2 = 51;
					if ((Operators.CompareString(RptType, "Stock", false) == 0) | (Operators.CompareString(RptType, "Mrp", false) == 0))
					{
						goto IL_096d;
					}
					goto IL_0e0f;
					IL_096d:
					num2 = 52;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.LC_CODE As LcCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As VchDate,C.TAG_NO As TagNo,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.ITM_SIZE As Size,C.DESIGN_NO As Design,C.ITM_NWT AS NetWt,1 AS Qty,C.ITM_PCS as Pcs,  C.ITM_GWT As Grwt,C.JDT_JDT_WT As JdtWt,C.JDT_GHT_WT As JGhtWt,C.JDT_KUN_WT As Kundan,C.KR_NET_WT As KrNWt,  C.KR_WAX_WT As KrWax,C.JDT_WAX_WT As Wax,C.ITM_TOUCH As Touch,C.ITM_WEST_PRC As West,C.ITM_FINE AS Fine,C.KR_FINE As KrFine,C.ITM_FINE-C.KR_FINE As PfFine,CASE WHEN C.ITM_FINE-C.KR_FINE <> 0 THEN ((C.ITM_FINE*100)/C.KR_FINE)-100 ELSE 0 END As PfPrc,C.LBR_AMT LbrAmt,C.KR_LBR_AMT As KrLbr,C.OTH_AMT OthAmt,C.KR_OTH_AMT As KrOth,C.OTH_AMT -C.KR_OTH_AMT As OthPf,  C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,  (Select SUM(D.IT_PCS) FROM BAR_IDTL AS D WHERE C.CO_CODE = D.CO_CODE And C.LC_CODE = D.LC_CODE And C.TAG_NO = D.TAG_NO And C.VCH_SRNO = D.VCH_SRNO And D.IT_PCS <> 0 And D.IT_CODE = '" + Col1 + "') As " + Col1 + "pc,  (Select SUM(E.IT_GWT) FROM BAR_IDTL AS E WHERE C.CO_CODE = E.CO_CODE And C.LC_CODE = E.LC_CODE AND C.TAG_NO = E.TAG_NO AND C.VCH_SRNO = E.VCH_SRNO AND E.IT_GWT <> 0 AND E.IT_CODE = '" + Col1 + "') As " + Col1 + "wt,  (Select SUM(F.IT_PCS) FROM BAR_IDTL As F WHERE C.CO_CODE = F.CO_CODE And C.LC_CODE = F.LC_CODE And C.TAG_NO = F.TAG_NO And C.VCH_SRNO = F.VCH_SRNO And F.IT_PCS <> 0 And F.IT_CODE = '" + Col2 + "') As " + Col2 + "pc,  (Select SUM(G.IT_GWT) FROM BAR_IDTL As G WHERE C.CO_CODE = G.CO_CODE And C.LC_CODE = G.LC_CODE And C.TAG_NO = G.TAG_NO And C.VCH_SRNO = G.VCH_SRNO And G.IT_GWT <> 0 And G.IT_CODE = '" + Col2 + "') As " + Col2 + "wt,  (Select SUM(H.IT_PCS) FROM BAR_IDTL As H WHERE C.CO_CODE = H.CO_CODE And C.LC_CODE = H.LC_CODE And C.TAG_NO = H.TAG_NO And C.VCH_SRNO = H.VCH_SRNO And H.IT_PCS <> 0 And H.IT_CODE = '" + Col3 + "') As " + Col3 + "pc,  (Select SUM(I.IT_GWT) FROM BAR_IDTL AS I WHERE C.CO_CODE = I.CO_CODE And C.LC_CODE = I.LC_CODE AND C.TAG_NO = I.TAG_NO AND C.VCH_SRNO = I.VCH_SRNO AND I.IT_GWT <> 0 AND I.IT_CODE = '" + Col3 + "') As " + Col3 + "wt,  (Select SUM(J.IT_PCS) FROM BAR_IDTL As J WHERE C.CO_CODE = J.CO_CODE And C.LC_CODE = J.LC_CODE And C.TAG_NO = J.TAG_NO And C.VCH_SRNO = J.VCH_SRNO And J.IT_PCS <> 0 And J.IT_CODE = '" + Col4 + "') As " + Col4 + "pc,  (Select SUM(K.IT_GWT) FROM BAR_IDTL AS K WHERE C.CO_CODE = K.CO_CODE And C.LC_CODE = K.LC_CODE AND C.TAG_NO = K.TAG_NO AND C.VCH_SRNO = K.VCH_SRNO AND K.IT_GWT <> 0 AND K.IT_CODE = '" + Col4 + "') As " + Col4 + "wt  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_0b96;
					IL_0b96:
					num2 = 53;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0bb8;
					}
					goto IL_0be1;
					IL_0bb8:
					num2 = 54;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_0be1;
					IL_0be1:
					num2 = 56;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_0c03;
					}
					goto IL_0c2c;
					IL_0c03:
					num2 = 57;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_0c2c;
					IL_0c2c:
					num2 = 59;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_0c4e;
					}
					goto IL_0c77;
					IL_0c4e:
					num2 = 60;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_0c77;
					IL_0c77:
					num2 = 62;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_0c99;
					}
					goto IL_0cc2;
					IL_0c99:
					num2 = 63;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_0cc2;
					IL_0cc2:
					num2 = 65;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_0ce4;
					}
					goto IL_0d0d;
					IL_0ce4:
					num2 = 66;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_0d0d;
					IL_0d0d:
					num2 = 68;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_0d2f;
					}
					goto IL_0d5f;
					IL_0d2f:
					num2 = 69;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_0d5f;
					IL_0d5f:
					num2 = 71;
					if (Operators.CompareString(RptType, "Mrp", false) == 0)
					{
						goto IL_0d77;
					}
					goto IL_0d90;
					IL_0d77:
					num2 = 72;
					DC_Main.RsQry += "AND C.ITM_MRP <> 0";
					goto IL_0d90;
					IL_0d90:
					num2 = 74;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_0db2;
					}
					goto IL_0ddb;
					IL_0db2:
					num2 = 75;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_0ddb;
					IL_0ddb:
					num2 = 77;
					DC_Main.RsQry += " GROUP BY C.CO_CODE,C.LC_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.ITM_SIZE,C.DESIGN_NO,C.ITM_NWT,C.ITM_PCS,  C.ITM_GWT,C.JDT_JDT_WT,C.JDT_GHT_WT,C.JDT_KUN_WT,C.KR_NET_WT,  C.KR_WAX_WT,C.JDT_WAX_WT,C.ITM_TOUCH,C.ITM_WEST_PRC,C.ITM_FINE,C.KR_FINE,C.ITM_FINE-C.KR_FINE,C.LBR_AMT,C.KR_LBR_AMT,C.OTH_AMT,C.KR_OTH_AMT,C.OTH_AMT -C.KR_OTH_AMT,  C.KR_NAME,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO ";
					goto IL_0df2;
					IL_0df2:
					num2 = 78;
					DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY C.TAG_NO";
					goto IL_11b2;
					IL_0e0f:
					num2 = 80;
					if (Operators.CompareString(RptType, "All", false) == 0)
					{
						goto IL_0e2a;
					}
					goto IL_11b2;
					IL_0e2a:
					num2 = 81;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,A.DESIGN_NO As Design,A.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,0 As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,C.OTH_AMT -C.KR_OTH_AMT As OthPf,  A.ITM_MRP As Mrp,'' As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,A.ITM_SIGN As Sign  from MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_0eeb;
					IL_0eeb:
					num2 = 82;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0f0d;
					}
					goto IL_0f36;
					IL_0f0d:
					num2 = 83;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_0f36;
					IL_0f36:
					num2 = 85;
					if (Operators.CompareString(tTagNo.Text, "", false) == 0)
					{
						goto IL_0f58;
					}
					goto IL_0fd1;
					IL_0f58:
					num2 = 86;
					DC_Main.RsQry = DC_Main.RsQry + "And A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
					goto IL_0fd1;
					IL_0fd1:
					num2 = 88;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_0ff3;
					}
					goto IL_101c;
					IL_0ff3:
					num2 = 89;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_101c;
					IL_101c:
					num2 = 91;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_103e;
					}
					goto IL_1067;
					IL_103e:
					num2 = 92;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_1067;
					IL_1067:
					num2 = 94;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_1089;
					}
					goto IL_10b2;
					IL_1089:
					num2 = 95;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_10b2;
					IL_10b2:
					num2 = 97;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_10d4;
					}
					goto IL_10fd;
					IL_10d4:
					num2 = 98;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_10fd;
					IL_10fd:
					num2 = 100;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_111f;
					}
					goto IL_114f;
					IL_111f:
					num2 = 101;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_114f;
					IL_114f:
					num2 = 103;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_1171;
					}
					goto IL_119a;
					IL_1171:
					num2 = 104;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_119a;
					IL_119a:
					num2 = 106;
					DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.TAG_NO";
					goto IL_11b2;
					IL_11b2:
					num2 = 108;
					RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_11c5;
					IL_11c5:
					num2 = 109;
					DGV_CLEAR();
					goto IL_11cf;
					IL_11cf:
					num2 = 110;
					dataView = new DataView(RsStkSum);
					goto IL_11de;
					IL_11de:
					num2 = 111;
					GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 9f);
					goto IL_1206;
					IL_1206:
					num2 = 112;
					GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
					goto IL_1224;
					IL_1224:
					num2 = 113;
					GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", 8.7f);
					goto IL_124c;
					IL_124c:
					num2 = 114;
					GridView1.RowHeight = 22;
					goto IL_125d;
					IL_125d:
					num2 = 115;
					if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
					{
						goto IL_1279;
					}
					goto IL_12ae;
					IL_1279:
					num2 = 116;
					GridView1.Appearance.Row.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize - 1f, DC_Main.MsFontStyle);
					goto IL_12ae;
					IL_12ae:
					num2 = 118;
					if (dataView.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_12c0;
					IL_12c0:
					num2 = 119;
					DGV.DataSource = dataView;
					goto IL_12d0;
					IL_12d0:
					num2 = 120;
					DGV.ForceInitialize();
					goto IL_12e9;
					IL_12e9:
					num2 = 124;
					GridView1.OptionsView.ColumnAutoWidth = false;
					goto IL_12fe;
					IL_12fe:
					num2 = 125;
					GridView1.HorzScrollVisibility = (ScrollVisibility)(-1);
					goto IL_130e;
					IL_130e:
					num2 = 126;
					if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
					{
						goto IL_132f;
					}
					goto IL_16c3;
					IL_132f:
					num2 = 127;
					val = GridView1;
					goto IL_133a;
					IL_133a:
					num2 = 128;
					((ColumnView)val).Columns["VchTyp"].Width = 70;
					goto IL_1359;
					IL_1359:
					num2 = 129;
					((ColumnView)val).Columns["VchNo"].Width = 60;
					goto IL_1378;
					IL_1378:
					num2 = 130;
					((ColumnView)val).Columns["VchDate"].Width = 85;
					goto IL_1397;
					IL_1397:
					num2 = 131;
					((ColumnView)val).Columns["TagNo"].Width = 80;
					goto IL_13b6;
					IL_13b6:
					num2 = 132;
					((ColumnView)val).Columns["ItCode"].Width = 60;
					goto IL_13d5;
					IL_13d5:
					num2 = 133;
					((ColumnView)val).Columns["Counter"].Width = 60;
					goto IL_13f4;
					IL_13f4:
					num2 = 134;
					((ColumnView)val).Columns["Size"].Width = 60;
					goto IL_1413;
					IL_1413:
					num2 = 135;
					((ColumnView)val).Columns["NetWt"].Width = 70;
					goto IL_1432;
					IL_1432:
					num2 = 136;
					((ColumnView)val).Columns["Design"].Width = 90;
					goto IL_1451;
					IL_1451:
					num2 = 137;
					((ColumnView)val).Columns["Qty"].Width = 60;
					goto IL_1470;
					IL_1470:
					num2 = 138;
					((ColumnView)val).Columns["Pcs"].Width = 60;
					goto IL_148f;
					IL_148f:
					num2 = 139;
					((ColumnView)val).Columns["Grwt"].Width = 70;
					goto IL_14ae;
					IL_14ae:
					num2 = 140;
					((ColumnView)val).Columns["JdtWt"].Width = 70;
					goto IL_14cd;
					IL_14cd:
					num2 = 141;
					((ColumnView)val).Columns["Kundan"].Width = 70;
					goto IL_14ec;
					IL_14ec:
					num2 = 142;
					((ColumnView)val).Columns["JGhtWt"].Width = 70;
					goto IL_150b;
					IL_150b:
					num2 = 143;
					((ColumnView)val).Columns["KrNWt"].Width = 70;
					goto IL_152a;
					IL_152a:
					num2 = 144;
					((ColumnView)val).Columns["KrWax"].Width = 70;
					goto IL_1549;
					IL_1549:
					num2 = 145;
					((ColumnView)val).Columns["Wax"].Width = 70;
					goto IL_1568;
					IL_1568:
					num2 = 146;
					((ColumnView)val).Columns["Touch"].Width = 70;
					goto IL_1587;
					IL_1587:
					num2 = 147;
					((ColumnView)val).Columns["West"].Width = 70;
					goto IL_15a6;
					IL_15a6:
					num2 = 148;
					((ColumnView)val).Columns["Fine"].Width = 70;
					goto IL_15c5;
					IL_15c5:
					num2 = 149;
					((ColumnView)val).Columns["KrFine"].Width = 70;
					goto IL_15e4;
					IL_15e4:
					num2 = 150;
					((ColumnView)val).Columns["PfFine"].Width = 70;
					goto IL_1603;
					IL_1603:
					num2 = 151;
					((ColumnView)val).Columns["LbrAmt"].Width = 70;
					goto IL_1622;
					IL_1622:
					num2 = 152;
					((ColumnView)val).Columns["KrLbr"].Width = 70;
					goto IL_1641;
					IL_1641:
					num2 = 153;
					((ColumnView)val).Columns["OthAmt"].Width = 70;
					goto IL_1660;
					IL_1660:
					num2 = 154;
					((ColumnView)val).Columns["KrOth"].Width = 70;
					goto IL_167f;
					IL_167f:
					num2 = 155;
					((ColumnView)val).Columns["KrName"].Width = 70;
					goto IL_169e;
					IL_169e:
					num2 = 156;
					((ColumnView)val).Columns["TagId"].Width = 100;
					goto IL_16be;
					IL_16be:
					val = null;
					goto IL_16c3;
					IL_16c3:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_16cc;
					IL_16cc:
					num2 = 160;
					if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) != 0)
					{
						goto IL_16eb;
					}
					goto IL_170f;
					IL_16eb:
					num2 = 161;
					((ColumnView)GridView1).Columns["CoCode"].Visible = false;
					goto IL_170f;
					IL_170f:
					num2 = 163;
					if (((ColumnView)GridView1).Columns["Book"] != null)
					{
						goto IL_1733;
					}
					goto IL_1755;
					IL_1733:
					num2 = 164;
					((ColumnView)GridView1).Columns["Book"].Visible = false;
					goto IL_1755;
					IL_1755:
					num2 = 165;
					if (((ColumnView)GridView1).Columns["BookName"] != null)
					{
						goto IL_1779;
					}
					goto IL_179b;
					IL_1779:
					num2 = 166;
					((ColumnView)GridView1).Columns["BookName"].Visible = false;
					goto IL_179b;
					IL_179b:
					num2 = 167;
					if (((ColumnView)GridView1).Columns["AcCode"] != null)
					{
						goto IL_17bf;
					}
					goto IL_17e1;
					IL_17bf:
					num2 = 168;
					((ColumnView)GridView1).Columns["AcCode"].Visible = false;
					goto IL_17e1;
					IL_17e1:
					num2 = 169;
					if (((ColumnView)GridView1).Columns["Qty"] != null)
					{
						goto IL_1805;
					}
					goto IL_1836;
					IL_1805:
					num2 = 170;
					((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");
					goto IL_1836;
					IL_1836:
					num2 = 171;
					if (((ColumnView)GridView1).Columns["Pcs"] != null)
					{
						goto IL_185a;
					}
					goto IL_188b;
					IL_185a:
					num2 = 172;
					((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
					goto IL_188b;
					IL_188b:
					num2 = 173;
					if (((ColumnView)GridView1).Columns["Grwt"] != null)
					{
						goto IL_18b2;
					}
					goto IL_1937;
					IL_18b2:
					num2 = 174;
					((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_18d9;
					IL_18d9:
					num2 = 175;
					((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1904;
					IL_1904:
					num2 = 176;
					((ColumnView)GridView1).Columns["Grwt"].Summary.Add((SummaryItemType)0, "Grwt", "{0}");
					goto IL_1937;
					IL_1937:
					num2 = 178;
					if (((ColumnView)GridView1).Columns["NetWt"] != null)
					{
						goto IL_195e;
					}
					goto IL_19e3;
					IL_195e:
					num2 = 179;
					((ColumnView)GridView1).Columns["NetWt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1985;
					IL_1985:
					num2 = 180;
					((ColumnView)GridView1).Columns["NetWt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_19b0;
					IL_19b0:
					num2 = 181;
					((ColumnView)GridView1).Columns["NetWt"].Summary.Add((SummaryItemType)0, "NetWt", "{0}");
					goto IL_19e3;
					IL_19e3:
					num2 = 183;
					if (((ColumnView)GridView1).Columns["JdtWt"] != null)
					{
						goto IL_1a0a;
					}
					goto IL_1a8f;
					IL_1a0a:
					num2 = 184;
					((ColumnView)GridView1).Columns["JdtWt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1a31;
					IL_1a31:
					num2 = 185;
					((ColumnView)GridView1).Columns["JdtWt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1a5c;
					IL_1a5c:
					num2 = 186;
					((ColumnView)GridView1).Columns["JdtWt"].Summary.Add((SummaryItemType)0, "JdtWt", "{0}");
					goto IL_1a8f;
					IL_1a8f:
					num2 = 188;
					if (((ColumnView)GridView1).Columns["JGhtWt"] != null)
					{
						goto IL_1ab6;
					}
					goto IL_1b3b;
					IL_1ab6:
					num2 = 189;
					((ColumnView)GridView1).Columns["JGhtWt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1add;
					IL_1add:
					num2 = 190;
					((ColumnView)GridView1).Columns["JGhtWt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1b08;
					IL_1b08:
					num2 = 191;
					((ColumnView)GridView1).Columns["JGhtWt"].Summary.Add((SummaryItemType)0, "JGhtWt", "{0}");
					goto IL_1b3b;
					IL_1b3b:
					num2 = 193;
					if (((ColumnView)GridView1).Columns["Kundan"] != null)
					{
						goto IL_1b62;
					}
					goto IL_1be7;
					IL_1b62:
					num2 = 194;
					((ColumnView)GridView1).Columns["Kundan"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1b89;
					IL_1b89:
					num2 = 195;
					((ColumnView)GridView1).Columns["Kundan"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1bb4;
					IL_1bb4:
					num2 = 196;
					((ColumnView)GridView1).Columns["Kundan"].Summary.Add((SummaryItemType)0, "Kundan", "{0}");
					goto IL_1be7;
					IL_1be7:
					num2 = 198;
					if (((ColumnView)GridView1).Columns["KrNWt"] != null)
					{
						goto IL_1c0e;
					}
					goto IL_1c93;
					IL_1c0e:
					num2 = 199;
					((ColumnView)GridView1).Columns["KrNWt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1c35;
					IL_1c35:
					num2 = 200;
					((ColumnView)GridView1).Columns["KrNWt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1c60;
					IL_1c60:
					num2 = 201;
					((ColumnView)GridView1).Columns["KrNWt"].Summary.Add((SummaryItemType)0, "KrNWt", "{0}");
					goto IL_1c93;
					IL_1c93:
					num2 = 203;
					if (((ColumnView)GridView1).Columns["KrWax"] != null)
					{
						goto IL_1cba;
					}
					goto IL_1d3f;
					IL_1cba:
					num2 = 204;
					((ColumnView)GridView1).Columns["KrWax"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1ce1;
					IL_1ce1:
					num2 = 205;
					((ColumnView)GridView1).Columns["KrWax"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1d0c;
					IL_1d0c:
					num2 = 206;
					((ColumnView)GridView1).Columns["KrWax"].Summary.Add((SummaryItemType)0, "KrWax", "{0}");
					goto IL_1d3f;
					IL_1d3f:
					num2 = 208;
					if (((ColumnView)GridView1).Columns["Wax"] != null)
					{
						goto IL_1d66;
					}
					goto IL_1deb;
					IL_1d66:
					num2 = 209;
					((ColumnView)GridView1).Columns["Wax"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1d8d;
					IL_1d8d:
					num2 = 210;
					((ColumnView)GridView1).Columns["Wax"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1db8;
					IL_1db8:
					num2 = 211;
					((ColumnView)GridView1).Columns["Wax"].Summary.Add((SummaryItemType)0, "Wax", "{0}");
					goto IL_1deb;
					IL_1deb:
					num2 = 213;
					if (((ColumnView)GridView1).Columns["Fine"] != null)
					{
						goto IL_1e12;
					}
					goto IL_1e97;
					IL_1e12:
					num2 = 214;
					((ColumnView)GridView1).Columns["Fine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1e39;
					IL_1e39:
					num2 = 215;
					((ColumnView)GridView1).Columns["Fine"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1e64;
					IL_1e64:
					num2 = 216;
					((ColumnView)GridView1).Columns["Fine"].Summary.Add((SummaryItemType)0, "Fine", "{0}");
					goto IL_1e97;
					IL_1e97:
					num2 = 218;
					if (((ColumnView)GridView1).Columns["KrFine"] != null)
					{
						goto IL_1ebe;
					}
					goto IL_1f43;
					IL_1ebe:
					num2 = 219;
					((ColumnView)GridView1).Columns["KrFine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1ee5;
					IL_1ee5:
					num2 = 220;
					((ColumnView)GridView1).Columns["KrFine"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1f10;
					IL_1f10:
					num2 = 221;
					((ColumnView)GridView1).Columns["KrFine"].Summary.Add((SummaryItemType)0, "KrFine", "{0}");
					goto IL_1f43;
					IL_1f43:
					num2 = 223;
					if (((ColumnView)GridView1).Columns["PfFine"] != null)
					{
						goto IL_1f6a;
					}
					goto IL_1fef;
					IL_1f6a:
					num2 = 224;
					((ColumnView)GridView1).Columns["PfFine"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_1f91;
					IL_1f91:
					num2 = 225;
					((ColumnView)GridView1).Columns["PfFine"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1fbc;
					IL_1fbc:
					num2 = 226;
					((ColumnView)GridView1).Columns["PfFine"].Summary.Add((SummaryItemType)0, "PfFine", "{0}");
					goto IL_1fef;
					IL_1fef:
					num2 = 228;
					if (((ColumnView)GridView1).Columns["PfPrc"] != null)
					{
						goto IL_2013;
					}
					goto IL_2067;
					IL_2013:
					num2 = 229;
					((ColumnView)GridView1).Columns["PfPrc"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_203a;
					IL_203a:
					num2 = 230;
					((ColumnView)GridView1).Columns["PfPrc"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_2067;
					IL_2067:
					num2 = 232;
					if (((ColumnView)GridView1).Columns["LbrAmt"] != null)
					{
						goto IL_208e;
					}
					goto IL_2113;
					IL_208e:
					num2 = 233;
					((ColumnView)GridView1).Columns["LbrAmt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_20b5;
					IL_20b5:
					num2 = 234;
					((ColumnView)GridView1).Columns["LbrAmt"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_20e0;
					IL_20e0:
					num2 = 235;
					((ColumnView)GridView1).Columns["LbrAmt"].Summary.Add((SummaryItemType)0, "LbrAmt", "{0}");
					goto IL_2113;
					IL_2113:
					num2 = 237;
					if (((ColumnView)GridView1).Columns["KrLbr"] != null)
					{
						goto IL_213a;
					}
					goto IL_21bf;
					IL_213a:
					num2 = 238;
					((ColumnView)GridView1).Columns["KrLbr"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_2161;
					IL_2161:
					num2 = 239;
					((ColumnView)GridView1).Columns["KrLbr"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_218c;
					IL_218c:
					num2 = 240;
					((ColumnView)GridView1).Columns["KrLbr"].Summary.Add((SummaryItemType)0, "KrLbr", "{0}");
					goto IL_21bf;
					IL_21bf:
					num2 = 242;
					if (((ColumnView)GridView1).Columns["OthAmt"] != null)
					{
						goto IL_21e6;
					}
					goto IL_226b;
					IL_21e6:
					num2 = 243;
					((ColumnView)GridView1).Columns["OthAmt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_220d;
					IL_220d:
					num2 = 244;
					((ColumnView)GridView1).Columns["OthAmt"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_2238;
					IL_2238:
					num2 = 245;
					((ColumnView)GridView1).Columns["OthAmt"].Summary.Add((SummaryItemType)0, "OthAmt", "{0}");
					goto IL_226b;
					IL_226b:
					num2 = 247;
					if (((ColumnView)GridView1).Columns["KrOth"] != null)
					{
						goto IL_2292;
					}
					goto IL_2317;
					IL_2292:
					num2 = 248;
					((ColumnView)GridView1).Columns["KrOth"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_22b9;
					IL_22b9:
					num2 = 249;
					((ColumnView)GridView1).Columns["KrOth"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_22e4;
					IL_22e4:
					num2 = 250;
					((ColumnView)GridView1).Columns["KrOth"].Summary.Add((SummaryItemType)0, "KrOth", "{0}");
					goto IL_2317;
					IL_2317:
					num2 = 252;
					if (((ColumnView)GridView1).Columns["OthPf"] != null)
					{
						goto IL_233e;
					}
					goto IL_23c3;
					IL_233e:
					num2 = 253;
					((ColumnView)GridView1).Columns["OthPf"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_2365;
					IL_2365:
					num2 = 254;
					((ColumnView)GridView1).Columns["OthPf"].DisplayFormat.FormatString = "{0:n2}";
					goto IL_2390;
					IL_2390:
					num2 = 255;
					((ColumnView)GridView1).Columns["OthPf"].Summary.Add((SummaryItemType)0, "OthPf", "{0}");
					goto IL_23c3;
					IL_23c3:
					num2 = 257;
					if (((ColumnView)GridView1).Columns[Col1 + "pc"] != null)
					{
						goto IL_23f2;
					}
					goto IL_2439;
					IL_23f2:
					num2 = 258;
					((ColumnView)GridView1).Columns[Col1 + "pc"].Summary.Add((SummaryItemType)0, Col1 + "pc", "{0}");
					goto IL_2439;
					IL_2439:
					num2 = 259;
					if (((ColumnView)GridView1).Columns[Col1 + "wt"] != null)
					{
						goto IL_2468;
					}
					goto IL_24af;
					IL_2468:
					num2 = 260;
					((ColumnView)GridView1).Columns[Col1 + "wt"].Summary.Add((SummaryItemType)0, Col1 + "wt", "{0}");
					goto IL_24af;
					IL_24af:
					num2 = 261;
					if (((ColumnView)GridView1).Columns[Col2 + "pc"] != null)
					{
						goto IL_24de;
					}
					goto IL_2525;
					IL_24de:
					num2 = 262;
					((ColumnView)GridView1).Columns[Col2 + "pc"].Summary.Add((SummaryItemType)0, Col2 + "pc", "{0}");
					goto IL_2525;
					IL_2525:
					num2 = 263;
					if (((ColumnView)GridView1).Columns[Col2 + "wt"] != null)
					{
						goto IL_2554;
					}
					goto IL_259b;
					IL_2554:
					num2 = 264;
					((ColumnView)GridView1).Columns[Col2 + "wt"].Summary.Add((SummaryItemType)0, Col2 + "wt", "{0}");
					goto IL_259b;
					IL_259b:
					num2 = 265;
					if (((ColumnView)GridView1).Columns[Col3 + "pc"] != null)
					{
						goto IL_25ca;
					}
					goto IL_2611;
					IL_25ca:
					num2 = 266;
					((ColumnView)GridView1).Columns[Col3 + "pc"].Summary.Add((SummaryItemType)0, Col3 + "pc", "{0}");
					goto IL_2611;
					IL_2611:
					num2 = 267;
					if (((ColumnView)GridView1).Columns[Col3 + "wt"] != null)
					{
						goto IL_2640;
					}
					goto IL_2687;
					IL_2640:
					num2 = 268;
					((ColumnView)GridView1).Columns[Col3 + "wt"].Summary.Add((SummaryItemType)0, Col3 + "wt", "{0}");
					goto IL_2687;
					IL_2687:
					num2 = 269;
					if (((ColumnView)GridView1).Columns[Col4 + "pc"] != null)
					{
						goto IL_26b6;
					}
					goto IL_26fd;
					IL_26b6:
					num2 = 270;
					((ColumnView)GridView1).Columns[Col4 + "pc"].Summary.Add((SummaryItemType)0, Col4 + "pc", "{0}");
					goto IL_26fd;
					IL_26fd:
					num2 = 271;
					if (((ColumnView)GridView1).Columns[Col4 + "wt"] != null)
					{
						goto IL_272c;
					}
					goto IL_2773;
					IL_272c:
					num2 = 272;
					((ColumnView)GridView1).Columns[Col4 + "wt"].Summary.Add((SummaryItemType)0, Col4 + "wt", "{0}");
					goto IL_2773;
					IL_2773:
					num2 = 273;
					if (!((Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0) & (DC_Main.ScreenHight > 1.0)))
					{
						goto end_IL_0001_3;
					}
					goto IL_27a6;
					IL_27a6:
					num2 = 274;
					num5 = checked((int)Math.Ceiling(9.0 * DC_Main.ScreenHight));
					goto IL_27c3;
					IL_27c3:
					num2 = 275;
					GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_27ec;
					end_IL_0001_2:
					break;
				}
				num2 = 280;
				GridView1.BestFitColumns(true);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 11544;
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

	private void BtnIn_Click(object sender, EventArgs e)
	{
		IdtlWithName = "N";
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
		{
			RptType = "";
			Jdt_Tag_Detalil("In");
		}
		else if (cboRptType.SelectedIndex == 1)
		{
			RptType = "";
			Itm_Summ("In");
		}
		else
		{
			RptType = "In";
			Tag_Summ("In");
		}
	}

	private void BtnOut_Click(object sender, EventArgs e)
	{
		IdtlWithName = "N";
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
		{
			RptType = "";
			Jdt_Tag_Detalil("Out");
		}
		else if (cboRptType.SelectedIndex == 1)
		{
			RptType = "";
			Itm_Summ("Out");
		}
		else
		{
			RptType = "Out";
			Tag_Summ("Out");
		}
	}

	private void BtnMrp_Click(object sender, EventArgs e)
	{
		IdtlWithName = "N";
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) != 0)
		{
			RptType = "";
			if (cboRptType.SelectedIndex == 1)
			{
				Itm_Summ("Mrp");
			}
			else
			{
				Tag_Summ("Mrp");
			}
		}
	}

	private void BtnApr_Click(object sender, EventArgs e)
	{
		IdtlWithName = "N";
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) != 0)
		{
			RptType = "";
			if (cboRptType.SelectedIndex == 1)
			{
				Itm_Summ("Apr");
				return;
			}
			Tag_Summ("Apr");
			RptType = "Apr";
		}
	}

	private void Itm_Summ(string RptType)
	{
		//IL_1955: Unknown result type (might be due to invalid IL or missing references)
		//IL_195f: Expected O, but got Unknown
		//IL_199f: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a9: Expected O, but got Unknown
		//IL_19c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d2: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataView dataView = default(DataView);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (Operators.CompareString(RptType, "In", false) == 0)
					{
						goto IL_001c;
					}
					goto IL_037c;
				case 7465:
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
							goto IL_001c;
						case 3:
							goto IL_0138;
						case 4:
							goto IL_0159;
						case 5:
						case 6:
							goto IL_0181;
						case 7:
							goto IL_01a2;
						case 8:
						case 9:
							goto IL_01ca;
						case 10:
							goto IL_01ec;
						case 11:
						case 12:
							goto IL_0215;
						case 13:
							goto IL_0237;
						case 14:
						case 15:
							goto IL_0260;
						case 16:
							goto IL_0282;
						case 17:
						case 18:
							goto IL_02ab;
						case 19:
							goto IL_02cd;
						case 20:
						case 21:
							goto IL_02fd;
						case 22:
							goto IL_031f;
						case 23:
						case 24:
							goto IL_0348;
						case 25:
							goto IL_035f;
						case 27:
							goto IL_037c;
						case 28:
							goto IL_0397;
						case 29:
							goto IL_03b6;
						case 31:
							goto IL_04c6;
						case 30:
						case 32:
						case 33:
							goto IL_05e4;
						case 34:
							goto IL_0606;
						case 35:
						case 36:
							goto IL_062f;
						case 37:
							goto IL_0651;
						case 38:
						case 39:
							goto IL_067a;
						case 40:
							goto IL_069c;
						case 41:
						case 42:
							goto IL_06c5;
						case 43:
							goto IL_06e7;
						case 44:
						case 45:
							goto IL_0710;
						case 46:
							goto IL_0732;
						case 47:
						case 48:
							goto IL_075b;
						case 49:
							goto IL_077d;
						case 50:
						case 51:
							goto IL_07a6;
						case 52:
							goto IL_07c8;
						case 53:
						case 54:
							goto IL_07f8;
						case 55:
							goto IL_080f;
						case 57:
							goto IL_082c;
						case 58:
							goto IL_0857;
						case 59:
							goto IL_086e;
						case 60:
							goto IL_087c;
						case 61:
							goto IL_0937;
						case 63:
							goto IL_0949;
						case 62:
						case 64:
						case 65:
							goto IL_0954;
						case 66:
							goto IL_0a43;
						case 67:
							goto IL_0a65;
						case 68:
						case 69:
							goto IL_0a8e;
						case 70:
							goto IL_0ab0;
						case 71:
						case 72:
							goto IL_0ad9;
						case 73:
							goto IL_0afb;
						case 74:
						case 75:
							goto IL_0b24;
						case 76:
							goto IL_0b46;
						case 77:
						case 78:
							goto IL_0b6f;
						case 79:
							goto IL_0b91;
						case 80:
						case 81:
							goto IL_0bc1;
						case 82:
							goto IL_0bd9;
						case 83:
						case 84:
							goto IL_0bf2;
						case 85:
							goto IL_0c14;
						case 86:
						case 87:
							goto IL_0c3d;
						case 88:
							goto IL_0c80;
						case 89:
							goto IL_0c97;
						case 91:
							goto IL_0cb4;
						case 92:
							goto IL_0ccf;
						case 93:
							goto IL_0d6a;
						case 94:
							goto IL_0d8c;
						case 95:
						case 96:
							goto IL_0db5;
						case 97:
							goto IL_0dd7;
						case 98:
						case 99:
							goto IL_0e00;
						case 100:
							goto IL_0e22;
						case 101:
						case 102:
							goto IL_0e4b;
						case 103:
							goto IL_0e6d;
						case 104:
						case 105:
							goto IL_0e96;
						case 106:
							goto IL_0eb8;
						case 107:
						case 108:
							goto IL_0ee1;
						case 109:
							goto IL_0f03;
						case 110:
						case 111:
							goto IL_0f33;
						case 112:
							goto IL_0f55;
						case 113:
						case 114:
							goto IL_0f7e;
						case 115:
							goto IL_0f95;
						case 117:
							goto IL_0fb2;
						case 118:
							goto IL_0fcd;
						case 119:
							goto IL_0fe4;
						case 120:
							goto IL_0ff2;
						case 121:
							goto IL_10ad;
						case 123:
							goto IL_10bf;
						case 122:
						case 124:
						case 125:
							goto IL_10ca;
						case 126:
							goto IL_11b9;
						case 127:
							goto IL_11db;
						case 128:
						case 129:
							goto IL_1204;
						case 130:
							goto IL_1229;
						case 131:
						case 132:
							goto IL_1255;
						case 133:
							goto IL_127a;
						case 134:
						case 135:
							goto IL_12ba;
						case 136:
							goto IL_12df;
						case 137:
						case 138:
							goto IL_130b;
						case 139:
							goto IL_1330;
						case 140:
						case 141:
							goto IL_135c;
						case 142:
							goto IL_1381;
						case 143:
						case 144:
							goto IL_13ad;
						case 145:
							goto IL_13d2;
						case 146:
						case 147:
							goto IL_1405;
						case 148:
							goto IL_142a;
						case 149:
						case 150:
							goto IL_1456;
						case 151:
							goto IL_1470;
						case 26:
						case 56:
						case 90:
						case 116:
						case 152:
						case 153:
							goto IL_148b;
						case 154:
							goto IL_14a1;
						case 155:
							goto IL_14b4;
						case 156:
							goto IL_14cb;
						case 157:
							goto IL_14dd;
						case 158:
							goto IL_14f2;
						case 159:
							goto IL_1505;
						case 160:
						case 162:
						case 163:
							goto IL_1521;
						case 164:
							goto IL_1544;
						case 165:
							goto IL_156a;
						case 166:
							goto IL_158d;
						case 167:
							goto IL_15b0;
						case 168:
							goto IL_15d3;
						case 169:
							goto IL_15f6;
						case 170:
							goto IL_15ff;
						case 171:
							goto IL_1623;
						case 172:
							goto IL_1645;
						case 173:
							goto IL_1669;
						case 174:
							goto IL_169a;
						case 175:
							goto IL_16be;
						case 176:
							goto IL_16ef;
						case 177:
							goto IL_1716;
						case 178:
							goto IL_173d;
						case 179:
							goto IL_1768;
						case 180:
						case 181:
							goto IL_179b;
						case 182:
							goto IL_17c2;
						case 183:
							goto IL_17e9;
						case 184:
							goto IL_1814;
						case 185:
						case 186:
							goto IL_1847;
						case 187:
							goto IL_186b;
						case 188:
							goto IL_1897;
						case 189:
							goto IL_18bb;
						case 190:
							goto IL_18e7;
						case 191:
							goto IL_191a;
						case 192:
							goto IL_1937;
						case 193:
							goto IL_1960;
						case 194:
							goto IL_1981;
						case 195:
							goto IL_19aa;
						case 196:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 161:
						case 197:
						case 198:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_1960:
					num2 = 193;
					GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
					goto IL_1981;
					IL_1981:
					num2 = 194;
					GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_19aa;
					IL_1937:
					num2 = 192;
					GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_1960;
					IL_19aa:
					num2 = 195;
					GridView1.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					break;
					IL_001c:
					num2 = 2;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.IT_CODE As ItCode,B.IT_NAME As Name,SUM(1) AS Qty,SUM(C.ITM_PCS) as Pcs,SUM(C.ITM_GWT) As Grwt,SUM(C.ITM_NWT) AS NetWt,B.IT_TYPE  from BAR_DETL AS C LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND C.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND C.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND C.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_0138;
					IL_0138:
					num2 = 3;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0159;
					}
					goto IL_0181;
					IL_0159:
					num2 = 4;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_0181;
					IL_0181:
					num2 = 6;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_01a2;
					}
					goto IL_01ca;
					IL_01a2:
					num2 = 7;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_01ca;
					IL_01ca:
					num2 = 9;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_01ec;
					}
					goto IL_0215;
					IL_01ec:
					num2 = 10;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_0215;
					IL_0215:
					num2 = 12;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_0237;
					}
					goto IL_0260;
					IL_0237:
					num2 = 13;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_0260;
					IL_0260:
					num2 = 15;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_0282;
					}
					goto IL_02ab;
					IL_0282:
					num2 = 16;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_02ab;
					IL_02ab:
					num2 = 18;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_02cd;
					}
					goto IL_02fd;
					IL_02cd:
					num2 = 19;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_02fd;
					IL_02fd:
					num2 = 21;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_031f;
					}
					goto IL_0348;
					IL_031f:
					num2 = 22;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_0348;
					IL_0348:
					num2 = 24;
					DC_Main.RsQry += "GROUP BY C.IT_CODE,B.IT_NAME,B.IT_TYPE ";
					goto IL_035f;
					IL_035f:
					num2 = 25;
					DC_Main.RsQry += "ORDER BY B.IT_NAME";
					goto IL_148b;
					IL_037c:
					num2 = 27;
					if (Operators.CompareString(RptType, "Out", false) == 0)
					{
						goto IL_0397;
					}
					goto IL_082c;
					IL_0397:
					num2 = 28;
					if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
					{
						goto IL_03b6;
					}
					goto IL_04c6;
					IL_03b6:
					num2 = 29;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As ItCode,B.IT_NAME As Name,SUM(1) AS Qty,SUM(A.ITM_PCS) as Pcs,SUM(A.ITM_GWT) As Grwt,SUM(A.ITM_NWT) AS NetWt,B.IT_TYPE  from MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE  A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_05e4;
					IL_04c6:
					num2 = 31;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As ItCode,B.IT_NAME As Name,SUM(1) AS Qty,SUM(A.ITM_PCS) as Pcs,SUM(A.ITM_GWT) As Grwt,SUM(A.ITM_NWT) AS NetWt,B.IT_TYPE  from MAIN_STOCK AS A  LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '-' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_05e4;
					IL_05e4:
					num2 = 33;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0606;
					}
					goto IL_062f;
					IL_0606:
					num2 = 34;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_062f;
					IL_062f:
					num2 = 36;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_0651;
					}
					goto IL_067a;
					IL_0651:
					num2 = 37;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_067a;
					IL_067a:
					num2 = 39;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_069c;
					}
					goto IL_06c5;
					IL_069c:
					num2 = 40;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_06c5;
					IL_06c5:
					num2 = 42;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_06e7;
					}
					goto IL_0710;
					IL_06e7:
					num2 = 43;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_0710;
					IL_0710:
					num2 = 45;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_0732;
					}
					goto IL_075b;
					IL_0732:
					num2 = 46;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_075b;
					IL_075b:
					num2 = 48;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_077d;
					}
					goto IL_07a6;
					IL_077d:
					num2 = 49;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_07a6;
					IL_07a6:
					num2 = 51;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_07c8;
					}
					goto IL_07f8;
					IL_07c8:
					num2 = 52;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_07f8;
					IL_07f8:
					num2 = 54;
					DC_Main.RsQry += "GROUP BY A.IT_CODE,B.IT_NAME,B.IT_TYPE ";
					goto IL_080f;
					IL_080f:
					num2 = 55;
					DC_Main.RsQry += "ORDER BY B.IT_NAME";
					goto IL_148b;
					IL_082c:
					num2 = 57;
					if ((Operators.CompareString(RptType, "Stock", false) == 0) | (Operators.CompareString(RptType, "Mrp", false) == 0))
					{
						goto IL_0857;
					}
					goto IL_0cb4;
					IL_0857:
					num2 = 58;
					if (chkEmpIsuLess.Checked)
					{
						goto IL_086e;
					}
					goto IL_0949;
					IL_086e:
					num2 = 59;
					DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA");
					goto IL_087c;
					IL_087c:
					num2 = 60;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SUM_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  IT_CODE,TAG_NO,VCH_SRNO,IT_TYPE,DATA_TYPE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE)  SELECT C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,0,1,C.VCH_DATE,  C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_TYPE,1,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE   from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO AND A.IT_CODE = C.IT_CODE)  LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(!chkEmpIsuLess.Checked, (object)"", (object)"AND C.EMP_ISU <> 'Y'")), (object)" "), (object)" GROUP BY C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_TYPE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE "), (object)" HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ORDER BY A.TAG_NO"));
					goto IL_0937;
					IL_0937:
					num2 = 61;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0954;
					IL_0949:
					num2 = 63;
					TagSumm_Insert();
					goto IL_0954;
					IL_0954:
					num2 = 65;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE As ItCode,B.IT_NAME As Name,SUM(ITM_QTY)AS Qty,SUM(A.ITM_PCS) AS Pcs,SUM(A.ITM_GWT) AS Grwt,SUM(A.ITM_NWT) AS NetWt,B.IT_TYPE  from TAG_SUM_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_0a43;
					IL_0a43:
					num2 = 66;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0a65;
					}
					goto IL_0a8e;
					IL_0a65:
					num2 = 67;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_0a8e;
					IL_0a8e:
					num2 = 69;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_0ab0;
					}
					goto IL_0ad9;
					IL_0ab0:
					num2 = 70;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_0ad9;
					IL_0ad9:
					num2 = 72;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_0afb;
					}
					goto IL_0b24;
					IL_0afb:
					num2 = 73;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_0b24;
					IL_0b24:
					num2 = 75;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_0b46;
					}
					goto IL_0b6f;
					IL_0b46:
					num2 = 76;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_0b6f;
					IL_0b6f:
					num2 = 78;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_0b91;
					}
					goto IL_0bc1;
					IL_0b91:
					num2 = 79;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_0bc1;
					IL_0bc1:
					num2 = 81;
					if (Operators.CompareString(RptType, "Mrp", false) == 0)
					{
						goto IL_0bd9;
					}
					goto IL_0bf2;
					IL_0bd9:
					num2 = 82;
					DC_Main.RsQry += "AND A.ITM_MRP <> 0";
					goto IL_0bf2;
					IL_0bf2:
					num2 = 84;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_0c14;
					}
					goto IL_0c3d;
					IL_0c14:
					num2 = 85;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_0c3d;
					IL_0c3d:
					num2 = 87;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO IN (SELECT TAG_NO FROM MAIN_STOCK AS C WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TAG_NO <> 'N' GROUP BY C.TAG_NO HAVING SUM(CASE WHEN C.ITM_SIGN = '+' THEN C.VCH_SRNO ELSE -C.VCH_SRNO END) > 0)";
					goto IL_0c80;
					IL_0c80:
					num2 = 88;
					DC_Main.RsQry += " GROUP BY A.IT_CODE,B.IT_NAME,B.IT_TYPE ";
					goto IL_0c97;
					IL_0c97:
					num2 = 89;
					DC_Main.RsQry += " ORDER BY B.IT_NAME";
					goto IL_148b;
					IL_0cb4:
					num2 = 91;
					if (Operators.CompareString(RptType, "Apr", false) == 0)
					{
						goto IL_0ccf;
					}
					goto IL_0fb2;
					IL_0ccf:
					num2 = 92;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.IT_CODE As ItCode,B.IT_NAME As Name,SUM(1) AS Qty,SUM(C.ITM_PCS) as Pcs,SUM(C.ITM_GWT) As Grwt,SUM(C.ITM_NWT) AS NetWt,B.IT_TYPE  from ((APR_DETL AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N' "));
					goto IL_0d6a;
					IL_0d6a:
					num2 = 93;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_0d8c;
					}
					goto IL_0db5;
					IL_0d8c:
					num2 = 94;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_0db5;
					IL_0db5:
					num2 = 96;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_0dd7;
					}
					goto IL_0e00;
					IL_0dd7:
					num2 = 97;
					DC_Main.RsQry = DC_Main.RsQry + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_0e00;
					IL_0e00:
					num2 = 99;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_0e22;
					}
					goto IL_0e4b;
					IL_0e22:
					num2 = 100;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_0e4b;
					IL_0e4b:
					num2 = 102;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_0e6d;
					}
					goto IL_0e96;
					IL_0e6d:
					num2 = 103;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_0e96;
					IL_0e96:
					num2 = 105;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_0eb8;
					}
					goto IL_0ee1;
					IL_0eb8:
					num2 = 106;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_0ee1;
					IL_0ee1:
					num2 = 108;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_0f03;
					}
					goto IL_0f33;
					IL_0f03:
					num2 = 109;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_0f33;
					IL_0f33:
					num2 = 111;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_0f55;
					}
					goto IL_0f7e;
					IL_0f55:
					num2 = 112;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_0f7e;
					IL_0f7e:
					num2 = 114;
					DC_Main.RsQry += " GROUP BY C.IT_CODE,B.IT_NAME,B.IT_TYPE ";
					goto IL_0f95;
					IL_0f95:
					num2 = 115;
					DC_Main.RsQry += " ORDER BY B.IT_NAME";
					goto IL_148b;
					IL_0fb2:
					num2 = 117;
					if (Operators.CompareString(RptType, "All", false) == 0)
					{
						goto IL_0fcd;
					}
					goto IL_148b;
					IL_0fcd:
					num2 = 118;
					if (chkEmpIsuLess.Checked)
					{
						goto IL_0fe4;
					}
					goto IL_10bf;
					IL_0fe4:
					num2 = 119;
					DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA");
					goto IL_0ff2;
					IL_0ff2:
					num2 = 120;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SUM_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  IT_CODE,TAG_NO,VCH_SRNO,IT_TYPE,DATA_TYPE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE)  SELECT C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,0,1,C.VCH_DATE,  C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_TYPE,1,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE   from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO AND A.IT_CODE = C.IT_CODE)  LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(!chkEmpIsuLess.Checked, (object)"", (object)"AND C.EMP_ISU <> 'Y'")), (object)" "), (object)" GROUP BY C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_TYPE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE "), (object)" HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ORDER BY A.TAG_NO"));
					goto IL_10ad;
					IL_10ad:
					num2 = 121;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_10ca;
					IL_10bf:
					num2 = 123;
					TagSumm_Insert();
					goto IL_10ca;
					IL_10ca:
					num2 = 125;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.PR_CODE As ItCode,C.PR_NAME As Name,SUM(ITM_QTY)AS Qty,SUM(A.ITM_PCS) AS Pcs,SUM(A.ITM_GWT) AS Grwt,SUM(A.ITM_NWT) AS NetWt,B.IT_TYPE  from (TAG_SUM_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE)LEFT JOIN PRODUCT_MAST AS C ON A.CO_CODE = C.CO_CODE AND B.PR_CODE = C.PR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "));
					goto IL_11b9;
					IL_11b9:
					num2 = 126;
					if (Operators.CompareString(tBookCode.Text, "", false) != 0)
					{
						goto IL_11db;
					}
					goto IL_1204;
					IL_11db:
					num2 = 127;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
					goto IL_1204;
					IL_1204:
					num2 = 129;
					if (Operators.CompareString(cboSize.Text, "", false) != 0)
					{
						goto IL_1229;
					}
					goto IL_1255;
					IL_1229:
					num2 = 130;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_SIZE = '" + cboSize.Text + "'";
					goto IL_1255;
					IL_1255:
					num2 = 132;
					if (Operators.CompareString(tTagNo.Text, "", false) == 0)
					{
						goto IL_127a;
					}
					goto IL_12ba;
					IL_127a:
					num2 = 133;
					DC_Main.RsQry = DC_Main.RsQry + "And A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
					goto IL_12ba;
					IL_12ba:
					num2 = 135;
					if (Operators.CompareString(tItCode.Text, "", false) != 0)
					{
						goto IL_12df;
					}
					goto IL_130b;
					IL_12df:
					num2 = 136;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
					goto IL_130b;
					IL_130b:
					num2 = 138;
					if (Operators.CompareString(tPrCode.Text, "", false) != 0)
					{
						goto IL_1330;
					}
					goto IL_135c;
					IL_1330:
					num2 = 139;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
					goto IL_135c;
					IL_135c:
					num2 = 141;
					if (Operators.CompareString(tGrCode.Text, "", false) != 0)
					{
						goto IL_1381;
					}
					goto IL_13ad;
					IL_1381:
					num2 = 142;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
					goto IL_13ad;
					IL_13ad:
					num2 = 144;
					if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
					{
						goto IL_13d2;
					}
					goto IL_1405;
					IL_13d2:
					num2 = 145;
					DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
					goto IL_1405;
					IL_1405:
					num2 = 147;
					if (Operators.CompareString(tTagNo.Text, "", false) != 0)
					{
						goto IL_142a;
					}
					goto IL_1456;
					IL_142a:
					num2 = 148;
					DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
					goto IL_1456;
					IL_1456:
					num2 = 150;
					DC_Main.RsQry += " GROUP BY B.PR_CODE,C.PR_NAME,B.IT_TYPE ";
					goto IL_1470;
					IL_1470:
					num2 = 151;
					DC_Main.RsQry += " ORDER BY C.PR_NAME";
					goto IL_148b;
					IL_148b:
					num2 = 153;
					RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_14a1;
					IL_14a1:
					num2 = 154;
					DGV.DataSource = null;
					goto IL_14b4;
					IL_14b4:
					num2 = 155;
					((CollectionBase)(object)((ColumnView)GridView1).Columns).Clear();
					goto IL_14cb;
					IL_14cb:
					num2 = 156;
					dataView = new DataView(RsStkSum);
					goto IL_14dd;
					IL_14dd:
					num2 = 157;
					if (dataView.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_14f2;
					IL_14f2:
					num2 = 158;
					DGV.DataSource = dataView;
					goto IL_1505;
					IL_1505:
					num2 = 159;
					DGV.ForceInitialize();
					goto IL_1521;
					IL_1521:
					num2 = 163;
					((ColumnView)GridView1).Columns["ItCode"].Width = 90;
					goto IL_1544;
					IL_1544:
					num2 = 164;
					((ColumnView)GridView1).Columns["Name"].Width = 250;
					goto IL_156a;
					IL_156a:
					num2 = 165;
					((ColumnView)GridView1).Columns["Qty"].Width = 70;
					goto IL_158d;
					IL_158d:
					num2 = 166;
					((ColumnView)GridView1).Columns["Pcs"].Width = 70;
					goto IL_15b0;
					IL_15b0:
					num2 = 167;
					((ColumnView)GridView1).Columns["Grwt"].Width = 100;
					goto IL_15d3;
					IL_15d3:
					num2 = 168;
					((ColumnView)GridView1).Columns["NetWt"].Width = 100;
					goto IL_15f6;
					IL_15f6:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_15ff;
					IL_15ff:
					num2 = 170;
					if (((ColumnView)GridView1).Columns["IT_TYPE"] != null)
					{
						goto IL_1623;
					}
					goto IL_1645;
					IL_1623:
					num2 = 171;
					((ColumnView)GridView1).Columns["IT_TYPE"].Visible = false;
					goto IL_1645;
					IL_1645:
					num2 = 172;
					if (((ColumnView)GridView1).Columns["Qty"] != null)
					{
						goto IL_1669;
					}
					goto IL_169a;
					IL_1669:
					num2 = 173;
					((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");
					goto IL_169a;
					IL_169a:
					num2 = 174;
					if (((ColumnView)GridView1).Columns["Pcs"] != null)
					{
						goto IL_16be;
					}
					goto IL_16ef;
					IL_16be:
					num2 = 175;
					((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
					goto IL_16ef;
					IL_16ef:
					num2 = 176;
					if (((ColumnView)GridView1).Columns["Grwt"] != null)
					{
						goto IL_1716;
					}
					goto IL_179b;
					IL_1716:
					num2 = 177;
					((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_173d;
					IL_173d:
					num2 = 178;
					((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1768;
					IL_1768:
					num2 = 179;
					((ColumnView)GridView1).Columns["Grwt"].Summary.Add((SummaryItemType)0, "Grwt", "{0}");
					goto IL_179b;
					IL_179b:
					num2 = 181;
					if (((ColumnView)GridView1).Columns["NetWt"] != null)
					{
						goto IL_17c2;
					}
					goto IL_1847;
					IL_17c2:
					num2 = 182;
					((ColumnView)GridView1).Columns["NetWt"].DisplayFormat.FormatType = (FormatType)1;
					goto IL_17e9;
					IL_17e9:
					num2 = 183;
					((ColumnView)GridView1).Columns["NetWt"].DisplayFormat.FormatString = "{0:n3}";
					goto IL_1814;
					IL_1814:
					num2 = 184;
					((ColumnView)GridView1).Columns["NetWt"].Summary.Add((SummaryItemType)0, "NetWt", "{0}");
					goto IL_1847;
					IL_1847:
					num2 = 186;
					if (((ColumnView)GridView1).Columns["Grwt"] != null)
					{
						goto IL_186b;
					}
					goto IL_1897;
					IL_186b:
					num2 = 187;
					((AppearanceObject)((ColumnView)GridView1).Columns["Grwt"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_1897;
					IL_1897:
					num2 = 188;
					if (((ColumnView)GridView1).Columns["NetWt"] != null)
					{
						goto IL_18bb;
					}
					goto IL_18e7;
					IL_18bb:
					num2 = 189;
					((AppearanceObject)((ColumnView)GridView1).Columns["NetWt"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					goto IL_18e7;
					IL_18e7:
					num2 = 190;
					if (!((Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0) & (DC_Main.ScreenHight > 1.0)))
					{
						goto end_IL_0001_3;
					}
					goto IL_191a;
					IL_191a:
					num2 = 191;
					num5 = checked((int)Math.Ceiling(9.0 * DC_Main.ScreenHight));
					goto IL_1937;
					end_IL_0001_2:
					break;
				}
				num2 = 196;
				GridView1.RowHeight = checked((int)Math.Round(22.0 * DC_Main.ScreenHight));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7465;
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

	private void TagSumm_Insert()
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA");
		DC_Main.RsQry = "INSERT INTO TAG_SUM_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  IT_CODE,TAG_NO,VCH_SRNO,IT_TYPE,DATA_TYPE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE)  SELECT C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,0,1,C.VCH_DATE,  C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_TYPE,1,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE   from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO AND A.IT_CODE = C.IT_CODE)  LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  GROUP BY C.CO_CODE,C.LC_CODE,C.CO_YEAR,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.IT_CODE,A.TAG_NO,C.VCH_SRNO,B.IT_TYPE,C.DATA_TYPE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.ITM_FINE  HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ORDER BY A.TAG_NO";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
	}

	private void Stk_Insert()
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		GridView gridView = GridView1;
		((BaseView)gridView).PostEditor();
		((ColumnView)gridView).UpdateCurrentRow();
		checked
		{
			int num = gridView.RowCount - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
				if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,DESIGN_NO,ITM_SIZE,TBL_CODE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), dataRow["Book"]), (object)"','"), dataRow["VchNo"]), (object)"',"), (object)DC_Main.X), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(dataRow["VchDate"]), "MM/dd/yyyy")), (object)"','"), dataRow["VchTyp"]), (object)"','I','"), dataRow["VchTyp"]), (object)"', "), (object)" '"), dataRow["ItCode"]), (object)"','"), dataRow["TagNo"]), (object)"',"), dataRow["TagId"]), (object)",'+','"), dataRow["Design"]), (object)"','"), dataRow["Size"]), (object)"','"), dataRow["Counter"]), (object)"',1,"), dataRow["Pcs"]), (object)","), dataRow["Grwt"]), (object)","), dataRow["NetWt"]), (object)",0,'A')"));
				}
				else if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,DESIGN_NO,ITM_SIZE,TBL_CODE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,DATA_TYPE,WX_WT,MM_WT,SN_WT,OTH_AMT)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), dataRow["Book"]), (object)"','"), dataRow["VchNo"]), (object)"',"), (object)DC_Main.X), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(dataRow["VchDate"]), "MM/dd/yyyy")), (object)"','"), dataRow["VchTyp"]), (object)"','I','"), dataRow["VchTyp"]), (object)"', "), (object)" '"), dataRow["ItCode"]), (object)"','"), dataRow["TagNo"]), (object)"',"), dataRow["TagId"]), (object)",'+','"), dataRow["Design"]), (object)"','"), dataRow["Size"]), (object)"','"), dataRow["Counter"]), (object)"',1,"), dataRow["Pcs"]), (object)","), dataRow["Grwt"]), (object)","), dataRow["NetWt"]), (object)",0,'A',");
					string columnName;
					DataRow dataRow2;
					object Value = RuntimeHelpers.GetObjectValue((dataRow2 = dataRow)[columnName = Col4 + "wt"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow2[columnName] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow2 = dataRow)[columnName = Col2 + "wt"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow2[columnName] = RuntimeHelpers.GetObjectValue(Value);
					Value = RuntimeHelpers.GetObjectValue((dataRow2 = dataRow)[columnName = Col3 + "wt"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow2[columnName] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)(num3 + num4)), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow2 = dataRow)[columnName = Col4 + "wt"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow2[columnName] = RuntimeHelpers.GetObjectValue(Value);
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num5), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow2 = dataRow)["OthAmt"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow2["OthAmt"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num6), (object)")"));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,DESIGN_NO,ITM_SIZE,TBL_CODE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), dataRow["Book"]), (object)"','"), dataRow["VchNo"]), (object)"',"), (object)DC_Main.X), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(dataRow["VchDate"]), "MM/dd/yyyy")), (object)"','"), dataRow["VchTyp"]), (object)"','I','"), dataRow["BookName"]), (object)"', "), (object)" '"), dataRow["ItCode"]), (object)"','"), dataRow["TagNo"]), (object)"',"), dataRow["TagId"]), (object)",'+','"), dataRow["Design"]), (object)"','"), dataRow["Size"]), (object)"','"), dataRow["Counter"]), (object)"',1,"), dataRow["Pcs"]), (object)","), dataRow["Grwt"]), (object)","), dataRow["NetWt"]), (object)",0,'A')"));
				}
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			gridView = null;
			DC_Main.RsQry = "Select * FROM TAG_STOCK_PRINT";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Invalid comparison between Unknown and I4
		checked
		{
			if (cboRptType.SelectedIndex == 1)
			{
				DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				GridView gridView = GridView1;
				((BaseView)gridView).PostEditor();
				((ColumnView)gridView).UpdateCurrentRow();
				int num = gridView.RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,IT_CODE,IT_DESC,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,VCH_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), dataRow[0]), (object)"','"), dataRow[1]), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[2]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[3]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[4]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[5]))), (object)",'"), dataRow[6]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				gridView = null;
				DC_Main.RsQry = "SELECT * FROM TAG_STOCK_PRINT";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				string text = "Tag Wise Stock Summary As on Date ";
				string text2 = "TagStkRpt";
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagItmSumm.RPT";
				}
				CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "TagStkRpt";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
					Cr.Action = -1;
				}
				return;
			}
			Stk_Insert();
			string text3 = "";
			string text4 = "";
			if (Operators.CompareString(CurRpt, "Tag Detail", false) == 0)
			{
				text3 = "Tag Wise Stock As on Date ";
				text4 = "TagStkRpt";
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagStkIdtlRpt.RPT";
				}
				else
				{
					DC_Main.RptName = "TagStkIdtlRpt";
				}
				if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
				else
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
			}
			else if (Operators.CompareString(CurRpt, "JdtTag Dtl", false) == 0)
			{
				text3 = "Jadtar Tag Wise Stock As on Date ";
				text4 = "JadtarTagStkRpt";
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JdterSkt.RPT";
				}
				else
				{
					DC_Main.RptName = "JdterSkt";
				}
				if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
				else
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
			}
			else
			{
				text3 = "Tag Wise Stock As on Date ";
				text4 = ((Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0) ? "TagStkRpt" : ((unchecked((int)Interaction.MsgBox((object)"'Yes' Then Wt and Qry Or 'No' then Dm and Ston Summ Report?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6) ? "TagStkRptDmSum" : "TagStkRpt"));
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text4 + ".RPT";
				}
				else
				{
					DC_Main.RptName = text4;
				}
				if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
				else
				{
					CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				}
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text3 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'" + text3 + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
				{
					Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text3 + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					Cr[(short)0] = "RptTitel = '" + text3 + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				Cr.Action = -1;
			}
		}
	}

	private void BtnSumm_Click(object sender, EventArgs e)
	{
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Invalid comparison between Unknown and I4
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Invalid comparison between Unknown and I4
		string text;
		checked
		{
			string text2;
			if (cboRptType.SelectedIndex == 1)
			{
				DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				GridView gridView = GridView1;
				((BaseView)gridView).PostEditor();
				((ColumnView)gridView).UpdateCurrentRow();
				int num = gridView.RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,IT_CODE,IT_DESC,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,VCH_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), dataRow[0]), (object)"','"), dataRow[1]), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[2]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[3]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[4]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataRow[5]))), (object)",'"), dataRow[6]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				gridView = null;
				DC_Main.RsQry = "SELECT * FROM TAG_STOCK_PRINT";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text = "Tag Wise Stock Summary As on Date ";
				text2 = "TagStkRpt";
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagItmSumm.RPT";
				}
				CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "TagItmSumm";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
					Cr.Action = -1;
				}
				return;
			}
			Stk_Insert();
			text = "Tag Wise Stock Summary As on Date ";
			text2 = "TagStkRpt";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Product Wise Group Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagStkSummRpt.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagStkItemSumRpt.RPT";
			}
		}
		else if ((int)Interaction.MsgBox((object)"Product Wise Group Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RptName = "TagStkSummRpt";
		}
		else
		{
			DC_Main.RptName = "TagStkItemSumRpt";
		}
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
		{
			CurFormula = "{TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		else
		{
			CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " " + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			Cr.Action = -1;
		}
	}

	private void BtnAll_Click(object sender, EventArgs e)
	{
		IdtlWithName = "N";
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (cboRptType.SelectedIndex == 1)
		{
			Itm_Summ("All");
		}
		else
		{
			Tag_Summ("All");
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		if (cboRptType.SelectedIndex == 1 || Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0 || (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 && Operators.CompareString(((ColumnView)GridView1).GetFocusedRowCellValue("CoCode").ToString() ?? "", DC_Main.MCo_code, false) != 0))
		{
			return;
		}
		DC_Main.RsQry = string.Concat("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '" + ((ColumnView)GridView1).GetFocusedRowCellValue("Book").ToString(), "' ");
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
		DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("VchNo").ToString() ?? "";
		if (((Control)pnlDiff).Visible)
		{
			DC_Main.MsTagVchSrnoUpdate = true;
		}
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void GridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		if (((Operators.CompareString(CurRpt, "Tag Detail", false) != 0) & (Operators.CompareString(CurRpt, "JdtTag Dtl", false) != 0)) || ((ColumnView)GridView1).GetFocusedDataSourceRowIndex() < 0 || ((ColumnView)GridView1).GetFocusedRowCellValue("TagId") == null)
		{
			return;
		}
		DC_Main.MsImageNo = ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString() + "_" + ((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString();
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			Image image;
			using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
			{
				image = Image.FromStream(stream);
			}
			PicImage.Image = image;
		}
		else if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
		{
			try
			{
				string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString()))) ?? "";
				DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						PicImage.Image = null;
						ProjectData.ClearProjectError();
						return;
					}
					object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
					byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
					object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
					PicImage.Image = (Image)objectValue;
				}
				ProjectData.ClearProjectError();
			}
		}
		DGV_IDTL_CLEAR();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.TAG_NO = '"), (object)((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString()), (object)"' AND A.VCH_SRNO = "), (object)Conversion.Val(((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString())), (object)" "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		checked
		{
			while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
			{
				DataGridViewX dGV_IDTL = DGV_IDTL;
				((DataGridView)dGV_IDTL).Rows.Add();
				((DataGridView)dGV_IDTL)[0, DC_Main.i].Value = DC_Main.i + 1;
				((DataGridView)dGV_IDTL)[1, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
				((DataGridView)dGV_IDTL)[2, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
				((DataGridView)dGV_IDTL)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
				((DataGridView)dGV_IDTL)[4, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
				((DataGridView)dGV_IDTL)[13, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
				((DataGridView)dGV_IDTL)[5, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
				((DataGridView)dGV_IDTL)[6, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
				((DataGridView)dGV_IDTL)[7, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
				((DataGridView)dGV_IDTL)[8, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
				((DataGridView)dGV_IDTL)[9, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
				((DataGridView)dGV_IDTL)[10, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
				((DataGridView)dGV_IDTL)[11, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
				((DataGridView)dGV_IDTL)[12, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
				((DataGridView)dGV_IDTL)[14, DC_Main.i].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
				((DataGridView)dGV_IDTL)[15, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
				DC_Main.i++;
				dGV_IDTL = null;
			}
		}
	}

	private void DGV_IDTL_CLEAR()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		((DataGridView)DGV_IDTL).DataSource = null;
		((DataGridView)DGV_IDTL).ClearSelection();
		((DataGridView)DGV_IDTL).Rows.Clear();
		((DataGridView)DGV_IDTL).Columns.Clear();
		((Control)DGV_IDTL).Refresh();
		((DataGridView)DGV_IDTL).MultiSelect = false;
		((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_IDTL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_IDTL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_IDTL).AutoGenerateColumns = false;
		((DataGridView)DGV_IDTL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_IDTL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "ItCode");
			((DataGridView)DGV_IDTL).Columns[1].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "ItName");
			((DataGridView)DGV_IDTL).Columns[2].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "Pcs");
			((DataGridView)DGV_IDTL).Columns[3].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns.Add("", "Weight");
			((DataGridView)DGV_IDTL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_IDTL).Columns.Add("", "Con%");
			((DataGridView)DGV_IDTL).Columns[5].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_IDTL).Columns.Add("", "P/W");
			((DataGridView)DGV_IDTL).Columns[6].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "Rate");
			((DataGridView)DGV_IDTL).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "ItAmt");
			((DataGridView)DGV_IDTL).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "LbrRate");
			((DataGridView)DGV_IDTL).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "LbrAmt");
			((DataGridView)DGV_IDTL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "NetAmt");
			((DataGridView)DGV_IDTL).Columns[11].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "ConWt");
			((DataGridView)DGV_IDTL).Columns[12].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "KrWt");
			((DataGridView)DGV_IDTL).Columns[13].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "KrConWt");
			((DataGridView)DGV_IDTL).Columns[14].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "ItType");
			((DataGridView)DGV_IDTL).Columns[15].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "RowSrNo");
			((DataGridView)DGV_IDTL).Columns[16].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
		}
	}

	private void PicImage_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicImage.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void PicZoom_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = null;
		((Control)PicZoom).Dock = (DockStyle)0;
		((Control)PicZoom).Visible = false;
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
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
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
					tGrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
		}
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
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
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
					tPrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tPrCode).SelectAll();
			}
		}
		else
		{
			tPrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_NAME"], (object)""));
		}
	}

	private void tPrCode_LostFocus(object sender, EventArgs e)
	{
		if (Operators.CompareString(tPrCode.Text, "", false) == 0)
		{
			tPrName.Text = "";
		}
	}

	private void tGrCode_LostFocus(object sender, EventArgs e)
	{
		if (Operators.CompareString(tGrCode.Text, "", false) == 0)
		{
			tGrName.Text = "";
		}
	}

	private void chkDoubelTag_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkDoubelTag_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkZeroId.Checked = false;
		Dgv_Adj_Feel();
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)chkDuplicatTag).Visible = true;
		((Control)chkTagLessNotStk).Visible = true;
		((Control)chkSlWtDiff).Visible = true;
		((Control)chkSlWtDiff).Visible = true;
		((Control)pnlDiff).Visible = true;
		((Control)chkItDiff).Visible = true;
		((Control)chkTagPcsDiff).Visible = true;
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
				if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tLcCode.Text = DC_Main.ColValue[0];
					((TextBoxBase)tLcCode).SelectAll();
				}
			}
			else
			{
				DGV_CLEAR();
			}
		}
		else
		{
			DGV_CLEAR();
		}
	}

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.IT_NAME As ItNameL,A.IT_CODE As ItCodeL FROM ITEM_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.IT_CODE";
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
					tItCode.Text = DC_Main.ColValue[1];
					tItName.Text = DC_Main.ColValue[0];
				}
				((Control)tItCode).Focus();
			}
		}
		else
		{
			tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
		}
	}

	private void CboRptType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboRptType.SelectedIndex == 1)
		{
			BtnAll.Text = "Product Stk";
		}
		else
		{
			BtnAll.Text = "&All Tag";
		}
	}

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tBookCode.Text, "", false) == 0)
		{
			return;
		}
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
			tBookCode.Text = "";
		}
	}

	private void pnlDiff_DoubleClick(object sender, EventArgs e)
	{
		((Control)pnlDiff).Visible = false;
	}

	private void lblX_Click(object sender, EventArgs e)
	{
		((Control)pnlDiff).Visible = false;
	}

	private void BtnAdjust_Click(object sender, EventArgs e)
	{
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (chkTagLessNotStk.Checked)
			{
				string text = "";
				GridView gridView = GridView1;
				((BaseView)gridView).PostEditor();
				((ColumnView)gridView).UpdateCurrentRow();
				int num = gridView.RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.MAIN_BOOK,B.BOOK_TBL_NAME FROM BOOK_DATA AS B WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_BOOK = '"), dataRow[1]), (object)"' AND B.BOOK_TBL_NAME <> ''"));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_TBL_NAME"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TAG_NO,VCH_SRNO FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), dataRow[5]), (object)"' GROUP BY TAG_NO,VCH_SRNO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0"));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						switch (text)
						{
						case "SL_DATA":
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_DETL SET VCH_SRNO = ", DC_Main.Tbl.Rows[0]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), dataRow[1]), (object)"' AND VCH_NO = '"), dataRow[3]), (object)"' AND TAG_NO = '"), dataRow[5]), (object)"' "));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							break;
						case "KR_DATA":
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE KR_DETL SET VCH_SRNO = ", DC_Main.Tbl.Rows[0]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), dataRow[1]), (object)"' AND VCH_NO = '"), dataRow[3]), (object)"' AND TAG_NO = '"), dataRow[5]), (object)"' "));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							break;
						case "BAR_CAN_DATA":
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BAR_CAN_DETL SET VCH_SRNO = ", DC_Main.Tbl.Rows[0]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), dataRow[1]), (object)"' AND VCH_NO = '"), dataRow[3]), (object)"' AND TAG_NO = '"), dataRow[5]), (object)"' "));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							break;
						case "RATE_CUT_DATA":
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE RATE_CUT_ISU SET VCH_SRNO = ", DC_Main.Tbl.Rows[0]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), dataRow[1]), (object)"' AND VCH_NO = '"), dataRow[3]), (object)"' AND TAG_NO = '"), dataRow[5]), (object)"' "));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							break;
						case "LBR_DATA":
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE LBR_ISU_DETL SET VCH_SRNO = ", DC_Main.Tbl.Rows[0]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), dataRow[1]), (object)"' AND VCH_NO = '"), dataRow[3]), (object)"' AND TAG_NO = '"), dataRow[5]), (object)"' "));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							break;
						case "APR_DATA":
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE APR_DETL SET VCH_SRNO = ", DC_Main.Tbl.Rows[0]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), dataRow[1]), (object)"' AND VCH_NO = '"), dataRow[3]), (object)"' AND TAG_NO = '"), dataRow[5]), (object)"' "));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							break;
						}
					}
					DC_Main.X++;
				}
				gridView = null;
				Interaction.MsgBox((object)"Tag Adjust Ok Please First Data Refresh And Check......", (MsgBoxStyle)0, (object)null);
			}
			if (!chkTagNotInBarDetl.Checked)
			{
				return;
			}
			string text2 = "";
			GridView gridView2 = GridView1;
			((BaseView)gridView2).PostEditor();
			((ColumnView)gridView2).UpdateCurrentRow();
			int num2 = gridView2.RowCount - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num2)
			{
				DataRow dataRow2 = ((ColumnView)gridView2).GetDataRow(DC_Main.X);
				string text3 = Conversions.ToString(dataRow2[3]);
				string text4 = Conversions.ToString(dataRow2[1]);
				string text5 = Conversions.ToString(dataRow2[2]);
				string text6 = Conversions.ToString(dataRow2[5]);
				DC_Main.RsQry = "SELECT B.MAIN_BOOK,B.BOOK_TBL_NAME FROM BOOK_DATA AS B WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_BOOK = '" + text4 + "' AND B.BOOK_TBL_NAME <> ''";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_TBL_NAME"], (object)""));
				}
				switch (text2)
				{
				case "BAR_CAN_DATA":
					DC_Main.RsQry = "DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + text4 + "' AND VCH_NO = '" + text3 + "' AND TAG_NO = '" + text6 + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					break;
				case "RATE_CUT_DATA":
					DC_Main.RsQry = "UPDATE RATE_CUT_ISU SET TAG_NO = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + text4 + "' AND VCH_NO = '" + text3 + "' AND TAG_NO = '" + text6 + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					break;
				case "LBR_DATA":
					DC_Main.RsQry = "UPDATE LBR_ISU_DETL SET TAG_NO = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + text4 + "' AND VCH_NO = '" + text3 + "' AND TAG_NO = '" + text6 + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					break;
				case "SL_DATA":
					DC_Main.RsQry = "UPDATE SL_DETL SET TAG_NO = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + text4 + "' AND VCH_NO = '" + text3 + "' AND TAG_NO = '" + text6 + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					break;
				case "APR_DATA":
					DC_Main.RsQry = "UPDATE APR_DETL SET TAG_NO = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + text4 + "' AND VCH_NO = '" + text3 + "' AND TAG_NO = '" + text6 + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					break;
				}
				DC_Main.X++;
			}
			gridView2 = null;
			Interaction.MsgBox((object)"Tag Adjust Ok Please First Data Refresh And Check......", (MsgBoxStyle)0, (object)null);
		}
	}

	private void chkslandStk_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
	}

	private void ChkTagLessNotStk_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkTagLessNotStk_Click(object sender, EventArgs e)
	{
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
		DC_Main.RsQry = "Select ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,A.CO_BOOK,B.TAG_NO) AS SrNo,A.CO_BOOK As Book,C.BOOK_NAME As BookName,A.VCH_NO As VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,B.TAG_NO As Tag,C.MAIN_BOOK As MainBook,A.ITM_PCS As Pcs,A.ITM_GWT FROM (MAIN_STOCK As A LEFT JOIN BAR_DETL As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.TAG_NO = B.TAG_NO And A.VCH_SRNO = B.VCH_SRNO)  LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' AND A.ITM_SIGN = '-' AND B.TAG_NO IS NULL ORDER BY A.VCH_DATE,A.CO_BOOK,B.TAG_NO ";
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_CLEAR();
		DataView dataView = new DataView(RsStkSum);
		if (dataView.Count > 0)
		{
			DGV.DataSource = dataView;
			DGV.ForceInitialize();
			if (((ColumnView)GridView1).Columns["Pcs"] != null)
			{
				((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
			}
		}
	}

	private void ChkTagNotInBarDetl_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkTagNotInBarDetl_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
		DC_Main.RsQry = "Select ROW_NUMBER() OVER (ORDER BY A.CO_BOOK,B.TAG_NO) AS SrNo, A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.VCH_NO As VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,B.TAG_NO As BarDtlTag,A.ITM_PCS As Pcs,A.ITM_GWT As Gwt FROM MAIN_STOCK As A LEFT JOIN BAR_DETL As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE  And A.TAG_NO = B.TAG_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' AND B.TAG_NO IS NULL ORDER BY A.CO_BOOK,B.TAG_NO";
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_CLEAR();
		DataView dataView = new DataView(RsStkSum);
		if (dataView.Count > 0)
		{
			DGV.DataSource = dataView;
			DGV.ForceInitialize();
			if (((ColumnView)GridView1).Columns["Pcs"] != null)
			{
				((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
			}
		}
	}

	private void ChkItDiff_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkItDiff_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
		DC_Main.RsQry = "SELECT A.CO_BOOK As InBook,B.CO_BOOK AS Book,A.VCH_NO As StkVchNo,B.VCH_NO As VchNo,A.TAG_NO As InTag,B.TAG_NO As SlTag,A.IT_CODE As InItCode ,B.IT_CODE As SlItCode  FROM  MAIN_STOCK AS A LEFT JOIN MAIN_STOCK AS B ON A.CO_CODE =B.CO_CODE And A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_SIGN = '+' AND B.ITM_SIGN = '-' AND A.IT_CODE <> B.IT_CODE AND A.TAG_NO <> 'N'";
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_CLEAR();
		DataView dataView = new DataView(RsStkSum);
		if (dataView.Count > 0)
		{
			DGV.DataSource = dataView;
			DGV.ForceInitialize();
			if (((ColumnView)GridView1).Columns["Pcs"] != null)
			{
				((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
			}
		}
	}

	private void ChkSlWtDiff_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkSlWtDiff_Click(object sender, EventArgs e)
	{
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
		checked
		{
			if (Operators.CompareString(RptType, "Out", false) == 0)
			{
				RptType = "";
				string text = "";
				Application.DoEvents();
				GridView gridView = GridView1;
				((BaseView)gridView).PostEditor();
				((ColumnView)gridView).UpdateCurrentRow();
				int num = gridView.RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
					text = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(text + "'"), dataRow[4]), (object)"',"));
					DC_Main.X++;
				}
				gridView = null;
				if (Operators.CompareString(text, "", false) != 0)
				{
					text = Strings.Mid(text, 1, Strings.Len(text) - 1);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TAG_NO StkTag,A.ITM_GWT As StkGwt,B.ITM_GWT As SlGwt,FORMAT((A.ITM_GWT- B.ITM_GWT),'0.000') As GDiff,A.ITM_NWT As StkNwt,B.ITM_NWT As SlNwt,format((A.ITM_NWT- B.ITM_NWT),'0.000') As NDiff,B.VCH_TYPE As VchTyp,B.VCH_NO As VchNo,B.CO_BOOK As Book  FROM  MAIN_STOCK AS B LEFT JOIN BAR_DETL AS A ON B.CO_CODE = A.CO_CODE AND A.LC_CODE = B.LC_CODE AND B.TAG_NO = A.TAG_NO AND B.VCH_SRNO = A.VCH_SRNO AND A.ITM_GWT+A.ITM_NWT <> B.ITM_GWT+B.ITM_NWT  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND A.PR_CODE = '" + tPrCode.Text + "'"))), (object)" AND B.ITM_SIGN = '-' AND B.TAG_NO <> 'N' "), (object)" AND A.TAG_NO IN ("), (object)text), (object)")  ORDER BY B.VCH_TYPE,B.VCH_NO,B.TAG_NO "));
					RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DGV_FILL();
					((ColumnView)GridView1).Columns["StkGwt"].DisplayFormat.FormatType = (FormatType)1;
					((ColumnView)GridView1).Columns["StkGwt"].DisplayFormat.FormatString = "{0:n3}";
					((ColumnView)GridView1).Columns["StkGwt"].Summary.Add((SummaryItemType)0, "StkGwt", "{0}");
					((ColumnView)GridView1).Columns["SlGwt"].DisplayFormat.FormatType = (FormatType)1;
					((ColumnView)GridView1).Columns["SlGwt"].DisplayFormat.FormatString = "{0:n3}";
					((ColumnView)GridView1).Columns["SlGwt"].Summary.Add((SummaryItemType)0, "SlGwt", "{0}");
					((ColumnView)GridView1).Columns["StkNwt"].DisplayFormat.FormatType = (FormatType)1;
					((ColumnView)GridView1).Columns["StkNwt"].DisplayFormat.FormatString = "{0:n3}";
					((ColumnView)GridView1).Columns["StkNwt"].Summary.Add((SummaryItemType)0, "StkNwt", "{0}");
					((ColumnView)GridView1).Columns["SlNwt"].DisplayFormat.FormatType = (FormatType)1;
					((ColumnView)GridView1).Columns["SlNwt"].DisplayFormat.FormatString = "{0:n3}";
					((ColumnView)GridView1).Columns["SlNwt"].Summary.Add((SummaryItemType)0, "SlNwt", "{0}");
					if (((ColumnView)GridView1).Columns["GDiff"] != null)
					{
						((AppearanceObject)((ColumnView)GridView1).Columns["GDiff"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					}
					if (((ColumnView)GridView1).Columns["NDiff"] != null)
					{
						((AppearanceObject)((ColumnView)GridView1).Columns["NDiff"].AppearanceCell).TextOptions.HAlignment = (HorzAlignment)3;
					}
				}
			}
			else
			{
				Interaction.MsgBox((object)"Please Select Outword Tag List First And Try....", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void ChkTagPcsDiff_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkTagPcsDiff_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
		DC_Main.RsQry = "SELECT A.CO_BOOK as Book,A.VCH_NO As VchNo,A.TAG_NO,A.ITM_PCS,B.ITM_PCS FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_SIGN = '-' AND A.ITM_PCS <> B.ITM_PCS";
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_CLEAR();
		DataView dataView = new DataView(RsStkSum);
		if (dataView.Count > 0)
		{
			DGV.DataSource = dataView;
			DGV.ForceInitialize();
			if (((ColumnView)GridView1).Columns["Pcs"] != null)
			{
				((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
			}
		}
	}

	private void ChkDuplicatTag_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkDuplicatTag_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDoubelTag.Checked = false;
		chkZeroId.Checked = false;
		checked
		{
			if (Operators.CompareString(RptType, "TagStk", false) == 0)
			{
				RptType = "";
				string text = "";
				GridView gridView = GridView1;
				((BaseView)gridView).PostEditor();
				((ColumnView)gridView).UpdateCurrentRow();
				int num = gridView.RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
					text = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(text + "'"), dataRow[4]), (object)"',"));
					DC_Main.X++;
				}
				gridView = null;
				if (Operators.CompareString(text, "", false) != 0)
				{
					if (GridView1.RowCount > 1)
					{
						text = Strings.Mid(text, 1, Strings.Len(text) - 1);
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.TAG_NO As TagNo,1 As Qty,A.VCH_SRNO As TagId  FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" AND TAG_NO IN ("), (object)text), (object)") "), (object)" GROUP BY A.CO_CODE,A.VCH_TYPE,A.TAG_NO,A.VCH_SRNO HAVING COUNT(*) > 1 "), (object)" ORDER BY TAG_NO "));
					RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DGV_FILL();
				}
			}
			else
			{
				DC_Main.RsQry = "Select A.IT_CODE,A.TAG_NO,A.VCH_SRNO,Count(*) As Record FROM BAR_DETL As A   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N'  GROUP BY A.IT_CODE,A.TAG_NO,A.VCH_SRNO HAVING COUNT(*) > 1 ORDER BY A.TAG_NO";
				RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DGV_FILL();
			}
		}
	}

	private void chkZeroId_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkZeroId_Click(object sender, EventArgs e)
	{
		chkTagLessNotStk.Checked = false;
		chkTagNotInBarDetl.Checked = false;
		chkslandStk.Checked = false;
		chkItDiff.Checked = false;
		chkSlWtDiff.Checked = false;
		chkTagPcsDiff.Checked = false;
		chkDuplicatTag.Checked = false;
		chkDoubelTag.Checked = false;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE As CoCode,A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,A.DESIGN_NO As Design,A.ITM_SIZE As Size,1 As Qty,A.ITM_PCS as Pcs,FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt,A.LBR_RATE As LbrRate,0 As Lbrprc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_MRP As Mrp,'' As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId,A.ITM_SIGN As Sign  from MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)"  AND A.TAG_NO <> 'N' AND VCH_SRNO = 0  "), (object)" UNION ALL SELECT C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.VCH_DATE,C.TAG_NO,C.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_SIZE,1,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,0,C.LBR_AMT,C.OTH_AMT, "), (object)" C.ITM_MRP,'',C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO,C.ITM_SIGN "), (object)" from MAIN_STOCK AS C LEFT JOIN ITEM_MAST AS D ON C.CO_CODE = D.CO_CODE And C.IT_CODE = D.IT_CODE  WHERE C.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), (object)" AND C.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND C.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND D.PR_CODE = '" + tPrCode.Text + "'"))), (object)"  AND LEN(C.TAG_NO) <= 6 AND C.TAG_NO <> 'N' ORDER BY A.VCH_DATE,A.TAG_NO "));
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void BtnTagSplit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItemInword.RPT";
		}
		CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Day Wise Item InOut Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.RptName = "ItemInword";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Day Wise Item InOut Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnTagWtChange_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagWtChangSplit.RPT";
		}
		CurFormula = "{LBR_ISU_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LBR_ISU_DETL.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LBR_ISU_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {LBR_ISU_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {LBR_ISU_DETL.BOOK_NAME} IN ['TAG WT CHANGE']";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {LBR_ISU_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {LBR_ISU_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Tag Weight Change Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.RptName = "TagWtChangSplit";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Tag Weight Change Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void DGV_ADJUST_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_ADJUST_DoubleClick(object sender, EventArgs e)
	{
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 || Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)
		{
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV_ADJUST).Rows[((DataGridViewBand)((DataGridView)DGV_ADJUST).CurrentRow).Index].Cells[3].Value), (object)""), (object)"' "));
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
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_ADJUST).Rows[((DataGridViewBand)((DataGridView)DGV_ADJUST).CurrentRow).Index].Cells[5].Value, (object)""));
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG STNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG NAKSHI REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG PREP REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG FILE REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG GHAT REC", false) == 0))
		{
			TR_MFG_ISU_REC tR_MFG_ISU_REC = new TR_MFG_ISU_REC();
			((Form)tR_MFG_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MFG_ISU_REC).Show();
			((Control)tR_MFG_ISU_REC).Focus();
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
		else if (Operators.CompareString(DC_Main.CurBookMain, "COUNTER TRFR", false) == 0)
		{
			TR_PHYSTK tR_PHYSTK = new TR_PHYSTK();
			((Form)tR_PHYSTK).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PHYSTK).Show();
			((Control)tR_PHYSTK).Focus();
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

	private void tTagNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tTagNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Invalid comparison between Unknown and I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112 && (int)Interaction.MsgBox((object)"Re Adjust This Tag...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "SELECT TAG_NO,VCH_SRNO,ENTRY_TIME FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + tTagNo.Text + "' AND ITM_SIGN = '+' ORDER BY ENTRY_TIME";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_TBL_DETL FROM MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"'  AND A.ENTRY_TIME > '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["ENTRY_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"' AND A.ITM_SIGN = '-' AND B.BOOK_TBL_DETL <> ''"));
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE ", dataTable.Rows[0]["BOOK_TBL_DETL"]), (object)" SET VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable.Rows[0]["TAG_NO"]), (object)"'"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE MAIN_STOCK SET VCH_SRNO = ", DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable.Rows[0]["TAG_NO"]), (object)"'"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.M++;
				}
				Interaction.MsgBox((object)"Tag Is Adjust...", (MsgBoxStyle)0, (object)null);
			}
		}
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select A.TAG_NO FROM BAR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + tTagNo.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry = "Select A.DESIGN_NO As DesignL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.DESIGN_NO,A.TAG_NO,B.IT_NAME,A.IT_CODE  ORDER BY SUBSTRING(A.DESIGN_NO,1,2), LEN(A.DESIGN_NO),A.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.TAG_NO,A.DESIGN_NO,B.IT_NAME,A.IT_CODE  ORDER BY A.TAG_NO";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[5];
			DC_Main.ColWidth[0] = 110.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
				{
					tTagNo.Text = DC_Main.ColValue[1];
				}
				else
				{
					tTagNo.Text = DC_Main.ColValue[0];
				}
			}
		}
		else
		{
			BtnAll_Click(BtnAll, new EventArgs());
		}
	}
}
