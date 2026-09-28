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
public class RP_OTH_DETL : Form
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
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

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
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnlosItmInout")]
	private QButton _btnlosItmInout;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BrnItmInWord")]
	private QButton _BrnItmInWord;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItmInOut")]
	private QButton _BtnItmInOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItmOutWord")]
	private QButton _BtnItmOutWord;

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
	[AccessedThroughProperty("chkBookSelect")]
	private CheckBox _chkBookSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnlosItmOut")]
	private QButton _btnlosItmOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnlosItmIn")]
	private QButton _btnlosItmIn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrin")]
	private QButton _btnKrin;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrInout")]
	private QButton _btnKrInout;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrIsu")]
	private QButton _btnKrIsu;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string BulRptType;

	private string RepringType;

	private string SchmType;

	private string ScelectBook;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
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
			ComboBox val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboArea = value;
			val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual ComboBox cboItemTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("PanelInOut")]
	private virtual Panel _PanelInOut;

	internal virtual Panel PanelInOut
	{
		get
		{
			return _PanelInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelInOut = value;
		}
	}

	internal virtual QButton btnlosItmInout
	{
		[CompilerGenerated]
		get
		{
			return _btnlosItmInout;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnlosItmInout_Click;
			QButton val = _btnlosItmInout;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnlosItmInout = value;
			val = _btnlosItmInout;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BrnItmInWord
	{
		[CompilerGenerated]
		get
		{
			return _BrnItmInWord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnItmInWord_Click;
			QButton val = _BrnItmInWord;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BrnItmInWord = value;
			val = _BrnItmInWord;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnItmInOut
	{
		[CompilerGenerated]
		get
		{
			return _BtnItmInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItmInOut_Click;
			QButton val = _BtnItmInOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItmInOut = value;
			val = _BtnItmInOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnItmOutWord
	{
		[CompilerGenerated]
		get
		{
			return _BtnItmOutWord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItmOutWord_Click;
			QButton val = _BtnItmOutWord;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItmOutWord = value;
			val = _BtnItmOutWord;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEmploy")]
	private virtual ComboBox _cboEmploy;

	internal virtual ComboBox cboEmploy
	{
		get
		{
			return _cboEmploy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboEmploy = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblemp")]
	private virtual Label _lblemp;

	internal virtual Label lblemp
	{
		get
		{
			return _lblemp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblemp = value;
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

	internal virtual QButton btnlosItmOut
	{
		[CompilerGenerated]
		get
		{
			return _btnlosItmOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnlosItmOut_Click;
			QButton val = _btnlosItmOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnlosItmOut = value;
			val = _btnlosItmOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnlosItmIn
	{
		[CompilerGenerated]
		get
		{
			return _btnlosItmIn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnlosItmIn_Click;
			QButton val = _btnlosItmIn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnlosItmIn = value;
			val = _btnlosItmIn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrin
	{
		[CompilerGenerated]
		get
		{
			return _btnKrin;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnKrin_Click;
			QButton val = _btnKrin;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrin = value;
			val = _btnKrin;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrInout
	{
		[CompilerGenerated]
		get
		{
			return _btnKrInout;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnKrInout_Click;
			QButton val = _btnKrInout;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrInout = value;
			val = _btnKrInout;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnKrIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnKrIsu_Click;
			QButton val = _btnKrIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrIsu = value;
			val = _btnKrIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public RP_OTH_DETL()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += RP_OTH_DETL_Load;
		((Form)this).Deactivate += RP_OTH_DETL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_OTH_DETL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_OTH_DETL_KeyDown);
		((Form)this).Closed += RP_OTH_DETL_Closed;
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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected O, but got Unknown
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0675: Expected O, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Expected O, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Expected O, but got Unknown
		//IL_08bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Expected O, but got Unknown
		//IL_092c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Expected O, but got Unknown
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a18: Expected O, but got Unknown
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a90: Expected O, but got Unknown
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4d: Expected O, but got Unknown
		//IL_0bca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd4: Expected O, but got Unknown
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Expected O, but got Unknown
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1d: Expected O, but got Unknown
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Expected O, but got Unknown
		//IL_0e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e62: Expected O, but got Unknown
		//IL_0eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Expected O, but got Unknown
		//IL_0fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdc: Expected O, but got Unknown
		//IL_105c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1066: Expected O, but got Unknown
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_114e: Expected O, but got Unknown
		//IL_11cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d9: Expected O, but got Unknown
		//IL_128d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1297: Expected O, but got Unknown
		//IL_1317: Unknown result type (might be due to invalid IL or missing references)
		//IL_1321: Expected O, but got Unknown
		//IL_13a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b2: Expected O, but got Unknown
		//IL_1472: Unknown result type (might be due to invalid IL or missing references)
		//IL_147c: Expected O, but got Unknown
		//IL_14ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f6: Expected O, but got Unknown
		//IL_15aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b4: Expected O, but got Unknown
		//IL_1631: Unknown result type (might be due to invalid IL or missing references)
		//IL_163b: Expected O, but got Unknown
		//IL_16bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c9: Expected O, but got Unknown
		//IL_177a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1784: Expected O, but got Unknown
		//IL_181b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1825: Expected O, but got Unknown
		//IL_18bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c6: Expected O, but got Unknown
		//IL_1946: Unknown result type (might be due to invalid IL or missing references)
		//IL_1950: Expected O, but got Unknown
		//IL_19d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e1: Expected O, but got Unknown
		//IL_1dc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1deb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e66: Expected O, but got Unknown
		//IL_1e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_2113: Unknown result type (might be due to invalid IL or missing references)
		//IL_2137: Unknown result type (might be due to invalid IL or missing references)
		//IL_215b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2184: Unknown result type (might be due to invalid IL or missing references)
		//IL_218e: Expected O, but got Unknown
		//IL_21b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2417: Unknown result type (might be due to invalid IL or missing references)
		//IL_243b: Unknown result type (might be due to invalid IL or missing references)
		//IL_245f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2483: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b6: Expected O, but got Unknown
		//IL_24d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_273c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2760: Unknown result type (might be due to invalid IL or missing references)
		//IL_2784: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_27db: Expected O, but got Unknown
		//IL_27fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b00: Expected O, but got Unknown
		//IL_2b20: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2def: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e22: Expected O, but got Unknown
		//IL_2e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_30a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_30cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3114: Unknown result type (might be due to invalid IL or missing references)
		//IL_313d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3147: Expected O, but got Unknown
		//IL_3167: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_3412: Unknown result type (might be due to invalid IL or missing references)
		//IL_3436: Unknown result type (might be due to invalid IL or missing references)
		//IL_345f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3469: Expected O, but got Unknown
		//IL_348c: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_3713: Unknown result type (might be due to invalid IL or missing references)
		//IL_3737: Unknown result type (might be due to invalid IL or missing references)
		//IL_375b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3784: Unknown result type (might be due to invalid IL or missing references)
		//IL_378e: Expected O, but got Unknown
		//IL_37b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3851: Unknown result type (might be due to invalid IL or missing references)
		//IL_385b: Expected O, but got Unknown
		//IL_38ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_38f6: Expected O, but got Unknown
		//IL_3c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d08: Expected O, but got Unknown
		//IL_3d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_4027: Unknown result type (might be due to invalid IL or missing references)
		//IL_4031: Expected O, but got Unknown
		//IL_4054: Unknown result type (might be due to invalid IL or missing references)
		//IL_40e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_40f2: Expected O, but got Unknown
		//IL_4187: Unknown result type (might be due to invalid IL or missing references)
		//IL_4191: Expected O, but got Unknown
		//IL_420f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4219: Expected O, but got Unknown
		//IL_42ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_42f8: Expected O, but got Unknown
		//IL_4361: Unknown result type (might be due to invalid IL or missing references)
		//IL_436b: Expected O, but got Unknown
		//IL_441e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4428: Expected O, but got Unknown
		//IL_4512: Unknown result type (might be due to invalid IL or missing references)
		//IL_451c: Expected O, but got Unknown
		//IL_45aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b4: Expected O, but got Unknown
		//IL_4672: Unknown result type (might be due to invalid IL or missing references)
		//IL_467c: Expected O, but got Unknown
		//IL_4700: Unknown result type (might be due to invalid IL or missing references)
		//IL_470a: Expected O, but got Unknown
		//IL_4792: Unknown result type (might be due to invalid IL or missing references)
		//IL_479c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_OTH_DETL));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label1 = new Label();
		Label2 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label3 = new Label();
		cboCity = new ComboBox();
		lblCity = new Label();
		cboArea = new ComboBox();
		Label17 = new Label();
		tPrCode = new TextBox();
		tPrName = new TextBox();
		Label4 = new Label();
		cboItemTyp = new ComboBox();
		Label5 = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		tGrCode = new TextBox();
		tGrName = new TextBox();
		Label7 = new Label();
		PanelInOut = new Panel();
		btnKrin = new QButton();
		btnKrInout = new QButton();
		btnKrIsu = new QButton();
		btnlosItmOut = new QButton();
		btnlosItmIn = new QButton();
		btnlosItmInout = new QButton();
		BrnItmInWord = new QButton();
		BtnItmInOut = new QButton();
		BtnItmOutWord = new QButton();
		cboEmploy = new ComboBox();
		lblemp = new Label();
		PnlIt = new Panel();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DevComponents.DotNetBar.Controls.DataGridViewX();
		chkBookSelect = new CheckBox();
		cboState = new ComboBox();
		Label9 = new Label();
		tItCode = new TextBox();
		tItName = new TextBox();
		Label8 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)PanelInOut).SuspendLayout();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
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
		((Control)BtnExit).TabIndex = 25;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnDelete.ImageOptions.SvgImage");
		((Control)BtnDelete).Location = new Point(1118, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 24;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnCancel.ImageOptions.SvgImage");
		((Control)BtnCancel).Location = new Point(1021, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 23;
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
		((Control)BtnSave).TabIndex = 22;
		BtnSave.Text = "&Save";
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
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
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
		((Control)lblBook).TabIndex = 11;
		lblBook.Text = "Report All";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(475, 117);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(76, 23);
		((Control)tBookCode).TabIndex = 3;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(557, 116);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(282, 23);
		((Control)tBookName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(370, 117);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(97, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Book";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(367, 57);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "From / To Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(475, 203);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 6;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(557, 203);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(382, 201);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(85, 20);
		((Control)Label3).TabIndex = 1165;
		Label3.Text = "Party Code";
		Label3.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(475, 261);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(148, 22);
		((Control)cboCity).TabIndex = 8;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(407, 262);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(58, 19);
		((Control)lblCity).TabIndex = 1166;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(692, 262);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(147, 22);
		((Control)cboArea).TabIndex = 9;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(638, 263);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(47, 19);
		((Control)Label17).TabIndex = 1168;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPrCode).Location = new Point(475, 145);
		((TextBoxBase)tPrCode).MaxLength = 8;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(76, 23);
		((Control)tPrCode).TabIndex = 4;
		((TextBoxBase)tPrName).BackColor = Color.White;
		((Control)tPrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPrName).Location = new Point(557, 145);
		((TextBoxBase)tPrName).MaxLength = 8;
		((Control)tPrName).Name = "tPrName";
		((Control)tPrName).Size = new Size(282, 23);
		((Control)tPrName).TabIndex = 1172;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(395, 144);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(72, 20);
		((Control)Label4).TabIndex = 1171;
		Label4.Text = "Pr Code";
		Label4.TextAlign = (ContentAlignment)64;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(475, 289);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(148, 22);
		((Control)cboItemTyp).TabIndex = 10;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(370, 291);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(99, 20);
		((Control)Label5).TabIndex = 1174;
		Label5.Text = "Item Type";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(475, 87);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(76, 23);
		((Control)tLcCode).TabIndex = 2;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(557, 86);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(282, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(408, 87);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(557, 56);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(475, 56);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrCode).Location = new Point(475, 174);
		((TextBoxBase)tGrCode).MaxLength = 8;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(76, 23);
		((Control)tGrCode).TabIndex = 5;
		((TextBoxBase)tGrName).BackColor = Color.White;
		((Control)tGrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrName).Location = new Point(557, 174);
		((TextBoxBase)tGrName).MaxLength = 8;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(282, 23);
		((Control)tGrName).TabIndex = 1184;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(395, 173);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(72, 20);
		((Control)Label7).TabIndex = 1183;
		Label7.Text = "Gr Code";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)PanelInOut).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelInOut).Controls.Add((Control)(object)btnKrin);
		((Control)PanelInOut).Controls.Add((Control)(object)btnKrInout);
		((Control)PanelInOut).Controls.Add((Control)(object)btnKrIsu);
		((Control)PanelInOut).Controls.Add((Control)(object)btnlosItmOut);
		((Control)PanelInOut).Controls.Add((Control)(object)btnlosItmIn);
		((Control)PanelInOut).Controls.Add((Control)(object)btnlosItmInout);
		((Control)PanelInOut).Controls.Add((Control)(object)BrnItmInWord);
		((Control)PanelInOut).Controls.Add((Control)(object)BtnItmInOut);
		((Control)PanelInOut).Controls.Add((Control)(object)BtnItmOutWord);
		((Control)PanelInOut).Location = new Point(268, 328);
		((Control)PanelInOut).Name = "PanelInOut";
		((Control)PanelInOut).Size = new Size(712, 212);
		((Control)PanelInOut).TabIndex = 1185;
		((Control)PanelInOut).Visible = false;
		((QControl)btnKrin).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrin).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrin).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrin).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrin).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrin).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrin).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrin).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrin).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrin).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrin).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrin).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrin).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrin).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrin.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrin.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrin.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrin.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrin.Image = null;
		((QControl)btnKrin).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrin).Location = new Point(471, 140);
		((Control)btnKrin).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrin).Name = "btnKrin";
		((Control)btnKrin).Size = new Size(143, 37);
		((Control)btnKrin).TabIndex = 8;
		btnKrin.Text = "Kr Rec";
		((QControl)btnKrInout).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrInout).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrInout).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrInout).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrInout).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrInout).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrInout).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrInout).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrInout).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrInout).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrInout).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrInout).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrInout).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrInout).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrInout.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrInout.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrInout.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrInout.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrInout.Image = null;
		((QControl)btnKrInout).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrInout).Location = new Point(285, 140);
		((Control)btnKrInout).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrInout).Name = "btnKrInout";
		((Control)btnKrInout).Size = new Size(143, 37);
		((Control)btnKrInout).TabIndex = 7;
		btnKrInout.Text = "Kr In Out";
		((QControl)btnKrIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Image = null;
		((QControl)btnKrIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrIsu).Location = new Point(102, 140);
		((Control)btnKrIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrIsu).Name = "btnKrIsu";
		((Control)btnKrIsu).Size = new Size(143, 37);
		((Control)btnKrIsu).TabIndex = 6;
		btnKrIsu.Text = "Kr Isu";
		((QControl)btnlosItmOut).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnlosItmOut).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnlosItmOut).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnlosItmOut).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnlosItmOut).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnlosItmOut).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnlosItmOut).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnlosItmOut).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnlosItmOut).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnlosItmOut).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnlosItmOut).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnlosItmOut).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnlosItmOut).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnlosItmOut).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnlosItmOut.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmOut.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmOut.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmOut.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmOut.Image = null;
		((QControl)btnlosItmOut).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnlosItmOut).Location = new Point(471, 81);
		((Control)btnlosItmOut).Margin = new Padding(3, 6, 3, 6);
		((Control)btnlosItmOut).Name = "btnlosItmOut";
		((Control)btnlosItmOut).Size = new Size(143, 37);
		((Control)btnlosItmOut).TabIndex = 5;
		btnlosItmOut.Text = "Loose Itm Out";
		((QControl)btnlosItmIn).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnlosItmIn).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnlosItmIn).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnlosItmIn).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnlosItmIn).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnlosItmIn).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnlosItmIn).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnlosItmIn).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnlosItmIn).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnlosItmIn).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnlosItmIn).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnlosItmIn).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnlosItmIn).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnlosItmIn).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnlosItmIn.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmIn.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmIn.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmIn.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmIn.Image = null;
		((QControl)btnlosItmIn).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnlosItmIn).Location = new Point(102, 81);
		((Control)btnlosItmIn).Margin = new Padding(3, 6, 3, 6);
		((Control)btnlosItmIn).Name = "btnlosItmIn";
		((Control)btnlosItmIn).Size = new Size(143, 37);
		((Control)btnlosItmIn).TabIndex = 4;
		btnlosItmIn.Text = "Loose Itm In";
		((QControl)btnlosItmInout).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnlosItmInout).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnlosItmInout).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnlosItmInout).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnlosItmInout).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnlosItmInout).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnlosItmInout).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnlosItmInout).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnlosItmInout).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnlosItmInout).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnlosItmInout).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnlosItmInout).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnlosItmInout).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnlosItmInout).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnlosItmInout.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmInout.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmInout.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmInout.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnlosItmInout.Image = null;
		((QControl)btnlosItmInout).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnlosItmInout).Location = new Point(285, 81);
		((Control)btnlosItmInout).Margin = new Padding(3, 6, 3, 6);
		((Control)btnlosItmInout).Name = "btnlosItmInout";
		((Control)btnlosItmInout).Size = new Size(143, 37);
		((Control)btnlosItmInout).TabIndex = 3;
		btnlosItmInout.Text = "Loose In Out";
		((QControl)BrnItmInWord).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BrnItmInWord).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BrnItmInWord).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BrnItmInWord.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Image = null;
		((QControl)BrnItmInWord).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BrnItmInWord).Location = new Point(102, 24);
		((Control)BrnItmInWord).Margin = new Padding(3, 6, 3, 6);
		((Control)BrnItmInWord).Name = "BrnItmInWord";
		((Control)BrnItmInWord).Size = new Size(143, 37);
		((Control)BrnItmInWord).TabIndex = 0;
		BrnItmInWord.Text = "Stud Itm In";
		((QControl)BtnItmInOut).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnItmInOut).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnItmInOut).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnItmInOut.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Image = null;
		((QControl)BtnItmInOut).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnItmInOut).Location = new Point(285, 24);
		((Control)BtnItmInOut).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItmInOut).Name = "BtnItmInOut";
		((Control)BtnItmInOut).Size = new Size(143, 37);
		((Control)BtnItmInOut).TabIndex = 1;
		BtnItmInOut.Text = "Stud In Out";
		((QControl)BtnItmOutWord).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnItmOutWord).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnItmOutWord).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnItmOutWord.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Image = null;
		((QControl)BtnItmOutWord).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnItmOutWord).Location = new Point(471, 24);
		((Control)BtnItmOutWord).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItmOutWord).Name = "BtnItmOutWord";
		((Control)BtnItmOutWord).Size = new Size(143, 37);
		((Control)BtnItmOutWord).TabIndex = 2;
		BtnItmOutWord.Text = "Stud Itm Out";
		cboEmploy.AutoCompleteMode = (AutoCompleteMode)3;
		cboEmploy.AutoCompleteSource = (AutoCompleteSource)256;
		cboEmploy.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboEmploy).Font = new Font("Tahoma", 9f);
		((ListControl)cboEmploy).FormattingEnabled = true;
		((Control)cboEmploy).Location = new Point(692, 291);
		((Control)cboEmploy).Name = "cboEmploy";
		((Control)cboEmploy).Size = new Size(148, 22);
		((Control)cboEmploy).TabIndex = 1191;
		((Control)cboEmploy).Visible = false;
		((Control)lblemp).BackColor = Color.Transparent;
		((Control)lblemp).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblemp).ForeColor = Color.Black;
		lblemp.ImeMode = (ImeMode)0;
		((Control)lblemp).Location = new Point(626, 292);
		((Control)lblemp).Name = "lblemp";
		((Control)lblemp).Size = new Size(57, 19);
		((Control)lblemp).TabIndex = 1192;
		lblemp.Text = "Employ";
		lblemp.TextAlign = (ContentAlignment)64;
		((Control)lblemp).Visible = false;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(1021, 56);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1207;
		((Control)PnlIt).Visible = false;
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
		((Control)btnItCancel).Location = new Point(255, 248);
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
		((Control)btnOk).Location = new Point(106, 248);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(100, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV_ITM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITM).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val3;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val5;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((ButtonBase)chkBookSelect).BackColor = Color.Transparent;
		((Control)chkBookSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBookSelect).ForeColor = Color.Black;
		((Control)chkBookSelect).Location = new Point(859, 119);
		((Control)chkBookSelect).Name = "chkBookSelect";
		((Control)chkBookSelect).RightToLeft = (RightToLeft)0;
		((Control)chkBookSelect).Size = new Size(141, 19);
		((Control)chkBookSelect).TabIndex = 1208;
		((ButtonBase)chkBookSelect).Text = "Select Book";
		((ButtonBase)chkBookSelect).UseVisualStyleBackColor = false;
		((Control)chkBookSelect).Visible = false;
		cboState.AutoCompleteMode = (AutoCompleteMode)3;
		cboState.AutoCompleteSource = (AutoCompleteSource)256;
		cboState.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboState).Font = new Font("Tahoma", 9f);
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Location = new Point(692, 56);
		((Control)cboState).Name = "cboState";
		((Control)cboState).Size = new Size(148, 22);
		((Control)cboState).TabIndex = 1209;
		((Control)cboState).Visible = false;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(627, 57);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(58, 19);
		((Control)Label9).TabIndex = 1210;
		Label9.Text = "State";
		Label9.TextAlign = (ContentAlignment)64;
		((Control)Label9).Visible = false;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItCode).Location = new Point(475, 232);
		((TextBoxBase)tItCode).MaxLength = 8;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(76, 23);
		((Control)tItCode).TabIndex = 1211;
		((TextBoxBase)tItName).BackColor = Color.White;
		((Control)tItName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItName).Location = new Point(557, 232);
		((TextBoxBase)tItName).MaxLength = 50;
		((Control)tItName).Name = "tItName";
		((Control)tItName).Size = new Size(282, 23);
		((Control)tItName).TabIndex = 1212;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(382, 232);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(85, 20);
		((Control)Label8).TabIndex = 1213;
		Label8.Text = "It Code";
		Label8.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)tItName);
		((Control)this).Controls.Add((Control)(object)PnlIt);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)cboState);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)chkBookSelect);
		((Control)this).Controls.Add((Control)(object)PanelInOut);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)cboCity);
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
		((Control)this).Controls.Add((Control)(object)cboEmploy);
		((Control)this).Controls.Add((Control)(object)lblemp);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_OTH_DETL";
		((Form)this).Text = "Report All";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)PanelInOut).ResumeLayout(false);
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_OTH_DETL_Load(object sender, EventArgs e)
	{
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e4: Expected O, but got Unknown
		//IL_0a5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6e: Expected O, but got Unknown
		//IL_0b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b29: Expected O, but got Unknown
		//IL_0bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Expected O, but got Unknown
		//IL_0c32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3d: Expected O, but got Unknown
		//IL_0cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfe: Expected O, but got Unknown
		//IL_0d1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2c: Expected O, but got Unknown
		//IL_0d4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5a: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
		if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
		{
			tLcCode.Text = DC_Main.MLc_code;
			tLcName.Text = DC_Main.MLc_Name;
			((Control)tLcCode).Enabled = false;
			((Control)tLcName).Enabled = false;
		}
		else
		{
			tLcCode.Text = DC_Main.MLc_code;
			tLcName.Text = DC_Main.MLc_Name;
		}
		((Control)PnlIt).Left = ((Control)tGrCode).Left;
		((Control)PnlIt).Top = ((Control)tGrCode).Top;
		if (Operators.CompareString(CurRpt, "Oth Itm Rpt", false) == 0)
		{
			((Control)PanelInOut).Visible = true;
			((Control)lblemp).Visible = true;
			((Control)cboEmploy).Visible = true;
			((Control)chkBookSelect).Visible = true;
			BookMast();
		}
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
			foreach (object control3 in ((Control)PanelInOut).Controls)
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
				((Control)PanelInOut).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelInOut = PanelInOut;
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelInOut).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj9 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj10 = lblBook;
				object? obj11 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj10).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				Panel panelInOut2 = PanelInOut;
				object? obj13 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelInOut2).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
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
					foreach (object control5 in ((Control)PnlIt).Controls)
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
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_ITM).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_ITM).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_ITM).RowTemplate.Height * (1.0 + num2));
				}
			}
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
			DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				int num6 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
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
			DC_Main.RsQry = "SELECT EMP_CODE,EMP_NAME FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY EMP_CODE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboEmploy.Items.Clear();
				cboEmploy.Items.Add((object)"");
				int num7 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num7)
				{
					cboEmploy.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["EMP_CODE"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.X]["EMP_NAME"]), (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboEmploy.Items.Add((object)"");
			}
			cboEmploy.SelectedIndex = 0;
			cboItemTyp.Items.Add((object)"");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			cboItemTyp.SelectedIndex = 0;
			mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
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
		SchmType = "";
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_OTH_DETL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_OTH_DETL_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_OTH_DETL_KeyDown(object sender, KeyEventArgs e)
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
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_OTH_DETL_Closed(object sender, EventArgs e)
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
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_CODE,A.MEMB_NAME,A.SCHM_CODE FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND A.SCHM_CODE = '" + tPrCode.Text + "'"))), (object)" AND A.MEMB_CODE = '"), (object)tAcCode.Text), (object)"'"));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_CODE as MembNoL,A.MEMB_NAME As MembNameL,A.AC_MOBILE AS MobileL,A.SCHM_CODE AS SchemeL ,A.MEMB_AMT AS SchmAmtR,FORMAT(SUM(IIF(SIGN = '+',B.ADJ_AMT,- B.ADJ_AMT)),'0.00') AS MembBalR  FROM AD_MEMB AS A LEFT JOIN AD_OS AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND A.SCHM_CODE = '" + tPrCode.Text + "'"))), (object)"  GROUP BY A.MEMB_CODE,A.MEMB_NAME,A.SCHM_CODE,A.MEMB_AMT,A.AC_MOBILE ORDER BY A.SCHM_CODE,A.MEMB_CODE"));
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[7];
					DC_Main.ColWidth[0] = 100.0;
					DC_Main.ColWidth[1] = 300.0;
					DC_Main.ColWidth[2] = 150.0;
					DC_Main.ColWidth[3] = 100.0;
					DC_Main.ColWidth[4] = 120.0;
					DC_Main.ColWidth[5] = 120.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (!DC_Main.HelpClose)
					{
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							tAcCode.Text = DC_Main.ColValue[0];
							tAcName.Text = DC_Main.ColValue[1];
						}
						((Control)tAcCode).Focus();
					}
				}
				else
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)""));
					SendKeys.Send("{tab}");
				}
				return;
			}
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
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

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tPrCode.Text, "", false) == 0)
			{
				return;
			}
			DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + tPrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.PR_NAME As ProdNameL,A.PR_CODE As CodeL FROM PRODUCT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.PR_CODE";
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
						tPrCode.Text = DC_Main.ColValue[1];
						tPrName.Text = DC_Main.ColValue[0];
					}
					((Control)tPrCode).Focus();
				}
			}
			else
			{
				tPrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			((Control)cboCity).Focus();
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

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
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

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Vp Report", false) == 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tGrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.AC_NAME";
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
						tGrCode.Text = DC_Main.ColValue[1];
						tGrName.Text = DC_Main.ColValue[0];
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
			if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
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
				SendKeys.Send("{tab}");
			}
		}
	}

	private void BrnItmInWord_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OthItmStud.RPT";
		Cr.SelectionFormula = "{DM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DM_DATA.DM_SIGN} = '+' AND {DM_DATA.ENTRY_TYPE} = 'S' AND {DM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_CODE} = '" + tItCode.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'Other Item Inword Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnItmInOut_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OthItmStud.RPT";
		Cr.SelectionFormula = "{DM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DM_DATA.ENTRY_TYPE} = 'S' AND {DM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_CODE} = '" + tItCode.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'Day Wise Other Item InOut Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnItmOutWord_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OthItmStud.RPT";
		Cr.SelectionFormula = "{DM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DM_DATA.DM_SIGN} = '-' AND {DM_DATA.ENTRY_TYPE} = 'S' AND {DM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_CODE} = '" + tItCode.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'Other Item OutWord Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectAll();
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectAll();
	}

	private void chkBookSelect_Click(object sender, EventArgs e)
	{
		if (chkBookSelect.Checked)
		{
			((Control)PnlIt).Visible = true;
		}
		else
		{
			((Control)PnlIt).Visible = false;
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		if (!chkBookSelect.Checked)
		{
			return;
		}
		ScelectBook = "";
		checked
		{
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
		}
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
				((DataGridView)dGV_ITM).Columns.Add("", "CO_BOOK");
				((DataGridView)dGV_ITM).Columns[1].Width = 50;
				((DataGridView)dGV_ITM).Columns.Add("", "BOOK_NAME");
				((DataGridView)dGV_ITM).Columns[2].Width = 250;
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

	private void BtnItCancel_Click(object sender, EventArgs e)
	{
		((Control)PnlIt).Visible = false;
		ScelectBook = "";
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

	private void BtnlosItmInout_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OthItmLoose.RPT";
		Cr.SelectionFormula = "{DM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DM_DATA.ENTRY_TYPE} = 'L' AND {DM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_CODE} = '" + tItCode.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'Day Wise Other Item InOut Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnlosItmIn_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OthItmLoose.RPT";
		Cr.SelectionFormula = "{DM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DM_DATA.DM_SIGN} = '+' AND {DM_DATA.ENTRY_TYPE} = 'L' AND {DM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_CODE} = '" + tItCode.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'Other Item Inword Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnlosItmOut_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OthItmLoose.RPT";
		Cr.SelectionFormula = "{DM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DM_DATA.DM_SIGN} = '-' AND {DM_DATA.ENTRY_TYPE} = 'L' AND {DM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_CODE} = '" + tItCode.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'Other Item OutWord Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnKrIsu_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrDmIsuRec.RPT";
		Cr.SelectionFormula = "{DM_KR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_KR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_KR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula += " And {DM_KR_DATA.DM_SIGN} = '-'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Karigar Wise Other Item Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnKrin_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrDmIsuRec.RPT";
		Cr.SelectionFormula = "{DM_KR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_KR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_KR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula += " And {DM_KR_DATA.DM_SIGN} = '+'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Karigar Wise Other Item Received From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnKrInout_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrDmWtInOut.RPT";
		Cr.SelectionFormula = "{DM_KR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DM_KR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {DM_KR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DM_KR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Karigar Wise Other Item Received From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}
}
