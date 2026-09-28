using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class RP_LEDR : Form
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
	[AccessedThroughProperty("DGV_AC")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_VCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcGrCode")]
	private TextBox _tAcGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkZero")]
	private CheckBox _chkZero;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGold")]
	private SimpleButton _BtnGold;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSilver")]
	private SimpleButton _BtnSilver;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKhataNo")]
	private TextBox _tKhataNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOpBal")]
	private CheckBox _chkOpBal;

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
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnJmaUdhar")]
	private SimpleButton _BtnJmaUdhar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTimeWise")]
	private SimpleButton _BtnTimeWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlMonth")]
	private Panel _PnlMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkHalfMonth")]
	private CheckBox _chkHalfMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_MONTH")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_MONTH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcRpt")]
	private SimpleButton _btnPurcRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearch")]
	private TextBox _tSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkGoldCol")]
	private CheckBox _chkGoldCol;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAcType")]
	private ComboBox _cboAcType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnOsDay")]
	private SimpleButton _brnOsDay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboState")]
	private ComboBox _cboState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlVchDesc")]
	private Panel _pnlVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchdesc")]
	private TextBox _tVchdesc;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private bool DgvAcEnter;

	private int DgvCurRow;

	private int DgvDtlRow;

	private string MainAcCode;

	private string CurRpt;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cAddress = 3;

	private const int cMobile = 4;

	private const int cDrAmt = 5;

	private const int cCrAmt = 6;

	private const int cDrGold = 7;

	private const int cCrGold = 8;

	private const int cDrSilver = 9;

	private const int cCrSilver = 10;

	private const int cAcRefBy = 11;

	private const int cAcCity = 12;

	private const int cAcKhataNo = 13;

	private const int cRemark = 14;

	private const int c2SrNo = 0;

	private const int c2BookName = 1;

	private const int c2VchNo = 2;

	private const int c2VchDate = 3;

	private const int c2BillNo = 4;

	private const int c2AcName = 5;

	private const int c2Cramt = 6;

	private const int c2DrAmt = 7;

	private const int c2BalAmt = 8;

	private const int c2CrDr = 9;

	private const int c2CrGold = 10;

	private const int c2DrGold = 11;

	private const int c2BalGold = 12;

	private const int c2GlCrDr = 13;

	private const int c2CrSilver = 14;

	private const int c2DrSilver = 15;

	private const int c2BalSilver = 16;

	private const int c2SlCrDr = 17;

	private const int c2CoBook = 18;

	private const int c2AcCode = 19;

	private const int c2MainBook = 20;

	private const int c2Remark = 21;

	private const int c3SrNo = 0;

	private const int c3BookName = 1;

	private const int c3VchNo = 2;

	private const int c3VchDate = 3;

	private const int c3BillNo = 4;

	private const int c3AcName = 5;

	private const int c3DrAmt = 6;

	private const int c3Cramt = 7;

	private const int c3BalAmt = 8;

	private const int c3CrDr = 9;

	private const int c3DrGold = 10;

	private const int c3CrGold = 11;

	private const int c3BalGold = 12;

	private const int c3GlCrDr = 13;

	private const int c3DrSilver = 14;

	private const int c3CrSilver = 15;

	private const int c3BalSilver = 16;

	private const int c3SlCrDr = 17;

	private const int c3CoBook = 18;

	private const int c3AcCode = 19;

	private const int c3MainBook = 20;

	private const int ctSrNo = 0;

	private const int ctAcName = 1;

	private const int ctMobile = 2;

	private const int ctAmt15 = 3;

	private const int ctAmt30 = 4;

	private const int ctAmt45 = 5;

	private const int ctAmt60 = 6;

	private const int ctAmt90 = 7;

	private const int ctAmt120 = 8;

	private const int ctAmt150 = 9;

	private const int ctAmt151 = 10;

	private const int ctAmt = 11;

	private const int ctWt15 = 12;

	private const int ctWt30 = 13;

	private const int ctWt45 = 14;

	private const int ctWt60 = 15;

	private const int ctWt90 = 16;

	private const int ctWt120 = 17;

	private const int ctWt150 = 18;

	private const int ctWt151 = 19;

	private const int ctWt = 20;

	private const int ctAcCode = 21;

	private const int ctAdd1 = 22;

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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_AC
	{
		[CompilerGenerated]
		get
		{
			return _DGV_AC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_AC_CellFormatting);
			EventHandler eventHandler = DGV_DoubleClick;
			KeyEventHandler val2 = new KeyEventHandler(DGV_KeyDown);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(DGV_RowEnter);
			DevComponents.DotNetBar.Controls.DataGridViewX val4 = _DGV_AC;
			if (val4 != null)
			{
				((DataGridView)val4).CellFormatting -= val;
				((Control)val4).DoubleClick -= eventHandler;
				((Control)val4).KeyDown -= val2;
				((DataGridView)val4).RowEnter -= val3;
			}
			_DGV_AC = value;
			val4 = _DGV_AC;
			if (val4 != null)
			{
				((DataGridView)val4).CellFormatting += val;
				((Control)val4).DoubleClick += eventHandler;
				((Control)val4).KeyDown += val2;
				((DataGridView)val4).RowEnter += val3;
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
			EventHandler eventHandler2 = tSerchAll_SelectedIndexChanged;
			SearchControl val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((ComboBoxEdit)val).SelectedIndexChanged -= eventHandler2;
			}
			_tSerchAll = value;
			val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((ComboBoxEdit)val).SelectedIndexChanged += eventHandler2;
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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			KeyEventHandler val2 = new KeyEventHandler(DGV_VCH_KeyDown);
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((Control)val3).KeyDown -= val2;
			}
			_DGV_VCH = value;
			val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((Control)val3).DoubleClick += eventHandler;
				((Control)val3).KeyDown += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlAcSumm")]
	private virtual Panel _PnlAcSumm;

	internal virtual Panel PnlAcSumm
	{
		get
		{
			return _PnlAcSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlAcSumm = value;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			KeyEventHandler val2 = new KeyEventHandler(DGV_DETL_KeyDown);
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV_DETL;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((Control)val3).KeyDown -= val2;
			}
			_DGV_DETL = value;
			val3 = _DGV_DETL;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((Control)val3).DoubleClick += eventHandler;
				((Control)val3).KeyDown += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkVchSum")]
	private virtual CheckBox _chkVchSum;

	internal virtual CheckBox chkVchSum
	{
		get
		{
			return _chkVchSum;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkVchSum = value;
		}
	}

	internal virtual TextBox tAcGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcGrCode_KeyDown);
			TextBox val2 = _tAcGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcGrCode = value;
			val2 = _tAcGrCode;
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
			EventHandler eventHandler = cboCity_DropDownClosed;
			ComboBox val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.DropDownClosed -= eventHandler;
			}
			_cboCity = value;
			val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.DropDownClosed += eventHandler;
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

	internal virtual CheckBox chkZero
	{
		[CompilerGenerated]
		get
		{
			return _chkZero;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkZero_CheckedChanged;
			CheckBox val = _chkZero;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkZero = value;
			val = _chkZero;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnGold
	{
		[CompilerGenerated]
		get
		{
			return _BtnGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGold_Click;
			SimpleButton val = _BtnGold;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGold = value;
			val = _BtnGold;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnSilver
	{
		[CompilerGenerated]
		get
		{
			return _BtnSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSilver_Click;
			SimpleButton val = _BtnSilver;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSilver = value;
			val = _BtnSilver;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tKhataNo
	{
		[CompilerGenerated]
		get
		{
			return _tKhataNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tKhataNo_KeyDown);
			TextBox val2 = _tKhataNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tKhataNo = value;
			val2 = _tKhataNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblRefby")]
	private virtual Label _lblRefby;

	internal virtual Label lblRefby
	{
		get
		{
			return _lblRefby;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRefby = value;
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
	[AccessedThroughProperty("lblMobile")]
	private virtual Label _lblMobile;

	internal virtual Label lblMobile
	{
		get
		{
			return _lblMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMobile = value;
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

	internal virtual CheckBox chkOpBal
	{
		[CompilerGenerated]
		get
		{
			return _chkOpBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkOpBal_CheckedChanged;
			CheckBox val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkOpBal = value;
			val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
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

	internal virtual SimpleButton BtnTimeWise
	{
		[CompilerGenerated]
		get
		{
			return _BtnTimeWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTimeWise_Click;
			SimpleButton val = _BtnTimeWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTimeWise = value;
			val = _BtnTimeWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Panel PnlMonth
	{
		[CompilerGenerated]
		get
		{
			return _PnlMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PnlMonth_DoubleClick;
			Panel val = _PnlMonth;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PnlMonth = value;
			val = _PnlMonth;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCrDr")]
	private virtual ComboBox _cboCrDr;

	internal virtual ComboBox cboCrDr
	{
		get
		{
			return _cboCrDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCrDr = value;
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
	[AccessedThroughProperty("cboFineType")]
	private virtual ComboBox _cboFineType;

	internal virtual ComboBox cboFineType
	{
		get
		{
			return _cboFineType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFineType = value;
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

	internal virtual CheckBox chkHalfMonth
	{
		[CompilerGenerated]
		get
		{
			return _chkHalfMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkHalfMonth_CheckStateChanged;
			CheckBox val = _chkHalfMonth;
			if (val != null)
			{
				val.CheckStateChanged -= eventHandler;
			}
			_chkHalfMonth = value;
			val = _chkHalfMonth;
			if (val != null)
			{
				val.CheckStateChanged += eventHandler;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_MONTH
	{
		[CompilerGenerated]
		get
		{
			return _DGV_MONTH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = DGV_MONTH_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val = _DGV_MONTH;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV_MONTH = value;
			val = _DGV_MONTH;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual SimpleButton btnPurcRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPurcRpt_Click;
			SimpleButton val = _btnPurcRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcRpt = value;
			val = _btnPurcRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
			EventHandler eventHandler = cboArea_DropDownClosed;
			ComboBox val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.DropDownClosed -= eventHandler;
			}
			_cboArea = value;
			val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.DropDownClosed += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DgvTot")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DgvTot;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DgvTot
	{
		get
		{
			return _DgvTot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DgvTot = value;
		}
	}

	internal virtual TextBox tSearch
	{
		[CompilerGenerated]
		get
		{
			return _tSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSearch_TextChanged;
			TextBox val = _tSearch;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSearch = value;
			val = _tSearch;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkGoldCol
	{
		[CompilerGenerated]
		get
		{
			return _chkGoldCol;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkGoldCol_Click;
			CheckBox val = _chkGoldCol;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkGoldCol = value;
			val = _chkGoldCol;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboAcType
	{
		[CompilerGenerated]
		get
		{
			return _cboAcType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboAcType_KeyDown);
			ComboBox val2 = _cboAcType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboAcType = value;
			val2 = _cboAcType;
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

	internal virtual SimpleButton brnOsDay
	{
		[CompilerGenerated]
		get
		{
			return _brnOsDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = brnOsDay_Click;
			SimpleButton val = _brnOsDay;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnOsDay = value;
			val = _brnOsDay;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual Panel pnlVchDesc
	{
		[CompilerGenerated]
		get
		{
			return _pnlVchDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(pnlVchDesc_KeyDown);
			Panel val2 = _pnlVchDesc;
			if (val2 != null)
			{
				val2.KeyDown -= val;
			}
			_pnlVchDesc = value;
			val2 = _pnlVchDesc;
			if (val2 != null)
			{
				val2.KeyDown += val;
			}
		}
	}

	internal virtual TextBox tVchdesc
	{
		[CompilerGenerated]
		get
		{
			return _tVchdesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tVchdesc_KeyDown);
			TextBox val2 = _tVchdesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tVchdesc = value;
			val2 = _tVchdesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	public int newindex { get; set; }

	public RP_LEDR()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_LEDR_Load;
		((Form)this).Deactivate += RP_LEDR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_LEDR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_LEDR_KeyDown);
		((Form)this).Activated += RP_LEDR_Activated;
		((Form)this).Closed += RP_LEDR_Closed;
		DgvAcEnter = false;
		DgvCurRow = 0;
		DgvDtlRow = 0;
		CurFormula = "";
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
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected O, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Expected O, but got Unknown
		//IL_0985: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Expected O, but got Unknown
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Expected O, but got Unknown
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b64: Expected O, but got Unknown
		//IL_0bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd1: Expected O, but got Unknown
		//IL_0c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c91: Expected O, but got Unknown
		//IL_0cf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfe: Expected O, but got Unknown
		//IL_0db4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbe: Expected O, but got Unknown
		//IL_0e21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2b: Expected O, but got Unknown
		//IL_0ee5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eef: Expected O, but got Unknown
		//IL_0f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5c: Expected O, but got Unknown
		//IL_108d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1097: Expected O, but got Unknown
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		//IL_114d: Expected O, but got Unknown
		//IL_122f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected O, but got Unknown
		//IL_1308: Unknown result type (might be due to invalid IL or missing references)
		//IL_1312: Expected O, but got Unknown
		//IL_13a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b1: Expected O, but got Unknown
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1439: Expected O, but got Unknown
		//IL_151b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1525: Expected O, but got Unknown
		//IL_158e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Expected O, but got Unknown
		//IL_1659: Unknown result type (might be due to invalid IL or missing references)
		//IL_1663: Expected O, but got Unknown
		//IL_16cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d5: Expected O, but got Unknown
		//IL_16d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16dd: Expected O, but got Unknown
		//IL_175e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1768: Expected O, but got Unknown
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_180e: Expected O, but got Unknown
		//IL_1894: Unknown result type (might be due to invalid IL or missing references)
		//IL_189e: Expected O, but got Unknown
		//IL_1985: Unknown result type (might be due to invalid IL or missing references)
		//IL_198f: Expected O, but got Unknown
		//IL_19f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a02: Expected O, but got Unknown
		//IL_1cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d08: Expected O, but got Unknown
		//IL_1d86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d90: Expected O, but got Unknown
		//IL_1e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e75: Expected O, but got Unknown
		//IL_1ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efd: Expected O, but got Unknown
		//IL_1fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe2: Expected O, but got Unknown
		//IL_205f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2069: Expected O, but got Unknown
		//IL_2107: Unknown result type (might be due to invalid IL or missing references)
		//IL_2111: Expected O, but got Unknown
		//IL_21ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b7: Expected O, but got Unknown
		//IL_223d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2247: Expected O, but got Unknown
		//IL_2331: Unknown result type (might be due to invalid IL or missing references)
		//IL_233b: Expected O, but got Unknown
		//IL_23a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ae: Expected O, but got Unknown
		//IL_2470: Unknown result type (might be due to invalid IL or missing references)
		//IL_247a: Expected O, but got Unknown
		//IL_2516: Unknown result type (might be due to invalid IL or missing references)
		//IL_2520: Expected O, but got Unknown
		//IL_25a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b0: Expected O, but got Unknown
		//IL_2697: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a1: Expected O, but got Unknown
		//IL_270a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2714: Expected O, but got Unknown
		//IL_28c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28cc: Expected O, but got Unknown
		//IL_294a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2954: Expected O, but got Unknown
		//IL_2a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a3b: Expected O, but got Unknown
		//IL_2ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ac3: Expected O, but got Unknown
		//IL_2b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b7b: Expected O, but got Unknown
		//IL_2c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c53: Expected O, but got Unknown
		//IL_2d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d35: Expected O, but got Unknown
		//IL_2dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddb: Expected O, but got Unknown
		//IL_2eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ef7: Expected O, but got Unknown
		//IL_2f61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f6b: Expected O, but got Unknown
		//IL_3019: Unknown result type (might be due to invalid IL or missing references)
		//IL_3023: Expected O, but got Unknown
		//IL_309e: Unknown result type (might be due to invalid IL or missing references)
		//IL_30a8: Expected O, but got Unknown
		//IL_3156: Unknown result type (might be due to invalid IL or missing references)
		//IL_3160: Expected O, but got Unknown
		//IL_31fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3207: Expected O, but got Unknown
		//IL_32e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ec: Expected O, but got Unknown
		//IL_336a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3374: Expected O, but got Unknown
		//IL_33ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_33f4: Expected O, but got Unknown
		//IL_34b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_34be: Expected O, but got Unknown
		//IL_356d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3577: Expected O, but got Unknown
		//IL_35f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_35fb: Expected O, but got Unknown
		//IL_367f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3689: Expected O, but got Unknown
		//IL_3759: Unknown result type (might be due to invalid IL or missing references)
		//IL_3763: Expected O, but got Unknown
		//IL_37ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3809: Expected O, but got Unknown
		//IL_388f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3899: Expected O, but got Unknown
		//IL_3980: Unknown result type (might be due to invalid IL or missing references)
		//IL_398a: Expected O, but got Unknown
		//IL_39f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_39fd: Expected O, but got Unknown
		//IL_3ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3abc: Expected O, but got Unknown
		//IL_3b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b75: Expected O, but got Unknown
		//IL_3c38: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c42: Expected O, but got Unknown
		//IL_3d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d21: Expected O, but got Unknown
		//IL_3dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dc4: Expected O, but got Unknown
		//IL_3ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ef2: Expected O, but got Unknown
		//IL_3fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fb1: Expected O, but got Unknown
		//IL_404c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4056: Expected O, but got Unknown
		//IL_40da: Unknown result type (might be due to invalid IL or missing references)
		//IL_40e4: Expected O, but got Unknown
		//IL_4192: Unknown result type (might be due to invalid IL or missing references)
		//IL_419c: Expected O, but got Unknown
		//IL_4275: Unknown result type (might be due to invalid IL or missing references)
		//IL_427f: Expected O, but got Unknown
		//IL_42c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_42d1: Expected O, but got Unknown
		//IL_43a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_43ab: Expected O, but got Unknown
		//IL_4480: Unknown result type (might be due to invalid IL or missing references)
		//IL_448a: Expected O, but got Unknown
		//IL_4523: Unknown result type (might be due to invalid IL or missing references)
		//IL_452d: Expected O, but got Unknown
		//IL_46c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_46cf: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_LEDR));
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
		DataGridViewCellStyle val21 = new DataGridViewCellStyle();
		DataGridViewCellStyle val22 = new DataGridViewCellStyle();
		DataGridViewCellStyle val23 = new DataGridViewCellStyle();
		DataGridViewCellStyle val24 = new DataGridViewCellStyle();
		DataGridViewCellStyle val25 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnGold = new SimpleButton();
		BtnSilver = new SimpleButton();
		BtnJmaUdhar = new SimpleButton();
		btnPurcRpt = new SimpleButton();
		Panel1 = new Panel();
		lblMobile = new Label();
		lblAdd1 = new Label();
		lblBook = new Label();
		DGV_AC = new DevComponents.DotNetBar.Controls.DataGridViewX();
		tSerchAll = new SearchControl();
		DGV_VCH = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PnlAcSumm = new Panel();
		cboArea = new ComboBox();
		Label8 = new Label();
		cboAcType = new ComboBox();
		Label7 = new Label();
		cboCity = new ComboBox();
		tSearch = new TextBox();
		DgvTot = new DevComponents.DotNetBar.Controls.DataGridViewX();
		DGV_MONTH = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PnlMonth = new Panel();
		cboFineType = new ComboBox();
		chkHalfMonth = new CheckBox();
		cboCrDr = new ComboBox();
		Label6 = new Label();
		Label5 = new Label();
		BtnTimeWise = new SimpleButton();
		tRefAc = new TextBox();
		Label4 = new Label();
		tKhataNo = new TextBox();
		Label17 = new Label();
		lblCity = new Label();
		Label15 = new Label();
		cboState = new ComboBox();
		tAcGrCode = new TextBox();
		Label1 = new Label();
		chkVchSum = new CheckBox();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		chkZero = new CheckBox();
		lblRefby = new Label();
		BtnF1 = new SimpleButton();
		chkOpBal = new CheckBox();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		Label3 = new Label();
		tLcCode = new TextBox();
		Cr = new AxCrystalReport();
		chkGoldCol = new CheckBox();
		brnOsDay = new SimpleButton();
		pnlVchDesc = new Panel();
		tVchdesc = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)DGV_AC).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)DGV_VCH).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)DgvTot).BeginInit();
		((ISupportInitialize)DGV_MONTH).BeginInit();
		((Control)PnlMonth).SuspendLayout();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((Control)pnlVchDesc).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnGold);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSilver);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnJmaUdhar);
		((Control)PnlBotam).Controls.Add((Control)(object)btnPurcRpt);
		((Control)PnlBotam).Controls.Add((Control)(object)Panel1);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 3;
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
		((Control)BtnExit).TabIndex = 0;
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
		((Control)BtnCancel).TabIndex = 1;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(1021, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 3;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnSave).TabIndex = 2;
		BtnSave.Text = "&Excel";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(827, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 4;
		BtnDelete.Text = "&JmaUdr";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnDelete).Visible = false;
		((BaseStyleControl)BtnGold).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnGold).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnGold).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnGold).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnGold.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnGold.ImageOptions.SvgImage");
		((Control)BtnGold).Location = new Point(730, 3);
		((BaseControl)BtnGold).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnGold).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnGold).Name = "BtnGold";
		((Control)BtnGold).Size = new Size(91, 37);
		((Control)BtnGold).TabIndex = 6;
		BtnGold.Text = "&Gold";
		((BaseButton)BtnGold).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnGold).Visible = false;
		((BaseStyleControl)BtnSilver).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSilver).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSilver).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSilver).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSilver.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSilver.ImageOptions.SvgImage");
		((Control)BtnSilver).Location = new Point(633, 3);
		((BaseControl)BtnSilver).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSilver).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSilver).Name = "BtnSilver";
		((Control)BtnSilver).Size = new Size(91, 37);
		((Control)BtnSilver).TabIndex = 7;
		BtnSilver.Text = "&Silver";
		((BaseButton)BtnSilver).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnSilver).Visible = false;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnJmaUdhar.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnJmaUdhar.ImageOptions.SvgImage");
		((Control)BtnJmaUdhar).Location = new Point(536, 3);
		((BaseControl)BtnJmaUdhar).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnJmaUdhar).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnJmaUdhar).Name = "BtnJmaUdhar";
		((Control)BtnJmaUdhar).Size = new Size(91, 37);
		((Control)BtnJmaUdhar).TabIndex = 1158;
		BtnJmaUdhar.Text = "&In Out";
		((BaseButton)BtnJmaUdhar).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnJmaUdhar).Visible = false;
		((BaseStyleControl)btnPurcRpt).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnPurcRpt).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnPurcRpt).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnPurcRpt).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnPurcRpt.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnPurcRpt.ImageOptions.SvgImage");
		((Control)btnPurcRpt).Location = new Point(439, 3);
		((BaseControl)btnPurcRpt).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnPurcRpt).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnPurcRpt).Name = "btnPurcRpt";
		((Control)btnPurcRpt).Size = new Size(91, 37);
		((Control)btnPurcRpt).TabIndex = 1159;
		btnPurcRpt.Text = "&Ac Purc";
		((BaseButton)btnPurcRpt).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnPurcRpt).Visible = false;
		((Control)Panel1).Controls.Add((Control)(object)lblMobile);
		((Control)Panel1).Controls.Add((Control)(object)lblAdd1);
		((Control)Panel1).Location = new Point(146, 3);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(287, 38);
		((Control)Panel1).TabIndex = 11;
		((Control)lblMobile).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.White;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(7, 18);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).RightToLeft = (RightToLeft)0;
		((Control)lblMobile).Size = new Size(274, 20);
		((Control)lblMobile).TabIndex = 1140;
		lblMobile.Text = "Mobile";
		lblMobile.TextAlign = (ContentAlignment)64;
		((Control)lblAdd1).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.White;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(8, 0);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).RightToLeft = (RightToLeft)0;
		((Control)lblAdd1).Size = new Size(274, 20);
		((Control)lblAdd1).TabIndex = 1139;
		lblAdd1.Text = "Address";
		lblAdd1.TextAlign = (ContentAlignment)64;
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
		lblBook.Text = "Ledr Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((DataGridView)DGV_AC).AllowUserToAddRows = false;
		((DataGridView)DGV_AC).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AC).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_AC).BackgroundColor = Color.Snow;
		((DataGridView)DGV_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_AC).ColumnHeadersHeight = 30;
		((DataGridView)DGV_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).DefaultCellStyle = val3;
		((DataGridView)DGV_AC).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_AC).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_AC).Location = new Point(15, 45);
		((Control)DGV_AC).Name = "DGV_AC";
		DGV_AC.PaintEnhancedSelection = false;
		((DataGridView)DGV_AC).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AC).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_AC).RowHeadersVisible = false;
		((DataGridView)DGV_AC).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_AC).RowsDefaultCellStyle = val5;
		DGV_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_AC.SelectAllSignVisible = false;
		((DataGridView)DGV_AC).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_AC).Size = new Size(1160, 448);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((Control)tSerchAll).Location = new Point(110, 11);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Ac Or Mobile Search";
		((Control)tSerchAll).Size = new Size(89, 24);
		((Control)tSerchAll).TabIndex = 1;
		((DataGridView)DGV_VCH).AllowUserToAddRows = false;
		((DataGridView)DGV_VCH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_VCH).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_VCH).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_VCH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_VCH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_VCH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_VCH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).DefaultCellStyle = val8;
		((DataGridView)DGV_VCH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_VCH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_VCH).Location = new Point(13, 79);
		((Control)DGV_VCH).Name = "DGV_VCH";
		DGV_VCH.PaintEnhancedSelection = false;
		((DataGridView)DGV_VCH).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_VCH).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_VCH).RowHeadersVisible = false;
		((DataGridView)DGV_VCH).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_VCH).RowsDefaultCellStyle = val10;
		DGV_VCH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_VCH.SelectAllSignVisible = false;
		((DataGridView)DGV_VCH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_VCH).Size = new Size(1159, 473);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 7;
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboArea);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label8);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboAcType);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label7);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSearch);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DgvTot);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_MONTH);
		((Control)PnlAcSumm).Controls.Add((Control)(object)PnlMonth);
		((Control)PnlAcSumm).Controls.Add((Control)(object)BtnTimeWise);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tRefAc);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label4);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tKhataNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label17);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label15);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboState);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcGrCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Location = new Point(-1, 34);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 531);
		((Control)PnlAcSumm).TabIndex = 0;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(490, 13);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(100, 22);
		((Control)cboArea).TabIndex = 1152;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(576, 14);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(67, 19);
		((Control)Label8).TabIndex = 1162;
		Label8.Text = "State";
		Label8.TextAlign = (ContentAlignment)64;
		cboAcType.AutoCompleteMode = (AutoCompleteMode)3;
		cboAcType.AutoCompleteSource = (AutoCompleteSource)256;
		cboAcType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboAcType).Font = new Font("Tahoma", 9f);
		((ListControl)cboAcType).FormattingEnabled = true;
		((Control)cboAcType).Location = new Point(247, 13);
		((Control)cboAcType).Name = "cboAcType";
		((Control)cboAcType).Size = new Size(42, 22);
		((Control)cboAcType).TabIndex = 1160;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(176, 13);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(67, 19);
		((Control)Label7).TabIndex = 1161;
		Label7.Text = "Type";
		Label7.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(333, 13);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(105, 22);
		((Control)cboCity).TabIndex = 2;
		((TextBoxBase)tSearch).BackColor = Color.White;
		((Control)tSearch).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSearch).Location = new Point(16, 10);
		((TextBoxBase)tSearch).MaxLength = 50;
		((Control)tSearch).Name = "tSearch";
		((Control)tSearch).Size = new Size(88, 25);
		((Control)tSearch).TabIndex = 1159;
		((DataGridView)DgvTot).AllowUserToAddRows = false;
		((DataGridView)DgvTot).AllowUserToDeleteRows = false;
		((DataGridView)DgvTot).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DgvTot).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DgvTot).BackgroundColor = Color.Snow;
		((DataGridView)DgvTot).BorderStyle = (BorderStyle)2;
		((DataGridView)DgvTot).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DgvTot).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DgvTot).ColumnHeadersHeight = 30;
		((DataGridView)DgvTot).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DgvTot).DefaultCellStyle = val13;
		((DataGridView)DgvTot).EnableHeadersVisualStyles = false;
		((DataGridView)DgvTot).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DgvTot).Location = new Point(15, 493);
		((Control)DgvTot).Name = "DgvTot";
		DgvTot.PaintEnhancedSelection = false;
		((DataGridView)DgvTot).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DgvTot).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DgvTot).RowHeadersVisible = false;
		((DataGridView)DgvTot).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DgvTot).RowsDefaultCellStyle = val15;
		DgvTot.ScrollBarAppearance = (eScrollBarAppearance)0;
		DgvTot.SelectAllSignVisible = false;
		((DataGridView)DgvTot).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DgvTot).Size = new Size(1160, 27);
		((DataGridView)DgvTot).StandardTab = true;
		((Control)DgvTot).TabIndex = 1158;
		((DataGridView)DGV_MONTH).AllowUserToAddRows = false;
		((DataGridView)DGV_MONTH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_MONTH).AllowUserToResizeRows = false;
		val16.BackColor = Color.PapayaWhip;
		val16.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val16.ForeColor = Color.FromArgb(64, 64, 64);
		val16.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val16.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_MONTH).AlternatingRowsDefaultCellStyle = val16;
		((DataGridView)DGV_MONTH).BackgroundColor = Color.Snow;
		((DataGridView)DGV_MONTH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_MONTH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val17.Alignment = (DataGridViewContentAlignment)16;
		val17.BackColor = SystemColors.Control;
		val17.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val17.ForeColor = Color.FromArgb(64, 64, 64);
		val17.SelectionBackColor = SystemColors.ScrollBar;
		val17.SelectionForeColor = Color.White;
		val17.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle = val17;
		((DataGridView)DGV_MONTH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_MONTH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val18.Alignment = (DataGridViewContentAlignment)16;
		val18.BackColor = SystemColors.Window;
		val18.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val18.ForeColor = Color.FromArgb(64, 64, 64);
		val18.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val18.SelectionForeColor = Color.Maroon;
		val18.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_MONTH).DefaultCellStyle = val18;
		((DataGridView)DGV_MONTH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_MONTH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_MONTH).Location = new Point(15, 45);
		((Control)DGV_MONTH).Name = "DGV_MONTH";
		DGV_MONTH.PaintEnhancedSelection = false;
		((DataGridView)DGV_MONTH).ReadOnly = true;
		val19.Alignment = (DataGridViewContentAlignment)16;
		val19.BackColor = Color.MintCream;
		val19.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val19.ForeColor = SystemColors.WindowText;
		val19.SelectionBackColor = SystemColors.Highlight;
		val19.SelectionForeColor = SystemColors.HighlightText;
		val19.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_MONTH).RowHeadersDefaultCellStyle = val19;
		((DataGridView)DGV_MONTH).RowHeadersVisible = false;
		((DataGridView)DGV_MONTH).RowHeadersWidth = 20;
		val20.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val20.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_MONTH).RowsDefaultCellStyle = val20;
		DGV_MONTH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_MONTH.SelectAllSignVisible = false;
		((DataGridView)DGV_MONTH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_MONTH).Size = new Size(1160, 447);
		((DataGridView)DGV_MONTH).StandardTab = true;
		((Control)DGV_MONTH).TabIndex = 1157;
		((Control)DGV_MONTH).Visible = false;
		((Control)PnlMonth).Controls.Add((Control)(object)cboFineType);
		((Control)PnlMonth).Controls.Add((Control)(object)chkHalfMonth);
		((Control)PnlMonth).Controls.Add((Control)(object)cboCrDr);
		((Control)PnlMonth).Controls.Add((Control)(object)Label6);
		((Control)PnlMonth).Controls.Add((Control)(object)Label5);
		((Control)PnlMonth).Location = new Point(644, 4);
		((Control)PnlMonth).Name = "PnlMonth";
		((Control)PnlMonth).Size = new Size(546, 39);
		((Control)PnlMonth).TabIndex = 1151;
		((Control)PnlMonth).Visible = false;
		cboFineType.AutoCompleteMode = (AutoCompleteMode)3;
		cboFineType.AutoCompleteSource = (AutoCompleteSource)256;
		cboFineType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboFineType).Font = new Font("Tahoma", 9f);
		((ListControl)cboFineType).FormattingEnabled = true;
		((Control)cboFineType).Location = new Point(100, 10);
		((Control)cboFineType).Name = "cboFineType";
		((Control)cboFineType).Size = new Size(96, 22);
		((Control)cboFineType).TabIndex = 1139;
		((ButtonBase)chkHalfMonth).BackColor = Color.Transparent;
		((Control)chkHalfMonth).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHalfMonth).ForeColor = Color.Black;
		((Control)chkHalfMonth).Location = new Point(378, 11);
		((Control)chkHalfMonth).Name = "chkHalfMonth";
		((Control)chkHalfMonth).RightToLeft = (RightToLeft)0;
		((Control)chkHalfMonth).Size = new Size(163, 21);
		((Control)chkHalfMonth).TabIndex = 1143;
		((ButtonBase)chkHalfMonth).Text = " Half Month Show";
		((ButtonBase)chkHalfMonth).UseVisualStyleBackColor = false;
		cboCrDr.AutoCompleteMode = (AutoCompleteMode)3;
		cboCrDr.AutoCompleteSource = (AutoCompleteSource)256;
		cboCrDr.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCrDr).Font = new Font("Tahoma", 9f);
		((ListControl)cboCrDr).FormattingEnabled = true;
		((Control)cboCrDr).Location = new Point(307, 10);
		((Control)cboCrDr).Name = "cboCrDr";
		((Control)cboCrDr).Size = new Size(59, 22);
		((Control)cboCrDr).TabIndex = 1141;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(191, 10);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(107, 19);
		((Control)Label6).TabIndex = 1142;
		Label6.Text = "Balance Type";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(17, 9);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(75, 22);
		((Control)Label5).TabIndex = 1140;
		Label5.Text = "FineType";
		Label5.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnTimeWise).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnTimeWise).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnTimeWise).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnTimeWise).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnTimeWise).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnTimeWise).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnTimeWise).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnTimeWise).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnTimeWise).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnTimeWise).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnTimeWise).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnTimeWise).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnTimeWise).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnTimeWise).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnTimeWise).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnTimeWise).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnTimeWise).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnTimeWise).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnTimeWise).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnTimeWise).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnTimeWise).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnTimeWise).AppearancePressed.Options.UseFont = true;
		((Control)BtnTimeWise).Location = new Point(1107, 9);
		((BaseControl)BtnTimeWise).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnTimeWise).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnTimeWise).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnTimeWise).Name = "BtnTimeWise";
		((Control)BtnTimeWise).Size = new Size(78, 28);
		((Control)BtnTimeWise).TabIndex = 1150;
		BtnTimeWise.Text = "Time Wise";
		((BaseControl)BtnTimeWise).ToolTip = "Time Wise Ledger";
		((TextBoxBase)tRefAc).BackColor = Color.White;
		((Control)tRefAc).Font = new Font("Tahoma", 9f);
		((Control)tRefAc).Location = new Point(1037, 13);
		((TextBoxBase)tRefAc).MaxLength = 10;
		((Control)tRefAc).Name = "tRefAc";
		((Control)tRefAc).Size = new Size(60, 22);
		((Control)tRefAc).TabIndex = 6;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(975, 14);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(56, 20);
		((Control)Label4).TabIndex = 1144;
		Label4.Text = "Ref by";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tKhataNo).BackColor = Color.White;
		((Control)tKhataNo).Font = new Font("Tahoma", 9f);
		((Control)tKhataNo).Location = new Point(920, 13);
		((TextBoxBase)tKhataNo).MaxLength = 10;
		((Control)tKhataNo).Name = "tKhataNo";
		((Control)tKhataNo).Size = new Size(53, 22);
		((Control)tKhataNo).TabIndex = 5;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(417, 14);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(67, 19);
		((Control)Label17).TabIndex = 1140;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(280, 13);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(46, 19);
		((Control)lblCity).TabIndex = 1138;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(739, 14);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(72, 20);
		((Control)Label15).TabIndex = 1136;
		Label15.Text = "Ac Group";
		Label15.TextAlign = (ContentAlignment)64;
		cboState.AutoCompleteMode = (AutoCompleteMode)3;
		cboState.AutoCompleteSource = (AutoCompleteSource)256;
		cboState.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboState).Font = new Font("Tahoma", 9f);
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Location = new Point(650, 13);
		((Control)cboState).Name = "cboState";
		((Control)cboState).Size = new Size(89, 22);
		((Control)cboState).TabIndex = 1163;
		((TextBoxBase)tAcGrCode).BackColor = Color.White;
		((Control)tAcGrCode).Font = new Font("Tahoma", 9f);
		((Control)tAcGrCode).Location = new Point(817, 13);
		((TextBoxBase)tAcGrCode).MaxLength = 2;
		((Control)tAcGrCode).Name = "tAcGrCode";
		((Control)tAcGrCode).Size = new Size(43, 22);
		((Control)tAcGrCode).TabIndex = 4;
		tAcGrCode.TextAlign = (HorizontalAlignment)2;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(842, 14);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(72, 20);
		((Control)Label1).TabIndex = 1142;
		Label1.Text = "Khata";
		Label1.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkVchSum).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkVchSum).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkVchSum).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkVchSum).Location = new Point(966, 7);
		((Control)chkVchSum).Name = "chkVchSum";
		((Control)chkVchSum).RightToLeft = (RightToLeft)0;
		((Control)chkVchSum).Size = new Size(94, 19);
		((Control)chkVchSum).TabIndex = 7;
		((ButtonBase)chkVchSum).Text = "Vch Summ";
		((ButtonBase)chkVchSum).UseVisualStyleBackColor = false;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(296, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(74, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(374, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(259, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(211, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(80, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Ac Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val21.BackColor = Color.PapayaWhip;
		val21.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val21.ForeColor = Color.FromArgb(64, 64, 64);
		val21.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val21.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val21;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Linen;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val22.Alignment = (DataGridViewContentAlignment)16;
		val22.BackColor = SystemColors.Control;
		val22.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val22.ForeColor = Color.FromArgb(64, 64, 64);
		val22.SelectionBackColor = SystemColors.ScrollBar;
		val22.SelectionForeColor = Color.White;
		val22.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val22;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val23.Alignment = (DataGridViewContentAlignment)16;
		val23.BackColor = SystemColors.Window;
		val23.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val23.ForeColor = Color.FromArgb(64, 64, 64);
		val23.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val23.SelectionForeColor = Color.Maroon;
		val23.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val23;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 79);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val24.Alignment = (DataGridViewContentAlignment)16;
		val24.BackColor = Color.MintCream;
		val24.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val24.ForeColor = SystemColors.WindowText;
		val24.SelectionBackColor = SystemColors.Highlight;
		val24.SelectionForeColor = SystemColors.HighlightText;
		val24.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val24;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val25.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val25.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val25;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((ButtonBase)chkZero).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkZero).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkZero).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkZero).Location = new Point(16, 7);
		((Control)chkZero).Name = "chkZero";
		((Control)chkZero).RightToLeft = (RightToLeft)0;
		((Control)chkZero).Size = new Size(141, 19);
		((Control)chkZero).TabIndex = 1;
		((ButtonBase)chkZero).Text = "With Zero Balance";
		chkZero.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkZero).UseVisualStyleBackColor = false;
		((Control)lblRefby).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRefby).ForeColor = Color.Black;
		lblRefby.ImeMode = (ImeMode)0;
		((Control)lblRefby).Location = new Point(727, 45);
		((Control)lblRefby).Name = "lblRefby";
		((Control)lblRefby).Size = new Size(317, 20);
		((Control)lblRefby).TabIndex = 1140;
		lblRefby.Text = "AcRefBy";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(639, 44);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(33, 23);
		((Control)BtnF1).TabIndex = 1152;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Ledger Date";
		((ButtonBase)chkOpBal).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkOpBal).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOpBal).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkOpBal).Location = new Point(188, 7);
		((Control)chkOpBal).Name = "chkOpBal";
		((Control)chkOpBal).RightToLeft = (RightToLeft)0;
		((Control)chkOpBal).Size = new Size(141, 20);
		((Control)chkOpBal).TabIndex = 2;
		((ButtonBase)chkOpBal).Text = "Opning Balance";
		((ButtonBase)chkOpBal).UseVisualStyleBackColor = false;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(144, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1155;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(62, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 1154;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(12, 45);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(44, 20);
		((Control)Label3).TabIndex = 1156;
		Label3.Text = "Date";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1112, 6);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1158;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1247, 476);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
		((ButtonBase)chkGoldCol).BackColor = Color.Transparent;
		((Control)chkGoldCol).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkGoldCol).ForeColor = Color.Black;
		((Control)chkGoldCol).Location = new Point(1054, 48);
		((Control)chkGoldCol).Name = "chkGoldCol";
		((Control)chkGoldCol).RightToLeft = (RightToLeft)0;
		((Control)chkGoldCol).Size = new Size(132, 20);
		((Control)chkGoldCol).TabIndex = 1159;
		((ButtonBase)chkGoldCol).Text = "Gold Col Show";
		((ButtonBase)chkGoldCol).UseVisualStyleBackColor = false;
		((BaseStyleControl)brnOsDay).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)brnOsDay).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)brnOsDay).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)brnOsDay).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)brnOsDay).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)brnOsDay).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)brnOsDay).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)brnOsDay).Appearance.Options.UseFont = true;
		((BaseStyleControl)brnOsDay).Appearance.Options.UseForeColor = true;
		((BaseButton)brnOsDay).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)brnOsDay).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)brnOsDay).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)brnOsDay).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)brnOsDay).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)brnOsDay).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)brnOsDay).AppearanceHovered.Options.UseFont = true;
		((BaseButton)brnOsDay).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)brnOsDay).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)brnOsDay).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)brnOsDay).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)brnOsDay).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)brnOsDay).AppearancePressed.Options.UseFont = true;
		((Control)brnOsDay).Location = new Point(679, 44);
		((BaseControl)brnOsDay).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)brnOsDay).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)brnOsDay).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)brnOsDay).Name = "brnOsDay";
		((Control)brnOsDay).Size = new Size(36, 23);
		((Control)brnOsDay).TabIndex = 1160;
		brnOsDay.Text = "OD";
		((BaseControl)brnOsDay).ToolTip = "Bill Os Day";
		((Control)brnOsDay).Visible = false;
		((Control)pnlVchDesc).Controls.Add((Control)(object)tVchdesc);
		((Control)pnlVchDesc).Location = new Point(639, 35);
		((Control)pnlVchDesc).Name = "pnlVchDesc";
		((Control)pnlVchDesc).Size = new Size(539, 42);
		((Control)pnlVchDesc).TabIndex = 1166;
		((Control)pnlVchDesc).Visible = false;
		((TextBoxBase)tVchdesc).BackColor = Color.White;
		((Control)tVchdesc).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchdesc).Location = new Point(4, 4);
		((TextBoxBase)tVchdesc).MaxLength = 250;
		tVchdesc.Multiline = true;
		((Control)tVchdesc).Name = "tVchdesc";
		((Control)tVchdesc).Size = new Size(529, 34);
		((Control)tVchdesc).TabIndex = 1160;
		tVchdesc.Text = "Vch Desc :";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)chkVchSum);
		((Control)this).Controls.Add((Control)(object)chkOpBal);
		((Control)this).Controls.Add((Control)(object)chkZero);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)DGV_VCH);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)pnlVchDesc);
		((Control)this).Controls.Add((Control)(object)chkGoldCol);
		((Control)this).Controls.Add((Control)(object)lblRefby);
		((Control)this).Controls.Add((Control)(object)brnOsDay);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_LEDR";
		((Form)this).Text = "Company";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)DGV_AC).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((ISupportInitialize)DgvTot).EndInit();
		((ISupportInitialize)DGV_MONTH).EndInit();
		((Control)PnlMonth).ResumeLayout(false);
		((ISupportInitialize)DGV_DETL).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((Control)pnlVchDesc).ResumeLayout(false);
		((Control)pnlVchDesc).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		object obj = default(object);
		int num5 = default(int);
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
		int num14 = default(int);
		int num15 = default(int);
		int num16 = default(int);
		int num17 = default(int);
		int num18 = default(int);
		int num19 = default(int);
		int num20 = default(int);
		int num21 = default(int);
		int num22 = default(int);
		int num23 = default(int);
		int num24 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
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
					case 3182:
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
								goto IL_015c;
							case 15:
								goto IL_01a4;
							case 16:
								goto IL_01b3;
							case 17:
								goto IL_01d0;
							case 18:
								goto IL_01ea;
							case 19:
								goto IL_0211;
							case 21:
								goto IL_024c;
							case 23:
								goto IL_02b6;
							case 20:
							case 22:
							case 24:
							case 25:
							case 26:
								goto IL_0317;
							case 27:
								goto IL_0329;
							case 29:
								goto IL_034b;
							case 30:
								goto IL_0362;
							case 31:
								goto IL_03aa;
							case 32:
								goto IL_03b9;
							case 33:
								goto IL_03d6;
							case 34:
								goto IL_03f0;
							case 35:
								goto IL_0417;
							case 37:
								goto IL_0461;
							case 39:
								goto IL_04ce;
							case 41:
								goto IL_0538;
							case 36:
							case 38:
							case 40:
							case 42:
							case 43:
							case 44:
								goto IL_0590;
							case 45:
								goto IL_05a2;
							case 48:
								goto IL_05c5;
							case 49:
								goto IL_05dc;
							case 50:
								goto IL_05f3;
							case 51:
								goto IL_063b;
							case 52:
								goto IL_064a;
							case 53:
								goto IL_0667;
							case 54:
								goto IL_0681;
							case 55:
								goto IL_06a4;
							case 56:
							case 57:
								goto IL_06f9;
							case 58:
								goto IL_070b;
							case 60:
								goto IL_072d;
							case 61:
								goto IL_0744;
							case 62:
								goto IL_078c;
							case 63:
								goto IL_079b;
							case 64:
								goto IL_07b8;
							case 65:
								goto IL_07cf;
							case 66:
								goto IL_0822;
							case 67:
								goto IL_0831;
							case 28:
							case 46:
							case 47:
							case 59:
							case 68:
							case 69:
							case 70:
								goto IL_084e;
							case 71:
								goto IL_0858;
							case 72:
								goto IL_08ab;
							case 73:
								goto IL_0900;
							case 74:
								goto IL_0958;
							case 75:
								goto IL_09c6;
							case 76:
								goto IL_0a09;
							case 77:
								goto IL_0a38;
							case 78:
								goto IL_0a7b;
							case 79:
								goto IL_0abc;
							case 80:
								goto IL_0add;
							case 81:
								goto IL_0aeb;
							case 82:
								goto IL_0af1;
							case 83:
								goto IL_0af7;
							case 84:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 85:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0831:
						num2 = 67;
						DC_Main.i++;
						goto IL_0840;
						IL_07cf:
						num2 = 65;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0822;
						IL_082b:
						if (num5 <= num6)
						{
							goto IL_07cf;
						}
						goto IL_0831;
						IL_0822:
						num2 = 66;
						num5++;
						goto IL_082b;
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
						if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
						{
							goto IL_012e;
						}
						goto IL_05c5;
						IL_012e:
						num2 = 12;
						if (chkVchSum.Checked)
						{
							goto IL_0145;
						}
						goto IL_034b;
						IL_0145:
						num2 = 13;
						num7 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num8 = 0;
						goto IL_01ad;
						IL_01ad:
						if (num8 <= num7)
						{
							goto IL_015c;
						}
						goto IL_01b3;
						IL_01b3:
						num2 = 16;
						num9 = ((DataGridView)DGV_VCH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0338;
						IL_0338:
						if (DC_Main.i <= num9)
						{
							goto IL_01d0;
						}
						goto IL_084e;
						IL_01d0:
						num2 = 17;
						num10 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num11 = 0;
						goto IL_0320;
						IL_0320:
						if (num11 <= num10)
						{
							goto IL_01ea;
						}
						goto IL_0329;
						IL_0329:
						num2 = 27;
						DC_Main.i++;
						goto IL_0338;
						IL_01ea:
						num2 = 18;
						if (((DataGridView)DGV_VCH)[num11, DC_Main.i].Value != null)
						{
							goto IL_0211;
						}
						goto IL_0317;
						IL_0211:
						num2 = 19;
						switch (num11)
						{
						case 6:
						case 7:
						case 8:
						case 10:
						case 11:
						case 12:
						case 14:
						case 15:
						case 16:
							break;
						default:
							goto IL_02b6;
						}
						goto IL_024c;
						IL_02b6:
						num2 = 23;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString() ?? ""
						}, (string[])null, (Type[])null);
						goto IL_0317;
						IL_078c:
						num2 = 62;
						num12++;
						goto IL_0795;
						IL_0744:
						num2 = 61;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num12 + 1,
							((DataGridView)DGV_AC).Columns[num12].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_078c;
						IL_024c:
						num2 = 21;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString()), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_0317;
						IL_0317:
						num2 = 26;
						num11++;
						goto IL_0320;
						IL_015c:
						num2 = 14;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_VCH).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_01a4;
						IL_01a4:
						num2 = 15;
						num8++;
						goto IL_01ad;
						IL_034b:
						num2 = 29;
						num13 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num14 = 0;
						goto IL_03b3;
						IL_03b3:
						if (num14 <= num13)
						{
							goto IL_0362;
						}
						goto IL_03b9;
						IL_03b9:
						num2 = 32;
						num15 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_05b1;
						IL_05b1:
						if (DC_Main.i <= num15)
						{
							goto IL_03d6;
						}
						goto IL_084e;
						IL_03d6:
						num2 = 33;
						num16 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num17 = 0;
						goto IL_0599;
						IL_0599:
						if (num17 <= num16)
						{
							goto IL_03f0;
						}
						goto IL_05a2;
						IL_05a2:
						num2 = 45;
						DC_Main.i++;
						goto IL_05b1;
						IL_03f0:
						num2 = 34;
						if (((DataGridView)DGV_DETL)[num17, DC_Main.i].Value != null)
						{
							goto IL_0417;
						}
						goto IL_0590;
						IL_0417:
						num2 = 35;
						switch (num17)
						{
						case 6:
						case 7:
						case 8:
						case 10:
						case 11:
						case 12:
						case 14:
						case 15:
						case 16:
							break;
						case 3:
							goto IL_04ce;
						default:
							goto IL_0538;
						}
						goto IL_0461;
						IL_0538:
						num2 = 41;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num17 + 1,
							((DataGridView)DGV_DETL)[num17, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0590;
						IL_04ce:
						num2 = 39;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num17 + 1,
							Strings.Format((object)Conversions.ToDate(((DataGridView)DGV_DETL)[num17, DC_Main.i].Value.ToString()), "MM/dd/yyyy")
						}, (string[])null, (Type[])null);
						goto IL_0590;
						IL_0461:
						num2 = 37;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num17 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV_DETL)[num17, DC_Main.i].Value.ToString()), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_0590;
						IL_0590:
						num2 = 44;
						num17++;
						goto IL_0599;
						IL_0362:
						num2 = 30;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num14 + 1,
							((DataGridView)DGV_DETL).Columns[num14].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_03aa;
						IL_03aa:
						num2 = 31;
						num14++;
						goto IL_03b3;
						IL_05c5:
						num2 = 48;
						if (((Control)PnlMonth).Visible)
						{
							goto IL_05dc;
						}
						goto IL_072d;
						IL_05dc:
						num2 = 49;
						num18 = ((DataGridView)DGV_MONTH).ColumnCount - 1;
						num19 = 0;
						goto IL_0644;
						IL_0644:
						if (num19 <= num18)
						{
							goto IL_05f3;
						}
						goto IL_064a;
						IL_064a:
						num2 = 52;
						num20 = ((DataGridView)DGV_MONTH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_071a;
						IL_071a:
						if (DC_Main.i <= num20)
						{
							goto IL_0667;
						}
						goto IL_084e;
						IL_0667:
						num2 = 53;
						num21 = ((DataGridView)DGV_MONTH).ColumnCount - 1;
						num22 = 0;
						goto IL_0702;
						IL_0702:
						if (num22 <= num21)
						{
							goto IL_0681;
						}
						goto IL_070b;
						IL_070b:
						num2 = 58;
						DC_Main.i++;
						goto IL_071a;
						IL_0681:
						num2 = 54;
						if (((DataGridView)DGV_MONTH)[num22, DC_Main.i].Value != null)
						{
							goto IL_06a4;
						}
						goto IL_06f9;
						IL_06a4:
						num2 = 55;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num22 + 1,
							((DataGridView)DGV_MONTH)[num22, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_06f9;
						IL_06f9:
						num2 = 57;
						num22++;
						goto IL_0702;
						IL_05f3:
						num2 = 50;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num19 + 1,
							((DataGridView)DGV_MONTH).Columns[num19].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_063b;
						IL_063b:
						num2 = 51;
						num19++;
						goto IL_0644;
						IL_072d:
						num2 = 60;
						num23 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num12 = 0;
						goto IL_0795;
						IL_0795:
						if (num12 <= num23)
						{
							goto IL_0744;
						}
						goto IL_079b;
						IL_079b:
						num2 = 63;
						num24 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0840;
						IL_0840:
						if (DC_Main.i <= num24)
						{
							goto IL_07b8;
						}
						goto IL_084e;
						IL_084e:
						num2 = 70;
						colorConverter = new ColorConverter();
						goto IL_0858;
						IL_0858:
						num2 = 71;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_08ab;
						IL_08ab:
						num2 = 72;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0900;
						IL_0900:
						num2 = 73;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_0958;
						IL_0958:
						num2 = 74;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_09c6;
						IL_09c6:
						num2 = 75;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0a09;
						IL_0a09:
						num2 = 76;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0a38;
						IL_0a38:
						num2 = 77;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0a7b;
						IL_0a7b:
						num2 = 78;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0abc;
						IL_0abc:
						num2 = 79;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0add;
						IL_0add:
						num2 = 80;
						Cursor.Current = Cursors.Default;
						goto IL_0aeb;
						IL_0aeb:
						num2 = 81;
						obj = null;
						goto IL_0af1;
						IL_0af1:
						num2 = 82;
						obj3 = null;
						goto IL_0af7;
						IL_0af7:
						num2 = 83;
						obj2 = null;
						break;
						IL_07b8:
						num2 = 64;
						num6 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_082b;
						end_IL_0001_2:
						break;
					}
					num2 = 84;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 3182;
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
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
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
		double num = 0.0;
		double num2 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " and {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			DC_Main.MsCrForName1 = "FromDate";
			DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
			DC_Main.MsCrForName2 = "ToDate";
			DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName3 = "OpBal";
			DC_Main.MsCrForVal3 = Strings.Format((object)num, "0.00");
			DC_Main.MsCrForName4 = "ClBal";
			DC_Main.MsCrForVal4 = Strings.Format((object)num2, "0.00");
			DC_Main.RptName = "JmUdAmt";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdAmt.RPT";
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num2, "0.00")) ?? "";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
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

	private void RP_LEDR_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_1379: Unknown result type (might be due to invalid IL or missing references)
		//IL_1380: Expected O, but got Unknown
		//IL_13f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ff: Expected O, but got Unknown
		//IL_14af: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ba: Expected O, but got Unknown
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_152d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1533: Expected O, but got Unknown
		//IL_15a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ac: Expected O, but got Unknown
		//IL_1634: Unknown result type (might be due to invalid IL or missing references)
		//IL_1639: Unknown result type (might be due to invalid IL or missing references)
		//IL_1643: Expected O, but got Unknown
		//IL_16b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c0: Expected O, but got Unknown
		//IL_1772: Unknown result type (might be due to invalid IL or missing references)
		//IL_1777: Unknown result type (might be due to invalid IL or missing references)
		//IL_1781: Expected O, but got Unknown
		//IL_17a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17af: Expected O, but got Unknown
		//IL_17ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17dd: Expected O, but got Unknown
		//IL_185f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1864: Unknown result type (might be due to invalid IL or missing references)
		//IL_186e: Expected O, but got Unknown
		//IL_188d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1892: Unknown result type (might be due to invalid IL or missing references)
		//IL_189c: Expected O, but got Unknown
		//IL_18bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ca: Expected O, but got Unknown
		//IL_194c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1951: Unknown result type (might be due to invalid IL or missing references)
		//IL_195b: Expected O, but got Unknown
		//IL_197a: Unknown result type (might be due to invalid IL or missing references)
		//IL_197f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1989: Expected O, but got Unknown
		//IL_19a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b7: Expected O, but got Unknown
		//IL_1a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a48: Expected O, but got Unknown
		//IL_1a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a76: Expected O, but got Unknown
		//IL_1a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa4: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)PnlAcSumm).Controls)
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
			foreach (object control4 in ((Control)Panel1).Controls)
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
				((Form)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				CheckBox obj6 = chkZero;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj6).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				CheckBox obj8 = chkZero;
				object? obj9 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj8).ForeColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				CheckBox obj10 = chkOpBal;
				object? obj11 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				CheckBox obj12 = chkOpBal;
				object? obj13 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				CheckBox obj14 = chkVchSum;
				object? obj15 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				CheckBox obj16 = chkVchSum;
				object? obj17 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj16).ForeColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				((ButtonBase)chkHalfMonth).BackColor = Color.Silver;
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj18 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
				object? obj19 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_MONTH = DGV_MONTH;
				object? obj21 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_MONTH).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_MONTH).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
				object? obj23 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj24 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj25 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj26 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				ComboBox obj27 = cboCity;
				object? obj28 = colorConverter.ConvertFromString("243, 240, 239");
				obj27.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				ComboBox obj29 = cboArea;
				object? obj30 = colorConverter.ConvertFromString("243, 240, 239");
				obj29.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				ComboBox obj31 = cboState;
				object? obj32 = colorConverter.ConvertFromString("243, 240, 239");
				obj31.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				ComboBox obj33 = cboFineType;
				object? obj34 = colorConverter.ConvertFromString("243, 240, 239");
				obj33.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				ComboBox obj35 = cboCrDr;
				object? obj36 = colorConverter.ConvertFromString("243, 240, 239");
				obj35.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				((Control)lblAdd1).ForeColor = Color.Black;
				((Control)lblMobile).ForeColor = Color.Black;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj37 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((ButtonBase)chkZero).BackColor = Color.LightSlateGray;
				((Control)chkZero).ForeColor = Color.White;
				((ButtonBase)chkOpBal).BackColor = Color.LightSlateGray;
				((Control)chkOpBal).ForeColor = Color.White;
				((ButtonBase)chkOpBal).BackColor = Color.LightSlateGray;
				((Control)chkVchSum).ForeColor = Color.White;
				((ButtonBase)chkVchSum).BackColor = Color.LightSlateGray;
				CheckBox obj38 = chkHalfMonth;
				object? obj39 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj38).BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				((Control)PnlBotam).BackColor = Color.LightSlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC2 = DGV_AC;
				object? obj40 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj41 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_MONTH2 = DGV_MONTH;
				object? obj42 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_MONTH2).BackgroundColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_MONTH).AlternatingRowsDefaultCellStyle;
				object? obj43 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj44 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj45 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj46 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj47 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				ComboBox obj48 = cboCity;
				object? obj49 = colorConverter.ConvertFromString("233, 235, 240");
				obj48.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				ComboBox obj50 = cboArea;
				object? obj51 = colorConverter.ConvertFromString("233, 235, 240");
				obj50.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
				ComboBox obj52 = cboState;
				object? obj53 = colorConverter.ConvertFromString("233, 235, 240");
				obj52.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
				ComboBox obj54 = cboFineType;
				object? obj55 = colorConverter.ConvertFromString("233, 235, 240");
				obj54.BackColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
				ComboBox obj56 = cboCrDr;
				object? obj57 = colorConverter.ConvertFromString("233, 235, 240");
				obj56.BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj58 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj58 != null) ? ((Color)obj58) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj59 = lblBook;
				object? obj60 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj59).ForeColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
				((ButtonBase)chkZero).BackColor = Color.Cornsilk;
				CheckBox obj61 = chkZero;
				object? obj62 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj61).ForeColor = ((obj62 != null) ? ((Color)obj62) : default(Color));
				((ButtonBase)chkOpBal).BackColor = Color.Cornsilk;
				CheckBox obj63 = chkOpBal;
				object? obj64 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj63).ForeColor = ((obj64 != null) ? ((Color)obj64) : default(Color));
				((ButtonBase)chkVchSum).BackColor = Color.Cornsilk;
				CheckBox obj65 = chkVchSum;
				object? obj66 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj65).ForeColor = ((obj66 != null) ? ((Color)obj66) : default(Color));
				CheckBox obj67 = chkHalfMonth;
				object? obj68 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj67).BackColor = ((obj68 != null) ? ((Color)obj68) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj69 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj69 != null) ? ((Color)obj69) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC3 = DGV_AC;
				object? obj70 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj70 != null) ? ((Color)obj70) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj71 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj71 != null) ? ((Color)obj71) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_MONTH3 = DGV_MONTH;
				object? obj72 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_MONTH3).BackgroundColor = ((obj72 != null) ? ((Color)obj72) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle10 = ((DataGridView)DGV_MONTH).AlternatingRowsDefaultCellStyle;
				object? obj73 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle10.BackColor = ((obj73 != null) ? ((Color)obj73) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj74 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj74 != null) ? ((Color)obj74) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle11 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj75 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle11.BackColor = ((obj75 != null) ? ((Color)obj75) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj76 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj76 != null) ? ((Color)obj76) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle12 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj77 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle12.BackColor = ((obj77 != null) ? ((Color)obj77) : default(Color));
				cboCity.BackColor = Color.Cornsilk;
				cboArea.BackColor = Color.Cornsilk;
				cboState.BackColor = Color.Cornsilk;
				cboFineType.BackColor = Color.Cornsilk;
				cboCrDr.BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcGrCode).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
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
				num3 = (int)Math.Ceiling((double)((Control)tAcGrCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tAcGrCode).Font;
				try
				{
					foreach (object control6 in ((Control)PnlAcSumm).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control7 in ((Control)PnlMonth).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control8 in ((Control)Panel1).Controls)
					{
						object objectValue6 = RuntimeHelpers.GetObjectValue(control8);
						NewLateBinding.LateSet(objectValue6, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control9 in ((Control)PnlBotam).Controls)
					{
						object objectValue7 = RuntimeHelpers.GetObjectValue(control9);
						NewLateBinding.LateSet(objectValue7, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).Font.Style);
					((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).Font.Style);
					((DataGridView)DGV_AC).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_AC).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_AC).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_AC).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_VCH).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_VCH).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_VCH).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_MONTH).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_MONTH).Font.Style);
					((DataGridView)DGV_MONTH).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_MONTH).Font.Style);
					((DataGridView)DGV_MONTH).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_MONTH).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_MONTH).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_MONTH).RowTemplate.Height * (1.0 + num2));
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM074NBDM", false) == 0)
			{
				chkZero.Checked = true;
			}
			if (Operators.CompareString(CurRpt, "Mfg Ledger", false) == 0)
			{
			}
			DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
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
				DC_Main.X = 1;
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
			DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				int num6 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num6)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
			}
			if (Operators.CompareString(DC_Main.MsLdrSumm, "Y", false) == 0)
			{
				chkVchSum.Checked = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ024NEKJ", false) == 0)
			{
				chkVchSum.Checked = false;
				((Control)chkVchSum).Visible = false;
			}
			if (Operators.CompareString(DC_Main.MsMetalType, "S", false) != 0)
			{
				((Control)chkGoldCol).Visible = false;
			}
			cboFineType.Items.Add((object)"Gold");
			cboFineType.Items.Add((object)"Silver");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboFineType.SelectedIndex = 0;
			}
			else
			{
				cboFineType.SelectedIndex = 1;
			}
			cboAcType.Items.Add((object)"");
			cboAcType.Items.Add((object)"A");
			cboAcType.Items.Add((object)"B");
			cboAcType.Items.Add((object)"C");
			cboAcType.Items.Add((object)"D");
			cboAcType.Items.Add((object)"E");
			cboAcType.SelectedIndex = 0;
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			cboCrDr.Items.Add((object)"Dr");
			cboCrDr.SelectedIndex = 0;
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				((Control)brnOsDay).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0))
			{
				((Control)BtnTimeWise).Visible = false;
			}
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				BtnJmaUdhar.Text = "Ac Sale";
			}
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			CurActCtrl = (Control)(object)tSearch;
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
		chkZero.Checked = false;
		tSearch.Text = "";
		((Control)tSerchAll).ResetText();
		((Control)tAcGrCode).ResetText();
		cboArea.Text = "";
		cboState.Text = "";
		cboCity.Text = "";
		MainAcCode = "";
		((Control)pnlVchDesc).Visible = false;
		tVchdesc.Text = "Vch Desc :";
		DgvAcEnter = false;
		mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)BtnDelete).Visible = false;
		((Control)BtnJmaUdhar).Visible = false;
		((Control)btnPurcRpt).Visible = false;
		((Control)BtnGold).Visible = false;
		((Control)BtnSilver).Visible = false;
		((Control)PnlAcSumm).Visible = true;
		((Control)DgvTot).Visible = true;
		tLcCode.Text = DC_Main.MLc_code;
		if (DC_Main.MsLcBoxShow)
		{
			((Control)tLcCode).Visible = true;
		}
		BtnExit.Text = "E&xit";
		BtnCancel.Text = "&Cancel";
		((Control)PnlMonth).Visible = false;
		((Control)DGV_MONTH).Visible = false;
		DgvDtlRow = 0;
		DGV_FILL();
		AcSumm();
		((Control)tSearch).Focus();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV_AC).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Expected O, but got Unknown
		//IL_0f20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2a: Expected O, but got Unknown
		//IL_0f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f84: Expected O, but got Unknown
		//IL_1174: Unknown result type (might be due to invalid IL or missing references)
		//IL_1235: Unknown result type (might be due to invalid IL or missing references)
		//IL_123a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Expected O, but got Unknown
		//IL_126c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Unknown result type (might be due to invalid IL or missing references)
		//IL_127b: Expected O, but got Unknown
		//IL_12a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b2: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataView dataView = default(DataView);
		double num5 = default(double);
		double num6 = default(double);
		double num7 = default(double);
		double num8 = default(double);
		double num9 = default(double);
		double num10 = default(double);
		int num11 = default(int);
		int num12 = default(int);
		int num13 = default(int);
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
						DGV_CLEAR();
						goto IL_000b;
					case 5707:
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
								goto IL_0019;
							case 4:
								goto IL_002d;
							case 5:
								goto IL_003c;
							case 6:
								goto IL_004b;
							case 7:
								goto IL_006e;
							case 8:
								goto IL_008c;
							case 9:
								goto IL_00b3;
							case 10:
								goto IL_00db;
							case 11:
								goto IL_0103;
							case 12:
							case 13:
								goto IL_011e;
							case 14:
								goto IL_012f;
							case 15:
								goto IL_015f;
							case 16:
								goto IL_017e;
							case 17:
								goto IL_019d;
							case 18:
								goto IL_01b8;
							case 19:
								goto IL_01d7;
							case 20:
								goto IL_01f6;
							case 21:
								goto IL_0226;
							case 22:
								goto IL_0245;
							case 23:
								goto IL_0264;
							case 24:
								goto IL_027f;
							case 25:
								goto IL_029e;
							case 26:
								goto IL_02bd;
							case 27:
								goto IL_02ed;
							case 28:
								goto IL_030c;
							case 29:
								goto IL_032b;
							case 30:
								goto IL_035b;
							case 31:
								goto IL_037a;
							case 32:
								goto IL_03bb;
							case 33:
								goto IL_03dc;
							case 34:
								goto IL_0422;
							case 35:
								goto IL_0452;
							case 36:
								goto IL_0471;
							case 37:
								goto IL_04b2;
							case 38:
								goto IL_04d3;
							case 39:
								goto IL_0519;
							case 40:
								goto IL_0549;
							case 41:
								goto IL_0568;
							case 42:
								goto IL_05a9;
							case 43:
								goto IL_05ca;
							case 44:
								goto IL_05ee;
							case 45:
								goto IL_061e;
							case 46:
								goto IL_063d;
							case 47:
								goto IL_067e;
							case 48:
								goto IL_069f;
							case 49:
								goto IL_06c3;
							case 50:
								goto IL_06f4;
							case 51:
								goto IL_0714;
							case 52:
								goto IL_0734;
							case 53:
								goto IL_0756;
							case 54:
								goto IL_079d;
							case 55:
								goto IL_07ce;
							case 56:
								goto IL_07ee;
							case 57:
								goto IL_080e;
							case 58:
								goto IL_0830;
							case 59:
								goto IL_0877;
							case 60:
								goto IL_0893;
							case 61:
								goto IL_08b3;
							case 62:
								goto IL_08d2;
							case 63:
								goto IL_08ee;
							case 64:
								goto IL_090e;
							case 65:
								goto IL_092e;
							case 66:
								goto IL_094a;
							case 67:
								goto IL_096a;
							case 68:
								goto IL_098a;
							case 69:
								goto IL_09a6;
							case 70:
								goto IL_09c6;
							case 71:
								goto IL_09e6;
							case 72:
								goto IL_09ff;
							case 73:
							case 74:
								goto IL_0a26;
							case 75:
								goto IL_0a36;
							case 76:
								goto IL_0a58;
							case 77:
								goto IL_0af9;
							case 78:
								goto IL_0b03;
							case 79:
							case 80:
							case 81:
								goto IL_0b11;
							case 82:
								goto IL_0b1f;
							case 83:
								goto IL_0b2d;
							case 84:
								goto IL_0b3b;
							case 85:
								goto IL_0b49;
							case 86:
								goto IL_0b57;
							case 87:
								goto IL_0b65;
							case 88:
								goto IL_0b84;
							case 89:
								goto IL_0bc7;
							case 90:
								goto IL_0c00;
							case 91:
								goto IL_0c39;
							case 92:
								goto IL_0c72;
							case 93:
								goto IL_0cab;
							case 94:
								goto IL_0ce5;
							case 95:
							case 96:
								goto IL_0d21;
							case 97:
								goto IL_0d33;
							case 98:
								goto IL_0d4a;
							case 99:
								goto IL_0d75;
							case 100:
								goto IL_0dac;
							case 101:
								goto IL_0de3;
							case 102:
								goto IL_0e1a;
							case 103:
								goto IL_0e51;
							case 104:
								goto IL_0eab;
							case 105:
							case 106:
								goto IL_0f07;
							case 107:
								goto IL_0f2b;
							case 108:
								goto IL_0f41;
							case 109:
								goto IL_0f5d;
							case 110:
								goto IL_0f85;
							case 111:
							case 112:
								goto IL_0fa0;
							case 113:
								goto IL_0fa9;
							case 114:
								goto IL_0fb9;
							case 115:
								goto IL_0fc8;
							case 116:
								goto IL_0fdc;
							case 117:
								goto IL_0ff0;
							case 118:
								goto IL_0fff;
							case 119:
								goto IL_100f;
							case 120:
								goto IL_102d;
							case 121:
								goto IL_1041;
							case 122:
								goto IL_1051;
							case 123:
								goto IL_1066;
							case 124:
								goto IL_107a;
							case 125:
								goto IL_1097;
							case 126:
								goto IL_10b5;
							case 127:
								goto IL_10ed;
							case 128:
								goto IL_113a;
							case 129:
								goto IL_117f;
							case 130:
								goto IL_11a8;
							case 131:
								goto IL_11ca;
							case 132:
							case 133:
								goto IL_11ea;
							case 134:
								goto IL_1209;
							case 135:
								goto IL_1245;
							case 136:
								goto IL_127c;
							case 137:
								goto IL_12b3;
							case 138:
								goto IL_12dd;
							case 139:
							case 140:
								goto IL_1313;
							case 141:
								goto IL_1328;
							case 142:
								goto IL_134f;
							case 143:
							case 144:
							case 145:
								goto IL_1381;
							case 146:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 147:
							case 148:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_1328:
						num2 = 141;
						if (((DataGridView)DGV_AC).Rows.Count >= DgvCurRow)
						{
							goto IL_134f;
						}
						goto IL_1381;
						IL_134f:
						num2 = 142;
						((DataGridView)DGV_AC).Rows[DgvCurRow].Cells[2].Selected = true;
						goto IL_1381;
						IL_1313:
						num2 = 140;
						if (DgvCurRow > 0)
						{
							goto IL_1328;
						}
						goto IL_1381;
						IL_1381:
						num2 = 145;
						if (!((Operators.CompareString(DC_Main.MsRptTotShow, "Y", false) == 0) & (((DataGridView)DGV_AC).RowCount > 1)))
						{
							goto end_IL_0001_3;
						}
						break;
						IL_000b:
						num2 = 2;
						dataView = new DataView(RsAcSum);
						goto IL_0019;
						IL_0019:
						num2 = 3;
						if (dataView.Count > 0)
						{
							goto IL_002d;
						}
						goto IL_0f07;
						IL_002d:
						num2 = 4;
						((DataGridView)DGV_AC).MultiSelect = false;
						goto IL_003c;
						IL_003c:
						num2 = 5;
						((DataGridView)DGV_AC).AutoGenerateColumns = false;
						goto IL_004b;
						IL_004b:
						num2 = 6;
						((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
						goto IL_006e;
						IL_006e:
						num2 = 7;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_008c;
						}
						goto IL_011e;
						IL_008c:
						num2 = 8;
						((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_00b3;
						IL_00b3:
						num2 = 9;
						((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_00db;
						IL_00db:
						num2 = 10;
						((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0103;
						IL_0103:
						num2 = 11;
						((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_011e;
						IL_011e:
						num2 = 13;
						((DataGridView)DGV_AC).ColumnCount = 15;
						goto IL_012f;
						IL_012f:
						num2 = 14;
						((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_015f;
						IL_015f:
						num2 = 15;
						((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
						goto IL_017e;
						IL_017e:
						num2 = 16;
						((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
						goto IL_019d;
						IL_019d:
						num2 = 17;
						((DataGridView)DGV_AC).Columns[1].Visible = false;
						goto IL_01b8;
						IL_01b8:
						num2 = 18;
						((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
						goto IL_01d7;
						IL_01d7:
						num2 = 19;
						((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
						goto IL_01f6;
						IL_01f6:
						num2 = 20;
						((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(315.0 * ColCon);
						goto IL_0226;
						IL_0226:
						num2 = 21;
						((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
						goto IL_0245;
						IL_0245:
						num2 = 22;
						((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
						goto IL_0264;
						IL_0264:
						num2 = 23;
						((DataGridView)DGV_AC).Columns[3].Visible = false;
						goto IL_027f;
						IL_027f:
						num2 = 24;
						((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_ADD1";
						goto IL_029e;
						IL_029e:
						num2 = 25;
						((DataGridView)DGV_AC).Columns[3].HeaderText = "Address1";
						goto IL_02bd;
						IL_02bd:
						num2 = 26;
						((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
						goto IL_02ed;
						IL_02ed:
						num2 = 27;
						((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_MOBILE";
						goto IL_030c;
						IL_030c:
						num2 = 28;
						((DataGridView)DGV_AC).Columns[4].HeaderText = "Mobile";
						goto IL_032b;
						IL_032b:
						num2 = 29;
						((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
						goto IL_035b;
						IL_035b:
						num2 = 30;
						((DataGridView)DGV_AC).Columns[6].DataPropertyName = "CrAmt";
						goto IL_037a;
						IL_037a:
						num2 = 31;
						((DataGridView)DGV_AC).Columns[6].HeaderText = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM565NEHP", false) == 0, (object)"JamaAmt", (object)"CrAmt"));
						goto IL_03bb;
						IL_03bb:
						num2 = 32;
						((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_03dc;
						IL_03dc:
						num2 = 33;
						((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0, (object)"0.00", (object)"N2"));
						goto IL_0422;
						IL_0422:
						num2 = 34;
						((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
						goto IL_0452;
						IL_0452:
						num2 = 35;
						((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DrAmt";
						goto IL_0471;
						IL_0471:
						num2 = 36;
						((DataGridView)DGV_AC).Columns[5].HeaderText = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM565NEHP", false) == 0, (object)"NaveAmt", (object)"DrAmt"));
						goto IL_04b2;
						IL_04b2:
						num2 = 37;
						((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_04d3;
						IL_04d3:
						num2 = 38;
						((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0, (object)"0.00", (object)"N2"));
						goto IL_0519;
						IL_0519:
						num2 = 39;
						((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0549;
						IL_0549:
						num2 = 40;
						((DataGridView)DGV_AC).Columns[8].DataPropertyName = "CrGold";
						goto IL_0568;
						IL_0568:
						num2 = 41;
						((DataGridView)DGV_AC).Columns[8].HeaderText = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM565NEHP", false) == 0, (object)"JamaGold", (object)"CrGold"));
						goto IL_05a9;
						IL_05a9:
						num2 = 42;
						((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_05ca;
						IL_05ca:
						num2 = 43;
						((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
						goto IL_05ee;
						IL_05ee:
						num2 = 44;
						((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_061e;
						IL_061e:
						num2 = 45;
						((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DrGold";
						goto IL_063d;
						IL_063d:
						num2 = 46;
						((DataGridView)DGV_AC).Columns[7].HeaderText = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM565NEHP", false) == 0, (object)"NaveGold", (object)"DrGold"));
						goto IL_067e;
						IL_067e:
						num2 = 47;
						((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_069f;
						IL_069f:
						num2 = 48;
						((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
						goto IL_06c3;
						IL_06c3:
						num2 = 49;
						((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_06f4;
						IL_06f4:
						num2 = 50;
						((DataGridView)DGV_AC).Columns[10].DataPropertyName = "CrSilver";
						goto IL_0714;
						IL_0714:
						num2 = 51;
						((DataGridView)DGV_AC).Columns[10].HeaderText = "CrSilver";
						goto IL_0734;
						IL_0734:
						num2 = 52;
						((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0756;
						IL_0756:
						num2 = 53;
						((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"N3", (object)"N2"));
						goto IL_079d;
						IL_079d:
						num2 = 54;
						((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_07ce;
						IL_07ce:
						num2 = 55;
						((DataGridView)DGV_AC).Columns[9].DataPropertyName = "DrSilver";
						goto IL_07ee;
						IL_07ee:
						num2 = 56;
						((DataGridView)DGV_AC).Columns[9].HeaderText = "DrSilver";
						goto IL_080e;
						IL_080e:
						num2 = 57;
						((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0830;
						IL_0830:
						num2 = 58;
						((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"N3", (object)"N2"));
						goto IL_0877;
						IL_0877:
						num2 = 59;
						((DataGridView)DGV_AC).Columns[11].Visible = false;
						goto IL_0893;
						IL_0893:
						num2 = 60;
						((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_REFBY";
						goto IL_08b3;
						IL_08b3:
						num2 = 61;
						((DataGridView)DGV_AC).Columns[3].HeaderText = "RefBy";
						goto IL_08d2;
						IL_08d2:
						num2 = 62;
						((DataGridView)DGV_AC).Columns[12].Visible = false;
						goto IL_08ee;
						IL_08ee:
						num2 = 63;
						((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_CITY";
						goto IL_090e;
						IL_090e:
						num2 = 64;
						((DataGridView)DGV_AC).Columns[12].HeaderText = "City";
						goto IL_092e;
						IL_092e:
						num2 = 65;
						((DataGridView)DGV_AC).Columns[13].Visible = false;
						goto IL_094a;
						IL_094a:
						num2 = 66;
						((DataGridView)DGV_AC).Columns[13].DataPropertyName = "AC_KHATA_NO";
						goto IL_096a;
						IL_096a:
						num2 = 67;
						((DataGridView)DGV_AC).Columns[13].HeaderText = "KhataNo";
						goto IL_098a;
						IL_098a:
						num2 = 68;
						((DataGridView)DGV_AC).Columns[14].Visible = false;
						goto IL_09a6;
						IL_09a6:
						num2 = 69;
						((DataGridView)DGV_AC).Columns[14].DataPropertyName = "AC_KHATA_NO";
						goto IL_09c6;
						IL_09c6:
						num2 = 70;
						((DataGridView)DGV_AC).Columns[13].HeaderText = "Remark";
						goto IL_09e6;
						IL_09e6:
						num2 = 71;
						if (DC_Main.ScreenHight > 1.0)
						{
							goto IL_09ff;
						}
						goto IL_0a26;
						IL_09ff:
						num2 = 72;
						((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
						goto IL_0a26;
						IL_0a26:
						num2 = 74;
						((DataGridView)DGV_AC).DataSource = dataView;
						goto IL_0a36;
						IL_0a36:
						num2 = 75;
						if (((DataGridView)DGV_AC).Rows.Count >= 1)
						{
							goto IL_0a58;
						}
						goto IL_0b11;
						IL_0a58:
						num2 = 76;
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
						{
							goto IL_0af9;
						}
						goto IL_0b11;
						IL_0af9:
						num2 = 77;
						dataView.AddNew();
						goto IL_0b03;
						IL_0b03:
						num2 = 78;
						dataView.AddNew();
						goto IL_0b11;
						IL_0b11:
						num2 = 81;
						num5 = 0.0;
						goto IL_0b1f;
						IL_0b1f:
						num2 = 82;
						num6 = 0.0;
						goto IL_0b2d;
						IL_0b2d:
						num2 = 83;
						num7 = 0.0;
						goto IL_0b3b;
						IL_0b3b:
						num2 = 84;
						num8 = 0.0;
						goto IL_0b49;
						IL_0b49:
						num2 = 85;
						num9 = 0.0;
						goto IL_0b57;
						IL_0b57:
						num2 = 86;
						num10 = 0.0;
						goto IL_0b65;
						IL_0b65:
						num2 = 87;
						num11 = ((DataGridView)DGV_AC).Rows.Count - 1;
						num12 = 0;
						goto IL_0d2a;
						IL_0d2a:
						if (num12 <= num11)
						{
							goto IL_0b84;
						}
						goto IL_0d33;
						IL_0d33:
						num2 = 97;
						num13 = ((DataGridView)DGV_AC).Rows.Count - 1;
						goto IL_0d4a;
						IL_0d4a:
						num2 = 98;
						((DataGridView)DGV_AC).Rows[num13].Cells[2].Value = "Total :";
						goto IL_0d75;
						IL_0d75:
						num2 = 99;
						((DataGridView)DGV_AC).Rows[num13].Cells[6].Value = Strings.Format((object)num5, "0.00");
						goto IL_0dac;
						IL_0dac:
						num2 = 100;
						((DataGridView)DGV_AC).Rows[num13].Cells[5].Value = Strings.Format((object)num6, "0.00");
						goto IL_0de3;
						IL_0de3:
						num2 = 101;
						((DataGridView)DGV_AC).Rows[num13].Cells[8].Value = Strings.Format((object)num7, "0.000");
						goto IL_0e1a;
						IL_0e1a:
						num2 = 102;
						((DataGridView)DGV_AC).Rows[num13].Cells[7].Value = Strings.Format((object)num8, "0.000");
						goto IL_0e51;
						IL_0e51:
						num2 = 103;
						((DataGridView)DGV_AC).Rows[num13].Cells[10].Value = Strings.Format((object)num9, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")));
						goto IL_0eab;
						IL_0eab:
						num2 = 104;
						((DataGridView)DGV_AC).Rows[num13].Cells[9].Value = Strings.Format((object)num10, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")));
						goto IL_0f07;
						IL_0b84:
						num2 = 88;
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[1].Value, (object)""), (object)"Total :", false))
						{
							goto IL_0bc7;
						}
						goto IL_0d21;
						IL_0bc7:
						num2 = 89;
						num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[6].Value, (object)""));
						goto IL_0c00;
						IL_0c00:
						num2 = 90;
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[5].Value, (object)""));
						goto IL_0c39;
						IL_0c39:
						num2 = 91;
						num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[8].Value, (object)""));
						goto IL_0c72;
						IL_0c72:
						num2 = 92;
						num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[7].Value, (object)""));
						goto IL_0cab;
						IL_0cab:
						num2 = 93;
						num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[10].Value, (object)""));
						goto IL_0ce5;
						IL_0ce5:
						num2 = 94;
						num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[num12].Cells[9].Value, (object)""));
						goto IL_0d21;
						IL_0d21:
						num2 = 96;
						num12++;
						goto IL_0d2a;
						IL_0f07:
						num2 = 106;
						((DataGridView)DgvTot).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f, (FontStyle)0);
						goto IL_0f2b;
						IL_0f2b:
						num2 = 107;
						((DataGridView)DgvTot).RowTemplate.Height = 25;
						goto IL_0f41;
						IL_0f41:
						num2 = 108;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_0f5d;
						}
						goto IL_0fa0;
						IL_0f5d:
						num2 = 109;
						((DataGridView)DgvTot).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0f85;
						IL_0f85:
						num2 = 110;
						((DataGridView)DgvTot).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_0fa0;
						IL_0fa0:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0fa9;
						IL_0fa9:
						num2 = 113;
						((DataGridView)DgvTot).DataSource = null;
						goto IL_0fb9;
						IL_0fb9:
						num2 = 114;
						((DataGridView)DgvTot).ClearSelection();
						goto IL_0fc8;
						IL_0fc8:
						num2 = 115;
						((DataGridView)DgvTot).Rows.Clear();
						goto IL_0fdc;
						IL_0fdc:
						num2 = 116;
						((DataGridView)DgvTot).Columns.Clear();
						goto IL_0ff0;
						IL_0ff0:
						num2 = 117;
						((Control)DgvTot).Refresh();
						goto IL_0fff;
						IL_0fff:
						num2 = 118;
						((DataGridView)DgvTot).ColumnHeadersVisible = false;
						goto IL_100f;
						IL_100f:
						num2 = 119;
						((DataGridView)DgvTot).Columns.Add("", "");
						goto IL_102d;
						IL_102d:
						num2 = 120;
						((DataGridView)DgvTot).Rows.Add();
						goto IL_1041;
						IL_1041:
						num2 = 121;
						((DataGridView)DgvTot).ScrollBars = (ScrollBars)0;
						goto IL_1051;
						IL_1051:
						num2 = 122;
						DC_Main.R = ((DataGridView)DGV_AC).RowCount - 1;
						goto IL_1066;
						IL_1066:
						num2 = 123;
						if (DC_Main.R > 0)
						{
							goto IL_107a;
						}
						goto IL_11ea;
						IL_107a:
						num2 = 124;
						num14 = ((DataGridView)DGV_AC).ColumnCount - 1;
						DC_Main.i = 0;
						goto IL_11dc;
						IL_11dc:
						if (DC_Main.i <= num14)
						{
							goto IL_1097;
						}
						goto IL_11ea;
						IL_1097:
						num2 = 125;
						((DataGridView)DgvTot).Columns.Add("", "");
						goto IL_10b5;
						IL_10b5:
						num2 = 126;
						((DataGridView)DgvTot).Columns[DC_Main.i].Width = ((DataGridView)DGV_AC).Columns[DC_Main.i].Width;
						goto IL_10ed;
						IL_10ed:
						num2 = 127;
						((DataGridView)DgvTot)[DC_Main.i, 0].Value = Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[DC_Main.R].Cells[DC_Main.i].Value, (object)"");
						goto IL_113a;
						IL_113a:
						num2 = 128;
						((DataGridView)DgvTot).Columns[DC_Main.i].DefaultCellStyle.Alignment = ((DataGridView)DGV_AC).Columns[DC_Main.i].DefaultCellStyle.Alignment;
						goto IL_117f;
						IL_117f:
						num2 = 129;
						if (!((DataGridView)DGV_AC).Columns[DC_Main.i].Visible)
						{
							goto IL_11a8;
						}
						goto IL_11ca;
						IL_11a8:
						num2 = 130;
						((DataGridView)DgvTot).Columns[DC_Main.i].Visible = false;
						goto IL_11ca;
						IL_11ca:
						num2 = 131;
						DC_Main.i++;
						goto IL_11dc;
						IL_11ea:
						num2 = 133;
						if (DC_Main.ScreenHight > 1.0)
						{
							goto IL_1209;
						}
						goto IL_1313;
						IL_1209:
						num2 = 134;
						((DataGridView)DgvTot).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)DC_Main.HaderFont, ((DataGridView)DgvTot).ColumnHeadersDefaultCellStyle.Font.Style);
						goto IL_1245;
						IL_1245:
						num2 = 135;
						((DataGridView)DgvTot).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)DC_Main.HaderFont, ((DataGridView)DgvTot).Font.Style);
						goto IL_127c;
						IL_127c:
						num2 = 136;
						((DataGridView)DgvTot).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)DC_Main.HaderFont, ((DataGridView)DgvTot).Font.Style);
						goto IL_12b3;
						IL_12b3:
						num2 = 137;
						((DataGridView)DgvTot).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DgvTot).ColumnHeadersHeight * DC_Main.ScreenHight);
						goto IL_12dd;
						IL_12dd:
						num2 = 138;
						((DataGridView)DgvTot).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DgvTot).RowTemplate.Height * DC_Main.ScreenHight);
						goto IL_1313;
						end_IL_0001_2:
						break;
					}
					num2 = 146;
					((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).RowCount - 1].Cells[0].Selected = true;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 5707;
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

	private void DGV_AC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 5) <= 5u && Conversions.ToDouble(((ConvertEventArgs)e).Value.ToString()) == 0.0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 88:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_008e;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 88;
				continue;
			}
			break;
			IL_008e:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void tSearch_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		checked
		{
			if (((Control)PnlMonth).Visible)
			{
				if (!((Operators.CompareString(tSearch.Text, "", false) != 0) & (Operators.CompareString(tSearch.Text, "SEARCH RECORD", false) != 0)))
				{
					return;
				}
				int num = ((DataGridView)DGV_MONTH).Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (((DataGridView)DGV_MONTH)[1, i].Value != null && ((DataGridView)DGV_MONTH)[1, i].Value.ToString().ToUpper().StartsWith(tSearch.Text.ToUpper()))
					{
						((DataGridView)DGV_MONTH).CurrentCell = ((DataGridView)DGV_MONTH).Rows[i].Cells[1];
						((DataGridView)DGV_MONTH).Rows[i].Selected = true;
						break;
					}
				}
			}
			else if ((Operators.CompareString(tSearch.Text, "", false) == 0) & (Operators.CompareString(tSearch.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(tSearch.Text, "", false) != 0) & (Operators.CompareString(tSearch.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '" + tSearch.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(315.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Visible = false;
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "CrGold";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "CrGold";
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DrGold";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "DrGold";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[11].Visible = false;
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_REFBY";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "RefBy";
					((DataGridView)DGV_AC).Columns[12].Visible = false;
					((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[12].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[13].Visible = false;
					((DataGridView)DGV_AC).Columns[13].DataPropertyName = "AC_KHATA_NO";
					((DataGridView)DGV_AC).Columns[13].HeaderText = "KhataNo";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
		}
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		checked
		{
			if (((Control)PnlMonth).Visible)
			{
				if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
				{
					return;
				}
				int num = ((DataGridView)DGV_MONTH).Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (((DataGridView)DGV_MONTH)[2, i].Value != null && ((DataGridView)DGV_MONTH)[2, i].Value.ToString().ToUpper().StartsWith(((TextEdit)tSerchAll).Text.ToUpper()))
					{
						((DataGridView)DGV_MONTH).CurrentCell = ((DataGridView)DGV_MONTH).Rows[i].Cells[2];
						((DataGridView)DGV_MONTH).Rows[i].Selected = true;
						break;
					}
				}
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
			{
				((Control)tSerchAll).ResetText();
				DGV_FILL();
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '%" + ((TextEdit)tSerchAll).Text + "%' OR AC_MOBILE Like '%" + ((TextEdit)tSerchAll).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(315.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Visible = false;
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "CrGold";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "CrGold";
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DrGold";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "DrGold";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[11].Visible = false;
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_REFBY";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "RefBy";
					((DataGridView)DGV_AC).Columns[12].Visible = false;
					((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[12].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[13].Visible = false;
					((DataGridView)DGV_AC).Columns[13].DataPropertyName = "AC_KHATA_NO";
					((DataGridView)DGV_AC).Columns[13].HeaderText = "KhataNo";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
		{
			if (chkVchSum.Checked)
			{
				((DataGridView)DGV_DETL).DataSource = null;
				((DataGridView)DGV_DETL).ClearSelection();
				((DataGridView)DGV_DETL).Rows.Clear();
				((Control)DGV_DETL).Refresh();
				BtnExit.Text = "&Back";
				((Control)DGV_VCH).Visible = true;
				((Control)BtnGold).Visible = false;
				((Control)BtnSilver).Visible = false;
				((Control)BtnJmaUdhar).Visible = false;
				((Control)btnPurcRpt).Visible = false;
				((Control)BtnDelete).Visible = false;
				lblRefby.Text = "Ref By :";
				lblAdd1.Text = "";
				lblMobile.Text = "";
				((Control)pnlVchDesc).Visible = false;
				tVchdesc.Text = "Vch Desc :";
				if (((Control)PnlMonth).Visible)
				{
					((Control)DGV_MONTH).Visible = true;
					mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
				}
				return;
			}
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((DataGridView)DGV_DETL).Columns.Clear();
			((Control)DGV_DETL).Refresh();
			((Control)PnlAcSumm).Visible = true;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			if (((Control)PnlMonth).Visible)
			{
				((Control)DGV_MONTH).Visible = true;
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
			else
			{
				AcSumm();
			}
			BtnExit.Text = "E&xit";
			BtnCancel.Text = "&Cancel";
			((Control)BtnGold).Visible = false;
			((Control)BtnSilver).Visible = false;
			((Control)BtnJmaUdhar).Visible = false;
			((Control)btnPurcRpt).Visible = false;
			((Control)BtnDelete).Visible = false;
			BtnPrint.Text = "&Print";
			lblRefby.Text = "Ref By :";
			tVchdesc.Text = "Vch Desc :";
			lblAdd1.Text = "";
			lblMobile.Text = "";
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_VCH).DataSource = null;
			((DataGridView)DGV_VCH).ClearSelection();
			((DataGridView)DGV_VCH).Rows.Clear();
			((DataGridView)DGV_VCH).Columns.Clear();
			((Control)DGV_VCH).Refresh();
			((Control)PnlAcSumm).Visible = true;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			((Control)pnlVchDesc).Visible = false;
			tVchdesc.Text = "Vch Desc :";
			BtnExit.Text = "E&xit";
			BtnCancel.Text = "&Cancel";
			if (((Control)PnlMonth).Visible)
			{
				((Control)DGV_MONTH).Visible = true;
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
			else
			{
				AcSumm();
			}
			((Control)BtnGold).Visible = false;
			((Control)BtnSilver).Visible = false;
			((Control)BtnJmaUdhar).Visible = false;
			((Control)btnPurcRpt).Visible = false;
			((Control)BtnDelete).Visible = false;
			BtnPrint.Text = "&Print";
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_LEDR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_LEDR_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_LEDR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Invalid comparison between Unknown and I4
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)tSearch).Focus();
		}
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
			{
				if (chkVchSum.Checked)
				{
					((DataGridView)DGV_DETL).DataSource = null;
					((DataGridView)DGV_DETL).ClearSelection();
					((DataGridView)DGV_DETL).Rows.Clear();
					((Control)DGV_DETL).Refresh();
					BtnExit.Text = "&Back";
					((Control)DGV_VCH).Visible = true;
					((Control)BtnGold).Visible = false;
					((Control)BtnSilver).Visible = false;
					((Control)BtnJmaUdhar).Visible = false;
					((Control)btnPurcRpt).Visible = false;
					((Control)BtnDelete).Visible = false;
					lblRefby.Text = "Ref By :";
					lblAdd1.Text = "";
					lblMobile.Text = "";
				}
				else
				{
					((DataGridView)DGV_DETL).DataSource = null;
					((DataGridView)DGV_DETL).ClearSelection();
					((DataGridView)DGV_DETL).Rows.Clear();
					((DataGridView)DGV_DETL).Columns.Clear();
					((Control)DGV_DETL).Refresh();
					AcSumm();
					BtnExit.Text = "E&xit";
					((Control)PnlAcSumm).Visible = true;
					if (DC_Main.MsLcBoxShow)
					{
						((Control)tLcCode).Visible = true;
					}
					((Control)BtnGold).Visible = false;
					((Control)BtnSilver).Visible = false;
					((Control)BtnJmaUdhar).Visible = false;
					((Control)btnPurcRpt).Visible = false;
					((Control)BtnDelete).Visible = false;
					BtnPrint.Text = "&Print";
					lblRefby.Text = "Ref By :";
					lblAdd1.Text = "";
					lblMobile.Text = "";
				}
			}
			else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((DataGridView)DGV_VCH).Columns.Clear();
				((Control)DGV_VCH).Refresh();
				AcSumm();
				BtnExit.Text = "E&xit";
				((Control)PnlAcSumm).Visible = true;
				if (DC_Main.MsLcBoxShow)
				{
					((Control)tLcCode).Visible = true;
				}
				((Control)BtnGold).Visible = false;
				((Control)BtnSilver).Visible = false;
				((Control)BtnJmaUdhar).Visible = false;
				((Control)btnPurcRpt).Visible = false;
				((Control)BtnDelete).Visible = false;
				BtnPrint.Text = "&Print";
			}
			else
			{
				((Form)this).Close();
			}
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			if (((Control)PnlMonth).Visible)
			{
				((Control)DGV_MONTH).Focus();
			}
			else
			{
				((Control)DGV_AC).Focus();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0841: Invalid comparison between Unknown and I4
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
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
		checked
		{
			if (Operators.CompareString(BtnExit.Text, "E&xit", false) == 0)
			{
				if (Operators.CompareString(tLcCode.Text, "", false) == 0)
				{
					Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);
					return;
				}
				DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA");
				int num = ((DataGridView)DGV_AC).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[1].Value, (object)""), (object)"", false))
					{
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE, LC_CODE,CO_YEAR, VCH_DT, AC_CODE, CR_AMT, DR_AMT, CR_FINE_WT, DR_FINE_WT, CR_SL_FINE, DR_SL_FINE, DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + tLcCode.Text + "','" + DC_Main.MCo_year + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','"), ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[1].Value), (object)"',");
						DataGridViewCell val;
						object Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[6]).Value);
						double num2 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[5]).Value);
						double num3 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[8]).Value);
						double num4 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[7]).Value);
						double num5 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[10]).Value);
						double num6 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[9]).Value);
						double num7 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num7), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "AcSummLdr";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcSummLdr.RPT";
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = 'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
				}
				CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " and {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					UT_REPORT uT_REPORT = new UT_REPORT();
					((Control)uT_REPORT).Show();
					((Control)uT_REPORT).Focus();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
				return;
			}
			if (unchecked((int)Interaction.MsgBox((object)"Hz Repor With Gold and Silver....", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
			{
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt,SUM(CASE WHEN IT_TYPE = 'G' THEN (CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END )ELSE 0 END) as GoldWt,sum(CASE WHEN IT_TYPE = 'S' THEN (CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					num8 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BalAmt"], (object)"")), "0.00"));
					num9 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GoldWt"], (object)"")), "0.000"));
					num10 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SilverWt"], (object)"")), "0.000"));
				}
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " and {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if (chkVchSum.Checked)
					{
						DC_Main.RptName = "AcWithWtSumm";
					}
					else
					{
						DC_Main.RptName = "AcWithWtGold";
					}
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Ledger With Gold and Silver From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.MsCrForName1 = "AcOpGold";
					DC_Main.MsCrForVal1 = Strings.Format((object)num9, "0.000");
					DC_Main.MsCrForName2 = "AcOPAmt";
					DC_Main.MsCrForVal2 = Strings.Format((object)num8, "0.00");
					DC_Main.MsCrForName3 = "AcOpSilver";
					DC_Main.MsCrForVal3 = Strings.Format((object)num10, "0.000");
				}
				else
				{
					if (chkVchSum.Checked)
					{
						Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcWithWtSumm.RPT";
					}
					else
					{
						Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcWithWtGold.RPT";
					}
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = 'Ledger With Gold and Silver From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					Cr[(short)3] = ("AcOpGold = " + Strings.Format((object)num9, "0.000")) ?? "";
					Cr[(short)4] = ("AcOPAmt = " + Strings.Format((object)num8, "0.00")) ?? "";
					Cr[(short)5] = ("AcOpSilver = " + Strings.Format((object)num10, "0.000")) ?? "";
				}
			}
			else
			{
				double num11 = 0.0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					num11 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"])), "0.00"));
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.RptName = "AcLedger";
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Ledger With Gold and Silver From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.MsCrForName1 = "FromDate";
					DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
					DC_Main.MsCrForName2 = "ToDate";
					DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
					DC_Main.MsCrForName3 = "AcOpAmt";
					DC_Main.MsCrForVal3 = Strings.Format((object)num11, "0.00");
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedger.RPT";
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = 'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
					Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
					Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num11, "0.00")) ?? "";
				}
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " and {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				UT_REPORT uT_REPORT2 = new UT_REPORT();
				((Control)uT_REPORT2).Show();
				((Control)uT_REPORT2).Focus();
				CurFormula = "";
			}
			else
			{
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void RP_LEDR_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((Control)DGV_MONTH).Visible = false;
		if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
		{
			DGV_DETL_FILL();
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			DGV_VCH_FILL();
		}
		else
		{
			AcSumm();
		}
		CurActCtrl.Focus();
	}

	private void AcSumm()
	{
		DgvAcEnter = false;
		if (chkOpBal.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" and A.VCH_DATE < '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKhataNo.Text, "", false) == 0, (object)"", (object)("AND B.AC_KHATA_NO = '" + tKhataNo.Text + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tRefAc.Text, "", false) == 0, (object)"", (object)("AND B.AC_REF_CODE = '" + tRefAc.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND B.AC_STATE = '" + cboState.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND B.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))))), (object)"")), (object)" "));
			if (Operators.CompareString(CurRpt, "Mfg Ledger", false) == 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "And A.AC_CODE IN(SELECT KR_CODE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY KR_CODE)";
			}
			DC_Main.RsQry += "GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME";
		}
		else if (!chkZero.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" and A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKhataNo.Text, "", false) == 0, (object)"", (object)("AND B.AC_KHATA_NO = '" + tKhataNo.Text + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tRefAc.Text, "", false) == 0, (object)"", (object)("AND B.AC_REF_CODE = '" + tRefAc.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND B.AC_STATE = '" + cboState.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND B.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" "));
			if (Operators.CompareString(CurRpt, "Mfg Ledger", false) == 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "And A.AC_CODE IN(SELECT KR_CODE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY KR_CODE)";
			}
			DC_Main.RsQry += "GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO  HAVING (round(Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End,2)) +  (round(Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End,2)) +  (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.000')) +  (format(Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.000')) +  (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.00'))+  (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.00')) <> 0  ORDER BY B.AC_NAME ";
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" and A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKhataNo.Text, "", false) == 0, (object)"", (object)("AND B.AC_KHATA_NO = '" + tKhataNo.Text + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tRefAc.Text, "", false) == 0, (object)"", (object)("AND B.AC_REF_CODE = '" + tRefAc.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), Interaction.IIf(Operators.CompareString(cboState.Text, "", false) == 0, (object)"", (object)("AND B.AC_STATE = '" + cboState.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND B.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" "));
			if (Operators.CompareString(CurRpt, "Mfg Ledger", false) == 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "And A.AC_CODE IN(SELECT KR_CODE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY KR_CODE)";
			}
			DC_Main.RsQry += "GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME ";
		}
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
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

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		int index = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				int columnIndex;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 1432:
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
							goto IL_001a;
						case 4:
							goto IL_0029;
						case 5:
							goto IL_0032;
						case 6:
							goto IL_0045;
						case 7:
							goto IL_0059;
						case 8:
							goto IL_0071;
						case 9:
							goto IL_00a0;
						case 10:
							goto IL_00d0;
						case 11:
							goto IL_010b;
						case 12:
							goto IL_015e;
						case 13:
							goto IL_018e;
						case 14:
							goto IL_01cf;
						case 15:
							goto IL_01e1;
						case 16:
							goto IL_01ff;
						case 17:
							goto IL_022c;
						case 19:
							goto IL_024c;
						case 20:
							goto IL_0281;
						case 22:
							goto IL_02b3;
						case 18:
						case 21:
						case 23:
						case 24:
						case 25:
							goto IL_02ce;
						case 26:
						case 27:
							goto IL_0302;
						case 28:
							goto IL_0319;
						case 29:
							goto IL_032d;
						case 30:
							goto IL_033d;
						case 31:
							goto IL_035a;
						case 32:
							goto IL_036e;
						case 33:
							goto IL_037e;
						case 34:
							goto IL_038e;
						case 35:
							goto IL_039e;
						case 36:
						case 37:
							goto IL_03b0;
						case 38:
							goto IL_03c4;
						case 39:
							goto IL_03d4;
						case 41:
							goto IL_03e5;
						case 42:
							goto IL_03f9;
						case 43:
							goto IL_0409;
						case 44:
							goto IL_0419;
						case 45:
							goto IL_042d;
						case 46:
							goto IL_044a;
						case 47:
							goto IL_045a;
						case 48:
							goto IL_046a;
						case 49:
							goto IL_047a;
						case 50:
						case 51:
							goto IL_048c;
						case 52:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 40:
						case 53:
						case 54:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_03b0:
					num2 = 37;
					BtnPrint.Text = "Ledr";
					goto IL_03c4;
					IL_03c4:
					num2 = 38;
					((Control)DGV_VCH).Visible = true;
					goto IL_03d4;
					IL_039e:
					num2 = 35;
					((Control)BtnDelete).Visible = true;
					goto IL_03b0;
					IL_03d4:
					num2 = 39;
					DGV_VCH_FILL();
					goto end_IL_0001_3;
					IL_000b:
					num2 = 2;
					((Control)PnlAcSumm).Visible = false;
					goto IL_001a;
					IL_001a:
					num2 = 3;
					((Control)tLcCode).Visible = false;
					goto IL_0029;
					IL_0029:
					num2 = 4;
					DgvAcEnter = true;
					goto IL_0032;
					IL_0032:
					num2 = 5;
					columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
					goto IL_0045;
					IL_0045:
					num2 = 6;
					index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
					goto IL_0059;
					IL_0059:
					num2 = 7;
					DgvCurRow = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
					goto IL_0071;
					IL_0071:
					num2 = 8;
					tAcCode.Text = ((DataGridView)DGV_AC)[1, index].Value.ToString() ?? "";
					goto IL_00a0;
					IL_03f9:
					num2 = 42;
					((Control)DGV_VCH).Visible = false;
					goto IL_0409;
					IL_03e5:
					num2 = 41;
					BtnExit.Text = "&Back1";
					goto IL_03f9;
					IL_00a0:
					num2 = 9;
					tAcName.Text = ((DataGridView)DGV_AC)[2, index].Value.ToString() ?? "";
					goto IL_00d0;
					IL_0419:
					num2 = 44;
					BtnCancel.Text = "&Main";
					goto IL_042d;
					IL_0409:
					num2 = 43;
					((Control)BtnGold).Visible = true;
					goto IL_0419;
					IL_00d0:
					num2 = 10;
					lblRefby.Text = ("Ref By : " + ((DataGridView)DGV_AC)[11, index].Value.ToString()) ?? "";
					goto IL_010b;
					IL_044a:
					num2 = 46;
					((Control)BtnSilver).Visible = true;
					goto IL_045a;
					IL_042d:
					num2 = 45;
					if (Operators.CompareString(CurRpt, "Mfg Ledger", false) != 0)
					{
						goto IL_044a;
					}
					goto IL_048c;
					IL_010b:
					num2 = 11;
					lblAdd1.Text = (((DataGridView)DGV_AC)[3, index].Value.ToString() + " - " + ((DataGridView)DGV_AC)[12, index].Value.ToString()) ?? "";
					goto IL_015e;
					IL_046a:
					num2 = 48;
					((Control)BtnJmaUdhar).Visible = true;
					goto IL_047a;
					IL_045a:
					num2 = 47;
					((Control)BtnDelete).Visible = true;
					goto IL_046a;
					IL_015e:
					num2 = 12;
					lblMobile.Text = ((DataGridView)DGV_AC)[4, index].Value.ToString() ?? "";
					goto IL_018e;
					IL_048c:
					num2 = 51;
					BtnPrint.Text = "Ledr";
					break;
					IL_047a:
					num2 = 49;
					((Control)btnPurcRpt).Visible = true;
					goto IL_048c;
					IL_018e:
					num2 = 13;
					DC_Main.RsQry = "SELECT LAST_DATE,MAIN_AC_CODE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
					goto IL_01cf;
					IL_01cf:
					num2 = 14;
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_01e1;
					IL_01e1:
					num2 = 15;
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						goto IL_01ff;
					}
					goto IL_0302;
					IL_01ff:
					num2 = 16;
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LAST_DATE"])))
					{
						goto IL_022c;
					}
					goto IL_024c;
					IL_022c:
					num2 = 17;
					mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
					goto IL_02ce;
					IL_024c:
					num2 = 19;
					if (DateTime.Compare(Conversions.ToDate(DC_Main.Tbl.Rows[0]["LAST_DATE"]), DC_Main.MOp_dt) > 0)
					{
						goto IL_0281;
					}
					goto IL_02b3;
					IL_0281:
					num2 = 20;
					mFromDt.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["LAST_DATE"]);
					goto IL_02ce;
					IL_02b3:
					num2 = 22;
					mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
					goto IL_02ce;
					IL_02ce:
					num2 = 25;
					MainAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MAIN_AC_CODE"], (object)""));
					goto IL_0302;
					IL_0302:
					num2 = 27;
					if (chkVchSum.Checked)
					{
						goto IL_0319;
					}
					goto IL_03e5;
					IL_0319:
					num2 = 28;
					BtnExit.Text = "&Back";
					goto IL_032d;
					IL_032d:
					num2 = 29;
					((Control)BtnGold).Visible = true;
					goto IL_033d;
					IL_033d:
					num2 = 30;
					if (Operators.CompareString(CurRpt, "Mfg Ledger", false) != 0)
					{
						goto IL_035a;
					}
					goto IL_03b0;
					IL_035a:
					num2 = 31;
					BtnCancel.Text = "&Main";
					goto IL_036e;
					IL_036e:
					num2 = 32;
					((Control)BtnSilver).Visible = true;
					goto IL_037e;
					IL_037e:
					num2 = 33;
					((Control)BtnJmaUdhar).Visible = true;
					goto IL_038e;
					IL_038e:
					num2 = 34;
					((Control)btnPurcRpt).Visible = true;
					goto IL_039e;
					end_IL_0001_2:
					break;
				}
				num2 = 52;
				DGV_DETL_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1432;
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
					ProjectData.ClearProjectError();
					num2 = 2;
					switch (e.ColumnIndex)
					{
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
					case 14:
					case 15:
					case 16:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 9:
					case 13:
						break;
					}
					break;
				case 149:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00cb;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 149;
				continue;
			}
			break;
			IL_00cb:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_DETL_FILL()
	{
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Expected O, but got Unknown
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected O, but got Unknown
		//IL_105a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ024NEKJ", false) == 0)
		{
			LaxmiJw_CrDr();
			return;
		}
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.ENTRY_TIME,A.LEDR_KEY,A.LD_CODE As AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.LDR_NAME,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver,B.MAIN_BOOK  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.ENTRY_TIME,A.LEDR_KEY,A.LD_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,A.LDR_NAME ORDER BY A.ENTRY_TIME,B.BOOK_NAME,A.VCH_NO"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM KR_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM MFG_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM SL_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM RATE_CUT_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)""));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,VCH_REMARK FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" ORDER BY SR_NO "));
		DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView2 = new DataView(table2);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
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
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
			if (Operators.CompareString(DC_Main.MsLedrBillColShow, "Y", false) == 0)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Bill");
				((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Bill");
				((DataGridView)DGV_DETL).Columns[4].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Party Name");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Gold");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Gold");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Gold");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Silver");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Silver");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Silver");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[18].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Remark");
				((DataGridView)DGV_DETL).Columns[21].Visible = false;
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Remark");
				((DataGridView)DGV_DETL).Columns[21].Width = (int)Math.Round(250.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
			}
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			((DataGridView)DGV_DETL).Columns[5].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
			{
				if (chkGoldCol.Checked)
				{
					((DataGridView)DGV_DETL).Columns[10].Visible = true;
					((DataGridView)DGV_DETL).Columns[11].Visible = true;
					((DataGridView)DGV_DETL).Columns[12].Visible = true;
					((DataGridView)DGV_DETL).Columns[13].Visible = true;
				}
				else
				{
					((DataGridView)DGV_DETL).Columns[10].Visible = false;
					((DataGridView)DGV_DETL).Columns[11].Visible = false;
					((DataGridView)DGV_DETL).Columns[12].Visible = false;
					((DataGridView)DGV_DETL).Columns[13].Visible = false;
				}
			}
			DC_Main.R = 0;
			if (dataTable.Rows.Count > 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"])) != 0.0)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL)[1, DC_Main.R].Value = "Op Balance";
					((DataGridView)dGV_DETL)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_DETL)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_DETL)[8, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"]);
					((DataGridView)dGV_DETL)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[0]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable.Rows[0]["CrGold"]));
					((DataGridView)dGV_DETL)[12, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"]);
					((DataGridView)dGV_DETL)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable.Rows[0]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable.Rows[0]["CrSilver"]));
					((DataGridView)dGV_DETL)[16, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "";
					}
					DC_Main.R++;
				}
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num7 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
					((DataGridView)dGV_DETL2).Rows.Add();
					((DataGridView)dGV_DETL2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_DETL2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ENTRY_TIME"]), "dd/MM/yyyy");
					if (Operators.CompareString(DC_Main.MsLedrBillColShow, "Y", false) == 0)
					{
						dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
						if (dataView.Count > 0)
						{
							((DataGridView)dGV_DETL2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView[0]["BILL_NO"]);
						}
					}
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["LDR_NAME"], (object)""), (object)"", false))
					{
						((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LDR_NAME"]);
					}
					else
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_CODE"], (object)""), (object)"00045", false))
						{
							((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LDR_NAME"]);
						}
						((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_NAME"], (object)"");
					}
					((DataGridView)dGV_DETL2)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_DETL2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrGold"]);
					((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable2.Rows[DC_Main.M]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable2.Rows[DC_Main.M]["CrGold"]));
					((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrSilver"]);
					((DataGridView)dGV_DETL2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable2.Rows[DC_Main.M]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable2.Rows[DC_Main.M]["CrSilver"]));
					((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_DETL2)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_DETL2)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0)
					{
						((DataGridView)dGV_DETL2)[21, DC_Main.R].Value = "";
					}
					else
					{
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV_DETL2)[21, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView2[0]["VCH_REMARK"]);
						}
					}
					if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"LD ADJUST", false))
					{
						((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Red;
					}
					DC_Main.R++;
					dGV_DETL2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[5].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[5].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_DETL).Rows.Add();
					((DataGridView)DGV_DETL).Rows.Add();
				}
				int num8 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num8].Cells[5].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num8].Cells[7].Value = num;
				((DataGridView)DGV_DETL).Rows[num8].Cells[6].Value = num2;
				((DataGridView)DGV_DETL).Rows[num8].Cells[8].Value = Math.Abs(num2 - num);
				if (Conversion.Val((object)(num2 - num)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = "Cr";
				}
				else if (Conversion.Val((object)(num2 - num)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num8].Cells[11].Value = num3;
				((DataGridView)DGV_DETL).Rows[num8].Cells[10].Value = num4;
				((DataGridView)DGV_DETL).Rows[num8].Cells[12].Value = Math.Abs(num4 - num3);
				if (Conversion.Val((object)(num4 - num3)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = "Cr";
				}
				else if (Conversion.Val((object)(num4 - num3)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num8].Cells[15].Value = num5;
				((DataGridView)DGV_DETL).Rows[num8].Cells[14].Value = num6;
				((DataGridView)DGV_DETL).Rows[num8].Cells[16].Value = Math.Abs(num6 - num5);
				if (Conversion.Val((object)(num6 - num5)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[17].Value = "Cr";
				}
				else if (Conversion.Val((object)(num6 - num5)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[17].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[17].Value = "";
				}
			}
			if (DgvDtlRow > 1)
			{
				if (((DataGridView)DGV_DETL).Rows.Count >= DgvDtlRow)
				{
					((DataGridView)DGV_DETL).Rows[DgvDtlRow].Cells[1].Selected = true;
					((DataGridView)DGV_DETL).FirstDisplayedScrollingRowIndex = DgvDtlRow;
				}
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
			else
			{
				if ((Operators.CompareString(DC_Main.MsRptTotShow, "Y", false) == 0) & (((DataGridView)DGV_DETL).RowCount > 1))
				{
					((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).RowCount - 1].Cells[1].Selected = true;
					((DataGridView)DGV_DETL).FirstDisplayedScrollingRowIndex = ((DataGridView)DGV_DETL).Rows.Count - 1;
				}
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
		}
	}

	private void LaxmiJw_CrDr()
	{
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.ENTRY_TIME,A.LEDR_KEY,A.LD_CODE As AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.LDR_NAME,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver,B.MAIN_BOOK  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.ENTRY_TIME,A.LEDR_KEY,A.LD_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,A.LDR_NAME ORDER BY A.ENTRY_TIME,B.BOOK_NAME,A.VCH_NO"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM KR_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM MFG_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)""));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
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
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
			if (Operators.CompareString(DC_Main.MsLedrBillColShow, "Y", false) == 0)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Bill");
				((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Bill");
				((DataGridView)DGV_DETL).Columns[4].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Party Name");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Gold");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Gold");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Gold");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Silver");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Silver");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Silver");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[18].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			((DataGridView)DGV_DETL).Columns[5].Frozen = true;
			if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
			{
				if (chkGoldCol.Checked)
				{
					((DataGridView)DGV_DETL).Columns[11].Visible = true;
					((DataGridView)DGV_DETL).Columns[10].Visible = true;
					((DataGridView)DGV_DETL).Columns[12].Visible = true;
					((DataGridView)DGV_DETL).Columns[13].Visible = true;
				}
				else
				{
					((DataGridView)DGV_DETL).Columns[11].Visible = false;
					((DataGridView)DGV_DETL).Columns[10].Visible = false;
					((DataGridView)DGV_DETL).Columns[12].Visible = false;
					((DataGridView)DGV_DETL).Columns[13].Visible = false;
				}
			}
			DC_Main.R = 0;
			if (dataTable.Rows.Count > 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"])) != 0.0)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL)[1, DC_Main.R].Value = "Op Balance";
					((DataGridView)dGV_DETL)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_DETL)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_DETL)[8, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"]);
					((DataGridView)dGV_DETL)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[0]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable.Rows[0]["CrGold"]));
					((DataGridView)dGV_DETL)[12, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"]);
					((DataGridView)dGV_DETL)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable.Rows[0]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable.Rows[0]["CrSilver"]));
					((DataGridView)dGV_DETL)[16, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "";
					}
					DC_Main.R++;
				}
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num7 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
					((DataGridView)dGV_DETL2).Rows.Add();
					((DataGridView)dGV_DETL2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_DETL2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ENTRY_TIME"]), "dd/MM/yyyy");
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV_DETL2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView[0]["BILL_NO"]);
					}
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["LDR_NAME"], (object)""), (object)"", false))
					{
						((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LDR_NAME"]);
					}
					else
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_CODE"], (object)""), (object)"00045", false))
						{
							((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LDR_NAME"]);
						}
						((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_NAME"], (object)"");
					}
					((DataGridView)dGV_DETL2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_DETL2)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrGold"]);
					((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable2.Rows[DC_Main.M]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable2.Rows[DC_Main.M]["CrGold"]));
					((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrSilver"]);
					((DataGridView)dGV_DETL2)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable2.Rows[DC_Main.M]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable2.Rows[DC_Main.M]["CrSilver"]));
					((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_DETL2)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_DETL2)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"LD ADJUST", false))
					{
						((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Red;
					}
					DC_Main.R++;
					dGV_DETL2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[5].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[5].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_DETL).Rows.Add();
					((DataGridView)DGV_DETL).Rows.Add();
				}
				int num8 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num8].Cells[5].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num8].Cells[6].Value = num;
				((DataGridView)DGV_DETL).Rows[num8].Cells[7].Value = num2;
				((DataGridView)DGV_DETL).Rows[num8].Cells[8].Value = Math.Abs(num2 - num);
				if (Conversion.Val((object)(num2 - num)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = "Cr";
				}
				else if (Conversion.Val((object)(num2 - num)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num8].Cells[10].Value = num3;
				((DataGridView)DGV_DETL).Rows[num8].Cells[11].Value = num4;
				((DataGridView)DGV_DETL).Rows[num8].Cells[12].Value = Math.Abs(num4 - num3);
				if (Conversion.Val((object)(num4 - num3)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = "Cr";
				}
				else if (Conversion.Val((object)(num4 - num3)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num8].Cells[14].Value = num5;
				((DataGridView)DGV_DETL).Rows[num8].Cells[15].Value = num6;
				((DataGridView)DGV_DETL).Rows[num8].Cells[16].Value = Math.Abs(num6 - num5);
				if (Conversion.Val((object)(num6 - num5)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[17].Value = "Cr";
				}
				else if (Conversion.Val((object)(num6 - num5)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[17].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[17].Value = "";
				}
			}
			if (DgvDtlRow > 1)
			{
				if (((DataGridView)DGV_DETL).Rows.Count >= DgvDtlRow)
				{
					((DataGridView)DGV_DETL).Rows[DgvDtlRow].Cells[1].Selected = true;
					((DataGridView)DGV_DETL).FirstDisplayedScrollingRowIndex = DgvDtlRow;
				}
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
			else
			{
				if ((Operators.CompareString(DC_Main.MsRptTotShow, "Y", false) == 0) & (((DataGridView)DGV_DETL).RowCount > 1))
				{
					((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).RowCount - 1].Cells[1].Selected = true;
					((DataGridView)DGV_DETL).FirstDisplayedScrollingRowIndex = ((DataGridView)DGV_DETL).Rows.Count - 1;
				}
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
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
					ProjectData.ClearProjectError();
					num2 = 2;
					switch (e.ColumnIndex)
					{
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
					case 14:
					case 15:
					case 16:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 9:
					case 13:
						break;
					}
					break;
				case 149:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00cb;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 149;
				continue;
			}
			break;
			IL_00cb:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_VCH_FILL()
	{
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected O, but got Unknown
		//IL_1047: Unknown result type (might be due to invalid IL or missing references)
		//IL_1051: Expected O, but got Unknown
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.ENTRY_TIME,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,  SUM(A.DR_AMT) As DrAmt,SUM(A.CR_AMT) CrAmt,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END) As DrGold,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrGold,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END) As DrSilver,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' and A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.ENTRY_TIME,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK ORDER BY A.ENTRY_TIME,B.BOOK_NAME,A.VCH_NO"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM KR_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM SL_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "), (object)" UNION ALL SELECT CO_YEAR,CO_BOOK,VCH_NO,BILL_NO FROM RATE_CUT_DATA  WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" "));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,VCH_REMARK FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" ORDER BY SR_NO "));
		DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView2 = new DataView(table2);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_VCH).AutoGenerateColumns = false;
		((DataGridView)DGV_VCH).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_VCH).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Book");
			((DataGridView)DGV_VCH).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "VchNo");
			((DataGridView)DGV_VCH).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Date");
			((DataGridView)DGV_VCH).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			if (Operators.CompareString(DC_Main.MsLedrBillColShow, "Y", false) == 0)
			{
				((DataGridView)DGV_VCH).Columns.Add("", "BillNo");
				((DataGridView)DGV_VCH).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			}
			else
			{
				((DataGridView)DGV_VCH).Columns.Add("", "BillNo");
				((DataGridView)DGV_VCH).Columns[4].Visible = false;
			}
			((DataGridView)DGV_VCH).Columns.Add("", "Party Name");
			((DataGridView)DGV_VCH).Columns[5].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_VCH).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_VCH).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_VCH).Columns[8].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "CrDr");
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "Cr Gold");
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Dr Gold");
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Bal Gold");
			((DataGridView)DGV_VCH).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "CrDr");
			((DataGridView)DGV_VCH).Columns[13].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "Cr Silver");
			((DataGridView)DGV_VCH).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Dr Silver");
			((DataGridView)DGV_VCH).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Bal Silver");
			((DataGridView)DGV_VCH).Columns[16].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "CrDr");
			((DataGridView)DGV_VCH).Columns[17].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "CoBook");
			((DataGridView)DGV_VCH).Columns[18].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "AcCode");
			((DataGridView)DGV_VCH).Columns[19].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "MainBook");
			((DataGridView)DGV_VCH).Columns[20].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "Remark");
			((DataGridView)DGV_VCH).Columns[21].Width = (int)Math.Round(250.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
			if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
			{
				if (chkGoldCol.Checked)
				{
					((DataGridView)DGV_VCH).Columns[10].Visible = true;
					((DataGridView)DGV_VCH).Columns[11].Visible = true;
					((DataGridView)DGV_VCH).Columns[12].Visible = true;
					((DataGridView)DGV_VCH).Columns[13].Visible = true;
				}
				else
				{
					((DataGridView)DGV_VCH).Columns[10].Visible = false;
					((DataGridView)DGV_VCH).Columns[11].Visible = false;
					((DataGridView)DGV_VCH).Columns[12].Visible = false;
					((DataGridView)DGV_VCH).Columns[13].Visible = false;
				}
			}
			((DataGridView)DGV_VCH).Columns[0].Frozen = true;
			((DataGridView)DGV_VCH).Columns[1].Frozen = true;
			((DataGridView)DGV_VCH).Columns[2].Frozen = true;
			((DataGridView)DGV_VCH).Columns[3].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.R = 0;
			if (dataTable.Rows.Count > 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"])) != 0.0)
				{
					((DataGridView)dGV_VCH).Rows.Add();
					((DataGridView)dGV_VCH)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_VCH)[1, DC_Main.R].Value = "Op Balance";
					((DataGridView)dGV_VCH)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_VCH)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_VCH)[8, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_VCH)[9, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_VCH)[9, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"]);
					((DataGridView)dGV_VCH)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[0]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable.Rows[0]["CrGold"]));
					((DataGridView)dGV_VCH)[12, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_VCH)[13, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_VCH)[13, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"]);
					((DataGridView)dGV_VCH)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable.Rows[0]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable.Rows[0]["CrSilver"]));
					((DataGridView)dGV_VCH)[16, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_VCH)[17, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_VCH)[17, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH)[17, DC_Main.R].Value = "";
					}
					DC_Main.R++;
				}
				dGV_VCH = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num7 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH2 = DGV_VCH;
					((DataGridView)dGV_VCH2).Rows.Add();
					((DataGridView)dGV_VCH2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_VCH2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_VCH2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_VCH2)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ENTRY_TIME"]), "dd/MM/yyyy");
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV_VCH2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView[0]["BILL_NO"]);
					}
					((DataGridView)dGV_VCH2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_NAME"]);
					((DataGridView)dGV_VCH2)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_VCH2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_VCH2)[8, DC_Main.R].Value = Math.Abs(num2 - num);
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_VCH2)[9, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_VCH2)[9, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH2)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH2)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrGold"]);
					((DataGridView)dGV_VCH2)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable2.Rows[DC_Main.M]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable2.Rows[DC_Main.M]["CrGold"]));
					((DataGridView)dGV_VCH2)[12, DC_Main.R].Value = Math.Abs(num4 - num3);
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_VCH2)[13, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_VCH2)[13, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH2)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH2)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrSilver"]);
					((DataGridView)dGV_VCH2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable2.Rows[DC_Main.M]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable2.Rows[DC_Main.M]["CrSilver"]));
					((DataGridView)dGV_VCH2)[16, DC_Main.R].Value = Math.Abs(num6 - num5);
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_VCH2)[17, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_VCH2)[17, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH2)[17, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH2)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_VCH2)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_VCH2)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (dataView2.Count > 0)
					{
						((DataGridView)dGV_VCH2)[21, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView2[0]["VCH_REMARK"]);
					}
					if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"LD ADJUST", false))
					{
						((DataGridView)DGV_VCH).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Red;
					}
					DC_Main.R++;
					dGV_VCH2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_VCH).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridView)DGV_VCH).Rows.Count - 1].Cells[5].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridView)DGV_VCH).Rows.Count - 1].Cells[5].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_VCH).Rows.Add();
					((DataGridView)DGV_VCH).Rows.Add();
				}
				int num8 = ((DataGridView)DGV_VCH).Rows.Count - 1;
				((DataGridView)DGV_VCH).Rows[num8].Cells[5].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num8].Cells[7].Value = num;
				((DataGridView)DGV_VCH).Rows[num8].Cells[6].Value = num2;
				((DataGridView)DGV_VCH).Rows[num8].Cells[8].Value = Math.Abs(num2 - num);
				if (Conversion.Val((object)(num2 - num)) > 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[9].Value = "Cr";
				}
				else if (Conversion.Val((object)(num2 - num)) < 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[9].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[9].Value = "";
				}
				((DataGridView)DGV_VCH).Rows[num8].Cells[11].Value = num3;
				((DataGridView)DGV_VCH).Rows[num8].Cells[10].Value = num4;
				((DataGridView)DGV_VCH).Rows[num8].Cells[12].Value = Math.Abs(num4 - num3);
				if (Conversion.Val((object)(num4 - num3)) > 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[13].Value = "Cr";
				}
				else if (Conversion.Val((object)(num4 - num3)) < 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[13].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[13].Value = "";
				}
				((DataGridView)DGV_VCH).Rows[num8].Cells[15].Value = num5;
				((DataGridView)DGV_VCH).Rows[num8].Cells[14].Value = num6;
				((DataGridView)DGV_VCH).Rows[num8].Cells[16].Value = Math.Abs(num6 - num5);
				if (Conversion.Val((object)(num6 - num5)) > 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[17].Value = "Cr";
				}
				else if (Conversion.Val((object)(num6 - num5)) < 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[17].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[17].Value = "";
				}
			}
			if (DgvDtlRow > 1)
			{
				if (((DataGridView)DGV_VCH).Rows.Count >= DgvDtlRow)
				{
					((DataGridView)DGV_VCH).Rows[DgvDtlRow].Cells[1].Selected = true;
					((DataGridView)DGV_VCH).FirstDisplayedScrollingRowIndex = DgvDtlRow;
				}
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
			else
			{
				if ((Operators.CompareString(DC_Main.MsRptTotShow, "Y", false) == 0) & (((DataGridView)DGV_VCH).RowCount > 1))
				{
					((DataGridView)DGV_VCH).Rows[((DataGridView)DGV_VCH).RowCount - 1].Cells[1].Selected = true;
					((DataGridView)DGV_VCH).FirstDisplayedScrollingRowIndex = ((DataGridView)DGV_VCH).Rows.Count - 1;
				}
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
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
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND A.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" ORDER BY A.AC_NAME"));
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND A.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)"  AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND A.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" ORDER BY A.AC_NAME"));
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
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
				if (chkVchSum.Checked)
				{
					DGV_VCH_FILL();
				}
				else
				{
					DGV_DETL_FILL();
				}
			}
			((Control)tAcCode).Focus();
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			if (chkVchSum.Checked)
			{
				DGV_VCH_FILL();
			}
			else
			{
				DGV_DETL_FILL();
			}
			((Control)tAcCode).Focus();
		}
	}

	private void tAcGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_GR = '" + tAcGrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_GR as GrCode,AC_GR_NAME As AcGroupL,AC_SUB_GR AS MainGroupL,AC_MAIN_GR As GrL FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY AC_GR";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 300.0;
				DC_Main.ColWidth[2] = 300.0;
				DC_Main.ColWidth[3] = 0.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcGrCode.Text = DC_Main.ColValue[0];
					}
					AcSumm();
					((Control)tAcGrCode).Focus();
				}
			}
			else
			{
				AcSumm();
			}
		}
		else
		{
			AcSumm();
		}
	}

	private void chkZero_CheckedChanged(object sender, EventArgs e)
	{
		AcSumm();
	}

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (((Control)PnlMonth).Visible)
			{
				TimeLedr_Dr();
			}
			else
			{
				AcSumm();
			}
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			AcSumm();
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DgvAcEnter = true;
			DGV_DoubleClick(DGV_AC, new EventArgs());
		}
	}

	private void BtnGold_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a37: Invalid comparison between Unknown and I4
		//IL_19f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fe: Invalid comparison between Unknown and I4
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
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
		if (chkVchSum.Checked)
		{
			Gold_Summ();
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,1,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'','',A.IT_CODE,A.ITM_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F',ITM_SIGN,'',DATA_TYPE   FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND A.SR_NO <> 7 AND BOOK_NAME IN ('TR_AC_OPBL','SALES ORDER','SALES','SALES RETURNE','WH SALES','RATE CUT','KARIGAR ISSUE','DHIRAN ISSUE','INTREST RECIVED','DHIRAN RECEIVED','PURC RETURN','TOUR SALES')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,2,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,A.IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'PURCHASE'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,3,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','','OTH FINE',TAG_NO,0,ITM_OTH_FINE,ITM_OTH_FINE,100,0,ITM_OTH_FINE,  ITM_OTH_RATE,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_OTH_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'PURCHASE'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,4,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,A.IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (KR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'KARIGAR RECEIPT'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,5,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','','OTH FINE',TAG_NO,0,ITM_OTH_FINE,ITM_OTH_FINE,100,0,ITM_OTH_FINE,  ITM_OTH_RATE,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (KR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_OTH_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'KARIGAR RECEIPT'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,6,600,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'RATE CUT',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  FINE_RATE,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE <> 'S'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_AMT+DR_AMT <> 0 AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,7,700,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'RATE CUT',LD_CODE,'','','',0,0,0,0,0,0,  FINE_RATE,0,0,0,0,0,CASE WHEN SIGN = '-' THEN CR_AMT ELSE 0 END,CASE WHEN SIGN = '+' THEN DR_AMT ELSE 0 END,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_AMT+DR_AMT <> 0 AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,8,800,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  FINE_RATE,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE <> 'S' AND BOOK_NAME <> 'FINE JV' AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND LD_CODE = '00098' AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,9,900,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'G' AND BOOK_NAME = 'FINE JV' AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,10,901,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'',SUBSTRING(IT_DESC,1,50),'',0,0,0,0,0,0,  0,0,0,0,0,0,0,DR_AMT,'F','-','',DATA_TYPE   FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND DR_AMT <> 0 AND FINE_WT = 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,11,902,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'',SUBSTRING(IT_DESC,1,50),'',0,0,0,0,0,0,  0,0,0,0,0,0,CR_AMT,0,'F','+','',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)"  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_AMT <> 0 AND FINE_WT = 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,12,903,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND IT_TYPE = 'G' AND FINE_WT <> 0 AND BOOK_NAME = 'TR_AC_OPBL'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,13,SR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'','00003','999','','',0,0,0,0,0,ITM_OTH_FINE,  ITM_OTH_RATE,0,0,0,0,0,0,0,'F','-','','A'   FROM RATE_CUT_ISU  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE <> 'S'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_OTH_FINE <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,14,904,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'INT FINE','00061','','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'G'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' AND LD_CODE = '00061' "), (object)" AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,15,905,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'G'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' AND BOOK_NAME = 'LABOUR WORK' "), (object)" AND FINE_WT <> 0 AND CR_AMT+DR_AMT = 0"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,16,907,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'G'  AND SIGN = '-' AND AC_CODE = '"), (object)tAcCode.Text), (object)"' AND BOOK_NAME = 'INTREST RECIVED' "), (object)" AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,16,907,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'G'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND BOOK_NAME IN ('MTL ISU','GHAT ISU','MFG GHAT REC','MFG FILE ISU','MFG FILE REC','MFG PREP ISU','MFG PREP REC','MFG NAKSHI ISU','MFG NAKSHI REC','MFG STNG ISU','MFG STNG REC','MFG MINO ISU','MFG MINO REC','MFG FILE2 ISU','MFG FILE2 REC','MFG POLISH ISU','MFG POLISH REC') AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,17,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('GHAT REC')"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,18,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','999','KUNDAN WT','',0,KR_KUNDAN_WT,KR_KUNDAN_WT,0,0,KR_KUNDAN_WT,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND KR_KUNDAN_WT <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('JDTR REC')"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,19,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','MIX GOLD','',0,FTNG_GWT,FTNG_NWT,FTNG_TOUCH,0,FTNG_FINE,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FTNG_FINE <> 0 AND FTNG_IT_CODE = '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FTNG REC','CHEDIYA REC','PARA REC')"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,19,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','MIX GOLD','',0,FTNG_GWT,FTNG_NWT,FTNG_TOUCH,0,FTNG_FINE,  0,0,0,0,0,0,0,0,'F','-','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.FTNG_IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FTNG_FINE <> 0 AND FTNG_IT_CODE <> '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FTNG ISU','CHEDIYA ISU','PARA ISU')"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,20,1,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','OLD_GOLD','',0,DR_WT,DR_WT,DR_TOUCH,0,DR_FINE,  0,0,0,0,0,0,0,0,'F','-','',C.DATA_TYPE   FROM LBR_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND DR_FINE <> 0 AND AC_CODE <> '' AND A.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('TAG WT CHANGE','TAG SPLIT')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,21,1,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','OLD_GOLD','',0,CR_WT,CR_WT,CR_TOUCH,0,CR_FINE,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM LBR_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_FINE <> 0 AND AC_CODE <> '' AND A.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('TAG WT CHANGE','TAG SPLIT')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,22,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (SL_DETL_RTN AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'SALES RETURNE'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,23,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  D.AC_CODE,'','',A.IT_CODE,A.ITM_REMARK,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  0,0,0,0,0,0,0,0,'F','-','',C.DATA_TYPE   FROM ((INOUT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN LOCT_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TO_LC_CODE = D.LC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND D.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'OUTWORD'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,24,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  D.AC_CODE,'','',A.IT_CODE,A.ITM_REMARK,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM ((INOUT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN LOCT_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.FROM_LC_CODE = D.LC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND D.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'INWORD'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,25,A.SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',A.TAG_NO,A.STK_PCS,A.STK_GWT,A.STK_NWT,A.ITM_TOUCH,A.ITM_WEST_PRC,A.STK_FINE,  0,0,0,0,0,0,0,0,'F','-','','B'   FROM (CUT_STK_DETL AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND A.STK_FINE <> 0 AND AC_CODE <> '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FINE PURC','FINE SALE')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,26,A.SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',A.TAG_NO,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_TOUCH,A.ITM_WEST_PRC,A.ITM_FINE,  0,0,A.LBR_RATE,A.LBR_AMT,A.OTH_AMT,A.NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (RATE_CUT_REC AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND AC_CODE <> '' AND C.MAIN_BOOK IN ('WH RTN')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
			num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
			num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'   AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
			num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
			num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
		}
		CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {FINE_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {FINE_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "#";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " and {FINE_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Ledr With Gold Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Ledr With Gold Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			DC_Main.MsCrForName1 = "FromDate";
			DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
			DC_Main.MsCrForName2 = "ToDate";
			DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName3 = "OpBal";
			DC_Main.MsCrForVal3 = Strings.Format((object)num2, "0.000");
			DC_Main.MsCrForName4 = "ClBal";
			DC_Main.MsCrForVal4 = Strings.Format((object)num5, "0.000");
			DC_Main.MsCrForName5 = "OpAmtBal";
			DC_Main.MsCrForVal5 = Strings.Format((object)num, "0.00");
			DC_Main.MsCrForName6 = "ClAmtBal";
			DC_Main.MsCrForVal6 = Strings.Format((object)num4, "0.00");
			DC_Main.MsCrForName7 = "DataType";
			DC_Main.MsCrForStr7 = "'" + DC_Main.MsDataType + "'";
			if ((int)Interaction.MsgBox((object)"Hz Jama Udhar Gold Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.RptName = "JmUdFineHz";
			}
			else
			{
				DC_Main.RptName = "JmUdFine";
			}
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Hz Jama Udhar Gold Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineHz.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFine.RPT";
			}
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Ledr With Gold Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'Ledr With Gold Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num5, "0.000")) ?? "";
			Cr[(short)5] = ("OpAmtBal = " + Strings.Format((object)num, "0.00")) ?? "";
			Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";
			Cr[(short)7] = "DataType = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
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

	private void Gold_Summ()
	{
		//IL_3304: Unknown result type (might be due to invalid IL or missing references)
		//IL_330a: Invalid comparison between Unknown and I4
		DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");
		checked
		{
			int num = ((DataGridView)DGV_VCH).Rows.Count - 2;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND IT_TYPE = 'A'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				DC_Main.X = 1;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",1, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[5, DC_Main.M].Value), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["LD_CODE"]), (object)"','','',0,0,0,0,0,0, "), (object)" 0,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["CR_AMT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["DR_AMT"]), (object)",'A','','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND IT_TYPE = 'G' AND FINE_RATE <> 0"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",2, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','RATE CUT','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_RATE"]), (object)",0,"), DC_Main.Rshlp.Rows[DC_Main.R]["CR_AMT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["DR_AMT"]), (object)",'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND IT_TYPE = 'G' AND BOOK_NAME = 'FINE JV' AND AC_CODE = '"), (object)tAcCode.Text), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",3, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','FINE JV','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_RATE"]), (object)",0,0,0,'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["DATA_TYPE"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.MAIN_BOOK FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.IT_TYPE = 'G' AND B.MAIN_BOOK IN ('GHAT ISU','MFG GHAT REC','MFG FILE ISU','MFG FILE REC','MFG PREP ISU','MFG PREP REC','MFG NAKSHI ISU','MFG NAKSHI REC','MFG STNG ISU','MFG STNG REC','MFG MINO ISU','MFG MINO REC','MFG FILE2 ISU','MFG FILE2 REC','MFG POLISH ISU','MFG POLISH REC') AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",4, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_RATE"]), (object)",0,0,0,'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["DATA_TYPE"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME NOT IN ('KARIGAR RECEIPT','PURCHASE','FINE PURC') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'G' AND ITM_AMT = 0 AND ITM_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",5, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_FINE"]), (object)", "), (object)" 0,0,0,0,'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM KR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('KARIGAR RECEIPT') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'G' AND ITM_AMT = 0 AND ITM_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",6, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST_PRC"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_FINE"]), (object)", "), (object)" 0,0,0,0,'G','+','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('PURCHASE') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'G' AND ITM_AMT = 0 AND ITM_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",7, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST_PRC"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_FINE"]), (object)", "), (object)" 0,0,0,0,'G','+','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'G' AND ITM_AMT <> 0  AND A.ITM_SIGN = '-' "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",8, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST"]), (object)",0, "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_RATE"]), (object)",0,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"]), (object)",'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'G' AND ITM_AMT <> 0  AND A.ITM_SIGN = '+' "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",9, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST"]), (object)",0, "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_RATE"]), (object)",0,"), DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"]), (object)",0,'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND IT_TYPE = 'G' AND ITM_OTH_FINE <> 0"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",10, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','','OTH AMT FINE',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_OTH_FINE"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_OTH_RATE"]), (object)",0,0,0,'G','-','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM CUT_STK_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('FINE PURC') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'G' AND STK_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",11, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"', "), DC_Main.Rshlp.Rows[DC_Main.R]["STK_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["STK_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["STK_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST_PRC"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["STK_FINE"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["STK_ITM_RATE"]), (object)",0,0,0,'G',"), Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_VCH)[20, DC_Main.M].Value, (object)"FINE PURC", false), (object)"'-'", (object)"'+'")), (object)",'B')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,12,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('GHAT REC')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,13,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','999','KUNDAN WT','',0,KR_KUNDAN_WT,KR_KUNDAN_WT,0,0,KR_KUNDAN_WT,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND KR_KUNDAN_WT <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('JDTR REC')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,14,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','MIX GOLD','',0,FTNG_GWT,FTNG_NWT,FTNG_TOUCH,0,FTNG_FINE,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FTNG_FINE <> 0 AND FTNG_IT_CODE = '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FTNG REC','CHEDIYA REC','PARA REC')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,15,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','MIX GOLD','',0,FTNG_GWT,FTNG_NWT,FTNG_TOUCH,0,FTNG_FINE,  0,0,0,0,0,0,0,0,'F','-','',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.FTNG_IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FTNG_FINE <> 0 AND FTNG_IT_CODE <> '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FTNG ISU','CHEDIYA ISU','PARA ISU')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND IT_TYPE = 'G' AND BOOK_NAME = 'LD ADJUST' "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",16, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','LD ADJUST','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" 0,0,0,0,'G','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["DATA_TYPE"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				dGV_VCH = null;
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,17,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  D.AC_CODE,'','',A.IT_CODE,A.ITM_REMARK,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  0,0,0,0,0,0,0,0,'F','-','',C.DATA_TYPE   FROM ((INOUT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN LOCT_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TO_LC_CODE = D.LC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND D.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'OUTWORD'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,18,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  D.AC_CODE,'','',A.IT_CODE,A.ITM_REMARK,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM ((INOUT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK) LEFT JOIN LOCT_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.FROM_LC_CODE = D.LC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND D.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK = 'INWORD'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
				num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'   AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
				num7 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
			if (unchecked((int)Interaction.MsgBox((object)"Hz Jama Udhar Gold Voucher Wise Summ Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineHzSummVch.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineHzSumm.RPT";
			}
			CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {FINE_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			Cr[(short)0] = "RptTitel = 'Ledr With Gold Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num3, "0.00")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num6, "0.00")) ?? "";
			Cr[(short)5] = ("OpAmtBal = " + Strings.Format((object)num2, "0.00")) ?? "";
			Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num5, "0.00")) ?? "";
			Cr[(short)7] = "DataType = '" + DC_Main.MsDataType + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void Silver_Summ()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c87: Invalid comparison between Unknown and I4
		DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");
		if (Operators.CompareString(tLcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			int num = ((DataGridView)DGV_VCH).Rows.Count - 2;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND IT_TYPE = 'A'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				DC_Main.X = 1;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",1, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[5, DC_Main.M].Value), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["LD_CODE"]), (object)"','','',0,0,0,0,0,0, "), (object)" 0,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["CR_AMT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["DR_AMT"]), (object)",'A','','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND IT_TYPE = 'S' AND FINE_RATE <> 0"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",1, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','RATE CUT','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_RATE"]), (object)",0,"), DC_Main.Rshlp.Rows[DC_Main.R]["CR_AMT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["DR_AMT"]), (object)",'S','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND IT_TYPE = 'S' AND BOOK_NAME = 'FINE JV' AND AC_CODE = '"), (object)tAcCode.Text), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",2, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','FINE JV','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_RATE"]), (object)",0,0,0,'S','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["DATA_TYPE"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME NOT IN ('KARIGAR RECEIPT','PURCHASE') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'S' AND ITM_AMT = 0 AND ITM_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",3, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_FINE"]), (object)", "), (object)" 0,0,0,0,'S','"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM KR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('KARIGAR RECEIPT') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'S' AND ITM_AMT = 0 AND ITM_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",4, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST_PRC"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_FINE"]), (object)", "), (object)" 0,0,0,0,'S','+','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM KR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('KARIGAR RECEIPT') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND ITM_AMT = 0 AND SILVER_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",5, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','FSL','KADLI FINE SILVER', 0,"), DC_Main.Rshlp.Rows[DC_Main.R]["SILVER_FINE"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["SILVER_FINE"]), (object)",100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["SILVER_FINE"]), (object)", "), (object)" 0,0,0,0,'S','+','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('PURCHASE') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'S' AND ITM_AMT = 0 AND ITM_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",6, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST_PRC"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_FINE"]), (object)", "), (object)" 0,0,0,0,'S','+','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.BOOK_NAME IN ('PURCHASE') AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND ITM_AMT = 0 AND SILVER_FINE <> 0 "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",7, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','FSL','KADLI FINE SILVER', 0,"), DC_Main.Rshlp.Rows[DC_Main.R]["SILVER_FINE"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["SILVER_FINE"]), (object)",100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["SILVER_FINE"]), (object)", "), (object)" 0,0,0,0,'S','+','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'S' AND ITM_AMT <> 0  AND A.ITM_SIGN = '-' "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",8, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST"]), (object)",0, "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_RATE"]), (object)",0,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"]), (object)",'S','"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.IT_TYPE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND A.VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND A.AC_CODE = '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"' AND B.IT_TYPE = 'S' AND ITM_AMT <> 0  AND A.ITM_SIGN = '+' "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",9, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','','','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"]), (object)"',    "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_NWT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_TOUCH"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_WEST"]), (object)",0, "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_RATE"]), (object)",0,"), DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"]), (object)",0,'S','"), DC_Main.Rshlp.Rows[DC_Main.R]["ITM_SIGN"]), (object)"','A')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"' AND IT_TYPE = 'S' AND BOOK_NAME = 'WH SALES' AND  LD_CODE = '00098' AND AC_CODE = '"), (object)tAcCode.Text), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,DATA_TYPE)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "', '" + DC_Main.MCo_year + "','"), ((DataGridView)dGV_VCH)[18, DC_Main.M].Value), (object)"','"), ((DataGridView)dGV_VCH)[2, DC_Main.M].Value), (object)"', "), (object)DC_Main.X), (object)",10, '"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)dGV_VCH)[3, DC_Main.M].Value), "MM/dd/yyyy")), (object)"', '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_TYPE"]), (object)"', '"), ((DataGridView)dGV_VCH)[20, DC_Main.M].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_VCH)[19, DC_Main.M].Value), (object)"','FINE KASAR','','','',0,0,0,100,0,"), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_WT"]), (object)", "), (object)" "), DC_Main.Rshlp.Rows[DC_Main.R]["FINE_RATE"]), (object)",0,0,0,'S','"), DC_Main.Rshlp.Rows[DC_Main.R]["SIGN"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.R]["DATA_TYPE"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.R++;
					DC_Main.X++;
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				dGV_VCH = null;
				DC_Main.M++;
			}
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				if (Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0)
				{
					num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
					num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.000"));
				}
				else
				{
					num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
					num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
				}
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'   AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				if (Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0)
				{
					num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
					num7 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.000"));
				}
				else
				{
					num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
					num7 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
				}
			}
			if (unchecked((int)Interaction.MsgBox((object)"Silver Report Summery", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineSlSum.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineSlHz.RPT";
			}
			CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {FINE_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			Cr[(short)0] = "RptTitel = 'Ledr With Silver Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num4, "0.000")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num7, "0.000")) ?? "";
			Cr[(short)5] = ("OpAmtBal = " + Strings.Format((object)num2, "0.00")) ?? "";
			Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num5, "0.00")) ?? "";
			Cr[(short)7] = "DataType = '" + DC_Main.MsDataType + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void BtnSilver_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14dd: Invalid comparison between Unknown and I4
		//IL_149e: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a4: Invalid comparison between Unknown and I4
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
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
		if (chkVchSum.Checked)
		{
			Silver_Summ();
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM FINE_DATA");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,1,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'','',A.IT_CODE,A.ITM_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F',ITM_SIGN,'',DATA_TYPE   FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'S' AND A.SR_NO <> 7 AND BOOK_NAME IN ('SALES ORDER','SALES','WH SALES','RATE CUT','KARIGAR ISSUE')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,2,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,A.IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'S' AND C.MAIN_BOOK = 'PURCHASE'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,3,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','FSL','',TAG_NO,0,SILVER_FINE,SILVER_FINE,100,0,CASE WHEN ITM_AMT = 0 THEN SILVER_FINE ELSE 0 END,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND SILVER_FINE <> 0 AND C.MAIN_BOOK ='PURCHASE'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,4,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,A.IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (KR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'S' AND C.MAIN_BOOK = 'KARIGAR RECEIPT'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,3,SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','FSL','',TAG_NO,0,SILVER_FINE,SILVER_FINE,100,0,CASE WHEN ITM_AMT = 0 THEN SILVER_FINE ELSE 0 END,  0,0,0,0,0,0,0,0,'F','+','',C.DATA_TYPE   FROM (PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND SILVER_FINE <> 0 AND C.MAIN_BOOK ='KARIGAR RECEIPT'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,5,0,A.VCH_DATE,B.BOOK_SNAME,B.MAIN_BOOK,  A.AC_CODE,'','00004','','','',0,0,0,0,0,A.SILVER_FINE_DR,  0,0,0,0,0,0,0,0,'F','-','',B.DATA_TYPE   FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND A.SILVER_FINE_DR <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,6,0,A.VCH_DATE,B.BOOK_SNAME,B.MAIN_BOOK,  A.AC_CODE,'','00009','','','',0,0,0,0,0,A.SILVER_FINE_CR,  0,0,0,0,0,0,0,0,'F','+','',B.DATA_TYPE   FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND A.SILVER_FINE_CR <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,7,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  FINE_RATE,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE <> 'G'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_AMT+DR_AMT <> 0 AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,8,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,0,  FINE_RATE,0,0,0,0,0,CASE WHEN SIGN = '-' THEN CR_AMT ELSE 0 END,CASE WHEN SIGN = '+' THEN DR_AMT ELSE 0 END,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_AMT+DR_AMT <> 0 AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,9,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  FINE_RATE,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE <> 'G' AND BOOK_NAME <> 'FINE JV' AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND LD_CODE = '00098' AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,10,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'S' AND BOOK_NAME = 'FINE JV' AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,11,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,0,  0,0,0,0,0,0,0,DR_AMT,'F','-','',DATA_TYPE   FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND DR_AMT <> 0 AND FINE_WT = 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,12,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,0,  0,0,0,0,0,0,CR_AMT,0,'F','+','',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND CR_AMT <> 0 AND FINE_WT = 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,13,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'FSL','FINE SILVER','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND IT_TYPE = 'S' AND FINE_WT <> 0 AND BOOK_NAME = 'TR_AC_OPBL'"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,14,RIGHT(LEDR_KEY,2),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'INT FINE','00061','','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'S'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' AND LD_CODE = '00061' "), (object)" AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,15,RIGHT(LEDR_KEY,2),VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,FINE_WT,  0,0,0,0,0,0,0,0,'F',SIGN,'',DATA_TYPE   FROM AC_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND IT_TYPE = 'S'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' AND BOOK_NAME = 'LABOUR WORK' "), (object)" AND FINE_WT <> 0 "));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,16,A.SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',A.TAG_NO,A.STK_PCS,A.STK_GWT,A.STK_NWT,A.ITM_TOUCH,A.ITM_WEST_PRC,A.STK_FINE,  0,0,0,0,0,0,0,0,'F','-','','B'   FROM (CUT_STK_DETL AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND A.STK_FINE <> 0 AND AC_CODE <> '' AND B.IT_TYPE = 'S' AND C.MAIN_BOOK IN ('FINE PURC','FINE SALE')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,17,A.SR_NO,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',A.TAG_NO,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_TOUCH,A.ITM_WEST_PRC,A.ITM_FINE,  0,0,A.LBR_RATE,A.LBR_AMT,A.OTH_AMT,A.NET_AMT,0,0,'F','+','',C.DATA_TYPE   FROM (RATE_CUT_REC AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'S' AND AC_CODE <> '' AND C.MAIN_BOOK IN ('WH RTN')"));
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
			if (Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0)
			{
				num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
				num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.000"));
			}
			else
			{
				num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
				num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'   AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
			if (Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0)
			{
				num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
				num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.000"));
			}
			else
			{
				num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
				num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
		}
		CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {FINE_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {FINE_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " and {FINE_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Ledr With Silver Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Ledr With Silver Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			DC_Main.MsCrForName1 = "FromDate";
			DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
			DC_Main.MsCrForName2 = "ToDate";
			DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName3 = "OpBal";
			DC_Main.MsCrForVal3 = Strings.Format((object)num3, "0.000");
			DC_Main.MsCrForName4 = "ClBal";
			DC_Main.MsCrForVal4 = Strings.Format((object)num6, "0.000");
			DC_Main.MsCrForName5 = "OpAmtBal";
			DC_Main.MsCrForVal5 = Strings.Format((object)num, "0.00");
			DC_Main.MsCrForName6 = "ClAmtBal";
			DC_Main.MsCrForVal6 = Strings.Format((object)num4, "0.00");
			DC_Main.MsCrForName7 = "DataType";
			DC_Main.MsCrForStr7 = "'" + DC_Main.MsDataType + "'";
			if ((int)Interaction.MsgBox((object)"Hz Jama Udhar Silver Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.RptName = "JmUdFineSlHz";
			}
			else
			{
				DC_Main.RptName = "JmUdFineSl";
			}
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Hz Jama Udhar Silver Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineSlHz.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdFineSl.RPT";
			}
			if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
			{
				Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Ledr With Silver Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'Ledr With Silver Fine Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num3, "0.000")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num6, "0.000")) ?? "";
			Cr[(short)5] = ("OpAmtBal = " + Strings.Format((object)num, "0.00")) ?? "";
			Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";
			Cr[(short)7] = "DataType = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
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

	private void BtnJmaUdhar_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
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
		checked
		{
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "' AND {MAIN_STOCK.CO_BOOK} <> '018' AND {MAIN_STOCK.ITM_SIGN} = '-' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " and {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Party Wise Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Party Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "AcSaleWhRpt";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcSaleWhRpt.RPT";
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Party Wise Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = 'Party Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					UT_REPORT uT_REPORT = new UT_REPORT();
					((Control)uT_REPORT).Show();
					((Control)uT_REPORT).Focus();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
				return;
			}
			DC_Main.ExeQuteDc("DELETE FROM FINE_DATA ");
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,1,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  A.AC_CODE,'',LD_CODE,'',IT_DESC,'',0,0,0,0,0,0,  0,0,0,0,0,0,0,DR_AMT,'F','-','L',DATA_TYPE   FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LD_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' AND B.AC_GR NOT IN ('25','30') "), (object)" AND DR_AMT <> 0 AND FINE_WT = 0 "));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,2,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  A.AC_CODE,'',LD_CODE,'',IT_DESC,'',0,0,0,0,0,0,  0,0,0,0,0,0,CR_AMT,0,'F','+','L',DATA_TYPE   FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LD_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' AND B.AC_GR NOT IN ('25','30') "), (object)" AND CR_AMT <> 0 AND FINE_WT = 0 "));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,2,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  LD_CODE,'',A.AC_CODE,'','','',0,0,0,0,0,0,  0,0,0,0,0,0,DR_AMT,0,'A','+','L',DATA_TYPE   FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.LD_CODE = '"), (object)tAcCode.Text), (object)"' AND B.AC_GR IN ('12') "), (object)" AND DR_AMT <> 0 AND FINE_WT = 0 "));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,3,A.ISR_NO,A.VCH_DATE,A.VCH_TYPE,A.BOOK_NAME,  A.AC_CODE,'','',A.IT_CODE,B.IT_NAME,A.TAG_NO,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_TOUCH,A.ITM_WEST,A.ITM_FINE,  A.ITM_RATE,A.ITM_AMT,0,A.LBR_AMT,A.OTH_AMT,A.NET_AMT,A.NET_AMT,0,'F','+','S',DATA_TYPE   FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND A.ITM_SIGN = '+' "));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,3,A.ISR_NO,A.VCH_DATE,A.VCH_TYPE,A.BOOK_NAME,  A.AC_CODE,'','',A.IT_CODE,B.IT_NAME,A.TAG_NO,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_TOUCH,A.ITM_WEST,A.ITM_FINE,  A.ITM_RATE,A.ITM_AMT,0,A.LBR_AMT,A.OTH_AMT,A.NET_AMT,0,A.NET_AMT,'F','-','S',DATA_TYPE   FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND A.ITM_SIGN = '-' "));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,4,RIGHT(LEDR_KEY,1),VCH_DATE,VCH_TYPE,BOOK_NAME,  LD_CODE,'',A.AC_CODE,'','','',0,0,0,0,0,0,  0,0,0,0,0,0,0,CR_AMT,'A','-','L',DATA_TYPE   FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.LD_CODE = '"), (object)tAcCode.Text), (object)"' AND B.AC_GR IN ('12') "), (object)" AND CR_AMT <> 0 AND FINE_WT = 0 "));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,9,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','',A.IT_CODE,'',TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,0,0,'F','+','S',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('GHAT REC')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,10,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','999','KUNDAN WT','',0,KR_KUNDAN_WT,KR_KUNDAN_WT,0,0,KR_KUNDAN_WT,  0,0,0,0,0,0,0,0,'F','+','S',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND KR_KUNDAN_WT <> 0 AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('JDTR REC')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,11,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','MIX GOLD','',0,FTNG_GWT,FTNG_NWT,FTNG_TOUCH,0,FTNG_FINE,  0,0,0,0,0,0,0,0,'F','+','S',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FTNG_FINE <> 0 AND FTNG_IT_CODE = '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FTNG REC','CHEDIYA REC','PARA REC')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO FINE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,IT_CODE,IT_DESC,TAG_NO,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,  ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,CR_AMT,DR_AMT,TR_TYPE,ITM_SIGN,ENTRY_TYPE,DATA_TYPE)  SELECT A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,12,VCH_DATE,VCH_TYPE,C.MAIN_BOOK,  AC_CODE,'','','OG','MIX GOLD','',0,FTNG_GWT,FTNG_NWT,FTNG_TOUCH,0,FTNG_FINE,  0,0,0,0,0,0,0,0,'F','-','S',C.DATA_TYPE   FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.FTNG_IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND AC_CODE = '"), (object)tAcCode.Text), (object)"' "), (object)" AND FTNG_FINE <> 0 AND FTNG_IT_CODE <> '' AND B.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('FTNG ISU','CHEDIYA ISU','PARA ISU')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
				num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'   AND AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.00"));
				num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
			CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {FINE_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {FINE_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {FINE_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Party Wise Sales Purchase Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Party Wise Sales Purchase Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				DC_Main.MsCrForName1 = "FromDate";
				DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
				DC_Main.MsCrForName2 = "ToDate";
				DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
				DC_Main.MsCrForName3 = "OpBal";
				DC_Main.MsCrForVal3 = Strings.Format((object)num2, "0.000");
				DC_Main.MsCrForName4 = "ClBal";
				DC_Main.MsCrForVal4 = Strings.Format((object)num5, "0.000");
				DC_Main.MsCrForName5 = "OpAmtBal";
				DC_Main.MsCrForVal5 = Strings.Format((object)num, "0.00");
				DC_Main.MsCrForName6 = "ClAmtBal";
				DC_Main.MsCrForVal6 = Strings.Format((object)num4, "0.00");
				DC_Main.MsCrForName7 = "DataType";
				DC_Main.MsCrForStr7 = "'" + DC_Main.MsDataType + "'";
				DC_Main.RptName = "LedrInOut";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LedrInOut.RPT";
				if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
				{
					Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Party Wise Sales Purchase Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					Cr[(short)0] = "RptTitel = 'Party Wise Sales Purchase Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
				Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
				Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.00")) ?? "";
				Cr[(short)4] = ("ClBal = " + Strings.Format((object)num5, "0.00")) ?? "";
				Cr[(short)5] = ("OpAmtBal = " + Strings.Format((object)num, "0.00")) ?? "";
				Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";
				Cr[(short)7] = "DataType = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				UT_REPORT uT_REPORT2 = new UT_REPORT();
				((Control)uT_REPORT2).Show();
				((Control)uT_REPORT2).Focus();
				CurFormula = "";
			}
			else
			{
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void tKhataNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tKhataNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_KHATA_NO = '" + tKhataNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_KHATA_NO as KhataNoL,AC_NAME As PartyNameL,AC_ADD1 As AddressL,AC_CITY As CityL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_KHATA_NO <> ''  ORDER BY AC_KHATA_NO";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 300.0;
				DC_Main.ColWidth[2] = 250.0;
				DC_Main.ColWidth[3] = 170.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tKhataNo.Text = DC_Main.ColValue[0];
					}
					AcSumm();
					((Control)tKhataNo).Focus();
				}
			}
			else
			{
				AcSumm();
			}
		}
		else
		{
			AcSumm();
		}
	}

	private void DGV_RowEnter(object sender, DataGridViewCellEventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataGridViewRow val = default(DataGridViewRow);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (DgvAcEnter)
					{
						goto end_IL_0001;
					}
					goto IL_0014;
				case 433:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001_2;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_0014;
						case 3:
							goto IL_0027;
						case 4:
							goto IL_003a;
						case 5:
							goto IL_0051;
						case 6:
							goto IL_005a;
						case 7:
							goto IL_0074;
						case 8:
							goto IL_00bb;
						case 9:
							goto IL_00e9;
						case 11:
							goto end_IL_0001_3;
						default:
							goto end_IL_0001_2;
						case 10:
						case 12:
						case 13:
						case 14:
						case 15:
							goto end_IL_0001;
						}
						goto default;
					}
					IL_0074:
					num2 = 7;
					lblAdd1.Text = val.Cells[3].Value.ToString() + " - " + val.Cells[12].Value.ToString();
					goto IL_00bb;
					IL_00bb:
					num2 = 8;
					if (Operators.CompareString(val.Cells[13].Value.ToString(), "", false) == 0)
					{
						break;
					}
					goto IL_00e9;
					IL_005a:
					num2 = 6;
					val = ((DataGridView)DGV_AC).Rows[e.RowIndex];
					goto IL_0074;
					IL_00e9:
					num2 = 9;
					lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(val.Cells[4].Value, (object)"  KhataNo - "), val.Cells[13].Value));
					goto end_IL_0001;
					IL_0014:
					num2 = 2;
					lblAdd1.Text = "";
					goto IL_0027;
					IL_0027:
					num2 = 3;
					lblMobile.Text = "";
					goto IL_003a;
					IL_003a:
					num2 = 4;
					if (e.RowIndex < 0)
					{
						goto end_IL_0001;
					}
					goto IL_0051;
					IL_0051:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_005a;
					end_IL_0001_3:
					break;
				}
				num2 = 11;
				lblMobile.Text = Conversions.ToString(val.Cells[4].Value);
				break;
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 433;
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

	private void BtnF1_Click(object sender, EventArgs e)
	{
		DC_Main.LdrAcMastCode = tAcCode.Text;
		MS_ACCT mS_ACCT = new MS_ACCT();
		((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)mS_ACCT).Show();
		((Control)mS_ACCT).Focus();
	}

	private void chkOpBal_CheckedChanged(object sender, EventArgs e)
	{
		AcSumm();
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
				DGV_DETL_FILL();
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

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select B.AC_NAME,A.AC_REF_CODE From AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.AC_REF_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.AC_REF_CODE = '" + tRefAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.AC_REF_CODE As AcCodeL,B.AC_CITY AS CityL,B.AC_ADD1 As AddressL,B.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.AC_REF_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_REF_CODE <> '' GROUP BY B.AC_NAME,A.AC_REF_CODE,B.AC_CITY,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[7];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 220.0;
				DC_Main.ColWidth[3] = 280.0;
				DC_Main.ColWidth[4] = 120.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				AcSumm();
				((TextBoxBase)tRefAc).SelectAll();
			}
		}
		else
		{
			AcSumm();
			((TextBoxBase)tRefAc).SelectAll();
		}
	}

	private void BtnTimeWise_Click(object sender, EventArgs e)
	{
		((Control)PnlMonth).Visible = true;
		((Control)DGV_MONTH).Visible = true;
		TimeLedr_Dr();
	}

	private void TimeLedr_Dr()
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Expected O, but got Unknown
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		int num7 = 0;
		((DataGridView)DGV_MONTH).DataSource = null;
		((DataGridView)DGV_MONTH).ClearSelection();
		((DataGridView)DGV_MONTH).Rows.Clear();
		((DataGridView)DGV_MONTH).Columns.Clear();
		((Control)DGV_MONTH).Refresh();
		((Control)DgvTot).Visible = false;
		((Control)DGV_MONTH).Height = 475;
		((DataGridView)DGV_MONTH).MultiSelect = false;
		((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_MONTH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_MONTH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_MONTH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_MONTH).AutoGenerateColumns = false;
		((DataGridView)DGV_MONTH).ColumnCount = 23;
		((DataGridView)DGV_MONTH).Columns[0].Frozen = true;
		((DataGridView)DGV_MONTH).Columns[1].Frozen = true;
		((DataGridView)DGV_MONTH).Columns[2].Frozen = true;
		((DataGridView)DGV_MONTH).Columns[0].HeaderText = "Sr";
		checked
		{
			((DataGridView)DGV_MONTH).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[1].HeaderText = "AcName";
			((DataGridView)DGV_MONTH).Columns[1].Width = (int)Math.Round(260.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[2].HeaderText = "Moble";
			((DataGridView)DGV_MONTH).Columns[2].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[3].HeaderText = "Amt15";
			((DataGridView)DGV_MONTH).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[3].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[4].HeaderText = "Amt30";
			((DataGridView)DGV_MONTH).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[4].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[5].HeaderText = "Amt45";
			((DataGridView)DGV_MONTH).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[6].HeaderText = "Amt60";
			((DataGridView)DGV_MONTH).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[7].HeaderText = "Amt90";
			((DataGridView)DGV_MONTH).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[8].HeaderText = "Amt120";
			((DataGridView)DGV_MONTH).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[9].HeaderText = "Amt150";
			((DataGridView)DGV_MONTH).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[10].HeaderText = "<Amt151";
			((DataGridView)DGV_MONTH).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[11].HeaderText = "Amt";
			((DataGridView)DGV_MONTH).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_MONTH).Columns[12].HeaderText = "Wt15";
			((DataGridView)DGV_MONTH).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[13].HeaderText = "Wt30";
			((DataGridView)DGV_MONTH).Columns[13].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[14].HeaderText = "Wt45";
			((DataGridView)DGV_MONTH).Columns[14].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[15].HeaderText = "Wt60";
			((DataGridView)DGV_MONTH).Columns[15].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[16].HeaderText = "Wt90";
			((DataGridView)DGV_MONTH).Columns[16].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[17].HeaderText = "Wt120";
			((DataGridView)DGV_MONTH).Columns[17].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[17].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[18].HeaderText = "Wt150";
			((DataGridView)DGV_MONTH).Columns[18].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[18].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[19].HeaderText = "<Wt151";
			((DataGridView)DGV_MONTH).Columns[19].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[19].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[20].HeaderText = "Wt";
			((DataGridView)DGV_MONTH).Columns[20].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_MONTH).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_MONTH).Columns[20].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_MONTH).Columns[21].HeaderText = "AcCode";
			((DataGridView)DGV_MONTH).Columns[21].Visible = false;
			((DataGridView)DGV_MONTH).Columns[22].HeaderText = "Add1";
			((DataGridView)DGV_MONTH).Columns[22].Visible = false;
			if (!chkHalfMonth.Checked)
			{
				((DataGridView)DGV_MONTH).Columns[3].Visible = false;
				((DataGridView)DGV_MONTH).Columns[4].Visible = false;
				((DataGridView)DGV_MONTH).Columns[5].Visible = false;
				((DataGridView)DGV_MONTH).Columns[12].Visible = false;
				((DataGridView)DGV_MONTH).Columns[13].Visible = false;
				((DataGridView)DGV_MONTH).Columns[14].Visible = false;
			}
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_MONTH).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			bool flag = false;
			DC_Main.RsQry = "SELECT * FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				flag = true;
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.CR_AMT-A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)" HAVING Sum(A.CR_AMT-A.DR_AMT) + SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END ELSE 0 END) + SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END ELSE 0 END) <> 0 ORDER BY B.AC_NAME "));
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.CR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,SUM(A.CR_AMT) AS Amount,SUM(A.CR_GL_FINE) As GoldWt,SUM(A.CR_GL_FINE) As SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(table);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-15.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-15.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView2 = new DataView(table2);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-16.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-30.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-16.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-30.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView3 = new DataView(table3);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-31.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-45.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-31.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-45.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView4 = new DataView(table4);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-46.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-60.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-46.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-60.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table5 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView5 = new DataView(table5);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)"  AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-61.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-90.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-61.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-90.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table6 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView6 = new DataView(table6);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-91.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-120.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-91.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-120.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table7 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView7 = new DataView(table7);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-121.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-150.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-121.0), "MM/dd/yyyy")), (object)"' and VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-150.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table8 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView8 = new DataView(table8);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(CASE WHEN A.IT_TYPE = 'G' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as GoldWt,SUM(CASE WHEN A.IT_TYPE = 'S' THEN CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)"  AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(flag, (object)"AND A.CO_BOOK <> '000'", (object)"")), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboAcType.Text, "", false) == 0, (object)"", (object)("AND B.AC_TYPE = '" + cboAcType.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-151.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE "), (object)"UNION ALL SELECT A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,Sum(A.DR_AMT) as Amount,SUM(A.DR_GL_FINE) as GoldWt,SUM(A.CR_GL_FINE) as SilverWt FROM OP_LDR AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-151.0), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME "));
			DataTable table9 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView9 = new DataView(table9);
			num7 = 0;
			if (dataTable.Rows.Count == 0)
			{
				return;
			}
			DevComponents.DotNetBar.Controls.DataGridViewX dGV_MONTH = DGV_MONTH;
			if (dataTable.Rows.Count == 0)
			{
				return;
			}
			int num8 = dataTable.Rows.Count - 1;
			DC_Main.M = 0;
			double num16 = default(double);
			double num17 = default(double);
			double num18 = default(double);
			double num19 = default(double);
			double num20 = default(double);
			double num21 = default(double);
			double num22 = default(double);
			double num23 = default(double);
			double num24 = default(double);
			double num25 = default(double);
			double num26 = default(double);
			double num27 = default(double);
			double num28 = default(double);
			double num29 = default(double);
			double num30 = default(double);
			double num31 = default(double);
			while (DC_Main.M <= num8)
			{
				double num9 = 0.0;
				if (cboFineType.SelectedIndex == 0)
				{
					if (Operators.ConditionalCompareObjectLess(dataTable.Rows[DC_Main.M]["Amount"], (object)0, false))
					{
						num9 = Conversions.ToDouble(dataTable.Rows[DC_Main.M]["Amount"]);
					}
					if (Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["GoldWt"]), "0.000")) < 0.0)
					{
						num9 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["GoldWt"]), "0.000"));
					}
				}
				else
				{
					if (Operators.ConditionalCompareObjectLess(dataTable.Rows[DC_Main.M]["Amount"], (object)0, false))
					{
						num9 = Conversions.ToDouble(dataTable.Rows[DC_Main.M]["Amount"]);
					}
					if (Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SilverWt"]), "0.000")) < 0.0)
					{
						num9 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SilverWt"]), "0.000"));
					}
				}
				if (num9 != 0.0)
				{
					((DataGridView)dGV_MONTH).Rows.Add();
					((DataGridView)dGV_MONTH)[0, num7].Value = num7 + 1;
					((DataGridView)dGV_MONTH)[21, num7].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["AC_CODE"], (object)"");
					((DataGridView)dGV_MONTH)[1, num7].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["AC_NAME"], (object)"");
					((DataGridView)dGV_MONTH)[22, num7].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["AC_ADD1"], (object)"");
					((DataGridView)dGV_MONTH)[2, num7].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["AC_MOBILE"], (object)"");
					if (Operators.ConditionalCompareObjectLess(dataTable.Rows[DC_Main.M]["Amount"], (object)0, false))
					{
						DataGridViewCell obj = ((DataGridView)dGV_MONTH)[11, num7];
						Type? typeFromHandle = typeof(Math);
						DataRow dataRow;
						object[] obj2 = new object[1] { (dataRow = dataTable.Rows[DC_Main.M])["Amount"] };
						object[] array = obj2;
						bool[] obj3 = new bool[1] { true };
						bool[] array2 = obj3;
						object obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj2, (string[])null, (Type[])null, obj3);
						if (array2[0])
						{
							dataRow["Amount"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
						}
						obj.Value = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0");
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[11, num7].Value));
					}
					if (cboFineType.SelectedIndex == 1 && Operators.ConditionalCompareObjectLess(dataTable.Rows[DC_Main.M]["SilverWt"], (object)0, false))
					{
						DataGridViewCell obj5 = ((DataGridView)dGV_MONTH)[20, num7];
						Type? typeFromHandle2 = typeof(Math);
						DataRow dataRow;
						object[] obj6 = new object[1] { (dataRow = dataTable.Rows[DC_Main.M])["SilverWt"] };
						object[] array = obj6;
						bool[] obj7 = new bool[1] { true };
						bool[] array2 = obj7;
						object obj8 = NewLateBinding.LateGet((object)null, typeFromHandle2, "Abs", obj6, (string[])null, (Type[])null, obj7);
						if (array2[0])
						{
							dataRow["SilverWt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
						}
						obj5.Value = Strings.Format(RuntimeHelpers.GetObjectValue(obj8), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[20, num7].Value)) == 0.0)
						{
							((DataGridView)dGV_MONTH)[20, num7].Value = "";
						}
						num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[20, num7].Value));
					}
					if (cboFineType.SelectedIndex == 0 && Operators.ConditionalCompareObjectLess(dataTable.Rows[DC_Main.M]["GoldWt"], (object)0, false))
					{
						DataGridViewCell obj9 = ((DataGridView)dGV_MONTH)[20, num7];
						Type? typeFromHandle3 = typeof(Math);
						DataRow dataRow;
						object[] obj10 = new object[1] { (dataRow = dataTable.Rows[DC_Main.M])["GoldWt"] };
						object[] array = obj10;
						bool[] obj11 = new bool[1] { true };
						bool[] array2 = obj11;
						object obj12 = NewLateBinding.LateGet((object)null, typeFromHandle3, "Abs", obj10, (string[])null, (Type[])null, obj11);
						if (array2[0])
						{
							dataRow["GoldWt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
						}
						obj9.Value = Strings.Format(RuntimeHelpers.GetObjectValue(obj12), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[20, num7].Value)) == 0.0)
						{
							((DataGridView)dGV_MONTH)[20, num7].Value = "";
						}
						num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[20, num7].Value));
					}
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					DC_Main.R = 0;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					while (DC_Main.R < dataView.Count)
					{
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, dataView[DC_Main.R]["Amount"]));
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, dataView[DC_Main.R]["GoldWt"]));
						num12 = Conversions.ToDouble(Operators.AddObject((object)num12, dataView[DC_Main.R]["SilverWt"]));
						DC_Main.R++;
					}
					dataView9.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView9.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView9.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView9[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView9[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView9[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[10, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[19, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[19, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num16 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[10, num7].Value));
						num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[19, num7].Value));
					}
					dataView8.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView8.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView8.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView8[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView8[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView8[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[9, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[18, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[18, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num18 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[9, num7].Value));
						num19 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[18, num7].Value));
					}
					dataView7.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView7.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView7.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView7[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView7[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView7[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[8, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[17, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[17, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num20 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[8, num7].Value));
						num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[17, num7].Value));
					}
					dataView6.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView6.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView6.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView6[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView6[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView6[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[7, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[16, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[16, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num22 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[7, num7].Value));
						num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[16, num7].Value));
					}
					dataView5.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView5.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView5.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView5[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView5[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView5[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[6, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[15, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[15, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num24 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[6, num7].Value));
						num25 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[15, num7].Value));
					}
					dataView4.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView4.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView4.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView4[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView4[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView4[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[5, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[14, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[14, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num26 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[5, num7].Value));
						num27 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[14, num7].Value));
					}
					dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView3.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView3.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView3[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView3[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView3[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (!(num10 - num13 <= 0.0))
							{
								num10 = ((!(num10 >= num13)) ? 0.0 : (num10 - num13));
							}
							else
							{
								((DataGridView)dGV_MONTH)[4, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (!(num12 - num15 <= 0.0))
								{
									num12 = ((!(num12 >= num15)) ? 0.0 : (num12 - num15));
								}
								else
								{
									((DataGridView)dGV_MONTH)[13, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (!(num11 - num14 <= 0.0))
							{
								num11 = ((!(num11 >= num14)) ? 0.0 : (num11 - num14));
							}
							else
							{
								((DataGridView)dGV_MONTH)[13, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
						}
						num28 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[4, num7].Value));
						num29 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[13, num7].Value));
					}
					dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = '", dataTable.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					if (dataView2.Count > 0)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						DC_Main.R = 0;
						while (DC_Main.R < dataView2.Count)
						{
							num13 = Conversions.ToDouble(Operators.AddObject((object)num13, dataView2[DC_Main.R]["Amount"]));
							num14 = Conversions.ToDouble(Operators.AddObject((object)num14, dataView2[DC_Main.R]["GoldWt"]));
							num15 = Conversions.ToDouble(Operators.AddObject((object)num15, dataView2[DC_Main.R]["SilverWt"]));
							DC_Main.R++;
						}
						if (num13 != 0.0)
						{
							if (num10 - num13 <= 0.0)
							{
								((DataGridView)dGV_MONTH)[3, num7].Value = Strings.Format((object)Math.Abs(num13 - num10), "0.00");
								num10 = 0.0;
							}
							else if (num10 >= num13)
							{
								num10 -= num13;
							}
							else
							{
								num10 = 0.0;
							}
						}
						if (cboFineType.SelectedIndex == 1)
						{
							if (num15 != 0.0)
							{
								if (num12 - num15 <= 0.0)
								{
									((DataGridView)dGV_MONTH)[12, num7].Value = Strings.Format((object)Math.Abs(num15 - num12), "0.000");
									num12 = 0.0;
								}
								else if (num12 >= num15)
								{
									num12 -= num15;
								}
								else
								{
									num12 = 0.0;
								}
							}
						}
						else if (cboFineType.SelectedIndex == 0 && num14 != 0.0)
						{
							if (num11 - num14 <= 0.0)
							{
								((DataGridView)dGV_MONTH)[12, num7].Value = Strings.Format((object)Math.Abs(num14 - num11), "0.000");
								num11 = 0.0;
							}
							else if (num11 >= num14)
							{
								num11 -= num14;
							}
							else
							{
								num11 = 0.0;
							}
						}
						num30 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[3, num7].Value));
						num31 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_MONTH)[12, num7].Value));
					}
					num7++;
				}
				DC_Main.R++;
				DC_Main.M++;
			}
			((DataGridView)dGV_MONTH).Rows.Add();
			((DataGridView)dGV_MONTH).Rows.Add();
			num7++;
			((DataGridView)dGV_MONTH)[1, num7].Value = "Grand Total";
			((DataGridView)dGV_MONTH)[3, num7].Value = Strings.Format((object)Math.Abs(num30), "0");
			((DataGridView)dGV_MONTH)[12, num7].Value = Strings.Format((object)Math.Abs(num31), "0.000");
			((DataGridView)dGV_MONTH)[4, num7].Value = Strings.Format((object)Math.Abs(num28), "0");
			((DataGridView)dGV_MONTH)[13, num7].Value = Strings.Format((object)Math.Abs(num29), "0.000");
			((DataGridView)dGV_MONTH)[5, num7].Value = Strings.Format((object)Math.Abs(num26), "0");
			((DataGridView)dGV_MONTH)[14, num7].Value = Strings.Format((object)Math.Abs(num27), "0.000");
			((DataGridView)dGV_MONTH)[6, num7].Value = Strings.Format((object)Math.Abs(num24), "0");
			((DataGridView)dGV_MONTH)[15, num7].Value = Strings.Format((object)Math.Abs(num25), "0.000");
			((DataGridView)dGV_MONTH)[7, num7].Value = Strings.Format((object)Math.Abs(num22), "0");
			((DataGridView)dGV_MONTH)[16, num7].Value = Strings.Format((object)Math.Abs(num23), "0.000");
			((DataGridView)dGV_MONTH)[8, num7].Value = Strings.Format((object)Math.Abs(num20), "0");
			((DataGridView)dGV_MONTH)[17, num7].Value = Strings.Format((object)Math.Abs(num21), "0.000");
			((DataGridView)dGV_MONTH)[9, num7].Value = Strings.Format((object)Math.Abs(num18), "0");
			((DataGridView)dGV_MONTH)[18, num7].Value = Strings.Format((object)Math.Abs(num19), "0.000");
			((DataGridView)dGV_MONTH)[10, num7].Value = Strings.Format((object)Math.Abs(num16), "0");
			((DataGridView)dGV_MONTH)[19, num7].Value = Strings.Format((object)Math.Abs(num17), "0.000");
			((DataGridView)dGV_MONTH)[11, num7].Value = Strings.Format((object)Math.Abs(num), "0");
			if (cboFineType.SelectedIndex == 0)
			{
				((DataGridView)dGV_MONTH)[20, num7].Value = Strings.Format((object)Math.Abs(num3), "0.000");
			}
			else
			{
				((DataGridView)dGV_MONTH)[20, num7].Value = Strings.Format((object)Math.Abs(num5), "0.000");
			}
			((Control)DGV_MONTH).Height = ((Control)DGV_AC).Height;
			((Control)tSearch).Focus();
			dGV_MONTH = null;
		}
	}

	private void chkHalfMonth_CheckStateChanged(object sender, EventArgs e)
	{
		TimeLedr_Dr();
	}

	private void DGV_MONTH_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlAcSumm).Visible = false;
		((Control)tLcCode).Visible = false;
		((Control)DGV_MONTH).Visible = false;
		DgvDtlRow = 0;
		int columnIndex = ((DataGridView)DGV_MONTH).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_MONTH).CurrentRow).Index;
		DgvCurRow = ((DataGridViewBand)((DataGridView)DGV_MONTH).CurrentRow).Index;
		tAcCode.Text = ((DataGridView)DGV_MONTH)[21, index].Value.ToString();
		tAcName.Text = ((DataGridView)DGV_MONTH)[1, index].Value.ToString();
		lblRefby.Text = "";
		lblAdd1.Text = ((DataGridView)DGV_MONTH)[22, index].Value.ToString();
		lblMobile.Text = ((DataGridView)DGV_MONTH)[2, index].Value.ToString();
		DC_Main.RsQry = "SELECT LAST_DATE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LAST_DATE"])))
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
			else if (DateTime.Compare(Conversions.ToDate(DC_Main.Tbl.Rows[0]["LAST_DATE"]), DC_Main.MOp_dt) > 0)
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
			else
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
		}
		if (chkVchSum.Checked)
		{
			BtnExit.Text = "&Back";
			BtnCancel.Text = "&Main";
			((Control)BtnGold).Visible = true;
			((Control)BtnSilver).Visible = true;
			((Control)BtnJmaUdhar).Visible = true;
			((Control)btnPurcRpt).Visible = true;
			((Control)BtnDelete).Visible = true;
			BtnPrint.Text = "Ledr";
			((Control)DGV_VCH).Visible = true;
			DGV_VCH_FILL();
		}
		else
		{
			BtnExit.Text = "&Back1";
			BtnCancel.Text = "&Main";
			((Control)DGV_VCH).Visible = false;
			((Control)BtnGold).Visible = true;
			((Control)BtnSilver).Visible = true;
			((Control)BtnDelete).Visible = true;
			((Control)BtnJmaUdhar).Visible = true;
			((Control)btnPurcRpt).Visible = true;
			BtnPrint.Text = "Ledr";
			DGV_DETL_FILL();
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
				if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tLcCode.Text = DC_Main.ColValue[0];
					((TextBoxBase)tLcCode).SelectAll();
				}
			}
			else
			{
				AcSumm();
			}
		}
		else
		{
			AcSumm();
		}
	}

	private void BtnPurcRpt_Click(object sender, EventArgs e)
	{
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
		checked
		{
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "' AND {MAIN_STOCK.CO_BOOK} <> '019'  AND {MAIN_STOCK.ITM_SIGN} = '+' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " and {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Party Wise Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						DC_Main.MsRptTitel = "RptTitel";
						DC_Main.MsRptTitelStr = "'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					DC_Main.RptName = "AcPurcWhRpt";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcPurcWhRpt.RPT";
					if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
					{
						Cr[(short)0] = "RptTitel = 'Branch - " + tLcCode.Text + " Party Wise Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
					else
					{
						Cr[(short)0] = "RptTitel = 'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					}
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = CurFormula;
					UT_REPORT uT_REPORT = new UT_REPORT();
					((Control)uT_REPORT).Show();
					((Control)uT_REPORT).Focus();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
				return;
			}
			CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				if ((Operators.CompareString(tLcCode.Text, "", false) != 0) & DC_Main.MsLcBoxShow)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Branch - " + tLcCode.Text + " Party Wise Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				else
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				}
				DC_Main.RptName = "AcPurcRpt";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcPurcRpt.RPT";
				Cr[(short)0] = "RptTitel = 'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				UT_REPORT uT_REPORT2 = new UT_REPORT();
				((Control)uT_REPORT2).Show();
				((Control)uT_REPORT2).Focus();
				CurFormula = "";
			}
			else
			{
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void cboArea_DropDownClosed(object sender, EventArgs e)
	{
		AcSumm();
	}

	private void cboCity_DropDownClosed(object sender, EventArgs e)
	{
		AcSumm();
	}

	private void DGV_VCH_DoubleClick(object sender, EventArgs e)
	{
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)
		{
			return;
		}
		DgvDtlRow = ((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[18].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
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
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[2].Value, (object)""));
			if ((double)Strings.Len(DC_Main.CurBookVch) < Conversions.ToDouble("00000"))
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
				Interaction.MsgBox((object)"This Is a Opening Ledger Voucher You Cant Zoom ....", (MsgBoxStyle)0, (object)null);
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
			else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
			{
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
			{
				TR_CASH tR_CASH2 = new TR_CASH();
				((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH2).Show();
				((Control)tR_CASH2).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
			{
				TR_CASH tR_CASH3 = new TR_CASH();
				((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH3).Show();
				((Control)tR_CASH3).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
			{
				TR_CASH tR_CASH4 = new TR_CASH();
				((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH4).Show();
				((Control)tR_CASH4).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
			{
				TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
				((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_WH_SALE).Show();
				((Control)tR_WH_SALE).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
			{
				TR_CONTRA tR_CONTRA = new TR_CONTRA();
				((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CONTRA).Show();
				((Control)tR_CONTRA).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
			{
				TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
				((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CONTRA2).Show();
				((Control)tR_CONTRA2).Focus();
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
			else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
			{
				TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
				((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SL_ORD_ADJ).Show();
				((Control)tR_SL_ORD_ADJ).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
			{
				TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
				((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_TAG_WT_DIFF).Show();
				((Control)tR_TAG_WT_DIFF).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
			{
				TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
				((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MEMB_ENT).Show();
				((Control)tR_MEMB_ENT).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
			{
				TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
				((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MEMB_ADJ).Show();
				((Control)tR_MEMB_ADJ).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
			{
				TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
				((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_ISU).Show();
				((Control)tR_DHRN_ISU).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
			{
				TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
				((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_REC).Show();
				((Control)tR_DHRN_REC).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
			{
				TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_INTREC).Show();
				((Control)tR_DHRN_INTREC).Focus();
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
				TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
				((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_ISU2).Show();
				((Control)tR_DHRN_ISU2).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
			{
				TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_INTREC2).Show();
				((Control)tR_DHRN_INTREC2).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
			{
				TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
				((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_REC2).Show();
				((Control)tR_DHRN_REC2).Focus();
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
				TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
				((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_TAG_CAN).Show();
				((Control)tR_TAG_CAN).Focus();
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
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG REC ITEM", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG ISU ITEM", false) == 0))
			{
				TR_MFG_ITEM tR_MFG_ITEM = new TR_MFG_ITEM();
				((Form)tR_MFG_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ITEM).Show();
				((Control)tR_MFG_ITEM).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG MINO ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG MINO REC", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					TR_MFG_GHAT_REC tR_MFG_GHAT_REC = new TR_MFG_GHAT_REC();
					((Form)tR_MFG_GHAT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_GHAT_REC).Show();
					((Control)tR_MFG_GHAT_REC).Focus();
				}
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG STNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG STNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "DESIGN ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG CAST ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG CAST REC", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
				{
					TR_MFG_WITH_LOT tR_MFG_WITH_LOT = new TR_MFG_WITH_LOT();
					((Form)tR_MFG_WITH_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_WITH_LOT).Show();
					((Control)tR_MFG_WITH_LOT).Focus();
				}
				else if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_KR_ISU_REC).Show();
					((Control)tR_MFG_KR_ISU_REC).Focus();
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					TR_MFG_ORD_REC tR_MFG_ORD_REC = new TR_MFG_ORD_REC();
					((Form)tR_MFG_ORD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_ORD_REC).Show();
					((Control)tR_MFG_ORD_REC).Focus();
				}
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
		else
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
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)
		{
			return;
		}
		DgvDtlRow = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[18].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
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
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
			if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
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
			else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
			{
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
			{
				TR_CASH tR_CASH2 = new TR_CASH();
				((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH2).Show();
				((Control)tR_CASH2).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
			{
				TR_CASH tR_CASH3 = new TR_CASH();
				((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH3).Show();
				((Control)tR_CASH3).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
			{
				TR_CASH tR_CASH4 = new TR_CASH();
				((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CASH4).Show();
				((Control)tR_CASH4).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
			{
				TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
				((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_WH_SALE).Show();
				((Control)tR_WH_SALE).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
			{
				TR_CONTRA tR_CONTRA = new TR_CONTRA();
				((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CONTRA).Show();
				((Control)tR_CONTRA).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
			{
				TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
				((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_CONTRA2).Show();
				((Control)tR_CONTRA2).Focus();
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
			else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
			{
				TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
				((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SL_ORD_ADJ).Show();
				((Control)tR_SL_ORD_ADJ).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
			{
				TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
				((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_TAG_WT_DIFF).Show();
				((Control)tR_TAG_WT_DIFF).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
			{
				TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
				((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MEMB_ENT).Show();
				((Control)tR_MEMB_ENT).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
			{
				TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
				((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MEMB_ADJ).Show();
				((Control)tR_MEMB_ADJ).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
			{
				TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
				((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_ISU).Show();
				((Control)tR_DHRN_ISU).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
			{
				TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
				((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_REC).Show();
				((Control)tR_DHRN_REC).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
			{
				TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_INTREC).Show();
				((Control)tR_DHRN_INTREC).Focus();
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
				TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
				((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_ISU2).Show();
				((Control)tR_DHRN_ISU2).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
			{
				TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_INTREC2).Show();
				((Control)tR_DHRN_INTREC2).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
			{
				TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
				((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_DHRN_REC2).Show();
				((Control)tR_DHRN_REC2).Focus();
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
				TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
				((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_TAG_CAN).Show();
				((Control)tR_TAG_CAN).Focus();
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
			else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
			{
				TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
				((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_LEDR_ADJ).Show();
				((Control)tR_LEDR_ADJ).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG REC ITEM", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG ISU ITEM", false) == 0))
			{
				TR_MFG_ITEM tR_MFG_ITEM = new TR_MFG_ITEM();
				((Form)tR_MFG_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ITEM).Show();
				((Control)tR_MFG_ITEM).Focus();
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG MINO ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG MINO REC", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					TR_MFG_GHAT_REC tR_MFG_GHAT_REC = new TR_MFG_GHAT_REC();
					((Form)tR_MFG_GHAT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_GHAT_REC).Show();
					((Control)tR_MFG_GHAT_REC).Focus();
				}
			}
			else if ((Operators.CompareString(DC_Main.CurBookMain, "MFG STNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG STNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG POLISH REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "DESIGN ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG CAST ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG CAST REC", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
				{
					TR_MFG_WITH_LOT tR_MFG_WITH_LOT = new TR_MFG_WITH_LOT();
					((Form)tR_MFG_WITH_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_WITH_LOT).Show();
					((Control)tR_MFG_WITH_LOT).Focus();
				}
				else if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_KR_ISU_REC).Show();
					((Control)tR_MFG_KR_ISU_REC).Focus();
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					TR_MFG_ORD_REC tR_MFG_ORD_REC = new TR_MFG_ORD_REC();
					((Form)tR_MFG_ORD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_ORD_REC).Show();
					((Control)tR_MFG_ORD_REC).Focus();
				}
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
		else
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
		}
	}

	private void chkGoldCol_Click(object sender, EventArgs e)
	{
		if (chkVchSum.Checked)
		{
			DGV_VCH_FILL();
		}
		else
		{
			DGV_DETL_FILL();
		}
	}

	private void cboAcType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (((Control)PnlMonth).Visible)
			{
				TimeLedr_Dr();
			}
			else
			{
				AcSumm();
			}
		}
	}

	private void PnlMonth_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlMonth).Visible = false;
	}

	private void brnOsDay_Click(object sender, EventArgs e)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Bill Os Day";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (dataTable.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.LdrAcMastCode = tAcCode.Text;
		RP_INOUT rP_INOUT = new RP_INOUT();
		((Form)rP_INOUT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)rP_INOUT).Show();
		((Control)rP_INOUT).Focus();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(BtnExit.Text, "E&xit", false) == 0) | (Operators.CompareString(BtnExit.Text, "&Exit", false) == 0))
		{
			CLEAR_DATA();
			return;
		}
		if (Operators.CompareString(MainAcCode, "", false) == 0)
		{
			Interaction.MsgBox((object)"Thair is no Main Account code Set...", (MsgBoxStyle)0, (object)null);
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
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND B.MAIN_AC_CODE = '"), (object)MainAcCode), (object)"' and A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tRefAc.Text, "", false) == 0, (object)"", (object)("AND B.AC_REF_CODE = '" + tRefAc.Text + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + tLcCode.Text + "','" + DC_Main.MCo_year + "','000','" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "','00000','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',"), dataTable.Rows[DC_Main.X]["CrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["DrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["CrGold"]), (object)","), dataTable.Rows[DC_Main.X]["DrGold"]), (object)","), dataTable.Rows[DC_Main.X]["CrSilver"]), (object)","), dataTable.Rows[DC_Main.X]["DrSilver"]), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MainAcSumm.RPT";
			CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboState.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			Cr[(short)0] = "RptTitel = 'MAIN ACCOUNT WISE SUMMERY AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void cboState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			AcSumm();
		}
	}

	private void DGV_DETL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 112)
		{
			return;
		}
		int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
		if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_DETL)[20, index].Value, (object)"LD ADJUST", false))
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT IT_REMARK FROM LDR_ADJ_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL)[18, index].Value), (object)"' AND VCH_NO = '"), ((DataGridView)DGV_DETL)[2, index].Value), (object)"'"));
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tVchdesc.Text = Conversions.ToString(Operators.ConcatenateObject((object)"Vch Desc : ", DC_Main.Tbl.Rows[0]["IT_REMARK"]));
				((Control)pnlVchDesc).Visible = true;
			}
			else
			{
				Interaction.MsgBox((object)"Voucher Desc Not found...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void DGV_VCH_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 112)
		{
			return;
		}
		int index = ((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index;
		if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_VCH)[20, index].Value, (object)"LD ADJUST", false) && Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_VCH)[20, index].Value, (object)"LD ADJUST", false))
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT IT_REMARK FROM LDR_ADJ_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)DGV_VCH)[18, index].Value), (object)"' AND VCH_NO = '"), ((DataGridView)DGV_VCH)[2, index].Value), (object)"'"));
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tVchdesc.Text = Conversions.ToString(Operators.ConcatenateObject((object)"Vch Desc : ", DC_Main.Tbl.Rows[0]["IT_REMARK"]));
				((Control)pnlVchDesc).Visible = true;
			}
			else
			{
				Interaction.MsgBox((object)"Voucher Desc Not found...", (MsgBoxStyle)0, (object)null);
			}
		}
		if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_VCH)[20, index].Value, (object)"LD ADJUST", false))
		{
			((Control)pnlVchDesc).Visible = true;
		}
	}

	private void pnlVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)pnlVchDesc).Visible = false;
			tVchdesc.Text = "Vch Desc :";
		}
	}

	private void tVchdesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)pnlVchDesc).Visible = false;
			tVchdesc.Text = "Vch Desc :";
		}
	}

	private void tSerchAll_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
