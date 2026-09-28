using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_GST : Form
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
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSectionType")]
	private ComboBox _cboSectionType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGstr1")]
	private SimpleButton _BtnGstr1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGst3Zoom")]
	private QButton _BtnGst3Zoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGst2Zoom")]
	private QButton _BtnGst2Zoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGst1Zoom")]
	private QButton _BtnGst1Zoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCsvFile")]
	private SimpleButton _BtnCsvFile;

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
	[AccessedThroughProperty("btnGstrCsv")]
	private SimpleButton _btnGstrCsv;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string CurFormula;

	private const int c1 = 0;

	private const int c2 = 1;

	private const int c3 = 2;

	private const int c4 = 3;

	private const int c5 = 4;

	private const int c6 = 5;

	private const int c7 = 6;

	private const int c8 = 7;

	private const int c9 = 8;

	private const int c10 = 9;

	private const int c11 = 10;

	private const int c12 = 11;

	private const int c13 = 12;

	private const int c14 = 13;

	private const int c15 = 14;

	private const int cSrNo = 15;

	private const int cAcCode = 16;

	private const int cBookName = 17;

	private const int cBookCode = 18;

	private bool bExportingAll;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dlgOpen")]
	private virtual FolderBrowserDialog _dlgOpen;

	internal virtual FolderBrowserDialog dlgOpen
	{
		get
		{
			return _dlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_dlgOpen = value;
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
	[AccessedThroughProperty("tBookName")]
	private virtual TextBox _tBookName;

	internal virtual TextBox tBookName
	{
		get
		{
			return _tBookName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBookName = value;
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

	internal virtual ComboBox cboSectionType
	{
		[CompilerGenerated]
		get
		{
			return _cboSectionType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboSectionType_KeyDown);
			ComboBox val2 = _cboSectionType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboSectionType = value;
			val2 = _cboSectionType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("tLcName")]
	private virtual TextBox _tLcName;

	internal virtual TextBox tLcName
	{
		get
		{
			return _tLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLcName = value;
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

	internal virtual SimpleButton BtnGstr1
	{
		[CompilerGenerated]
		get
		{
			return _BtnGstr1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGstr1_Click;
			SimpleButton val = _BtnGstr1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGstr1 = value;
			val = _BtnGstr1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnGst3Zoom
	{
		[CompilerGenerated]
		get
		{
			return _BtnGst3Zoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGst3Zoom_Click;
			QButton val = _BtnGst3Zoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGst3Zoom = value;
			val = _BtnGst3Zoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnGst2Zoom
	{
		[CompilerGenerated]
		get
		{
			return _BtnGst2Zoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGst2Zoom_Click;
			QButton val = _BtnGst2Zoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGst2Zoom = value;
			val = _BtnGst2Zoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnGst1Zoom
	{
		[CompilerGenerated]
		get
		{
			return _BtnGst1Zoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGst1Zoom_Click;
			QButton val = _BtnGst1Zoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGst1Zoom = value;
			val = _BtnGst1Zoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnCsvFile
	{
		[CompilerGenerated]
		get
		{
			return _BtnCsvFile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCsvFile_Click;
			SimpleButton val = _BtnCsvFile;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCsvFile = value;
			val = _BtnCsvFile;
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
	[AccessedThroughProperty("MSG_VCH")]
	private virtual AxMSFlexGrid _MSG_VCH;

	internal virtual AxMSFlexGrid MSG_VCH
	{
		get
		{
			return _MSG_VCH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_VCH = value;
		}
	}

	internal virtual SimpleButton btnGstrCsv
	{
		[CompilerGenerated]
		get
		{
			return _btnGstrCsv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnGstrCsv_Click;
			SimpleButton val = _btnGstrCsv;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnGstrCsv = value;
			val = _btnGstrCsv;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public RP_GST()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_GST_Load;
		((Form)this).Deactivate += RP_GST_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_GST_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_GST_KeyDown);
		((Form)this).Closed += RP_GST_Closed;
		bExportingAll = false;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Expected O, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Expected O, but got Unknown
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0785: Expected O, but got Unknown
		//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f2: Expected O, but got Unknown
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Expected O, but got Unknown
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Expected O, but got Unknown
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Expected O, but got Unknown
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Expected O, but got Unknown
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b17: Expected O, but got Unknown
		//IL_0b85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8f: Expected O, but got Unknown
		//IL_0c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Expected O, but got Unknown
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Expected O, but got Unknown
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d60: Expected O, but got Unknown
		//IL_0e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1b: Expected O, but got Unknown
		//IL_0ec9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed3: Expected O, but got Unknown
		//IL_0f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5a: Expected O, but got Unknown
		//IL_0fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe9: Expected O, but got Unknown
		//IL_10c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ce: Expected O, but got Unknown
		//IL_1148: Unknown result type (might be due to invalid IL or missing references)
		//IL_1152: Expected O, but got Unknown
		//IL_1200: Unknown result type (might be due to invalid IL or missing references)
		//IL_120a: Expected O, but got Unknown
		//IL_1287: Unknown result type (might be due to invalid IL or missing references)
		//IL_1291: Expected O, but got Unknown
		//IL_1315: Unknown result type (might be due to invalid IL or missing references)
		//IL_131f: Expected O, but got Unknown
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_1629: Unknown result type (might be due to invalid IL or missing references)
		//IL_1652: Unknown result type (might be due to invalid IL or missing references)
		//IL_165c: Expected O, but got Unknown
		//IL_167f: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1906: Unknown result type (might be due to invalid IL or missing references)
		//IL_192a: Unknown result type (might be due to invalid IL or missing references)
		//IL_194e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1977: Unknown result type (might be due to invalid IL or missing references)
		//IL_1981: Expected O, but got Unknown
		//IL_19a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca6: Expected O, but got Unknown
		//IL_1cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d46: Expected O, but got Unknown
		//IL_1dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de8: Expected O, but got Unknown
		//IL_1e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8d: Expected O, but got Unknown
		//IL_1f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5e: Expected O, but got Unknown
		//IL_1fa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fad: Expected O, but got Unknown
		//IL_2010: Unknown result type (might be due to invalid IL or missing references)
		//IL_201a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_GST));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnGstr1 = new SimpleButton();
		BtnCsvFile = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label1 = new Label();
		Label2 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label3 = new Label();
		cboSectionType = new ComboBox();
		lblCity = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		BtnGst3Zoom = new QButton();
		BtnGst2Zoom = new QButton();
		BtnGst1Zoom = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label4 = new Label();
		MSG_VCH = new AxMSFlexGrid();
		btnGstrCsv = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG_VCH).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnGstr1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCsvFile);
		((Control)PnlBotam).Controls.Add((Control)(object)btnGstrCsv);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 9;
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
		((Control)BtnDelete).TabIndex = 4;
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
		((Control)BtnCancel).TabIndex = 3;
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
		((Control)BtnSave).TabIndex = 2;
		BtnSave.Text = "Gstr 3";
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
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "Gstr 2";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnGstr1).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnGstr1).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnGstr1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnGstr1).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnGstr1.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnGstr1.ImageOptions.SvgImage");
		((Control)BtnGstr1).Location = new Point(730, 3);
		((BaseControl)BtnGstr1).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnGstr1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnGstr1).Name = "BtnGstr1";
		((Control)BtnGstr1).Size = new Size(91, 37);
		((Control)BtnGstr1).TabIndex = 0;
		BtnGstr1.Text = "Gstr 1";
		((BaseButton)BtnGstr1).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCsvFile).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCsvFile).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCsvFile).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCsvFile).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnCsvFile.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnCsvFile.ImageOptions.SvgImage");
		((Control)BtnCsvFile).Location = new Point(633, 3);
		((BaseControl)BtnCsvFile).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCsvFile).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCsvFile).Name = "BtnCsvFile";
		((Control)BtnCsvFile).Size = new Size(91, 37);
		((Control)BtnCsvFile).TabIndex = 6;
		BtnCsvFile.Text = "Csv Fil";
		((BaseButton)BtnCsvFile).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1246, 507);
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
		lblBook.Text = "Gst Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(442, 42);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(65, 23);
		((Control)tBookCode).TabIndex = 3;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(514, 41);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(250, 23);
		((Control)tBookName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(386, 41);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(48, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Book";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 43);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "From  Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(441, 76);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(66, 23);
		((Control)tAcCode).TabIndex = 4;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(514, 76);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(250, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(360, 77);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(75, 20);
		((Control)Label3).TabIndex = 1165;
		Label3.Text = "Party Code";
		Label3.TextAlign = (ContentAlignment)64;
		cboSectionType.AutoCompleteMode = (AutoCompleteMode)3;
		cboSectionType.AutoCompleteSource = (AutoCompleteSource)256;
		cboSectionType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboSectionType).Font = new Font("Tahoma", 9f);
		((ListControl)cboSectionType).FormattingEnabled = true;
		((Control)cboSectionType).Location = new Point(120, 75);
		((Control)cboSectionType).Name = "cboSectionType";
		((Control)cboSectionType).Size = new Size(226, 22);
		((Control)cboSectionType).TabIndex = 2;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(12, 75);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(102, 19);
		((Control)lblCity).TabIndex = 1166;
		lblCity.Text = "Section Type";
		lblCity.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(840, 42);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(56, 23);
		((Control)tLcCode).TabIndex = 5;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(902, 42);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(204, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(774, 42);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "Lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((QControl)BtnGst3Zoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGst3Zoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGst3Zoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGst3Zoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGst3Zoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst3Zoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst3Zoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst3Zoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst3Zoom.Image = null;
		((QControl)BtnGst3Zoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGst3Zoom).Location = new Point(438, 114);
		((Control)BtnGst3Zoom).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGst3Zoom).Name = "BtnGst3Zoom";
		((Control)BtnGst3Zoom).Size = new Size(143, 37);
		((Control)BtnGst3Zoom).TabIndex = 8;
		BtnGst3Zoom.Text = "Gstr 3";
		((QControl)BtnGst2Zoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGst2Zoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGst2Zoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGst2Zoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGst2Zoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst2Zoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst2Zoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst2Zoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst2Zoom.Image = null;
		((QControl)BtnGst2Zoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGst2Zoom).Location = new Point(280, 114);
		((Control)BtnGst2Zoom).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGst2Zoom).Name = "BtnGst2Zoom";
		((Control)BtnGst2Zoom).Size = new Size(143, 37);
		((Control)BtnGst2Zoom).TabIndex = 7;
		BtnGst2Zoom.Text = "Gstr 2";
		((QControl)BtnGst1Zoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGst1Zoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGst1Zoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGst1Zoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGst1Zoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst1Zoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst1Zoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst1Zoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGst1Zoom.Image = null;
		((QControl)BtnGst1Zoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGst1Zoom).Location = new Point(121, 114);
		((Control)BtnGst1Zoom).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGst1Zoom).Name = "BtnGst1Zoom";
		((Control)BtnGst1Zoom).Size = new Size(143, 37);
		((Control)BtnGst1Zoom).TabIndex = 6;
		BtnGst1Zoom.Text = "Gstr 1";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(120, 43);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 1178;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(270, 42);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1179;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(202, 44);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(62, 20);
		((Control)Label4).TabIndex = 1180;
		Label4.Text = "To Date";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)MSG_VCH).Location = new Point(11, 147);
		((Control)MSG_VCH).Name = "MSG_VCH";
		((AxHost)MSG_VCH).OcxState = (State)componentResourceManager.GetObject("MSG_VCH.OcxState");
		((Control)MSG_VCH).Size = new Size(1160, 406);
		((Control)MSG_VCH).TabIndex = 1181;
		((BaseStyleControl)btnGstrCsv).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnGstrCsv).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnGstrCsv).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnGstrCsv).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnGstrCsv.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SimpleButton1.ImageOptions.SvgImage");
		((Control)btnGstrCsv).Location = new Point(504, 3);
		((BaseControl)btnGstrCsv).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnGstrCsv).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnGstrCsv).Name = "btnGstrCsv";
		((Control)btnGstrCsv).Size = new Size(123, 37);
		((Control)btnGstrCsv).TabIndex = 7;
		btnGstrCsv.Text = "Gsrt1 Csv";
		((BaseButton)btnGstrCsv).ToolTipAnchor = (ToolTipAnchor)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)MSG_VCH);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)BtnGst1Zoom);
		((Control)this).Controls.Add((Control)(object)BtnGst2Zoom);
		((Control)this).Controls.Add((Control)(object)BtnGst3Zoom);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)cboSectionType);
		((Control)this).Controls.Add((Control)(object)lblCity);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_GST";
		((Form)this).Text = "Gst Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG_VCH).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_GST_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Expected O, but got Unknown
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Expected O, but got Unknown
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_099f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Expected O, but got Unknown
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Expected O, but got Unknown
		//IL_0ad3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Expected O, but got Unknown
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
				ComboBox obj7 = cboSectionType;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				obj7.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG_VCH = MSG_VCH;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_VCH.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG_VCH2 = MSG_VCH;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG_VCH2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_VCH3 = MSG_VCH;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_VCH3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj12 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				ComboBox obj13 = cboSectionType;
				object? obj14 = colorConverter.ConvertFromString("233, 235, 240");
				obj13.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_VCH4 = MSG_VCH;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_VCH4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_VCH5 = MSG_VCH;
				object? obj16 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_VCH5.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_VCH6 = MSG_VCH;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_VCH6.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj18 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj19 = lblBook;
				object? obj20 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj19).ForeColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj21 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				cboSectionType.BackColor = Color.Cornsilk;
				AxMSFlexGrid mSG_VCH7 = MSG_VCH;
				object? obj22 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_VCH7.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_VCH8 = MSG_VCH;
				object? obj23 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_VCH8.BackColorBkg = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_VCH9 = MSG_VCH;
				object? obj24 = colorConverter.ConvertFromString("Cornsilk");
				mSG_VCH9.BackColorFixed = ((obj24 != null) ? ((Color)obj24) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
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
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling((double)MSG_VCH.Font.Size * (1.0 + num2));
					MSG_VCH.Font = new Font("Segoe UI Semibold", (float)num3, MSG_VCH.Font.Style);
				}
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				cboSectionType.Items.Add((object)"");
				cboSectionType.Items.Add((object)"With Tax");
				cboSectionType.Items.Add((object)"Whout Tax");
				cboSectionType.SelectedIndex = 0;
				BtnGst1Zoom.Text = "Sale Tax";
				BtnGst2Zoom.Text = "Purc Tax";
				((Control)BtnGst3Zoom).Visible = false;
				((Control)BtnCsvFile).Visible = false;
				((Control)BtnSave).Visible = false;
				BtnGstr1.Text = "Sales";
				BtnPrint.Text = "Purc";
			}
			else
			{
				cboSectionType.Items.Add((object)"");
				cboSectionType.Items.Add((object)"B2B - Bill to Bill");
				cboSectionType.Items.Add((object)"B2CL - B2C Large");
				cboSectionType.Items.Add((object)"B2CS - B2C Small");
				cboSectionType.Items.Add((object)"CDNR - Credit/Debit Note");
				cboSectionType.Items.Add((object)"CDNUR - Credit/Debit Note Unregistered");
				cboSectionType.Items.Add((object)"EXP - Export");
				cboSectionType.Items.Add((object)"AT - Tax liability on Advances");
				cboSectionType.Items.Add((object)"ATADJ - Advance Adjustments");
				cboSectionType.Items.Add((object)"EXEMP - Intra-State Supp to Unreg persons");
				cboSectionType.Items.Add((object)"HSN - Summary For HSN");
				cboSectionType.Items.Add((object)"DOCS - Summary Of Issue Rec Bill");
				cboSectionType.SelectedIndex = 0;
			}
			CLEAR_DATA();
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
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0)
		{
			((Control)Label6).Visible = false;
			((Control)tLcCode).Visible = false;
			((Control)tLcName).Visible = false;
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
		{
			((Control)BtnCsvFile).Visible = false;
			((Control)BtnGstr1).Visible = false;
			((Control)BtnPrint).Visible = false;
			((Control)BtnSave).Visible = false;
			((Control)MSG_VCH).Visible = false;
		}
		cboSectionType.SelectedIndex = 0;
		DGV_CLEAR();
		mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
		mToDt.Text = Conversions.ToString(DateTime.Now);
		((Control)mFromDt).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_GST_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_GST_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_GST_KeyDown(object sender, KeyEventArgs e)
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
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PrTaxRpt.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\Gstr_2.RPT";
			}
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {TAX_DATA.TRAN_TYPE} = 'P'";
		CurFormula += " And {BOOK_DATA.BOOK_TYPE} = 'T'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'YEAR : " + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + " / MONTH : " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "'";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				DC_Main.RptName = "PrTaxRpt";
			}
			else
			{
				DC_Main.RptName = "Gstr_2";
			}
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'YEAR : " + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + " / MONTH : " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_GST_Closed(object sender, EventArgs e)
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
						tBookName.Text = DC_Main.ColValue[0];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
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
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.AC_NAME";
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
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
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
					tLcName.Text = DC_Main.ColValue[1];
				}
			}
			else
			{
				tLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboSectionType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnGstr1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SlTaxRpt.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\Gstr_1.RPT";
			}
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {TAX_DATA.TRAN_TYPE} = 'S'";
		CurFormula += " And {BOOK_DATA.BOOK_TYPE} = 'T'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
		{
			if (cboSectionType.SelectedIndex == 1)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For B2B(4)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For B2B(4)'";
				}
				CurFormula += " AND {AC_MAST.AC_GSTNO} <> '' AND {TAX_DATA.BOOK_NAME} IN ['SALES','LABOUR WORK','SERVICE INC','E INVOICE']";
			}
			else if (cboSectionType.SelectedIndex == 2)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For B2CL(5)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For B2CL(5)'";
				}
				CurFormula += " AND {AC_MAST.AC_GSTNO} = '' AND {TAX_DATA.BOOK_NAME} IN ['SALES','LABOUR WORK','SERVICE INC','E INVOICE'] AND {TAX_DATA.TOT_AMT} >= 250000";
			}
			else if (cboSectionType.SelectedIndex == 3)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For B2CS(7)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For B2CS(7)'";
				}
				CurFormula += " AND {AC_MAST.AC_GSTNO} = '' AND {TAX_DATA.BOOK_NAME} IN ['SALES','LABOUR WORK','SERVICE INC','E INVOICE'] AND {TAX_DATA.TOT_AMT} < 250000";
			}
			else if (cboSectionType.SelectedIndex == 4)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For CDNR(9B)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For B2CS(7)'";
				}
				CurFormula += " AND {AC_MAST.AC_GSTNO} <> '' AND {TAX_DATA.BOOK_NAME} IN ['SALES RETURNE','PURC RETURN'] ";
			}
			else if (cboSectionType.SelectedIndex == 5)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For CDNR(9B)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For CDNR(9B)'";
				}
				CurFormula += " AND {AC_MAST.AC_GSTNO} = '' AND {TAX_DATA.BOOK_NAME} IN ['SALES RETURNE','PURC RETURN'] ";
			}
			else if (cboSectionType.SelectedIndex == 6)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For EXP(6)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For EXP(6)'";
				}
				CurFormula += " AND {TAX_DATA.BOOK_NAME} IN ['EXPORT']";
			}
			else if (cboSectionType.SelectedIndex == 7)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)1] = "SectionType = 'Summary For Advance Adjust(11B)'";
				}
				else
				{
					DC_Main.MsCrForName1 = "SectionType";
					DC_Main.MsCrForStr1 = "'Summary For Advance Adjust(11B)'";
				}
				CurFormula += " AND {TAX_DATA.BOOK_NAME} IN ['ORD ADJUST']";
			}
			else if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr[(short)1] = "SectionType = 'Gstr 1 Total Entry'";
			}
			else
			{
				DC_Main.MsCrForName1 = "SectionType";
				DC_Main.MsCrForStr1 = "'Gstr 1 Total Entry'";
			}
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'YEAR : " + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + " / MONTH : " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "'";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				DC_Main.RptName = "SlTaxRpt";
			}
			else
			{
				DC_Main.RptName = "Gstr_1";
			}
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'YEAR : " + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + " / MONTH : " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\GSTR_3.RPT";
		}
		CurFormula = "{TAX_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAX_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAX_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {TAX_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {BOOK_DATA.BOOK_TYPE} = 'T'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {TAX_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'YEAR : " + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + " / MONTH : " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "'";
			DC_Main.RptName = "GSTR_3";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'YEAR : " + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + " / MONTH : " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void DGV_CLEAR()
	{
		checked
		{
			if (cboSectionType.SelectedIndex != 0)
			{
				AxMSFlexGrid mSG_VCH = MSG_VCH;
				mSG_VCH.Clear();
				mSG_VCH.Cols = 19;
				mSG_VCH.Rows = 5;
				mSG_VCH[0] = 325;
				mSG_VCH[15] = 0;
				mSG_VCH[0] = 0;
				mSG_VCH[1] = 0;
				mSG_VCH[2] = 0;
				mSG_VCH[3] = 0;
				mSG_VCH[4] = 0;
				mSG_VCH[5] = 0;
				mSG_VCH[6] = 0;
				mSG_VCH[7] = 0;
				mSG_VCH[8] = 0;
				mSG_VCH[9] = 0;
				mSG_VCH[10] = 0;
				mSG_VCH[11] = 0;
				mSG_VCH[12] = 0;
				mSG_VCH[13] = 0;
				mSG_VCH[14] = 0;
				mSG_VCH[17] = 0;
				mSG_VCH[16] = 0;
				mSG_VCH[18] = 0;
				switch (cboSectionType.SelectedIndex)
				{
				case 1:
					mSG_VCH[0, 15] = Conversions.ToString(1);
					mSG_VCH[0, 0] = "Summary For B2B(4)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "No. of Recipients";
					mSG_VCH[1, 2] = "No. of Invoices";
					mSG_VCH[1, 4] = "Total Invoice Val";
					mSG_VCH[1, 11] = "Total Taxable Val";
					mSG_VCH[1, 12] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = Conversions.ToString(4);
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2100.0 * ColCon);
					mSG_VCH[3, 0] = "GSTIN/UIN";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 1] = "Receiver Name";
					mSG_VCH[2] = 0;
					mSG_VCH[2] = (int)Math.Round(1400.0 * ColCon);
					mSG_VCH[3, 2] = "Invoice No";
					mSG_VCH[3] = 0;
					mSG_VCH[3] = (int)Math.Round(1300.0 * ColCon);
					mSG_VCH[3, 3] = "Invoice Date";
					mSG_VCH[4] = 7;
					mSG_VCH[4] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 4] = "Invoice Value";
					mSG_VCH[5] = 0;
					mSG_VCH[5] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 5] = "Plase Of Supply";
					mSG_VCH[6] = 0;
					mSG_VCH[6] = (int)Math.Round(900.0 * ColCon);
					mSG_VCH[3, 6] = "R Charg";
					mSG_VCH[7] = 0;
					mSG_VCH[7] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 7] = "App% Rate";
					mSG_VCH[8] = 0;
					mSG_VCH[8] = (int)Math.Round(1300.0 * ColCon);
					mSG_VCH[3, 8] = "Invoice Type";
					mSG_VCH[9] = 0;
					mSG_VCH[9] = (int)Math.Round(1500.0 * ColCon);
					mSG_VCH[3, 9] = "E-Com GSTIN";
					mSG_VCH[10] = 7;
					mSG_VCH[10] = (int)Math.Round(1000.0 * ColCon);
					mSG_VCH[3, 10] = "Rate";
					mSG_VCH[11] = 7;
					mSG_VCH[11] = (int)Math.Round(1700.0 * ColCon);
					mSG_VCH[3, 11] = "Taxable Value";
					mSG_VCH[12] = 7;
					mSG_VCH[12] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 12] = "Cess Amt";
					break;
				case 2:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For B2CL(5)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "No. of Invoices";
					mSG_VCH[1, 2] = "Total Invoice Val";
					mSG_VCH[1, 6] = "Total Taxable Val";
					mSG_VCH[1, 7] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2100.0 * ColCon);
					mSG_VCH[3, 0] = "Invoice No";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(1400.0 * ColCon);
					mSG_VCH[3, 1] = "Invoice Date";
					mSG_VCH[2] = 7;
					mSG_VCH[2] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 2] = "Invoice Value";
					mSG_VCH[3] = 0;
					mSG_VCH[3] = (int)Math.Round(2200.0 * ColCon);
					mSG_VCH[3, 3] = "Plase Of Supply";
					mSG_VCH[4] = 0;
					mSG_VCH[4] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 4] = "App% Rate";
					mSG_VCH[5] = 7;
					mSG_VCH[5] = (int)Math.Round(1000.0 * ColCon);
					mSG_VCH[3, 5] = "Rate";
					mSG_VCH[6] = 7;
					mSG_VCH[6] = (int)Math.Round(1700.0 * ColCon);
					mSG_VCH[3, 6] = "Taxable Value";
					mSG_VCH[7] = 7;
					mSG_VCH[7] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 7] = "Cess Amt";
					mSG_VCH[8] = 0;
					mSG_VCH[8] = (int)Math.Round(1500.0 * ColCon);
					mSG_VCH[3, 8] = "E-Com GSTIN";
					break;
				case 3:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 1] = "Summary For B2CS(7)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "";
					mSG_VCH[1, 4] = "Total Taxable Val";
					mSG_VCH[1, 5] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2100.0 * ColCon);
					mSG_VCH[3, 0] = "Type";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 1] = "Plase Of Supply";
					mSG_VCH[2] = 0;
					mSG_VCH[2] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 2] = "App% Rate";
					mSG_VCH[3] = 7;
					mSG_VCH[3] = (int)Math.Round(1000.0 * ColCon);
					mSG_VCH[3, 3] = "Rate";
					mSG_VCH[4] = 7;
					mSG_VCH[4] = (int)Math.Round(1700.0 * ColCon);
					mSG_VCH[3, 4] = "Taxable Value";
					mSG_VCH[5] = 7;
					mSG_VCH[5] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 5] = "Cess Amt";
					mSG_VCH[6] = 0;
					mSG_VCH[6] = (int)Math.Round(1500.0 * ColCon);
					mSG_VCH[3, 6] = "E-Com GSTIN";
					break;
				case 4:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For CDNR(9B)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "No. of Recipients";
					mSG_VCH[1, 2] = "No. of Invoices";
					mSG_VCH[1, 4] = "No.of Notes/Vch";
					mSG_VCH[1, 8] = "Refund Vch Val";
					mSG_VCH[1, 11] = "Total Taxable Val";
					mSG_VCH[1, 12] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2400.0 * ColCon);
					mSG_VCH[3, 0] = "GSTIN/UIN";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 1] = "Receiver Name";
					mSG_VCH[2] = 0;
					mSG_VCH[2] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 2] = "Invoice/Advanc RecNo";
					mSG_VCH[3] = 0;
					mSG_VCH[3] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 3] = "Invoice/Advanc RecDate";
					mSG_VCH[4] = 0;
					mSG_VCH[4] = (int)Math.Round(1500.0 * ColCon);
					mSG_VCH[3, 4] = "Refund VchNo";
					mSG_VCH[5] = 0;
					mSG_VCH[5] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 5] = "Refund VchDate";
					mSG_VCH[6] = 0;
					mSG_VCH[6] = (int)Math.Round(800.0 * ColCon);
					mSG_VCH[3, 6] = "Dc Type";
					mSG_VCH[7] = 0;
					mSG_VCH[7] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 7] = "Plase Of Supply";
					mSG_VCH[8] = 7;
					mSG_VCH[8] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 8] = "Note Refund Val";
					mSG_VCH[9] = 0;
					mSG_VCH[9] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 9] = "App% Rate";
					mSG_VCH[10] = 7;
					mSG_VCH[10] = (int)Math.Round(1000.0 * ColCon);
					mSG_VCH[3, 10] = "Rate";
					mSG_VCH[11] = 7;
					mSG_VCH[11] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 11] = "Taxable Value";
					mSG_VCH[12] = 7;
					mSG_VCH[12] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 12] = "Cess Amt";
					mSG_VCH[13] = 3;
					mSG_VCH[13] = (int)Math.Round(1100.0 * ColCon);
					mSG_VCH[3, 13] = "Pre Gst";
					break;
				case 5:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For CDNUR(9B)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 1] = "No.of Notes/Vch";
					mSG_VCH[1, 4] = "No. of Invoices";
					mSG_VCH[1, 7] = "Refund Vch Val";
					mSG_VCH[1, 10] = "Total Taxable Val";
					mSG_VCH[1, 11] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2200.0 * ColCon);
					mSG_VCH[3, 0] = "UR Type";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 1] = "Refund VchNo";
					mSG_VCH[2] = 0;
					mSG_VCH[2] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 2] = "Refund VchDate";
					mSG_VCH[3] = 0;
					mSG_VCH[3] = (int)Math.Round(900.0 * ColCon);
					mSG_VCH[3, 3] = "Dc Type";
					mSG_VCH[4] = 0;
					mSG_VCH[4] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 4] = "Invoice/Advanc RecNo";
					mSG_VCH[5] = 0;
					mSG_VCH[5] = (int)Math.Round(2300.0 * ColCon);
					mSG_VCH[3, 5] = "Invoice/Advanc RecDate";
					mSG_VCH[6] = 0;
					mSG_VCH[6] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 6] = "Plase Of Supply";
					mSG_VCH[7] = 7;
					mSG_VCH[7] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 7] = "Note Refund Val";
					mSG_VCH[8] = 0;
					mSG_VCH[8] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 8] = "App% Rate";
					mSG_VCH[9] = 7;
					mSG_VCH[9] = (int)Math.Round(1000.0 * ColCon);
					mSG_VCH[3, 9] = "Rate";
					mSG_VCH[10] = 7;
					mSG_VCH[10] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 10] = "Taxable Value";
					mSG_VCH[11] = 7;
					mSG_VCH[11] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 11] = "Cess Amt";
					mSG_VCH[12] = 3;
					mSG_VCH[12] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 12] = "Pre Gst";
					break;
				case 6:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For Exp(6)";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2000.0 * ColCon);
					break;
				case 7:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For Advance(11B)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "";
					mSG_VCH[1, 3] = "Total Advance Rec";
					mSG_VCH[1, 4] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2800.0 * ColCon);
					mSG_VCH[3, 0] = "Plase Of Supply";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 1] = "App% Rate";
					mSG_VCH[2] = 7;
					mSG_VCH[2] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 2] = "Rate";
					mSG_VCH[3] = 7;
					mSG_VCH[3] = (int)Math.Round(2400.0 * ColCon);
					mSG_VCH[3, 3] = "Gross Advance Rec";
					mSG_VCH[4] = 7;
					mSG_VCH[4] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 4] = "Cess Amt";
					break;
				case 8:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For Adv Adjust(11B)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "";
					mSG_VCH[1, 3] = "Total Advance Adjusted";
					mSG_VCH[1, 4] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(3100.0 * ColCon);
					mSG_VCH[3, 0] = "Plase Of Supply";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 1] = "App% Rate";
					mSG_VCH[2] = 7;
					mSG_VCH[2] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 2] = "Rate";
					mSG_VCH[3] = 7;
					mSG_VCH[3] = (int)Math.Round(2500.0 * ColCon);
					mSG_VCH[3, 3] = "Gross Advance Adj";
					mSG_VCH[4] = 7;
					mSG_VCH[4] = (int)Math.Round(1500.0 * ColCon);
					mSG_VCH[3, 4] = "Cess Amt";
					break;
				case 9:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For Nill Rated,Exmp and Non Gst outword(8)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "";
					mSG_VCH[1, 1] = "Total Nil Rated Supplies";
					mSG_VCH[1, 2] = "Total Exempted Supplies";
					mSG_VCH[1, 3] = "Total Non-Gst Supplies";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(5200.0 * ColCon);
					mSG_VCH[3, 0] = "Descripition";
					mSG_VCH[1] = 7;
					mSG_VCH[1] = (int)Math.Round(2400.0 * ColCon);
					mSG_VCH[3, 1] = "Nil Rated Supply";
					mSG_VCH[2] = 7;
					mSG_VCH[2] = (int)Math.Round(3000.0 * ColCon);
					mSG_VCH[3, 2] = "Exmp and Non Gst Supply";
					mSG_VCH[3] = 7;
					mSG_VCH[3] = (int)Math.Round(2400.0 * ColCon);
					mSG_VCH[3, 3] = "Non Gst Supply";
					break;
				case 10:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary For HSN(12)";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 0] = "No.of HSN";
					mSG_VCH[1, 4] = "Total Value";
					mSG_VCH[1, 5] = "Total Taxable Val";
					mSG_VCH[1, 6] = "Total IGST Tax";
					mSG_VCH[1, 7] = "Total CGST Tax";
					mSG_VCH[1, 8] = "Total SGST Tax";
					mSG_VCH[1, 9] = "Total Cess";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(2200.0 * ColCon);
					mSG_VCH[3, 0] = "HSN";
					mSG_VCH[1] = 0;
					mSG_VCH[1] = (int)Math.Round(1800.0 * ColCon);
					mSG_VCH[3, 1] = "Descripition";
					mSG_VCH[2] = 0;
					mSG_VCH[2] = (int)Math.Round(1400.0 * ColCon);
					mSG_VCH[3, 2] = "UQC";
					mSG_VCH[3] = 7;
					mSG_VCH[3] = (int)Math.Round(1500.0 * ColCon);
					mSG_VCH[3, 3] = "Total Qty";
					mSG_VCH[4] = 7;
					mSG_VCH[4] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 4] = "Total Value";
					mSG_VCH[5] = 7;
					mSG_VCH[5] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 5] = "Taxable Value";
					mSG_VCH[6] = 7;
					mSG_VCH[6] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 6] = "IGST Amount";
					mSG_VCH[7] = 7;
					mSG_VCH[7] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 7] = "CGST Amount";
					mSG_VCH[8] = 7;
					mSG_VCH[8] = (int)Math.Round(1600.0 * ColCon);
					mSG_VCH[3, 8] = "SGST Amount";
					mSG_VCH[9] = 7;
					mSG_VCH[9] = (int)Math.Round(1200.0 * ColCon);
					mSG_VCH[3, 9] = "Total Cess";
					break;
				case 11:
					mSG_VCH[0, 15] = "1";
					mSG_VCH[0, 0] = "Summary of Doc. issued The Tax Period";
					mSG_VCH[1, 15] = Conversions.ToString(2);
					mSG_VCH[1, 3] = "Total Number";
					mSG_VCH[1, 4] = "Total Cancelled";
					mSG_VCH[2, 15] = Conversions.ToString(3);
					mSG_VCH.Row = 3;
					mSG_VCH[3, 15] = "4";
					mSG_VCH[0] = 0;
					mSG_VCH[0] = (int)Math.Round(4000.0 * ColCon);
					mSG_VCH[3, 0] = "Nature Of Document";
					mSG_VCH[1] = 7;
					mSG_VCH[1] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 1] = "Sr. No From";
					mSG_VCH[2] = 7;
					mSG_VCH[2] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 2] = "Sr. No To";
					mSG_VCH[3] = 7;
					mSG_VCH[3] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 3] = "Total Number";
					mSG_VCH[4] = 7;
					mSG_VCH[4] = (int)Math.Round(2000.0 * ColCon);
					mSG_VCH[3, 4] = "Cancelled";
					break;
				}
				mSG_VCH.Row = 3;
				int num = mSG_VCH.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					mSG_VCH.Col = DC_Main.M;
					mSG_VCH.CellBackColor = Color.Moccasin;
					mSG_VCH.CellForeColor = Color.Blue;
					DC_Main.M++;
				}
				mSG_VCH = null;
			}
		}
	}

	private void BtnGst1Zoom_Click(object sender, EventArgs e)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b23: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			BtnGstr1_Click(BtnGstr1, new EventArgs());
			return;
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
		{
			BtnGstr1_Click(BtnGstr1, new EventArgs());
			return;
		}
		DGV_CLEAR();
		if (cboSectionType.SelectedIndex == 0)
		{
			Interaction.MsgBox((object)"Please Select Section Type And Try...", (MsgBoxStyle)0, (object)null);
			((Control)cboSectionType).Focus();
			return;
		}
		switch (cboSectionType.SelectedIndex)
		{
		case 1:
		case 2:
			DC_Main.RsQry = "SELECT A.CO_BOOK,B.AC_NAME,A.BOOK_NAME,A.AC_CODE,B.AC_GSTNO,E.BOOK_SR_NAME,A.VCH_NO,A.VCH_DATE,A.TOT_AMT,C.STATE_CODE,C.STATE_NAME,A.R_CHARG,D.TAX_PRC As TaxPrc,A.NET_AMT,A.DISC_AMT from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0 ";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			if (cboSectionType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND B.AC_GSTNO <> '' AND A.BOOK_NAME IN ('SALES','LABOUR WORK','SERVICE INC','E INVOICE')";
			}
			else if (cboSectionType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND B.AC_GSTNO = '' AND A.BOOK_NAME IN ('SALES','LABOUR WORK','SERVICE INC','E INVOICE') AND A.TOT_AMT >= 250000";
			}
			DC_Main.RsQry += " GROUP BY A.CO_BOOK,B.AC_NAME,A.BOOK_NAME,A.AC_CODE,B.AC_GSTNO,E.BOOK_SR_NAME,A.VCH_NO,A.VCH_DATE,A.TOT_AMT,C.STATE_CODE,C.STATE_NAME,A.R_CHARG,D.TAX_PRC,A.NET_AMT,A.DISC_AMT";
			DC_Main.RsQry += " ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
			break;
		case 3:
			DC_Main.RsQry = " SELECT C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC As TaxPrc,Sum(A.NET_AMT-A.DISC_AMT) As NetAmt from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			DC_Main.RsQry += "AND B.AC_GSTNO = '' AND A.BOOK_NAME IN ('SALES','LABOUR WORK','SERVICE INC','E INVOICE') AND A.SR_NO IN (1,3,10,30) AND A.TOT_AMT < 250000";
			DC_Main.RsQry += " GROUP BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
			DC_Main.RsQry += " ORDER BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
			break;
		case 4:
		case 5:
			DC_Main.RsQry = " SELECT A.CO_BOOK,B.AC_NAME,C.BOOK_SR_NAME As BillBook,B.AC_GSTNO,A.BILL_NO,A.BILL_DATE,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,E.BOOK_SR_NAME,F.STATE_CODE,F.STATE_NAME,D.TAX_PRC As TaxPrc,A.NET_AMT,A.TOT_AMT from ((((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.BILL_DBCD = C.CO_BOOK)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK)  LEFT JOIN STATE_MAST AS F ON B.AC_STATE = F.STATE_NAME WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			if (cboSectionType.SelectedIndex == 5)
			{
				DC_Main.RsQry += "AND B.AC_GSTNO = '' AND A.BOOK_NAME IN ('SALES RETURNE','PURC RETURN') ";
			}
			else
			{
				DC_Main.RsQry += "AND B.AC_GSTNO <> '' AND A.BOOK_NAME IN ('SALES RETURNE','PURC RETURN') ";
			}
			DC_Main.RsQry += " GROUP BY A.CO_BOOK,B.AC_NAME,C.BOOK_SR_NAME,B.AC_GSTNO,A.BILL_NO,A.BILL_DATE,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,E.BOOK_SR_NAME,F.STATE_CODE,F.STATE_NAME,D.TAX_PRC,A.NET_AMT,A.TOT_AMT";
			DC_Main.RsQry += " ORDER BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE";
			break;
		case 6:
			return;
		case 7:
			DC_Main.RsQry = " SELECT C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC As TaxPrc,Sum(A.NET_AMT) As NetAmt from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			DC_Main.RsQry += " AND A.BOOK_NAME IN ('SALES ORDER') AND A.SR_NO IN (1,3) ";
			DC_Main.RsQry += " GROUP BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
			DC_Main.RsQry += " ORDER BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
			break;
		case 8:
			DC_Main.RsQry = " SELECT C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC As TaxPrc,Sum(A.NET_AMT) As NetAmt from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'  AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			DC_Main.RsQry += " AND A.BOOK_NAME IN ('ORD ADJUST') AND A.SR_NO IN (11,13,21,23,31,33,41,43,51,53) ";
			DC_Main.RsQry += " GROUP BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
			DC_Main.RsQry += " ORDER BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
			break;
		case 9:
			return;
		case 10:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(" SELECT B.HSN_CODE,B.RATE_TYPE,B.IT_TYPE As ItType,D.AC_GST_TYPE As TAX_TYPE,  CASE WHEN B.RATE_TYPE = 'P' THEN SUM(A.ITM_PCS) ELSE SUM(A.ITM_NWT) END As ItmNwt,SUM(NET_AMT)As ItmAmt,SUM(IT_TAX_AMT)As ItmTax,SUM(IT_DISC_AMT)As ItmDisc from ((SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)  LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND C.BOOK_TYPE = 'T' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND C.MAIN_BOOK IN ('SALES','LABOUR WORK','SERVICE INC','E INVOICE') GROUP BY B.HSN_CODE,B.RATE_TYPE,B.IT_TYPE,D.AC_GST_TYPE "), (object)" UNION ALL SELECT F.HSN_CODE,F.RATE_TYPE,F.IT_TYPE,G.AC_GST_TYPE, "), (object)" CASE WHEN F.RATE_TYPE = 'P' THEN SUM(-E.ITM_PCS) ELSE SUM(-E.ITM_NWT) END As ItmNwt,SUM(-E.NET_AMT)As ItmAmt,SUM(-E.RTN_IT_TAX_AMT)As ItmTax,0 As ItmDisc from ((SL_DETL_RTN AS E LEFT JOIN ITEM_MAST AS F ON E.CO_CODE = F.CO_CODE AND E.IT_CODE = F.IT_CODE) "), (object)" LEFT JOIN BOOK_DATA AS H ON E.CO_CODE = H.CO_CODE AND E.LC_CODE = H.LC_CODE AND E.CO_BOOK = H.CO_BOOK)LEFT JOIN AC_MAST AS G ON E.CO_CODE = G.CO_CODE AND E.AC_CODE = G.AC_CODE WHERE E.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND E.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND E.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND H.BOOK_TYPE = 'T' AND E.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  AND E.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY F.HSN_CODE,F.RATE_TYPE,F.IT_TYPE,G.AC_GST_TYPE "), (object)" UNION ALL SELECT I.HSN_CODE,I.RATE_TYPE,I.IT_TYPE As ItType,J.AC_GST_TYPE As TAX_TYPE, "), (object)" CASE WHEN I.RATE_TYPE = 'P' THEN SUM(-K.ITM_PCS) ELSE SUM(-K.ITM_NWT) END As ItmNwt,SUM(-K.NET_AMT)As ItmAmt,SUM(-K.IT_TAX_AMT)As ItmTax,SUM(-K.IT_DISC_AMT)As ItmDisc from ((SL_DETL AS K LEFT JOIN ITEM_MAST AS I ON K.CO_CODE = I.CO_CODE AND K.IT_CODE = I.IT_CODE) "), (object)" LEFT JOIN BOOK_DATA AS L ON K.CO_CODE = L.CO_CODE AND K.LC_CODE = L.LC_CODE AND K.CO_BOOK = L.CO_BOOK)LEFT JOIN AC_MAST AS J ON K.CO_CODE = J.CO_CODE AND K.AC_CODE = J.AC_CODE WHERE K.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND K.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND K.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND L.BOOK_TYPE = 'T' AND K.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  AND K.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND L.MAIN_BOOK IN ('E CRNT') GROUP BY I.HSN_CODE,I.RATE_TYPE,I.IT_TYPE,J.AC_GST_TYPE "), (object)" UNION ALL SELECT N.HSN_CODE,N.RATE_TYPE,N.IT_TYPE As ItType,P.AC_GST_TYPE As TAX_TYPE, "), (object)" CASE WHEN N.RATE_TYPE = 'P' THEN SUM(M.ITM_PCS) ELSE SUM(M.ITM_NWT) END As ItmNwt,SUM(M.IT_NET_AMT)As ItmAmt,SUM(M.IT_TAX_AMT)As ItmTax,SUM(M.IT_DISC_AMT) As ItmDisc from ((LBR_ISU_DETL AS M LEFT JOIN ITEM_MAST AS N ON M.CO_CODE = N.CO_CODE AND M.IT_CODE = N.IT_CODE) "), (object)" LEFT JOIN BOOK_DATA AS O ON M.CO_CODE = O.CO_CODE AND M.LC_CODE = O.LC_CODE AND M.CO_BOOK = O.CO_BOOK)LEFT JOIN AC_MAST AS P ON M.CO_CODE = P.CO_CODE AND M.AC_CODE = P.AC_CODE WHERE M.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND M.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND M.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND O.BOOK_TYPE = 'T' AND M.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  AND M.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND O.MAIN_BOOK IN ('LABOUR WORK') GROUP BY N.HSN_CODE,N.RATE_TYPE,N.IT_TYPE,P.AC_GST_TYPE "), (object)" UNION ALL Select '998892' AS HSN_CODE, R.RATE_TYPE, R.IT_TYPE As ItType, T.AC_GST_TYPE As TAX_TYPE, "), (object)" SUM(Q.ITM_NWT) As ItmNwt,SUM(Q.IT_LBR_AMT)As ItmAmt,SUM(Q.IT_LBR_TAX)As ItmTax,SUM(Q.IT_LBR_DISC) As ItmDisc "), (object)" from((LBR_ISU_DETL AS Q LEFT JOIN ITEM_MAST AS R ON Q.CO_CODE = R.CO_CODE And Q.IT_CODE = R.IT_CODE)Left Join BOOK_DATA AS S ON Q.CO_CODE = S.CO_CODE And Q.LC_CODE = S.LC_CODE And Q.CO_BOOK = S.CO_BOOK) "), (object)" Left Join AC_MAST AS T ON Q.CO_CODE = T.CO_CODE And Q.AC_CODE = T.AC_CODE WHERE Q.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND Q.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND Q.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  "), (object)" And S.BOOK_TYPE = 'T' AND Q.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  AND Q.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND S.MAIN_BOOK IN ('LABOUR WORK')  GROUP BY HSN_CODE,R.RATE_TYPE,R.IT_TYPE,T.AC_GST_TYPE "));
			DC_Main.RsQry += " ORDER BY B.HSN_CODE,B.RATE_TYPE,B.IT_TYPE,D.AC_GST_TYPE";
			break;
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			if (!bExportingAll)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
			}
			if (!bExportingAll)
			{
				((Control)mFromDt).Focus();
			}
			return;
		}
		string text = "";
		AxMSFlexGrid mSG_VCH = MSG_VCH;
		DC_Main.i = 4;
		DC_Main.R = 0;
		checked
		{
			double num = default(double);
			double num2 = default(double);
			double num6 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
			{
				switch (cboSectionType.SelectedIndex)
				{
				case 1:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
					mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
					mSG_VCH[DC_Main.i, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_CODE"], (object)""));
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_GSTNO"], (object)""));
					mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_NAME"], (object)""));
					mSG_VCH[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
					mSG_VCH[DC_Main.i, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"]), "dd-MMM-yy");
					mSG_VCH[DC_Main.i, 4] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)""), "0.00");
					mSG_VCH[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["R_CHARG"], (object)""));
					if (Operators.CompareString(mSG_VCH[DC_Main.i, 6], "", false) == 0)
					{
						mSG_VCH[DC_Main.i, 6] = "N";
					}
					mSG_VCH[DC_Main.i, 7] = "";
					mSG_VCH[DC_Main.i, 8] = "Regular";
					mSG_VCH[DC_Main.i, 9] = "";
					mSG_VCH[DC_Main.i, 10] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
					mSG_VCH[DC_Main.i, 11] = Strings.Format(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], DC_Main.Rshlp.Rows[DC_Main.R]["DISC_AMT"]), Conversions.ToString(0.0));
					mSG_VCH[DC_Main.i, 12] = Conversions.ToString(0);
					num += Conversion.Val(mSG_VCH[DC_Main.i, 4]);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 11]);
					if (Operators.CompareString(mSG_VCH[DC_Main.i, 2], text, false) != 0)
					{
						text = mSG_VCH[DC_Main.i, 2];
						num6 += 1.0;
					}
					break;
				case 2:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
					mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
					mSG_VCH[DC_Main.i, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_CODE"], (object)""));
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
					mSG_VCH[DC_Main.i, 1] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"], (object)""), "dd-MMM-yy");
					mSG_VCH[DC_Main.i, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 4] = "";
					mSG_VCH[DC_Main.i, 5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 6] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)"")), "0.00");
					num += Conversion.Val(mSG_VCH[DC_Main.i, 2]);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 6]);
					if (Operators.CompareString(mSG_VCH[DC_Main.i, 0], text, false) != 0)
					{
						text = mSG_VCH[DC_Main.i, 0];
						num6 += 1.0;
					}
					break;
				case 3:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 0] = "OE";
					mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 2] = "";
					mSG_VCH[DC_Main.i, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 4] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 5] = Conversions.ToString(0);
					mSG_VCH[DC_Main.i, 6] = "";
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 4]);
					break;
				case 4:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
					mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
					mSG_VCH[DC_Main.i, 16] = "";
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_GSTNO"], (object)""));
					mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_NAME"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false))
					{
						mSG_VCH[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BillBook"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"]), (object)""));
					}
					else
					{
						mSG_VCH[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"], (object)""));
					}
					mSG_VCH[DC_Main.i, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_DATE"]), "dd-MMM-yy");
					mSG_VCH[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
					mSG_VCH[DC_Main.i, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"]), "dd-MMM-yy");
					mSG_VCH[DC_Main.i, 6] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false), (object)"C", (object)"D"));
					mSG_VCH[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 9] = "";
					mSG_VCH[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 12] = Conversions.ToString(0);
					mSG_VCH[DC_Main.i, 13] = "N";
					num += Conversion.Val(mSG_VCH[DC_Main.i, 8]);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 11]);
					if (Operators.CompareString(mSG_VCH[DC_Main.i, 4], text, false) != 0)
					{
						text = mSG_VCH[DC_Main.i, 4];
						num6 += 1.0;
					}
					break;
				case 5:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
					mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
					mSG_VCH[DC_Main.i, 16] = "";
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Interaction.IIf(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)"")) >= 250000.0, (object)"B2CL", (object)"B2CS"));
					mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
					mSG_VCH[DC_Main.i, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"]), "dd-MMM-yy");
					mSG_VCH[DC_Main.i, 3] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false), (object)"C", (object)"D"));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false))
					{
						mSG_VCH[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BillBook"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"]), (object)""));
					}
					else
					{
						mSG_VCH[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"], (object)""));
					}
					mSG_VCH[DC_Main.i, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_DATE"]), "dd-MMM-yy");
					mSG_VCH[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 8] = "";
					mSG_VCH[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 11] = Conversions.ToString(0);
					mSG_VCH[DC_Main.i, 12] = "N";
					num += Conversion.Val(mSG_VCH[DC_Main.i, 7]);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 10]);
					if (Operators.CompareString(mSG_VCH[DC_Main.i, 1], text, false) != 0)
					{
						text = mSG_VCH[DC_Main.i, 1];
						num6 += 1.0;
					}
					break;
				case 7:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 1] = "";
					mSG_VCH[DC_Main.i, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 4] = Conversions.ToString(0);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 3]);
					break;
				case 8:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
					mSG_VCH[DC_Main.i, 1] = "";
					mSG_VCH[DC_Main.i, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 4] = Conversions.ToString(0);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 2]);
					break;
				case 10:
					mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
					mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["HSN_CODE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"G", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Gold";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"S", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Silver";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"D", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Diamond";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"R", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Real Stone";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"E", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Emetation";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"O", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Other";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"B", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Bronze";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"H", false))
					{
						mSG_VCH[DC_Main.i, 1] = "H-Brass";
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItType"], (object)""), (object)"M", false))
					{
						mSG_VCH[DC_Main.i, 1] = "Mix Metal";
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["RATE_TYPE"], (object)""), (object)"G", false))
					{
						mSG_VCH[DC_Main.i, 2] = "GMS-GRAMMES";
					}
					else
					{
						mSG_VCH[DC_Main.i, 2] = "PCS";
					}
					mSG_VCH[DC_Main.i, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItmNwt"], (object)"")), "0.00");
					mSG_VCH[DC_Main.i, 4] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["ItmAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["ItmTax"])) - Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItmDisc"], (object)""))), "0.00");
					mSG_VCH[DC_Main.i, 5] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["ItmAmt"])) - Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["ItmDisc"], (object)""))), "0.00");
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TAX_TYPE"], (object)""), (object)"L", false))
					{
						AxMSFlexGrid obj = mSG_VCH;
						int i = DC_Main.i;
						object Value = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["ItmTax"]));
						obj[i, 6] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
					}
					else
					{
						AxMSFlexGrid obj2 = mSG_VCH;
						int i2 = DC_Main.i;
						object Value = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["ItmTax"]));
						obj2[i2, 7] = Strings.Format((object)(DC_Main.Fnv(ref Value) / 2.0), "0.00");
						AxMSFlexGrid obj3 = mSG_VCH;
						int i3 = DC_Main.i;
						Value = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["ItmTax"]));
						obj3[i3, 8] = Strings.Format((object)(DC_Main.Fnv(ref Value) / 2.0), "0.00");
					}
					mSG_VCH[DC_Main.i, 9] = Strings.Format((object)0, "0.00");
					num += Conversion.Val(mSG_VCH[DC_Main.i, 4]);
					num2 += Conversion.Val(mSG_VCH[DC_Main.i, 5]);
					num3 += Conversion.Val(mSG_VCH[DC_Main.i, 6]);
					num4 += Conversion.Val(mSG_VCH[DC_Main.i, 7]);
					num5 += Conversion.Val(mSG_VCH[DC_Main.i, 8]);
					break;
				}
				DC_Main.i++;
				DC_Main.R++;
				mSG_VCH.Rows += 1;
			}
			mSG_VCH.Rows += 1;
			DC_Main.i++;
			switch (cboSectionType.SelectedIndex)
			{
			case 1:
				mSG_VCH[2, 4] = Strings.Format((object)num, "0.00");
				mSG_VCH[2, 11] = Strings.Format((object)num2, "0.00");
				mSG_VCH[2, 2] = Strings.Format((object)num6, "0");
				break;
			case 2:
				mSG_VCH[2, 2] = Strings.Format((object)num, "0.00");
				mSG_VCH[2, 6] = Strings.Format((object)num2, "0.00");
				mSG_VCH[2, 0] = Strings.Format((object)num6, "0");
				break;
			case 3:
				mSG_VCH[2, 4] = Strings.Format((object)num2, "0.00");
				break;
			case 4:
				mSG_VCH[2, 8] = Strings.Format((object)num, "0.00");
				mSG_VCH[2, 11] = Strings.Format((object)num2, "0.00");
				mSG_VCH[2, 4] = Strings.Format((object)num6, "0");
				break;
			case 5:
				mSG_VCH[2, 7] = Strings.Format((object)num, "0.00");
				mSG_VCH[2, 10] = Strings.Format((object)num2, "0.00");
				mSG_VCH[2, 1] = Strings.Format((object)num6, "0");
				break;
			case 7:
				mSG_VCH[2, 3] = Strings.Format((object)num2, "0.00");
				break;
			case 8:
				mSG_VCH[2, 3] = Strings.Format((object)num2, "0.00");
				break;
			case 10:
				mSG_VCH[2, 4] = Strings.Format((object)num, "0.00");
				mSG_VCH[2, 5] = Strings.Format((object)num2, "0.00");
				mSG_VCH[2, 6] = Strings.Format((object)num3, "0.00");
				mSG_VCH[2, 7] = Strings.Format((object)num4, "0.00");
				mSG_VCH[2, 8] = Strings.Format((object)num5, "0.00");
				break;
			}
			mSG_VCH.Row = DC_Main.i;
			int num7 = mSG_VCH.Cols - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num7)
			{
				mSG_VCH.Col = DC_Main.i;
				mSG_VCH.CellBackColor = Color.Moccasin;
				mSG_VCH.CellForeColor = Color.Blue;
				DC_Main.i++;
			}
			mSG_VCH = null;
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

	private void BtnCsvFile_Click(object sender, EventArgs e)
	{
		switch (cboSectionType.SelectedIndex)
		{
		case 1:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\B2B.csv");
			break;
		case 2:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\B2CL.csv");
			break;
		case 3:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\B2CS.csv");
			break;
		case 4:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\CDNR.csv");
			break;
		case 5:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\CDNUR.csv");
			break;
		case 6:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\EXP.csv");
			break;
		case 7:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\AT.csv");
			break;
		case 8:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\ATADJ.csv");
			break;
		case 10:
			SaveCSV(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\CsvFile\\HSNSUM.csv");
			break;
		case 9:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void SaveCSV(string strFilename)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		string fileName = Path.GetFileName(strFilename);
		if (Operators.CompareString(FileSystem.Dir(strFilename, (FileAttribute)0), "", false) != 0)
		{
			File.Delete(strFilename);
		}
		StreamWriter streamWriter = File.AppendText(strFilename);
		AxMSFlexGrid mSG_VCH = MSG_VCH;
		checked
		{
			int num = mSG_VCH.Rows - 1;
			DC_Main.R = 3;
			while (DC_Main.R <= num)
			{
				string text = "";
				int num2 = mSG_VCH.Cols - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (mSG_VCH[i] != 0)
					{
						text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)text, Interaction.IIf(i == 0, (object)"", (object)",")), (object)mSG_VCH[DC_Main.R, i]));
					}
				}
				streamWriter.WriteLine(text);
				DC_Main.R++;
			}
			mSG_VCH = null;
			streamWriter.Close();
			Interaction.MsgBox((object)"File is Generate...", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnGst2Zoom_Click(object sender, EventArgs e)
	{
		//IL_1e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		double num4 = default(double);
		double num3 = default(double);
		double num5 = default(double);
		int num = default(int);
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
					{
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							BtnPrint_Click(BtnPrint, new EventArgs());
							goto end_IL_0001;
						}
						if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
						{
							BtnPrint_Click(BtnPrint, new EventArgs());
							goto end_IL_0001;
						}
						DGV_CLEAR();
						ProjectData.ClearProjectError();
						num2 = 2;
						if (cboSectionType.SelectedIndex == 0)
						{
							Interaction.MsgBox((object)"Please Select Section Type And Try...", (MsgBoxStyle)0, (object)null);
							((Control)cboSectionType).Focus();
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 3;
						switch (cboSectionType.SelectedIndex)
						{
						case 1:
						case 2:
							DC_Main.RsQry = "SELECT A.CO_BOOK,A.BOOK_NAME,A.AC_CODE,B.AC_GSTNO,E.BOOK_SR_NAME,A.VCH_NO,A.VCH_DATE,A.TOT_AMT,C.STATE_CODE,C.STATE_NAME,A.R_CHARG,D.TAX_PRC As TaxPrc,A.NET_AMT from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0 ";
							DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'";
							if (cboSectionType.SelectedIndex == 0)
							{
								DC_Main.RsQry += "AND B.AC_GSTNO <> '' AND A.BOOK_NAME IN ('PURCHASE','KARIGAR RECEIPT','OTH SERVICE')";
							}
							else if (cboSectionType.SelectedIndex == 1)
							{
								DC_Main.RsQry += "AND B.AC_GSTNO = '' AND A.BOOK_NAME IN ('PURCHASE','KARIGAR RECEIPT','OTH SERVICE') AND A.TOT_AMT >= 250000";
							}
							DC_Main.RsQry += " GROUP BY A.CO_BOOK,A.BOOK_NAME,A.AC_CODE,B.AC_GSTNO,E.BOOK_SR_NAME,A.VCH_NO,A.VCH_DATE,A.TOT_AMT,C.STATE_CODE,C.STATE_NAME,A.R_CHARG,D.TAX_PRC,A.NET_AMT";
							DC_Main.RsQry += " ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
							break;
						case 3:
							DC_Main.RsQry = " SELECT C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC As TaxPrc,Sum(A.NET_AMT) As NetAmt from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
							DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'";
							DC_Main.RsQry += "AND B.AC_GSTNO = '' AND A.BOOK_NAME IN ('PURCHASE','KARIGAR RECEIPT','OTH SERVICE') AND A.SR_NO IN (1,3,10,30) AND A.TOT_AMT < 250000";
							DC_Main.RsQry += " GROUP BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
							DC_Main.RsQry += " ORDER BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
							break;
						case 4:
						case 5:
							DC_Main.RsQry = " SELECT A.CO_BOOK,C.BOOK_SR_NAME As BillBook,B.AC_GSTNO,A.BILL_NO,A.BILL_DATE,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,E.BOOK_SR_NAME,F.STATE_CODE,F.STATE_NAME,D.TAX_PRC As TaxPrc,A.NET_AMT,A.TOT_AMT from ((((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.BILL_DBCD = C.CO_BOOK)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK)  LEFT JOIN STATE_MAST AS F ON B.AC_STATE = F.STATE_NAME WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
							DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'";
							if (cboSectionType.SelectedIndex == 4)
							{
								DC_Main.RsQry += "AND B.AC_GSTNO = '' AND A.BOOK_NAME IN ('SALES RETURNE','PURC RETURN') ";
							}
							else
							{
								DC_Main.RsQry += "AND B.AC_GSTNO <> '' AND A.BOOK_NAME IN ('SALES RETURNE','PURC RETURN') ";
							}
							DC_Main.RsQry += " GROUP BY A.CO_BOOK,C.BOOK_SR_NAME,B.AC_GSTNO,A.BILL_NO,A.BILL_DATE,A.VCH_NO,A.VCH_DATE,A.BOOK_NAME,E.BOOK_SR_NAME,F.STATE_CODE,F.STATE_NAME,D.TAX_PRC,A.NET_AMT,A.TOT_AMT";
							DC_Main.RsQry += " ORDER BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE";
							break;
						case 7:
							DC_Main.RsQry = " SELECT C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC As TaxPrc,Sum(A.NET_AMT) As NetAmt from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
							DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'";
							DC_Main.RsQry += " AND A.BOOK_NAME IN ('SALES ORDER') AND A.SR_NO IN (1,3) ";
							DC_Main.RsQry += " GROUP BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
							DC_Main.RsQry += " ORDER BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
							break;
						case 8:
							DC_Main.RsQry = " SELECT C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC As TaxPrc,Sum(A.NET_AMT) As NetAmt from (((TAX_DATA AS A  INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE  AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME)LEFT JOIN TAX_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.TAX_CODE = D.TAX_CODE)LEFT JOIN BOOK_DATA AS E ON A.CO_CODE = E.CO_CODE AND A.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.SR_NO = 0";
							DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "'";
							DC_Main.RsQry += " AND A.BOOK_NAME IN ('ORD ADJUST') AND A.SR_NO IN (11,13,21,23,31,33,41,43,51,53) ";
							DC_Main.RsQry += " GROUP BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
							DC_Main.RsQry += " ORDER BY C.STATE_CODE,C.STATE_NAME,A.TAX_CODE,D.TAX_PRC";
							break;
						case 6:
							goto end_IL_0001;
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
							((Control)mFromDt).Focus();
							goto end_IL_0001;
						}
						string text = "";
						AxMSFlexGrid mSG_VCH = MSG_VCH;
						DC_Main.i = 4;
						DC_Main.R = 0;
						while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
						{
							switch (cboSectionType.SelectedIndex)
							{
							case 1:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
								mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
								mSG_VCH[DC_Main.i, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_CODE"], (object)""));
								mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_GSTNO"], (object)""));
								mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
								mSG_VCH[DC_Main.i, 2] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"], (object)""), "dd-MMM-yy");
								mSG_VCH[DC_Main.i, 3] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
								mSG_VCH[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["R_CHARG"], (object)""));
								mSG_VCH[DC_Main.i, 6] = "Regular";
								mSG_VCH[DC_Main.i, 7] = "";
								mSG_VCH[DC_Main.i, 8] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 9] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 10] = Conversions.ToString(0);
								num4 += Conversion.Val(mSG_VCH[DC_Main.i, 3]);
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 9]);
								if (Operators.CompareString(mSG_VCH[DC_Main.i, 1], text, false) != 0)
								{
									text = mSG_VCH[DC_Main.i, 1];
									num5 += 1.0;
								}
								break;
							case 2:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
								mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
								mSG_VCH[DC_Main.i, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_CODE"], (object)""));
								mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
								mSG_VCH[DC_Main.i, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"]), "dd-MMM-yy");
								mSG_VCH[DC_Main.i, 2] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
								mSG_VCH[DC_Main.i, 4] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 5] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)""), "0.00");
								num4 += Conversion.Val(mSG_VCH[DC_Main.i, 2]);
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 5]);
								if (Operators.CompareString(mSG_VCH[DC_Main.i, 0], text, false) != 0)
								{
									text = mSG_VCH[DC_Main.i, 0];
									num5 += 1.0;
								}
								break;
							case 3:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 0] = "OE";
								mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]));
								mSG_VCH[DC_Main.i, 2] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 3] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 4] = Conversions.ToString(0);
								mSG_VCH[DC_Main.i, 5] = "";
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 3]);
								break;
							case 4:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
								mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
								mSG_VCH[DC_Main.i, 16] = "";
								mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["AC_GSTNO"], (object)""));
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false))
								{
									mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BillBook"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"]), (object)""));
								}
								else
								{
									mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"], (object)""));
								}
								mSG_VCH[DC_Main.i, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_DATE"]), "dd-MMM-yy");
								mSG_VCH[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
								mSG_VCH[DC_Main.i, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"]), "dd-MMM-yy");
								mSG_VCH[DC_Main.i, 5] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false), (object)"C", (object)"D"));
								mSG_VCH[DC_Main.i, 6] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false), (object)"Sales Return", (object)"Debit Note"));
								mSG_VCH[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
								mSG_VCH[DC_Main.i, 8] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 9] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 10] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 11] = Conversions.ToString(0);
								mSG_VCH[DC_Main.i, 12] = "N";
								num4 += Conversion.Val(mSG_VCH[DC_Main.i, 8]);
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 10]);
								if (Operators.CompareString(mSG_VCH[DC_Main.i, 3], text, false) != 0)
								{
									text = mSG_VCH[DC_Main.i, 3];
									num5 += 1.0;
								}
								break;
							case 5:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"], (object)""));
								mSG_VCH[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""));
								mSG_VCH[DC_Main.i, 16] = "";
								mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectGreaterEqual(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)250000, false), (object)"B2CL", (object)"B2CS"));
								mSG_VCH[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_SR_NAME"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)""));
								mSG_VCH[DC_Main.i, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["VCH_DATE"]), "dd-MMM-yy");
								mSG_VCH[DC_Main.i, 3] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false), (object)"C", (object)"D"));
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false))
								{
									mSG_VCH[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BillBook"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"]), (object)""));
								}
								else
								{
									mSG_VCH[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_NO"], (object)""));
								}
								mSG_VCH[DC_Main.i, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["BILL_DATE"]), "dd-MMM-yy");
								mSG_VCH[DC_Main.i, 6] = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["BOOK_NAME"], (object)""), (object)"SALES RETURNE", false), (object)"Sales Return", (object)"Debit Note"));
								mSG_VCH[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
								mSG_VCH[DC_Main.i, 8] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TOT_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 9] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 10] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NET_AMT"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 11] = Conversions.ToString(0);
								mSG_VCH[DC_Main.i, 12] = "N";
								num4 += Conversion.Val(mSG_VCH[DC_Main.i, 8]);
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 10]);
								if (Operators.CompareString(mSG_VCH[DC_Main.i, 1], text, false) != 0)
								{
									text = mSG_VCH[DC_Main.i, 1];
									num5 += 1.0;
								}
								break;
							case 7:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
								mSG_VCH[DC_Main.i, 1] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 2] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 3] = Conversions.ToString(0);
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 2]);
								break;
							case 8:
								mSG_VCH[DC_Main.i, 15] = Conversions.ToString(DC_Main.i + 1);
								mSG_VCH[DC_Main.i, 0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["STATE_NAME"]), (object)""));
								mSG_VCH[DC_Main.i, 1] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TaxPrc"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 2] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
								mSG_VCH[DC_Main.i, 3] = Conversions.ToString(0);
								num3 += Conversion.Val(mSG_VCH[DC_Main.i, 2]);
								break;
							}
							DC_Main.i++;
							DC_Main.R++;
							mSG_VCH.Rows += 1;
						}
						mSG_VCH.Rows += 1;
						DC_Main.i++;
						switch (cboSectionType.SelectedIndex)
						{
						case 1:
							mSG_VCH[2, 3] = Strings.Format((object)num4, "0.00");
							mSG_VCH[2, 9] = Strings.Format((object)num3, "0.00");
							mSG_VCH[2, 1] = Strings.Format((object)num5, "0");
							break;
						case 2:
							mSG_VCH[2, 2] = Strings.Format((object)num4, "0.00");
							mSG_VCH[2, 5] = Strings.Format((object)num3, "0.00");
							mSG_VCH[2, 0] = Strings.Format((object)num5, "0");
							break;
						case 3:
							mSG_VCH[2, 3] = Strings.Format((object)num3, "0.00");
							break;
						case 4:
							mSG_VCH[2, 8] = Strings.Format((object)num4, "0.00");
							mSG_VCH[2, 10] = Strings.Format((object)num3, "0.00");
							mSG_VCH[2, 3] = Strings.Format((object)num5, "0");
							break;
						case 5:
							mSG_VCH[2, 8] = Strings.Format((object)num4, "0.00");
							mSG_VCH[2, 10] = Strings.Format((object)num3, "0.00");
							mSG_VCH[2, 1] = Strings.Format((object)num5, "0");
							break;
						case 7:
							mSG_VCH[2, 2] = Strings.Format((object)num3, "0.00");
							break;
						case 8:
							mSG_VCH[2, 2] = Strings.Format((object)num3, "0.00");
							break;
						}
						mSG_VCH.Row = DC_Main.i;
						int num6 = mSG_VCH.Cols - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num6)
						{
							mSG_VCH.Col = DC_Main.i;
							mSG_VCH.CellBackColor = Color.Moccasin;
							mSG_VCH.CellForeColor = Color.Blue;
							DC_Main.i++;
						}
						mSG_VCH = null;
						goto end_IL_0001;
					}
					case 7841:
						num = -1;
						switch (num2)
						{
						case 2:
						case 3:
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7841;
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

	private void BtnGst3Zoom_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
		{
			BtnSave_Click(BtnSave, new EventArgs());
			return;
		}
		AxMSFlexGrid mSG_VCH = MSG_VCH;
		mSG_VCH.Clear();
		mSG_VCH.Cols = 19;
		mSG_VCH.Rows = 2;
		mSG_VCH[0] = 325;
		mSG_VCH[15] = 0;
		mSG_VCH[0] = 0;
		mSG_VCH[1] = 0;
		mSG_VCH[2] = 0;
		mSG_VCH[3] = 0;
		mSG_VCH[4] = 0;
		mSG_VCH[5] = 0;
		mSG_VCH[6] = 0;
		mSG_VCH[7] = 0;
		mSG_VCH[8] = 0;
		mSG_VCH[9] = 0;
		mSG_VCH[10] = 0;
		mSG_VCH[11] = 0;
		mSG_VCH[12] = 0;
		mSG_VCH[13] = 0;
		mSG_VCH[14] = 0;
		mSG_VCH[17] = 0;
		mSG_VCH[16] = 0;
		mSG_VCH[18] = 0;
		mSG_VCH.Row = 0;
		mSG_VCH[0, 0] = "GSTR 3B";
		mSG_VCH[0, 1] = "Month = " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "     " + DC_Main.MCo_Name;
		mSG_VCH[0] = 0;
		checked
		{
			mSG_VCH[0] = (int)Math.Round(1300.0 * ColCon);
			mSG_VCH[1, 0] = "Table No 3.1";
			mSG_VCH[1] = 0;
			mSG_VCH[1] = (int)Math.Round(5000.0 * ColCon);
			mSG_VCH[1, 1] = "Nature of Supplies)  ";
			mSG_VCH[2] = 0;
			mSG_VCH[2] = (int)Math.Round(3000.0 * ColCon);
			mSG_VCH[1, 2] = "Place of Supplies";
			mSG_VCH[3] = 7;
			mSG_VCH[3] = (int)Math.Round(1500.0 * ColCon);
			mSG_VCH[1, 3] = "Total Taxable";
			mSG_VCH[4] = 7;
			mSG_VCH[4] = (int)Math.Round(1500.0 * ColCon);
			mSG_VCH[1, 4] = "Igst Tax";
			mSG_VCH[5] = 7;
			mSG_VCH[5] = (int)Math.Round(1500.0 * ColCon);
			mSG_VCH[1, 5] = "Cgst Tax";
			mSG_VCH[6] = 7;
			mSG_VCH[6] = (int)Math.Round(1500.0 * ColCon);
			mSG_VCH[1, 6] = "Sgst/UT Tax";
			mSG_VCH[7] = 7;
			mSG_VCH[7] = (int)Math.Round(1300.0 * ColCon);
			mSG_VCH[1, 7] = "Cess";
			mSG_VCH = null;
			DC_Main.RsQry = "SELECT SUM(IIF(TAX_TYPE IN ('IGST','SGST'),A.NET_AMT,0)) As NetAmt,SUM(IIF(TAX_TYPE = 'IGST',TAX_AMT,0)) As IgstAmt,SUM(IIF(TAX_TYPE = 'CGST',TAX_AMT,0)) As CgstAmt,SUM(IIF(TAX_TYPE = 'SGST',TAX_AMT,0)) As SgstAmt  FROM TAX_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TAX_SIGN = '+' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			AxMSFlexGrid mSG_VCH2 = MSG_VCH;
			mSG_VCH2.Rows += 1;
			DC_Main.i = 2;
			DC_Main.R = 0;
			double num = default(double);
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				mSG_VCH2[DC_Main.i, 0] = "(a)";
				mSG_VCH2[DC_Main.i, 1] = "OutWord Taxable Supplies(Other then Zero rated)";
				mSG_VCH2[DC_Main.i, 2] = "";
				mSG_VCH2[DC_Main.i, 3] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 4] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 5] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 6] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["SgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 7] = "";
				num += Conversion.Val(mSG_VCH2[DC_Main.i, 3]);
				num2 += Conversion.Val(mSG_VCH2[DC_Main.i, 4]);
				num3 += Conversion.Val(mSG_VCH2[DC_Main.i, 5]);
				num4 += Conversion.Val(mSG_VCH2[DC_Main.i, 6]);
				DC_Main.i++;
				mSG_VCH2.Rows += 1;
			}
			else
			{
				mSG_VCH2[DC_Main.i, 0] = "(a)";
				mSG_VCH2[DC_Main.i, 1] = "OutWord Taxable Supplies(Other then Zero rated)";
				mSG_VCH2.Rows += 1;
				DC_Main.i++;
			}
			mSG_VCH2[DC_Main.i, 0] = "(b)";
			mSG_VCH2[DC_Main.i, 1] = "OutWord Taxable Supplies (Zero rated) ";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(c)";
			mSG_VCH2[DC_Main.i, 1] = "Other then OutWord Supplies(Nil rated,Exempted) ";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			DC_Main.RsQry = "SELECT SUM(IIF(TAX_TYPE IN ('IGST','SGST'),A.NET_AMT,0)) As NetAmt,SUM(IIF(TAX_TYPE = 'IGST',TAX_AMT,0)) As IgstAmt,SUM(IIF(TAX_TYPE = 'CGST',TAX_AMT,0)) As CgstAmt,SUM(IIF(TAX_TYPE = 'SGST',TAX_AMT,0)) As SgstAmt  FROM TAX_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TAX_SIGN = '+' AND A.R_CHARG = 'Y'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				mSG_VCH2[DC_Main.i, 0] = "(d)";
				mSG_VCH2[DC_Main.i, 1] = "InWord Supplies(Lible to Reverse Charge)";
				mSG_VCH2[DC_Main.i, 2] = "";
				mSG_VCH2[DC_Main.i, 3] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 4] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 5] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 6] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["SgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 7] = "";
				num += Conversion.Val(mSG_VCH2[DC_Main.i, 3]);
				num2 += Conversion.Val(mSG_VCH2[DC_Main.i, 4]);
				num3 += Conversion.Val(mSG_VCH2[DC_Main.i, 5]);
				num4 += Conversion.Val(mSG_VCH2[DC_Main.i, 6]);
				DC_Main.i++;
				mSG_VCH2.Rows += 1;
			}
			else
			{
				mSG_VCH2[DC_Main.i, 0] = "(d)";
				mSG_VCH2[DC_Main.i, 1] = "InWord Supplies(Lible to Reverse Charge)";
				mSG_VCH2.Rows += 1;
				DC_Main.i++;
			}
			mSG_VCH2[DC_Main.i, 0] = "(e)";
			mSG_VCH2[DC_Main.i, 1] = "Non-Gst OutWord Supplies";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 3] = Strings.Format((object)num, "0.00");
			mSG_VCH2[DC_Main.i, 4] = Strings.Format((object)num2, "0.00");
			mSG_VCH2[DC_Main.i, 5] = Strings.Format((object)num3, "0.00");
			mSG_VCH2[DC_Main.i, 6] = Strings.Format((object)num4, "0.00");
			mSG_VCH2.Row = DC_Main.i;
			int num5 = mSG_VCH2.Cols - 1;
			DC_Main.M = 2;
			while (DC_Main.M <= num5)
			{
				mSG_VCH2.Col = DC_Main.M;
				mSG_VCH2.CellBackColor = Color.Moccasin;
				mSG_VCH2.CellForeColor = Color.Blue;
				DC_Main.M++;
			}
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "3.2";
			mSG_VCH2[DC_Main.i, 1] = "Inter State Supplies made to Unregistered Persons Comp";
			mSG_VCH2[DC_Main.i, 2] = "osition persons and UIN Holders    ";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "";
			mSG_VCH2[DC_Main.i, 2] = "Place of Supplies (State/Ut)";
			mSG_VCH2[DC_Main.i, 3] = "Taxable Val";
			mSG_VCH2[DC_Main.i, 4] = "Igst Tax ";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			DC_Main.RsQry = "SELECT C.STATE_CODE,B.AC_STATE,SUM(IIF(A.TAX_TYPE IN ('IGST','SGST'),A.NET_AMT,0)) As NetAmt,SUM(IIF(A.TAX_TYPE = 'IGST',TAX_AMT,0)) As IgstAmt FROM (TAX_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN STATE_MAST AS C ON B.AC_STATE = C.STATE_NAME WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.AC_STATE <> '" + DC_Main.MCo_State + "' AND AC_STATE <> ''";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TAX_SIGN = '+' AND B.AC_GSTNO = '' GROUP BY C.STATE_CODE,B.AC_STATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 1;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
				{
					if (DC_Main.M == 1)
					{
						mSG_VCH2[DC_Main.i, 0] = "(1)";
						mSG_VCH2[DC_Main.i, 1] = "Supplies Made ot Unregester Persons";
					}
					mSG_VCH2[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["STATE_CODE"], (object)""), (object)" - "), DC_Main.Rshlp.Rows[DC_Main.R]["AC_STATE"]), (object)""));
					mSG_VCH2[DC_Main.i, 3] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
					mSG_VCH2[DC_Main.i, 4] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IgstAmt"], (object)""), "0.00");
					DC_Main.M++;
					DC_Main.i++;
					DC_Main.R++;
					mSG_VCH2.Rows += 1;
				}
			}
			else
			{
				mSG_VCH2[DC_Main.i, 0] = "(1)";
				mSG_VCH2[DC_Main.i, 1] = "Supplies Made ot Unregester Persons";
				mSG_VCH2.Rows += 1;
				DC_Main.i++;
			}
			mSG_VCH2[DC_Main.i, 0] = "(2)";
			mSG_VCH2[DC_Main.i, 1] = "Supplies Made ot Composition Taxable Persons";
			mSG_VCH2[DC_Main.i, 2] = "";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(3)";
			mSG_VCH2[DC_Main.i, 1] = "Supplies Made ot UIN Holders";
			mSG_VCH2[DC_Main.i, 2] = "";
			mSG_VCH2.Rows += 2;
			DC_Main.i += 2;
			mSG_VCH2[DC_Main.i, 0] = "4";
			mSG_VCH2[DC_Main.i, 1] = "Eligible ITC";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(A)";
			mSG_VCH2[DC_Main.i, 1] = "ITC Available(Whether in full of part)";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(1)";
			mSG_VCH2[DC_Main.i, 1] = "Imprt of goods";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(2)";
			mSG_VCH2[DC_Main.i, 1] = "Imprt of Service";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(3)";
			mSG_VCH2[DC_Main.i, 1] = "Inword Supplies Liable to Reverse Charge";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(4)";
			mSG_VCH2[DC_Main.i, 1] = "Inword Supplies From ISD";
			DC_Main.RsQry = "SELECT SUM(IIF(TAX_TYPE IN ('IGST','SGST'),A.NET_AMT,0)) As NetAmt,SUM(IIF(TAX_TYPE = 'IGST',TAX_AMT,0)) As IgstAmt,SUM(IIF(TAX_TYPE = 'CGST',TAX_AMT,0)) As CgstAmt,SUM(IIF(TAX_TYPE = 'SGST',TAX_AMT,0)) As SgstAmt  FROM TAX_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
			DC_Main.RsQry = DC_Main.RsQry + " AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TAX_SIGN = '-' AND A.R_CHARG = 'N'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			DC_Main.R = 0;
			double num7 = default(double);
			double num8 = default(double);
			double num9 = default(double);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				mSG_VCH2[DC_Main.i, 0] = "(5)";
				mSG_VCH2[DC_Main.i, 1] = "All Other ITC)";
				mSG_VCH2[DC_Main.i, 2] = "";
				mSG_VCH2[DC_Main.i, 3] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["NetAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 4] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 5] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["CgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 6] = Strings.Format(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["SgstAmt"], (object)""), "0.00");
				mSG_VCH2[DC_Main.i, 7] = "";
				double num6 = num6 + Conversion.Val(mSG_VCH2[DC_Main.i, 3]);
				num7 += Conversion.Val(mSG_VCH2[DC_Main.i, 4]);
				num8 += Conversion.Val(mSG_VCH2[DC_Main.i, 5]);
				num9 += Conversion.Val(mSG_VCH2[DC_Main.i, 6]);
			}
			else
			{
				mSG_VCH2[DC_Main.i, 0] = "(5)";
				mSG_VCH2[DC_Main.i, 1] = "All Other ITC)";
			}
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(B)";
			mSG_VCH2[DC_Main.i, 1] = "ITC Reversed";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(1)";
			mSG_VCH2[DC_Main.i, 1] = "As per rules 42 & 43 of CGST Rules";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(2)";
			mSG_VCH2[DC_Main.i, 1] = "Others";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(C)";
			mSG_VCH2[DC_Main.i, 1] = "Net ITC Avaible (A)-(B)";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(D)";
			mSG_VCH2[DC_Main.i, 1] = "Ineligible ITC";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(1)";
			mSG_VCH2[DC_Main.i, 1] = "As per Section 17(5)";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "(2)";
			mSG_VCH2[DC_Main.i, 1] = "Other";
			mSG_VCH2.Rows += 2;
			DC_Main.i += 2;
			mSG_VCH2[DC_Main.i, 0] = "5";
			mSG_VCH2[DC_Main.i, 1] = "Values of exempt,nil rated and non GST Inword supplies";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "";
			mSG_VCH2[DC_Main.i, 1] = "Supplier Under Composition and nil rated supplies";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "";
			mSG_VCH2[DC_Main.i, 1] = "Non GST Supplies";
			mSG_VCH2.Rows += 2;
			DC_Main.i += 2;
			mSG_VCH2[DC_Main.i, 0] = "6.1";
			mSG_VCH2[DC_Main.i, 1] = "Payment of Tax";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "Discription";
			mSG_VCH2[DC_Main.i, 1] = "Taxpayable";
			mSG_VCH2[DC_Main.i, 2] = "Paid Igst";
			mSG_VCH2[DC_Main.i, 3] = "Paid Cgst";
			mSG_VCH2[DC_Main.i, 4] = "Paid Sgst";
			mSG_VCH2[DC_Main.i, 5] = "Paid Cess";
			mSG_VCH2[DC_Main.i, 6] = "TDS Paid";
			mSG_VCH2[DC_Main.i, 7] = "Tax Paid In Cash";
			mSG_VCH2[DC_Main.i, 8] = "Interest";
			mSG_VCH2[DC_Main.i, 9] = "Late Fee";
			mSG_VCH2.Rows += 2;
			DC_Main.i += 2;
			mSG_VCH2[DC_Main.i, 0] = "Integrated Tax";
			mSG_VCH2[DC_Main.i, 1] = Strings.Format((object)num2, "0.00");
			mSG_VCH2[DC_Main.i, 2] = Strings.Format((object)num7, "0.00");
			mSG_VCH2[DC_Main.i, 3] = Strings.Format((object)num8, "0.00");
			mSG_VCH2[DC_Main.i, 4] = Strings.Format((object)num9, "0.00");
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "Centrel Tax";
			mSG_VCH2[DC_Main.i, 1] = Strings.Format((object)num3, "0.00");
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "State/Ut Tax";
			mSG_VCH2[DC_Main.i, 1] = Strings.Format((object)num3, "0.00");
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "Cess";
			mSG_VCH2.Rows += 2;
			DC_Main.i += 2;
			mSG_VCH2[DC_Main.i, 0] = "6.2";
			mSG_VCH2[DC_Main.i, 1] = "TDS/TCS Credit";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "TDS";
			mSG_VCH2.Rows += 1;
			DC_Main.i++;
			mSG_VCH2[DC_Main.i, 0] = "TCS";
			mSG_VCH2 = null;
		}
	}

	private void btnGstrCsv_Click(object sender, EventArgs e)
	{
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		Cursor.Current = Cursors.WaitCursor;
		object obj = null;
		object obj2 = null;
		checked
		{
			try
			{
				obj = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
				obj2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
				int selectedIndex = cboSectionType.SelectedIndex;
				bExportingAll = true;
				string[] array = new string[11]
				{
					"", "B2B", "B2CL", "B2CS", "CDNR", "CDNUR", "EXP", "AT", "ATADJ", "EXEMP",
					"HSN"
				};
				int num = 1;
				int num2 = 1;
				do
				{
					cboSectionType.SelectedIndex = num2;
					BtnGst1Zoom_Click(BtnGst1Zoom, new EventArgs());
					if (MSG_VCH.Rows > 0)
					{
						object objectValue;
						if (num == 1)
						{
							objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						}
						else
						{
							object obj3 = NewLateBinding.LateGet(obj2, (Type)null, "Sheets", new object[0], (string[])null, (Type[])null, (bool[])null);
							object[] array2 = new object[1];
							object obj4 = obj2;
							object[] array3 = new object[1];
							object obj6;
							object obj5 = (array3[0] = NewLateBinding.LateGet(obj6 = NewLateBinding.LateGet(obj2, (Type)null, "Sheets", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Count", new object[0], (string[])null, (Type[])null, (bool[])null));
							object[] array4 = array3;
							bool[] obj7 = new bool[1] { true };
							bool[] array5 = obj7;
							object obj8 = NewLateBinding.LateGet(obj4, (Type)null, "Sheets", array3, (string[])null, (Type[])null, obj7);
							if (array5[0])
							{
								NewLateBinding.LateSetComplex(obj6, (Type)null, "Count", new object[1] { array4[0] }, (string[])null, (Type[])null, true, true);
							}
							array2[0] = obj8;
							object[] array6;
							bool[] array7;
							object obj9 = NewLateBinding.LateGet(obj3, (Type)null, "Add", array6 = array2, new string[1] { "After" }, (Type[])null, array7 = new bool[1] { true });
							if (array7[0])
							{
								NewLateBinding.LateSetComplex(obj4, (Type)null, "Sheets", new object[2]
								{
									obj5,
									array6[0]
								}, (string[])null, (Type[])null, true, false);
							}
							objectValue = RuntimeHelpers.GetObjectValue(obj9);
						}
						NewLateBinding.LateSet(objectValue, (Type)null, "Name", new object[1] { array[num2] }, (string[])null, (Type[])null);
						AxMSFlexGrid mSG_VCH = MSG_VCH;
						int num3 = mSG_VCH.Rows - 1;
						for (int i = 0; i <= num3; i++)
						{
							int num4 = 1;
							int num5 = mSG_VCH.Cols - 1;
							for (int j = 0; j <= num5; j++)
							{
								if (mSG_VCH[j] != 0)
								{
									if (mSG_VCH[i, j] != null)
									{
										NewLateBinding.LateSet(objectValue, (Type)null, "Cells", new object[3]
										{
											i + 1,
											num4,
											mSG_VCH[i, j].ToString()
										}, (string[])null, (Type[])null);
									}
									num4++;
								}
							}
						}
						mSG_VCH = null;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						num++;
					}
					num2++;
				}
				while (num2 <= 10);
				cboSectionType.SelectedIndex = selectedIndex;
				bExportingAll = false;
				if (selectedIndex > 0)
				{
					BtnGst1Zoom_Click(BtnGst1Zoom, new EventArgs());
				}
				else
				{
					DGV_CLEAR();
				}
				NewLateBinding.LateSet(obj, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				bExportingAll = false;
				if (obj != null)
				{
					NewLateBinding.LateCall(obj, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
				}
				Interaction.MsgBox((object)("Error Exporting to Excel: " + ex2.Message), (MsgBoxStyle)0, (object)null);
				ProjectData.ClearProjectError();
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				obj2 = null;
				obj = null;
			}
		}
	}
}
