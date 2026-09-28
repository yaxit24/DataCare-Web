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
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_MFG_ZOOM : Form
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
	[AccessedThroughProperty("DGV_AC")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

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
	[AccessedThroughProperty("cboProcessName")]
	private ComboBox _cboProcessName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKrCode")]
	private TextBox _tKrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIsuNo")]
	private SimpleButton _btnIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tOrdNo")]
	private TextBox _tOrdNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tOrdDesgn")]
	private TextBox _tOrdDesgn;

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

	private const int cLotNo = 1;

	private const int cVchDate = 2;

	private const int cOrdSr = 3;

	private const int cOrdDesign = 4;

	private const int cOrdName = 5;

	private const int cOrdBook = 6;

	private const int cOrdYrCd = 7;

	private const int cOrdWt = 8;

	private const int czSrNo = 0;

	private const int czLotNo = 1;

	private const int czItName = 2;

	private const int czDesign = 3;

	private const int czSize = 4;

	private const int czKrName = 5;

	private const int czIsuPcs = 6;

	private const int czIsuGwt = 7;

	private const int czIsuOthWt = 8;

	private const int czIsuNwt = 9;

	private const int czRecPcs = 10;

	private const int czRecGwt = 11;

	private const int czRecOthWt = 12;

	private const int czRecNwt = 13;

	private const int czDmPcs = 14;

	private const int czDmWt = 15;

	private const int czRecGht = 16;

	private const int czRecChol = 17;

	private const int czRecGhis = 18;

	private const int czRecMtrl = 19;

	private const int czRecLoss = 20;

	private const int czKrCode = 21;

	private const int czDiffWt = 22;

	private const int cmSrNo = 0;

	private const int cmProName = 1;

	private const int cmGrWt = 2;

	private const int cmOthWt = 3;

	private const int cmNetWt = 4;

	private const int cmDmPcs = 5;

	private const int cmDmWt = 6;

	private const int cmMino = 7;

	private const int cmGhtWt = 8;

	private const int cmGhis = 9;

	private const int cmRtnChol = 10;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_AC_CellFormatting);
			KeyEventHandler val2 = new KeyEventHandler(DGV_KeyDown);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(DGV_AC_CellContentClick);
			DevComponents.DotNetBar.Controls.DataGridViewX val4 = _DGV_AC;
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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV_DETL;
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
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DEL;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DEL
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

	internal virtual ComboBox cboProcessName
	{
		[CompilerGenerated]
		get
		{
			return _cboProcessName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboProcessName_KeyDown);
			ComboBox val2 = _cboProcessName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboProcessName = value;
			val2 = _cboProcessName;
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

	internal virtual TextBox tKrCode
	{
		[CompilerGenerated]
		get
		{
			return _tKrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tKrCode_KeyDown);
			TextBox val2 = _tKrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tKrCode = value;
			val2 = _tKrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKrName")]
	private virtual TextBox _tKrName;

	internal virtual TextBox tKrName
	{
		get
		{
			return _tKrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tKrName = value;
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

	internal virtual SimpleButton btnIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _btnIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnIsuNo_Click;
			SimpleButton val = _btnIsuNo;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIsuNo = value;
			val = _btnIsuNo;
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

	internal virtual TextBox tOrdNo
	{
		[CompilerGenerated]
		get
		{
			return _tOrdNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tOrdNo_KeyDown);
			TextBox val2 = _tOrdNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tOrdNo = value;
			val2 = _tOrdNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tOrdDesgn
	{
		[CompilerGenerated]
		get
		{
			return _tOrdDesgn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tOrdDesgn_KeyDown);
			EventHandler eventHandler = tOrdDesgn_TextChanged;
			TextBox val2 = _tOrdDesgn;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tOrdDesgn = value;
			val2 = _tOrdDesgn;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

	public RP_MFG_ZOOM()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Activated += RP_MFG_ZOOM_Activated;
		((Form)this).Load += RP_MFG_ZOOM_Load;
		((Form)this).Deactivate += RP_MFG_ZOOM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_MFG_ZOOM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_MFG_ZOOM_KeyDown);
		((Form)this).Closed += RP_MFG_ZOOM_Closed;
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
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Expected O, but got Unknown
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0708: Expected O, but got Unknown
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Expected O, but got Unknown
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089f: Expected O, but got Unknown
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Expected O, but got Unknown
		//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Expected O, but got Unknown
		//IL_0aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Expected O, but got Unknown
		//IL_0b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Expected O, but got Unknown
		//IL_0c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c31: Expected O, but got Unknown
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb9: Expected O, but got Unknown
		//IL_0d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da5: Expected O, but got Unknown
		//IL_0e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e18: Expected O, but got Unknown
		//IL_10ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Expected O, but got Unknown
		//IL_11a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11af: Expected O, but got Unknown
		//IL_1460: Unknown result type (might be due to invalid IL or missing references)
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ff: Expected O, but got Unknown
		//IL_1522: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c3: Expected O, but got Unknown
		//IL_169b: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a5: Expected O, but got Unknown
		//IL_1741: Unknown result type (might be due to invalid IL or missing references)
		//IL_174b: Expected O, but got Unknown
		//IL_1859: Unknown result type (might be due to invalid IL or missing references)
		//IL_1863: Expected O, but got Unknown
		//IL_191e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1928: Expected O, but got Unknown
		//IL_19c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cd: Expected O, but got Unknown
		//IL_1a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a85: Expected O, but got Unknown
		//IL_1b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0d: Expected O, but got Unknown
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b87: Expected O, but got Unknown
		//IL_1c35: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3f: Expected O, but got Unknown
		//IL_1ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf7: Expected O, but got Unknown
		//IL_1d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7f: Expected O, but got Unknown
		//IL_1e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e37: Expected O, but got Unknown
		//IL_1eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebf: Expected O, but got Unknown
		//IL_1f8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f99: Expected O, but got Unknown
		//IL_2035: Unknown result type (might be due to invalid IL or missing references)
		//IL_203f: Expected O, but got Unknown
		//IL_20c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cf: Expected O, but got Unknown
		//IL_21b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c0: Expected O, but got Unknown
		//IL_2229: Unknown result type (might be due to invalid IL or missing references)
		//IL_2233: Expected O, but got Unknown
		//IL_2310: Unknown result type (might be due to invalid IL or missing references)
		//IL_231a: Expected O, but got Unknown
		//IL_2394: Unknown result type (might be due to invalid IL or missing references)
		//IL_239e: Expected O, but got Unknown
		//IL_244f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2459: Expected O, but got Unknown
		//IL_24ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f7: Expected O, but got Unknown
		//IL_2577: Unknown result type (might be due to invalid IL or missing references)
		//IL_2581: Expected O, but got Unknown
		//IL_262c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2636: Expected O, but got Unknown
		//IL_26b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ba: Expected O, but got Unknown
		//IL_2787: Unknown result type (might be due to invalid IL or missing references)
		//IL_2791: Expected O, but got Unknown
		//IL_282d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2837: Expected O, but got Unknown
		//IL_28bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c7: Expected O, but got Unknown
		//IL_29ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_29b8: Expected O, but got Unknown
		//IL_2a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a2b: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_MFG_ZOOM));
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
		DGV_AC = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PnlAcSumm = new Panel();
		Label11 = new Label();
		tOrdDesgn = new TextBox();
		btnOk = new QButton();
		btnIsuNo = new SimpleButton();
		Label7 = new Label();
		tOrdNo = new TextBox();
		Label6 = new Label();
		tKrCode = new TextBox();
		tKrName = new TextBox();
		Label5 = new Label();
		Label4 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		cboProcessName = new ComboBox();
		Label1 = new Label();
		DGV_DEL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboCity = new ComboBox();
		lblCity = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		Label3 = new Label();
		tDesgnNo = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
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
		((Control)lblMobile).Visible = false;
		((Control)lblAdd1).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.White;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(23, 0);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).RightToLeft = (RightToLeft)1;
		((Control)lblAdd1).Size = new Size(301, 20);
		((Control)lblAdd1).TabIndex = 1139;
		lblAdd1.Text = "Address";
		((Control)lblAdd1).Visible = false;
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
		lblBook.Text = "Mfg Zoom Report";
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
		((Control)DGV_AC).Location = new Point(14, 80);
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
		((Control)DGV_AC).Size = new Size(1163, 435);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label11);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tOrdDesgn);
		((Control)PnlAcSumm).Controls.Add((Control)(object)btnOk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)btnIsuNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label7);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tOrdNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label6);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tKrCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tKrName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label5);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label4);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboProcessName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_DEL);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mToDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mFromDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlAcSumm).Location = new Point(-1, 33);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 530);
		((Control)PnlAcSumm).TabIndex = 0;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(812, 12);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(64, 20);
		((Control)Label11).TabIndex = 1187;
		Label11.Text = "Design";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tOrdDesgn).BackColor = Color.White;
		((Control)tOrdDesgn).Font = new Font("Tahoma", 9f);
		((Control)tOrdDesgn).Location = new Point(882, 11);
		((TextBoxBase)tOrdDesgn).MaxLength = 15;
		((Control)tOrdDesgn).Name = "tOrdDesgn";
		((Control)tOrdDesgn).Size = new Size(118, 22);
		((Control)tOrdDesgn).TabIndex = 1186;
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
		((Control)btnOk).Location = new Point(1047, 25);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(95, 37);
		((Control)btnOk).TabIndex = 1172;
		btnOk.Text = "&Ok";
		((BaseStyleControl)btnIsuNo).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnIsuNo).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnIsuNo).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnIsuNo).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnIsuNo).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseForeColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnIsuNo).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnIsuNo).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIsuNo).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnIsuNo).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnIsuNo).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnIsuNo).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseFont = true;
		((Control)btnIsuNo).Location = new Point(965, 40);
		((BaseControl)btnIsuNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIsuNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIsuNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIsuNo).Name = "btnIsuNo";
		((Control)btnIsuNo).Size = new Size(35, 23);
		((Control)btnIsuNo).TabIndex = 1169;
		btnIsuNo.Text = "F1";
		((BaseControl)btnIsuNo).ToolTip = "Voucher Help";
		((Control)btnIsuNo).Visible = false;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(822, 42);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(57, 20);
		((Control)Label7).TabIndex = 1168;
		Label7.Text = "Ord No";
		Label7.TextAlign = (ContentAlignment)16;
		((Control)Label7).Visible = false;
		((TextBoxBase)tOrdNo).BackColor = Color.White;
		((Control)tOrdNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tOrdNo).Location = new Point(882, 40);
		((TextBoxBase)tOrdNo).MaxLength = 8;
		((Control)tOrdNo).Name = "tOrdNo";
		((TextBoxBase)tOrdNo).ReadOnly = true;
		((Control)tOrdNo).Size = new Size(76, 22);
		((Control)tOrdNo).TabIndex = 1167;
		((Control)tOrdNo).Visible = false;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(190, 44);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(71, 20);
		((Control)Label6).TabIndex = 1166;
		Label6.Text = "Kr Code";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tKrCode).BackColor = Color.White;
		((Control)tKrCode).Font = new Font("Tahoma", 9f);
		((Control)tKrCode).Location = new Point(268, 43);
		((TextBoxBase)tKrCode).MaxLength = 8;
		((Control)tKrCode).Name = "tKrCode";
		((Control)tKrCode).Size = new Size(71, 22);
		((Control)tKrCode).TabIndex = 1164;
		((TextBoxBase)tKrName).BackColor = Color.White;
		((Control)tKrName).Font = new Font("Tahoma", 9.75f);
		((Control)tKrName).Location = new Point(345, 43);
		((TextBoxBase)tKrName).MaxLength = 8;
		((Control)tKrName).Name = "tKrName";
		((Control)tKrName).Size = new Size(206, 23);
		((Control)tKrName).TabIndex = 1165;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(9, 43);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(87, 20);
		((Control)Label5).TabIndex = 1163;
		Label5.Text = "To Date";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(190, 13);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(71, 20);
		((Control)Label4).TabIndex = 1162;
		Label4.Text = "Ac Code";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(268, 13);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(71, 22);
		((Control)tAcCode).TabIndex = 1160;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(345, 12);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(206, 23);
		((Control)tAcName).TabIndex = 1161;
		cboProcessName.AutoCompleteMode = (AutoCompleteMode)3;
		cboProcessName.AutoCompleteSource = (AutoCompleteSource)256;
		cboProcessName.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboProcessName).Font = new Font("Tahoma", 9f);
		((ListControl)cboProcessName).FormattingEnabled = true;
		((Control)cboProcessName).Location = new Point(689, 43);
		((Control)cboProcessName).Name = "cboProcessName";
		((Control)cboProcessName).Size = new Size(120, 22);
		((Control)cboProcessName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(567, 47);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(107, 19);
		((Control)Label1).TabIndex = 1159;
		Label1.Text = "Process Name";
		Label1.TextAlign = (ContentAlignment)64;
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
		((Control)DGV_DEL).Location = new Point(14, 80);
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
		((Control)DGV_DEL).Size = new Size(1163, 435);
		((DataGridView)DGV_DEL).StandardTab = true;
		((Control)DGV_DEL).TabIndex = 1157;
		((Control)DGV_DEL).Visible = false;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(689, 12);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(120, 22);
		((Control)cboCity).TabIndex = 4;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(592, 13);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(82, 19);
		((Control)lblCity).TabIndex = 1138;
		lblCity.Text = "Work Type";
		lblCity.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(104, 43);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(104, 10);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(9, 11);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(87, 20);
		((Control)Label3).TabIndex = 1156;
		Label3.Text = "Form Date";
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
		((Control)this).Name = "RP_MFG_ZOOM";
		((Form)this).Text = "Mfg Zoom";
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

	private void DGV_MFG_INOUT()
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).Columns.Clear();
		((DataGridView)DGV_AC).Rows.Clear();
		((Control)DGV_AC).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY B.TRAN_NAME) AS SrNo,B.TRAN_NAME As Name,Format(SUM(A.ITM_GWT),'0.000') As GrWt,Format(SUM(A.ITM_OTH_WT),'0.000') As OthWt,Format(SUM(A.ITM_NWT),'0.000') As NetWt,Format(SUM(A.KR_MINO_WT),'0.000') As MinoWt,Format(SUM(A.DM_PCS),'0') As DmPcs,Format(SUM(A.DM_WT),'0.000') As DmWt,  Format(SUM(A.ITM_GHT_WT),'0.000') As GhtWt,Format(SUM(A.RTN_GHIS),'0.000') As Ghis,Format(SUM(A.RTN_CHOL),'0.000') As Chol FROM (MFG_DETL AS A LEFT JOIN MFG_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  "));
		DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		if (Operators.CompareString(tKrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + " And A.KR_CODE =  '" + tKrCode.Text + "'";
		}
		DC_Main.RsQry += " GROUP BY B.TRAN_NAME";
		DC_Main.RsQry += " ORDER BY B.TRAN_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(DC_Main.Tbl);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_AC).MultiSelect = false;
				((DataGridView)DGV_AC).AutoGenerateColumns = false;
				((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
				((DataGridView)DGV_AC).ColumnCount = 11;
				((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
				((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(200.0 * ColCon);
				((DataGridView)DGV_AC).Columns[1].DataPropertyName = "Name";
				((DataGridView)DGV_AC).Columns[1].HeaderText = "Process Name";
				((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[2].DataPropertyName = "GrWt";
				((DataGridView)DGV_AC).Columns[2].HeaderText = "GrWt";
				((DataGridView)DGV_AC).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[2].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[3].DataPropertyName = "OthWt";
				((DataGridView)DGV_AC).Columns[3].HeaderText = "OthWt";
				((DataGridView)DGV_AC).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[3].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[4].DataPropertyName = "NetWt";
				((DataGridView)DGV_AC).Columns[4].HeaderText = "NetWt";
				((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[7].DataPropertyName = "MinoWt";
				((DataGridView)DGV_AC).Columns[7].HeaderText = "MinoWt";
				((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DmPcs";
				((DataGridView)DGV_AC).Columns[5].HeaderText = "DmPcs";
				((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DmWt";
				((DataGridView)DGV_AC).Columns[6].HeaderText = "DmWt";
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[8].DataPropertyName = "GhtWt";
				((DataGridView)DGV_AC).Columns[8].HeaderText = "GhatWt";
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[9].DataPropertyName = "Ghis";
				((DataGridView)DGV_AC).Columns[9].HeaderText = "Ghis";
				((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[10].DataPropertyName = "Chol";
				((DataGridView)DGV_AC).Columns[10].HeaderText = "Chol";
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).DataSource = dataView;
			}
		}
	}

	private void RP_MFG_ZOOM_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			DGV_DETL_LOT_FILL();
		}
		CurActCtrl.Focus();
	}

	private void DGV_DESIGN_FILL()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).Columns.Clear();
		((DataGridView)DGV_AC).Rows.Clear();
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
		((DataGridView)DGV_AC).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "LotNo");
			((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Date");
			((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
			DC_Main.RsQry = "UPDATE MFG_MAST SET MFG_MAST.BOOK_SNAME = B.BOOK_SNAME FROM MFG_MAST,BOOK_DATA AS B WHERE MFG_MAST.CO_CODE = B.CO_CODE AND MFG_MAST.CO_BOOK = B.CO_BOOK AND MFG_MAST.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '00'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT BOOK_SNAME FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CUR_IN_USE = 'Y' ORDER BY SM_CODE";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(DC_Main.Tbl);
			DC_Main.i = 3;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_AC).Columns.Add("", Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"]));
				((DataGridView)DGV_AC).Columns[DC_Main.i].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_AC).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				DC_Main.i++;
				DC_Main.M++;
			}
			((DataGridView)DGV_AC).Columns.Add("", "DiffWt");
			((DataGridView)DGV_AC).Columns[DC_Main.i].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_AC).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
			{
				((DataGridView)DGV_AC).Columns.Add("", "IsPan");
				((DataGridView)DGV_AC).Columns[DC_Main.i + 1].Visible = false;
				((DataGridView)DGV_AC).Columns[DC_Main.i + 1].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns.Add("", "PurcAc");
				((DataGridView)DGV_AC).Columns[DC_Main.i + 1].Width = (int)Math.Round(2500.0 * ColCon);
			}
			else
			{
				((DataGridView)DGV_AC).Columns.Add("", "IsPan");
				((DataGridView)DGV_AC).Columns[DC_Main.i + 1].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_AC).Columns[DC_Main.i + 1].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns.Add("", "PurcAc");
				((DataGridView)DGV_AC).Columns[DC_Main.i + 1].Visible = false;
			}
			if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.ITM_LOT AS LOT_NO,B.SM_CODE,B.BOOK_SNAME,A.IR_TYPE,SUM(A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS) As Gwt FROM MFG_ISU_REC AS A LEFT JOIN MFG_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ";
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.AC_CODE =  '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(tKrCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.KR_AC_CODE =  '" + tKrCode.Text + "'";
				}
				if (Operators.CompareString(tOrdDesgn.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.ITM_LOT =  '" + tOrdDesgn.Text + "'";
				}
				DC_Main.RsQry += "GROUP BY A.ITM_LOT,B.SM_CODE,B.BOOK_SNAME,A.IR_TYPE ";
				DC_Main.RsQry += "ORDER BY A.ITM_LOT,B.SM_CODE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.RsQry = "SELECT A.LOT_NO,B.SM_CODE,B.BOOK_SNAME,A.IR_TYPE,SUM(A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS) As Gwt FROM MFG_ISU_REC AS A LEFT JOIN MFG_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ";
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.AC_CODE =  '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(tKrCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.KR_AC_CODE =  '" + tKrCode.Text + "'";
				}
				if (Operators.CompareString(tOrdDesgn.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.LOT_NO =  '" + tOrdDesgn.Text + "'";
				}
				DC_Main.RsQry += "GROUP BY A.LOT_NO,B.SM_CODE,B.BOOK_SNAME,A.IR_TYPE ";
				DC_Main.RsQry += "ORDER BY A.LOT_NO,B.SM_CODE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			DC_Main.R = -1;
			string text = "";
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				int num2 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
					if (Operators.ConditionalCompareObjectNotEqual((object)text, Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["LOT_NO"], (object)""), false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["LOT_NO"], (object)""));
						((DataGridView)dGV_AC).Rows.Add();
						DC_Main.R++;
						((DataGridView)dGV_AC)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV_AC)[1, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["LOT_NO"], (object)"");
						if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TOP 1 VCH_DATE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_LOT = '"), DC_Main.Tbl.Rows[DC_Main.M]["LOT_NO"]), (object)"' ORDER BY VCH_TIME"));
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TOP 1 VCH_DATE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LOT_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["LOT_NO"]), (object)"' ORDER BY VCH_TIME"));
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							((DataGridView)dGV_AC)[2, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[0]["VCH_DATE"]), "dd/MM/yyyy");
						}
						int num3 = ((BaseCollection)((DataGridView)dGV_AC).Columns).Count - 1;
						DC_Main.i = 3;
						while (DC_Main.i <= num3)
						{
							if (Operators.ConditionalCompareObjectEqual((object)(((DataGridView)dGV_AC).Columns[DC_Main.i].HeaderText ?? ""), Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""), false))
							{
								((DataGridView)dGV_AC)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"])), "0.000");
								break;
							}
							DC_Main.i++;
						}
					}
					else
					{
						int num4 = ((BaseCollection)((DataGridView)dGV_AC).Columns).Count - 1;
						DC_Main.i = 3;
						while (DC_Main.i <= num4)
						{
							string text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""));
							string text3 = ((DataGridView)dGV_AC).Columns[DC_Main.i].HeaderText ?? "";
							if (Operators.ConditionalCompareObjectEqual((object)(((DataGridView)dGV_AC).Columns[DC_Main.i].HeaderText ?? ""), Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""), false))
							{
								if ((DC_Main.Tbl.Rows.Count > 0) & (DC_Main.R >= 0))
								{
									((DataGridView)dGV_AC)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"], (object)"")), "0.000");
								}
								break;
							}
							DC_Main.i++;
						}
					}
					dGV_AC = null;
					DC_Main.M++;
				}
			}
			int num5 = ((DataGridView)DGV_AC).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num5)
			{
				if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.ITM_LOT AS LOT_NO,SUM(IIF(ITM_SIGN = '-',A.ITM_NWT,-ITM_NWT)) As DiffWt FROM MFG_ISU_REC AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND ITM_LOT = '"), ((DataGridView)DGV_AC)[1, DC_Main.M].Value), (object)"' AND A.IR_TYPE <> 'L' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND AC_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKrCode.Text, "", false) == 0, (object)"", (object)("AND KR_AC_CODE = '" + tKrCode.Text + "'"))), (object)" GROUP BY ITM_LOT ORDER BY ITM_LOT"));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.LOT_NO,SUM(IIF(ITM_SIGN = '-',A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS,-(A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS))) As DiffWt FROM MFG_ISU_REC AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND LOT_NO = '"), ((DataGridView)DGV_AC)[1, DC_Main.M].Value), (object)"' AND A.IR_TYPE <> 'L' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND AC_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKrCode.Text, "", false) == 0, (object)"", (object)("AND KR_AC_CODE = '" + tKrCode.Text + "'"))), (object)" GROUP BY LOT_NO ORDER BY LOT_NO"));
				}
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					((DataGridView)DGV_AC)[((BaseCollection)((DataGridView)DGV_AC).Columns).Count - 3, DC_Main.M].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DiffWt"])), "0.000");
				}
				if (Operators.CompareString(tKrCode.Text, "", false) == 0)
				{
					if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.ITM_LOT AS LOT_NO,SUM(IIF(ITM_SIGN = '-',ITM_NWT,-ITM_NWT)) As DiffWt FROM MFG_ISU_REC AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND ITM_LOT = '"), ((DataGridView)DGV_AC)[1, DC_Main.M].Value), (object)"' AND A.IR_TYPE = 'L' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" And AC_CODE = '" + tAcCode.Text + "'"))), (object)" GROUP BY ITM_LOT ORDER BY ITM_LOT"));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.LOT_NO,SUM(IIF(ITM_SIGN = '-',A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS,-(A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS))) As DiffWt FROM MFG_ISU_REC AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND LOT_NO = '"), ((DataGridView)DGV_AC)[1, DC_Main.M].Value), (object)"' AND A.IR_TYPE = 'L' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" And AC_CODE = '" + tAcCode.Text + "'"))), (object)" GROUP BY LOT_NO ORDER BY LOT_NO"));
					}
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						((DataGridView)DGV_AC)[((BaseCollection)((DataGridView)DGV_AC).Columns).Count - 2, DC_Main.M].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DiffWt"])), "0.000");
					}
				}
				if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME  FROM PR_DATA AS A INNER JOIN PR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND B.ITM_LOT = '"), ((DataGridView)DGV_AC)[1, DC_Main.M].Value), (object)"' "));
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						((DataGridView)DGV_AC)[((BaseCollection)((DataGridView)DGV_AC).Columns).Count - 1, DC_Main.M].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_NAME"]);
					}
				}
				DC_Main.M++;
			}
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlAcSumm).Visible = false;
		DgvAcEnter = true;
		int columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		DgvCurRow = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		BtnExit.Text = "&Back";
		if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
		{
			Label2.Text = "Pro Type";
			((Control)tDesgnNo).Width = 200;
			tDesgnNo.Text = Conversions.ToString(((DataGridView)DGV_AC)[1, index].Value);
		}
		else
		{
			Label2.Text = "Lot No";
			tDesgnNo.Text = Conversions.ToString(((DataGridView)DGV_AC)[1, index].Value);
		}
		DGV_DETL_LOT_FILL();
	}

	private void DGV_DETL_LOT_FILL()
	{
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_11d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e1: Expected O, but got Unknown
		//IL_1213: Unknown result type (might be due to invalid IL or missing references)
		//IL_1218: Unknown result type (might be due to invalid IL or missing references)
		//IL_1222: Expected O, but got Unknown
		//IL_1238: Unknown result type (might be due to invalid IL or missing references)
		//IL_123d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1247: Expected O, but got Unknown
		//IL_125d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1262: Unknown result type (might be due to invalid IL or missing references)
		//IL_126c: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		checked
		{
			if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.ORD_YRCD,A.ORD_DBCD,A.ORD_NO AS LOT_NO,A.ORD_SRNO,A.IT_CODE,A.KR_CODE,B.AC_NAME,A.ENTRY_TYPE,A.VCH_DATE As KrDate,A.TAG_NO as TagLot,  A.ITM_PCS As IsuPcs,A.ITM_GWT As IsuGWt,A.ITM_OTH_WT As IsuOth,A.ITM_NWT As IsuNWt,  A.ITM_GHT_WT As RecGhat,A.RTN_CHOL As RecChol,A.RTN_GHIS As RecGhis,A.KR_MINO_WT As RecMtrl,A.LBR_AMT As LbrAmt,A.DESIGN_NO,A.ITM_SIZE,Format(A.DM_PCS,'0') As DmPcs,Format(A.DM_WT,'0.000') As DmWt  FROM ((MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.KR_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK)  LEFT JOIN MFG_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  And D.TRAN_NAME = '"), ((DataGridView)DGV_AC)[1, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(tKrCode.Text, "", false) == 0, (object)"", (object)("AND A.KR_CODE = '" + tKrCode.Text + "'"))), (object)" And A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' ORDER BY A.VCH_DATE,B.AC_NAME "));
				DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DataView dataView = new DataView(table);
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_DETL).MultiSelect = false;
					((DataGridView)DGV_DETL).AutoGenerateColumns = false;
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
					{
						((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
					}
					((DataGridView)DGV_DETL).ColumnCount = 24;
					((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_DETL).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "LOT_NO";
					((DataGridView)DGV_DETL).Columns[1].HeaderText = "OrdNo";
					((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[2].DataPropertyName = "IT_CODE";
					((DataGridView)DGV_DETL).Columns[2].HeaderText = "ItCode";
					((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(95.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[3].DataPropertyName = "DESIGN_NO";
					((DataGridView)DGV_DETL).Columns[3].HeaderText = "Design";
					((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[4].DataPropertyName = "ITM_SIZE";
					((DataGridView)DGV_DETL).Columns[4].HeaderText = "Size";
					((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[5].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_DETL).Columns[5].HeaderText = "KrName";
					((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[6].DataPropertyName = "KrDate";
					((DataGridView)DGV_DETL).Columns[6].HeaderText = "KrDate";
					((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_DETL).Columns[7].Visible = false;
					((DataGridView)DGV_DETL).Columns[7].DataPropertyName = "IsuGWt";
					((DataGridView)DGV_DETL).Columns[7].HeaderText = "GrWt";
					((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[8].Visible = false;
					((DataGridView)DGV_DETL).Columns[8].DataPropertyName = "IsuOth";
					((DataGridView)DGV_DETL).Columns[8].HeaderText = "OthWt";
					((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[9].Visible = false;
					((DataGridView)DGV_DETL).Columns[9].DataPropertyName = "IsuNWt";
					((DataGridView)DGV_DETL).Columns[9].HeaderText = "NetWt";
					((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(55.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[10].DataPropertyName = "IsuPcs";
					((DataGridView)DGV_DETL).Columns[10].HeaderText = "Pcs";
					((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N0";
					((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[11].DataPropertyName = "IsuGWt";
					((DataGridView)DGV_DETL).Columns[11].HeaderText = "GrWt";
					((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[12].DataPropertyName = "IsuOth";
					((DataGridView)DGV_DETL).Columns[12].HeaderText = "OthWt";
					((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[13].DataPropertyName = "IsuNWt";
					((DataGridView)DGV_DETL).Columns[13].HeaderText = "NetWt";
					((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[14].DataPropertyName = "DmPcs";
					((DataGridView)DGV_DETL).Columns[14].HeaderText = "DmPcs";
					((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N0";
					((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[15].DataPropertyName = "DmWt";
					((DataGridView)DGV_DETL).Columns[15].HeaderText = "DmWt";
					((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[16].DataPropertyName = "RecGhat";
					((DataGridView)DGV_DETL).Columns[16].HeaderText = "RGht";
					((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[17].DataPropertyName = "RecChol";
					((DataGridView)DGV_DETL).Columns[17].HeaderText = "RChol";
					((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[18].DataPropertyName = "RecGhis";
					((DataGridView)DGV_DETL).Columns[18].HeaderText = "RGhis";
					((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[19].DataPropertyName = "RecMtrl";
					((DataGridView)DGV_DETL).Columns[19].HeaderText = "Mino";
					((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[20].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[20].DataPropertyName = "LbrAmt";
					((DataGridView)DGV_DETL).Columns[20].HeaderText = "LbrAmt";
					((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[21].Visible = false;
					((DataGridView)DGV_DETL).Columns[21].DataPropertyName = "KR_AC_CODE";
					((DataGridView)DGV_DETL).Columns[21].HeaderText = "KrCode";
					((DataGridView)DGV_DETL).Columns[22].Visible = false;
					((DataGridView)DGV_DETL).Columns[22].DataPropertyName = "DiffWt";
					((DataGridView)DGV_DETL).Columns[22].HeaderText = "DiffWt";
					((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).DataSource = dataView;
				}
			}
			else
			{
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.ORD_YRCD,A.ORD_DBCD,A.ORD_NO AS LOT_NO,A.ORD_SRNO,A.IT_CODE,A.KR_CODE,B.AC_NAME,A.ENTRY_TYPE,  SUM(IIF(C.BOOK_INOUT = 'O',A.ITM_PCS,0)) As IsuPcs,SUM(IIF(C.BOOK_INOUT = 'O',A.ITM_GWT,0)) As IsuGWt,SUM(IIF(C.BOOK_INOUT = 'O',A.ITM_NWT,0)) As IsuNWt,  SUM(IIF(C.BOOK_INOUT = 'I',A.ITM_PCS,0)) As RecPcs,SUM(IIF(C.BOOK_INOUT = 'I',A.ITM_GWT,0)) As RecGWt,SUM(IIF(C.BOOK_INOUT = 'I',A.ITM_NWT,0)) As RecNWt,  SUM(IIF(C.BOOK_INOUT = 'I',A.ITM_GHT_WT,0)) As RecGhat,SUM(IIF(C.BOOK_INOUT = 'I',A.RTN_CHOL,0)) As RecChol,SUM(IIF(C.BOOK_INOUT = 'I',A.RTN_GHIS,0)) As RecGhis,SUM(IIF(C.BOOK_INOUT = 'I',A.KR_MINO_WT,0)) As RecMtrl,  SUM(IIF(C.BOOK_INOUT = 'O',A.ITM_GWT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHT_WT,-(A.ITM_GWT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHT_WT))) As DiffWt  FROM (MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.KR_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORD_YRCD = '"), ((DataGridView)DGV_AC)[7, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' AND A.ORD_DBCD = '"), ((DataGridView)DGV_AC)[6, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' AND A.ORD_NO = '"), ((DataGridView)DGV_AC)[1, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' AND A.ORD_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[3, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value))), (object)"  GROUP BY A.ORD_YRCD,A.ORD_DBCD,A.ORD_NO,A.ORD_SRNO,A.IT_CODE,A.KR_CODE,B.AC_NAME,A.ENTRY_TYPE  ORDER BY B.AC_NAME "));
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.ITM_LOT AS LOT_NO,A.LOT_NO As TagLot,A.IT_CODE,A.KR_AC_CODE,B.AC_NAME,A.IR_TYPE,  SUM(IIF(ITM_SIGN = '-',A.IR_PCS,0)) As IsuPcs,SUM(IIF(A.ITM_SIGN = '-',A.ITM_GWT,0)) As IsuGWt,SUM(IIF(A.ITM_SIGN = '-',A.ITM_NWT,0)) As IsuNWt,  SUM(IIF(ITM_SIGN = '+',A.IR_PCS,0)) As RecPcs,SUM(IIF(A.ITM_SIGN = '+',A.ITM_GWT,0)) As RecGWt,SUM(IIF(A.ITM_SIGN = '+',A.ITM_NWT,0)) As RecNWt,  SUM(IIF(ITM_SIGN = '+',A.ITM_GHAT,0)) As RecGhat,SUM(IIF(A.ITM_SIGN = '+',A.RTN_CHOL,0)) As RecChol,SUM(IIF(A.ITM_SIGN = '+',A.RTN_GHIS,0)) As RecGhis,SUM(IIF(A.ITM_SIGN = '+',A.RTN_MTRL,0)) As RecMtrl,  SUM(IIF(ITM_SIGN = '-',A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS,-(A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS))) As DiffWt  FROM MFG_ISU_REC AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.KR_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_LOT = '"), ((DataGridView)DGV_AC)[1, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' AND A.IR_TYPE <> 'L' GROUP BY A.ITM_LOT,A.LOT_NO,A.IT_CODE,A.KR_AC_CODE,B.AC_NAME,A.IR_TYPE ORDER BY B.AC_NAME "));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.LOT_NO,A.IT_CODE,A.KR_AC_CODE,B.AC_NAME,A.IR_TYPE,  SUM(IIF(ITM_SIGN = '-',A.IR_PCS,0)) As IsuPcs,SUM(IIF(A.ITM_SIGN = '-',A.ITM_GWT,0)) As IsuGWt,SUM(IIF(A.ITM_SIGN = '-',A.ITM_NWT,0)) As IsuNWt,  SUM(IIF(ITM_SIGN = '+',A.IR_PCS,0)) As RecPcs,SUM(IIF(A.ITM_SIGN = '+',A.ITM_GWT,0)) As RecGWt,SUM(IIF(A.ITM_SIGN = '+',A.ITM_NWT,0)) As RecNWt,  SUM(IIF(ITM_SIGN = '+',A.ITM_GHAT,0)) As RecGhat,SUM(IIF(A.ITM_SIGN = '+',A.RTN_CHOL,0)) As RecChol,SUM(IIF(A.ITM_SIGN = '+',A.RTN_GHIS,0)) As RecGhis,SUM(IIF(A.ITM_SIGN = '+',A.RTN_MTRL,0)) As RecMtrl,  SUM(IIF(ITM_SIGN = '-',A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS,-(A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS))) As DiffWt  FROM MFG_ISU_REC AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.KR_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LOT_NO = '"), ((DataGridView)DGV_AC)[1, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' AND A.IR_TYPE <> 'L' GROUP BY A.LOT_NO,A.IT_CODE,A.KR_AC_CODE,B.AC_NAME,A.IR_TYPE ORDER BY B.AC_NAME "));
				}
				DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DataView dataView2 = new DataView(table);
				if (dataView2.Count > 0)
				{
					((DataGridView)DGV_DETL).MultiSelect = false;
					((DataGridView)DGV_DETL).AutoGenerateColumns = false;
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
					{
						((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
					}
					((DataGridView)DGV_DETL).ColumnCount = 23;
					((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_DETL).Columns[0].HeaderText = "SrNo";
					if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
					{
						((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
						((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "LOT_NO";
						((DataGridView)DGV_DETL).Columns[1].HeaderText = "OrdNo";
					}
					else
					{
						((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
						((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "LOT_NO";
						((DataGridView)DGV_DETL).Columns[1].HeaderText = "LotNo";
					}
					((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[2].DataPropertyName = "IT_CODE";
					((DataGridView)DGV_DETL).Columns[2].HeaderText = "ItCode";
					if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
					{
						((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
						((DataGridView)DGV_DETL).Columns[3].DataPropertyName = "TagLot";
						((DataGridView)DGV_DETL).Columns[3].HeaderText = "TagLot";
					}
					else
					{
						((DataGridView)DGV_DETL).Columns[3].Visible = false;
					}
					((DataGridView)DGV_DETL).Columns[4].Visible = false;
					((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(185.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[5].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_DETL).Columns[5].HeaderText = "KrName";
					((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(55.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[6].DataPropertyName = "IsuPcs";
					((DataGridView)DGV_DETL).Columns[6].HeaderText = "IPcs";
					((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N0";
					((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[7].DataPropertyName = "IsuGWt";
					((DataGridView)DGV_DETL).Columns[7].HeaderText = "IGrWt";
					((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[8].Visible = false;
					((DataGridView)DGV_DETL).Columns[8].DataPropertyName = "";
					((DataGridView)DGV_DETL).Columns[8].HeaderText = "IOthWt";
					((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[9].DataPropertyName = "IsuNWt";
					((DataGridView)DGV_DETL).Columns[9].HeaderText = "INetWt";
					((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(55.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[10].DataPropertyName = "RecPcs";
					((DataGridView)DGV_DETL).Columns[10].HeaderText = "RPcs";
					((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N0";
					((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[11].DataPropertyName = "RecGWt";
					((DataGridView)DGV_DETL).Columns[11].HeaderText = "RGwt";
					((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[12].Visible = false;
					((DataGridView)DGV_DETL).Columns[12].DataPropertyName = "";
					((DataGridView)DGV_DETL).Columns[12].HeaderText = "ROth";
					((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[13].DataPropertyName = "RecNWt";
					((DataGridView)DGV_DETL).Columns[13].HeaderText = "RNwt";
					((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).Columns[14].Visible = false;
					((DataGridView)DGV_DETL).Columns[15].Visible = false;
					if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
					{
						((DataGridView)DGV_DETL).Columns[16].Visible = false;
						((DataGridView)DGV_DETL).Columns[16].DataPropertyName = "RecGhat";
						((DataGridView)DGV_DETL).Columns[16].HeaderText = "RGht";
						((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[17].Visible = false;
						((DataGridView)DGV_DETL).Columns[17].DataPropertyName = "RecChol";
						((DataGridView)DGV_DETL).Columns[17].HeaderText = "RChol";
						((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[18].Visible = false;
						((DataGridView)DGV_DETL).Columns[18].DataPropertyName = "RecGhis";
						((DataGridView)DGV_DETL).Columns[18].HeaderText = "RGhis";
						((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[19].Visible = false;
						((DataGridView)DGV_DETL).Columns[19].DataPropertyName = "RecMtrl";
						((DataGridView)DGV_DETL).Columns[19].HeaderText = "Mino";
						((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[20].Visible = false;
						((DataGridView)DGV_DETL).Columns[20].DataPropertyName = "";
						((DataGridView)DGV_DETL).Columns[20].HeaderText = "RLoss";
						((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[21].Visible = false;
						((DataGridView)DGV_DETL).Columns[21].DataPropertyName = "KR_AC_CODE";
						((DataGridView)DGV_DETL).Columns[21].HeaderText = "KrCode";
					}
					else
					{
						((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(70.0 * ColCon);
						((DataGridView)DGV_DETL).Columns[16].DataPropertyName = "RecGhat";
						((DataGridView)DGV_DETL).Columns[16].HeaderText = "RGht";
						((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(70.0 * ColCon);
						((DataGridView)DGV_DETL).Columns[17].DataPropertyName = "RecChol";
						((DataGridView)DGV_DETL).Columns[17].HeaderText = "RChol";
						((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(70.0 * ColCon);
						((DataGridView)DGV_DETL).Columns[18].DataPropertyName = "RecGhis";
						((DataGridView)DGV_DETL).Columns[18].HeaderText = "RGhis";
						((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N3";
						if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
						{
							((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(70.0 * ColCon);
							((DataGridView)DGV_DETL).Columns[19].DataPropertyName = "RecMtrl";
							((DataGridView)DGV_DETL).Columns[19].HeaderText = "Mino";
							((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
							((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N3";
						}
						else
						{
							((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(70.0 * ColCon);
							((DataGridView)DGV_DETL).Columns[19].DataPropertyName = "RecMtrl";
							((DataGridView)DGV_DETL).Columns[19].HeaderText = "RMtrl";
							((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
							((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N3";
						}
						((DataGridView)DGV_DETL).Columns[20].Visible = false;
						((DataGridView)DGV_DETL).Columns[20].DataPropertyName = "";
						((DataGridView)DGV_DETL).Columns[20].HeaderText = "RLoss";
						((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Format = "N3";
						((DataGridView)DGV_DETL).Columns[21].Visible = false;
						((DataGridView)DGV_DETL).Columns[21].DataPropertyName = "KR_AC_CODE";
						((DataGridView)DGV_DETL).Columns[21].HeaderText = "KrCode";
					}
					((DataGridView)DGV_DETL).Columns[22].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_DETL).Columns[22].DataPropertyName = "DiffWt";
					((DataGridView)DGV_DETL).Columns[22].HeaderText = "DiffWt";
					((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_DETL).DataSource = dataView2;
				}
			}
			((Control)tDesgnNo).Focus();
			((TextBoxBase)tDesgnNo).SelectAll();
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
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					case 22:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 14:
					case 15:
					case 21:
						break;
					}
					break;
				case 173:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00e3;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 173;
				continue;
			}
			break;
			IL_00e3:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void RP_MFG_ZOOM_Load(object sender, EventArgs e)
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
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DEL = DGV_DEL;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DEL).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				ComboBox obj13 = cboCity;
				object? obj14 = colorConverter.ConvertFromString("243, 240, 239");
				obj13.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblAdd1).ForeColor = Color.Black;
				((Control)lblMobile).ForeColor = Color.Black;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.LightSlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DEL2 = DGV_DEL;
				object? obj16 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_DEL2).BackgroundColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC2 = DGV_AC;
				object? obj18 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj20 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				ComboBox obj22 = cboCity;
				object? obj23 = colorConverter.ConvertFromString("233, 235, 240");
				obj22.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj24 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj25 = lblBook;
				object? obj26 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj25).ForeColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj27 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DEL3 = DGV_DEL;
				object? obj28 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DEL3).BackgroundColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj29 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC3 = DGV_AC;
				object? obj30 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj32 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				cboCity.BackColor = Color.Cornsilk;
			}
			if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				cboProcessName.Items.Add((object)"Order");
				cboProcessName.Items.Add((object)"Krigar");
				cboProcessName.SelectedIndex = 0;
			}
			else
			{
				cboProcessName.Items.Add((object)"");
				cboProcessName.Items.Add((object)"Ghat");
				cboProcessName.Items.Add((object)"Jadtar");
				cboProcessName.Items.Add((object)"Fitting");
				cboProcessName.Items.Add((object)"Chediya");
				cboProcessName.SelectedIndex = 0;
			}
			if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
			{
				lblBook.Text = CurRpt;
				mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
				mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
				((Control)Label4).Visible = false;
				((Control)tAcCode).Visible = false;
				((Control)lblCity).Visible = false;
				((Control)cboCity).Visible = false;
				((Control)Label1).Visible = false;
				((Control)cboProcessName).Visible = false;
				((Control)tAcName).Visible = false;
				DGV_MFG_INOUT();
			}
			else
			{
				lblBook.Text = "Lot Wise Report";
				mFromDt.Text = "01/01/2020";
				mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
				cboCity.Items.Add((object)"Panding");
				cboCity.Items.Add((object)"Complete");
				cboCity.Items.Add((object)"All");
				cboCity.SelectedIndex = 0;
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					((Control)Label7).Visible = true;
					((Control)tOrdNo).Visible = true;
					((Control)btnIsuNo).Visible = true;
					DGV_ORD_FILL();
				}
				else
				{
					Label11.Text = "LotNo";
					DGV_DESIGN_FILL();
				}
			}
			CurActCtrl = (Control)(object)mFromDt;
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
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
					{
						int columnIndex = e.ColumnIndex;
						if ((uint)(columnIndex - 2) <= 8u)
						{
							if (Operators.ConditionalCompareObjectEqual(((ConvertEventArgs)e).Value, (object)"0.000", false))
							{
								((ConvertEventArgs)e).Value = "";
								e.FormattingApplied = true;
							}
							if (Operators.ConditionalCompareObjectEqual(((ConvertEventArgs)e).Value, (object)"0", false))
							{
								((ConvertEventArgs)e).Value = "";
								e.FormattingApplied = true;
							}
						}
					}
					else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
					{
						int columnIndex2 = e.ColumnIndex;
						if ((uint)(columnIndex2 - 8) <= 7u && Operators.ConditionalCompareObjectEqual(((ConvertEventArgs)e).Value, (object)"0", false))
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					else
					{
						int columnIndex3 = e.ColumnIndex;
						if ((uint)(columnIndex3 - 4) <= 2u && Operators.ConditionalCompareObjectEqual(((ConvertEventArgs)e).Value, (object)"0", false))
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					break;
				case 321:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_0177;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 321;
				continue;
			}
			break;
			IL_0177:
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
					case 1882:
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
								goto IL_01d3;
							case 18:
								goto IL_01f6;
							case 19:
							case 20:
								goto IL_024b;
							case 21:
								goto IL_025d;
							case 23:
								goto IL_027f;
							case 24:
								goto IL_0296;
							case 25:
								goto IL_02de;
							case 26:
								goto IL_02ed;
							case 27:
								goto IL_030a;
							case 28:
								goto IL_0324;
							case 29:
								goto IL_0347;
							case 30:
							case 31:
								goto IL_039c;
							case 32:
								goto IL_03ae;
							case 22:
							case 33:
							case 34:
								goto IL_03ca;
							case 35:
								goto IL_03d4;
							case 36:
								goto IL_0427;
							case 37:
								goto IL_047c;
							case 38:
								goto IL_04d4;
							case 39:
								goto IL_0542;
							case 40:
								goto IL_0585;
							case 41:
								goto IL_05b4;
							case 42:
								goto IL_05f7;
							case 43:
								goto IL_0638;
							case 44:
								goto IL_0659;
							case 45:
								goto IL_0667;
							case 46:
								goto IL_066d;
							case 47:
								goto IL_0673;
							case 48:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 49:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_039c:
						num2 = 31;
						num5++;
						goto IL_03a5;
						IL_0296:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_AC).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02de;
						IL_0347:
						num2 = 29;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_039c;
						IL_02de:
						num2 = 25;
						num6++;
						goto IL_02e7;
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
						goto IL_027f;
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
						goto IL_026c;
						IL_026c:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_03ca;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num11 = 0;
						goto IL_0254;
						IL_0254:
						if (num11 <= num10)
						{
							goto IL_01d3;
						}
						goto IL_025d;
						IL_025d:
						num2 = 21;
						DC_Main.i++;
						goto IL_026c;
						IL_01d3:
						num2 = 17;
						if (((DataGridView)DGV_DETL)[num11, DC_Main.i].Value != null)
						{
							goto IL_01f6;
						}
						goto IL_024b;
						IL_01f6:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_DETL)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_024b;
						IL_024b:
						num2 = 20;
						num11++;
						goto IL_0254;
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
						IL_027f:
						num2 = 23;
						num12 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num6 = 0;
						goto IL_02e7;
						IL_02e7:
						if (num6 <= num12)
						{
							goto IL_0296;
						}
						goto IL_02ed;
						IL_02ed:
						num2 = 26;
						num13 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_03bd;
						IL_03bd:
						if (DC_Main.i <= num13)
						{
							goto IL_030a;
						}
						goto IL_03ca;
						IL_03ca:
						num2 = 34;
						colorConverter = new ColorConverter();
						goto IL_03d4;
						IL_03d4:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0427;
						IL_0427:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_047c;
						IL_047c:
						num2 = 37;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04d4;
						IL_04d4:
						num2 = 38;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0542;
						IL_0542:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0585;
						IL_0585:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05b4;
						IL_05b4:
						num2 = 41;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05f7;
						IL_05f7:
						num2 = 42;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0638;
						IL_0638:
						num2 = 43;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0659;
						IL_0659:
						num2 = 44;
						Cursor.Current = Cursors.Default;
						goto IL_0667;
						IL_0667:
						num2 = 45;
						obj = null;
						goto IL_066d;
						IL_066d:
						num2 = 46;
						obj3 = null;
						goto IL_0673;
						IL_0673:
						num2 = 47;
						obj2 = null;
						break;
						IL_030a:
						num2 = 27;
						num14 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_03a5;
						IL_03a5:
						if (num5 <= num14)
						{
							goto IL_0324;
						}
						goto IL_03ae;
						IL_03ae:
						num2 = 32;
						DC_Main.i++;
						goto IL_03bd;
						IL_0324:
						num2 = 28;
						if (((DataGridView)DGV_AC)[num5, DC_Main.i].Value != null)
						{
							goto IL_0347;
						}
						goto IL_039c;
						end_IL_0001_2:
						break;
					}
					num2 = 48;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1882;
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
		tKrCode.Text = "";
		tKrName.Text = "";
		DgvAcEnter = false;
		cboCity.SelectedIndex = 0;
		if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
		{
			DGV_MFG_INOUT();
		}
		else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
		{
			DGV_ORD_FILL();
		}
		else
		{
			DGV_DESIGN_FILL();
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

	private void RP_MFG_ZOOM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_MFG_ZOOM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_MFG_ZOOM_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_MFG_ZOOM_Closed(object sender, EventArgs e)
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
			if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				DGV_ORD_FILL();
			}
			else
			{
				DGV_DESIGN_FILL();
			}
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
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				DGV_DETL_LOT_FILL();
			}
			else if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
			{
				DGV_MFG_INOUT();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				DGV_ORD_FILL();
			}
			else
			{
				DGV_DESIGN_FILL();
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
			if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				DGV_ORD_FILL();
			}
			else
			{
				DGV_DESIGN_FILL();
			}
		}
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
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
				DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR AS GroupL,B.AC_ADD1 As AddressL,B.AC_PHONE As PhoneL,B.AC_MOBILE As MobileL FROM MFG_ISU_REC AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY B.AC_NAME,A.AC_CODE,B.AC_GR,B.AC_ADD1,B.AC_PHONE,B.AC_MOBILE ORDER BY B.AC_NAME";
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
					}
					((Control)tAcCode).Focus();
					((TextBoxBase)tAcCode).SelectAll();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				DGV_DESIGN_FILL();
				((Control)tAcCode).Focus();
				((TextBoxBase)tAcCode).SelectAll();
			}
		}
		else
		{
			tAcName.Text = "";
		}
	}

	private void tKrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tKrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tKrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.KR_CODE As AcCodeL,B.AC_GR AS GroupL,B.AC_ADD1 As AddressL,B.AC_PHONE As PhoneL,B.AC_MOBILE As MobileL FROM MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.KR_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.KR_CODE <> '' GROUP BY B.AC_NAME,A.KR_CODE,B.AC_GR,B.AC_ADD1,B.AC_PHONE,B.AC_MOBILE ORDER BY B.AC_NAME";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.KR_AC_CODE As AcCodeL,B.AC_GR AS GroupL,B.AC_ADD1 As AddressL,B.AC_PHONE As PhoneL,B.AC_MOBILE As MobileL FROM MFG_ISU_REC AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.KR_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.KR_AC_CODE <> '' GROUP BY B.AC_NAME,A.KR_AC_CODE,B.AC_GR,B.AC_ADD1,B.AC_PHONE,B.AC_MOBILE ORDER BY B.AC_NAME";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
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
						tKrCode.Text = DC_Main.ColValue[1];
						tKrName.Text = DC_Main.ColValue[0];
					}
					((Control)tKrCode).Focus();
					((TextBoxBase)tKrCode).SelectAll();
				}
			}
			else
			{
				tKrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
				{
					DGV_MFG_INOUT();
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DGV_ORD_FILL();
				}
				else
				{
					DGV_DESIGN_FILL();
				}
				((Control)tKrCode).Focus();
				((TextBoxBase)tKrCode).SelectAll();
			}
		}
		else
		{
			tKrName.Text = "";
			if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
			{
				DGV_MFG_INOUT();
			}
			else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				DGV_ORD_FILL();
			}
			else
			{
				DGV_DESIGN_FILL();
			}
		}
	}

	private void DGV_ORD_FILL()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).Columns.Clear();
		((DataGridView)DGV_AC).Rows.Clear();
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
		((DataGridView)DGV_AC).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "OrdNo");
			((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Date");
			((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "OSr");
			((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Design");
			((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Ord Name");
			((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(140.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Book");
			((DataGridView)DGV_AC).Columns[6].Visible = false;
			((DataGridView)DGV_AC).Columns.Add("", "Year");
			((DataGridView)DGV_AC).Columns[7].Visible = false;
			((DataGridView)DGV_AC).Columns.Add("", "OrdWt");
			((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			DC_Main.RsQry = "UPDATE MFG_MAST SET MFG_MAST.BOOK_SNAME = B.BOOK_SNAME FROM MFG_MAST,BOOK_DATA AS B WHERE MFG_MAST.CO_CODE = B.CO_CODE AND MFG_MAST.CO_BOOK = B.CO_BOOK AND MFG_MAST.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '00'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
			{
				DC_Main.RsQry = "SELECT BOOK_SNAME FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_SNAME NOT IN ('MLTNG','GHTIS') AND CUR_IN_USE = 'Y' ORDER BY SM_CODE";
			}
			else
			{
				DC_Main.RsQry = "SELECT BOOK_SNAME FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CUR_IN_USE = 'Y' ORDER BY SM_CODE";
			}
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(DC_Main.Tbl);
			DC_Main.i = 9;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_AC).Columns.Add("", Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"]));
				((DataGridView)DGV_AC).Columns[DC_Main.i].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_AC).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				DC_Main.i++;
				DC_Main.M++;
			}
			((DataGridView)DGV_AC).Columns.Add("", "TagGen");
			((DataGridView)DGV_AC).Columns[DC_Main.i].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[DC_Main.i].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			if (cboProcessName.SelectedIndex == 1)
			{
				DC_Main.RsQry = "SELECT A.VCH_DATE,B.CO_YEAR,B.CO_BOOK,B.VCH_NO,B.OLD_SRNO,B.ITM_GWT As OrdWt,C.BOOK_SNAME,D.AC_NAME,A.ITM_GWT As Gwt,B.DESIGN_NO As OrdDesign FROM ((MFG_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.ORD_YRCD = B.CO_YEAR  AND A.ORD_DBCD = B.CO_BOOK  AND A.ORD_NO = B.VCH_NO AND A.ORD_SRNO = B.OLD_SRNO  )  LEFT JOIN MFG_MAST AS C ON A.CO_CODE = C.CO_CODE And A.CO_BOOK = C.CO_BOOK)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND B.AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ";
				if (cboCity.SelectedIndex == 0)
				{
					DC_Main.RsQry += " And A.REP_ADJ =  'N' AND A.INOUT_TYPE = 'O'";
				}
				else if (cboCity.SelectedIndex == 1)
				{
					DC_Main.RsQry += " And A.REP_ADJ <>  'N' AND A.INOUT_TYPE = 'O'";
				}
				if (Operators.CompareString(tOrdDesgn.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And B.DESIGN_NO =  '" + tOrdDesgn.Text + "'";
				}
				if (Operators.CompareString(tOrdNo.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And B.VCH_NO =  '" + tOrdNo.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And B.AC_CODE =  '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(tKrCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.KR_CODE =  '" + tKrCode.Text + "'";
				}
				DC_Main.RsQry = DC_Main.RsQry + "UNION ALL SELECT A.VCH_DATE,B.CO_YEAR,B.CO_BOOK,B.VCH_NO,B.OLD_SRNO,B.ITM_GWT As OrdWt,C.BOOK_SNAME,D.AC_NAME,A.ITM_GWT As Gwt,B.DESIGN_NO As OrdDesign FROM ((APR_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.ISU_YRCD = B.CO_YEAR  AND A.ISU_DBCD = B.CO_BOOK  AND A.ISU_NO = B.VCH_NO AND A.ISU_SRNO = B.OLD_SRNO  )  LEFT JOIN MFG_MAST AS C ON A.CO_CODE = C.CO_CODE And A.CO_BOOK = C.CO_BOOK)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND B.AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ";
				if (cboCity.SelectedIndex == 0)
				{
					DC_Main.RsQry += " And A.ISU_REC =  'N' AND A.BOOK_NAME = 'GHAT ISU'";
				}
				else if (cboCity.SelectedIndex == 1)
				{
					DC_Main.RsQry += " And A.ISU_REC <>  'N' AND A.BOOK_NAME = 'GHAT ISU'";
				}
				if (Operators.CompareString(tOrdDesgn.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And B.DESIGN_NO =  '" + tOrdDesgn.Text + "'";
				}
				if (Operators.CompareString(tOrdNo.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And B.VCH_NO =  '" + tOrdNo.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And B.AC_CODE =  '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(tKrCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " And A.AC_CODE =  '" + tKrCode.Text + "'";
				}
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = -1;
				string text = "";
				if (DC_Main.Tbl.Rows.Count <= 0)
				{
					return;
				}
				int num2 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
					if (Operators.ConditionalCompareObjectNotEqual((object)text, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"], (object)""), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]), false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"], (object)""), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]));
						((DataGridView)dGV_AC).Rows.Add();
						DC_Main.R++;
						((DataGridView)dGV_AC)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV_AC)[1, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"], (object)"");
						((DataGridView)dGV_AC)[2, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(DC_Main.Tbl.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
						((DataGridView)dGV_AC)[3, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"], (object)"");
						((DataGridView)dGV_AC)[4, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OrdDesign"], (object)"");
						((DataGridView)dGV_AC)[5, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["AC_NAME"], (object)"");
						((DataGridView)dGV_AC)[6, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"], (object)"");
						((DataGridView)dGV_AC)[7, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"], (object)"");
						((DataGridView)dGV_AC)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OrdWt"], (object)"")), "0.000");
						int num3 = ((BaseCollection)((DataGridView)dGV_AC).Columns).Count - 1;
						DC_Main.i = 3;
						while (DC_Main.i <= num3)
						{
							if (Operators.ConditionalCompareObjectEqual((object)(((DataGridView)dGV_AC).Columns[DC_Main.i].HeaderText ?? ""), Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""), false))
							{
								((DataGridView)dGV_AC)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"])), "0.000");
								break;
							}
							DC_Main.i++;
						}
					}
					else
					{
						int num4 = ((BaseCollection)((DataGridView)dGV_AC).Columns).Count - 1;
						DC_Main.i = 3;
						while (DC_Main.i <= num4)
						{
							if (Operators.CompareString(((DataGridView)dGV_AC).Columns[DC_Main.i].HeaderText, "MLTNG", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IR_WT FROM MFG_DETL AS A LEFT JOIN MFG_ISU_REC B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.LOT_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORD_YRCD = '"), ((DataGridView)dGV_AC)[7, DC_Main.R].Value), (object)"' AND A.ORD_DBCD = '"), ((DataGridView)dGV_AC)[6, DC_Main.R].Value), (object)"' AND A.ORD_NO = '"), ((DataGridView)dGV_AC)[1, DC_Main.R].Value), (object)"' AND A.ORD_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_AC)[3, DC_Main.R].Value))), (object)" AND B.CO_BOOK = '300' "));
								DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (dataTable.Rows.Count > 0)
								{
									((DataGridView)dGV_AC)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["IR_WT"], (object)"")), "0.000");
								}
							}
							else if (Operators.ConditionalCompareObjectEqual((object)(((DataGridView)dGV_AC).Columns[DC_Main.i].HeaderText ?? ""), Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""), false))
							{
								if ((DC_Main.Tbl.Rows.Count > 0) & (DC_Main.R >= 0))
								{
									((DataGridView)dGV_AC)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"], (object)"")), "0.000");
								}
								break;
							}
							DC_Main.i++;
						}
					}
					dGV_AC = null;
					DC_Main.M++;
				}
				return;
			}
			DC_Main.RsQry = "SELECT A.VCH_DATE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.OLD_SRNO,A.ITM_GWT As OrdWt,C.BOOK_SNAME,D.AC_NAME,SUM(B.ITM_GWT) As Gwt,A.DESIGN_NO As OrdDesign FROM ((SL_ORD_DETL AS A LEFT JOIN MFG_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO AND A.OLD_SRNO = B.ORD_SRNO)  LEFT JOIN MFG_MAST AS C ON B.CO_CODE = C.CO_CODE And B.CO_BOOK = C.CO_BOOK)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ";
			if (cboCity.SelectedIndex == 0)
			{
				DC_Main.RsQry += " And A.TAG_SALE <>  'Y'";
			}
			else if (cboCity.SelectedIndex == 1)
			{
				DC_Main.RsQry += " And A.TAG_SALE =  'Y'";
			}
			if (Operators.CompareString(tOrdDesgn.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " And A.DESIGN_NO =  '" + tOrdDesgn.Text + "'";
			}
			if (Operators.CompareString(tOrdNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " And A.VCH_NO =  '" + tOrdNo.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " And A.AC_CODE =  '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tKrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " And B.KR_CODE =  '" + tKrCode.Text + "'";
			}
			DC_Main.RsQry += "GROUP BY A.VCH_DATE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.OLD_SRNO,A.ITM_GWT,C.BOOK_SNAME,D.AC_NAME,A.DESIGN_NO,C.SM_CODE ";
			DC_Main.RsQry += " ORDER BY A.CO_YEAR DESC,A.CO_BOOK,A.VCH_NO DESC,A.OLD_SRNO,C.SM_CODE";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.R = -1;
			string text2 = "";
			if (DC_Main.Tbl.Rows.Count <= 0)
			{
				return;
			}
			int num5 = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num5)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC2 = DGV_AC;
				if (Operators.ConditionalCompareObjectNotEqual((object)text2, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"], (object)""), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]), false))
				{
					text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"], (object)""), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]));
					((DataGridView)dGV_AC2).Rows.Add();
					DC_Main.R++;
					((DataGridView)dGV_AC2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_AC2)[1, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"], (object)"");
					((DataGridView)dGV_AC2)[2, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(DC_Main.Tbl.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV_AC2)[3, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"], (object)"");
					((DataGridView)dGV_AC2)[4, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OrdDesign"], (object)"");
					((DataGridView)dGV_AC2)[5, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["AC_NAME"], (object)"");
					((DataGridView)dGV_AC2)[6, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"], (object)"");
					((DataGridView)dGV_AC2)[7, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"], (object)"");
					((DataGridView)dGV_AC2)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OrdWt"], (object)"")), "0.000");
					int num6 = ((BaseCollection)((DataGridView)dGV_AC2).Columns).Count - 1;
					DC_Main.i = 3;
					while (DC_Main.i <= num6)
					{
						if (Operators.CompareString(((DataGridView)dGV_AC2).Columns[DC_Main.i].HeaderText, "MLTNG", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IR_WT FROM MFG_DETL AS A LEFT JOIN MFG_ISU_REC B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.LOT_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORD_YRCD = '"), ((DataGridView)dGV_AC2)[7, DC_Main.R].Value), (object)"' AND A.ORD_DBCD = '"), ((DataGridView)dGV_AC2)[6, DC_Main.R].Value), (object)"' AND A.ORD_NO = '"), ((DataGridView)dGV_AC2)[1, DC_Main.R].Value), (object)"' AND A.ORD_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_AC2)[3, DC_Main.R].Value))), (object)" AND B.CO_BOOK = '300' "));
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								((DataGridView)dGV_AC2)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["IR_WT"], (object)"")), "0.000");
							}
						}
						else if (Operators.ConditionalCompareObjectEqual((object)(((DataGridView)dGV_AC2).Columns[DC_Main.i].HeaderText ?? ""), Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""), false))
						{
							if (Operators.CompareString(DC_Main.MsMeltingLotGenrate, "Y", false) == 0)
							{
								((DataGridView)dGV_AC2)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"])), "0.000");
							}
							else
							{
								((DataGridView)dGV_AC2)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"])), "0.000");
							}
							break;
						}
						DC_Main.i++;
					}
				}
				else
				{
					int num7 = ((BaseCollection)((DataGridView)dGV_AC2).Columns).Count - 1;
					DC_Main.i = 3;
					while (DC_Main.i <= num7)
					{
						if (Operators.CompareString(((DataGridView)dGV_AC2).Columns[DC_Main.i].HeaderText, "MLTNG", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IR_WT FROM MFG_DETL AS A LEFT JOIN MFG_ISU_REC B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.LOT_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORD_YRCD = '"), ((DataGridView)dGV_AC2)[7, DC_Main.R].Value), (object)"' AND A.ORD_DBCD = '"), ((DataGridView)dGV_AC2)[6, DC_Main.R].Value), (object)"' AND A.ORD_NO = '"), ((DataGridView)dGV_AC2)[1, DC_Main.R].Value), (object)"' AND A.ORD_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_AC2)[3, DC_Main.R].Value))), (object)" AND B.CO_BOOK = '300' "));
							DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0)
							{
								((DataGridView)dGV_AC2)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IR_WT"], (object)"")), "0.000");
							}
						}
						else if (Operators.ConditionalCompareObjectEqual((object)(((DataGridView)dGV_AC2).Columns[DC_Main.i].HeaderText ?? ""), Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["BOOK_SNAME"], (object)""), false))
						{
							if ((DC_Main.Tbl.Rows.Count > 0) & (DC_Main.R >= 0))
							{
								((DataGridView)dGV_AC2)[DC_Main.i, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["Gwt"], (object)"")), "0.000");
							}
							break;
						}
						DC_Main.i++;
					}
				}
				dGV_AC2 = null;
				DC_Main.M++;
			}
		}
	}

	private void btnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.AC_NAME As PartyNameL,A.DESIGN_NO As DesignL,A.ITM_SIZE As SizeL,A.ORD_DEL_DATE AS DeliveryL,A.CO_YEAR As YearL,A.CO_BOOK As BookL,A.OLD_SRNO As SrNoM FROM (SL_ORD_DETL AS A   LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND D.MAIN_BOOK = 'SALES ORDER'  ORDER BY A.VCH_NO,A.OLD_SRNO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[10];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 230.0;
		DC_Main.ColWidth[3] = 130.0;
		DC_Main.ColWidth[4] = 80.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.ColWidth[7] = 90.0;
		DC_Main.ColWidth[8] = 80.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tOrdNo.Text = DC_Main.ColValue[0];
				((Control)tOrdNo).Focus();
			}
			else
			{
				tOrdNo.Text = "";
			}
		}
	}

	private void tOrdNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
			{
				DGV_ORD_FILL();
			}
			else
			{
				DGV_DESIGN_FILL();
			}
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Mfg InOut", false) == 0)
		{
			DGV_MFG_INOUT();
		}
		else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
		{
			DGV_ORD_FILL();
		}
		else
		{
			DGV_DESIGN_FILL();
		}
	}

	private void tOrdDesgn_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btnOk).Focus();
		}
	}

	private void DGV_AC_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
	}

	private void tOrdDesgn_TextChanged(object sender, EventArgs e)
	{
	}
}
