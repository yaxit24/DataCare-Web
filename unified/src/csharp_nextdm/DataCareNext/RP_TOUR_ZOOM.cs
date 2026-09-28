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
public class RP_TOUR_ZOOM : Form
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
	[AccessedThroughProperty("DGV_AC")]
	private DataGridViewX _DGV_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

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
	[AccessedThroughProperty("tTagNo")]
	private TextBox _tTagNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private bool DgvAcEnter;

	private int DgvCurRow;

	private string CurRpt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cVchType = 1;

	private const int cVchDate = 2;

	private const int cVchNo = 3;

	private const int cEmpCode = 4;

	private const int cEmpName = 5;

	private const int cIsuWt = 6;

	private const int cIsuPcs = 7;

	private const int cSlPcs = 8;

	private const int cRecPcs = 9;

	private const int cPanPcs = 10;

	private const int cPanWt = 11;

	private const int cESrNo = 0;

	private const int cEVchType = 1;

	private const int cEVchDate = 2;

	private const int cEVchNo = 3;

	private const int cETagNo = 4;

	private const int cEIsuPcs = 5;

	private const int cEIsuGwt = 6;

	private const int cEIsuNwt = 7;

	private const int cEPanPcs = 8;

	private const int cEPanGwt = 9;

	private const int cEPanNwt = 10;

	private const int cESlAcName = 11;

	private const int cESlVchType = 12;

	private const int cESlVchDate = 13;

	private const int cESlVchNo = 14;

	private const int cESlPcs = 15;

	private const int cESlGwt = 16;

	private const int cESlNwt = 17;

	private const int cERecDate = 18;

	private const int cERecVchNo = 19;

	private const int cERecPcs = 20;

	private const int cERecGwt = 21;

	private const int cERecNwt = 22;

	private const int cEEmpCode = 23;

	private const int cEEmpName = 24;

	private const int cEIsuBook = 25;

	private const int cEAdjBook = 26;

	private const int cTSrNo = 0;

	private const int cTTagNo = 1;

	private const int cTVchDate = 2;

	private const int cTVchType = 3;

	private const int cTVchNo = 4;

	private const int cTEmpName = 5;

	private const int cTIsuPcs = 6;

	private const int cTIsuGwt = 7;

	private const int cTSlPcs = 8;

	private const int cTSlGwt = 9;

	private const int cTRcPcs = 10;

	private const int cTRcGwt = 11;

	private const int cTPanPcs = 12;

	private const int cTPanGwt = 13;

	private const int cTSlAcName = 14;

	private const int cTSlVchType = 15;

	private const int cTSlVchDate = 16;

	private const int cTSlVchNo = 17;

	private const int cTRcVchDate = 18;

	private const int cTRcVchNo = 19;

	private const int cTEmpCode = 20;

	private const int cTIsuBook = 21;

	private const int cTAdjBook = 22;

	private const int cTIsuYrCd = 23;

	private const int cTIsuSrNo = 24;

	private const int c1SrNo = 0;

	private const int c1EmpCode = 1;

	private const int c1EmpName = 2;

	private const int c1OpPcs = 3;

	private const int c1OPWt = 4;

	private const int c1IsuPcs = 5;

	private const int c1IsuWt = 6;

	private const int c1SlPcs = 7;

	private const int c1SlWt = 8;

	private const int c1RecPcs = 9;

	private const int c1RecWt = 10;

	private const int c1PanPcs = 11;

	private const int c1PanWt = 12;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private virtual SimpleButton _BtnPrint;

	internal virtual SimpleButton BtnPrint
	{
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnPrint = value;
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

	internal virtual DataGridViewX DGV_AC
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			KeyEventHandler val2 = new KeyEventHandler(DGV_KeyDown);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(DGV_AC_CellContentClick);
			DataGridViewX val4 = _DGV_AC;
			if (val4 != null)
			{
				((Control)val4).DoubleClick -= eventHandler;
				((DataGridView)val4).CellFormatting -= val;
				((Control)val4).KeyDown -= val2;
				((DataGridView)val4).CellContentClick -= val3;
			}
			_DGV_AC = value;
			val4 = _DGV_AC;
			if (val4 != null)
			{
				((Control)val4).DoubleClick += eventHandler;
				((DataGridView)val4).CellFormatting += val;
				((Control)val4).KeyDown += val2;
				((DataGridView)val4).CellContentClick += val3;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDesgnNo")]
	private virtual TextBox _tDesgnNo;

	internal virtual TextBox tDesgnNo
	{
		get
		{
			return _tDesgnNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tDesgnNo = value;
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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewX val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DEL")]
	private virtual DataGridViewX _DGV_DEL;

	internal virtual DataGridViewX DGV_DEL
	{
		get
		{
			return _DGV_DEL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_DEL = value;
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
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPrCode = value;
			val2 = _tPrCode;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTagNo_KeyDown);
			TextBox val2 = _tTagNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTagNo = value;
			val2 = _tTagNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItmStk")]
	private virtual CheckBox _chkItmStk;

	internal virtual CheckBox chkItmStk
	{
		get
		{
			return _chkItmStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkItmStk = value;
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
	[AccessedThroughProperty("chkOnlyTagStk")]
	private virtual CheckBox _chkOnlyTagStk;

	internal virtual CheckBox chkOnlyTagStk
	{
		get
		{
			return _chkOnlyTagStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOnlyTagStk = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuYrCd")]
	private virtual TextBox _tIsuYrCd;

	internal virtual TextBox tIsuYrCd
	{
		get
		{
			return _tIsuYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuDbCd")]
	private virtual TextBox _tIsuDbCd;

	internal virtual TextBox tIsuDbCd
	{
		get
		{
			return _tIsuDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuDbCd = value;
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

	internal virtual TextBox tIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _tIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tIsuNo_KeyDown);
			TextBox val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tIsuNo = value;
			val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	public int newindex { get; set; }

	public RP_TOUR_ZOOM()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Activated += RP_TOUR_ZOOM_Activated;
		((Form)this).Load += RP_TOUR_ZOOM_Load;
		((Form)this).Deactivate += RP_TOUR_ZOOM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_TOUR_ZOOM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_TOUR_ZOOM_KeyDown);
		((Form)this).Closed += RP_TOUR_ZOOM_Closed;
		DgvAcEnter = false;
		DgvCurRow = 0;
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
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected O, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected O, but got Unknown
		//IL_0777: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Expected O, but got Unknown
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Expected O, but got Unknown
		//IL_094a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0954: Expected O, but got Unknown
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Expected O, but got Unknown
		//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aab: Expected O, but got Unknown
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b84: Expected O, but got Unknown
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c23: Expected O, but got Unknown
		//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cab: Expected O, but got Unknown
		//IL_0d8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d97: Expected O, but got Unknown
		//IL_0e00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0a: Expected O, but got Unknown
		//IL_1107: Unknown result type (might be due to invalid IL or missing references)
		//IL_1111: Expected O, but got Unknown
		//IL_119c: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a6: Expected O, but got Unknown
		//IL_1220: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Expected O, but got Unknown
		//IL_12d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e2: Expected O, but got Unknown
		//IL_1363: Unknown result type (might be due to invalid IL or missing references)
		//IL_136d: Expected O, but got Unknown
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_144b: Expected O, but got Unknown
		//IL_152f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1539: Expected O, but got Unknown
		//IL_17e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1809: Unknown result type (might be due to invalid IL or missing references)
		//IL_182d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_187a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1884: Expected O, but got Unknown
		//IL_18a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_190a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1914: Expected O, but got Unknown
		//IL_19c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cc: Expected O, but got Unknown
		//IL_1a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a44: Expected O, but got Unknown
		//IL_1af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afc: Expected O, but got Unknown
		//IL_1b69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b73: Expected O, but got Unknown
		//IL_1c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2b: Expected O, but got Unknown
		//IL_1cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb6: Expected O, but got Unknown
		//IL_1d61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6b: Expected O, but got Unknown
		//IL_1de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df0: Expected O, but got Unknown
		//IL_1e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9d: Expected O, but got Unknown
		//IL_1f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f43: Expected O, but got Unknown
		//IL_1fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd3: Expected O, but got Unknown
		//IL_20ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c4: Expected O, but got Unknown
		//IL_212d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2137: Expected O, but got Unknown
		//IL_21e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f1: Expected O, but got Unknown
		//IL_22a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ac: Expected O, but got Unknown
		//IL_2343: Unknown result type (might be due to invalid IL or missing references)
		//IL_234d: Expected O, but got Unknown
		//IL_23cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d7: Expected O, but got Unknown
		//IL_2482: Unknown result type (might be due to invalid IL or missing references)
		//IL_248c: Expected O, but got Unknown
		//IL_2506: Unknown result type (might be due to invalid IL or missing references)
		//IL_2510: Expected O, but got Unknown
		//IL_25dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e7: Expected O, but got Unknown
		//IL_2683: Unknown result type (might be due to invalid IL or missing references)
		//IL_268d: Expected O, but got Unknown
		//IL_2713: Unknown result type (might be due to invalid IL or missing references)
		//IL_271d: Expected O, but got Unknown
		//IL_2804: Unknown result type (might be due to invalid IL or missing references)
		//IL_280e: Expected O, but got Unknown
		//IL_2877: Unknown result type (might be due to invalid IL or missing references)
		//IL_2881: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_TOUR_ZOOM));
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
		BtnCancel = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		Panel1 = new Panel();
		lblMobile = new Label();
		lblAdd1 = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV_AC = new DataGridViewX();
		PnlAcSumm = new Panel();
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		Label5 = new Label();
		tIsuNo = new TextBox();
		chkItmStk = new CheckBox();
		chkOnlyTagStk = new CheckBox();
		cboCity = new ComboBox();
		btnOk = new QButton();
		Label1 = new Label();
		tTagNo = new TextBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		Label9 = new Label();
		tPrCode = new TextBox();
		Label4 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		DGV_DEL = new DataGridViewX();
		lblCity = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		Label3 = new Label();
		tDesgnNo = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		((Control)PnlBotam).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_AC).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)DGV_DEL).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)Panel1);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 1;
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
		((Control)Panel1).Controls.Add((Control)(object)lblMobile);
		((Control)Panel1).Controls.Add((Control)(object)lblAdd1);
		((Control)Panel1).Location = new Point(591, 3);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(327, 38);
		((Control)Panel1).TabIndex = 11;
		((Control)lblMobile).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.White;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(23, 18);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).RightToLeft = (RightToLeft)1;
		((Control)lblMobile).Size = new Size(301, 20);
		((Control)lblMobile).TabIndex = 1140;
		lblMobile.Text = "Mobile";
		((Control)lblAdd1).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.White;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(23, 0);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).RightToLeft = (RightToLeft)1;
		((Control)lblAdd1).Size = new Size(301, 20);
		((Control)lblAdd1).TabIndex = 1139;
		lblAdd1.Text = "Address";
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
		lblBook.Text = "Tour Zoom Report";
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
		((Control)DGV_AC).Location = new Point(16, 78);
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
		((Control)DGV_AC).Size = new Size(1160, 440);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((Control)PnlAcSumm).Controls.Add((Control)(object)tIsuYrCd);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tIsuDbCd);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label5);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tIsuNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkItmStk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkOnlyTagStk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)btnOk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tTagNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label10);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tGrCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label9);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tPrCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label4);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_DEL);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mToDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mFromDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlAcSumm).Location = new Point(-1, 34);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 529);
		((Control)PnlAcSumm).TabIndex = 0;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuYrCd).Location = new Point(917, 45);
		((TextBoxBase)tIsuYrCd).MaxLength = 8;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(76, 22);
		((Control)tIsuYrCd).TabIndex = 1178;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuDbCd).Location = new Point(999, 45);
		((TextBoxBase)tIsuDbCd).MaxLength = 8;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(76, 22);
		((Control)tIsuDbCd).TabIndex = 1177;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(776, 47);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(53, 20);
		((Control)Label5).TabIndex = 1176;
		Label5.Text = "Isu No";
		Label5.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuNo).Location = new Point(835, 45);
		((TextBoxBase)tIsuNo).MaxLength = 8;
		((Control)tIsuNo).Name = "tIsuNo";
		((Control)tIsuNo).Size = new Size(76, 22);
		((Control)tIsuNo).TabIndex = 1175;
		((ButtonBase)chkItmStk).BackColor = Color.Transparent;
		((Control)chkItmStk).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItmStk).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkItmStk).Location = new Point(631, 48);
		((Control)chkItmStk).Name = "chkItmStk";
		((Control)chkItmStk).RightToLeft = (RightToLeft)0;
		((Control)chkItmStk).Size = new Size(135, 19);
		((Control)chkItmStk).TabIndex = 1134;
		((ButtonBase)chkItmStk).Text = "Item Wise Stock";
		((ButtonBase)chkItmStk).UseVisualStyleBackColor = false;
		((ButtonBase)chkOnlyTagStk).BackColor = Color.Transparent;
		chkOnlyTagStk.Checked = true;
		chkOnlyTagStk.CheckState = (CheckState)1;
		((Control)chkOnlyTagStk).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOnlyTagStk).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkOnlyTagStk).Location = new Point(631, 17);
		((Control)chkOnlyTagStk).Name = "chkOnlyTagStk";
		((Control)chkOnlyTagStk).RightToLeft = (RightToLeft)0;
		((Control)chkOnlyTagStk).Size = new Size(135, 19);
		((Control)chkOnlyTagStk).TabIndex = 1135;
		((ButtonBase)chkOnlyTagStk).Text = "Only Tag Stock";
		((ButtonBase)chkOnlyTagStk).UseVisualStyleBackColor = false;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(387, 15);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(98, 22);
		((Control)cboCity).TabIndex = 4;
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
		((Control)btnOk).Location = new Point(1094, 41);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(56, 30);
		((Control)btnOk).TabIndex = 1174;
		btnOk.Text = "&Ok";
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(323, 46);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1173;
		Label1.Text = "Tag No";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tTagNo).BackColor = Color.White;
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(387, 47);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(98, 22);
		((Control)tTagNo).TabIndex = 1172;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(497, 15);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 20);
		((Control)Label10).TabIndex = 1171;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(567, 15);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(49, 22);
		((Control)tGrCode).TabIndex = 1170;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(501, 47);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(60, 20);
		((Control)Label9).TabIndex = 1169;
		Label9.Text = "Pr Code";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(567, 46);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(49, 22);
		((Control)tPrCode).TabIndex = 1168;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(17, 45);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(71, 20);
		((Control)Label4).TabIndex = 1162;
		Label4.Text = "Emp Code";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(95, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(48, 22);
		((Control)tAcCode).TabIndex = 1160;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(147, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(148, 23);
		((Control)tAcName).TabIndex = 1161;
		((DataGridView)DGV_DEL).AllowUserToAddRows = false;
		((DataGridView)DGV_DEL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DEL).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_DEL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DEL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DEL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DEL).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_DEL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DEL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DEL).DefaultCellStyle = val8;
		((DataGridView)DGV_DEL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DEL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DEL).Location = new Point(17, 78);
		((Control)DGV_DEL).Name = "DGV_DEL";
		DGV_DEL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DEL).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DEL).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_DEL).RowHeadersVisible = false;
		((DataGridView)DGV_DEL).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DEL).RowsDefaultCellStyle = val10;
		DGV_DEL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DEL.SelectAllSignVisible = false;
		((DataGridView)DGV_DEL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DEL).Size = new Size(1159, 438);
		((DataGridView)DGV_DEL).StandardTab = true;
		((Control)DGV_DEL).TabIndex = 1157;
		((Control)DGV_DEL).Visible = false;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(297, 14);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(82, 19);
		((Control)lblCity).TabIndex = 1138;
		lblCity.Text = "Work Type";
		lblCity.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(177, 15);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(95, 15);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(45, 12);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(44, 20);
		((Control)Label3).TabIndex = 1156;
		Label3.Text = "Date";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tDesgnNo).BackColor = Color.White;
		((Control)tDesgnNo).Font = new Font("Tahoma", 9f);
		((Control)tDesgnNo).Location = new Point(106, 45);
		((TextBoxBase)tDesgnNo).MaxLength = 8;
		((Control)tDesgnNo).Name = "tDesgnNo";
		((Control)tDesgnNo).Size = new Size(78, 22);
		((Control)tDesgnNo).TabIndex = 3;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(13, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Design No";
		Label2.TextAlign = (ContentAlignment)64;
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
		((Control)DGV_DETL).Location = new Point(13, 79);
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
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tDesgnNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_TOUR_ZOOM";
		((Form)this).Text = "Tour Zoom";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_AC).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((ISupportInitialize)DGV_DEL).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_TOUR_ZOOM_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
			{
				Tour_Tag_Detl();
			}
			else
			{
				DGV_TOUR_FILL();
			}
		}
		CurActCtrl.Focus();
	}

	private void Tour_Tag_Detl()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataGridViewX val = default(DataGridViewX);
		double num5 = default(double);
		double num6 = default(double);
		double num7 = default(double);
		double num8 = default(double);
		double num9 = default(double);
		double num10 = default(double);
		double num11 = default(double);
		double num12 = default(double);
		DataTable dataTable = default(DataTable);
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
						((DataGridView)DGV_AC).DataSource = null;
						goto IL_0011;
					case 6772:
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
								goto IL_001f;
							case 4:
								goto IL_0032;
							case 5:
								goto IL_0045;
							case 6:
								goto IL_0053;
							case 7:
								goto IL_0062;
							case 8:
								goto IL_0085;
							case 9:
								goto IL_00a3;
							case 10:
								goto IL_00cb;
							case 11:
								goto IL_00f3;
							case 12:
								goto IL_011b;
							case 13:
							case 14:
								goto IL_0136;
							case 15:
								goto IL_014f;
							case 16:
								goto IL_015f;
							case 17:
								goto IL_017d;
							case 18:
								goto IL_01ad;
							case 19:
								goto IL_01cb;
							case 20:
								goto IL_01fb;
							case 21:
								goto IL_0219;
							case 22:
								goto IL_0249;
							case 23:
								goto IL_0267;
							case 24:
								goto IL_0297;
							case 25:
								goto IL_02b5;
							case 26:
								goto IL_02e5;
							case 27:
								goto IL_0303;
							case 28:
								goto IL_0333;
							case 29:
								goto IL_0351;
							case 30:
								goto IL_0381;
							case 31:
								goto IL_03a2;
							case 32:
								goto IL_03c0;
							case 33:
								goto IL_03f0;
							case 34:
								goto IL_0411;
							case 35:
								goto IL_0435;
							case 36:
								goto IL_0453;
							case 37:
								goto IL_0483;
							case 38:
								goto IL_04a4;
							case 39:
								goto IL_04c2;
							case 40:
								goto IL_04f3;
							case 41:
								goto IL_0515;
							case 42:
								goto IL_053a;
							case 43:
								goto IL_0558;
							case 44:
								goto IL_0589;
							case 45:
								goto IL_05ab;
							case 46:
								goto IL_05c9;
							case 47:
								goto IL_05fa;
							case 48:
								goto IL_061c;
							case 49:
								goto IL_0641;
							case 50:
								goto IL_065f;
							case 51:
								goto IL_0690;
							case 52:
								goto IL_06b2;
							case 53:
								goto IL_06d0;
							case 54:
								goto IL_0701;
							case 55:
								goto IL_0723;
							case 56:
								goto IL_0748;
							case 57:
								goto IL_0766;
							case 58:
								goto IL_0797;
							case 59:
								goto IL_07b5;
							case 60:
								goto IL_07e6;
							case 61:
								goto IL_0804;
							case 62:
								goto IL_0835;
							case 63:
								goto IL_0853;
							case 64:
								goto IL_0884;
							case 65:
								goto IL_08a2;
							case 66:
								goto IL_08d3;
							case 67:
								goto IL_08f1;
							case 68:
								goto IL_0922;
							case 69:
								goto IL_0940;
							case 70:
								goto IL_095c;
							case 71:
								goto IL_097a;
							case 72:
								goto IL_0996;
							case 73:
								goto IL_09b4;
							case 74:
								goto IL_09d0;
							case 75:
								goto IL_09dd;
							case 76:
								goto IL_09eb;
							case 77:
								goto IL_09f9;
							case 78:
								goto IL_0a07;
							case 79:
								goto IL_0a15;
							case 80:
								goto IL_0a23;
							case 81:
								goto IL_0a31;
							case 82:
								goto IL_0a3f;
							case 83:
								goto IL_0acb;
							case 84:
								goto IL_0b06;
							case 85:
								goto IL_0b1a;
							case 86:
							case 87:
								goto IL_0b33;
							case 88:
								goto IL_0b4a;
							case 90:
								goto IL_0b64;
							case 91:
								goto IL_0b7b;
							case 93:
								goto IL_0b95;
							case 94:
								goto IL_0bac;
							case 89:
							case 92:
							case 95:
							case 96:
							case 97:
								goto IL_0bc8;
							case 98:
								goto IL_0bea;
							case 99:
							case 100:
								goto IL_0c51;
							case 101:
								goto IL_0c73;
							case 102:
							case 103:
								goto IL_0c9c;
							case 104:
								goto IL_0cbe;
							case 105:
							case 106:
								goto IL_0ce7;
							case 107:
								goto IL_0d09;
							case 108:
							case 109:
								goto IL_0d32;
							case 110:
								goto IL_0d49;
							case 111:
								goto IL_0d58;
							case 112:
								goto IL_0d61;
							case 113:
								goto IL_0d6a;
							case 114:
								goto IL_0d85;
							case 115:
								goto IL_0da4;
							case 116:
								goto IL_0daf;
							case 117:
								goto IL_0dbf;
							case 118:
								goto IL_0de1;
							case 119:
								goto IL_0e17;
							case 120:
								goto IL_0e57;
							case 121:
								goto IL_0e8d;
							case 122:
								goto IL_0ec3;
							case 123:
								goto IL_0ef9;
							case 124:
								goto IL_0f2f;
							case 125:
								goto IL_0f61;
							case 126:
								goto IL_0fa2;
							case 127:
								goto IL_0fd9;
							case 128:
								goto IL_1010;
							case 130:
								goto IL_1050;
							case 131:
								goto IL_1085;
							case 132:
								goto IL_10bf;
							case 133:
								goto IL_10f9;
							case 134:
								goto IL_1142;
							case 135:
								goto IL_117c;
							case 136:
								goto IL_11b5;
							case 129:
							case 137:
							case 138:
								goto IL_11f0;
							case 139:
								goto IL_1275;
							case 140:
								goto IL_12fb;
							case 141:
								goto IL_1335;
							case 142:
								goto IL_136e;
							case 143:
								goto IL_13a8;
							case 144:
								goto IL_13e2;
							case 145:
								goto IL_140c;
							case 146:
								goto IL_1438;
							case 147:
								goto IL_1464;
							case 148:
								goto IL_1491;
							case 149:
								goto IL_14be;
							case 150:
								goto IL_14eb;
							case 151:
								goto IL_1518;
							case 152:
								goto IL_1545;
							case 153:
								goto IL_1558;
							case 154:
								goto IL_155b;
							case 155:
								goto IL_1579;
							case 156:
								goto IL_159b;
							case 157:
								goto IL_15b2;
							case 158:
							case 159:
								goto IL_15cb;
							case 160:
								goto IL_15e5;
							case 161:
								goto IL_15f9;
							case 162:
								goto IL_1627;
							case 163:
								goto IL_1656;
							case 164:
								goto IL_1686;
							case 165:
								goto IL_16b6;
							case 166:
								goto IL_16e7;
							case 167:
								goto IL_1718;
							case 168:
								goto IL_1749;
							case 169:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 170:
							case 171:
							case 172:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_1545:
						num2 = 152;
						DC_Main.R++;
						goto IL_1558;
						IL_1558:
						val = null;
						goto IL_155b;
						IL_1518:
						num2 = 151;
						num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[13, DC_Main.R].Value, (object)""));
						goto IL_1545;
						IL_155b:
						num2 = 154;
						DC_Main.M++;
						goto IL_156d;
						IL_0011:
						num2 = 2;
						((DataGridView)DGV_AC).ClearSelection();
						goto IL_001f;
						IL_001f:
						num2 = 3;
						((DataGridView)DGV_AC).Rows.Clear();
						goto IL_0032;
						IL_0032:
						num2 = 4;
						((DataGridView)DGV_AC).Columns.Clear();
						goto IL_0045;
						IL_0045:
						num2 = 5;
						((Control)DGV_AC).Refresh();
						goto IL_0053;
						IL_0053:
						num2 = 6;
						((DataGridView)DGV_AC).MultiSelect = false;
						goto IL_0062;
						IL_0062:
						num2 = 7;
						((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
						goto IL_0085;
						IL_0085:
						num2 = 8;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_00a3;
						}
						goto IL_0136;
						IL_00a3:
						num2 = 9;
						((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_00cb;
						IL_00cb:
						num2 = 10;
						((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_00f3;
						IL_00f3:
						num2 = 11;
						((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_011b;
						IL_011b:
						num2 = 12;
						((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_0136;
						IL_0136:
						num2 = 14;
						((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
						goto IL_014f;
						IL_014f:
						num2 = 15;
						((DataGridView)DGV_AC).AutoGenerateColumns = false;
						goto IL_015f;
						IL_015f:
						num2 = 16;
						((DataGridView)DGV_AC).Columns.Add("", "Sr");
						goto IL_017d;
						IL_017d:
						num2 = 17;
						((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
						goto IL_01ad;
						IL_01ad:
						num2 = 18;
						((DataGridView)DGV_AC).Columns.Add("", "TagNo");
						goto IL_01cb;
						IL_01cb:
						num2 = 19;
						((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
						goto IL_01fb;
						IL_01fb:
						num2 = 20;
						((DataGridView)DGV_AC).Columns.Add("", "IsuDate");
						goto IL_0219;
						IL_0219:
						num2 = 21;
						((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0249;
						IL_0249:
						num2 = 22;
						((DataGridView)DGV_AC).Columns.Add("", "IsuType");
						goto IL_0267;
						IL_0267:
						num2 = 23;
						((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_0297;
						IL_0297:
						num2 = 24;
						((DataGridView)DGV_AC).Columns.Add("", "IsuNo");
						goto IL_02b5;
						IL_02b5:
						num2 = 25;
						((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_02e5;
						IL_02e5:
						num2 = 26;
						((DataGridView)DGV_AC).Columns.Add("", "EmpName");
						goto IL_0303;
						IL_0303:
						num2 = 27;
						((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
						goto IL_0333;
						IL_0333:
						num2 = 28;
						((DataGridView)DGV_AC).Columns.Add("", "IPcs");
						goto IL_0351;
						IL_0351:
						num2 = 29;
						((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_0381;
						IL_0381:
						num2 = 30;
						((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_03a2;
						IL_03a2:
						num2 = 31;
						((DataGridView)DGV_AC).Columns.Add("", "IGrWt");
						goto IL_03c0;
						IL_03c0:
						num2 = 32;
						((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_03f0;
						IL_03f0:
						num2 = 33;
						((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0411;
						IL_0411:
						num2 = 34;
						((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
						goto IL_0435;
						IL_0435:
						num2 = 35;
						((DataGridView)DGV_AC).Columns.Add("", "SPcs");
						goto IL_0453;
						IL_0453:
						num2 = 36;
						((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_0483;
						IL_0483:
						num2 = 37;
						((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_04a4;
						IL_04a4:
						num2 = 38;
						((DataGridView)DGV_AC).Columns.Add("", "SlGrWt");
						goto IL_04c2;
						IL_04c2:
						num2 = 39;
						((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_04f3;
						IL_04f3:
						num2 = 40;
						((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0515;
						IL_0515:
						num2 = 41;
						((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N3";
						goto IL_053a;
						IL_053a:
						num2 = 42;
						((DataGridView)DGV_AC).Columns.Add("", "RPcs");
						goto IL_0558;
						IL_0558:
						num2 = 43;
						((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_0589;
						IL_0589:
						num2 = 44;
						((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_05ab;
						IL_05ab:
						num2 = 45;
						((DataGridView)DGV_AC).Columns.Add("", "RcGrWt");
						goto IL_05c9;
						IL_05c9:
						num2 = 46;
						((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_05fa;
						IL_05fa:
						num2 = 47;
						((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_061c;
						IL_061c:
						num2 = 48;
						((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Format = "N3";
						goto IL_0641;
						IL_0641:
						num2 = 49;
						((DataGridView)DGV_AC).Columns.Add("", "PPcs");
						goto IL_065f;
						IL_065f:
						num2 = 50;
						((DataGridView)DGV_AC).Columns[12].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_0690;
						IL_0690:
						num2 = 51;
						((DataGridView)DGV_AC).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_06b2;
						IL_06b2:
						num2 = 52;
						((DataGridView)DGV_AC).Columns.Add("", "PGrWt");
						goto IL_06d0;
						IL_06d0:
						num2 = 53;
						((DataGridView)DGV_AC).Columns[13].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_0701;
						IL_0701:
						num2 = 54;
						((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0723;
						IL_0723:
						num2 = 55;
						((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Format = "N3";
						goto IL_0748;
						IL_0748:
						num2 = 56;
						((DataGridView)DGV_AC).Columns.Add("", "Sl Pary");
						goto IL_0766;
						IL_0766:
						num2 = 57;
						((DataGridView)DGV_AC).Columns[14].Width = (int)Math.Round(150.0 * ColCon);
						goto IL_0797;
						IL_0797:
						num2 = 58;
						((DataGridView)DGV_AC).Columns.Add("", "SlType");
						goto IL_07b5;
						IL_07b5:
						num2 = 59;
						((DataGridView)DGV_AC).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
						goto IL_07e6;
						IL_07e6:
						num2 = 60;
						((DataGridView)DGV_AC).Columns.Add("", "SlDate");
						goto IL_0804;
						IL_0804:
						num2 = 61;
						((DataGridView)DGV_AC).Columns[16].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0835;
						IL_0835:
						num2 = 62;
						((DataGridView)DGV_AC).Columns.Add("", "SlVch");
						goto IL_0853;
						IL_0853:
						num2 = 63;
						((DataGridView)DGV_AC).Columns[17].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_0884;
						IL_0884:
						num2 = 64;
						((DataGridView)DGV_AC).Columns.Add("", "RcDate");
						goto IL_08a2;
						IL_08a2:
						num2 = 65;
						((DataGridView)DGV_AC).Columns[18].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_08d3;
						IL_08d3:
						num2 = 66;
						((DataGridView)DGV_AC).Columns.Add("", "RcVch");
						goto IL_08f1;
						IL_08f1:
						num2 = 67;
						((DataGridView)DGV_AC).Columns[19].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_0922;
						IL_0922:
						num2 = 68;
						((DataGridView)DGV_AC).Columns.Add("", "Emp");
						goto IL_0940;
						IL_0940:
						num2 = 69;
						((DataGridView)DGV_AC).Columns[20].Visible = false;
						goto IL_095c;
						IL_095c:
						num2 = 70;
						((DataGridView)DGV_AC).Columns.Add("", "IsuBook");
						goto IL_097a;
						IL_097a:
						num2 = 71;
						((DataGridView)DGV_AC).Columns[21].Visible = false;
						goto IL_0996;
						IL_0996:
						num2 = 72;
						((DataGridView)DGV_AC).Columns.Add("", "AdjBook");
						goto IL_09b4;
						IL_09b4:
						num2 = 73;
						((DataGridView)DGV_AC).Columns[22].Visible = false;
						goto IL_09d0;
						IL_09d0:
						num2 = 74;
						num6 = 0.0;
						goto IL_09dd;
						IL_09dd:
						num2 = 75;
						num7 = 0.0;
						goto IL_09eb;
						IL_09eb:
						num2 = 76;
						num8 = 0.0;
						goto IL_09f9;
						IL_09f9:
						num2 = 77;
						num9 = 0.0;
						goto IL_0a07;
						IL_0a07:
						num2 = 78;
						num10 = 0.0;
						goto IL_0a15;
						IL_0a15:
						num2 = 79;
						num11 = 0.0;
						goto IL_0a23;
						IL_0a23:
						num2 = 80;
						num12 = 0.0;
						goto IL_0a31;
						IL_0a31:
						num2 = 81;
						num5 = 0.0;
						goto IL_0a3f;
						IL_0a3f:
						num2 = 82;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT \r\n        A.VCH_TYPE,\r\n        A.VCH_DATE,\r\n        A.VCH_NO,\r\n        A.TAG_NO,\r\n        A.ITM_PCS,\r\n        A.ITM_GWT,\r\n        A.ITM_NWT,\r\n        A.CO_BOOK,\r\n        A.ISU_DBCD,\r\n        A.AC_CODE,\r\n\r\n        B.VCH_NO As SlVchNo,\r\n        B.VCH_DATE As SlDate,\r\n        B.ITM_PCS As SlPcs,\r\n        B.ITM_GWT As SlGwt,\r\n        B.ITM_NWT As SlNwt,\r\n\r\n        C.AC_NAME As SlAcName,\r\n        D.BOOK_NAME As AdjBook,\r\n\r\n        E.VCH_NO As RecVchNo,\r\n        E.VCH_DATE As RecDate,\r\n        E.ITM_PCS As RecPcs,\r\n        E.ITM_GWT As RecGwt,\r\n        E.ITM_NWT As RecNwt,\r\n\r\n        F.EMP_NAME\r\n\r\n        FROM APR_DETL AS A\r\n\r\n        LEFT JOIN RATE_CUT_ISU AS B \r\n        ON A.CO_CODE = B.CO_CODE \r\n        AND A.LC_CODE = B.LC_CODE \r\n        AND A.ISU_YRCD = B.CO_YEAR \r\n        AND A.ISU_DBCD = B.CO_BOOK \r\n        AND A.ISU_NO = B.VCH_NO \r\n        AND A.ISU_SRNO = B.OLD_SRNO\r\n        AND B.TAG_NO <> 'N'\r\n\r\n        LEFT JOIN AC_MAST AS C \r\n        ON B.CO_CODE = C.CO_CODE \r\n        AND B.AC_CODE = C.AC_CODE\r\n\r\n        LEFT JOIN BOOK_DATA AS D \r\n        ON B.CO_CODE = D.CO_CODE \r\n        AND B.LC_CODE = D.LC_CODE \r\n        AND B.CO_BOOK = D.CO_BOOK\r\n\r\n        LEFT JOIN APR_DETL AS E \r\n        ON A.CO_CODE = E.CO_CODE \r\n        AND A.LC_CODE = E.LC_CODE \r\n        AND A.ISU_YRCD = E.CO_YEAR \r\n        AND A.ISU_DBCD = E.CO_BOOK \r\n        AND A.ISU_NO = E.VCH_NO \r\n        AND A.ISU_SRNO = E.OLD_SRNO\r\n        AND E.TAG_NO <> 'N'\r\n\r\n        LEFT JOIN EMP_MAST AS F \r\n        ON A.CO_CODE = F.CO_CODE \r\n        AND A.AC_CODE = F.EMP_CODE\r\n\r\n        LEFT JOIN ITEM_MAST AS G \r\n        ON A.CO_CODE = G.CO_CODE \r\n        AND A.IT_CODE = G.IT_CODE\r\n\r\n        WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' \r\n        AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" AND A.AC_CODE = '" + tAcCode.Text + "' "))), (object)" AND A.BOOK_NAME = 'EMP ISU' "));
						goto IL_0acb;
						IL_0acb:
						num2 = 83;
						DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE  <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
						goto IL_0b06;
						IL_0b06:
						num2 = 84;
						if (chkOnlyTagStk.Checked)
						{
							goto IL_0b1a;
						}
						goto IL_0b33;
						IL_0b1a:
						num2 = 85;
						DC_Main.RsQry += " AND A.TAG_NO <> 'N'  ";
						goto IL_0b33;
						IL_0b33:
						num2 = 87;
						if (cboCity.SelectedIndex == 0)
						{
							goto IL_0b4a;
						}
						goto IL_0b64;
						IL_0b4a:
						num2 = 88;
						DC_Main.RsQry += " AND A.EMP_SALE = 'N' AND A.ISU_REC =  'N'";
						goto IL_0bc8;
						IL_0b64:
						num2 = 90;
						if (cboCity.SelectedIndex == 1)
						{
							goto IL_0b7b;
						}
						goto IL_0b95;
						IL_0b7b:
						num2 = 91;
						DC_Main.RsQry += " AND A.EMP_SALE =  'Y' ";
						goto IL_0bc8;
						IL_0b95:
						num2 = 93;
						if (cboCity.SelectedIndex == 2)
						{
							goto IL_0bac;
						}
						goto IL_0bc8;
						IL_0bac:
						num2 = 94;
						DC_Main.RsQry += " AND A.ISU_REC =  'Y' AND A.EMP_SALE =  'N'";
						goto IL_0bc8;
						IL_0bc8:
						num2 = 97;
						if (Operators.CompareString(tIsuNo.Text, "", false) != 0)
						{
							goto IL_0bea;
						}
						goto IL_0c51;
						IL_0bea:
						num2 = 98;
						DC_Main.RsQry = DC_Main.RsQry + " AND A.CO_YEAR =  '" + tIsuYrCd.Text + "' AND A.CO_BOOK =  '" + tIsuDbCd.Text + "' AND A.VCH_NO =  '" + tIsuNo.Text + "'";
						goto IL_0c51;
						IL_0c51:
						num2 = 100;
						if (Operators.CompareString(tTagNo.Text, "", false) != 0)
						{
							goto IL_0c73;
						}
						goto IL_0c9c;
						IL_0c73:
						num2 = 101;
						DC_Main.RsQry = DC_Main.RsQry + " AND A.TAG_NO =  '" + tTagNo.Text + "'";
						goto IL_0c9c;
						IL_0c9c:
						num2 = 103;
						if (Operators.CompareString(tGrCode.Text, "", false) != 0)
						{
							goto IL_0cbe;
						}
						goto IL_0ce7;
						IL_0cbe:
						num2 = 104;
						DC_Main.RsQry = DC_Main.RsQry + " And G.GR_CODE =  '" + tGrCode.Text + "'";
						goto IL_0ce7;
						IL_0ce7:
						num2 = 106;
						if (Operators.CompareString(tPrCode.Text, "", false) != 0)
						{
							goto IL_0d09;
						}
						goto IL_0d32;
						IL_0d09:
						num2 = 107;
						DC_Main.RsQry = DC_Main.RsQry + " And G.PR_CODE =  '" + tPrCode.Text + "'";
						goto IL_0d32;
						IL_0d32:
						num2 = 109;
						DC_Main.RsQry += " ORDER BY A.VCH_NO";
						goto IL_0d49;
						IL_0d49:
						num2 = 110;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0d58;
						IL_0d58:
						num2 = 111;
						DC_Main.R = 0;
						goto IL_0d61;
						IL_0d61:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0d6a;
						IL_0d6a:
						num2 = 113;
						if (dataTable.Rows.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_0d85;
						IL_0d85:
						num2 = 114;
						num13 = dataTable.Rows.Count - 1;
						DC_Main.M = 0;
						goto IL_156d;
						IL_156d:
						if (DC_Main.M <= num13)
						{
							goto IL_0da4;
						}
						goto IL_1579;
						IL_1579:
						num2 = 155;
						if (((DataGridView)DGV_AC).Rows.Count >= 1)
						{
							goto IL_159b;
						}
						goto IL_15cb;
						IL_159b:
						num2 = 156;
						((DataGridView)DGV_AC).Rows.Add();
						goto IL_15b2;
						IL_15b2:
						num2 = 157;
						((DataGridView)DGV_AC).Rows.Add();
						goto IL_15cb;
						IL_15cb:
						num2 = 159;
						num14 = ((DataGridView)DGV_AC).Rows.Count - 1;
						goto IL_15e5;
						IL_15e5:
						num2 = 160;
						if (num14 <= 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_15f9;
						IL_15f9:
						num2 = 161;
						((DataGridView)DGV_AC).Rows[num14].Cells[1].Value = "Total :";
						goto IL_1627;
						IL_1627:
						num2 = 162;
						((DataGridView)DGV_AC).Rows[num14].Cells[6].Value = num6;
						goto IL_1656;
						IL_1656:
						num2 = 163;
						((DataGridView)DGV_AC).Rows[num14].Cells[7].Value = num7;
						goto IL_1686;
						IL_1686:
						num2 = 164;
						((DataGridView)DGV_AC).Rows[num14].Cells[8].Value = num8;
						goto IL_16b6;
						IL_16b6:
						num2 = 165;
						((DataGridView)DGV_AC).Rows[num14].Cells[9].Value = num9;
						goto IL_16e7;
						IL_16e7:
						num2 = 166;
						((DataGridView)DGV_AC).Rows[num14].Cells[10].Value = num10;
						goto IL_1718;
						IL_1718:
						num2 = 167;
						((DataGridView)DGV_AC).Rows[num14].Cells[11].Value = num11;
						goto IL_1749;
						IL_1749:
						num2 = 168;
						((DataGridView)DGV_AC).Rows[num14].Cells[12].Value = num12;
						break;
						IL_0da4:
						num2 = 115;
						val = DGV_AC;
						goto IL_0daf;
						IL_0daf:
						num2 = 116;
						((DataGridView)val).Rows.Add();
						goto IL_0dbf;
						IL_0dbf:
						num2 = 117;
						((DataGridView)val)[0, DC_Main.R].Value = DC_Main.R + 1;
						goto IL_0de1;
						IL_0de1:
						num2 = 118;
						((DataGridView)val)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_TYPE"]);
						goto IL_0e17;
						IL_0e17:
						num2 = 119;
						((DataGridView)val)[2, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
						goto IL_0e57;
						IL_0e57:
						num2 = 120;
						((DataGridView)val)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
						goto IL_0e8d;
						IL_0e8d:
						num2 = 121;
						((DataGridView)val)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["TAG_NO"]);
						goto IL_0ec3;
						IL_0ec3:
						num2 = 122;
						((DataGridView)val)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_PCS"]);
						goto IL_0ef9;
						IL_0ef9:
						num2 = 123;
						((DataGridView)val)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_GWT"]);
						goto IL_0f2f;
						IL_0f2f:
						num2 = 124;
						if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[DC_Main.M]["ISU_DBCD"], (object)"505", false))
						{
							goto IL_0f61;
						}
						goto IL_1050;
						IL_0f61:
						num2 = 125;
						((DataGridView)val)[18, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecDate"]), "dd/MM/yyyy");
						goto IL_0fa2;
						IL_0fa2:
						num2 = 126;
						((DataGridView)val)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecVchNo"]);
						goto IL_0fd9;
						IL_0fd9:
						num2 = 127;
						((DataGridView)val)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecPcs"]);
						goto IL_1010;
						IL_1010:
						num2 = 128;
						((DataGridView)val)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecGwt"]);
						goto IL_11f0;
						IL_1050:
						num2 = 130;
						if (Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[DC_Main.M]["ISU_DBCD"], (object)"", false))
						{
							goto IL_1085;
						}
						goto IL_11f0;
						IL_1085:
						num2 = 131;
						((DataGridView)val)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlAcName"]);
						goto IL_10bf;
						IL_10bf:
						num2 = 132;
						((DataGridView)val)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AdjBook"]);
						goto IL_10f9;
						IL_10f9:
						num2 = 133;
						((DataGridView)val)[16, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(dataTable.Rows[DC_Main.M]["SlDate"]), "dd/MM/yyyy");
						goto IL_1142;
						IL_1142:
						num2 = 134;
						((DataGridView)val)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlVchNo"]);
						goto IL_117c;
						IL_117c:
						num2 = 135;
						((DataGridView)val)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlPcs"]);
						goto IL_11b5;
						IL_11b5:
						num2 = 136;
						((DataGridView)val)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlGwt"]);
						goto IL_11f0;
						IL_11f0:
						num2 = 138;
						((DataGridView)val)[12, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[6, DC_Main.R].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[8, DC_Main.R].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[10, DC_Main.R].Value, (object)""));
						goto IL_1275;
						IL_1275:
						num2 = 139;
						((DataGridView)val)[13, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[7, DC_Main.R].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[9, DC_Main.R].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[11, DC_Main.R].Value, (object)""));
						goto IL_12fb;
						IL_12fb:
						num2 = 140;
						((DataGridView)val)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_CODE"]);
						goto IL_1335;
						IL_1335:
						num2 = 141;
						((DataGridView)val)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["EMP_NAME"]);
						goto IL_136e;
						IL_136e:
						num2 = 142;
						((DataGridView)val)[21, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
						goto IL_13a8;
						IL_13a8:
						num2 = 143;
						((DataGridView)val)[22, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ISU_DBCD"]);
						goto IL_13e2;
						IL_13e2:
						num2 = 144;
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[6, DC_Main.R].Value, (object)""));
						goto IL_140c;
						IL_140c:
						num2 = 145;
						num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[7, DC_Main.R].Value, (object)""));
						goto IL_1438;
						IL_1438:
						num2 = 146;
						num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[8, DC_Main.R].Value, (object)""));
						goto IL_1464;
						IL_1464:
						num2 = 147;
						num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[9, DC_Main.R].Value, (object)""));
						goto IL_1491;
						IL_1491:
						num2 = 148;
						num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[10, DC_Main.R].Value, (object)""));
						goto IL_14be;
						IL_14be:
						num2 = 149;
						num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[11, DC_Main.R].Value, (object)""));
						goto IL_14eb;
						IL_14eb:
						num2 = 150;
						num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[12, DC_Main.R].Value, (object)""));
						goto IL_1518;
						end_IL_0001_2:
						break;
					}
					num2 = 169;
					((DataGridView)DGV_AC).Rows[num14].Cells[13].Value = num5;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 6772;
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

	private void EMP_VCH_DETL()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataGridViewX val = default(DataGridViewX);
		double num6 = default(double);
		double num7 = default(double);
		double num8 = default(double);
		double num9 = default(double);
		double num10 = default(double);
		double num11 = default(double);
		double num12 = default(double);
		double num13 = default(double);
		double num14 = default(double);
		double num15 = default(double);
		double num16 = default(double);
		double num17 = default(double);
		DataTable dataTable = default(DataTable);
		int num18 = default(int);
		int num19 = default(int);
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
						if (chkItmStk.Checked)
						{
							goto end_IL_0001;
						}
						goto IL_001a;
					case 7568:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001_2;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 3:
								goto IL_001a;
							case 4:
								goto IL_0029;
							case 5:
								goto IL_0037;
							case 6:
								goto IL_004a;
							case 7:
								goto IL_005d;
							case 8:
								goto IL_006b;
							case 9:
								goto IL_007a;
							case 10:
								goto IL_009e;
							case 11:
								goto IL_00bd;
							case 12:
								goto IL_00e5;
							case 13:
								goto IL_010d;
							case 14:
								goto IL_0135;
							case 15:
							case 16:
								goto IL_0150;
							case 17:
								goto IL_0169;
							case 18:
								goto IL_0179;
							case 19:
								goto IL_0197;
							case 20:
								goto IL_01c7;
							case 21:
								goto IL_01e5;
							case 22:
								goto IL_0215;
							case 23:
								goto IL_0233;
							case 24:
								goto IL_0263;
							case 25:
								goto IL_0281;
							case 26:
								goto IL_02b1;
							case 27:
								goto IL_02cf;
							case 28:
								goto IL_02ff;
							case 29:
								goto IL_031d;
							case 30:
								goto IL_034d;
							case 31:
								goto IL_036e;
							case 32:
								goto IL_038c;
							case 33:
								goto IL_03bc;
							case 34:
								goto IL_03dd;
							case 35:
								goto IL_0401;
							case 36:
								goto IL_041f;
							case 37:
								goto IL_044f;
							case 38:
								goto IL_0470;
							case 39:
								goto IL_0494;
							case 40:
								goto IL_04b2;
							case 41:
								goto IL_04e2;
							case 42:
								goto IL_0503;
							case 43:
								goto IL_0521;
							case 44:
								goto IL_0552;
							case 45:
								goto IL_0574;
							case 46:
								goto IL_0599;
							case 47:
								goto IL_05b7;
							case 48:
								goto IL_05e8;
							case 49:
								goto IL_060a;
							case 50:
								goto IL_062f;
							case 51:
								goto IL_064d;
							case 52:
								goto IL_067e;
							case 53:
								goto IL_069c;
							case 54:
								goto IL_06cd;
							case 55:
								goto IL_06eb;
							case 56:
								goto IL_071c;
							case 57:
								goto IL_073a;
							case 58:
								goto IL_076b;
							case 59:
								goto IL_0789;
							case 60:
								goto IL_07ba;
							case 61:
								goto IL_07dc;
							case 62:
								goto IL_07fa;
							case 63:
								goto IL_082b;
							case 64:
								goto IL_084d;
							case 65:
								goto IL_0872;
							case 66:
								goto IL_0890;
							case 67:
								goto IL_08c1;
							case 68:
								goto IL_08e3;
							case 69:
								goto IL_0908;
							case 70:
								goto IL_0926;
							case 71:
								goto IL_0957;
							case 72:
								goto IL_0975;
							case 73:
								goto IL_09a6;
							case 74:
								goto IL_09c4;
							case 75:
								goto IL_09f5;
							case 76:
								goto IL_0a17;
							case 77:
								goto IL_0a35;
							case 78:
								goto IL_0a66;
							case 79:
								goto IL_0a88;
							case 80:
								goto IL_0aad;
							case 81:
								goto IL_0acb;
							case 82:
								goto IL_0afc;
							case 83:
								goto IL_0b1e;
							case 84:
								goto IL_0b43;
							case 85:
								goto IL_0b61;
							case 86:
								goto IL_0b92;
							case 87:
								goto IL_0bb0;
							case 88:
								goto IL_0be1;
							case 89:
								goto IL_0bff;
							case 90:
								goto IL_0c1b;
							case 91:
								goto IL_0c39;
							case 92:
								goto IL_0c55;
							case 93:
								goto IL_0c63;
							case 94:
								goto IL_0c71;
							case 95:
								goto IL_0c7f;
							case 96:
								goto IL_0c8d;
							case 97:
								goto IL_0c9b;
							case 98:
								goto IL_0ca9;
							case 99:
								goto IL_0cb7;
							case 100:
								goto IL_0cc5;
							case 101:
								goto IL_0cd3;
							case 102:
								goto IL_0ce1;
							case 103:
								goto IL_0cef;
							case 104:
								goto IL_0cfd;
							case 105:
								goto IL_0d12;
							case 106:
								goto IL_0d1b;
							case 107:
								goto IL_0d7d;
							case 108:
								goto IL_0d94;
							case 110:
								goto IL_0dae;
							case 111:
								goto IL_0dc5;
							case 113:
								goto IL_0ddf;
							case 114:
								goto IL_0df6;
							case 109:
							case 112:
							case 115:
							case 116:
							case 117:
								goto IL_0e12;
							case 118:
								goto IL_0e21;
							case 119:
								goto IL_0e27;
							case 120:
								goto IL_0e42;
							case 121:
								goto IL_0e61;
							case 122:
								goto IL_0e6c;
							case 123:
								goto IL_0e7c;
							case 124:
								goto IL_0e98;
							case 125:
								goto IL_0ecb;
							case 126:
								goto IL_0f08;
							case 127:
								goto IL_0f3b;
							case 128:
								goto IL_0f6e;
							case 129:
								goto IL_0fa4;
							case 130:
								goto IL_0fda;
							case 131:
								goto IL_1010;
							case 132:
								goto IL_1045;
							case 133:
								goto IL_1086;
							case 134:
								goto IL_10bd;
							case 135:
								goto IL_10f4;
							case 136:
								goto IL_112b;
							case 138:
								goto IL_1168;
							case 139:
								goto IL_119d;
							case 140:
								goto IL_11d4;
							case 141:
								goto IL_120b;
							case 142:
								goto IL_1251;
							case 143:
								goto IL_1288;
							case 144:
								goto IL_12bf;
							case 145:
								goto IL_12f6;
							case 137:
							case 146:
							case 147:
								goto IL_132e;
							case 148:
								goto IL_13a7;
							case 149:
								goto IL_1421;
							case 150:
								goto IL_149b;
							case 151:
								goto IL_14d2;
							case 152:
								goto IL_14f4;
							case 153:
								goto IL_152b;
							case 154:
								goto IL_1562;
							case 155:
								goto IL_158b;
							case 156:
								goto IL_15b4;
							case 157:
								goto IL_15dd;
							case 158:
								goto IL_1607;
							case 159:
								goto IL_1631;
							case 160:
								goto IL_165b;
							case 161:
								goto IL_1685;
							case 162:
								goto IL_16af;
							case 163:
								goto IL_16d9;
							case 164:
								goto IL_1702;
							case 165:
								goto IL_172c;
							case 166:
								goto IL_1756;
							case 167:
								goto IL_1763;
							case 168:
								goto IL_1766;
							case 169:
								goto IL_1784;
							case 170:
								goto IL_17a6;
							case 171:
								goto IL_17bd;
							case 172:
							case 173:
								goto IL_17d6;
							case 174:
								goto IL_17f0;
							case 175:
								goto IL_1804;
							case 176:
								goto IL_1832;
							case 177:
								goto IL_1862;
							case 178:
								goto IL_1892;
							case 179:
								goto IL_18c2;
							case 180:
								goto IL_18f2;
							case 181:
								goto IL_1923;
							case 182:
								goto IL_1954;
							case 183:
								goto IL_1985;
							case 184:
								goto IL_19b6;
							case 185:
								goto IL_19e7;
							case 186:
								goto IL_1a18;
							case 187:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 2:
							case 188:
							case 189:
							case 190:
							case 191:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_1756:
						num2 = 166;
						num5++;
						goto IL_1763;
						IL_1763:
						val = null;
						goto IL_1766;
						IL_172c:
						num2 = 165;
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[10, num5].Value, (object)""));
						goto IL_1756;
						IL_1766:
						num2 = 168;
						DC_Main.M++;
						goto IL_1778;
						IL_001a:
						num2 = 3;
						((DataGridView)DGV_DETL).DataSource = null;
						goto IL_0029;
						IL_0029:
						num2 = 4;
						((DataGridView)DGV_DETL).ClearSelection();
						goto IL_0037;
						IL_0037:
						num2 = 5;
						((DataGridView)DGV_DETL).Rows.Clear();
						goto IL_004a;
						IL_004a:
						num2 = 6;
						((DataGridView)DGV_DETL).Columns.Clear();
						goto IL_005d;
						IL_005d:
						num2 = 7;
						((Control)DGV_DETL).Refresh();
						goto IL_006b;
						IL_006b:
						num2 = 8;
						((DataGridView)DGV_DETL).MultiSelect = false;
						goto IL_007a;
						IL_007a:
						num2 = 9;
						((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
						goto IL_009e;
						IL_009e:
						num2 = 10;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_00bd;
						}
						goto IL_0150;
						IL_00bd:
						num2 = 11;
						((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_00e5;
						IL_00e5:
						num2 = 12;
						((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_010d;
						IL_010d:
						num2 = 13;
						((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0135;
						IL_0135:
						num2 = 14;
						((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_0150;
						IL_0150:
						num2 = 16;
						((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
						goto IL_0169;
						IL_0169:
						num2 = 17;
						((DataGridView)DGV_DETL).AutoGenerateColumns = false;
						goto IL_0179;
						IL_0179:
						num2 = 18;
						((DataGridView)DGV_DETL).Columns.Add("", "Sr");
						goto IL_0197;
						IL_0197:
						num2 = 19;
						((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
						goto IL_01c7;
						IL_01c7:
						num2 = 20;
						((DataGridView)DGV_DETL).Columns.Add("", "IsuType");
						goto IL_01e5;
						IL_01e5:
						num2 = 21;
						((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
						goto IL_0215;
						IL_0215:
						num2 = 22;
						((DataGridView)DGV_DETL).Columns.Add("", "IsuDate");
						goto IL_0233;
						IL_0233:
						num2 = 23;
						((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0263;
						IL_0263:
						num2 = 24;
						((DataGridView)DGV_DETL).Columns.Add("", "IsuNo");
						goto IL_0281;
						IL_0281:
						num2 = 25;
						((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_02b1;
						IL_02b1:
						num2 = 26;
						((DataGridView)DGV_DETL).Columns.Add("", "TagNo");
						goto IL_02cf;
						IL_02cf:
						num2 = 27;
						((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
						goto IL_02ff;
						IL_02ff:
						num2 = 28;
						((DataGridView)DGV_DETL).Columns.Add("", "IPcs");
						goto IL_031d;
						IL_031d:
						num2 = 29;
						((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_034d;
						IL_034d:
						num2 = 30;
						((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_036e;
						IL_036e:
						num2 = 31;
						((DataGridView)DGV_DETL).Columns.Add("", "IGrWt");
						goto IL_038c;
						IL_038c:
						num2 = 32;
						((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_03bc;
						IL_03bc:
						num2 = 33;
						((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_03dd;
						IL_03dd:
						num2 = 34;
						((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
						goto IL_0401;
						IL_0401:
						num2 = 35;
						((DataGridView)DGV_DETL).Columns.Add("", "INwt");
						goto IL_041f;
						IL_041f:
						num2 = 36;
						((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_044f;
						IL_044f:
						num2 = 37;
						((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0470;
						IL_0470:
						num2 = 38;
						((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
						goto IL_0494;
						IL_0494:
						num2 = 39;
						((DataGridView)DGV_DETL).Columns.Add("", "PPcs");
						goto IL_04b2;
						IL_04b2:
						num2 = 40;
						((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_04e2;
						IL_04e2:
						num2 = 41;
						((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0503;
						IL_0503:
						num2 = 42;
						((DataGridView)DGV_DETL).Columns.Add("", "PGrWt");
						goto IL_0521;
						IL_0521:
						num2 = 43;
						((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_0552;
						IL_0552:
						num2 = 44;
						((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0574;
						IL_0574:
						num2 = 45;
						((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
						goto IL_0599;
						IL_0599:
						num2 = 46;
						((DataGridView)DGV_DETL).Columns.Add("", "PNwt");
						goto IL_05b7;
						IL_05b7:
						num2 = 47;
						((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_05e8;
						IL_05e8:
						num2 = 48;
						((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_060a;
						IL_060a:
						num2 = 49;
						((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
						goto IL_062f;
						IL_062f:
						num2 = 50;
						((DataGridView)DGV_DETL).Columns.Add("", "Sl Pary");
						goto IL_064d;
						IL_064d:
						num2 = 51;
						((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(150.0 * ColCon);
						goto IL_067e;
						IL_067e:
						num2 = 52;
						((DataGridView)DGV_DETL).Columns.Add("", "SlType");
						goto IL_069c;
						IL_069c:
						num2 = 53;
						((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
						goto IL_06cd;
						IL_06cd:
						num2 = 54;
						((DataGridView)DGV_DETL).Columns.Add("", "SlDate");
						goto IL_06eb;
						IL_06eb:
						num2 = 55;
						((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_071c;
						IL_071c:
						num2 = 56;
						((DataGridView)DGV_DETL).Columns.Add("", "SlVch");
						goto IL_073a;
						IL_073a:
						num2 = 57;
						((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_076b;
						IL_076b:
						num2 = 58;
						((DataGridView)DGV_DETL).Columns.Add("", "SPcs");
						goto IL_0789;
						IL_0789:
						num2 = 59;
						((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_07ba;
						IL_07ba:
						num2 = 60;
						((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_07dc;
						IL_07dc:
						num2 = 61;
						((DataGridView)DGV_DETL).Columns.Add("", "SGrWt");
						goto IL_07fa;
						IL_07fa:
						num2 = 62;
						((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_082b;
						IL_082b:
						num2 = 63;
						((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_084d;
						IL_084d:
						num2 = 64;
						((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
						goto IL_0872;
						IL_0872:
						num2 = 65;
						((DataGridView)DGV_DETL).Columns.Add("", "SNwt");
						goto IL_0890;
						IL_0890:
						num2 = 66;
						((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_08c1;
						IL_08c1:
						num2 = 67;
						((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_08e3;
						IL_08e3:
						num2 = 68;
						((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N3";
						goto IL_0908;
						IL_0908:
						num2 = 69;
						((DataGridView)DGV_DETL).Columns.Add("", "RcDate");
						goto IL_0926;
						IL_0926:
						num2 = 70;
						((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0957;
						IL_0957:
						num2 = 71;
						((DataGridView)DGV_DETL).Columns.Add("", "RecNo");
						goto IL_0975;
						IL_0975:
						num2 = 72;
						((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_09a6;
						IL_09a6:
						num2 = 73;
						((DataGridView)DGV_DETL).Columns.Add("", "RPcs");
						goto IL_09c4;
						IL_09c4:
						num2 = 74;
						((DataGridView)DGV_DETL).Columns[20].Width = (int)Math.Round(50.0 * ColCon);
						goto IL_09f5;
						IL_09f5:
						num2 = 75;
						((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0a17;
						IL_0a17:
						num2 = 76;
						((DataGridView)DGV_DETL).Columns.Add("", "RGrWt");
						goto IL_0a35;
						IL_0a35:
						num2 = 77;
						((DataGridView)DGV_DETL).Columns[21].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_0a66;
						IL_0a66:
						num2 = 78;
						((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0a88;
						IL_0a88:
						num2 = 79;
						((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Format = "N3";
						goto IL_0aad;
						IL_0aad:
						num2 = 80;
						((DataGridView)DGV_DETL).Columns.Add("", "RNet");
						goto IL_0acb;
						IL_0acb:
						num2 = 81;
						((DataGridView)DGV_DETL).Columns[22].Width = (int)Math.Round(85.0 * ColCon);
						goto IL_0afc;
						IL_0afc:
						num2 = 82;
						((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						goto IL_0b1e;
						IL_0b1e:
						num2 = 83;
						((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Format = "N3";
						goto IL_0b43;
						IL_0b43:
						num2 = 84;
						((DataGridView)DGV_DETL).Columns.Add("", "Emp");
						goto IL_0b61;
						IL_0b61:
						num2 = 85;
						((DataGridView)DGV_DETL).Columns[23].Width = (int)Math.Round(75.0 * ColCon);
						goto IL_0b92;
						IL_0b92:
						num2 = 86;
						((DataGridView)DGV_DETL).Columns.Add("", "EmpName");
						goto IL_0bb0;
						IL_0bb0:
						num2 = 87;
						((DataGridView)DGV_DETL).Columns[24].Width = (int)Math.Round(125.0 * ColCon);
						goto IL_0be1;
						IL_0be1:
						num2 = 88;
						((DataGridView)DGV_DETL).Columns.Add("", "IsuBook");
						goto IL_0bff;
						IL_0bff:
						num2 = 89;
						((DataGridView)DGV_DETL).Columns[25].Visible = false;
						goto IL_0c1b;
						IL_0c1b:
						num2 = 90;
						((DataGridView)DGV_DETL).Columns.Add("", "AdjBook");
						goto IL_0c39;
						IL_0c39:
						num2 = 91;
						((DataGridView)DGV_DETL).Columns[26].Visible = false;
						goto IL_0c55;
						IL_0c55:
						num2 = 92;
						num7 = 0.0;
						goto IL_0c63;
						IL_0c63:
						num2 = 93;
						num8 = 0.0;
						goto IL_0c71;
						IL_0c71:
						num2 = 94;
						num9 = 0.0;
						goto IL_0c7f;
						IL_0c7f:
						num2 = 95;
						num10 = 0.0;
						goto IL_0c8d;
						IL_0c8d:
						num2 = 96;
						num11 = 0.0;
						goto IL_0c9b;
						IL_0c9b:
						num2 = 97;
						num6 = 0.0;
						goto IL_0ca9;
						IL_0ca9:
						num2 = 98;
						num12 = 0.0;
						goto IL_0cb7;
						IL_0cb7:
						num2 = 99;
						num13 = 0.0;
						goto IL_0cc5;
						IL_0cc5:
						num2 = 100;
						num14 = 0.0;
						goto IL_0cd3;
						IL_0cd3:
						num2 = 101;
						num15 = 0.0;
						goto IL_0ce1;
						IL_0ce1:
						num2 = 102;
						num16 = 0.0;
						goto IL_0cef;
						IL_0cef:
						num2 = 103;
						num17 = 0.0;
						goto IL_0cfd;
						IL_0cfd:
						num2 = 104;
						num5 = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
						goto IL_0d12;
						IL_0d12:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0d1b;
						IL_0d1b:
						num2 = 106;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_TYPE,A.VCH_DATE,A.VCH_NO,A.TAG_NO,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.CO_BOOK,A.ISU_DBCD,A.AC_CODE,B.VCH_NO As SlVchNo,B.VCH_DATE As SlDate,B.ITM_PCS As SlPcs,B.ITM_GWT As SlGwt,B.ITM_NWT As SlNwt,C.AC_NAME As SlAcName,D.BOOK_NAME As AdjBook,  E.VCH_NO As RecVchNo,E.VCH_DATE As RecDate,E.ITM_PCS As RecPcs,E.ITM_GWT As RecGwt,E.ITM_NWT As RecNwt  FROM (((APR_DETL AS A LEFT JOIN RATE_CUT_ISU AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.ISU_YRCD = B.CO_YEAR And A.ISU_DBCD = B.CO_BOOK And A.ISU_NO = B.VCH_NO And A.ISU_SRNO = B.OLD_SRNO)  LEFT JOIN APR_DETL AS E ON A.CO_CODE = E.CO_CODE And A.LC_CODE = E.LC_CODE And A.ISU_YRCD = E.CO_YEAR And A.ISU_DBCD = E.CO_BOOK And A.ISU_NO = E.VCH_NO And A.ISU_SRNO = E.OLD_SRNO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.ISU_AC_CODE = C.AC_CODE) LEFT JOIN BOOK_DATA AS D ON  A.CO_CODE = D.CO_CODE And A.LC_CODE = D.LC_CODE And A.ISU_DBCD = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'EMP ISU' AND A.VCH_NO = '"), ((DataGridView)DGV_AC)[3, num5].Value), (object)"' "));
						goto IL_0d7d;
						IL_0d7d:
						num2 = 107;
						if (cboCity.SelectedIndex == 0)
						{
							goto IL_0d94;
						}
						goto IL_0dae;
						IL_0d94:
						num2 = 108;
						DC_Main.RsQry += " AND A.EMP_SALE = 'N' AND A.ISU_REC =  'N'";
						goto IL_0e12;
						IL_0dae:
						num2 = 110;
						if (cboCity.SelectedIndex == 1)
						{
							goto IL_0dc5;
						}
						goto IL_0ddf;
						IL_0dc5:
						num2 = 111;
						DC_Main.RsQry += " AND A.EMP_SALE =  'Y' ";
						goto IL_0e12;
						IL_0ddf:
						num2 = 113;
						if (cboCity.SelectedIndex == 2)
						{
							goto IL_0df6;
						}
						goto IL_0e12;
						IL_0df6:
						num2 = 114;
						DC_Main.RsQry += " AND A.ISU_REC =  'Y' AND A.EMP_SALE =  'N'";
						goto IL_0e12;
						IL_0e12:
						num2 = 117;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0e21;
						IL_0e21:
						num2 = 118;
						num5 = 0;
						goto IL_0e27;
						IL_0e27:
						num2 = 119;
						if (dataTable.Rows.Count <= 0)
						{
							goto end_IL_0001;
						}
						goto IL_0e42;
						IL_0e42:
						num2 = 120;
						num18 = dataTable.Rows.Count - 1;
						DC_Main.M = 0;
						goto IL_1778;
						IL_1778:
						if (DC_Main.M <= num18)
						{
							goto IL_0e61;
						}
						goto IL_1784;
						IL_1784:
						num2 = 169;
						if (((DataGridView)DGV_DETL).Rows.Count >= 1)
						{
							goto IL_17a6;
						}
						goto IL_17d6;
						IL_17a6:
						num2 = 170;
						((DataGridView)DGV_DETL).Rows.Add();
						goto IL_17bd;
						IL_17bd:
						num2 = 171;
						((DataGridView)DGV_DETL).Rows.Add();
						goto IL_17d6;
						IL_17d6:
						num2 = 173;
						num19 = ((DataGridView)DGV_DETL).Rows.Count - 1;
						goto IL_17f0;
						IL_17f0:
						num2 = 174;
						if (num19 <= 1)
						{
							goto end_IL_0001;
						}
						goto IL_1804;
						IL_1804:
						num2 = 175;
						((DataGridView)DGV_DETL).Rows[num19].Cells[4].Value = "Total :";
						goto IL_1832;
						IL_1832:
						num2 = 176;
						((DataGridView)DGV_DETL).Rows[num19].Cells[5].Value = num7;
						goto IL_1862;
						IL_1862:
						num2 = 177;
						((DataGridView)DGV_DETL).Rows[num19].Cells[6].Value = num8;
						goto IL_1892;
						IL_1892:
						num2 = 178;
						((DataGridView)DGV_DETL).Rows[num19].Cells[7].Value = num9;
						goto IL_18c2;
						IL_18c2:
						num2 = 179;
						((DataGridView)DGV_DETL).Rows[num19].Cells[8].Value = num10;
						goto IL_18f2;
						IL_18f2:
						num2 = 180;
						((DataGridView)DGV_DETL).Rows[num19].Cells[9].Value = num11;
						goto IL_1923;
						IL_1923:
						num2 = 181;
						((DataGridView)DGV_DETL).Rows[num19].Cells[10].Value = num6;
						goto IL_1954;
						IL_1954:
						num2 = 182;
						((DataGridView)DGV_DETL).Rows[num19].Cells[15].Value = num12;
						goto IL_1985;
						IL_1985:
						num2 = 183;
						((DataGridView)DGV_DETL).Rows[num19].Cells[16].Value = num13;
						goto IL_19b6;
						IL_19b6:
						num2 = 184;
						((DataGridView)DGV_DETL).Rows[num19].Cells[17].Value = num14;
						goto IL_19e7;
						IL_19e7:
						num2 = 185;
						((DataGridView)DGV_DETL).Rows[num19].Cells[20].Value = num15;
						goto IL_1a18;
						IL_1a18:
						num2 = 186;
						((DataGridView)DGV_DETL).Rows[num19].Cells[21].Value = num16;
						break;
						IL_0e61:
						num2 = 121;
						val = DGV_DETL;
						goto IL_0e6c;
						IL_0e6c:
						num2 = 122;
						((DataGridView)val).Rows.Add();
						goto IL_0e7c;
						IL_0e7c:
						num2 = 123;
						((DataGridView)val)[0, num5].Value = num5 + 1;
						goto IL_0e98;
						IL_0e98:
						num2 = 124;
						((DataGridView)val)[1, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_TYPE"]);
						goto IL_0ecb;
						IL_0ecb:
						num2 = 125;
						((DataGridView)val)[2, num5].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
						goto IL_0f08;
						IL_0f08:
						num2 = 126;
						((DataGridView)val)[3, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
						goto IL_0f3b;
						IL_0f3b:
						num2 = 127;
						((DataGridView)val)[4, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["TAG_NO"]);
						goto IL_0f6e;
						IL_0f6e:
						num2 = 128;
						((DataGridView)val)[5, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_PCS"]);
						goto IL_0fa4;
						IL_0fa4:
						num2 = 129;
						((DataGridView)val)[6, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_GWT"]);
						goto IL_0fda;
						IL_0fda:
						num2 = 130;
						((DataGridView)val)[7, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_NWT"]);
						goto IL_1010;
						IL_1010:
						num2 = 131;
						if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[DC_Main.M]["ISU_DBCD"], (object)"505", false))
						{
							goto IL_1045;
						}
						goto IL_1168;
						IL_1045:
						num2 = 132;
						((DataGridView)val)[18, num5].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecDate"]), "dd/MM/yyyy");
						goto IL_1086;
						IL_1086:
						num2 = 133;
						((DataGridView)val)[19, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecVchNo"]);
						goto IL_10bd;
						IL_10bd:
						num2 = 134;
						((DataGridView)val)[20, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecPcs"]);
						goto IL_10f4;
						IL_10f4:
						num2 = 135;
						((DataGridView)val)[21, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecGwt"]);
						goto IL_112b;
						IL_112b:
						num2 = 136;
						((DataGridView)val)[22, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["RecNwt"]);
						goto IL_132e;
						IL_1168:
						num2 = 138;
						if (Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[DC_Main.M]["ISU_DBCD"], (object)"", false))
						{
							goto IL_119d;
						}
						goto IL_132e;
						IL_119d:
						num2 = 139;
						((DataGridView)val)[11, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlAcName"]);
						goto IL_11d4;
						IL_11d4:
						num2 = 140;
						((DataGridView)val)[12, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AdjBook"]);
						goto IL_120b;
						IL_120b:
						num2 = 141;
						((DataGridView)val)[13, num5].Value = Strings.Format((object)Conversions.ToDate(dataTable.Rows[DC_Main.M]["SlDate"]), "dd/MM/yyyy");
						goto IL_1251;
						IL_1251:
						num2 = 142;
						((DataGridView)val)[14, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlVchNo"]);
						goto IL_1288;
						IL_1288:
						num2 = 143;
						((DataGridView)val)[15, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlPcs"]);
						goto IL_12bf;
						IL_12bf:
						num2 = 144;
						((DataGridView)val)[16, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlGwt"]);
						goto IL_12f6;
						IL_12f6:
						num2 = 145;
						((DataGridView)val)[17, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SlNwt"]);
						goto IL_132e;
						IL_132e:
						num2 = 147;
						((DataGridView)val)[8, num5].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[5, num5].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[15, num5].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[20, num5].Value, (object)""));
						goto IL_13a7;
						IL_13a7:
						num2 = 148;
						((DataGridView)val)[9, num5].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[6, num5].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[16, num5].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[21, num5].Value, (object)""));
						goto IL_1421;
						IL_1421:
						num2 = 149;
						((DataGridView)val)[10, num5].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[7, num5].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[17, num5].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[22, num5].Value, (object)""));
						goto IL_149b;
						IL_149b:
						num2 = 150;
						((DataGridView)val)[23, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_CODE"]);
						goto IL_14d2;
						IL_14d2:
						num2 = 151;
						((DataGridView)val)[24, num5].Value = tDesgnNo.Text;
						goto IL_14f4;
						IL_14f4:
						num2 = 152;
						((DataGridView)val)[25, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
						goto IL_152b;
						IL_152b:
						num2 = 153;
						((DataGridView)val)[26, num5].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ISU_DBCD"]);
						goto IL_1562;
						IL_1562:
						num2 = 154;
						num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[5, num5].Value, (object)""));
						goto IL_158b;
						IL_158b:
						num2 = 155;
						num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[6, num5].Value, (object)""));
						goto IL_15b4;
						IL_15b4:
						num2 = 156;
						num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[7, num5].Value, (object)""));
						goto IL_15dd;
						IL_15dd:
						num2 = 157;
						num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[15, num5].Value, (object)""));
						goto IL_1607;
						IL_1607:
						num2 = 158;
						num13 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[16, num5].Value, (object)""));
						goto IL_1631;
						IL_1631:
						num2 = 159;
						num14 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[17, num5].Value, (object)""));
						goto IL_165b;
						IL_165b:
						num2 = 160;
						num15 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[20, num5].Value, (object)""));
						goto IL_1685;
						IL_1685:
						num2 = 161;
						num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[21, num5].Value, (object)""));
						goto IL_16af;
						IL_16af:
						num2 = 162;
						num17 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[22, num5].Value, (object)""));
						goto IL_16d9;
						IL_16d9:
						num2 = 163;
						num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[8, num5].Value, (object)""));
						goto IL_1702;
						IL_1702:
						num2 = 164;
						num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)val)[9, num5].Value, (object)""));
						goto IL_172c;
						end_IL_0001_3:
						break;
					}
					num2 = 187;
					((DataGridView)DGV_DETL).Rows[num19].Cells[22].Value = num17;
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7568;
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

	private void DGV_TOUR_FILL()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0d83: Unknown result type (might be due to invalid IL or missing references)
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).Columns.Clear();
		((DataGridView)DGV_AC).Rows.Clear();
		((Control)DGV_AC).Refresh();
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,A.VCH_NO) AS SrNo,A.VCH_TYPE,A.VCH_DATE,A.VCH_NO,A.AC_CODE,F.EMP_NAME,\r\n\r\n        SUM(A.ITM_GWT) AS IsuWt,SUM(A.ITM_PCS) AS IsuPcs,SUM(ISNULL(B.ITM_PCS,0)) AS SalePcs,SUM(ISNULL(E.ITM_PCS,0)) AS RecPcs,\r\n\r\n        SUM(A.ITM_PCS) - SUM(ISNULL(B.ITM_PCS,0)) - SUM(ISNULL(E.ITM_PCS,0)) AS PanPcs,\r\n\r\n        SUM(A.ITM_GWT) - SUM(ISNULL(B.ITM_GWT,0)) - SUM(ISNULL(E.ITM_GWT,0)) AS PanWt\r\n        \r\n        FROM APR_DETL AS A\r\n\r\n        LEFT JOIN RATE_CUT_ISU AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.ISU_YRCD = B.CO_YEAR AND A.ISU_DBCD = B.CO_BOOK AND A.ISU_NO = B.VCH_NO AND A.ISU_SRNO = B.OLD_SRNO AND B.TAG_NO <> 'N'\r\n\r\n        LEFT JOIN APR_DETL AS E ON A.CO_CODE = E.CO_CODE AND A.LC_CODE = E.LC_CODE AND A.ISU_YRCD = E.CO_YEAR AND A.ISU_DBCD = E.CO_BOOK AND A.ISU_NO = E.VCH_NO AND A.ISU_SRNO = E.OLD_SRNO AND E.TAG_NO <> 'N' AND E.BOOK_NAME = 'EMP REC'\r\n\r\n        LEFT JOIN EMP_MAST AS F ON A.CO_CODE = F.CO_CODE AND A.AC_CODE = F.EMP_CODE LEFT JOIN ITEM_MAST AS G ON A.CO_CODE = G.CO_CODE AND A.IT_CODE = G.IT_CODE\r\n\r\n        WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'EMP ISU'AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "yyyy-MM-dd") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "yyyy-MM-dd") + "' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" AND A.AC_CODE = '" + tAcCode.Text + "' "))));
		if (chkOnlyTagStk.Checked)
		{
			DC_Main.RsQry += " AND A.TAG_NO <> 'N'  ";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + " AND G.GR_CODE = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + " AND G.PR_CODE = '" + tPrCode.Text + "'";
		}
		if (cboCity.SelectedIndex == 0)
		{
			DC_Main.RsQry += " AND A.EMP_SALE = 'N' AND A.ISU_REC =  'N'";
		}
		else if (cboCity.SelectedIndex == 1)
		{
			DC_Main.RsQry += " AND A.EMP_SALE =  'Y' ";
		}
		else if (cboCity.SelectedIndex == 2)
		{
			DC_Main.RsQry += " AND A.ISU_REC =  'Y' AND A.EMP_SALE =  'N'";
		}
		DC_Main.RsQry += "GROUP BY A.VCH_TYPE,A.VCH_DATE,A.VCH_NO,A.AC_CODE,F.EMP_NAME ORDER BY A.VCH_DATE,A.VCH_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(DC_Main.Rshlp);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_AC).ColumnCount = 12;
				((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_AC).Columns[0].HeaderText = "Sr";
				((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[1].DataPropertyName = "VCH_TYPE";
				((DataGridView)DGV_AC).Columns[1].HeaderText = "Book";
				((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(95.0 * ColCon);
				((DataGridView)DGV_AC).Columns[2].DataPropertyName = "VCH_DATE";
				((DataGridView)DGV_AC).Columns[2].HeaderText = "VchDate";
				((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_AC).Columns[3].DataPropertyName = "VCH_NO";
				((DataGridView)DGV_AC).Columns[3].HeaderText = "VchNo";
				((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_CODE";
				((DataGridView)DGV_AC).Columns[4].HeaderText = "EmpCode";
				((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(200.0 * ColCon);
				((DataGridView)DGV_AC).Columns[5].DataPropertyName = "EMP_NAME";
				((DataGridView)DGV_AC).Columns[5].HeaderText = "Emp Name";
				((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[6].DataPropertyName = "IsuWt";
				((DataGridView)DGV_AC).Columns[6].HeaderText = "IsuWt";
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV_AC).Columns[7].DataPropertyName = "IsuPcs";
				((DataGridView)DGV_AC).Columns[7].HeaderText = "IsuPcs";
				((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV_AC).Columns[8].DataPropertyName = "SalePcs";
				((DataGridView)DGV_AC).Columns[8].HeaderText = "SlPcs";
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV_AC).Columns[9].DataPropertyName = "RecPcs";
				((DataGridView)DGV_AC).Columns[9].HeaderText = "RecPcs";
				((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV_AC).Columns[10].DataPropertyName = "PanPcs";
				((DataGridView)DGV_AC).Columns[10].HeaderText = "PanPcs";
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[11].DataPropertyName = "PanWt";
				((DataGridView)DGV_AC).Columns[11].HeaderText = "PanWt";
				((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).DataSource = dataView;
				if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[5].Value, (object)""), (object)"Total : ", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[4].Value, (object)""), (object)"", false))))
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
				int num7 = ((DataGridView)DGV_AC).Rows.Count - 1;
				for (int i = 0; i <= num7; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""), (object)"Total ", false))
					{
						((DataGridView)DGV_AC).Rows[i].Cells[0].Value = i + 1;
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[8].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[9].Value, (object)""));
						num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[10].Value, (object)""));
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[11].Value, (object)""));
					}
				}
				int num8 = ((DataGridView)DGV_AC).Rows.Count - 1;
				((DataGridView)DGV_AC).Rows[num8].Cells[5].Value = "Total ";
				((DataGridView)DGV_AC).Rows[num8].Cells[6].Value = num;
				((DataGridView)DGV_AC).Rows[num8].Cells[7].Value = num2;
				((DataGridView)DGV_AC).Rows[num8].Cells[8].Value = num3;
				((DataGridView)DGV_AC).Rows[num8].Cells[9].Value = num4;
				((DataGridView)DGV_AC).Rows[num8].Cells[10].Value = num5;
				((DataGridView)DGV_AC).Rows[num8].Cells[11].Value = num6;
			}
			else
			{
				Interaction.MsgBox((object)"No Record Found...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Tour Tag", false) != 0)
		{
			((Control)PnlAcSumm).Visible = false;
			DgvAcEnter = true;
			int columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
			int index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
			DgvCurRow = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
			BtnExit.Text = "&Back";
			Label2.Text = "Emp Name";
			((Control)tDesgnNo).Width = 222;
			tDesgnNo.Text = Conversions.ToString(((DataGridView)DGV_AC)[5, index].Value);
			EMP_VCH_DETL();
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
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 15:
					case 16:
					case 17:
					case 20:
					case 21:
					case 22:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 11:
					case 12:
					case 13:
					case 14:
					case 18:
					case 19:
						break;
					}
					break;
				case 177:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00e7;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 177;
				continue;
			}
			break;
			IL_00e7:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void RP_TOUR_ZOOM_Load(object sender, EventArgs e)
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
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
				CheckBox obj6 = chkItmStk;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj6).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj8 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewX dGV_DEL = DGV_DEL;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DEL).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewX dGV_AC = DGV_AC;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewX dGV_DETL = DGV_DETL;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj14 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				ComboBox obj15 = cboCity;
				object? obj16 = colorConverter.ConvertFromString("243, 240, 239");
				obj15.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblAdd1).ForeColor = Color.Black;
				((Control)lblMobile).ForeColor = Color.Black;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj17 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((ButtonBase)chkItmStk).BackColor = Color.LightSlateGray;
				((Control)PnlBotam).BackColor = Color.LightSlateGray;
				DataGridViewX dGV_DEL2 = DGV_DEL;
				object? obj18 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_DEL2).BackgroundColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewX dGV_AC2 = DGV_AC;
				object? obj20 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj22 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj23 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				ComboBox obj24 = cboCity;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				obj24.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj26 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj27 = lblBook;
				object? obj28 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj27).ForeColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				((ButtonBase)chkItmStk).BackColor = Color.Cornsilk;
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj29 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DataGridViewX dGV_DEL3 = DGV_DEL;
				object? obj30 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DEL3).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DataGridViewX dGV_AC3 = DGV_AC;
				object? obj32 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj34 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj35 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				cboCity.BackColor = Color.Cornsilk;
			}
			mFromDt.Text = "01/01/2020";
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			cboCity.Items.Add((object)"Panding");
			cboCity.Items.Add((object)"Sales");
			cboCity.Items.Add((object)"Return");
			cboCity.Items.Add((object)"All");
			cboCity.SelectedIndex = 0;
			if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
			{
				Tour_Tag_Detl();
				((Control)chkItmStk).Visible = false;
			}
			else
			{
				((Control)Label1).Visible = false;
				((Control)tTagNo).Visible = false;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK194NEVK", false) == 0)
				{
					chkItmStk.Checked = true;
					Item_Wise_Tour_Stk();
				}
				else
				{
					DGV_TOUR_FILL();
				}
			}
			CurActCtrl = (Control)(object)mFromDt;
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				int columnIndex;
				int columnIndex2;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 356:
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
							goto IL_001d;
						case 5:
							goto IL_0032;
						case 6:
							goto IL_0043;
						case 7:
							goto IL_0064;
						case 8:
							goto IL_0072;
						case 13:
							goto IL_0088;
						case 15:
							goto IL_009d;
						case 16:
							goto IL_00af;
						case 17:
							goto IL_00d1;
						case 18:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 4:
						case 9:
						case 10:
						case 11:
						case 12:
						case 14:
						case 19:
						case 20:
						case 21:
						case 22:
						case 23:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_009d:
					num2 = 15;
					if (((ConvertEventArgs)e).Value == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_00af;
					IL_00af:
					num2 = 16;
					if (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00d1;
					IL_0088:
					num2 = 13;
					columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 6) > 5u)
					{
						goto end_IL_0001_3;
					}
					goto IL_009d;
					IL_00d1:
					num2 = 17;
					((ConvertEventArgs)e).Value = "";
					break;
					IL_000b:
					num2 = 2;
					if (chkItmStk.Checked)
					{
						goto IL_001d;
					}
					goto IL_0088;
					IL_001d:
					num2 = 3;
					columnIndex2 = e.ColumnIndex;
					if ((uint)(columnIndex2 - 3) > 9u)
					{
						goto end_IL_0001_3;
					}
					goto IL_0032;
					IL_0032:
					num2 = 5;
					if (((ConvertEventArgs)e).Value == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_0043;
					IL_0043:
					num2 = 6;
					if (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0064;
					IL_0064:
					num2 = 7;
					((ConvertEventArgs)e).Value = "";
					goto IL_0072;
					IL_0072:
					num2 = 8;
					e.FormattingApplied = true;
					goto end_IL_0001_3;
					end_IL_0001_2:
					break;
				}
				num2 = 18;
				e.FormattingApplied = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 356;
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
					case 1831:
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
								goto IL_031c;
							case 28:
							case 29:
								goto IL_0371;
							case 30:
								goto IL_0383;
							case 20:
							case 31:
							case 32:
								goto IL_039f;
							case 33:
								goto IL_03a9;
							case 34:
								goto IL_03fc;
							case 35:
								goto IL_0451;
							case 36:
								goto IL_04a9;
							case 37:
								goto IL_0517;
							case 38:
								goto IL_055a;
							case 39:
								goto IL_0589;
							case 40:
								goto IL_05cc;
							case 41:
								goto IL_060d;
							case 42:
								goto IL_062e;
							case 43:
								goto IL_063c;
							case 44:
								goto IL_0642;
							case 45:
								goto IL_0648;
							case 46:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 47:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0371:
						num2 = 29;
						num5++;
						goto IL_037a;
						IL_026b:
						num2 = 22;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_AC).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02b3;
						IL_031c:
						num2 = 27;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0371;
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
						goto IL_039f;
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
						num12 = ((DataGridView)DGV_AC).ColumnCount - 1;
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
						num13 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0392;
						IL_0392:
						if (DC_Main.i <= num13)
						{
							goto IL_02df;
						}
						goto IL_039f;
						IL_039f:
						num2 = 32;
						colorConverter = new ColorConverter();
						goto IL_03a9;
						IL_03a9:
						num2 = 33;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_03fc;
						IL_03fc:
						num2 = 34;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0451;
						IL_0451:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04a9;
						IL_04a9:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0517;
						IL_0517:
						num2 = 37;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_055a;
						IL_055a:
						num2 = 38;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0589;
						IL_0589:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05cc;
						IL_05cc:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_060d;
						IL_060d:
						num2 = 41;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_062e;
						IL_062e:
						num2 = 42;
						Cursor.Current = Cursors.Default;
						goto IL_063c;
						IL_063c:
						num2 = 43;
						obj = null;
						goto IL_0642;
						IL_0642:
						num2 = 44;
						obj3 = null;
						goto IL_0648;
						IL_0648:
						num2 = 45;
						obj2 = null;
						break;
						IL_02df:
						num2 = 25;
						num14 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_037a;
						IL_037a:
						if (num5 <= num14)
						{
							goto IL_02f9;
						}
						goto IL_0383;
						IL_0383:
						num2 = 30;
						DC_Main.i++;
						goto IL_0392;
						IL_02f9:
						num2 = 26;
						if (((DataGridView)DGV_AC)[num5, DC_Main.i].Value != null)
						{
							goto IL_031c;
						}
						goto IL_0371;
						end_IL_0001_2:
						break;
					}
					num2 = 46;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1831;
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
		mFromDt.Text = "01/01/2021";
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		BtnExit.Text = "E&xit";
		((Control)PnlAcSumm).Visible = true;
		tAcCode.Text = "";
		tAcName.Text = "";
		chkItmStk.Checked = false;
		DgvAcEnter = false;
		cboCity.SelectedIndex = 0;
		if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
		{
			Tour_Tag_Detl();
		}
		else if (Operators.CompareString(DC_Main.SSRegSrNo, "VK194NEVK", false) == 0)
		{
			chkItmStk.Checked = true;
			Item_Wise_Tour_Stk();
		}
		else
		{
			DGV_TOUR_FILL();
		}
		((Control)mFromDt).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((DataGridView)DGV_DETL).Columns.Clear();
			((Control)DGV_DETL).Refresh();
			BtnExit.Text = "E&xit";
			((Control)PnlAcSumm).Visible = true;
			BtnPrint.Text = "&Print";
			lblAdd1.Text = "";
			lblMobile.Text = "";
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_TOUR_ZOOM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_TOUR_ZOOM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_TOUR_ZOOM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Invalid comparison between Unknown and I4
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((DataGridView)DGV_DETL).DataSource = null;
				((DataGridView)DGV_DETL).ClearSelection();
				((DataGridView)DGV_DETL).Rows.Clear();
				((DataGridView)DGV_DETL).Columns.Clear();
				((Control)DGV_DETL).Refresh();
				BtnExit.Text = "E&xit";
				((Control)PnlAcSumm).Visible = true;
				BtnPrint.Text = "&Print";
				lblAdd1.Text = "";
				lblMobile.Text = "";
			}
			else
			{
				((Form)this).Close();
			}
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV_AC).Focus();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_TOUR_ZOOM_Closed(object sender, EventArgs e)
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

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
			{
				Tour_Tag_Detl();
			}
			else
			{
				DGV_TOUR_FILL();
			}
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		if (Operators.CompareString(CurRpt, "Tour Tag", false) != 0 && (int)e.KeyCode == 13)
		{
			DgvAcEnter = true;
			DGV_DoubleClick(DGV_AC, new EventArgs());
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		DC_Main.LdrAcMastCode = tDesgnNo.Text;
		MS_ACCT mS_ACCT = new MS_ACCT();
		((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)mS_ACCT).Show();
		((Control)mS_ACCT).Focus();
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

	private void DGV_DEL_CLEAR()
	{
		((DataGridView)DGV_DEL).DataSource = null;
		((DataGridView)DGV_DEL).Columns.Clear();
		((DataGridView)DGV_DEL).Rows.Clear();
	}

	private void cboProcessName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
			{
				Tour_Tag_Detl();
			}
			else
			{
				DGV_TOUR_FILL();
			}
		}
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND EMP_CODE = '" + tAcCode.Text + "'";
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
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
				if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
				{
					Tour_Tag_Detl();
				}
				else
				{
					DGV_TOUR_FILL();
				}
			}
		}
		else
		{
			tAcName.Text = "";
			if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
			{
				Tour_Tag_Detl();
			}
			else
			{
				DGV_TOUR_FILL();
			}
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
				}
				((TextBoxBase)tPrCode).SelectAll();
			}
		}
		else if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
		{
			Tour_Tag_Detl();
		}
		else
		{
			DGV_TOUR_FILL();
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
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
		{
			Tour_Tag_Detl();
		}
		else
		{
			DGV_TOUR_FILL();
		}
	}

	private void DGV_AC_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void tTagNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
			{
				Tour_Tag_Detl();
			}
			else
			{
				DGV_TOUR_FILL();
			}
		}
	}

	private void Item_Wise_Tour_Stk()
	{
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected O, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Expected O, but got Unknown
		//IL_129e: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY A.EMP_CODE,B.EMP_NAME) AS SrNo,A.EMP_CODE AS Code ,B.EMP_NAME AS Name, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN  A.ITM_PCS ELSE  -A.ITM_PCS END) ELSE 0 END) AS OpPcs,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_GWT ELSE -A.ITM_GWT END) ELSE 0 END) AS OpWt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS IsuPcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS IsuWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.BOOK_NAME = 'TOUR SALES' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS SalePcs,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.BOOK_NAME = 'TOUR SALES' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS SaleWt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.BOOK_NAME = 'EMP REC' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS RecPcs, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.BOOK_NAME = 'EMP REC' THEN A.ITM_GWT ELSE 0 END) ELSE 0 END) AS RecWt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS PanPcs,SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN A.BOOK_NAME = 'EMP ISU' THEN A.ITM_GWT ELSE -A.ITM_GWT END) ELSE 0 END) AS PanWt FROM (APR_DETL AS A LEFT JOIN EMP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.EMP_CODE = B.EMP_CODE)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.BOOK_NAME IN ('EMP ISU','TOUR SALES','EMP REC') "));
		DC_Main.RsQry += " AND A.TAG_NO = 'N'";
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.EMP_CODE =  '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE =  '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE =  '" + tGrCode.Text + "'";
		}
		DC_Main.RsQry += "GROUP BY A.EMP_CODE,B.EMP_NAME ORDER BY A.EMP_CODE";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).Columns.Clear();
		((DataGridView)DGV_AC).Rows.Clear();
		((Control)DGV_AC).Refresh();
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(DC_Main.Rshlp);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_AC).ColumnCount = 13;
				((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_AC).Columns[0].HeaderText = "Sr";
				((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[1].DataPropertyName = "Code";
				((DataGridView)DGV_AC).Columns[1].HeaderText = "EmpCode";
				((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(165.0 * ColCon);
				((DataGridView)DGV_AC).Columns[2].DataPropertyName = "Name";
				((DataGridView)DGV_AC).Columns[2].HeaderText = "Emp Name";
				((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[3].DataPropertyName = "OpPcs";
				((DataGridView)DGV_AC).Columns[3].HeaderText = "OpPcs";
				((DataGridView)DGV_AC).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[4].DataPropertyName = "OpWt";
				((DataGridView)DGV_AC).Columns[4].HeaderText = "OpWt";
				((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[5].DataPropertyName = "IsuPcs";
				((DataGridView)DGV_AC).Columns[5].HeaderText = "IsuPcs";
				((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[6].DataPropertyName = "IsuWt";
				((DataGridView)DGV_AC).Columns[6].HeaderText = "IsuWt";
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[7].DataPropertyName = "SalePcs";
				((DataGridView)DGV_AC).Columns[7].HeaderText = "SlPcs";
				((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[8].DataPropertyName = "SaleWt";
				((DataGridView)DGV_AC).Columns[8].HeaderText = "SlWt";
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[9].DataPropertyName = "RecPcs";
				((DataGridView)DGV_AC).Columns[9].HeaderText = "RecPcs";
				((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[10].DataPropertyName = "RecWt";
				((DataGridView)DGV_AC).Columns[10].HeaderText = "RecWt";
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[11].DataPropertyName = "PanPcs";
				((DataGridView)DGV_AC).Columns[11].HeaderText = "PanPcs";
				((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[12].DataPropertyName = "PanWt";
				((DataGridView)DGV_AC).Columns[12].HeaderText = "PanWt";
				((DataGridView)DGV_AC).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[12].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).DataSource = dataView;
				if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[2].Value, (object)""), (object)"Total : ", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
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
				int num11 = ((DataGridView)DGV_AC).Rows.Count - 1;
				for (int i = 0; i <= num11; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""), (object)"Total : ", false))
					{
						((DataGridView)DGV_AC).Rows[i].Cells[0].Value = i + 1;
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[3].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[4].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
						num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[8].Value, (object)""));
						num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[9].Value, (object)""));
						num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[10].Value, (object)""));
						num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[11].Value, (object)""));
						num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[12].Value, (object)""));
					}
				}
				int num12 = ((DataGridView)DGV_AC).Rows.Count - 1;
				((DataGridView)DGV_AC).Rows[num12].Cells[2].Value = "Total ";
				((DataGridView)DGV_AC).Rows[num12].Cells[3].Value = num;
				((DataGridView)DGV_AC).Rows[num12].Cells[4].Value = num2;
				((DataGridView)DGV_AC).Rows[num12].Cells[5].Value = num3;
				((DataGridView)DGV_AC).Rows[num12].Cells[6].Value = num4;
				((DataGridView)DGV_AC).Rows[num12].Cells[7].Value = num5;
				((DataGridView)DGV_AC).Rows[num12].Cells[8].Value = num6;
				((DataGridView)DGV_AC).Rows[num12].Cells[9].Value = num7;
				((DataGridView)DGV_AC).Rows[num12].Cells[10].Value = num8;
				((DataGridView)DGV_AC).Rows[num12].Cells[11].Value = num9;
				((DataGridView)DGV_AC).Rows[num12].Cells[12].Value = num10;
			}
			else
			{
				Interaction.MsgBox((object)"No Record Found...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		BtnExit.Text = "E&xit";
		((Control)PnlAcSumm).Visible = true;
		BtnPrint.Text = "&Print";
		if (chkItmStk.Checked)
		{
			Item_Wise_Tour_Stk();
		}
		else if (Operators.CompareString(CurRpt, "Tour Tag", false) == 0)
		{
			Tour_Tag_Detl();
		}
		else
		{
			DGV_TOUR_FILL();
		}
	}

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tIsuNo.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.EMP_NAME As EmpNameL,COUNT(*) As TagQtyM,A.CO_YEAR As YearL,A.CO_BOOK As BookL FROM (APR_DETL AS A   LEFT JOIN EMP_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.EMP_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND D.MAIN_BOOK = 'EMP ISU'   GROUP BY A.VCH_NO,A.VCH_DATE,C.EMP_NAME,A.CO_YEAR,A.CO_BOOK ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 110.0;
		DC_Main.ColWidth[5] = 90.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tIsuNo.Text = DC_Main.ColValue[0];
				tIsuYrCd.Text = DC_Main.ColValue[4];
				tIsuDbCd.Text = DC_Main.ColValue[5];
				((Control)tIsuNo).Focus();
			}
			else
			{
				((Control)tIsuNo).Focus();
			}
		}
	}
}
