using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxMSFlexGridLib;
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

namespace DataCareNext;

[DesignerGenerated]
public class MS_BOOK : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBkCode")]
	private TextBox _tBkCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBkName")]
	private TextBox _tBkName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchSer")]
	private TextBox _tVchSer;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCurUse")]
	private ComboBox _cboCurUse;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBkShort")]
	private TextBox _tBkShort;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItmTyp")]
	private ComboBox _cboItmTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTranInOut")]
	private ComboBox _cboTranInOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboInvoTyp")]
	private ComboBox _cboInvoTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTrnsNm")]
	private ComboBox _cboTrnsNm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

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
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tResetBook")]
	private TextBox _tResetBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDataType")]
	private TextBox _tDataType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrBook")]
	private TextBox _tTrfrBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnReSet")]
	private SimpleButton _btnReSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private bool MsgClear;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const short cSrNo = 0;

	private const short cLedrName = 1;

	private const short cAcCode = 2;

	private const short cAcName = 3;

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

	internal virtual TextBox tBkCode
	{
		[CompilerGenerated]
		get
		{
			return _tBkCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			CancelEventHandler cancelEventHandler = tBkCode_Validating;
			KeyEventHandler val = new KeyEventHandler(tBkCode_KeyDown);
			TextBox val2 = _tBkCode;
			if (val2 != null)
			{
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tBkCode = value;
			val2 = _tBkCode;
			if (val2 != null)
			{
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBkName
	{
		[CompilerGenerated]
		get
		{
			return _tBkName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			CancelEventHandler cancelEventHandler = tBkName_Validating;
			KeyEventHandler val = new KeyEventHandler(tBkName_KeyDown);
			TextBox val2 = _tBkName;
			if (val2 != null)
			{
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tBkName = value;
			val2 = _tBkName;
			if (val2 != null)
			{
				((Control)val2).Validating += cancelEventHandler;
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

	public virtual TextBox Text1
	{
		[CompilerGenerated]
		get
		{
			return _Text1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
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

	internal virtual TextBox tVchSer
	{
		[CompilerGenerated]
		get
		{
			return _tVchSer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tVchSer_KeyDown);
			TextBox val2 = _tVchSer;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tVchSer = value;
			val2 = _tVchSer;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboCurUse
	{
		[CompilerGenerated]
		get
		{
			return _cboCurUse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboCurUse;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCurUse = value;
			val2 = _cboCurUse;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBkShort
	{
		[CompilerGenerated]
		get
		{
			return _tBkShort;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			CancelEventHandler cancelEventHandler = tBkName_Validating;
			KeyEventHandler val = new KeyEventHandler(tBkName_KeyDown);
			TextBox val2 = _tBkShort;
			if (val2 != null)
			{
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tBkShort = value;
			val2 = _tBkShort;
			if (val2 != null)
			{
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).KeyDown += val;
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

	internal virtual ComboBox cboItmTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItmTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboItmTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItmTyp = value;
			val2 = _cboItmTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboTranInOut
	{
		[CompilerGenerated]
		get
		{
			return _cboTranInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboTranInOut;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboTranInOut = value;
			val2 = _cboTranInOut;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboInvoTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboInvoTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboInvoTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboInvoTyp = value;
			val2 = _cboInvoTyp;
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

	internal virtual ComboBox cboTrnsNm
	{
		[CompilerGenerated]
		get
		{
			return _cboTrnsNm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboTrnsNm_KeyDown);
			ComboBox val2 = _cboTrnsNm;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboTrnsNm = value;
			val2 = _cboTrnsNm;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox TEXT_ENTRY
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG
	{
		[CompilerGenerated]
		get
		{
			return _MSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_ClickEvent;
			EventHandler eventHandler2 = MSG_Enter;
			EventHandler eventHandler3 = MSG_EnterCell;
			EventHandler eventHandler4 = MSG_LeaveCell;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				((Control)val).Enter -= eventHandler2;
				val.EnterCell -= eventHandler3;
				val.LeaveCell -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				((Control)val).Enter += eventHandler2;
				val.EnterCell += eventHandler3;
				val.LeaveCell += eventHandler4;
			}
		}
	}

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
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val = _DGV;
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

	internal virtual TextBox tResetBook
	{
		[CompilerGenerated]
		get
		{
			return _tResetBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tResetBook_KeyDown);
			TextBox val2 = _tResetBook;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tResetBook = value;
			val2 = _tResetBook;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tDataType
	{
		[CompilerGenerated]
		get
		{
			return _tDataType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tDataType_KeyDown);
			TextBox val2 = _tDataType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tDataType = value;
			val2 = _tDataType;
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

	internal virtual TextBox tTrfrBook
	{
		[CompilerGenerated]
		get
		{
			return _tTrfrBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTrfrBook_KeyDown);
			TextBox val2 = _tTrfrBook;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTrfrBook = value;
			val2 = _tTrfrBook;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton btnReSet
	{
		[CompilerGenerated]
		get
		{
			return _btnReSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnReSet_Click;
			SimpleButton val = _btnReSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReSet = value;
			val = _btnReSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
	[AccessedThroughProperty("Label12")]
	private virtual Label _Label12;

	internal virtual Label Label12
	{
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label12 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMobilEmtry")]
	private virtual Label _lblMobilEmtry;

	internal virtual Label lblMobilEmtry
	{
		get
		{
			return _lblMobilEmtry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMobilEmtry = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobileEntry")]
	private virtual TextBox _tMobileEntry;

	internal virtual TextBox tMobileEntry
	{
		get
		{
			return _tMobileEntry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMobileEntry = value;
		}
	}

	public MS_BOOK()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_BOOK_Load;
		((Form)this).Activated += MS_BOOK_Activated;
		((Form)this).Deactivate += MS_BOOK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_BOOK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_BOOK_KeyDown);
		((Form)this).Closed += MS_BOOK_Closed;
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
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ba: Expected O, but got Unknown
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Expected O, but got Unknown
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Expected O, but got Unknown
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Expected O, but got Unknown
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Expected O, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Expected O, but got Unknown
		//IL_0aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Expected O, but got Unknown
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_0bda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be4: Expected O, but got Unknown
		//IL_0c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8b: Expected O, but got Unknown
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d04: Expected O, but got Unknown
		//IL_0da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dab: Expected O, but got Unknown
		//IL_0e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e50: Expected O, but got Unknown
		//IL_0efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f04: Expected O, but got Unknown
		//IL_0f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f67: Expected O, but got Unknown
		//IL_1080: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e2: Expected O, but got Unknown
		//IL_1145: Unknown result type (might be due to invalid IL or missing references)
		//IL_114f: Expected O, but got Unknown
		//IL_11f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1200: Expected O, but got Unknown
		//IL_1309: Unknown result type (might be due to invalid IL or missing references)
		//IL_1313: Expected O, but got Unknown
		//IL_142e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1438: Expected O, but got Unknown
		//IL_149b: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a5: Expected O, but got Unknown
		//IL_154c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1556: Expected O, but got Unknown
		//IL_15b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c3: Expected O, but got Unknown
		//IL_1695: Unknown result type (might be due to invalid IL or missing references)
		//IL_169f: Expected O, but got Unknown
		//IL_1734: Unknown result type (might be due to invalid IL or missing references)
		//IL_173e: Expected O, but got Unknown
		//IL_17bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c6: Expected O, but got Unknown
		//IL_189f: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a9: Expected O, but got Unknown
		//IL_1912: Unknown result type (might be due to invalid IL or missing references)
		//IL_191c: Expected O, but got Unknown
		//IL_19ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b5: Expected O, but got Unknown
		//IL_1a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6d: Expected O, but got Unknown
		//IL_1aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af5: Expected O, but got Unknown
		//IL_1b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b82: Expected O, but got Unknown
		//IL_1c30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3a: Expected O, but got Unknown
		//IL_1cdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce5: Expected O, but got Unknown
		//IL_1dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc7: Expected O, but got Unknown
		//IL_1e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6d: Expected O, but got Unknown
		//IL_1f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9c: Expected O, but got Unknown
		//IL_202d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2037: Expected O, but got Unknown
		//IL_20cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d6: Expected O, but got Unknown
		//IL_2183: Unknown result type (might be due to invalid IL or missing references)
		//IL_218d: Expected O, but got Unknown
		//IL_223e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2248: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_BOOK));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		tBkCode = new TextBox();
		tBkName = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Text1 = new TextBox();
		Label3 = new Label();
		Label4 = new Label();
		Label7 = new Label();
		Label8 = new Label();
		tVchSer = new TextBox();
		cboCurUse = new ComboBox();
		tBkShort = new TextBox();
		Label10 = new Label();
		cboItmTyp = new ComboBox();
		Label5 = new Label();
		cboTranInOut = new ComboBox();
		Label6 = new Label();
		cboInvoTyp = new ComboBox();
		cboTrnsNm = new ComboBox();
		MSG = new AxMSFlexGrid();
		TEXT_ENTRY = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		DGV = new DataGridViewX();
		Label9 = new Label();
		tResetBook = new TextBox();
		tDataType = new TextBox();
		Label11 = new Label();
		tTrfrBook = new TextBox();
		btnReSet = new SimpleButton();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label12 = new Label();
		lblMobilEmtry = new Label();
		tMobileEntry = new TextBox();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Book Master";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tBkCode).BackColor = Color.White;
		((Control)tBkCode).Font = new Font("Tahoma", 9f);
		((Control)tBkCode).Location = new Point(734, 69);
		((TextBoxBase)tBkCode).MaxLength = 3;
		((Control)tBkCode).Name = "tBkCode";
		((Control)tBkCode).Size = new Size(65, 22);
		((Control)tBkCode).TabIndex = 0;
		((TextBoxBase)tBkName).BackColor = Color.White;
		((Control)tBkName).Font = new Font("Tahoma", 9f);
		((Control)tBkName).Location = new Point(734, 96);
		((TextBoxBase)tBkName).MaxLength = 50;
		((Control)tBkName).Name = "tBkName";
		((Control)tBkName).Size = new Size(301, 22);
		((Control)tBkName).TabIndex = 2;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(597, 69);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(124, 20);
		((Control)Label2).TabIndex = 104;
		Label2.Text = "Book Code";
		Label2.TextAlign = (ContentAlignment)16;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(597, 95);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(127, 20);
		((Control)Label1).TabIndex = 105;
		Label1.Text = "Book Name";
		Label1.TextAlign = (ContentAlignment)16;
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		((Control)Text1).Font = new Font("Franklin Gothic Book", 11.25f);
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Location = new Point(64, 42);
		((Control)Text1).Margin = new Padding(2);
		((TextBoxBase)Text1).MaxLength = 50;
		((Control)Text1).Name = "Text1";
		((Control)Text1).RightToLeft = (RightToLeft)0;
		((Control)Text1).Size = new Size(402, 18);
		((Control)Text1).TabIndex = 13;
		Text1.Text = "SEARCH RECORD";
		Text1.TextAlign = (HorizontalAlignment)2;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(597, 150);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(127, 20);
		((Control)Label3).TabIndex = 106;
		Label3.Text = "Cur In Use";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(597, 176);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(127, 20);
		((Control)Label4).TabIndex = 107;
		Label4.Text = "Transaction Name";
		Label4.TextAlign = (ContentAlignment)16;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(597, 205);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(127, 20);
		((Control)Label7).TabIndex = 108;
		Label7.Text = "Item Type";
		Label7.TextAlign = (ContentAlignment)16;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(597, 312);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(127, 20);
		((Control)Label8).TabIndex = 109;
		Label8.Text = "Vch Serice";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchSer).BackColor = Color.White;
		((Control)tVchSer).Font = new Font("Tahoma", 9f);
		((Control)tVchSer).Location = new Point(734, 313);
		((TextBoxBase)tVchSer).MaxLength = 2;
		((Control)tVchSer).Name = "tVchSer";
		((Control)tVchSer).Size = new Size(65, 22);
		((Control)tVchSer).TabIndex = 10;
		cboCurUse.BackColor = Color.White;
		((Control)cboCurUse).Font = new Font("Tahoma", 9f);
		((ListControl)cboCurUse).FormattingEnabled = true;
		((Control)cboCurUse).Location = new Point(734, 150);
		cboCurUse.MaxLength = 3;
		((Control)cboCurUse).Name = "cboCurUse";
		((Control)cboCurUse).Size = new Size(65, 22);
		((Control)cboCurUse).TabIndex = 4;
		((TextBoxBase)tBkShort).BackColor = Color.White;
		((Control)tBkShort).Font = new Font("Tahoma", 9f);
		((Control)tBkShort).Location = new Point(734, 123);
		((TextBoxBase)tBkShort).MaxLength = 5;
		((Control)tBkShort).Name = "tBkShort";
		((Control)tBkShort).Size = new Size(65, 22);
		((Control)tBkShort).TabIndex = 3;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(597, 122);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(127, 20);
		((Control)Label10).TabIndex = 105;
		Label10.Text = "Book Short";
		Label10.TextAlign = (ContentAlignment)16;
		((Control)cboItmTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItmTyp).FormattingEnabled = true;
		((Control)cboItmTyp).Location = new Point(734, 204);
		cboItmTyp.MaxLength = 10;
		((Control)cboItmTyp).Name = "cboItmTyp";
		((Control)cboItmTyp).Size = new Size(133, 22);
		((Control)cboItmTyp).TabIndex = 6;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(597, 232);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(127, 20);
		((Control)Label5).TabIndex = 108;
		Label5.Text = "Tran In / Out";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)cboTranInOut).Font = new Font("Tahoma", 9f);
		((ListControl)cboTranInOut).FormattingEnabled = true;
		((Control)cboTranInOut).Location = new Point(734, 231);
		((Control)cboTranInOut).Name = "cboTranInOut";
		((Control)cboTranInOut).Size = new Size(133, 22);
		((Control)cboTranInOut).TabIndex = 7;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(597, 258);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(127, 20);
		((Control)Label6).TabIndex = 108;
		Label6.Text = "Invoice Type";
		Label6.TextAlign = (ContentAlignment)16;
		((Control)cboInvoTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboInvoTyp).FormattingEnabled = true;
		((Control)cboInvoTyp).Location = new Point(734, 258);
		cboInvoTyp.MaxLength = 10;
		((Control)cboInvoTyp).Name = "cboInvoTyp";
		((Control)cboInvoTyp).Size = new Size(133, 22);
		((Control)cboInvoTyp).TabIndex = 8;
		cboTrnsNm.AutoCompleteMode = (AutoCompleteMode)2;
		cboTrnsNm.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTrnsNm).Font = new Font("Tahoma", 9f);
		((ListControl)cboTrnsNm).FormattingEnabled = true;
		((Control)cboTrnsNm).Location = new Point(734, 177);
		cboTrnsNm.MaxLength = 30;
		((Control)cboTrnsNm).Name = "cboTrnsNm";
		((Control)cboTrnsNm).Size = new Size(216, 22);
		((Control)cboTrnsNm).TabIndex = 5;
		((Control)MSG).Location = new Point(548, 341);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(599, 197);
		((Control)MSG).TabIndex = 9;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)TEXT_ENTRY).Location = new Point(826, 406);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 11;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 12;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(924, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 0;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
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
		((DataGridView)DGV).GridColor = Color.FromArgb(127, 127, 127);
		((Control)DGV).Location = new Point(63, 69);
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
		((Control)DGV).Size = new Size(404, 469);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 111;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(597, 285);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(127, 20);
		((Control)Label9).TabIndex = 113;
		Label9.Text = "ReSet Book";
		Label9.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tResetBook).BackColor = Color.White;
		((Control)tResetBook).Font = new Font("Tahoma", 9f);
		((Control)tResetBook).Location = new Point(734, 286);
		((TextBoxBase)tResetBook).MaxLength = 5;
		((Control)tResetBook).Name = "tResetBook";
		((Control)tResetBook).Size = new Size(65, 22);
		((Control)tResetBook).TabIndex = 9;
		((TextBoxBase)tDataType).BackColor = Color.White;
		((Control)tDataType).Font = new Font("Tahoma", 9f);
		((Control)tDataType).Location = new Point(805, 69);
		((TextBoxBase)tDataType).MaxLength = 5;
		((Control)tDataType).Name = "tDataType";
		((Control)tDataType).Size = new Size(39, 22);
		((Control)tDataType).TabIndex = 1;
		tDataType.TextAlign = (HorizontalAlignment)2;
		((Control)tDataType).Visible = false;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(805, 288);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(71, 20);
		((Control)Label11).TabIndex = 115;
		Label11.Text = "Trfr Book";
		Label11.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tTrfrBook).BackColor = Color.White;
		((Control)tTrfrBook).Font = new Font("Tahoma", 9f);
		((Control)tTrfrBook).Location = new Point(882, 286);
		((TextBoxBase)tTrfrBook).MaxLength = 5;
		((Control)tTrfrBook).Name = "tTrfrBook";
		((Control)tTrfrBook).Size = new Size(54, 22);
		((Control)tTrfrBook).TabIndex = 114;
		((BaseStyleControl)btnReSet).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnReSet).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnReSet).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnReSet).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnReSet).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnReSet).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnReSet).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnReSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnReSet).Appearance.Options.UseForeColor = true;
		((BaseButton)btnReSet).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnReSet).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnReSet).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnReSet).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnReSet).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnReSet).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnReSet).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnReSet).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnReSet).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnReSet).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnReSet).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnReSet).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnReSet).AppearancePressed.Options.UseFont = true;
		((Control)btnReSet).Location = new Point(850, 67);
		((BaseControl)btnReSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnReSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnReSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnReSet).Name = "btnReSet";
		((Control)btnReSet).Size = new Size(185, 24);
		((Control)btnReSet).TabIndex = 1167;
		btnReSet.Text = "Reset All Book to A";
		((BaseControl)btnReSet).ToolTip = "Party Help";
		((Control)btnReSet).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(882, 313);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(54, 23);
		((Control)tEmpCode).TabIndex = 1168;
		((Control)tEmpCode).Visible = false;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(942, 313);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(205, 23);
		((Control)tEmpName).TabIndex = 1170;
		((Control)tEmpName).Visible = false;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(802, 314);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(72, 20);
		((Control)Label12).TabIndex = 1169;
		Label12.Text = "Employee";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label12).Visible = false;
		((Control)lblMobilEmtry).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblMobilEmtry).ForeColor = Color.Black;
		lblMobilEmtry.ImeMode = (ImeMode)0;
		((Control)lblMobilEmtry).Location = new Point(956, 287);
		((Control)lblMobilEmtry).Name = "lblMobilEmtry";
		((Control)lblMobilEmtry).Size = new Size(124, 20);
		((Control)lblMobilEmtry).TabIndex = 1172;
		lblMobilEmtry.Text = "With Mobile Entry";
		lblMobilEmtry.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tMobileEntry).BackColor = Color.White;
		((Control)tMobileEntry).Font = new Font("Tahoma", 9f);
		((Control)tMobileEntry).Location = new Point(1087, 286);
		((TextBoxBase)tMobileEntry).MaxLength = 1;
		((Control)tMobileEntry).Name = "tMobileEntry";
		((Control)tMobileEntry).Size = new Size(59, 22);
		((Control)tMobileEntry).TabIndex = 1171;
		tMobileEntry.TextAlign = (HorizontalAlignment)2;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)lblMobilEmtry);
		((Control)this).Controls.Add((Control)(object)tMobileEntry);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)btnReSet);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)tTrfrBook);
		((Control)this).Controls.Add((Control)(object)tDataType);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tResetBook);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)cboTrnsNm);
		((Control)this).Controls.Add((Control)(object)cboInvoTyp);
		((Control)this).Controls.Add((Control)(object)cboTranInOut);
		((Control)this).Controls.Add((Control)(object)cboItmTyp);
		((Control)this).Controls.Add((Control)(object)cboCurUse);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tVchSer);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tBkShort);
		((Control)this).Controls.Add((Control)(object)tBkCode);
		((Control)this).Controls.Add((Control)(object)tBkName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_BOOK";
		((Form)this).Text = "_u";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_BOOK_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0927: Expected O, but got Unknown
		//IL_0966: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Expected O, but got Unknown
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f8: Expected O, but got Unknown
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Expected O, but got Unknown
		//IL_0a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Expected O, but got Unknown
		//IL_0b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Expected O, but got Unknown
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Expected O, but got Unknown
		//IL_0c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Expected O, but got Unknown
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c90: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
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
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj8 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj9 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj10 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV = DGV;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj14 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj16 != null) ? ((Color)obj16) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj17 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj18 = lblBook;
				object? obj19 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj18).ForeColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj20 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj21 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj23 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj24 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj25 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj25 != null) ? ((Color)obj25) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)tBkName).Font.Size * (1.0 + num2));
				Font font = ((Control)tBkName).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
			}
			cboCurUse.Items.Add((object)"Yes");
			cboCurUse.Items.Add((object)"No");
			cboCurUse.SelectedIndex = 0;
			cboItmTyp.Items.Add((object)"All");
			cboItmTyp.Items.Add((object)"Gold");
			cboItmTyp.Items.Add((object)"Silver");
			cboItmTyp.SelectedIndex = 0;
			cboTranInOut.Items.Add((object)"Inword");
			cboTranInOut.Items.Add((object)"Outword");
			cboTranInOut.SelectedIndex = 0;
			cboInvoTyp.Items.Add((object)"Free");
			cboInvoTyp.Items.Add((object)"Tax Invoice");
			cboInvoTyp.Items.Add((object)"Mix");
			cboInvoTyp.SelectedIndex = 0;
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				((Control)Label12).Visible = true;
				((Control)tEmpCode).Visible = true;
				((Control)tEmpName).Visible = true;
			}
			DC_Main.RsQry = "SELECT MAIN_BOOK FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY MAIN_BOOK ORDER BY MAIN_BOOK ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboTrnsNm.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboTrnsNm.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["MAIN_BOOK"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboTrnsNm.Items.Add((object)"");
			}
			CLEAR_DATA();
			CurActCtrl = (Control)(object)tBkCode;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 4;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(2800.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "Account Desc";
			mSG[2] = (int)Math.Round(1300.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "AcCode";
			mSG[3] = (int)Math.Round(2800.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "AcName";
			mSG.Row = 1;
			mSG.Col = 0;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (mSG.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
				mSG = null;
			}
		}
	}

	private void MSG_Enter(object sender, EventArgs e)
	{
		if (((Control)TEXT_ENTRY).Visible)
		{
			TEXT_ENTRY.Text = MSG[MSG.Row, MSG.Col];
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (!MsgClear && !((mSG.Row == 0) | (mSG.CellWidth <= 0)))
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				if (((Control)TEXT_ENTRY).Visible)
				{
					((Control)TEXT_ENTRY).Focus();
				}
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
				Application.DoEvents();
				switch (MSG.Col)
				{
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 0:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClear && MSG.Row != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 1:
			case 2:
			case 3:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)TEXT_ENTRY.Text, "0");
				break;
			}
			((Control)TEXT_ENTRY).Visible = false;
			mSG = null;
		}
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG.Col > 1)
					{
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						mSG.Row += 1;
					}
					return;
				}
			}
			else
			{
				if (mSG.Col == 2)
				{
					if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, A.AC_GR As GroupL,B.AC_GR_NAME AS GrNameL  FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.AC_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[5];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 100.0;
							DC_Main.ColWidth[3] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[1];
									mSG[mSG.Row, 3] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
					}
					else if (mSG.Row == mSG.Rows - 1)
					{
						MSG_LeaveCell(MSG, new EventArgs());
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
					}
				}
				if ((mSG.Col == 3) | (mSG.Col == 2))
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						MSG_LeaveCell(MSG, new EventArgs());
						return;
					}
					mSG.Row += 1;
					mSG.Col = 2;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
				else
				{
					MSG.Col += 1;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
			}
			mSG = null;
		}
	}

	private void MS_BOOK_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		DGV_CLEAR();
		DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY BOOK_NAME ";
		DataView dataView = new DataView(RsMast);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).MultiSelect = false;
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV).ColumnCount = 3;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "CO_BOOK";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(260.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "BOOK_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				((DataGridView)DGV).Columns[2].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV).Columns[2].DataPropertyName = "TRFR_BOOK";
				((DataGridView)DGV).Columns[2].HeaderText = "Trfr";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
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
		}
		MainUser = DC_Main.MCo_User;
		DGV_CLEAR();
		MSG_CLEAR();
		cboCurUse.SelectedIndex = 0;
		cboTrnsNm.SelectedIndex = 0;
		cboItmTyp.SelectedIndex = 0;
		cboTranInOut.SelectedIndex = 0;
		cboInvoTyp.SelectedIndex = 0;
		((TextBoxBase)tMobileEntry).ReadOnly = false;
		((Control)cboTranInOut).Enabled = true;
		((Control)cboInvoTyp).Enabled = true;
		((TextBoxBase)tBkCode).ReadOnly = false;
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tBkCode).MaxLength = 3;
		EntryMode = "A";
		DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY CO_BOOK ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
		EntryMode = "A";
		((Control)tBkCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " CO_BOOK = '" + tBkCode.Text + "'";
		if (dataView.Count <= 0)
		{
			return;
		}
		DataView dataView2 = dataView;
		tBkCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["CO_BOOK"], (object)""));
		tBkName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["BOOK_NAME"], (object)""));
		tBkShort.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["BOOK_SNAME"], (object)""));
		if (Operators.ConditionalCompareObjectEqual(dataView2[0]["CUR_USE"], (object)"Y", false))
		{
			cboCurUse.SelectedIndex = 0;
		}
		else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["CUR_USE"], (object)"N", false))
		{
			cboCurUse.SelectedIndex = 1;
		}
		cboTrnsNm.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["MAIN_BOOK"], (object)""));
		if (Operators.ConditionalCompareObjectEqual(dataView2[0]["ITM_TYPE"], (object)"A", false))
		{
			cboItmTyp.SelectedIndex = 0;
		}
		else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["ITM_TYPE"], (object)"G", false))
		{
			cboItmTyp.SelectedIndex = 1;
		}
		else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["ITM_TYPE"], (object)"S", false))
		{
			cboItmTyp.SelectedIndex = 2;
		}
		if (Operators.ConditionalCompareObjectEqual(dataView2[0]["BOOK_INOUT"], (object)"I", false))
		{
			cboTranInOut.SelectedIndex = 0;
		}
		else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["BOOK_INOUT"], (object)"O", false))
		{
			cboTranInOut.SelectedIndex = 1;
		}
		if (Operators.ConditionalCompareObjectEqual(dataView2[0]["BOOK_TYPE"], (object)"F", false))
		{
			cboInvoTyp.SelectedIndex = 0;
		}
		else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["BOOK_TYPE"], (object)"T", false))
		{
			cboInvoTyp.SelectedIndex = 1;
		}
		else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["BOOK_TYPE"], (object)"M", false))
		{
			cboInvoTyp.SelectedIndex = 2;
		}
		tVchSer.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["BOOK_SR_NAME"], (object)""));
		tResetBook.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["RESET_BOOK"], (object)""));
		tTrfrBook.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["TRFR_BOOK"], (object)""));
		tDataType.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["DATA_TYPE"], (object)""));
		tMobileEntry.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["WITH_MOBILE_ENTRY"], (object)""));
		((TextBoxBase)tMobileEntry).ReadOnly = true;
		MainUser = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["MAIN_USER"], (object)""));
		tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["USER_EMP_CODE"], (object)""));
		DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
		DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.RsAc.Rows.Count > 0)
		{
			tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
		}
		dataView2 = null;
		MSG_CLEAR();
		checked
		{
			if (Operators.CompareString(cboTrnsNm.Text, "", false) != 0)
			{
				DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE MAIN_BOOK = '" + cboTrnsNm.Text + "'  ORDER BY SR_NO ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.RsQry = "SELECT * FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBkCode.Text + "' ORDER BY SR_NO ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.i]["SR_NO"]);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"], (object)""));
					if (DC_Main.Rshlp.Rows.Count > DC_Main.i)
					{
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["AC_CODE"], (object)""));
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["AC_NAME"], (object)""));
					}
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG.Rows -= 1;
				mSG = null;
			}
			EntryMode = "E";
			((Control)cboTranInOut).Enabled = false;
			((Control)cboInvoTyp).Enabled = false;
			((TextBoxBase)tBkCode).ReadOnly = true;
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
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
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if ((Operators.CompareString(tBkCode.Text, "218", false) == 0) | (Operators.CompareString(tBkCode.Text, "888", false) == 0) | (Operators.CompareString(tBkCode.Text, "999", false) == 0))
						{
							Interaction.MsgBox((object)"This Is a Reserve Code You Cant Use It...", (MsgBoxStyle)0, (object)null);
							((Control)tBkCode).Focus();
							goto end_IL_0001;
						}
						if (Operators.CompareString(tBkShort.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert Book Short Name", (MsgBoxStyle)0, (object)null);
							((Control)tBkShort).Focus();
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						if ((Operators.CompareString(tBkCode.Text, "", false) == 0) | (Operators.CompareString(tBkName.Text, "", false) == 0))
						{
							Interaction.MsgBox((object)"Error Found : Please Enter Book Detail First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						DC_Main.RsQry = "DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  CO_BOOK = '" + tBkCode.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  CO_BOOK = '" + tBkCode.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK  = '" + tBkCode.Text + "' ";
						RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = RsData.NewRow();
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["LC_CODE"] = DC_Main.MLc_code;
						dataRow["CO_BOOK"] = tBkCode.Text;
						dataRow["BOOK_NAME"] = tBkName.Text;
						dataRow["BOOK_SNAME"] = tBkShort.Text;
						dataRow["CUR_USE"] = Strings.Mid(cboCurUse.Text, 1, 1);
						dataRow["MAIN_BOOK"] = RuntimeHelpers.GetObjectValue(cboTrnsNm.SelectedItem);
						dataRow["ITM_TYPE"] = Strings.Mid(cboItmTyp.Text, 1, 1);
						dataRow["BOOK_INOUT"] = Strings.Mid(cboTranInOut.Text, 1, 1);
						dataRow["BOOK_TYPE"] = Strings.Mid(cboInvoTyp.Text, 1, 1);
						dataRow["BOOK_SR_NAME"] = tVchSer.Text;
						dataRow["USER_EMP_CODE"] = tEmpCode.Text;
						if (Operators.CompareString(tDataType.Text, "", false) == 0)
						{
							dataRow["DATA_TYPE"] = "A";
						}
						else
						{
							dataRow["DATA_TYPE"] = tDataType.Text;
						}
						dataRow["RESET_BOOK"] = tResetBook.Text;
						dataRow["TRFR_BOOK"] = tTrfrBook.Text;
						dataRow["WITH_MOBILE_ENTRY"] = tMobileEntry.Text;
						dataRow["MAIN_USER"] = MainUser;
						RsData.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
						RsData.Clear();
						DC_Main.RsQry = "SELECT * FROM BOOK_DETL WHERE CO_CODE  = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK  = '" + tBkCode.Text + "' ";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow2 = RsDetl.NewRow();
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							dataRow2["CO_CODE"] = DC_Main.MCo_code;
							dataRow2["LC_CODE"] = DC_Main.MLc_code;
							dataRow2["CO_BOOK"] = tBkCode.Text;
							dataRow2["BOOK_NAME"] = tBkName.Text;
							dataRow2["BOOK_SNAME"] = tBkShort.Text;
							dataRow2["BOOK_TYPE"] = Strings.Mid(cboInvoTyp.Text, 1, 1);
							dataRow2["ITM_TYPE"] = Strings.Mid(cboItmTyp.Text, 1, 1);
							dataRow2["BOOK_INOUT"] = Strings.Mid(cboTranInOut.Text, 1, 1);
							dataRow2["SR_NO"] = Conversion.Val(MSG[DC_Main.i, 0]);
							dataRow2["AC_CODE"] = MSG[DC_Main.i, 2];
							dataRow2["AC_NAME"] = MSG[DC_Main.i, 3];
							dataRow2["MAIN_BOOK"] = RuntimeHelpers.GetObjectValue(cboTrnsNm.SelectedItem);
							if (Operators.CompareString(tDataType.Text, "", false) == 0)
							{
								dataRow2["DATA_TYPE"] = "A";
							}
							else
							{
								dataRow2["DATA_TYPE"] = tDataType.Text;
							}
							dataRow2["RESET_BOOK"] = tResetBook.Text;
							RsDetl.Rows.Add(dataRow2);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
							RsDetl.Clear();
							DC_Main.i++;
						}
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						CLEAR_DATA();
						DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY CO_BOOK ";
						RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DGV_FILL();
						goto end_IL_0001;
					}
					case 1935:
						num = -1;
						switch (num2)
						{
						case 2:
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
				try0001_dispatch = 1935;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Invalid comparison between Unknown and I4
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tBkCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Product For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND CO_BOOK = '" + tBkCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Cant Delete Record This Book Code Use in Account Transection....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBkCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Cant Delete Record This Book Code Use in Stock Transection....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Book now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  CO_BOOK = '" + tBkCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  CO_BOOK = '" + tBkCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY CO_BOOK ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_BOOK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_BOOK_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "tBkName", false) != 0)
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
	}

	private void tBkCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " CO_BOOK = '" + tBkCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["BOOK_NAME"], (object)tBkName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Code already Exist in  '", dataView[0]["BOOK_NAME"]), (object)"'  Book Name... Please Change Book Code..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tBkCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tBkName_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " BOOK_NAME = '" + tBkName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["CO_BOOK"], (object)tBkCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Book Name already Exist in  '", dataView[0]["CO_BOOK"]), (object)"'  Book Code... Please Change Book Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tBkName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsMast);
				dataView.RowFilter = "BOOK_NAME Like  '" + Text1.Text + "%' OR CO_BOOK Like  '" + Text1.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).AutoGenerateColumns = false;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = "CO_BOOK";
					((DataGridView)DGV).Columns[0].HeaderText = "Code";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(260.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "BOOK_NAME";
					((DataGridView)DGV).Columns[1].HeaderText = "Name";
					((DataGridView)DGV).Columns[2].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV).Columns[2].DataPropertyName = "TRFR_BOOK";
					((DataGridView)DGV).Columns[2].HeaderText = "Trfr";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void MS_BOOK_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 79) & e.Control)
		{
			((Control)cboInvoTyp).Enabled = true;
			((Control)cboTranInOut).Enabled = true;
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void tBkName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tBkName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Error Found : Please Enter Book Name First...", (MsgBoxStyle)0, (object)null);
				((Control)tBkName).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13)
		{
			tBkCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tBkName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void cboTrnsNm_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		checked
		{
			if (Operators.CompareString(cboTrnsNm.Text, "", false) != 0)
			{
				MSG_CLEAR();
				if (Operators.CompareString(cboTrnsNm.Text, "", false) != 0)
				{
					DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE MAIN_BOOK = '" + cboTrnsNm.Text + "' AND SR_NO <> 0 ORDER BY SR_NO ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBkCode.Text + "' ORDER BY SR_NO ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (Operators.CompareString(EntryMode, "A", false) == 0 && DC_Main.Tbl.Rows.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["INOUT_TYPE"], (object)"I", false))
						{
							cboTranInOut.SelectedIndex = 0;
						}
						else
						{
							cboTranInOut.SelectedIndex = 1;
						}
					}
					DC_Main.i = 0;
					AxMSFlexGrid mSG = MSG;
					while (DC_Main.i < DC_Main.Tbl.Rows.Count)
					{
						mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.i]["SR_NO"]);
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"], (object)""));
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"], (object)""));
						if (DC_Main.Rshlp.Rows.Count > DC_Main.i + 1)
						{
							mSG[DC_Main.i + 1, 2] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["AC_CODE"]);
							mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["AC_NAME"], (object)""));
						}
						mSG.Rows += 1;
						DC_Main.i++;
					}
					mSG.Rows -= 1;
					mSG = null;
				}
			}
			SendKeys.Send("{TAB}");
		}
	}

	private void tVchSer_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && MSG.Rows > 1)
		{
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
		}
	}

	private void tBkCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13 && Operators.CompareString(tBkCode.Text, "", false) != 0)
		{
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = " CO_BOOK = '" + tBkCode.Text + "'";
			if (dataView.Count > 0)
			{
				DISPLAY_DATA();
				SendKeys.Send("{tab}");
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tBkCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tBkName).Focus();
	}

	private void MS_BOOK_Closed(object sender, EventArgs e)
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

	private void tResetBook_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tVchSer).Focus();
		}
	}

	private void tDataType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void tTrfrBook_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tVchSer).Focus();
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			((Control)tDataType).Visible = true;
			((Control)btnReSet).Visible = true;
		}
	}

	private void btnReSet_Click(object sender, EventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"All Book will Set Data Type = A permantley ?", (MsgBoxStyle)20, (object)null) == 6)
		{
			DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET DATA_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("UPDATE BOOK_DETL SET DATA_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			Interaction.MsgBox((object)"All Book Data Type A is Set ... Please Restart Sofware Again and Data Will Refresh ...", (MsgBoxStyle)0, (object)null);
			Application.Exit();
		}
	}

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
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
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}
}
