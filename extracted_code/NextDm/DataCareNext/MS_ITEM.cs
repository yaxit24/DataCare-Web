using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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

namespace DataCareNext;

[DesignerGenerated]
public class MS_ITEM : Form
{
	private IContainer components;

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
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItName")]
	private TextBox _tItName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagType")]
	private TextBox _tTagType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLbrPrc")]
	private TextBox _nLbrPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nItemRate")]
	private TextBox _nItemRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDiscPrc")]
	private TextBox _nDiscPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConPrc")]
	private TextBox _nConPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRateType")]
	private ComboBox _cboRateType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboUnit")]
	private ComboBox _cboUnit;

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
	[AccessedThroughProperty("tHsnCode")]
	private TextBox _tHsnCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOthRate")]
	private TextBox _nOthRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSafe")]
	private ComboBox _cboSafe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBagWt")]
	private TextBox _nBagWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLbrRate")]
	private TextBox _nLbrRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItUniCode")]
	private TextBox _tItUniCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcItem")]
	private TextBox _tAcItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOthRateType")]
	private ComboBox _cboOthRateType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExcel")]
	private SimpleButton _btnExcel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGhtPrc")]
	private TextBox _nGhtPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagValUpdate")]
	private SimpleButton _btnTagValUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTagLbrPrc")]
	private TextBox _nTagLbrPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTagKrWestPrc")]
	private TextBox _nTagKrWestPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTagKrTch")]
	private TextBox _nTagKrTch;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private double EmpComPrc;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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
			CancelEventHandler cancelEventHandler = tGrCode_Validating;
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
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
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
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

	internal virtual TextBox tItName
	{
		[CompilerGenerated]
		get
		{
			return _tItName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItName_KeyDown);
			CancelEventHandler cancelEventHandler = tItName_Validating;
			EventHandler eventHandler = tItName_TextChanged;
			TextBox val2 = _tItName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tItName = value;
			val2 = _tItName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			CancelEventHandler cancelEventHandler = tItCode_Validating;
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tItCode = value;
			val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).Validating += cancelEventHandler;
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
	[AccessedThroughProperty("tItType")]
	private virtual TextBox _tItType;

	internal virtual TextBox tItType
	{
		get
		{
			return _tItType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItType = value;
		}
	}

