using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
// Excel Interop type aliases — avoids conflicts with System.Windows.Forms
using Excel_Application = Microsoft.Office.Interop.Excel._Application;
using Excel_Workbooks = Microsoft.Office.Interop.Excel.Workbooks;
using Excel_Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Excel_Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using Excel_Sheets = Microsoft.Office.Interop.Excel.Sheets;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_ORD_TRACK : Form
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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private DateEdit _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private DateEdit _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnJmaUdhar")]
	private SimpleButton _BtnJmaUdhar;

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
	[AccessedThroughProperty("tSearch")]
	private SearchControl _tSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOrderType")]
	private ComboBox _cboOrderType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToOrdDt")]
	private MaskedTextBox _mToOrdDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromOrdDt")]
	private MaskedTextBox _mFromOrdDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKrAcCode")]
	private TextBox _tKrAcCode;

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
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

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
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private string CurRpt;

	private int DgvCurRow;

	private DataTable RsAcSum;

	private bool DgvAcEnter;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cMobile = 3;

	private const int cOrdNo = 4;

	private const int cOrdDate = 5;

	private const int cDelDate = 6;

	private const int cDesign = 7;

	private const int cSize = 8;

	private const int cItmDesc = 9;

	private const int cKrName = 10;

	private const int cOrnaRDt = 11;

	private const int cItName = 12;

	private const int cItmGwt = 13;

	private const int cItPcs = 14;

	private const int cOrdIsuKr = 15;

	private const int cOrdRecKr = 16;

	private const int cOrdSale = 17;

	private const int cOrdAmt = 18;

	private const int cOrdRecAmt = 19;

	private const int cOrdTouch = 20;

	private const int cOrdFine = 21;

	private const int cRecFine = 22;

	private const int cKrIsDate = 23;

	private const int cKrRcDate = 24;

	private const int cFunDate = 25;

	private const int cTagNo = 26;

	private const int cTagGwt = 27;

	private const int cTagNwt = 28;

	private const int cColor = 29;

	private const int cEmpName = 30;

	private const int cOrdYrcd = 31;

	private const int cOrdDbCd = 32;

	private const int cOrdSrNo = 33;

	private const int cOrdAdvAmt = 34;

	private const int cOrdGold = 35;

	private const int cOrdSilver = 36;

	private const int c2SrNo = 0;

	private const int c2BookName = 1;

	private const int c2VchNo = 2;

	private const int c2VchDate = 3;

	private const int c2AcName = 4;

	private const int c2AcArea = 5;

	private const int c2DrAmt = 6;

	private const int c2Cramt = 7;

	private const int c2BalAmt = 8;

	private const int c2CrDr = 9;

	private const int c2CoBook = 10;

	private const int c2AcCode = 11;

	private const int c2MainBook = 12;

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

	internal virtual DateEdit mToDt
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
			DateEdit val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mToDt = value;
			val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual DateEdit mFromDt
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
			DateEdit val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mFromDt = value;
			val2 = _mFromDt;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_AC_CellContentClick);
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV_AC;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).CellContentClick -= val2;
			}
			_DGV_AC = value;
			val3 = _DGV_AC;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).CellContentClick += val2;
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

	internal virtual SearchControl tSearch
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
			SearchControl val = _tSearch;
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

	internal virtual ComboBox cboOrderType
	{
		[CompilerGenerated]
		get
		{
			return _cboOrderType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboOrderType_KeyDown);
			ComboBox val2 = _cboOrderType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboOrderType = value;
			val2 = _cboOrderType;
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

	internal virtual MaskedTextBox mToOrdDt
	{
		[CompilerGenerated]
		get
		{
			return _mToOrdDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mToOrdDt_KeyDown);
			EventHandler eventHandler = mToOrdDt_GotFocus;
			MaskedTextBox val2 = _mToOrdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mToOrdDt = value;
			val2 = _mToOrdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mFromOrdDt
	{
		[CompilerGenerated]
		get
		{
			return _mFromOrdDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFromOrdDt_KeyDown);
			EventHandler eventHandler = mFromOrdDt_GotFocus;
			MaskedTextBox val2 = _mFromOrdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mFromOrdDt = value;
			val2 = _mFromOrdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual TextBox tKrAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tKrAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tKrAcCode_KeyDown);
			EventHandler eventHandler = tKrAcCode_TextChanged;
			TextBox val2 = _tKrAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tKrAcCode = value;
			val2 = _tKrAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKrAcName")]
	private virtual TextBox _tKrAcName;

	internal virtual TextBox tKrAcName
	{
		get
		{
			return _tKrAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tKrAcName = value;
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
	[AccessedThroughProperty("chkOrdTagStk")]
	private virtual CheckBox _chkOrdTagStk;

	internal virtual CheckBox chkOrdTagStk
	{
		get
		{
			return _chkOrdTagStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOrdTagStk = value;
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
	[AccessedThroughProperty("tDesignNo")]
	private virtual TextBox _tDesignNo;

	internal virtual TextBox tDesignNo
	{
		get
		{
			return _tDesignNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tDesignNo = value;
		}
	}

	public int newindex { get; set; }

	public RP_ORD_TRACK()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += RP_ORD_TRACK_Load;
		((Form)this).Activated += RP_ORD_TRACK_Activated;
		((Form)this).Deactivate += RP_ORD_TRACK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_ORD_TRACK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_ORD_TRACK_KeyDown);
		((Form)this).Closed += RP_ORD_TRACK_Closed;
		DgvCurRow = 0;
		DgvAcEnter = false;
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
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Expected O, but got Unknown
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Expected O, but got Unknown
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Expected O, but got Unknown
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Expected O, but got Unknown
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Expected O, but got Unknown
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Expected O, but got Unknown
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Expected O, but got Unknown
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3e: Expected O, but got Unknown
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Expected O, but got Unknown
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba9: Expected O, but got Unknown
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Expected O, but got Unknown
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Expected O, but got Unknown
		//IL_0db4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbe: Expected O, but got Unknown
		//IL_0e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e17: Expected O, but got Unknown
		//IL_0e3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e42: Expected O, but got Unknown
		//IL_0ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edf: Expected O, but got Unknown
		//IL_0f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f38: Expected O, but got Unknown
		//IL_0f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f63: Expected O, but got Unknown
		//IL_0faf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb9: Expected O, but got Unknown
		//IL_1087: Unknown result type (might be due to invalid IL or missing references)
		//IL_1091: Expected O, but got Unknown
		//IL_1126: Unknown result type (might be due to invalid IL or missing references)
		//IL_1130: Expected O, but got Unknown
		//IL_11ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b8: Expected O, but got Unknown
		//IL_129a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a4: Expected O, but got Unknown
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1317: Expected O, but got Unknown
		//IL_15f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fe: Expected O, but got Unknown
		//IL_16ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b6: Expected O, but got Unknown
		//IL_17df: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e9: Expected O, but got Unknown
		//IL_1894: Unknown result type (might be due to invalid IL or missing references)
		//IL_189e: Expected O, but got Unknown
		//IL_1919: Unknown result type (might be due to invalid IL or missing references)
		//IL_1923: Expected O, but got Unknown
		//IL_19a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b2: Expected O, but got Unknown
		//IL_1a60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6a: Expected O, but got Unknown
		//IL_1d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1deb: Expected O, but got Unknown
		//IL_1e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8f: Expected O, but got Unknown
		//IL_1f10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1a: Expected O, but got Unknown
		//IL_1fcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd5: Expected O, but got Unknown
		//IL_2056: Unknown result type (might be due to invalid IL or missing references)
		//IL_2060: Expected O, but got Unknown
		//IL_20e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ef: Expected O, but got Unknown
		//IL_218c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2196: Expected O, but got Unknown
		//IL_2244: Unknown result type (might be due to invalid IL or missing references)
		//IL_224e: Expected O, but got Unknown
		//IL_22e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f3: Expected O, but got Unknown
		//IL_23a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b3: Expected O, but got Unknown
		//IL_2430: Unknown result type (might be due to invalid IL or missing references)
		//IL_243a: Expected O, but got Unknown
		//IL_250a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2514: Expected O, but got Unknown
		//IL_25b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ba: Expected O, but got Unknown
		//IL_2640: Unknown result type (might be due to invalid IL or missing references)
		//IL_264a: Expected O, but got Unknown
		//IL_2731: Unknown result type (might be due to invalid IL or missing references)
		//IL_273b: Expected O, but got Unknown
		//IL_27a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ae: Expected O, but got Unknown
		//IL_2872: Unknown result type (might be due to invalid IL or missing references)
		//IL_287c: Expected O, but got Unknown
		//IL_28e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ee: Expected O, but got Unknown
		//IL_28f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f6: Expected O, but got Unknown
		//IL_297a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2984: Expected O, but got Unknown
		//IL_29f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f6: Expected O, but got Unknown
		//IL_29f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fe: Expected O, but got Unknown
		//IL_2ad4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ade: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_ORD_TRACK));
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
		mToDt = new DateEdit();
		mFromDt = new DateEdit();
		Label2 = new Label();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PnlAcSumm = new Panel();
		Label11 = new Label();
		tDesignNo = new TextBox();
		PicImage = new PictureBox();
		Label7 = new Label();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label5 = new Label();
		chkOrdTagStk = new CheckBox();
		btnOk = new QButton();
		tOrdNo = new TextBox();
		Label4 = new Label();
		tKrAcCode = new TextBox();
		tKrAcName = new TextBox();
		Label3 = new Label();
		Label1 = new Label();
		mToOrdDt = new MaskedTextBox();
		mFromOrdDt = new MaskedTextBox();
		cboOrderType = new ComboBox();
		Label6 = new Label();
		DGV_AC = new DevComponents.DotNetBar.Controls.DataGridViewX();
		tSerchAll = new SearchControl();
		tSearch = new SearchControl();
		PicZoom = new PictureBox();
		tLcCode = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mToDt.Properties).BeginInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mFromDt.Properties).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)DGV_AC).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)tSearch.Properties).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
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
		((Control)BtnExit).TabIndex = 7;
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
		((Control)BtnCancel).TabIndex = 5;
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
		((Control)BtnPrint).TabIndex = 3;
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
		lblBook.Text = "Order Traking Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(339, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(78, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(421, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(272, 23);
		((Control)tAcName).TabIndex = 1129;
		mToDt.EditValue = null;
		((Control)mToDt).Location = new Point(128, 45);
		((Control)mToDt).Name = "mToDt";
		((RepositoryItem)mToDt.Properties).Appearance.BackColor = Color.LightYellow;
		((RepositoryItem)mToDt.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)mToDt.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)mToDt.Properties).Appearance.Options.UseFont = true;
		((RepositoryItemButtonEdit)mToDt.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemButtonEdit)mToDt.Properties.CalendarTimeProperties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((Control)mToDt).Size = new Size(109, 22);
		((Control)mToDt).TabIndex = 2;
		mFromDt.EditValue = null;
		((Control)mFromDt).Location = new Point(14, 45);
		((Control)mFromDt).Name = "mFromDt";
		((RepositoryItem)mFromDt.Properties).Appearance.BackColor = Color.LightYellow;
		((RepositoryItem)mFromDt.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)mFromDt.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)mFromDt.Properties).Appearance.Options.UseFont = true;
		((RepositoryItemButtonEdit)mFromDt.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemButtonEdit)mFromDt.Properties.CalendarTimeProperties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((Control)mFromDt).Size = new Size(109, 22);
		((Control)mFromDt).TabIndex = 1;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(246, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Party Code";
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
		((DataGridView)DGV_DETL).BackgroundColor = Color.SeaShell;
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
		((Control)DGV_DETL).Location = new Point(13, 80);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
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
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label11);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tDesignNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)PicImage);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label7);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tEmpCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tEmpName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label5);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkOrdTagStk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)btnOk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tOrdNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label4);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tKrAcCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tKrAcName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mToOrdDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mFromOrdDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboOrderType);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label6);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSearch);
		((Control)PnlAcSumm).Location = new Point(0, 34);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 531);
		((Control)PnlAcSumm).TabIndex = 1134;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(420, 69);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(64, 20);
		((Control)Label11).TabIndex = 1185;
		Label11.Text = "Design";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tDesignNo).BackColor = Color.White;
		((Control)tDesignNo).Font = new Font("Tahoma", 9f);
		((Control)tDesignNo).Location = new Point(490, 70);
		((TextBoxBase)tDesignNo).MaxLength = 15;
		((Control)tDesignNo).Name = "tDesignNo";
		((Control)tDesignNo).Size = new Size(142, 22);
		((Control)tDesignNo).TabIndex = 1184;
		((Control)PicImage).BackColor = Color.LavenderBlush;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.Image = (Image)(object)Resources.longset;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(1057, 7);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(120, 85);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1177;
		PicImage.TabStop = false;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(10, 68);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(69, 20);
		((Control)Label7).TabIndex = 1176;
		Label7.Text = "Search";
		Label7.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(86, 39);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(76, 22);
		((Control)tEmpCode).TabIndex = 1173;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(165, 40);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(228, 22);
		((Control)tEmpName).TabIndex = 1175;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 38);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(69, 20);
		((Control)Label5).TabIndex = 1174;
		Label5.Text = "Employee";
		Label5.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkOrdTagStk).BackColor = Color.Transparent;
		((Control)chkOrdTagStk).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOrdTagStk).ForeColor = Color.Black;
		((Control)chkOrdTagStk).Location = new Point(643, 40);
		((Control)chkOrdTagStk).Name = "chkOrdTagStk";
		((Control)chkOrdTagStk).RightToLeft = (RightToLeft)0;
		((Control)chkOrdTagStk).Size = new Size(163, 20);
		((Control)chkOrdTagStk).TabIndex = 1172;
		((ButtonBase)chkOrdTagStk).Text = "Only Order Tag Stock";
		((ButtonBase)chkOrdTagStk).UseVisualStyleBackColor = false;
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
		((Control)btnOk).Location = new Point(885, 26);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(95, 37);
		((Control)btnOk).TabIndex = 1171;
		btnOk.Text = "&Ok";
		((TextBoxBase)tOrdNo).BackColor = Color.White;
		((Control)tOrdNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tOrdNo).Location = new Point(317, 11);
		((TextBoxBase)tOrdNo).MaxLength = 8;
		((Control)tOrdNo).Name = "tOrdNo";
		((Control)tOrdNo).Size = new Size(76, 23);
		((Control)tOrdNo).TabIndex = 1169;
		((Control)Label4).BackColor = SystemColors.ButtonHighlight;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(247, 11);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(64, 20);
		((Control)Label4).TabIndex = 1170;
		Label4.Text = "Ord No";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tKrAcCode).BackColor = Color.White;
		((Control)tKrAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tKrAcCode).Location = new Point(490, 10);
		((TextBoxBase)tKrAcCode).MaxLength = 8;
		((Control)tKrAcCode).Name = "tKrAcCode";
		((Control)tKrAcCode).Size = new Size(76, 23);
		((Control)tKrAcCode).TabIndex = 1166;
		((TextBoxBase)tKrAcName).BackColor = Color.White;
		((Control)tKrAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tKrAcName).Location = new Point(572, 10);
		((TextBoxBase)tKrAcName).MaxLength = 50;
		((Control)tKrAcName).Name = "tKrAcName";
		((Control)tKrAcName).Size = new Size(234, 23);
		((Control)tKrAcName).TabIndex = 1167;
		((Control)Label3).BackColor = SystemColors.ButtonHighlight;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(422, 12);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(62, 20);
		((Control)Label3).TabIndex = 1168;
		Label3.Text = "Kr Code";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(38, 12);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(44, 20);
		((Control)Label1).TabIndex = 1156;
		Label1.Text = "Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToOrdDt).BackColor = Color.White;
		((Control)mToOrdDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToOrdDt).Location = new Point(165, 9);
		mToOrdDt.Mask = "00/00/0000";
		((Control)mToOrdDt).Name = "mToOrdDt";
		((Control)mToOrdDt).Size = new Size(76, 23);
		((Control)mToOrdDt).TabIndex = 1155;
		mToOrdDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromOrdDt).BackColor = Color.White;
		((Control)mFromOrdDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromOrdDt).Location = new Point(86, 9);
		mFromOrdDt.Mask = "00/00/0000";
		((Control)mFromOrdDt).Name = "mFromOrdDt";
		((Control)mFromOrdDt).Size = new Size(76, 23);
		((Control)mFromOrdDt).TabIndex = 1154;
		mFromOrdDt.ValidatingType = typeof(DateTime);
		cboOrderType.AutoCompleteMode = (AutoCompleteMode)2;
		cboOrderType.AutoCompleteSource = (AutoCompleteSource)256;
		cboOrderType.BackColor = SystemColors.HighlightText;
		((Control)cboOrderType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboOrderType).FormattingEnabled = true;
		((Control)cboOrderType).Location = new Point(490, 39);
		cboOrderType.MaxLength = 5;
		((Control)cboOrderType).Name = "cboOrderType";
		((Control)cboOrderType).Size = new Size(142, 24);
		((Control)cboOrderType).TabIndex = 1152;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(398, 42);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(86, 20);
		((Control)Label6).TabIndex = 1153;
		Label6.Text = "Order Type";
		Label6.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_AC).AllowUserToAddRows = false;
		((DataGridView)DGV_AC).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AC).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_AC).BackgroundColor = Color.Snow;
		((DataGridView)DGV_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_AC).ColumnHeadersHeight = 30;
		((DataGridView)DGV_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).DefaultCellStyle = val8;
		((DataGridView)DGV_AC).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_AC).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_AC).Location = new Point(16, 98);
		((Control)DGV_AC).Name = "DGV_AC";
		DGV_AC.PaintEnhancedSelection = false;
		((DataGridView)DGV_AC).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AC).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_AC).RowHeadersVisible = false;
		((DataGridView)DGV_AC).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_AC).RowsDefaultCellStyle = val10;
		DGV_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_AC.SelectAllSignVisible = false;
		((DataGridView)DGV_AC).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_AC).Size = new Size(1162, 420);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((Control)tSerchAll).Location = new Point(251, 69);
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
		((Control)tSerchAll).Size = new Size(142, 24);
		((Control)tSerchAll).TabIndex = 1;
		((Control)tSearch).Location = new Point(86, 68);
		((Control)tSearch).Name = "tSearch";
		((RepositoryItem)tSearch.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSearch.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSearch.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSearch.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSearch.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((Control)tSearch).Size = new Size(158, 24);
		((Control)tSearch).TabIndex = 0;
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1202, 72);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(35, 20);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1148;
		PicZoom.TabStop = false;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1080, 6);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1177;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_ORD_TRACK";
		((Form)this).Text = "Order Track Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mToDt.Properties).EndInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mFromDt.Properties).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)DGV_AC).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)tSearch.Properties).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_DETL_FILL()
	{
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
					if ((uint)(columnIndex - 6) <= 2u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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

	private void AcSumm()
	{
		DgvAcEnter = false;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO) AS SrNo,A.AC_CODE,C.AC_NAME,C.AC_MOBILE,A.VCH_NO,A.VCH_DATE,A.ORD_DEL_DATE AS DEL_DATE,D.IT_NAME,A.DESIGN_NO,A.ITM_SIZE,A.ITM_REMARK,A.ITM_GWT,A.ITM_PCS,  A.DESIGN_ISU,F.AC_NAME AS KR_NAME,E.VCH_DATE AS KR_ISU_DT,TAG_GEN,G.VCH_DATE AS KR_REC_DT,G.TAG_NO,A.TAG_SALE,G.ITM_GWT As TAG_GWT,G.ITM_NWT As TAG_NWT,E.ORNA_REC_DATE,I.EMP_NAME,A.NET_AMT,A.ORD_REC_AMT,A.ITM_TOUCH,A.ITM_FINE,A.ITM_COLOR,B.FUN_DATE,A.CO_BOOK,A.CO_YEAR,B.ADV_AMT,B.OLD_GL,B.OLD_SL  FROM (((((((SL_ORD_DETL AS A LEFT JOIN SL_ORD_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO) LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE)  LEFT JOIN APR_DETL AS E ON A.CO_CODE = E.CO_CODE AND A.CO_YEAR = E.ISU_YRCD AND A.CO_BOOK = E.ISU_DBCD AND A.VCH_NO = E.ISU_NO AND A.SR_NO = E.ISU_SRNO)  LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)LEFT JOIN AC_MAST AS F ON E.CO_CODE = F.CO_CODE AND E.AC_CODE = F.AC_CODE)  LEFT JOIN BAR_DETL AS G ON A.CO_CODE = G.CO_CODE AND A.LC_CODE = G.LC_CODE AND A.CO_YEAR = G.ORD_YRCD AND A.CO_BOOK = G.ORD_DBCD AND A.VCH_NO = G.ORD_NO AND A.OLD_SRNO = G.ORD_SRNO)  LEFT JOIN BOOK_DATA AS H ON A.CO_CODE = H.CO_CODE AND A.LC_CODE = H.LC_CODE AND A.CO_BOOK = H.CO_BOOK)  LEFT JOIN EMP_MAST AS I ON A.CO_CODE = I.CO_CODE AND A.EMP_CODE = I.EMP_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tOrdNo.Text, "", false) == 0, (object)"", (object)("AND A.VCH_NO = '" + tOrdNo.Text + "'"))), Interaction.IIf(Operators.CompareString(tEmpCode.Text, "", false) == 0, (object)"", (object)("And B.EMP_CODE = '" + tEmpCode.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND H.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromOrdDt.Text), "MM/dd/yyyy")), (object)"' and A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToOrdDt.Text), "MM/dd/yyyy")), (object)"' "));
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + " And A.LC_CODE =  '" + tLcCode.Text + "'";
		}
		if (chkOrdTagStk.Checked)
		{
			DC_Main.RsQry += " And A.TAG_STK_LESS = 'Y' AND A.TAG_NO <> ''";
		}
		if (Operators.CompareString(tDesignNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + " And A.DESIGN_NO = '" + tDesignNo.Text + "' ";
		}
		if (Operators.CompareString(tKrAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + " And E.AC_CODE = '" + tKrAcCode.Text + "' ";
		}
		if (cboOrderType.SelectedIndex == 0)
		{
			DC_Main.RsQry += " And A.TAG_SALE = 'N' AND A.TAG_GEN = 'Y'";
		}
		else if (cboOrderType.SelectedIndex == 1)
		{
			DC_Main.RsQry += "AND A.DESIGN_ISU = 'N'";
		}
		else if (cboOrderType.SelectedIndex == 2)
		{
			DC_Main.RsQry += "AND A.TAG_GEN = 'N' AND A.DESIGN_ISU = 'Y'";
		}
		DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO ";
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).ClearSelection();
		((DataGridView)DGV_AC).Rows.Clear();
		((Control)DGV_AC).Refresh();
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
		//IL_146f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1479: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsAcSum);
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
				((DataGridView)DGV_AC).ColumnCount = 37;
				((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
				{
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Visible = false;
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Visible = false;
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
				}
				else
				{
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(170.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
				}
				((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(65.0 * ColCon);
				((DataGridView)DGV_AC).Columns[4].DataPropertyName = "VCH_NO";
				((DataGridView)DGV_AC).Columns[4].HeaderText = "OrdNo";
				((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV_AC).Columns[5].DataPropertyName = "VCH_DATE";
				((DataGridView)DGV_AC).Columns[5].HeaderText = "OrdDate";
				((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DEL_DATE";
				((DataGridView)DGV_AC).Columns[6].HeaderText = "DelDate";
				((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(95.0 * ColCon);
				((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DESIGN_NO";
				((DataGridView)DGV_AC).Columns[7].HeaderText = "Design";
				((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_AC).Columns[8].DataPropertyName = "ITM_SIZE";
				((DataGridView)DGV_AC).Columns[8].HeaderText = "Size";
				((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(135.0 * ColCon);
				((DataGridView)DGV_AC).Columns[9].DataPropertyName = "ITM_REMARK";
				((DataGridView)DGV_AC).Columns[9].HeaderText = "Remark";
				((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(130.0 * ColCon);
				((DataGridView)DGV_AC).Columns[10].DataPropertyName = "KR_NAME";
				((DataGridView)DGV_AC).Columns[10].HeaderText = "KrName";
				((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[11].DataPropertyName = "ORNA_REC_DATE";
				((DataGridView)DGV_AC).Columns[11].HeaderText = "OrnRecDt";
				((DataGridView)DGV_AC).Columns[12].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)DGV_AC).Columns[12].DataPropertyName = "IT_NAME";
				((DataGridView)DGV_AC).Columns[12].HeaderText = "ItName";
				((DataGridView)DGV_AC).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_AC).Columns[13].DataPropertyName = "ITM_GWT";
				((DataGridView)DGV_AC).Columns[13].HeaderText = "Grwt";
				((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[14].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[14].DataPropertyName = "ITM_PCS";
				((DataGridView)DGV_AC).Columns[14].HeaderText = "Pcs";
				((DataGridView)DGV_AC).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_AC).Columns[15].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[15].DataPropertyName = "DESIGN_ISU";
				((DataGridView)DGV_AC).Columns[15].HeaderText = "KIsu";
				((DataGridView)DGV_AC).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_AC).Columns[16].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_AC).Columns[16].DataPropertyName = "TAG_GEN";
				((DataGridView)DGV_AC).Columns[16].HeaderText = "KrRec";
				((DataGridView)DGV_AC).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_AC).Columns[17].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_AC).Columns[17].DataPropertyName = "TAG_SALE";
				((DataGridView)DGV_AC).Columns[17].HeaderText = "TagSl";
				((DataGridView)DGV_AC).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_AC).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_AC).Columns[18].DataPropertyName = "NET_AMT";
				((DataGridView)DGV_AC).Columns[18].HeaderText = "OrdAmt";
				((DataGridView)DGV_AC).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[18].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_AC).Columns[19].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_AC).Columns[19].DataPropertyName = "ORD_REC_AMT";
				((DataGridView)DGV_AC).Columns[19].HeaderText = "RecAmt";
				((DataGridView)DGV_AC).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[19].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_AC).Columns[20].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_AC).Columns[20].DataPropertyName = "ITM_TOUCH";
				((DataGridView)DGV_AC).Columns[20].HeaderText = "OrTch";
				((DataGridView)DGV_AC).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[20].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_AC).Columns[21].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_AC).Columns[21].DataPropertyName = "ITM_FINE";
				((DataGridView)DGV_AC).Columns[21].HeaderText = "OrdFine";
				((DataGridView)DGV_AC).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[21].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[22].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_AC).Columns[22].DataPropertyName = "";
				((DataGridView)DGV_AC).Columns[22].HeaderText = "RecFine";
				((DataGridView)DGV_AC).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[22].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[23].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[23].DataPropertyName = "KR_ISU_DT";
				((DataGridView)DGV_AC).Columns[23].HeaderText = "KrIsuDt";
				((DataGridView)DGV_AC).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_AC).Columns[24].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[24].DataPropertyName = "KR_REC_DT";
				((DataGridView)DGV_AC).Columns[24].HeaderText = "KrRecDt";
				((DataGridView)DGV_AC).Columns[25].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_AC).Columns[25].DataPropertyName = "FUN_DATE";
				((DataGridView)DGV_AC).Columns[25].HeaderText = "FunDate";
				((DataGridView)DGV_AC).Columns[26].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[26].DataPropertyName = "TAG_NO";
				((DataGridView)DGV_AC).Columns[26].HeaderText = "TagNo";
				((DataGridView)DGV_AC).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_AC).Columns[27].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[27].DataPropertyName = "TAG_GWT";
				((DataGridView)DGV_AC).Columns[27].HeaderText = "TGwt";
				((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[27].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[28].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[28].DataPropertyName = "TAG_NWT";
				((DataGridView)DGV_AC).Columns[28].HeaderText = "TNwt";
				((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[28].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[29].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[29].DataPropertyName = "ITM_COLOR";
				((DataGridView)DGV_AC).Columns[29].HeaderText = "Color";
				((DataGridView)DGV_AC).Columns[30].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)DGV_AC).Columns[30].DataPropertyName = "EMP_NAME";
				((DataGridView)DGV_AC).Columns[30].HeaderText = "EmpName";
				((DataGridView)DGV_AC).Columns[31].Visible = false;
				((DataGridView)DGV_AC).Columns[31].DataPropertyName = "CO_YEAR";
				((DataGridView)DGV_AC).Columns[31].HeaderText = "City";
				((DataGridView)DGV_AC).Columns[32].Visible = false;
				((DataGridView)DGV_AC).Columns[32].DataPropertyName = "CO_BOOK";
				((DataGridView)DGV_AC).Columns[32].HeaderText = "Address1";
				((DataGridView)DGV_AC).Columns[33].Visible = false;
				((DataGridView)DGV_AC).Columns[33].DataPropertyName = "SR_NO";
				((DataGridView)DGV_AC).Columns[33].HeaderText = "Address1";
				((DataGridView)DGV_AC).Columns[34].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[34].DataPropertyName = "ADV_AMT";
				((DataGridView)DGV_AC).Columns[34].HeaderText = "AdvAmt";
				((DataGridView)DGV_AC).Columns[34].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[34].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_AC).Columns[35].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[35].DataPropertyName = "OLD_GL";
				((DataGridView)DGV_AC).Columns[35].HeaderText = "AdvGodl";
				((DataGridView)DGV_AC).Columns[35].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[35].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[36].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_AC).Columns[36].DataPropertyName = "OLD_SL";
				((DataGridView)DGV_AC).Columns[36].HeaderText = "AdvSilver";
				((DataGridView)DGV_AC).Columns[36].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[36].DefaultCellStyle.Format = "N2";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV_AC).DataSource = dataView;
				if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					dataView.AddNew();
					dataView.AddNew();
				}
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = ((DataGridView)DGV_AC).Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
					{
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[13].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[18].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[19].Value, (object)""));
					}
				}
				int num5 = ((DataGridView)DGV_AC).Rows.Count - 1;
				((DataGridView)DGV_AC).Rows[num5].Cells[1].Value = "Total :";
				((DataGridView)DGV_AC).Rows[num5].Cells[13].Value = num;
				((DataGridView)DGV_AC).Rows[num5].Cells[18].Value = Math.Round(num2, 0);
				((DataGridView)DGV_AC).Rows[num5].Cells[19].Value = Math.Round(num3, 0);
			}
			if (DgvCurRow > 0)
			{
				((DataGridView)DGV_AC).Rows[DgvCurRow].Cells[1].Selected = true;
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
					if (columnIndex == 13 && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 85:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_008b;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 85;
				continue;
			}
			break;
			IL_008b:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void tSearch_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) == 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '" + ((TextEdit)tSearch).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(170.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "VCH_NO";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "OrdNo";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "VCH_DATE";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "OrdDate";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DEL_DATE";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "DelDate";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(130.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "KR_NAME";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "KrName";
					((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "ORNA_REC_DATE";
					((DataGridView)DGV_AC).Columns[11].HeaderText = "OrnRecDt";
					((DataGridView)DGV_AC).Columns[12].Width = (int)Math.Round(120.0 * ColCon);
					((DataGridView)DGV_AC).Columns[12].DataPropertyName = "IT_NAME";
					((DataGridView)DGV_AC).Columns[12].HeaderText = "ItName";
					((DataGridView)DGV_AC).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[13].DataPropertyName = "ITM_GWT";
					((DataGridView)DGV_AC).Columns[13].HeaderText = "Grwt";
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[14].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[14].DataPropertyName = "ITM_PCS";
					((DataGridView)DGV_AC).Columns[14].HeaderText = "Pcs";
					((DataGridView)DGV_AC).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[15].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[15].DataPropertyName = "DESIGN_ISU";
					((DataGridView)DGV_AC).Columns[15].HeaderText = "KIsu";
					((DataGridView)DGV_AC).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[16].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[16].DataPropertyName = "TAG_GEN";
					((DataGridView)DGV_AC).Columns[16].HeaderText = "KrRec";
					((DataGridView)DGV_AC).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[17].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[17].DataPropertyName = "TAG_SALE";
					((DataGridView)DGV_AC).Columns[17].HeaderText = "TagSl";
					((DataGridView)DGV_AC).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[18].DataPropertyName = "NET_AMT";
					((DataGridView)DGV_AC).Columns[18].HeaderText = "OrdAmt";
					((DataGridView)DGV_AC).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[18].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[19].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[19].DataPropertyName = "ORD_REC_AMT";
					((DataGridView)DGV_AC).Columns[19].HeaderText = "RecAmt";
					((DataGridView)DGV_AC).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[19].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[20].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[20].DataPropertyName = "ITM_TOUCH";
					((DataGridView)DGV_AC).Columns[20].HeaderText = "OrTch";
					((DataGridView)DGV_AC).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[20].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[21].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[21].DataPropertyName = "ITM_FINE";
					((DataGridView)DGV_AC).Columns[21].HeaderText = "OrdFine";
					((DataGridView)DGV_AC).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[21].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[22].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[22].DataPropertyName = "";
					((DataGridView)DGV_AC).Columns[22].HeaderText = "RecFine";
					((DataGridView)DGV_AC).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[22].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[23].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[23].DataPropertyName = "KR_ISU_DT";
					((DataGridView)DGV_AC).Columns[23].HeaderText = "KrIsuDt";
					((DataGridView)DGV_AC).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[24].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[24].DataPropertyName = "KR_REC_DT";
					((DataGridView)DGV_AC).Columns[24].HeaderText = "KrRecDt";
					((DataGridView)DGV_AC).Columns[25].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[25].DataPropertyName = "FUN_DATE";
					((DataGridView)DGV_AC).Columns[25].HeaderText = "FunDate";
					((DataGridView)DGV_AC).Columns[26].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[26].DataPropertyName = "TAG_NO";
					((DataGridView)DGV_AC).Columns[26].HeaderText = "TagNo";
					((DataGridView)DGV_AC).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[27].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[27].DataPropertyName = "TAG_GWT";
					((DataGridView)DGV_AC).Columns[27].HeaderText = "TGwt";
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[27].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[28].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[28].DataPropertyName = "TAG_NWT";
					((DataGridView)DGV_AC).Columns[28].HeaderText = "TNwt";
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[28].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DESIGN_NO";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "Design";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "ITM_SIZE";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "Size";
					((DataGridView)DGV_AC).Columns[29].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[29].DataPropertyName = "ITM_COLOR";
					((DataGridView)DGV_AC).Columns[29].HeaderText = "Color";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "ITM_REMARK";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "Remark";
					((DataGridView)DGV_AC).Columns[30].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV_AC).Columns[30].DataPropertyName = "EMP_NAME";
					((DataGridView)DGV_AC).Columns[30].HeaderText = "EmpName";
					((DataGridView)DGV_AC).Columns[31].Visible = false;
					((DataGridView)DGV_AC).Columns[31].DataPropertyName = "CO_YEAR";
					((DataGridView)DGV_AC).Columns[31].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[32].Visible = false;
					((DataGridView)DGV_AC).Columns[32].DataPropertyName = "CO_BOOK";
					((DataGridView)DGV_AC).Columns[32].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[33].Visible = false;
					((DataGridView)DGV_AC).Columns[33].DataPropertyName = "SR_NO";
					((DataGridView)DGV_AC).Columns[33].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[34].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[34].DataPropertyName = "ADV_AMT";
					((DataGridView)DGV_AC).Columns[34].HeaderText = "AdvAmt";
					((DataGridView)DGV_AC).Columns[34].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[34].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[35].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[35].DataPropertyName = "OLD_GL";
					((DataGridView)DGV_AC).Columns[35].HeaderText = "AdvGodl";
					((DataGridView)DGV_AC).Columns[35].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[35].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[36].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[36].DataPropertyName = "OLD_SL";
					((DataGridView)DGV_AC).Columns[36].HeaderText = "AdvSilver";
					((DataGridView)DGV_AC).Columns[36].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[36].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
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
				DataView dataView = new DataView(RsAcSum);
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
				{
					dataView.RowFilter = "DESIGN_NO Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";
				}
				else
				{
					dataView.RowFilter = "AC_NAME Like  '%" + ((TextEdit)tSerchAll).Text + "%' OR AC_MOBILE Like '%" + ((TextEdit)tSerchAll).Text + "%' ";
				}
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(170.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "VCH_NO";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "OrdNo";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "VCH_DATE";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "OrdDate";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DEL_DATE";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "DelDate";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(130.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "KR_NAME";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "KrName";
					((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "ORNA_REC_DATE";
					((DataGridView)DGV_AC).Columns[11].HeaderText = "OrnRecDt";
					((DataGridView)DGV_AC).Columns[12].Width = (int)Math.Round(120.0 * ColCon);
					((DataGridView)DGV_AC).Columns[12].DataPropertyName = "IT_NAME";
					((DataGridView)DGV_AC).Columns[12].HeaderText = "ItName";
					((DataGridView)DGV_AC).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[13].DataPropertyName = "ITM_GWT";
					((DataGridView)DGV_AC).Columns[13].HeaderText = "Grwt";
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[14].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[14].DataPropertyName = "ITM_PCS";
					((DataGridView)DGV_AC).Columns[14].HeaderText = "Pcs";
					((DataGridView)DGV_AC).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[15].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[15].DataPropertyName = "DESIGN_ISU";
					((DataGridView)DGV_AC).Columns[15].HeaderText = "KIsu";
					((DataGridView)DGV_AC).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[16].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[16].DataPropertyName = "TAG_GEN";
					((DataGridView)DGV_AC).Columns[16].HeaderText = "KrRec";
					((DataGridView)DGV_AC).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[17].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[17].DataPropertyName = "TAG_SALE";
					((DataGridView)DGV_AC).Columns[17].HeaderText = "TagSl";
					((DataGridView)DGV_AC).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[18].DataPropertyName = "NET_AMT";
					((DataGridView)DGV_AC).Columns[18].HeaderText = "OrdAmt";
					((DataGridView)DGV_AC).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[18].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[19].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_AC).Columns[19].DataPropertyName = "ORD_REC_AMT";
					((DataGridView)DGV_AC).Columns[19].HeaderText = "RecAmt";
					((DataGridView)DGV_AC).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[19].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[20].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[20].DataPropertyName = "ITM_TOUCH";
					((DataGridView)DGV_AC).Columns[20].HeaderText = "OrTch";
					((DataGridView)DGV_AC).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[20].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[21].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[21].DataPropertyName = "ITM_FINE";
					((DataGridView)DGV_AC).Columns[21].HeaderText = "OrdFine";
					((DataGridView)DGV_AC).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[21].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[22].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[22].DataPropertyName = "";
					((DataGridView)DGV_AC).Columns[22].HeaderText = "RecFine";
					((DataGridView)DGV_AC).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[22].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[23].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[23].DataPropertyName = "KR_ISU_DT";
					((DataGridView)DGV_AC).Columns[23].HeaderText = "KrIsuDt";
					((DataGridView)DGV_AC).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[24].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[24].DataPropertyName = "KR_REC_DT";
					((DataGridView)DGV_AC).Columns[24].HeaderText = "KrRecDt";
					((DataGridView)DGV_AC).Columns[25].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[25].DataPropertyName = "FUN_DATE";
					((DataGridView)DGV_AC).Columns[25].HeaderText = "FunDate";
					((DataGridView)DGV_AC).Columns[26].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[26].DataPropertyName = "TAG_NO";
					((DataGridView)DGV_AC).Columns[26].HeaderText = "TagNo";
					((DataGridView)DGV_AC).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
					((DataGridView)DGV_AC).Columns[27].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[27].DataPropertyName = "TAG_GWT";
					((DataGridView)DGV_AC).Columns[27].HeaderText = "TGwt";
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[27].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[28].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[28].DataPropertyName = "TAG_NWT";
					((DataGridView)DGV_AC).Columns[28].HeaderText = "TNwt";
					((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[28].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DESIGN_NO";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "Design";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "ITM_SIZE";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "Size";
					((DataGridView)DGV_AC).Columns[29].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[29].DataPropertyName = "ITM_COLOR";
					((DataGridView)DGV_AC).Columns[29].HeaderText = "Color";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "ITM_REMARK";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "Remark";
					((DataGridView)DGV_AC).Columns[30].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)DGV_AC).Columns[30].DataPropertyName = "EMP_NAME";
					((DataGridView)DGV_AC).Columns[30].HeaderText = "EmpName";
					((DataGridView)DGV_AC).Columns[31].Visible = false;
					((DataGridView)DGV_AC).Columns[31].DataPropertyName = "CO_YEAR";
					((DataGridView)DGV_AC).Columns[31].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[32].Visible = false;
					((DataGridView)DGV_AC).Columns[32].DataPropertyName = "CO_BOOK";
					((DataGridView)DGV_AC).Columns[32].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[33].Visible = false;
					((DataGridView)DGV_AC).Columns[33].DataPropertyName = "SR_NO";
					((DataGridView)DGV_AC).Columns[33].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[34].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[34].DataPropertyName = "ADV_AMT";
					((DataGridView)DGV_AC).Columns[34].HeaderText = "AdvAmt";
					((DataGridView)DGV_AC).Columns[34].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[34].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[35].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[35].DataPropertyName = "OLD_GL";
					((DataGridView)DGV_AC).Columns[35].HeaderText = "AdvGodl";
					((DataGridView)DGV_AC).Columns[35].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[35].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[36].Width = (int)Math.Round(75.0 * ColCon);
					((DataGridView)DGV_AC).Columns[36].DataPropertyName = "OLD_SL";
					((DataGridView)DGV_AC).Columns[36].HeaderText = "AdvSilver";
					((DataGridView)DGV_AC).Columns[36].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[36].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).DataSource = dataView;
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
		Worksheet worksheet = default(Worksheet);
		int num6 = default(int);
		Application application = default(Application);
		object value = default(object);
		Workbook workbook = default(Workbook);
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
					case 1155:
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
								goto IL_0050;
							case 7:
								goto IL_0059;
							case 8:
								goto IL_0062;
							case 9:
								goto IL_0078;
							case 10:
								goto IL_0093;
							case 11:
								goto IL_00b4;
							case 12:
								goto IL_00cb;
							case 13:
								goto IL_0101;
							case 14:
								goto IL_0110;
							case 15:
								goto IL_012d;
							case 16:
								goto IL_0144;
							case 17:
								goto IL_0167;
							case 18:
							case 19:
								goto IL_01aa;
							case 20:
								goto IL_01b9;
							case 21:
								goto IL_01d4;
							case 22:
								goto IL_01de;
							case 23:
								goto IL_022e;
							case 24:
								goto IL_0280;
							case 25:
								goto IL_02d5;
							case 26:
								goto IL_0340;
							case 27:
								goto IL_0355;
							case 28:
								goto IL_0365;
							case 29:
								goto IL_037a;
							case 30:
								goto IL_03ab;
							case 31:
								goto IL_03b6;
							case 32:
								goto IL_03c4;
							case 33:
								goto IL_03ca;
							case 34:
								goto IL_03d0;
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
						IL_01aa:
						num2 = 19;
						num5++;
						goto IL_01b3;
						IL_00cb:
						num2 = 12;
						worksheet.Cells[1, num6 + 1] = ((DataGridView)DGV_AC).Columns[num6].HeaderText;
						goto IL_0101;
						IL_0167:
						num2 = 17;
						worksheet.Cells[DC_Main.i + 2, num5 + 1] = ((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString();
						goto IL_01aa;
						IL_0101:
						num2 = 13;
						num6++;
						goto IL_010a;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						application = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
						goto IL_0050;
						IL_0050:
						num2 = 6;
						value = Missing.Value;
						goto IL_0059;
						IL_0059:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0062;
						IL_0062:
						num2 = 8;
						workbook = application.Workbooks.Add(RuntimeHelpers.GetObjectValue(value));
						goto IL_0078;
						IL_0078:
						num2 = 9;
						worksheet = (Worksheet)workbook.Sheets["sheet1"];
						goto IL_0093;
						IL_0093:
						num2 = 10;
						worksheet.Cells[1, 1] = "Sheet 1 content";
						goto IL_00b4;
						IL_00b4:
						num2 = 11;
						num7 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num6 = 0;
						goto IL_010a;
						IL_010a:
						if (num6 <= num7)
						{
							goto IL_00cb;
						}
						goto IL_0110;
						IL_0110:
						num2 = 14;
						num8 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_01c8;
						IL_01c8:
						if (DC_Main.i <= num8)
						{
							goto IL_012d;
						}
						goto IL_01d4;
						IL_01d4:
						num2 = 21;
						colorConverter = new ColorConverter();
						goto IL_01de;
						IL_01de:
						num2 = 22;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(worksheet.Rows["1:1", RuntimeHelpers.GetObjectValue(Missing.Value)], (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_022e;
						IL_022e:
						num2 = 23;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(worksheet.Rows["1:1", RuntimeHelpers.GetObjectValue(Missing.Value)], (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0280;
						IL_0280:
						num2 = 24;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(worksheet.Rows["1:1", RuntimeHelpers.GetObjectValue(Missing.Value)], (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_02d5;
						IL_02d5:
						num2 = 25;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(worksheet.Rows["1:1", RuntimeHelpers.GetObjectValue(Missing.Value)], (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0340;
						IL_0340:
						num2 = 26;
						worksheet.Cells.Columns.AutoFit();
						goto IL_0355;
						IL_0355:
						num2 = 27;
						worksheet.Cells.Select();
						goto IL_0365;
						IL_0365:
						num2 = 28;
						worksheet.Cells.EntireColumn.AutoFit();
						goto IL_037a;
						IL_037a:
						num2 = 29;
						NewLateBinding.LateCall(worksheet.Cells[1, 1], (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_03ab;
						IL_03ab:
						num2 = 30;
						application.Visible = true;
						goto IL_03b6;
						IL_03b6:
						num2 = 31;
						Cursor.Current = Cursors.Default;
						goto IL_03c4;
						IL_03c4:
						num2 = 32;
						worksheet = null;
						goto IL_03ca;
						IL_03ca:
						num2 = 33;
						workbook = null;
						goto IL_03d0;
						IL_03d0:
						num2 = 34;
						application = null;
						break;
						IL_012d:
						num2 = 15;
						num9 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_01b3;
						IL_01b3:
						if (num5 <= num9)
						{
							goto IL_0144;
						}
						goto IL_01b9;
						IL_01b9:
						num2 = 20;
						DC_Main.i++;
						goto IL_01c8;
						IL_0144:
						num2 = 16;
						if (((DataGridView)DGV_AC)[num5, DC_Main.i].Value != null)
						{
							goto IL_0167;
						}
						goto IL_01aa;
						end_IL_0001_2:
						break;
					}
					num2 = 35;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1155;
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

	private void RP_ORD_TRACK_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Expected O, but got Unknown
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b27: Expected O, but got Unknown
		//IL_0bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected O, but got Unknown
		//IL_0c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c79: Expected O, but got Unknown
		//IL_0ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Expected O, but got Unknown
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Expected O, but got Unknown
		//IL_0dd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de5: Expected O, but got Unknown
		//IL_0e04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e13: Expected O, but got Unknown
		//IL_0e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea4: Expected O, but got Unknown
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed2: Expected O, but got Unknown
		//IL_0ef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Expected O, but got Unknown
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
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC2 = DGV_AC;
				object? obj12 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj14 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC3 = DGV_AC;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj22 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj23 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tKrAcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tKrAcCode).Font;
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
				num3 = (int)Math.Ceiling((double)((Control)tKrAcCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tKrAcCode).Font;
				try
				{
					foreach (object control5 in ((Control)PnlAcSumm).Controls)
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
					((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).Font.Style);
					((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).Font.Style);
					((DataGridView)DGV_AC).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_AC).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_AC).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_AC).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
				}
			}
			cboOrderType.Items.Add((object)"Sal Panding");
			cboOrderType.Items.Add((object)"Isu Panding");
			cboOrderType.Items.Add((object)"Rec Panding");
			cboOrderType.Items.Add((object)"All");
			cboOrderType.SelectedIndex = 0;
			CLEAR_DATA();
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
			{
				((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Design Search";
			}
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
			}
			CurActCtrl = (Control)(object)mFromOrdDt;
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
		((TextEdit)mFromDt).Text = "01/01/2010";
		mToDt.EditValue = DC_Main.MsSysDate;
		mFromOrdDt.Text = "01/01/2010";
		mToOrdDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		tLcCode.Text = DC_Main.MLc_code;
		AcSumm();
		((Control)mFromOrdDt).Focus();
	}

	private void RP_ORD_TRACK_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((Control)DGV_DETL).Refresh();
			BtnExit.Text = "&Exit";
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_ORD_TRACK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_ORD_TRACK_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_ORD_TRACK_KeyDown(object sender, KeyEventArgs e)
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
			((Control)DGV_DETL).Focus();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		double num = 0.0;
		DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedger.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Ledr Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd") + ") ";
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

	private void RP_ORD_TRACK_Closed(object sender, EventArgs e)
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
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
					DGV_DETL_FILL();
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_DETL_FILL();
			((Control)tAcCode).Focus();
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
	}

	private void mFromDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
			DGV_DETL_FILL();
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
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdAmt.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd") + ") ";
		Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";
		Cr[(short)4] = ("ClBal = " + Strings.Format((object)num2, "0.00")) ?? "";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void cboOrderType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			AcSumm();
		}
	}

	private void tKrAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tKrAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tKrAcCode.Text + "'";
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
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tKrAcCode.Text = DC_Main.ColValue[1];
						tKrAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tKrAcCode).Focus();
					((TextBoxBase)tKrAcCode).SelectAll();
				}
			}
			else
			{
				tKrAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				AcSumm();
			}
		}
		else
		{
			tKrAcName.Text = "";
			AcSumm();
		}
	}

	private void tOrdNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tOrdNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_NO = '" + tOrdNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.ADV_AMT As OrdAmtR,SUM(CASE WHEN ORD_SIGN = '-' THEN ORD_AMT ELSE 0 END) As AdjAmtR FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON   A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.VCH_DESC,A.ADV_AMT  ORDER BY A.VCH_DATE,A.VCH_NO";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[7];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 120.0;
				DC_Main.ColWidth[2] = 300.0;
				DC_Main.ColWidth[3] = 250.0;
				DC_Main.ColWidth[4] = 100.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.HelpSelect = 0;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose && !DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						tOrdNo.Text = DC_Main.ColValue[0];
						((TextBoxBase)tOrdNo).SelectAll();
					}
					else
					{
						tOrdNo.Text = "";
					}
				}
			}
			else
			{
				((TextBoxBase)tOrdNo).SelectAll();
				AcSumm();
			}
		}
		else
		{
			AcSumm();
		}
	}

	private void mFromOrdDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mFromOrdDt;
			DC_Main.SetDate(ref MsDate);
			mFromOrdDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToOrdDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToOrdDt;
			DC_Main.SetDate(ref MsDate);
			mToOrdDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mFromOrdDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromOrdDt).SelectionStart = 0;
		((TextBoxBase)mFromOrdDt).SelectionLength = Strings.Len(mFromOrdDt.Text);
	}

	private void mToOrdDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToOrdDt).SelectionStart = 0;
		((TextBoxBase)mToOrdDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		AcSumm();
	}

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
		{
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
					((Control)tEmpCode).Focus();
				}
			}
			else
			{
				tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
				((Control)btnOk).Focus();
			}
		}
		else
		{
			tEmpName.Text = "";
			((Control)btnOk).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DGV_AC_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		string text = default(string);
		HttpWebRequest httpWebRequest = default(HttpWebRequest);
		int num5 = default(int);
		double num6 = default(double);
		Image image = default(Image);
		DataTable dataTable = default(DataTable);
		object obj = default(object);
		byte[] bA = default(byte[]);
		object objectValue = default(object);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				WebResponse response;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					PicImage.Image = null;
					goto IL_0011;
				case 1629:
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
							goto IL_0011;
						case 4:
							goto IL_002c;
						case 5:
							goto IL_0050;
						case 6:
							goto IL_005f;
						case 7:
							goto IL_0093;
						case 8:
							goto IL_00f5;
						case 9:
							goto IL_0106;
						case 10:
							goto IL_0121;
						case 11:
						case 12:
							goto IL_0151;
						case 13:
							goto IL_0192;
						case 14:
							goto IL_019f;
						case 16:
							goto IL_01e9;
						case 17:
							goto IL_0213;
						case 19:
							goto IL_029f;
						case 18:
						case 20:
						case 21:
							goto IL_02ad;
						case 22:
							goto IL_02ba;
						case 15:
						case 23:
						case 24:
							goto IL_02fe;
						case 25:
							goto IL_0321;
						case 26:
							goto IL_0349;
						case 28:
							goto IL_0361;
						case 29:
							goto IL_03bb;
						case 30:
							goto IL_03c9;
						case 31:
							goto IL_03e3;
						case 32:
							goto IL_0417;
						case 34:
							goto IL_042c;
						case 35:
							goto IL_0451;
						case 36:
							goto IL_0462;
						case 37:
							goto IL_0473;
						case 39:
							goto IL_0490;
						case 40:
							goto IL_04af;
						case 41:
							goto IL_04b8;
						case 42:
							goto IL_04d4;
						case 44:
							goto IL_0518;
						case 43:
						case 45:
						case 46:
							goto IL_0532;
						case 47:
							goto IL_0543;
						case 48:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 3:
						case 27:
						case 33:
						case 38:
						case 49:
						case 50:
						case 51:
						case 52:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0518:
					num2 = 44;
					text = DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg";
					goto IL_0532;
					IL_0532:
					num2 = 46;
					httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
					goto IL_0543;
					IL_04d4:
					num2 = 42;
					text = DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
					goto IL_0532;
					IL_0543:
					num2 = 47;
					response = httpWebRequest.GetResponse();
					break;
					IL_0011:
					num2 = 2;
					if (((DataGridView)DGV_AC).CurrentRow == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_002c;
					IL_002c:
					num2 = 4;
					num5 = checked((int)Math.Round(Conversion.Val((object)((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index)));
					goto IL_0050;
					IL_0050:
					num2 = 5;
					PicImage.Image = null;
					goto IL_005f;
					IL_005f:
					num2 = 6;
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC)[26, num5].Value, (object)""), (object)"", false))
					{
						goto IL_0093;
					}
					goto IL_01e9;
					IL_0093:
					num2 = 7;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), ((DataGridView)DGV_AC)[26, num5].Value), (object)"' AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE ORDER BY B.VCH_DATE DESC"));
					goto IL_00f5;
					IL_00f5:
					num2 = 8;
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0106;
					IL_0106:
					num2 = 9;
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						goto IL_0121;
					}
					goto IL_0151;
					IL_0121:
					num2 = 10;
					num6 = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["VCH_SRNO"], (object)""));
					goto IL_0151;
					IL_0151:
					num2 = 12;
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_AC)[26, num5].Value, (object)"_"), (object)num6), (object)""));
					goto IL_0192;
					IL_0192:
					num2 = 13;
					DC_Main.MsImageType = "TagImage";
					goto IL_019f;
					IL_019f:
					num2 = 14;
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					goto IL_02fe;
					IL_01e9:
					num2 = 16;
					if (Operators.ConditionalCompareObjectNotEqual(((DataGridView)DGV_AC)[7, num5].Value, (object)"", false))
					{
						goto IL_0213;
					}
					goto IL_029f;
					IL_0213:
					num2 = 17;
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_AC)[7, num5].Value, (object)"_"), (object)DC_Main.MCo_code), (object)DC_Main.MLc_code), ((DataGridView)DGV_AC)[31, num5].Value), ((DataGridView)DGV_AC)[32, num5].Value), ((DataGridView)DGV_AC)[4, num5].Value));
					goto IL_02ad;
					IL_029f:
					num2 = 19;
					DC_Main.MsImageNo = "";
					goto IL_02ad;
					IL_02ad:
					num2 = 21;
					DC_Main.MsImageType = "TagImage";
					goto IL_02ba;
					IL_02ba:
					num2 = 22;
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					goto IL_02fe;
					IL_02fe:
					num2 = 24;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						goto IL_0321;
					}
					goto IL_0361;
					IL_0321:
					num2 = 25;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					goto IL_0349;
					IL_0349:
					num2 = 26;
					PicImage.Image = image;
					goto end_IL_0001_3;
					IL_0361:
					num2 = 28;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_AC)[26, num5].Value), (object)"' AND VCH_SRNO = "), (object)num6), (object)""));
					goto IL_03bb;
					IL_03bb:
					num2 = 29;
					dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					goto IL_03c9;
					IL_03c9:
					num2 = 30;
					if (dataTable.Rows.Count > 0)
					{
						goto IL_03e3;
					}
					goto IL_0490;
					IL_03e3:
					num2 = 31;
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						goto IL_0417;
					}
					goto IL_042c;
					IL_0417:
					num2 = 32;
					PicImage.Image = null;
					goto end_IL_0001_3;
					IL_042c:
					num2 = 34;
					obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
					goto IL_0451;
					IL_0451:
					num2 = 35;
					bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
					goto IL_0462;
					IL_0462:
					num2 = 36;
					objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
					goto IL_0473;
					IL_0473:
					num2 = 37;
					PicImage.Image = (Image)objectValue;
					goto end_IL_0001_3;
					IL_0490:
					num2 = 39;
					if (Operators.CompareString(DC_Main.MsHttpPath, "", false) == 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_04af;
					IL_04af:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_04b8;
					IL_04b8:
					num2 = 41;
					if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
					{
						goto IL_04d4;
					}
					goto IL_0518;
					end_IL_0001_2:
					break;
				}
				num2 = 48;
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(text)));
				break;
				end_IL_0001:;
			}
			catch (object obj2) when (obj2 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj2);
				try0001_dispatch = 1629;
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
		DGV_CLEAR();
		AcSumm();
		((TextBoxBase)tLcCode).SelectAll();
		((Control)tLcCode).Focus();
	}

	private void tKrAcCode_TextChanged(object sender, EventArgs e)
	{
	}
}