	internal virtual TextBox tTagType
	{
		[CompilerGenerated]
		get
		{
			return _tTagType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTagType_KeyDown);
			TextBox val2 = _tTagType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTagType = value;
			val2 = _tTagType;
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

	internal virtual TextBox nLbrPrc
	{
		[CompilerGenerated]
		get
		{
			return _nLbrPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nLbrPrc_KeyDown);
			TextBox val2 = _nLbrPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nLbrPrc = value;
			val2 = _nLbrPrc;
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

	internal virtual TextBox nItemRate
	{
		[CompilerGenerated]
		get
		{
			return _nItemRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nItemRate_KeyDown);
			TextBox val2 = _nItemRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nItemRate = value;
			val2 = _nItemRate;
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

	internal virtual TextBox nDiscPrc
	{
		[CompilerGenerated]
		get
		{
			return _nDiscPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDiscPrc_KeyDown);
			TextBox val2 = _nDiscPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDiscPrc = value;
			val2 = _nDiscPrc;
			if (val2 != null)
			{
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

	internal virtual TextBox nConPrc
	{
		[CompilerGenerated]
		get
		{
			return _nConPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nConPrc_KeyDown);
			TextBox val2 = _nConPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nConPrc = value;
			val2 = _nConPrc;
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

	internal virtual ComboBox cboRateType
	{
		[CompilerGenerated]
		get
		{
			return _cboRateType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboRateType_KeyDown);
			ComboBox val2 = _cboRateType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboRateType = value;
			val2 = _cboRateType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboUnit
	{
		[CompilerGenerated]
		get
		{
			return _cboUnit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboUnit_KeyDown);
			ComboBox val2 = _cboUnit;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboUnit = value;
			val2 = _cboUnit;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = PnlBotam_DoubleClick;
			PaintEventHandler val = new PaintEventHandler(PnlBotam_Paint);
			FlowLayoutPanel val2 = _PnlBotam;
			if (val2 != null)
			{
				((Control)val2).DoubleClick -= eventHandler;
				((Control)val2).Paint -= val;
			}
			_PnlBotam = value;
			val2 = _PnlBotam;
			if (val2 != null)
			{
				((Control)val2).DoubleClick += eventHandler;
				((Control)val2).Paint += val;
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
			EventHandler eventHandler = BtnPrint_Click_1;
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
	[AccessedThroughProperty("tTradType")]
	private virtual TextBox _tTradType;

	internal virtual TextBox tTradType
	{
		get
		{
			return _tTradType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTradType = value;
		}
	}

	internal virtual TextBox tHsnCode
	{
		[CompilerGenerated]
		get
		{
			return _tHsnCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHsnCode_KeyDown);
			TextBox val2 = _tHsnCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHsnCode = value;
			val2 = _tHsnCode;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboStkDisplay")]
	private virtual ComboBox _cboStkDisplay;

	internal virtual ComboBox cboStkDisplay
	{
		get
		{
			return _cboStkDisplay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboStkDisplay = value;
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

	internal virtual TextBox nOthRate
	{
		[CompilerGenerated]
		get
		{
			return _nOthRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOthRate_KeyDown);
			TextBox val2 = _nOthRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nOthRate = value;
			val2 = _nOthRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label13")]
	private virtual Label _Label13;

	internal virtual Label Label13
	{
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual ComboBox cboSafe
	{
		[CompilerGenerated]
		get
		{
			return _cboSafe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboSafe_KeyDown);
			ComboBox val2 = _cboSafe;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboSafe = value;
			val2 = _cboSafe;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nBagWt
	{
		[CompilerGenerated]
		get
		{
			return _nBagWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nBagWt_KeyDown);
			TextBox val2 = _nBagWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nBagWt = value;
			val2 = _nBagWt;
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

	internal virtual TextBox nLbrRate
	{
		[CompilerGenerated]
		get
		{
			return _nLbrRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nLbrRate_KeyDown);
			EventHandler eventHandler = nLbrRate_TextChanged;
			TextBox val2 = _nLbrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nLbrRate = value;
			val2 = _nLbrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	private virtual Label _Label16;

	internal virtual Label Label16
	{
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label16 = value;
		}
	}

	internal virtual TextBox tItUniCode
	{
		[CompilerGenerated]
		get
		{
			return _tItUniCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItUniCode_KeyDown);
			TextBox val2 = _tItUniCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItUniCode = value;
			val2 = _tItUniCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblUnicode")]
	private virtual Label _lblUnicode;

	internal virtual Label lblUnicode
	{
		get
		{
			return _lblUnicode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblUnicode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTagOthDetail")]
	private virtual CheckBox _chkTagOthDetail;

	internal virtual CheckBox chkTagOthDetail
	{
		get
		{
			return _chkTagOthDetail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkTagOthDetail = value;
		}
	}

	internal virtual TextBox tAcItem
	{
		[CompilerGenerated]
		get
		{
			return _tAcItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcItem_KeyDown);
			TextBox val2 = _tAcItem;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcItem = value;
			val2 = _tAcItem;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAcItem")]
	private virtual Label _lblAcItem;

	internal virtual Label lblAcItem
	{
		get
		{
			return _lblAcItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAcItem = value;
		}
	}

	internal virtual ComboBox cboOthRateType
	{
		[CompilerGenerated]
		get
		{
			return _cboOthRateType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboOthRateType_KeyDown);
			ComboBox val2 = _cboOthRateType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboOthRateType = value;
			val2 = _cboOthRateType;
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

	internal virtual SimpleButton btnExcel
	{
		[CompilerGenerated]
		get
		{
			return _btnExcel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnExcel_Click;
			SimpleButton val = _btnExcel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExcel = value;
			val = _btnExcel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpen")]
	private virtual OpenFileDialog _DlgOpen;

	internal virtual OpenFileDialog DlgOpen
	{
		get
		{
			return _DlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpen = value;
		}
	}

	internal virtual TextBox nGhtPrc
	{
		[CompilerGenerated]
		get
		{
			return _nGhtPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGhtPrc_KeyDown);
			TextBox val2 = _nGhtPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGhtPrc = value;
			val2 = _nGhtPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label18")]
	private virtual Label _Label18;

	internal virtual Label Label18
	{
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label18 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOthItmPosting")]
	private virtual CheckBox _chkOthItmPosting;

	internal virtual CheckBox chkOthItmPosting
	{
		get
		{
			return _chkOthItmPosting;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOthItmPosting = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOthItmWtRemove")]
	private virtual CheckBox _chkOthItmWtRemove;

	internal virtual CheckBox chkOthItmWtRemove
	{
		get
		{
			return _chkOthItmWtRemove;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOthItmWtRemove = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkLotStock")]
	private virtual CheckBox _chkLotStock;

	internal virtual CheckBox chkLotStock
	{
		get
		{
			return _chkLotStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkLotStock = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlTagValUpdate")]
	private virtual Panel _PnlTagValUpdate;

	internal virtual Panel PnlTagValUpdate
	{
		get
		{
			return _PnlTagValUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlTagValUpdate = value;
		}
	}

	internal virtual SimpleButton btnTagValUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnTagValUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTagValUpdate_Click;
			SimpleButton val = _btnTagValUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagValUpdate = value;
			val = _btnTagValUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label22")]
	private virtual Label _Label22;

	internal virtual Label Label22
	{
		get
		{
			return _Label22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label22 = value;
		}
	}

	internal virtual TextBox nTagLbrPrc
	{
		[CompilerGenerated]
		get
		{
			return _nTagLbrPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nTagLbrPrc_KeyDown);
			TextBox val2 = _nTagLbrPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nTagLbrPrc = value;
			val2 = _nTagLbrPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label19")]
	private virtual Label _Label19;

	internal virtual Label Label19
	{
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label19 = value;
		}
	}

	internal virtual TextBox nTagKrWestPrc
	{
		[CompilerGenerated]
		get
		{
			return _nTagKrWestPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nTagKrWestPrc_KeyDown);
			TextBox val2 = _nTagKrWestPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nTagKrWestPrc = value;
			val2 = _nTagKrWestPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label20")]
	private virtual Label _Label20;

	internal virtual Label Label20
	{
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label20 = value;
		}
	}

	internal virtual TextBox nTagKrTch
	{
		[CompilerGenerated]
		get
		{
			return _nTagKrTch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nTagKrTch_KeyDown);
			TextBox val2 = _nTagKrTch;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nTagKrTch = value;
			val2 = _nTagKrTch;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label21")]
	private virtual Label _Label21;

	internal virtual Label Label21
	{
		get
		{
			return _Label21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label21 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chktaxfreeItem")]
	private virtual CheckBox _chktaxfreeItem;

	internal virtual CheckBox chktaxfreeItem
	{
		get
		{
			return _chktaxfreeItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chktaxfreeItem = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkAppItem")]
	private virtual CheckBox _chkAppItem;

	internal virtual CheckBox chkAppItem
	{
		get
		{
			return _chkAppItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkAppItem = value;
		}
	}

	public MS_ITEM()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_ITEM_Load;
		((Form)this).Activated += MS_ITEM_Activated;
		((Form)this).Deactivate += MS_ITEM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_ITEM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_ITEM_KeyDown);
		((Form)this).Closed += MS_ITEM_Closed;
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
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected O, but got Unknown
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Expected O, but got Unknown
		//IL_0d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d89: Expected O, but got Unknown
		//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df6: Expected O, but got Unknown
		//IL_0e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6f: Expected O, but got Unknown
		//IL_0f40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4a: Expected O, but got Unknown
		//IL_102d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Expected O, but got Unknown
		//IL_109a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a4: Expected O, but got Unknown
		//IL_1113: Unknown result type (might be due to invalid IL or missing references)
		//IL_111d: Expected O, but got Unknown
		//IL_1180: Unknown result type (might be due to invalid IL or missing references)
		//IL_118a: Expected O, but got Unknown
		//IL_11f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Expected O, but got Unknown
		//IL_198d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1997: Expected O, but got Unknown
		//IL_19fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a04: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_ITEM));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		tPrCode = new TextBox();
		tGrCode = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Text1 = new TextBox();
		DGV = new DataGridViewX();
		Label3 = new Label();
		tItCode = new TextBox();
		Label4 = new Label();
		tItName = new TextBox();
		tPrName = new TextBox();
		tGrName = new TextBox();
		tItType = new TextBox();
		tTagType = new TextBox();
		Label6 = new Label();
		Label7 = new Label();
		nLbrPrc = new TextBox();
		Label8 = new Label();
		nItemRate = new TextBox();
		Label9 = new Label();
		nDiscPrc = new TextBox();
		Label10 = new Label();
		nConPrc = new TextBox();
		Label11 = new Label();
		cboRateType = new ComboBox();
		cboUnit = new ComboBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnExcel = new SimpleButton();
		tTradType = new TextBox();
		tHsnCode = new TextBox();
		Label5 = new Label();
		cboStkDisplay = new ComboBox();
		Label12 = new Label();
		nOthRate = new TextBox();
		Label13 = new Label();
		cboSafe = new ComboBox();
		Label14 = new Label();
		nBagWt = new TextBox();
		Label15 = new Label();
		nLbrRate = new TextBox();
		Label16 = new Label();
		tItUniCode = new TextBox();
		lblUnicode = new Label();
		chkTagOthDetail = new CheckBox();
		tAcItem = new TextBox();
		lblAcItem = new Label();
		cboOthRateType = new ComboBox();
		Label17 = new Label();
		DlgOpen = new OpenFileDialog();
		nGhtPrc = new TextBox();
		Label18 = new Label();
		chkOthItmPosting = new CheckBox();
		chkOthItmWtRemove = new CheckBox();
		chkLotStock = new CheckBox();
		PnlTagValUpdate = new Panel();
		btnTagValUpdate = new SimpleButton();
		Label22 = new Label();
		nTagLbrPrc = new TextBox();
		Label19 = new Label();
		nTagKrWestPrc = new TextBox();
		Label20 = new Label();
		nTagKrTch = new TextBox();
		Label21 = new Label();
		chktaxfreeItem = new CheckBox();
		chkAppItem = new CheckBox();
		((ISupportInitialize)DGV).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)PnlTagValUpdate).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		((TextBoxBase)tPrCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPrCode, "tPrCode");
		((Control)tPrCode).Name = "tPrCode";
		((TextBoxBase)tPrCode).ReadOnly = true;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tGrCode, "tGrCode");
		((Control)tGrCode).Name = "tGrCode";
		((TextBoxBase)tGrCode).ReadOnly = true;
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		componentResourceManager.ApplyResources(DGV, "DGV");
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DGV).StandardTab = true;
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		((TextBoxBase)tItCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tItCode, "tItCode");
		((Control)tItCode).Name = "tItCode";
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		((TextBoxBase)tItName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tItName, "tItName");
		((Control)tItName).Name = "tItName";
		((TextBoxBase)tPrName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tPrName, "tPrName");
		((Control)tPrName).Name = "tPrName";
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tGrName, "tGrName");
		((Control)tGrName).Name = "tGrName";
		((TextBoxBase)tItType).BackColor = Color.White;
		((TextBoxBase)tItType).BorderStyle = (BorderStyle)1;
		componentResourceManager.ApplyResources(tItType, "tItType");
		((Control)tItType).Name = "tItType";
		((TextBoxBase)tTagType).BackColor = Color.White;
		componentResourceManager.ApplyResources(tTagType, "tTagType");
		((Control)tTagType).Name = "tTagType";
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		componentResourceManager.ApplyResources(Label7, "Label7");
		((Control)Label7).ForeColor = Color.Black;
		((Control)Label7).Name = "Label7";
		((TextBoxBase)nLbrPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nLbrPrc, "nLbrPrc");
		((Control)nLbrPrc).Name = "nLbrPrc";
		componentResourceManager.ApplyResources(Label8, "Label8");
		((Control)Label8).ForeColor = Color.Black;
		((Control)Label8).Name = "Label8";
		((TextBoxBase)nItemRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nItemRate, "nItemRate");
		((Control)nItemRate).Name = "nItemRate";
		componentResourceManager.ApplyResources(Label9, "Label9");
		((Control)Label9).ForeColor = Color.Black;
		((Control)Label9).Name = "Label9";
		((TextBoxBase)nDiscPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nDiscPrc, "nDiscPrc");
		((Control)nDiscPrc).Name = "nDiscPrc";
		componentResourceManager.ApplyResources(Label10, "Label10");
		((Control)Label10).ForeColor = Color.Black;
		((Control)Label10).Name = "Label10";
		((TextBoxBase)nConPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nConPrc, "nConPrc");
		((Control)nConPrc).Name = "nConPrc";
		componentResourceManager.ApplyResources(Label11, "Label11");
		((Control)Label11).ForeColor = Color.Black;
		((Control)Label11).Name = "Label11";
		componentResourceManager.ApplyResources(cboRateType, "cboRateType");
		((ListControl)cboRateType).FormattingEnabled = true;
		((Control)cboRateType).Name = "cboRateType";
		cboUnit.AutoCompleteMode = (AutoCompleteMode)2;
		cboUnit.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboUnit, "cboUnit");
		((ListControl)cboUnit).FormattingEnabled = true;
		((Control)cboUnit).Name = "cboUnit";
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnExcel);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
		((BaseStyleControl)BtnExit).Appearance.Font = (Font)componentResourceManager.GetObject("BtnExit.Appearance.Font");
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnExit, "BtnExit");
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = (Font)componentResourceManager.GetObject("BtnDelete.Appearance.Font");
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		componentResourceManager.ApplyResources(BtnDelete, "BtnDelete");
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = (Font)componentResourceManager.GetObject("BtnCancel.Appearance.Font");
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = (Font)componentResourceManager.GetObject("BtnSave.Appearance.Font");
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnSave, "BtnSave");
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = (Font)componentResourceManager.GetObject("BtnPrint.Appearance.Font");
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnPrint, "BtnPrint");
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnExcel).Appearance.Font = (Font)componentResourceManager.GetObject("btnExcel.Appearance.Font");
		((BaseStyleControl)btnExcel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExcel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExcel).Appearance.Options.UseForeColor = true;
		componentResourceManager.ApplyResources(btnExcel, "btnExcel");
		((BaseControl)btnExcel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExcel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExcel).Name = "btnExcel";
		((BaseButton)btnExcel).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)tTradType).BackColor = Color.White;
		((TextBoxBase)tTradType).BorderStyle = (BorderStyle)1;
		componentResourceManager.ApplyResources(tTradType, "tTradType");
		((Control)tTradType).Name = "tTradType";
		((TextBoxBase)tHsnCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tHsnCode, "tHsnCode");
		((Control)tHsnCode).Name = "tHsnCode";
		componentResourceManager.ApplyResources(Label5, "Label5");
		((Control)Label5).ForeColor = Color.Black;
		((Control)Label5).Name = "Label5";
		cboStkDisplay.AutoCompleteMode = (AutoCompleteMode)2;
		cboStkDisplay.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboStkDisplay, "cboStkDisplay");
		((ListControl)cboStkDisplay).FormattingEnabled = true;
		((Control)cboStkDisplay).Name = "cboStkDisplay";
		componentResourceManager.ApplyResources(Label12, "Label12");
		((Control)Label12).ForeColor = Color.Black;
		((Control)Label12).Name = "Label12";
		((TextBoxBase)nOthRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nOthRate, "nOthRate");
		((Control)nOthRate).Name = "nOthRate";
		componentResourceManager.ApplyResources(Label13, "Label13");
		((Control)Label13).ForeColor = Color.Black;
		((Control)Label13).Name = "Label13";
		cboSafe.AutoCompleteMode = (AutoCompleteMode)3;
		cboSafe.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboSafe, "cboSafe");
		((ListControl)cboSafe).FormattingEnabled = true;
		((Control)cboSafe).Name = "cboSafe";
		componentResourceManager.ApplyResources(Label14, "Label14");
		((Control)Label14).ForeColor = Color.Black;
		((Control)Label14).Name = "Label14";
		((TextBoxBase)nBagWt).BackColor = Color.White;
		componentResourceManager.ApplyResources(nBagWt, "nBagWt");
		((Control)nBagWt).Name = "nBagWt";
		componentResourceManager.ApplyResources(Label15, "Label15");
		((Control)Label15).ForeColor = Color.Black;
		((Control)Label15).Name = "Label15";
		((TextBoxBase)nLbrRate).BackColor = Color.White;
		componentResourceManager.ApplyResources(nLbrRate, "nLbrRate");
		((Control)nLbrRate).Name = "nLbrRate";
		componentResourceManager.ApplyResources(Label16, "Label16");
		((Control)Label16).ForeColor = Color.Black;
		((Control)Label16).Name = "Label16";
		((TextBoxBase)tItUniCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tItUniCode, "tItUniCode");
		((Control)tItUniCode).Name = "tItUniCode";
		componentResourceManager.ApplyResources(lblUnicode, "lblUnicode");
		((Control)lblUnicode).ForeColor = Color.Black;
		((Control)lblUnicode).Name = "lblUnicode";
		((ButtonBase)chkTagOthDetail).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkTagOthDetail, "chkTagOthDetail");
		((Control)chkTagOthDetail).ForeColor = Color.Black;
		((Control)chkTagOthDetail).Name = "chkTagOthDetail";
		((ButtonBase)chkTagOthDetail).UseVisualStyleBackColor = false;
		((TextBoxBase)tAcItem).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcItem, "tAcItem");
		((Control)tAcItem).Name = "tAcItem";
		componentResourceManager.ApplyResources(lblAcItem, "lblAcItem");
		((Control)lblAcItem).ForeColor = Color.Black;
		((Control)lblAcItem).Name = "lblAcItem";
		cboOthRateType.DropDownStyle = (ComboBoxStyle)2;
		componentResourceManager.ApplyResources(cboOthRateType, "cboOthRateType");
		((ListControl)cboOthRateType).FormattingEnabled = true;
		((Control)cboOthRateType).Name = "cboOthRateType";
		componentResourceManager.ApplyResources(Label17, "Label17");
		((Control)Label17).ForeColor = Color.Black;
		((Control)Label17).Name = "Label17";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((TextBoxBase)nGhtPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nGhtPrc, "nGhtPrc");
		((Control)nGhtPrc).Name = "nGhtPrc";
		componentResourceManager.ApplyResources(Label18, "Label18");
		((Control)Label18).ForeColor = Color.Black;
		((Control)Label18).Name = "Label18";
		((ButtonBase)chkOthItmPosting).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkOthItmPosting, "chkOthItmPosting");
		((Control)chkOthItmPosting).ForeColor = Color.Black;
		((Control)chkOthItmPosting).Name = "chkOthItmPosting";
		((ButtonBase)chkOthItmPosting).UseVisualStyleBackColor = false;
		((ButtonBase)chkOthItmWtRemove).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkOthItmWtRemove, "chkOthItmWtRemove");
		((Control)chkOthItmWtRemove).ForeColor = Color.Black;
		((Control)chkOthItmWtRemove).Name = "chkOthItmWtRemove";
		((ButtonBase)chkOthItmWtRemove).UseVisualStyleBackColor = false;
		((ButtonBase)chkLotStock).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkLotStock, "chkLotStock");
		((Control)chkLotStock).ForeColor = Color.Black;
		((Control)chkLotStock).Name = "chkLotStock";
		((ButtonBase)chkLotStock).UseVisualStyleBackColor = false;
		PnlTagValUpdate.BorderStyle = (BorderStyle)1;
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)btnTagValUpdate);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)Label22);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)nTagLbrPrc);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)Label19);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)nTagKrWestPrc);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)Label20);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)nTagKrTch);
		((Control)PnlTagValUpdate).Controls.Add((Control)(object)Label21);
		componentResourceManager.ApplyResources(PnlTagValUpdate, "PnlTagValUpdate");
		((Control)PnlTagValUpdate).Name = "PnlTagValUpdate";
		((BaseStyleControl)btnTagValUpdate).Appearance.Font = (Font)componentResourceManager.GetObject("btnTagValUpdate.Appearance.Font");
		((BaseStyleControl)btnTagValUpdate).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTagValUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagValUpdate).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnTagValUpdate.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnTagValUpdate.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(btnTagValUpdate, "btnTagValUpdate");
		((BaseControl)btnTagValUpdate).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTagValUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagValUpdate).Name = "btnTagValUpdate";
		((BaseButton)btnTagValUpdate).ToolTipAnchor = (ToolTipAnchor)1;
		componentResourceManager.ApplyResources(Label22, "Label22");
		((Control)Label22).ForeColor = Color.Maroon;
		((Control)Label22).Name = "Label22";
		((TextBoxBase)nTagLbrPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nTagLbrPrc, "nTagLbrPrc");
		((Control)nTagLbrPrc).Name = "nTagLbrPrc";
		componentResourceManager.ApplyResources(Label19, "Label19");
		((Control)Label19).ForeColor = Color.Black;
		((Control)Label19).Name = "Label19";
		((TextBoxBase)nTagKrWestPrc).BackColor = Color.White;
		componentResourceManager.ApplyResources(nTagKrWestPrc, "nTagKrWestPrc");
		((Control)nTagKrWestPrc).Name = "nTagKrWestPrc";
		componentResourceManager.ApplyResources(Label20, "Label20");
		((Control)Label20).ForeColor = Color.Black;
		((Control)Label20).Name = "Label20";
		((TextBoxBase)nTagKrTch).BackColor = Color.White;
		componentResourceManager.ApplyResources(nTagKrTch, "nTagKrTch");
		((Control)nTagKrTch).Name = "nTagKrTch";
		componentResourceManager.ApplyResources(Label21, "Label21");
		((Control)Label21).ForeColor = Color.Black;
		((Control)Label21).Name = "Label21";
		((ButtonBase)chktaxfreeItem).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chktaxfreeItem, "chktaxfreeItem");
		((Control)chktaxfreeItem).ForeColor = Color.Black;
		((Control)chktaxfreeItem).Name = "chktaxfreeItem";
		((ButtonBase)chktaxfreeItem).UseVisualStyleBackColor = false;
		((ButtonBase)chkAppItem).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkAppItem, "chkAppItem");
		((Control)chkAppItem).ForeColor = Color.Black;
		((Control)chkAppItem).Name = "chkAppItem";
		((ButtonBase)chkAppItem).UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)chkAppItem);
		((Control)this).Controls.Add((Control)(object)chktaxfreeItem);
		((Control)this).Controls.Add((Control)(object)PnlTagValUpdate);
		((Control)this).Controls.Add((Control)(object)chkLotStock);
		((Control)this).Controls.Add((Control)(object)chkOthItmWtRemove);
		((Control)this).Controls.Add((Control)(object)nGhtPrc);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)cboOthRateType);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)lblAcItem);
		((Control)this).Controls.Add((Control)(object)tAcItem);
		((Control)this).Controls.Add((Control)(object)chkTagOthDetail);
		((Control)this).Controls.Add((Control)(object)lblUnicode);
		((Control)this).Controls.Add((Control)(object)tItUniCode);
		((Control)this).Controls.Add((Control)(object)nLbrRate);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)nBagWt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)cboSafe);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nOthRate);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)cboStkDisplay);
		((Control)this).Controls.Add((Control)(object)tHsnCode);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tTradType);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)cboUnit);
		((Control)this).Controls.Add((Control)(object)cboRateType);
		((Control)this).Controls.Add((Control)(object)nItemRate);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nDiscPrc);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)nConPrc);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)nLbrPrc);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tTagType);
		((Control)this).Controls.Add((Control)(object)tItType);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)tItName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)chkOthItmPosting);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_ITEM";
		((ISupportInitialize)DGV).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)PnlTagValUpdate).ResumeLayout(false);
		((Control)PnlTagValUpdate).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_ITEM_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0854: Unknown result type (might be due to invalid IL or missing references)
		//IL_085b: Expected O, but got Unknown
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Expected O, but got Unknown
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Expected O, but got Unknown
		//IL_0b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b29: Expected O, but got Unknown
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a14: Expected O, but got Unknown
		//IL_0a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Expected O, but got Unknown
		//IL_0a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Expected O, but got Unknown
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba6: Expected O, but got Unknown
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
				TextBox obj8 = tPrName;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				TextBox obj10 = tGrName;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj12 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV = DGV;
				object? obj13 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj14 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				TextBox obj15 = tPrName;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj15).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				TextBox obj17 = tGrName;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj17).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj19 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj20 = lblBook;
				object? obj21 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj20).ForeColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj22 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj23 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj24 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((TextBoxBase)tPrName).BackColor = Color.Cornsilk;
				((TextBoxBase)tGrName).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
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
					foreach (object control4 in ((Control)PnlTagValUpdate).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
			}
			cboRateType.Items.Add((object)"Gram Wise");
			cboRateType.Items.Add((object)"10Gm Wise");
			cboRateType.Items.Add((object)"Kg Wise");
			cboRateType.Items.Add((object)"Pcs Wise");
			cboRateType.SelectedIndex = 0;
			cboStkDisplay.Items.Add((object)"Yes");
			cboStkDisplay.Items.Add((object)"No");
			cboStkDisplay.SelectedIndex = 0;
			cboOthRateType.Items.Add((object)"Weight");
			cboOthRateType.Items.Add((object)"Pcs");
			cboOthRateType.Items.Add((object)"Fix");
			cboOthRateType.SelectedIndex = 0;
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)lblUnicode).Visible = true;
				((Control)tItUniCode).Visible = true;
				((Control)chktaxfreeItem).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsOthItmWtRemove, "Y", false) == 0)
			{
				((Control)chkOthItmWtRemove).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				((Control)chkTagOthDetail).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				((Control)chkOthItmPosting).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0)
			{
				((Control)lblAcItem).Visible = true;
				((Control)tAcItem).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0)
			{
				((Control)chkLotStock).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
			{
				((Control)chkAppItem).Visible = true;
			}
			((Control)PnlTagValUpdate).Left = ((Control)Label14).Left + 5;
			((Control)PnlTagValUpdate).Top = ((Control)Label14).Top - 7;
			DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_NAME ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			AddCboItem();
			DGV_FILL();
			EntryMode = "A";
			CurActCtrl = (Control)(object)tPrCode;
		}
	}

	private void MS_ITEM_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		DGV_CLEAR();
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
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "IT_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(230.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "IT_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				((DataGridView)DGV).Columns[2].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[2].DataPropertyName = "SAFE_NAME";
				((DataGridView)DGV).Columns[2].HeaderText = "Safe";
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
		AddCboItem();
		DGV_FILL();
		cboUnit.SelectedIndex = 0;
		cboRateType.SelectedIndex = 0;
		cboStkDisplay.SelectedIndex = 0;
		cboSafe.SelectedIndex = 0;
		cboOthRateType.SelectedIndex = 0;
		EmpComPrc = 0.0;
		chkTagOthDetail.Checked = false;
		chkOthItmPosting.Checked = false;
		chkOthItmWtRemove.Checked = false;
		chkLotStock.Checked = false;
		chktaxfreeItem.Checked = false;
		chkAppItem.Checked = false;
		cboSafe.Text = "MAIN";
		Text1.Text = "SEARCH RECORD";
		EntryMode = "A";
		((Control)tPrCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " IT_CODE = '" + tItCode.Text + "'";
		CLEAR_DATA();
		if (dataView.Count > 0)
		{
			DataView dataView2 = dataView;
			tPrCode.Text = Conversions.ToString(dataView2[0]["PR_CODE"]);
			DC_Main.RsQry = "SELECT PR_NAME FROM PRODUCT_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND PR_CODE = '" + tPrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tPrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_NAME"], (object)""));
			}
			tGrCode.Text = Conversions.ToString(dataView2[0]["GR_CODE"]);
			DC_Main.RsQry = "SELECT GR_NAME FROM GROUP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND GR_CODE = '" + tGrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
			}
			tItCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["IT_CODE"], (object)""));
			tItName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["IT_NAME"], (object)""));
			cboSafe.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["SAFE_NAME"], (object)""));
			tHsnCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["HSN_CODE"], (object)""));
			tItType.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["IT_TYPE"], (object)""));
			tTagType.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["TAG_TYPE"], (object)""));
			tTradType.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["TRAD_TYPE"], (object)""));
			cboUnit.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["UNIT_NAME"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(dataView2[0]["RATE_TYPE"], (object)"G", false))
			{
				cboRateType.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["RATE_TYPE"], (object)"1", false))
			{
				cboRateType.SelectedIndex = 1;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["RATE_TYPE"], (object)"K", false))
			{
				cboRateType.SelectedIndex = 2;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["RATE_TYPE"], (object)"P", false))
			{
				cboRateType.SelectedIndex = 3;
			}
			if (Operators.ConditionalCompareObjectEqual(dataView2[0]["STK_DISPLAY"], (object)"N", false))
			{
				cboStkDisplay.SelectedIndex = 1;
			}
			else
			{
				cboStkDisplay.SelectedIndex = 0;
			}
			if (Operators.ConditionalCompareObjectEqual(dataView2[0]["OTH_RATE_TYPE"], (object)"P", false))
			{
				cboOthRateType.SelectedIndex = 1;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["OTH_RATE_TYPE"], (object)"F", false))
			{
				cboOthRateType.SelectedIndex = 2;
			}
			else
			{
				cboOthRateType.SelectedIndex = 0;
			}
			TextBox obj = nLbrPrc;
			DataRowView dataRowView;
			object Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_PRC"]);
			double num = DC_Main.Fnv(ref Value);
			dataRowView["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			obj.Text = Strings.Format((object)num, "0.00");
			TextBox obj2 = nLbrRate;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["IT_LBR_RATE"]);
			double num2 = DC_Main.Fnv(ref Value);
			dataRowView["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
			obj2.Text = Strings.Format((object)num2, "0.00");
			TextBox obj3 = nConPrc;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["CON_PRC"]);
			double num3 = DC_Main.Fnv(ref Value);
			dataRowView["CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			obj3.Text = Strings.Format((object)num3, "0.00");
			TextBox obj4 = nDiscPrc;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["DISC_PRC"]);
			double num4 = DC_Main.Fnv(ref Value);
			dataRowView["DISC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			obj4.Text = Strings.Format((object)num4, "0.00");
			TextBox obj5 = nItemRate;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITEM_RATE"]);
			double num5 = DC_Main.Fnv(ref Value);
			dataRowView["ITEM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
			obj5.Text = Strings.Format((object)num5, "0.00");
			TextBox obj6 = nOthRate;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["OTH_RATE"]);
			double num6 = DC_Main.Fnv(ref Value);
			dataRowView["OTH_RATE"] = RuntimeHelpers.GetObjectValue(Value);
			obj6.Text = Strings.Format((object)num6, "0.00");
			TextBox obj7 = nBagWt;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["IT_BAG_WT"]);
			double num7 = DC_Main.Fnv(ref Value);
			dataRowView["IT_BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
			obj7.Text = Strings.Format((object)num7, "0.0000");
			TextBox obj8 = nGhtPrc;
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["IT_GHT_PRC"]);
			double num8 = DC_Main.Fnv(ref Value);
			dataRowView["IT_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			obj8.Text = Strings.Format((object)num8, "0.00");
			Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["EMP_COM_PRC"]);
			double num9 = DC_Main.Fnv(ref Value);
			dataRowView["EMP_COM_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			EmpComPrc = Conversions.ToDouble(Strings.Format((object)num9, "0.00"));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["MAIN_USER"], (object)""));
			tItUniCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["UNICODE_NAME"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["TAG_IDTL_COL"], (object)""), (object)"Y", false))
			{
				chkTagOthDetail.Checked = true;
			}
			else
			{
				chkTagOthDetail.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["OTH_DETL_POSTING"], (object)""), (object)"Y", false))
			{
				chkOthItmPosting.Checked = true;
			}
			else
			{
				chkOthItmPosting.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["OTH_ITM_WT_REMOVE"], (object)""), (object)"Y", false))
			{
				chkOthItmWtRemove.Checked = true;
			}
			else
			{
				chkOthItmWtRemove.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["ITM_WITH_LOT_STK"], (object)""), (object)"Y", false))
			{
				chkLotStock.Checked = true;
			}
			else
			{
				chkLotStock.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["TAX_FREE_ITEM"], (object)""), (object)"Y", false))
			{
				chktaxfreeItem.Checked = true;
			}
			else
			{
				chktaxfreeItem.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["APP_ITEM"], (object)""), (object)"Y", false))
			{
				chkAppItem.Checked = true;
			}
			else
			{
				chkAppItem.Checked = false;
			}
			tAcItem.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["AC_ITEM"], (object)""));
			dataView2 = null;
			EntryMode = "E";
			((TextBoxBase)tPrCode).ReadOnly = true;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void MS_ITEM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_ITEM_KeyPress(object sender, KeyPressEventArgs e)
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
			SendKeys.Send("{tab}");
		}
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_FILL();
		}
		else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = "IT_NAME Like  '" + Text1.Text + "%' OR  IT_CODE Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 80;
				((DataGridView)DGV).Columns[0].DataPropertyName = "IT_CODE";
				((DataGridView)DGV).Columns[1].Width = 320;
				((DataGridView)DGV).Columns[1].DataPropertyName = "IT_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_ITEM_KeyDown(object sender, KeyEventArgs e)
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
			((Control)btnExcel).Visible = true;
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
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
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if (chkTagOthDetail.Checked)
					{
						DC_Main.RsQry = "SELECT IT_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "' AND TAG_IDTL_COL = 'Y' ORDER BY IT_CODE";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT IT_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_IDTL_COL = 'Y'  ORDER BY IT_CODE";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 3)
							{
								Interaction.MsgBox((object)"You Cant Add Other Detail Column More Then 4... Please Remove Old Item Then Try...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
								goto end_IL_0001;
							}
						}
					}
					if (Operators.CompareString(tPrCode.Text, "", false) == 0)
					{
						Interaction.MsgBox((object)"Product Code Is Null Please Create Item Again..", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						((Control)tPrCode).Focus();
						goto end_IL_0001;
					}
					if (Operators.CompareString(tGrCode.Text, "", false) == 0)
					{
						Interaction.MsgBox((object)"Group Code Is Null Please Create Item Again..", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						((Control)tGrCode).Focus();
						goto end_IL_0001;
					}
					if (Operators.CompareString(tItCode.Text, "", false) == 0)
					{
						Interaction.MsgBox((object)"Item Code Is Null Please Create Item Again..", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						((Control)tGrCode).Focus();
						goto end_IL_0001;
					}
					DC_Main.RsQry = "DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM ITEM_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = DC_Main.Rshlp.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["PR_CODE"] = tPrCode.Text;
					dataRow["GR_CODE"] = tGrCode.Text;
					dataRow["IT_CODE"] = tItCode.Text;
					dataRow["IT_TYPE"] = tItType.Text;
					dataRow["TAG_TYPE"] = tTagType.Text;
					dataRow["TRAD_TYPE"] = tTradType.Text;
					dataRow["IT_NAME"] = tItName.Text;
					dataRow["SAFE_NAME"] = cboSafe.Text;
					dataRow["HSN_CODE"] = tHsnCode.Text;
					dataRow["UNIT_NAME"] = cboUnit.Text;
					dataRow["RATE_TYPE"] = Strings.Mid(cboRateType.Text, 1, 1);
					dataRow["STK_DISPLAY"] = Strings.Mid(cboStkDisplay.Text, 1, 1);
					dataRow["LBR_PRC"] = Conversion.Val(nLbrPrc.Text);
					dataRow["IT_LBR_RATE"] = Conversion.Val(nLbrRate.Text);
					dataRow["CON_PRC"] = Conversion.Val(nConPrc.Text);
					dataRow["DISC_PRC"] = Conversion.Val(nDiscPrc.Text);
					dataRow["ITEM_RATE"] = Conversion.Val(nItemRate.Text);
					dataRow["OTH_RATE"] = Conversion.Val(nOthRate.Text);
					dataRow["IT_BAG_WT"] = Conversion.Val(nBagWt.Text);
					dataRow["MAIN_USER"] = MainUser;
					dataRow["UNICODE_NAME"] = tItUniCode.Text;
					dataRow["TAG_IDTL_COL"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkTagOthDetail.Checked, (object)"Y", (object)"N"));
					dataRow["AC_ITEM"] = tAcItem.Text;
					dataRow["OTH_RATE_TYPE"] = Strings.Mid(cboOthRateType.Text, 1, 1);
					dataRow["IT_GHT_PRC"] = Conversion.Val(nGhtPrc.Text);
					dataRow["OTH_DETL_POSTING"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkOthItmPosting.Checked, (object)"Y", (object)"N"));
					dataRow["OTH_ITM_WT_REMOVE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkOthItmWtRemove.Checked, (object)"Y", (object)"N"));
					dataRow["ITM_WITH_LOT_STK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkLotStock.Checked, (object)"Y", (object)"N"));
					dataRow["TAX_FREE_ITEM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chktaxfreeItem.Checked, (object)"Y", (object)"N"));
					dataRow["APP_ITEM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkAppItem.Checked, (object)"Y", (object)"N"));
					dataRow["EMP_COM_PRC"] = EmpComPrc;
					DC_Main.Rshlp.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
					DC_Main.Rshlp.Clear();
					Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					CLEAR_DATA();
					DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_NAME ";
					RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DGV_FILL();
					goto end_IL_0001;
				}
				case 1787:
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
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1787;
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
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Invalid comparison between Unknown and I4
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Can't Delete Record This Item Use in Transaction....", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		switch (tItCode.Text)
		{
		case "SN":
		case "RD":
		case "OS":
		case "OG":
		case "OE":
		case "HM":
		case "FSL":
		case "DM":
		case "24CT":
		case "999":
		case "ORG":
		case "ORS":
		case "ORD":
		case "OO":
			Interaction.MsgBox((object)"You Cant Delete Record This Item Code Is Default Code....", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		if (Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Item For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  IT_CODE = '" + tItCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_NAME ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		DC_Main.RptName = "ItemMast";
		DC_Main.RptFormula = "{ITEM_MAST.CO_CODE}= '" + DC_Main.MCo_code + "' ";
		UT_REPORT uT_REPORT = new UT_REPORT();
		((Control)uT_REPORT).Show();
		((Control)uT_REPORT).Focus();
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
			tPrCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tGrCode).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tItCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tItName).Focus();
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
					tItType.Text = DC_Main.ColValue[2];
					tTagType.Text = DC_Main.ColValue[2];
					tTradType.Text = DC_Main.ColValue[3];
				}
				tItCode.Text = tPrCode.Text + tGrCode.Text;
				tItName.Text = tPrName.Text + " " + tGrCode.Text;
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
			tItType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_TYPE"], (object)""));
			tTagType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_TYPE"], (object)""));
			tTradType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TRAD_TYPE"], (object)""));
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				tItCode.Text = tPrCode.Text + tGrCode.Text;
			}
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				tItName.Text = tPrName.Text + " " + tGrCode.Text;
			}
			SendKeys.Send("{tab}");
		}
	}

	private void tGrCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		if (Operators.CompareString(EntryMode, "E", false) == 0)
		{
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				SendKeys.Send("{tab}");
			}
			else
			{
				((Control)tGrCode).Focus();
			}
			return;
		}
		bool cancel = e.Cancel;
		DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			if ((int)Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Item already Exist in  '", DC_Main.Rshlp.Rows[0]["IT_NAME"]), (object)"' Item Name...You Want to Creat New Item..."), (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)
			{
				cancel = false;
				tItCode.Text = "";
				tItName.Text = "";
			}
			else
			{
				((TextBoxBase)tGrCode).ReadOnly = false;
				tGrCode.Text = "";
				tGrName.Text = "";
				tItCode.Text = "";
				tItName.Text = "";
				((Control)tGrCode).Focus();
				cancel = true;
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tItCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = "IT_CODE = '" + tItCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["IT_NAME"], (object)tItName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Item Code already Exist in  '", dataView[0]["IT_NAME"]), (object)"'  Item Name...Please Change It Code..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tItCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tTagType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tItName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tItName.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboRateType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nLbrPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nLbrPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nLbrPrc.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nConPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nConPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nConPrc.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nDiscPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDiscPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDiscPrc.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nItemRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nItemRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nItemRate.Text)), "0.00");
			((Control)nOthRate).Focus();
		}
	}

	private void tItName_Validating(object sender, CancelEventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tItName.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Item Name", (MsgBoxStyle)0, (object)null);
			((Control)tItName).Focus();
		}
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " IT_NAME = '" + tItName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["IT_CODE"], (object)tItCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Item Code already Exist in  '", dataView[0]["IT_CODE"]), (object)"'  Item Name...Please Change It Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tItName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void AddCboItem()
	{
		cboUnit.Items.Clear();
		DC_Main.RsQry = "SELECT UNIT_NAME FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY UNIT_NAME ORDER BY UNIT_NAME ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					cboUnit.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["UNIT_NAME"], (object)""));
					DC_Main.X++;
				}
				cboUnit.SelectedIndex = 0;
			}
			else
			{
				cboUnit.Items.Add((object)"");
			}
			cboSafe.Items.Clear();
			DC_Main.RsQry = "SELECT SAFE_NAME FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY SAFE_NAME ORDER BY SAFE_NAME ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num2 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num2)
				{
					cboSafe.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["SAFE_NAME"], (object)""));
					DC_Main.X++;
				}
				cboSafe.SelectedIndex = 0;
				cboSafe.Text = "MAIN";
			}
			else
			{
				cboSafe.Items.Add((object)"");
			}
		}
	}

	private void cboUnit_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void MS_ITEM_Closed(object sender, EventArgs e)
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

	private void BtnPrint_Click_1(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void tHsnCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nOthRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nOthRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nOthRate.Text)), "0.00");
			SendKeys.Send("{tab}");
		}
	}

	private void cboSafe_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nBagWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nBagWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nBagWt.Text)), "0.0000");
			if (((Control)tItUniCode).Visible)
			{
				((Control)tItUniCode).Focus();
			}
			else
			{
				((Control)BtnSave).Focus();
			}
		}
	}

	private void nLbrRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nLbrRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nLbrRate.Text)), "0.00");
			SendKeys.Send("{tab}");
		}
	}

	private void tItUniCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void tAcItem_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tAcItem.Text + "'";
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
					tAcItem.Text = DC_Main.ColValue[1];
				}
				((Control)tAcItem).Focus();
			}
		}
		else
		{
			tAcItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_CODE"], (object)""));
			((Control)tItName).Focus();
		}
	}

	private void cboOthRateType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private static DataTable ImportExceltoDatatable(string filepath)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		DataTable result;
		try
		{
			DataSet dataSet = new DataSet();
			string text = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
			OleDbConnection val = new OleDbConnection(text ?? "");
			val.Open();
			object objectValue = RuntimeHelpers.GetObjectValue(val.GetSchema("Tables").Rows[0]["TABLE_NAME"]);
			string text2 = $"SELECT * FROM [{RuntimeHelpers.GetObjectValue(objectValue)}]";
			OleDbDataAdapter val2 = new OleDbDataAdapter(text2, val);
			((DbDataAdapter)(object)val2).Fill(dataSet);
			dataTable = dataSet.Tables[0];
			result = dataTable;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)Information.Err().Description, (MsgBoxStyle)16, (object)null);
			result = dataTable;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void btnExcel_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure Import Item Master....?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		((FileDialog)DlgOpen).Filter = "Excel files |*.xls;*.xlsx";
		((FileDialog)DlgOpen).Title = "Open File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
		{
			return;
		}
		DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpen).FileName);
		int num = 0;
		checked
		{
			int num2 = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num2)
			{
				string text = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][0], (object)"")), 1, 40) ?? "");
				if (Operators.CompareString(text, "", false) != 0)
				{
					DC_Main.RsQry = "SELECT PR_NAME FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_NAME = '" + text + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						num++;
						DC_Main.RsQry = "INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR)  VALUES  ('" + DC_Main.MCo_code + "','" + Strings.Format((object)num, "00") + "','" + text + "','ABC','N')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
				}
				string text2 = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][1], (object)"")), 1, 3) ?? "");
				if (Operators.CompareString(text2, "", false) != 0)
				{
					DC_Main.RsQry = "SELECT GR_CODE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + text2 + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						DC_Main.RsQry = "INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT, DAY_OP_PCS,DAY_OP_WT,DAY_CL_PCS,DAY_CL_WT,RATE_DISPLAY,DATA_TRFR,OP_TOUCH,OP_FINE)  VALUES  ('" + DC_Main.MCo_code + "','" + text2 + "','" + text2 + " Silver Item','S','SL',0,0,0,  0,0,'00004','00009','7113','ABC',0,0,0,0,  0,0,0,0,'N','N',0,0)";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
				}
				DC_Main.i++;
			}
			Interaction.MsgBox((object)"Data is Import Ok....", (MsgBoxStyle)0, (object)null);
			Application.Exit();
		}
	}

	private void nGhtPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nGhtPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGhtPrc.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		if (((Control)PnlTagValUpdate).Visible)
		{
			((Control)PnlTagValUpdate).Visible = false;
			((Control)tItName).Focus();
		}
		else
		{
			((Control)PnlTagValUpdate).Visible = true;
			((Control)nTagLbrPrc).Focus();
		}
	}

	private void nTagLbrPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nTagLbrPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nTagLbrPrc.Text)), "0.00");
			((Control)nTagKrTch).Focus();
		}
	}

	private void nTagKrTch_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nTagKrTch.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nTagKrTch.Text)), "0.00");
			((Control)nTagKrWestPrc).Focus();
		}
	}

	private void nTagKrWestPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nTagKrWestPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nTagKrWestPrc.Text)), "0.00");
			((Control)btnTagValUpdate).Focus();
		}
	}

	private void btnTagValUpdate_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Update This Item Tag With New Value... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		if (Conversion.Val(nTagLbrPrc.Text) != 0.0)
		{
			DC_Main.RsQry = "UPDATE BAR_DETL SET LBR_PRC = " + Conversions.ToString(Conversion.Val(nTagLbrPrc.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + tItCode.Text + "' AND LBR_PRC = 0 AND TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_SIGN = '-' AND A.TAG_NO <> 'N' AND A.IT_CODE = '" + tItCode.Text + "' GROUP BY A.TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		if (Conversion.Val(nTagKrTch.Text) != 0.0)
		{
			DC_Main.RsQry = "UPDATE BAR_DETL SET KR_TOUCH = " + Conversions.ToString(Conversion.Val(nTagKrTch.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + tItCode.Text + "' AND KR_TOUCH = 0 AND TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_SIGN = '-' AND A.TAG_NO <> 'N' AND A.IT_CODE = '" + tItCode.Text + "' GROUP BY A.TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		if (Conversion.Val(nTagKrWestPrc.Text) != 0.0)
		{
			DC_Main.RsQry = "UPDATE BAR_DETL SET KR_WEST_PRC = " + Conversions.ToString(Conversion.Val(nTagKrWestPrc.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + tItCode.Text + "' AND KR_WEST_PRC = 0 AND KR_TOUCH <> 0 AND TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_SIGN = '-' AND A.TAG_NO <> 'N' AND A.IT_CODE = '" + tItCode.Text + "' GROUP BY A.TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		DC_Main.RsQry = "SELECT TAG_NO,ITM_NWT,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,VCH_SRNO,IT_CODE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND (KR_TOUCH + KR_WEST_PRC) <> 0 AND KR_NET_WT <> 0 AND IT_CODE = '" + tItCode.Text + "' ORDER BY TAG_NO";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Tbl.Rows.Count)
			{
				double num = 0.0;
				if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Tbl.Rows[DC_Main.M]["KR_NET_WT"], (object)0, false))
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["KR_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["KR_WEST_PRC"])) != 0.0)
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["KR_NET_WT"])) * (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["KR_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["KR_WEST_PRC"]))) / 100.0;
					}
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET KR_FINE = " + Conversions.ToString(num) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" ")));
				}
				DC_Main.M++;
			}
			DC_Main.Tbl.Rows.Clear();
			DC_Main.Tbl.Columns.Clear();
			Interaction.MsgBox((object)"Item Tag Value Is Update.....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void PnlBotam_Paint(object sender, PaintEventArgs e)
	{
	}

	private void nLbrRate_TextChanged(object sender, EventArgs e)
	{
	}

	private void tItName_TextChanged(object sender, EventArgs e)
	{
	}
}
