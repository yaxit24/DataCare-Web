using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCrystal;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using DevNet;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using NextEmp.My;
using Qios.DevSuite.Components;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyTitle("NextEmp")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NextEmp")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("a62d7bfc-9dbe-40c5-bacd-f82d618229f1")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework(".NETFramework,Version=v4.7.2", FrameworkDisplayName = ".NET Framework 4.7.2")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace NextEmp.My
{
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class MyApplication : WindowsFormsApplicationBase
	{
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		[STAThread]
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static void Main(string[] Args)
		{
			try
			{
				Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
			}
			finally
			{
			}
			((WindowsFormsApplicationBase)MyProject.Application).Run(Args);
		}

		[DebuggerStepThrough]
		public MyApplication()
			: base((AuthenticationMode)0)
		{
			((WindowsFormsApplicationBase)this).IsSingleInstance = false;
			((WindowsFormsApplicationBase)this).EnableVisualStyles = true;
			((WindowsFormsApplicationBase)this).SaveMySettingsOnExit = true;
			((WindowsFormsApplicationBase)this).ShutdownStyle = (ShutdownMode)0;
		}

		[DebuggerStepThrough]
		protected override void OnCreateMainForm()
		{
			((WindowsFormsApplicationBase)this).MainForm = (Form)(object)MyProject.Forms.MDI_FORM;
		}
	}
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class MyComputer : Computer
	{
		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyComputer()
		{
		}
	}
	[StandardModule]
	[HideModuleName]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		internal sealed class MyForms
		{
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public MDI_FORM m_MDI_FORM;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public MS_HELP m_MS_HELP;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public UT_WHATSAPP_OLD m_UT_WHATSAPP_OLD;

			public MDI_FORM MDI_FORM
			{
				[DebuggerHidden]
				get
				{
					m_MDI_FORM = Create__Instance__(m_MDI_FORM);
					return m_MDI_FORM;
				}
				[DebuggerHidden]
				set
				{
					if (value != m_MDI_FORM)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						Dispose__Instance__(ref m_MDI_FORM);
					}
				}
			}

			public MS_HELP MS_HELP
			{
				[DebuggerHidden]
				get
				{
					m_MS_HELP = Create__Instance__(m_MS_HELP);
					return m_MS_HELP;
				}
				[DebuggerHidden]
				set
				{
					if (value != m_MS_HELP)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						Dispose__Instance__(ref m_MS_HELP);
					}
				}
			}

			public UT_WHATSAPP_OLD UT_WHATSAPP_OLD
			{
				[DebuggerHidden]
				get
				{
					m_UT_WHATSAPP_OLD = Create__Instance__(m_UT_WHATSAPP_OLD);
					return m_UT_WHATSAPP_OLD;
				}
				[DebuggerHidden]
				set
				{
					if (value != m_UT_WHATSAPP_OLD)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						Dispose__Instance__(ref m_UT_WHATSAPP_OLD);
					}
				}
			}

			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				if (Instance == null || ((Control)Instance).IsDisposed)
				{
					if (m_FormBeingCreated != null)
					{
						if (m_FormBeingCreated.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						m_FormBeingCreated = new Hashtable();
					}
					m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						return new T();
					}
					catch (TargetInvocationException ex) when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						ProjectData.SetProjectError((Exception)ex);
						return ex.InnerException != null;
					}).Invoke())
					{
						string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[1] { ex.InnerException.Message });
						throw new InvalidOperationException(resourceString, ex.InnerException);
					}
					finally
					{
						m_FormBeingCreated.Remove(typeof(T));
					}
				}
				return Instance;
			}

			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				((Component)instance/*cast due to constrained. prefix*/).Dispose();
				instance = default(T);
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyForms()
			{
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyForms);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			internal new Type GetType()
			{
				return typeof(MyWebServices);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override string ToString()
			{
				return base.ToString();
			}

			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				if (instance == null)
				{
					return new T();
				}
				return instance;
			}

			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;

			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					if (m_ThreadStaticValue == null)
					{
						m_ThreadStaticValue = new T();
					}
					return m_ThreadStaticValue;
				}
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
			}
		}

		private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();

		private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();

		private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User>();

		private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

		private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return m_ComputerObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return m_AppObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return m_UserObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.Forms")]
		internal static MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return m_MyFormsObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.WebServices")]
		internal static MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return m_MyWebServicesObjectProvider.GetInstance;
			}
		}
	}
}
namespace NextEmp.My.Resources
{
	[StandardModule]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[HideModuleName]
	internal sealed class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("NextEmp.Resources", typeof(Resources).Assembly);
					resourceMan = resourceManager;
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap tagsumm
		{
			get
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0022: Expected O, but got Unknown
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("tagsumm", resourceCulture));
				return (Bitmap)objectValue;
			}
		}
	}
}
namespace NextEmp.My
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed class MySettings : ApplicationSettingsBase
	{
		private static MySettings defaultInstance = (MySettings)(object)SettingsBase.Synchronized((SettingsBase)(object)new MySettings());

		private static bool addedHandler;

		private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

		public static MySettings Default
		{
			get
			{
				//IL_0040: Unknown result type (might be due to invalid IL or missing references)
				//IL_004a: Expected O, but got Unknown
				if (!addedHandler)
				{
					object obj = addedHandlerLockObject;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (!addedHandler)
						{
							((WindowsFormsApplicationBase)MyProject.Application).Shutdown += new ShutdownEventHandler(AutoSaveSettings);
							addedHandler = true;
						}
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(obj);
						}
					}
				}
				return defaultInstance;
			}
		}

		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		private static void AutoSaveSettings(object sender, EventArgs e)
		{
			if (((WindowsFormsApplicationBase)MyProject.Application).SaveMySettingsOnExit)
			{
				((ApplicationSettingsBase)MySettingsProperty.Settings).Save();
			}
		}
	}
	[StandardModule]
	[HideModuleName]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class MySettingsProperty
	{
		[HelpKeyword("My.Settings")]
		internal static MySettings Settings => MySettings.Default;
	}
}
namespace NextEmp
{
	[DesignerGenerated]
	public class MDI_FORM : Form
	{
		private IContainer components;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnImageSet")]
		private SimpleButton _btnImageSet;

		private double ColCon;

		private DataTable RsRight;

		[field: AccessedThroughProperty("xtraTabbedMdiManager1")]
		internal virtual XtraTabbedMdiManager xtraTabbedMdiManager1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("PanelTop")]
		internal virtual Panel PanelTop
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("PanelSideBase")]
		internal virtual Panel PanelSideBase
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("PanelSide")]
		internal virtual Panel PanelSide
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnWhSale")]
		internal virtual SimpleButton BtnWhSale
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnSales")]
		internal virtual SimpleButton BtnSales
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnParty")]
		internal virtual SimpleButton BtnParty
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnCash")]
		internal virtual SimpleButton BtnCash
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnItemMast")]
		internal virtual SimpleButton BtnItemMast
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnBankRec")]
		internal virtual SimpleButton BtnBankRec
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnBankPay")]
		internal virtual SimpleButton BtnBankPay
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Panel1")]
		internal virtual Panel Panel1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblClock")]
		internal virtual Label lblClock
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Timer1")]
		internal virtual Timer Timer1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("btnDesign")]
		internal virtual SimpleButton btnDesign
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("btnStkImport")]
		internal virtual SimpleButton btnStkImport
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("btnAutoItem")]
		internal virtual SimpleButton btnAutoItem
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual SimpleButton btnImageSet
		{
			[CompilerGenerated]
			get
			{
				return _btnImageSet;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnImageSet_Click;
				SimpleButton val = _btnImageSet;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnImageSet = value;
				val = _btnImageSet;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("BtnTchMast")]
		internal virtual SimpleButton BtnTchMast
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("btnBkp")]
		internal virtual SimpleButton btnBkp
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("FlowLayoutPanel1")]
		internal virtual FlowLayoutPanel FlowLayoutPanel1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("LblCoName")]
		internal virtual Label LblCoName
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("btnCashPay")]
		internal virtual SimpleButton btnCashPay
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("PnlBotam")]
		internal virtual FlowLayoutPanel PnlBotam
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public MDI_FORM()
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			((Form)this).Load += MDI_FORM_Load;
			((Form)this).FormClosed += new FormClosedEventHandler(MDI_FORM_FormClosed);
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
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
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
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Expected O, but got Unknown
			//IL_0376: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cd: Expected O, but got Unknown
			//IL_050d: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ac: Expected O, but got Unknown
			//IL_089e: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a8: Expected O, but got Unknown
			//IL_09a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_09b1: Expected O, but got Unknown
			//IL_0aaf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ab9: Expected O, but got Unknown
			//IL_0ba7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bb1: Expected O, but got Unknown
			//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cb9: Expected O, but got Unknown
			//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dc2: Expected O, but got Unknown
			//IL_0ec1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ecb: Expected O, but got Unknown
			//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fd3: Expected O, but got Unknown
			//IL_10c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_10ce: Expected O, but got Unknown
			//IL_11bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_11c9: Expected O, but got Unknown
			//IL_12ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_12c4: Expected O, but got Unknown
			//IL_13b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_13bc: Expected O, but got Unknown
			//IL_14aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_14b4: Expected O, but got Unknown
			//IL_15d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_169b: Unknown result type (might be due to invalid IL or missing references)
			//IL_16a5: Expected O, but got Unknown
			components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MDI_FORM));
			xtraTabbedMdiManager1 = new XtraTabbedMdiManager(components);
			PanelTop = new Panel();
			LblCoName = new Label();
			FlowLayoutPanel1 = new FlowLayoutPanel();
			Panel1 = new Panel();
			lblClock = new Label();
			PanelSideBase = new Panel();
			PanelSide = new Panel();
			btnCashPay = new SimpleButton();
			btnBkp = new SimpleButton();
			BtnTchMast = new SimpleButton();
			btnImageSet = new SimpleButton();
			btnAutoItem = new SimpleButton();
			btnStkImport = new SimpleButton();
			btnDesign = new SimpleButton();
			BtnItemMast = new SimpleButton();
			BtnBankRec = new SimpleButton();
			BtnBankPay = new SimpleButton();
			BtnCash = new SimpleButton();
			BtnParty = new SimpleButton();
			BtnSales = new SimpleButton();
			BtnWhSale = new SimpleButton();
			Timer1 = new Timer(components);
			PnlBotam = new FlowLayoutPanel();
			((ISupportInitialize)xtraTabbedMdiManager1).BeginInit();
			((Control)PanelTop).SuspendLayout();
			((Control)Panel1).SuspendLayout();
			((Control)PanelSideBase).SuspendLayout();
			((Control)PanelSide).SuspendLayout();
			((Control)this).SuspendLayout();
			xtraTabbedMdiManager1.AppearancePage.Header.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			xtraTabbedMdiManager1.AppearancePage.Header.ForeColor = Color.Maroon;
			xtraTabbedMdiManager1.AppearancePage.Header.Options.UseFont = true;
			xtraTabbedMdiManager1.AppearancePage.Header.Options.UseForeColor = true;
			xtraTabbedMdiManager1.ClosePageButtonShowMode = (ClosePageButtonShowMode)4;
			xtraTabbedMdiManager1.HeaderButtonsShowMode = (TabButtonShowMode)2;
			xtraTabbedMdiManager1.MdiParent = (Form)(object)this;
			((Control)PanelTop).BackColor = Color.FromArgb(250, 220, 220);
			PanelTop.BorderStyle = (BorderStyle)2;
			((Control)PanelTop).Controls.Add((Control)(object)LblCoName);
			((Control)PanelTop).Controls.Add((Control)(object)FlowLayoutPanel1);
			((Control)PanelTop).Controls.Add((Control)(object)Panel1);
			((Control)PanelTop).Dock = (DockStyle)1;
			((Control)PanelTop).Location = new Point(0, 0);
			((Control)PanelTop).Name = "PanelTop";
			((Control)PanelTop).Size = new Size(1350, 38);
			((Control)PanelTop).TabIndex = 0;
			((Control)LblCoName).BackColor = Color.FromArgb(250, 220, 220);
			((Control)LblCoName).Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((Control)LblCoName).ForeColor = Color.Maroon;
			((Control)LblCoName).Location = new Point(186, 0);
			((Control)LblCoName).Name = "LblCoName";
			((Control)LblCoName).Padding = new Padding(0, 7, 0, 0);
			((Control)LblCoName).Size = new Size(366, 31);
			((Control)LblCoName).TabIndex = 4;
			LblCoName.Text = "DataCare App Solution";
			((Control)FlowLayoutPanel1).BackColor = Color.FromArgb(250, 220, 220);
			FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
			((Control)FlowLayoutPanel1).Location = new Point(171, -1);
			((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
			((Control)FlowLayoutPanel1).Size = new Size(1177, 38);
			((Control)FlowLayoutPanel1).TabIndex = 3;
			((Control)Panel1).BackColor = Color.SlateGray;
			((Control)Panel1).Controls.Add((Control)(object)lblClock);
			((Control)Panel1).Location = new Point(-3, 0);
			((Control)Panel1).Name = "Panel1";
			((Control)Panel1).Size = new Size(174, 41);
			((Control)Panel1).TabIndex = 0;
			((Control)lblClock).Dock = (DockStyle)1;
			((Control)lblClock).Font = new Font("Bahnschrift SemiBold SemiConden", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((Control)lblClock).ForeColor = Color.White;
			((Control)lblClock).Location = new Point(0, 0);
			((Control)lblClock).Name = "lblClock";
			((Control)lblClock).Padding = new Padding(0, 7, 0, 0);
			((Control)lblClock).Size = new Size(174, 46);
			((Control)lblClock).TabIndex = 1;
			lblClock.Text = "Clock";
			lblClock.TextAlign = (ContentAlignment)2;
			PanelSideBase.BorderStyle = (BorderStyle)2;
			((Control)PanelSideBase).Controls.Add((Control)(object)PanelSide);
			((Control)PanelSideBase).Dock = (DockStyle)3;
			((Control)PanelSideBase).Location = new Point(0, 38);
			((Control)PanelSideBase).Name = "PanelSideBase";
			((Control)PanelSideBase).Size = new Size(173, 673);
			((Control)PanelSideBase).TabIndex = 13;
			((Control)PanelSide).BackColor = Color.FromArgb(250, 220, 220);
			((Control)PanelSide).Controls.Add((Control)(object)btnCashPay);
			((Control)PanelSide).Controls.Add((Control)(object)btnBkp);
			((Control)PanelSide).Controls.Add((Control)(object)BtnTchMast);
			((Control)PanelSide).Controls.Add((Control)(object)btnImageSet);
			((Control)PanelSide).Controls.Add((Control)(object)btnAutoItem);
			((Control)PanelSide).Controls.Add((Control)(object)btnStkImport);
			((Control)PanelSide).Controls.Add((Control)(object)btnDesign);
			((Control)PanelSide).Controls.Add((Control)(object)BtnItemMast);
			((Control)PanelSide).Controls.Add((Control)(object)BtnBankRec);
			((Control)PanelSide).Controls.Add((Control)(object)BtnBankPay);
			((Control)PanelSide).Controls.Add((Control)(object)BtnCash);
			((Control)PanelSide).Controls.Add((Control)(object)BtnParty);
			((Control)PanelSide).Controls.Add((Control)(object)BtnSales);
			((Control)PanelSide).Controls.Add((Control)(object)BtnWhSale);
			((Control)PanelSide).Location = new Point(-3, -3);
			((Control)PanelSide).Name = "PanelSide";
			((Control)PanelSide).Size = new Size(175, 674);
			((Control)PanelSide).TabIndex = 0;
			((BaseStyleControl)btnCashPay).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)btnCashPay).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)btnCashPay).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnCashPay).Appearance.Options.UseForeColor = true;
			((Control)btnCashPay).Location = new Point(-6, 191);
			((BaseControl)btnCashPay).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)btnCashPay).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnCashPay).Name = "btnCashPay";
			((Control)btnCashPay).RightToLeft = (RightToLeft)0;
			((Control)btnCashPay).Size = new Size(186, 38);
			((Control)btnCashPay).TabIndex = 13;
			btnCashPay.Text = "-";
			((BaseStyleControl)btnBkp).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)btnBkp).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)btnBkp).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnBkp).Appearance.Options.UseForeColor = true;
			((Control)btnBkp).Location = new Point(-5, 457);
			((BaseControl)btnBkp).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)btnBkp).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnBkp).Name = "btnBkp";
			((Control)btnBkp).RightToLeft = (RightToLeft)0;
			((Control)btnBkp).Size = new Size(186, 38);
			((Control)btnBkp).TabIndex = 12;
			btnBkp.Text = "-";
			((Control)btnBkp).Visible = false;
			((BaseStyleControl)BtnTchMast).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnTchMast).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnTchMast).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnTchMast).Appearance.Options.UseForeColor = true;
			((Control)BtnTchMast).Location = new Point(-7, 495);
			((BaseControl)BtnTchMast).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnTchMast).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnTchMast).Name = "BtnTchMast";
			((Control)BtnTchMast).RightToLeft = (RightToLeft)0;
			((Control)BtnTchMast).Size = new Size(186, 38);
			((Control)BtnTchMast).TabIndex = 0;
			BtnTchMast.Text = "-";
			((Control)BtnTchMast).Visible = false;
			((BaseStyleControl)btnImageSet).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)btnImageSet).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)btnImageSet).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnImageSet).Appearance.Options.UseForeColor = true;
			((Control)btnImageSet).Location = new Point(-6, 1);
			((BaseControl)btnImageSet).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)btnImageSet).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnImageSet).Name = "btnImageSet";
			((Control)btnImageSet).RightToLeft = (RightToLeft)0;
			((Control)btnImageSet).Size = new Size(186, 38);
			((Control)btnImageSet).TabIndex = 11;
			btnImageSet.Text = "Whatsapp";
			((BaseStyleControl)btnAutoItem).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)btnAutoItem).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)btnAutoItem).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnAutoItem).Appearance.Options.UseForeColor = true;
			((Control)btnAutoItem).Location = new Point(-5, 343);
			((BaseControl)btnAutoItem).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)btnAutoItem).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnAutoItem).Name = "btnAutoItem";
			((Control)btnAutoItem).RightToLeft = (RightToLeft)0;
			((Control)btnAutoItem).Size = new Size(186, 38);
			((Control)btnAutoItem).TabIndex = 8;
			btnAutoItem.Text = "-";
			((Control)btnAutoItem).Visible = false;
			((BaseStyleControl)btnStkImport).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)btnStkImport).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)btnStkImport).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnStkImport).Appearance.Options.UseForeColor = true;
			((Control)btnStkImport).Location = new Point(-5, 419);
			((BaseControl)btnStkImport).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)btnStkImport).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnStkImport).Name = "btnStkImport";
			((Control)btnStkImport).RightToLeft = (RightToLeft)0;
			((Control)btnStkImport).Size = new Size(186, 38);
			((Control)btnStkImport).TabIndex = 10;
			btnStkImport.Text = "-";
			((Control)btnStkImport).Visible = false;
			((BaseStyleControl)btnDesign).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)btnDesign).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)btnDesign).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnDesign).Appearance.Options.UseForeColor = true;
			((Control)btnDesign).Location = new Point(-5, 381);
			((BaseControl)btnDesign).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)btnDesign).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnDesign).Name = "btnDesign";
			((Control)btnDesign).RightToLeft = (RightToLeft)0;
			((Control)btnDesign).Size = new Size(186, 38);
			((Control)btnDesign).TabIndex = 9;
			btnDesign.Text = "-";
			((Control)btnDesign).Visible = false;
			((BaseStyleControl)BtnItemMast).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnItemMast).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnItemMast).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnItemMast).Appearance.Options.UseForeColor = true;
			((Control)BtnItemMast).Location = new Point(-3, 305);
			((BaseControl)BtnItemMast).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnItemMast).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnItemMast).Name = "BtnItemMast";
			((Control)BtnItemMast).RightToLeft = (RightToLeft)0;
			((Control)BtnItemMast).Size = new Size(186, 38);
			((Control)BtnItemMast).TabIndex = 7;
			BtnItemMast.Text = "-";
			((Control)BtnItemMast).Visible = false;
			((BaseStyleControl)BtnBankRec).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnBankRec).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnBankRec).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnBankRec).Appearance.Options.UseForeColor = true;
			((Control)BtnBankRec).Location = new Point(-3, 229);
			((BaseControl)BtnBankRec).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnBankRec).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnBankRec).Name = "BtnBankRec";
			((Control)BtnBankRec).RightToLeft = (RightToLeft)0;
			((Control)BtnBankRec).Size = new Size(186, 38);
			((Control)BtnBankRec).TabIndex = 5;
			BtnBankRec.Text = "-";
			((BaseStyleControl)BtnBankPay).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnBankPay).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnBankPay).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnBankPay).Appearance.Options.UseForeColor = true;
			((Control)BtnBankPay).Location = new Point(-3, 267);
			((BaseControl)BtnBankPay).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnBankPay).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnBankPay).Name = "BtnBankPay";
			((Control)BtnBankPay).RightToLeft = (RightToLeft)0;
			((Control)BtnBankPay).Size = new Size(186, 38);
			((Control)BtnBankPay).TabIndex = 6;
			BtnBankPay.Text = "-";
			((BaseStyleControl)BtnCash).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnCash).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnCash).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnCash).Appearance.Options.UseForeColor = true;
			((Control)BtnCash).Location = new Point(-3, 153);
			((BaseControl)BtnCash).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnCash).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnCash).Name = "BtnCash";
			((Control)BtnCash).RightToLeft = (RightToLeft)0;
			((Control)BtnCash).Size = new Size(186, 38);
			((Control)BtnCash).TabIndex = 4;
			BtnCash.Text = "-";
			((BaseStyleControl)BtnParty).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnParty).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnParty).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnParty).Appearance.Options.UseForeColor = true;
			((Control)BtnParty).Location = new Point(-3, 39);
			((BaseControl)BtnParty).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnParty).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnParty).Name = "BtnParty";
			((Control)BtnParty).RightToLeft = (RightToLeft)0;
			((Control)BtnParty).Size = new Size(186, 38);
			((Control)BtnParty).TabIndex = 1;
			BtnParty.Text = "-";
			((BaseStyleControl)BtnSales).Appearance.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnSales).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnSales).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnSales).Appearance.Options.UseForeColor = true;
			((Control)BtnSales).Location = new Point(-3, 77);
			((BaseControl)BtnSales).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnSales).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnSales).Name = "BtnSales";
			((Control)BtnSales).RightToLeft = (RightToLeft)0;
			((Control)BtnSales).Size = new Size(186, 38);
			((Control)BtnSales).TabIndex = 2;
			BtnSales.Text = "-";
			((BaseStyleControl)BtnWhSale).Appearance.Font = new Font("Segoe UI Semibold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnWhSale).Appearance.ForeColor = Color.DarkSlateGray;
			((BaseStyleControl)BtnWhSale).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnWhSale).Appearance.Options.UseForeColor = true;
			((Control)BtnWhSale).Location = new Point(-3, 115);
			((BaseControl)BtnWhSale).LookAndFeel.SkinName = "Seven Classic";
			((BaseControl)BtnWhSale).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnWhSale).Name = "BtnWhSale";
			((Control)BtnWhSale).RightToLeft = (RightToLeft)0;
			((Control)BtnWhSale).Size = new Size(186, 38);
			((Control)BtnWhSale).TabIndex = 3;
			BtnWhSale.Text = "-";
			Timer1.Enabled = true;
			((Control)PnlBotam).BackColor = Color.WhiteSmoke;
			((Control)PnlBotam).Dock = (DockStyle)2;
			((Control)PnlBotam).Location = new Point(173, 687);
			((Control)PnlBotam).Margin = new Padding(2);
			((Control)PnlBotam).Name = "PnlBotam";
			((Control)PnlBotam).Size = new Size(1177, 24);
			((Control)PnlBotam).TabIndex = 18;
			((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((Form)this).BackColor = Color.Silver;
			((Form)this).ClientSize = new Size(1350, 711);
			((Control)this).Controls.Add((Control)(object)PnlBotam);
			((Control)this).Controls.Add((Control)(object)PanelSideBase);
			((Control)this).Controls.Add((Control)(object)PanelTop);
			((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			((Form)this).IsMdiContainer = true;
			((Form)this).KeyPreview = true;
			((Control)this).Name = "MDI_FORM";
			((Form)this).Text = "DataCare Softech";
			((Form)this).WindowState = (FormWindowState)2;
			((ISupportInitialize)xtraTabbedMdiManager1).EndInit();
			((Control)PanelTop).ResumeLayout(false);
			((Control)Panel1).ResumeLayout(false);
			((Control)PanelSideBase).ResumeLayout(false);
			((Control)PanelSide).ResumeLayout(false);
			((Control)this).ResumeLayout(false);
		}

		private void MDI_FORM_Load(object sender, EventArgs e)
		{
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_11ba: Unknown result type (might be due to invalid IL or missing references)
			DC_Main.MainPcW = 1366.0;
			DC_Main.MainPcH = 768.0;
			DC_Main.PcW = Screen.PrimaryScreen.Bounds.Width;
			DC_Main.PcH = Screen.PrimaryScreen.Bounds.Height;
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
				foreach (object control2 in ((Control)Panel1).Controls)
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
				foreach (object control3 in ((Control)PanelTop).Controls)
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
				foreach (object control4 in ((Control)PanelSideBase).Controls)
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
				foreach (object control5 in ((Control)PanelSide).Controls)
				{
					object objectValue4 = RuntimeHelpers.GetObjectValue(control5);
					object obj = objectValue4;
					NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
					obj = objectValue4;
					NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
					obj = objectValue4;
					NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
					obj = objectValue4;
					NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				}
				DC_Main.DataCon();
				DC_Main.RsQry = "SELECT POINT_CODE,POINT_NAME,SR_NO,POINT_TYPE,MAIN_USER FROM POINT_MAST WHERE CO_CODE = 'XX'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					DC_Main.MCo_code = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["POINT_CODE"], (object)""));
					DC_Main.MLc_code = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["POINT_NAME"], (object)""));
					DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MAIN_USER"], (object)""));
					DC_Main.MsWappEndDay = (int)Math.Round(Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SR_NO"], (object)"")));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["POINT_TYPE"], (object)""), (object)"Y", false))
					{
						DC_Main.MsWappMember = true;
						DC_Main.MsWhatsAppOpen = "Y";
					}
					else
					{
						DC_Main.MsWappMember = false;
						DC_Main.MsWhatsAppOpen = "N";
					}
				}
				DC_Main.RsQry = "Select * From YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsOldMethod = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_METHOD"], (object)""));
					if (Operators.CompareString(DC_Main.MCo_Type, "", false) != 0)
					{
						DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
						DC_Main.SqlData = Strings.Mid(DC_Main.SqlData, 1, 4) + Strings.Mid(DC_Main.MCo_year, 3, 2);
					}
					else if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
					{
						if (Operators.CompareString(DC_Main.MsOldMethod, "Y", false) == 0)
						{
							DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);
						}
						else
						{
							DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);
						}
					}
					DC_Main.MMask = "__/__/____";
					DC_Main.MOp_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["OP_DATE"]);
					DC_Main.MCl_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["CL_DATE"]);
					DC_Main.MCo_OpDate = Strings.Format((object)DC_Main.MOp_dt, "dd/MM/yyyy");
					DC_Main.MCo_ClDate = Strings.Format((object)DC_Main.MCl_dt, "dd/MM/yyyy");
				}
				DC_Main.Dc.ConnectionString = "Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + DC_Main.SqlData + ";Persist Security Info=True;User ID=sa;Password=datacare@123";
				DC_Main.RsQry = "Select * From CO_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					LblCoName.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_NAME"]);
					DC_Main.MCo_code = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_CODE"], (object)""));
					DC_Main.MCo_Name = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_NAME"], (object)""));
					DC_Main.MCo_Type = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_TYPE"], (object)""));
					DC_Main.MCo_SName = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_SNAME"], (object)""));
					DC_Main.MsAdminMobile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_MOBILE"], (object)""));
					DC_Main.MCo_State = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_STATE"], (object)""));
					DC_Main.MsAlterYear = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ALTER_YEAR"], (object)""));
					DC_Main.MsWorkType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WORK_TYPE"], (object)""));
					if (Operators.CompareString(DC_Main.MsWorkType, "", false) == 0)
					{
						DC_Main.MsWorkType = "R";
					}
					DC_Main.MsMetalType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["METAL_TYPE"], (object)""));
					if (Operators.CompareString(DC_Main.MsMetalType, "", false) == 0)
					{
						DC_Main.MsMetalType = "G";
					}
					DC_Main.MCo_Path = new FileInfo(Application.ExecutablePath).DirectoryName;
				}
				DC_Main.RsQry = "SELECT * From CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsCoTheme = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["THEME"], (object)""));
					DC_Main.AcLcCodeLen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_LC_CODE_LEN"], (object)""));
					DC_Main.MsVbImport = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VB_IMPORT"], (object)""));
					DC_Main.MsHelpSearch = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HELP_SERCH"], (object)""));
					DC_Main.SmsLink = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SMS_LINK"], (object)""));
					DC_Main.MsAdminSms = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ADMIN_SMS"], (object)""));
					DC_Main.MsCustSms = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CUST_SMS"], (object)""));
					if (DC_Main.MsCoTheme == 0)
					{
						DC_Main.MsCoTheme = 1;
					}
					if (Operators.CompareString(DC_Main.MsCountryCode, "", false) == 0)
					{
						DC_Main.MsCountryCode = "INR";
					}
					if (Operators.CompareString(DC_Main.AcLcCodeLen, "", false) == 0)
					{
						DC_Main.AcLcCodeLen = Conversions.ToString(1);
					}
					if (Operators.CompareString(DC_Main.MsVbImport, "", false) == 0)
					{
						DC_Main.MsVbImport = "N";
					}
					if (Operators.CompareString(DC_Main.MsHelpSearch, "", false) == 0)
					{
						DC_Main.MsHelpSearch = "S";
					}
					if (Operators.CompareString(DC_Main.SmsLink, "", false) == 0)
					{
						DC_Main.SmsLink = "001";
					}
					if (Operators.CompareString(DC_Main.MsAdminSms, "", false) == 0)
					{
						DC_Main.MsAdminSms = "N";
					}
					if (Operators.CompareString(DC_Main.MsCustSms, "", false) == 0)
					{
						DC_Main.MsCustSms = "N";
					}
				}
				else
				{
					Interaction.MsgBox((object)"You Can't Open Software Without Main Software....", (MsgBoxStyle)0, (object)null);
					Application.Exit();
				}
				lblClock.Text = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
				((Form)this).Text = DC_Main.MCo_code + " - " + DC_Main.MCo_Name + " - " + DC_Main.MCo_year;
				LblCoName.Text = DC_Main.MCo_code + " - " + DC_Main.MCo_Name;
			}
		}

		private void MDI_FORM_FormClosed(object sender, FormClosedEventArgs e)
		{
			DC_Main.ExeQuteDc("DELETE FROM POINT_MAST WHERE CO_CODE = 'XX'");
			Application.Exit();
		}

		private void BtnImageSet_Click(object sender, EventArgs e)
		{
			UT_WHATSAPP_OLD uT_WHATSAPP_OLD = new UT_WHATSAPP_OLD();
			((Form)uT_WHATSAPP_OLD).MdiParent = (Form)(object)this;
			checked
			{
				DC_Main.TotOpenForm++;
				((Form)uT_WHATSAPP_OLD).Text = "Ledger " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_WHATSAPP_OLD).Show();
				((Control)uT_WHATSAPP_OLD).Focus();
			}
		}
	}
	[StandardModule]
	internal sealed class DC_Main
	{
		private static RegistryKey regKey;

		public static double MainPcW;

		public static double MainPcH;

		public static double PcW;

		public static double PcH;

		public static double ChildW;

		public static double ChildH;

		public static SqlConnection Mc = new SqlConnection();

		public static SqlConnection Dc = new SqlConnection();

		public static SqlConnection CnTr = new SqlConnection();

		public static SqlConnection Img = new SqlConnection();

		public static SqlCommand CmdRb = new SqlCommand();

		public static SqlTransaction MsTranRb;

		public static SqlCommand Cmd = new SqlCommand();

		public static SqlDataAdapter Da = new SqlDataAdapter();

		public static SqlCommandBuilder SqlBldr = new SqlCommandBuilder();

		public static DataSet DtSet = new DataSet();

		public static DataTable NewTbl = new DataTable();

		public static DataTable Rshlp;

		public static DataTable RsDg = new DataTable();

		public static DataTable Tbl = new DataTable();

		public static DataTable Mstbl = new DataTable();

		public static string RsQry;

		public static DataTable RsTax;

		public static DataTable RsAc;

		public static DataTable RsIt;

		public static DataView RtView;

		public static int i = 0;

		public static int R = 0;

		public static int X = 0;

		public static int M = 0;

		public static string SqlServer;

		public static string SqlMain;

		public static string SqlData;

		public static string SqlOdbc;

		public static string CurLc;

		public static string LinkType;

		public static string MsTrfrSvr;

		public static string MsTrfrSvrMast;

		public static string MsTrfrIp;

		public static string MsTrfrPwd;

		public static bool MsSoftOpen = false;

		public static string CurBook;

		public static string CurBookName;

		public static string CurBookType;

		public static string CurBookItm;

		public static string CurBookVch;

		public static string CurBookMain;

		public static string CurBookSname;

		public static string CurBookInOut;

		public static bool MsCreat;

		public static bool MsSubCreat;

		public static string MsCode;

		public static string MsName;

		public static string RptName;

		public static string RptFormula;

		public static string CrConnect;

		public static string MsPrintOpt;

		public static bool MsPrintOg;

		public static bool MsPrintDup;

		public static bool MsPrintTrip;

		public static bool MsPrintStatus;

		public static string MsMobileLen;

		public static string SmsId;

		public static string SmsPwd;

		public static string SmsUser;

		public static string SmsLink;

		public static string MsSoftType;

		public static string MsMainBtn;

		public static DataTable RsClDetl;

		public static DataTable RsClIdtl;

		public static string SSWithKey;

		public static string SSRegSrNo;

		public static string SSCompSrNo1;

		public static string SSCompSrNo2;

		public static DateTime AmcEndDate;

		public static string MsSoftDemoName;

		public static string MCo_Path;

		public static string MCo_code;

		public static string MLc_code;

		public static string MCo_year;

		public static string MCo_Book;

		public static string MCo_BookType;

		public static string MCo_Type;

		public static string MCo_Name;

		public static string MLc_Name;

		public static string MCo_SName;

		public static string MsAlterYear;

		public static string NewCompCode;

		public static string NewMstCreat;

		public static string NewYearCode;

		public static DateTime MsSysDate;

		public static string MsOldMethod;

		public static string MCo_State;

		public static string MCo_User;

		public static DateTime MOp_dt;

		public static DateTime MCl_dt;

		public static string MCo_OpDate;

		public static string MCo_ClDate;

		public static int MsCoTheme;

		public static string MsDmMast;

		public static string FnYear;

		public static bool RongDate;

		public static string MMask;

		public static bool HelpClose;

		public static string MsWorkType;

		public static string MsMetalType;

		public static string MsGrCode;

		public static string MsUserRightForm = "";

		public static DateTime MsLockDt;

		public static int MsTaxRof = 0;

		public static string MsRatePar;

		public static double MsAcAmtOpBal;

		public static double MsAcGoldOpBal;

		public static double MsAcSilverOpBal;

		public static double MsAcAmtClBal;

		public static double MsAcGoldClBal;

		public static double MsAcSilverClBal;

		public static bool MsHoAcCreat = false;

		public static string MsSlRowChange;

		public static string MsVbImport;

		public static bool TakeBkp;

		public static double TestWt;

		public static string MsLbrGen;

		public static bool MsDailyRateGen = false;

		public static string MsRateMastOpen;

		public static string MsFineStkType;

		public static string MsTagRpt;

		public static string MsHelpSearch;

		public static string MsWeightPort;

		public static string MsLdrSumm;

		public static string MsSlAmtType;

		public static string MsTradFine;

		public static int MsLbrRof;

		public static string LdrAcMastCode;

		public static string MsEstmateReset;

		public static string MsReminderOpen;

		public static int MsItmRateRof;

		public static string MsCustSms;

		public static string MsAdminSms;

		public static string MsAdminMobile;

		public static string MsPurcWithLbr;

		public static string MsGridScroll;

		public static string MsStkRptType;

		public static string MsTchAutoSave;

		public static double MsPanCardVal;

		public static double MsDhrnPrc;

		public static string MsSlNwtLock;

		public static string MsWhBillImg;

		public static string MsSlDupPrint;

		public static bool MsDupPrintStatus;

		public static string MsRptBalZoomType;

		public static bool MsOnlyOpBalnce;

		public static string MsClgValueSave;

		public static string MsProfitRptType;

		public static string MsTaxCode;

		public static string MsQrCodeGen;

		public static string MsOsBillSms;

		public static string MsIpWith;

		public static string MsSlBillImg;

		public static string MsOldCoCode;

		public static string MsCoStockMerge;

		public static bool MsTodayBalance;

		public static string MsTotFineStkType;

		public static string MsOpblTrfrBtn;

		public static string MsTagVchAutoSave;

		public static string MsDesignHelp;

		public static string MsSalesWithHmTax;

		public static string MsBillImgPath;

		public static bool MsTagVchSrnoUpdate;

		public static string MsSqlDataPath = "";

		public static string MsDataLogName;

		public static string MsNextMainLogName;

		public static string MsTileMenuShow;

		public static int MsPrRateRof;

		public static string MsLenImgPath;

		public static string MsCreatName;

		public static string MsSlTdsTax;

		public static string MsPrTdsTax;

		public static string MsCntrStk;

		public static string MsEstmateBankLock;

		public static string MsOldPurcTchGen;

		public static string MsNegativeStkSale;

		public static string MsDhrnIntType;

		public static double MsIntYearDays;

		public static string MsOpDhiran;

		public static string MsIntDayCalc;

		public static string MsDhrnCompound;

		public static string MsLoanIntType;

		public static string MsOpLoan;

		public static int TotOpenForm;

		public static double MsSlSchmAdj;

		public static bool MsSlAdj;

		public static bool MsOldPurc;

		public static bool MsOldPurcSl;

		public static double MsOldPurcAmt;

		public static double MsOldPurcWt;

		public static string MsSlBill;

		public static string MsSlBillHdNo;

		public static string MsSlAcCode;

		public static string MsSlYrCd;

		public static string MsSlDbCd;

		public static double MsSlAmt;

		public static string CustUrdName;

		public static string MsCountryCode;

		public static string MsLbrType;

		public static string MsDataType;

		public static string MsImageNo;

		public static string MsImageType;

		public static string MsImagePath;

		public static string MSImageSavePath;

		public static string MSImageSavePathSmall;

		public static double MsOzGoldRate;

		public static double MsOzSilverRate;

		public static double MsOzConvVal;

		public static double MsOzSlConv;

		public static double MsOzGlConv;

		public static double MsCurrency;

		public static bool LiveRateDisplay;

		public static int MsWappEndDay;

		public static bool MsWappMember;

		public static string MsWhatsAppOpen;

		public static bool YearHelp;

		public static bool HelpLode;

		public static double[] ColWidth;

		public static string[] ColValue;

		public static short HelpSelect;

		public static string AcLcCodeLen;

		public static bool FirstImageLode;

		public static double MainImageW;

		public static double MainImageH;

		public static bool OpenMdi;

		public static string MsgTitle = "DataCareNext";

		public static void DataCon()
		{
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			FileStream fileStream = File.Open(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlName.txt", FileMode.Open);
			StreamReader streamReader = new StreamReader(fileStream);
			SqlServer = streamReader.ReadLine();
			SqlData = streamReader.ReadLine();
			SqlMain = streamReader.ReadLine();
			SqlOdbc = streamReader.ReadLine();
			CurLc = streamReader.ReadLine();
			LinkType = streamReader.ReadLine();
			MSImageSavePath = streamReader.ReadLine();
			MsSqlDataPath = streamReader.ReadLine();
			MsDataLogName = streamReader.ReadLine();
			MsNextMainLogName = streamReader.ReadLine();
			streamReader.Close();
			fileStream.Close();
			Mc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + SqlMain + ";Persist Security Info=True;User ID=sa;Password=datacare@123";
			try
			{
				if (Operators.CompareString(LinkType, "W", false) == 0)
				{
					Dc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + SqlData + ";Integrated Security=True";
				}
				else
				{
					Dc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + SqlData + ";Persist Security Info=True;User ID=sa;Password=datacare@123";
				}
				if (Dc.State == ConnectionState.Open)
				{
					Dc.Close();
				}
				Dc.Open();
				Dc.Close();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox((object)(ex2.Message + "\r\n" + ex2.StackTrace), (MsgBoxStyle)16, (object)null);
				ProjectData.ClearProjectError();
			}
		}

		public static DataTable OpenRecordSetMc(string sql)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			NewTbl = new DataTable();
			Da = new SqlDataAdapter(sql, Mc);
			((DbDataAdapter)(object)Da).Fill(NewTbl);
			return NewTbl;
		}

		public static DataTable OpenRecordSetDc(string sql)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			NewTbl = new DataTable();
			Da = new SqlDataAdapter(sql, Dc);
			((DbDataAdapter)(object)Da).Fill(NewTbl);
			return NewTbl;
		}

		public static DataTable OpenRecordSetImg(string sql)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			NewTbl = new DataTable();
			Da = new SqlDataAdapter(sql, Img);
			((DbDataAdapter)(object)Da).Fill(NewTbl);
			return NewTbl;
		}

		public static void MsInsertData()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			SqlBldr = new SqlCommandBuilder(Da);
			Da.InsertCommand = SqlBldr.GetInsertCommand();
		}

		public static void ExeQuteRb(string Sql)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			CmdRb = new SqlCommand(Sql, Dc, MsTranRb);
		}

		public static void ExeQuteMc(string Sql)
		{
			if (Mc.State == ConnectionState.Open)
			{
				Mc.Close();
			}
			Mc.Open();
			Cmd.Connection = Mc;
			Cmd.CommandText = Sql;
			Cmd.ExecuteNonQuery();
			Mc.Close();
		}

		public static void ExeQuteDc(string Sql)
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
						if (MsSoftOpen)
						{
							if (Dc.State == ConnectionState.Open)
							{
								Dc.Close();
							}
							Dc.Open();
							Cmd.Connection = Dc;
							Cmd.CommandText = Sql;
							Cmd.ExecuteNonQuery();
							Dc.Close();
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						if (Dc.State == ConnectionState.Open)
						{
							Dc.Close();
						}
						Dc.Open();
						Cmd.Connection = Dc;
						Cmd.CommandText = Sql;
						Cmd.ExecuteNonQuery();
						Dc.Close();
						goto end_IL_0001;
					case 429:
						num = -1;
						switch (num2)
						{
						case 2:
							if (!MsSoftOpen)
							{
								Dc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=datacare@123";
								RsQry = "USE [master]   ALTER DATABASE [" + SqlData + "] SET  OFFLINE";
								ExeQuteDc(RsQry);
								RsQry = "USE [master]   ALTER DATABASE [" + SqlData + "] SET  ONLINE";
								ExeQuteDc(RsQry);
								if (Dc.State == ConnectionState.Open)
								{
									Dc.Close();
								}
								Dc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + SqlData + ";Persist Security Info=True;User ID=sa;Password=datacare@123";
							}
							goto end_IL_0001;
						}
						break;
					}
				}
				catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
				{
					ProjectData.SetProjectError((Exception)obj);
					try0001_dispatch = 429;
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

		public static void ExeQuteImg(string Sql)
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
						if (Img.State == ConnectionState.Open)
						{
							Img.Close();
						}
						Img.Open();
						Cmd.Connection = Img;
						Cmd.CommandText = Sql;
						Cmd.ExecuteNonQuery();
						Img.Close();
						goto end_IL_0001;
					case 296:
						num = -1;
						switch (num2)
						{
						case 2:
						{
							string text = "NextImage";
							Img.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=datacare@123";
							RsQry = "USE [master]   ALTER DATABASE [" + text + "] SET  OFFLINE";
							ExeQuteImg(RsQry);
							RsQry = "USE [master]   ALTER DATABASE [" + text + "] SET  ONLINE";
							ExeQuteImg(RsQry);
							if (Img.State == ConnectionState.Open)
							{
								Img.Close();
							}
							Img.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + text + ";Persist Security Info=True;User ID=sa;Password=datacare@123";
							goto end_IL_0001;
						}
						}
						break;
					}
				}
				catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
				{
					ProjectData.SetProjectError((Exception)obj);
					try0001_dispatch = 296;
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

		public static void MsAcBal(string AcCode, DateTime TranTime)
		{
			MsAcAmtOpBal = 0.0;
			MsAcAmtClBal = 0.0;
			MsAcGoldOpBal = 0.0;
			MsAcGoldClBal = 0.0;
			MsAcSilverOpBal = 0.0;
			MsAcSilverClBal = 0.0;
			RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_CODE,Sum(CR_AMT-DR_AMT) as Amount,SUM(CASE WHEN IT_TYPE = 'G' THEN(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN IT_TYPE = 'S' THEN (CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA  WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CO_YEAR = '" + MCo_year + "' AND AC_CODE = '" + AcCode + "' and ENTRY_TIME < '" + Strings.Format((object)TranTime, "MM/dd/yyyy HH:mm:ss") + "' "), Interaction.IIf(Operators.CompareString(MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + MsDataType + "'"))), (object)"   GROUP BY AC_CODE"));
			DataTable dataTable = OpenRecordSetDc(RsQry);
			if (dataTable.Rows.Count > 0)
			{
				MsAcAmtOpBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]), "0.00"));
				MsAcGoldOpBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GoldWt"]), "0.000"));
				MsAcSilverOpBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"]), "0.000"));
			}
			RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_CODE,Sum(CR_AMT-DR_AMT) as Amount,SUM(CASE WHEN IT_TYPE = 'G' THEN(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN IT_TYPE = 'S' THEN (CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA  WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CO_YEAR = '" + MCo_year + "' AND AC_CODE = '" + AcCode + "' and ENTRY_TIME <= '" + Strings.Format((object)TranTime, "MM/dd/yyyy HH:mm:ss") + "' "), Interaction.IIf(Operators.CompareString(MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + MsDataType + "'"))), (object)"   GROUP BY AC_CODE"));
			dataTable = OpenRecordSetDc(RsQry);
			if (dataTable.Rows.Count > 0)
			{
				MsAcAmtClBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]), "0.00"));
				MsAcGoldClBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GoldWt"]), "0.000"));
				MsAcSilverClBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"]), "0.000"));
			}
		}

		public static void SetDate(ref MaskedTextBox MsDate)
		{
			//IL_054d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0674: Unknown result type (might be due to invalid IL or missing references)
			//IL_0622: Unknown result type (might be due to invalid IL or missing references)
			//IL_05df: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
			RongDate = false;
			string text = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
			checked
			{
				int num = Strings.Len(MsDate.Text) - 1;
				int i;
				for (i = 1; i <= num && !((Operators.CompareString(Strings.Mid(MsDate.Text, i, 1), "_", false) == 0) | (Operators.CompareString(Strings.Mid(MsDate.Text, i, 1), " ", false) == 0)); i++)
				{
				}
				if (i > 5)
				{
					FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));
				}
				else
				{
					FnYear = Conversions.ToString(Interaction.IIf((Conversion.Val(Strings.Mid(text, 4, 2)) < 4.0) | (Operators.CompareString(Strings.Mid(text, 4, 2), "", false) == 0), (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));
				}
				if (i == 2)
				{
					RongDate = true;
					return;
				}
				switch (i)
				{
				case 1:
					MsDate.Text = DateAndTime.Today.Day.ToString("00") + "/" + DateAndTime.Today.Month.ToString("00") + "/" + FnYear;
					break;
				case 2:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 1) + "/" + Strings.Mid(text, 2, 5) + "/" + FnYear;
					break;
				case 3:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;
					break;
				case 4:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;
					break;
				case 5:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;
					break;
				case 6:
					MsDate.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Strings.Mid(MsDate.Text, 1, 2) + "/"), Interaction.IIf((Operators.CompareString(Strings.Mid(MsDate.Text, 4, 2), "  ", false) == 0) | (Operators.CompareString(Strings.Mid(MsDate.Text, 5, 1), " ", false) == 0), (object)Strings.Mid(text, 4, 2), (object)Strings.Mid(MsDate.Text, 4, 2))), (object)"/"), (object)FnYear));
					break;
				case 7:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;
					break;
				case 8:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;
					break;
				case 9:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;
					break;
				case 10:
					MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + Strings.Mid(MsDate.Text, 7, 10);
					break;
				}
				double num2 = Conversion.Val(Strings.Mid(MsDate.Text, 4, 2));
				if (num2 == 2.0)
				{
					if (Operators.CompareString(Strings.Mid(MsDate.Text, 1, 1), "29", false) > 0)
					{
						RongDate = true;
						Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);
						MsDate.Text = "__/__/____";
						((TextBoxBase)MsDate).SelectAll();
						return;
					}
				}
				else if (num2 == 4.0 || num2 == 6.0 || num2 == 9.0 || num2 == 11.0)
				{
					if (Operators.CompareString(Strings.Mid(MsDate.Text, 1, 1), "30", false) > 0)
					{
						RongDate = true;
						Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);
						MsDate.Text = "__/__/____";
						((TextBoxBase)MsDate).SelectAll();
						return;
					}
				}
				else if (num2 > 12.0)
				{
					RongDate = true;
					Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);
					MsDate.Text = "__/__/____";
					((TextBoxBase)MsDate).SelectAll();
					return;
				}
				if (Conversion.Val(Strings.Mid(MsDate.Text, 1, 2)) > 31.0)
				{
					RongDate = true;
					Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);
					MsDate.Text = "__/__/____";
					((TextBoxBase)MsDate).SelectAll();
				}
				else if (Conversion.Val(Strings.Mid(MsDate.Text, 3, 2)) > 12.0)
				{
					RongDate = true;
					Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);
					MsDate.Text = "__/__/____";
					((TextBoxBase)MsDate).SelectAll();
				}
			}
		}

		public static void OpenTable_ColMast()
		{
			RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + MCo_code + "' AND BOOK_NAME NOT IN ('TAG_IDTL')";
			RsClDetl = OpenRecordSetDc(RsQry);
			RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + MCo_code + "' AND BOOK_NAME IN ('TAG_IDTL')";
			RsClIdtl = OpenRecordSetDc(RsQry);
		}

		public static void AvgTouch(DateTime TranDate)
		{
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			ExeQuteDc("UPDATE ITEM_MAST SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0,AVG_RATE = 0 WHERE  CO_CODE = '" + MCo_code + "'");
			ExeQuteDc("UPDATE GROUP_MAST SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0 WHERE  CO_CODE = '" + MCo_code + "'");
			ExeQuteDc("UPDATE BAL_GR SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0,AVG_AMT = 0 WHERE  CO_CODE = '" + MCo_code + "'");
			checked
			{
				if (Operators.CompareString(MsFineStkType, "G", false) == 0)
				{
					GroupStockTouch(TranDate);
				}
				else
				{
					RsQry = "Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0  and VCH_DATE <= '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' AND A.TR_TYPE IN ('P','I') GROUP BY A.IT_CODE ";
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						num = 0.0;
						num2 = 0.0;
						num3 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotFine"])) != 0.0))
						{
							num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotFine"])) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
							RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND A.IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'  and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE "));
							dataTable2 = OpenRecordSetDc(RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"]));
								num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"])) * num / 100.0;
							}
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = " + Strings.Format((object)num, "0.00") + ",AVG_FINE = " + Strings.Format((object)num2, "0.000") + ",AVG_NWT = " + Strings.Format((object)num3, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
						}
						else
						{
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = 100,AVG_FINE = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])), "0.000") + ",AVG_NWT = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])), "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
						}
					}
					Tbl.Rows.Clear();
					Tbl.Columns.Clear();
					RsQry = "Select GR_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY GR_CODE ORDER BY GR_CODE ";
					dataTable = OpenRecordSetDc(RsQry);
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						double num5 = 0.0;
						double num6 = 0.0;
						RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_TOUCH "));
						Tbl = OpenRecordSetDc(RsQry);
						for (M = 0; M < Tbl.Rows.Count; M++)
						{
							num = 0.0;
							num2 = 0.0;
							num3 = 0.0;
							if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"])) != 0.0))
							{
								num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"]));
								num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
								num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
								num5 += num3;
								num6 += num2;
							}
						}
						if (num5 + num6 != 0.0)
						{
							num = num6 * 100.0 / num5;
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET AVG_TOUCH = " + Strings.Format((object)num, "0.000") + ",AVG_FINE = " + Strings.Format((object)num6, "0.000") + ",AVG_NWT = " + Strings.Format((object)num5, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"'")));
						}
					}
					Tbl.Rows.Clear();
					Tbl.Columns.Clear();
					dataTable.Rows.Clear();
					dataTable.Columns.Clear();
					dataTable2.Rows.Clear();
					dataTable2.Columns.Clear();
					RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
					dataTable = OpenRecordSetDc(RsQry);
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						double num5 = 0.0;
						double num6 = 0.0;
						RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_TOUCH "));
						Tbl = OpenRecordSetDc(RsQry);
						for (M = 0; M < Tbl.Rows.Count; M++)
						{
							num = 0.0;
							num2 = 0.0;
							num3 = 0.0;
							if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"])) != 0.0))
							{
								num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"]));
								num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
								num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
								num5 += num3;
								num6 += num2;
							}
						}
						if (num5 + num6 != 0.0)
						{
							num = num6 * 100.0 / num5;
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_TOUCH = " + Strings.Format((object)num, "0.000") + ",AVG_FINE = " + Strings.Format((object)num6, "0.000") + ",AVG_NWT = " + Strings.Format((object)num5, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
						}
					}
					Tbl.Rows.Clear();
					Tbl.Columns.Clear();
					dataTable.Rows.Clear();
					dataTable.Columns.Clear();
					dataTable2.Rows.Clear();
					dataTable2.Columns.Clear();
				}
				RsQry = "Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE 0 END) AS TotPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_AMT ELSE 0 END) AS TotAmt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.RATE_TYPE = 'P' AND A.ITM_AMT <> 0  and VCH_DATE <= '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' AND A.TR_TYPE = 'P' GROUP BY A.IT_CODE ";
				Tbl = OpenRecordSetDc(RsQry);
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					num4 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) != 0.0))
					{
						num4 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"]));
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_RATE = " + Strings.Format((object)num4, "0.00") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND RATE_TYPE = 'P' GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
				dataTable = OpenRecordSetDc(RsQry);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num4 = 0.0;
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_RATE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS TotPcs FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' AND A.ITM_PCS <> 0  and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_RATE "));
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"])) != 0.0))
						{
							num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"]));
						}
					}
					ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_AMT = " + Strings.Format((object)num4, "0.00") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				dataTable.Rows.Clear();
				dataTable.Columns.Clear();
			}
		}

		public static void GroupStockTouch(DateTime TranDate)
		{
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			RsQry = "Select A.IT_CODE,C.MELTING_PRC,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM (MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.IT_TYPE IN ('G','S')  and VCH_DATE <= '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' GROUP BY A.IT_CODE,C.MELTING_PRC ";
			Tbl = OpenRecordSetDc(RsQry);
			checked
			{
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					num = 0.0;
					num2 = 0.0;
					num3 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"]));
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
						num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = " + Strings.Format((object)num, "0.00") + ",AVG_FINE = " + Strings.Format((object)num2, "0.000") + ",AVG_NWT = " + Strings.Format((object)num3, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				RsQry = "Select B.GR_CODE,C.MELTING_PRC,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM (MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.IT_TYPE IN ('G','S')  and VCH_DATE <= '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' GROUP BY B.GR_CODE,C.MELTING_PRC ";
				Tbl = OpenRecordSetDc(RsQry);
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					num = 0.0;
					num2 = 0.0;
					num3 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"]));
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
						num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET AVG_TOUCH = " + Strings.Format((object)num, "0.00") + ",AVG_FINE = " + Strings.Format((object)num2, "0.000") + ",AVG_NWT = " + Strings.Format((object)num3, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND GR_CODE = '"), Tbl.Rows[M]["GR_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
				dataTable = OpenRecordSetDc(RsQry);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num5 = 0.0;
					double num6 = 0.0;
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_TOUCH "));
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						num = 0.0;
						num2 = 0.0;
						num3 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"])) != 0.0))
						{
							num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"]));
							num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
							num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
							num5 += num3;
							num6 += num2;
						}
					}
					if (num5 + num6 != 0.0)
					{
						num = num6 * 100.0 / num5;
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_TOUCH = " + Strings.Format((object)num, "0.000") + ",AVG_FINE = " + Strings.Format((object)num6, "0.000") + ",AVG_NWT = " + Strings.Format((object)num5, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				dataTable.Rows.Clear();
				dataTable.Columns.Clear();
				dataTable2.Rows.Clear();
				dataTable2.Columns.Clear();
			}
		}

		public static double Fnv(ref object Value)
		{
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)))
			{
				return 0.0;
			}
			if (Value == null)
			{
				return 0.0;
			}
			if (Operators.CompareString(Value.ToString(), "", false) == 0)
			{
				return 0.0;
			}
			return Conversion.Val(Value.ToString());
		}

		public static void DcDateFormat()
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\International", writable: true);
			if (Operators.CompareString(Convert.ToString(registryKey).Trim(), string.Empty, false) == 0)
			{
				Interaction.MsgBox((object)"Blank", (MsgBoxStyle)0, (object)null);
				return;
			}
			registryKey.SetValue("sShortDate", "dd/MM/yyyy");
			registryKey.SetValue("sLongDate", "dddd,d MMMM yyyy");
		}
	}
	[DesignerGenerated]
	public class MS_HELP : Form
	{
		private IContainer components;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("LblExit")]
		private Label _LblExit;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("MSG")]
		private DataGridViewX _MSG;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("tSearchText")]
		private TextBox _tSearchText;

		private int HelpWidth;

		private DataTable dtTableGrd;

		private double ColCon;

		private int ColNumber;

		internal virtual Label LblExit
		{
			[CompilerGenerated]
			get
			{
				return _LblExit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = LblExit_Click;
				Label val = _LblExit;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_LblExit = value;
				val = _LblExit;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("LblHelpName")]
		internal virtual Label LblHelpName
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual DataGridViewX MSG
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
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected O, but got Unknown
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Expected O, but got Unknown
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_0027: Expected O, but got Unknown
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0034: Expected O, but got Unknown
				DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(MSG_CellContentDoubleClick);
				KeyEventHandler val2 = new KeyEventHandler(MSG_KeyDown);
				DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(MSG_CellContentClick);
				KeyPressEventHandler val4 = new KeyPressEventHandler(MSG_KeyPress);
				DataGridViewX val5 = _MSG;
				if (val5 != null)
				{
					((DataGridView)val5).CellDoubleClick -= val;
					((Control)val5).KeyDown -= val2;
					((DataGridView)val5).CellContentClick -= val3;
					((Control)val5).KeyPress -= val4;
				}
				_MSG = value;
				val5 = _MSG;
				if (val5 != null)
				{
					((DataGridView)val5).CellDoubleClick += val;
					((Control)val5).KeyDown += val2;
					((DataGridView)val5).CellContentClick += val3;
					((Control)val5).KeyPress += val4;
				}
			}
		}

		internal virtual TextBox tSearchText
		{
			[CompilerGenerated]
			get
			{
				return _tSearchText;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Expected O, but got Unknown
				EventHandler eventHandler = tSearchText_TextChanged;
				KeyEventHandler val = new KeyEventHandler(tSearchText_KeyDown);
				TextBox val2 = _tSearchText;
				if (val2 != null)
				{
					((Control)val2).TextChanged -= eventHandler;
					((Control)val2).KeyDown -= val;
				}
				_tSearchText = value;
				val2 = _tSearchText;
				if (val2 != null)
				{
					((Control)val2).TextChanged += eventHandler;
					((Control)val2).KeyDown += val;
				}
			}
		}

		public MS_HELP()
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			((Form)this).Load += MS_HELP_Load;
			((Control)this).KeyDown += new KeyEventHandler(MS_HELP_KeyDown);
			((Control)this).KeyPress += new KeyPressEventHandler(MS_HELP_KeyPress);
			((Form)this).Activated += MS_HELP_Activated;
			HelpWidth = 0;
			ColNumber = 0;
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
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Expected O, but got Unknown
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Expected O, but got Unknown
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Expected O, but got Unknown
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Expected O, but got Unknown
			//IL_049b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a5: Expected O, but got Unknown
			//IL_0543: Unknown result type (might be due to invalid IL or missing references)
			//IL_054d: Expected O, but got Unknown
			//IL_0664: Unknown result type (might be due to invalid IL or missing references)
			//IL_066e: Expected O, but got Unknown
			DataGridViewCellStyle val = new DataGridViewCellStyle();
			DataGridViewCellStyle val2 = new DataGridViewCellStyle();
			DataGridViewCellStyle val3 = new DataGridViewCellStyle();
			DataGridViewCellStyle val4 = new DataGridViewCellStyle();
			DataGridViewCellStyle val5 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_HELP));
			tSearchText = new TextBox();
			MSG = new DataGridViewX();
			LblExit = new Label();
			LblHelpName = new Label();
			((ISupportInitialize)MSG).BeginInit();
			((Control)this).SuspendLayout();
			((TextBoxBase)tSearchText).BackColor = Color.Tan;
			((TextBoxBase)tSearchText).BorderStyle = (BorderStyle)0;
			tSearchText.CharacterCasing = (CharacterCasing)1;
			((Control)tSearchText).Font = new Font("Verdana", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((TextBoxBase)tSearchText).ForeColor = Color.White;
			((Control)tSearchText).Location = new Point(18, 244);
			((Control)tSearchText).Name = "tSearchText";
			((Control)tSearchText).Size = new Size(701, 16);
			((Control)tSearchText).TabIndex = 1;
			((Control)MSG).AllowDrop = true;
			((DataGridView)MSG).AllowUserToAddRows = false;
			((DataGridView)MSG).AllowUserToDeleteRows = false;
			((DataGridView)MSG).AllowUserToOrderColumns = true;
			((DataGridView)MSG).AllowUserToResizeRows = false;
			val.BackColor = SystemColors.Control;
			val.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			val.ForeColor = Color.FromArgb(64, 64, 64);
			val.SelectionBackColor = Color.FromArgb(255, 192, 192);
			val.SelectionForeColor = Color.Maroon;
			((DataGridView)MSG).AlternatingRowsDefaultCellStyle = val;
			((DataGridView)MSG).BackgroundColor = SystemColors.ButtonHighlight;
			((DataGridView)MSG).BorderStyle = (BorderStyle)2;
			((DataGridView)MSG).CellBorderStyle = (DataGridViewCellBorderStyle)2;
			val2.Alignment = (DataGridViewContentAlignment)16;
			val2.BackColor = SystemColors.Control;
			val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			val2.ForeColor = Color.FromArgb(64, 64, 64);
			val2.SelectionBackColor = SystemColors.ScrollBar;
			val2.SelectionForeColor = Color.White;
			val2.WrapMode = (DataGridViewTriState)2;
			((DataGridView)MSG).ColumnHeadersDefaultCellStyle = val2;
			((DataGridView)MSG).ColumnHeadersHeight = 25;
			((DataGridView)MSG).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
			val3.Alignment = (DataGridViewContentAlignment)16;
			val3.BackColor = SystemColors.Window;
			val3.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			val3.ForeColor = Color.FromArgb(64, 64, 64);
			val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
			val3.SelectionForeColor = Color.Maroon;
			val3.WrapMode = (DataGridViewTriState)2;
			((DataGridView)MSG).DefaultCellStyle = val3;
			((DataGridView)MSG).EnableHeadersVisualStyles = false;
			((DataGridView)MSG).GridColor = Color.FromArgb(208, 215, 229);
			((Control)MSG).Location = new Point(14, 28);
			((Control)MSG).Name = "MSG";
			MSG.PaintEnhancedSelection = false;
			((DataGridView)MSG).ReadOnly = true;
			val4.Alignment = (DataGridViewContentAlignment)16;
			val4.BackColor = Color.MintCream;
			val4.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			val4.ForeColor = SystemColors.WindowText;
			val4.SelectionBackColor = SystemColors.Highlight;
			val4.SelectionForeColor = SystemColors.HighlightText;
			val4.WrapMode = (DataGridViewTriState)1;
			((DataGridView)MSG).RowHeadersDefaultCellStyle = val4;
			((DataGridView)MSG).RowHeadersVisible = false;
			((DataGridView)MSG).RowHeadersWidth = 10;
			val5.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((DataGridView)MSG).RowsDefaultCellStyle = val5;
			MSG.ScrollBarAppearance = (eScrollBarAppearance)0;
			((DataGridView)MSG).ScrollBars = (ScrollBars)2;
			((DataGridView)MSG).SelectionMode = (DataGridViewSelectionMode)0;
			((Control)MSG).Size = new Size(705, 209);
			((DataGridView)MSG).StandardTab = true;
			((Control)MSG).TabIndex = 0;
			LblExit.AutoSize = true;
			((Control)LblExit).BackColor = Color.Transparent;
			((Control)LblExit).Font = new Font("Verdana", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)LblExit).ForeColor = Color.White;
			((Control)LblExit).Location = new Point(706, 5);
			((Control)LblExit).Name = "LblExit";
			((Control)LblExit).Size = new Size(18, 18);
			((Control)LblExit).TabIndex = 3;
			LblExit.Text = "X";
			LblHelpName.AutoSize = true;
			((Control)LblHelpName).BackColor = Color.Transparent;
			((Control)LblHelpName).Font = new Font("Verdana", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)LblHelpName).ForeColor = Color.White;
			((Control)LblHelpName).Location = new Point(12, 5);
			((Control)LblHelpName).Name = "LblHelpName";
			((Control)LblHelpName).Size = new Size(115, 18);
			((Control)LblHelpName).TabIndex = 4;
			LblHelpName.Text = "DataCare Help";
			((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((Form)this).BackColor = Color.Tan;
			((Control)this).BackgroundImageLayout = (ImageLayout)3;
			((Form)this).ClientSize = new Size(734, 268);
			((Control)this).Controls.Add((Control)(object)LblHelpName);
			((Control)this).Controls.Add((Control)(object)LblExit);
			((Control)this).Controls.Add((Control)(object)MSG);
			((Control)this).Controls.Add((Control)(object)tSearchText);
			((Control)this).DoubleBuffered = true;
			((Form)this).FormBorderStyle = (FormBorderStyle)0;
			((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			((Form)this).KeyPreview = true;
			((Form)this).MaximizeBox = false;
			((Form)this).MinimizeBox = false;
			((Control)this).Name = "MS_HELP";
			((Form)this).ShowInTaskbar = false;
			((Form)this).StartPosition = (FormStartPosition)1;
			((Form)this).Text = "DataCare HD Help";
			((ISupportInitialize)MSG).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}

		private void MS_HELP_Load(object sender, EventArgs e)
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			int try0001_dispatch = -1;
			int num2 = default(int);
			int num = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			double num7 = default(double);
			double num8 = default(double);
			IEnumerator enumerator = default(IEnumerator);
			Control val = default(Control);
			ColorConverter colorConverter = default(ColorConverter);
			int num9 = default(int);
			while (true)
			{
				try
				{
					/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
					checked
					{
						object? obj;
						DataGridViewX mSG;
						object? obj2;
						object? obj3;
						DataGridViewX mSG2;
						object? obj4;
						DataGridViewCellStyle alternatingRowsDefaultCellStyle;
						object? obj5;
						DataGridViewX mSG3;
						object? obj6;
						DataGridViewCellStyle alternatingRowsDefaultCellStyle2;
						object? obj7;
						object? obj8;
						DataGridViewX mSG4;
						object? obj9;
						DataGridViewCellStyle alternatingRowsDefaultCellStyle3;
						object? obj10;
						Control val2;
						switch (try0001_dispatch)
						{
						default:
							num2 = 1;
							((Control)this).SuspendLayout();
							goto IL_000b;
						case 3236:
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
									goto IL_0014;
								case 4:
									goto IL_0028;
								case 5:
									goto IL_003d;
								case 6:
									goto IL_0050;
								case 7:
									goto IL_0072;
								case 8:
									goto IL_0097;
								case 9:
									goto IL_00bd;
								case 10:
									goto IL_00e3;
								case 11:
									goto IL_010a;
								case 12:
									goto IL_011d;
								case 13:
									goto IL_0136;
								case 14:
									goto IL_0140;
								case 15:
									goto IL_0154;
								case 16:
									goto IL_017f;
								case 17:
									goto IL_0194;
								case 18:
									goto IL_01c4;
								case 20:
									goto IL_01e3;
								case 21:
									goto IL_01f7;
								case 22:
									goto IL_0222;
								case 23:
									goto IL_0237;
								case 24:
									goto IL_0267;
								case 26:
									goto IL_02a2;
								case 27:
									goto IL_02b6;
								case 28:
									goto IL_02c5;
								case 29:
									goto IL_02da;
								case 30:
									goto IL_030a;
								case 32:
									goto IL_0345;
								case 33:
									goto IL_0359;
								case 34:
									goto IL_0384;
								case 35:
									goto IL_0399;
								case 36:
									goto IL_03c9;
								case 19:
								case 25:
								case 31:
								case 37:
								case 38:
									goto IL_03ff;
								case 39:
									goto IL_0409;
								case 40:
									goto IL_041d;
								case 41:
									goto IL_042d;
								case 42:
									goto IL_0441;
								case 43:
									goto IL_044a;
								case 44:
									goto IL_0468;
								case 45:
									goto IL_047c;
								case 46:
									goto IL_0486;
								case 47:
									goto IL_04a4;
								case 48:
									goto IL_04d4;
								case 49:
									goto IL_04f0;
								case 50:
									goto IL_050c;
								case 51:
									goto IL_052c;
								case 52:
									goto IL_0535;
								case 53:
									goto IL_056e;
								case 54:
									goto IL_0594;
								case 55:
									goto IL_059d;
								case 56:
									goto IL_05bf;
								case 57:
									goto IL_05f5;
								case 59:
									goto IL_061d;
								case 60:
									goto IL_0653;
								case 62:
									goto IL_067b;
								case 63:
									goto IL_06b1;
								case 64:
									goto IL_06d3;
								case 66:
									goto IL_06fb;
								case 67:
									goto IL_0731;
								case 68:
									goto IL_0753;
								case 58:
								case 61:
								case 65:
								case 69:
								case 70:
									goto IL_0779;
								case 71:
									goto IL_078b;
								case 72:
									goto IL_079c;
								case 73:
									goto IL_07b4;
								case 74:
									goto IL_07cc;
								case 75:
									goto IL_07e8;
								case 76:
									goto IL_0804;
								case 77:
									goto IL_081e;
								case 78:
									goto IL_0836;
								case 79:
									goto IL_085b;
								case 80:
									goto IL_0875;
								case 81:
									goto IL_0886;
								case 82:
									goto IL_08a3;
								case 83:
									goto IL_08b4;
								case 84:
									goto IL_08ce;
								case 85:
									goto IL_08ee;
								case 86:
									goto IL_0920;
								case 87:
									goto IL_0931;
								case 89:
									goto IL_095b;
								case 88:
								case 90:
								case 91:
									goto IL_098e;
								case 93:
									goto IL_099e;
								case 94:
									goto IL_09a7;
								case 95:
									goto IL_09b0;
								case 96:
									goto IL_09c3;
								case 97:
									goto IL_09db;
								case 98:
									goto IL_09eb;
								case 99:
									goto IL_09ff;
								case 100:
									goto IL_0a13;
								case 92:
								case 101:
								case 102:
									goto IL_0a23;
								case 103:
									goto IL_0a58;
								case 104:
									goto IL_0a8d;
								case 105:
									goto IL_0aa9;
								case 106:
									goto IL_0abd;
								case 107:
								case 108:
									goto end_IL_0001_2;
								default:
									goto end_IL_0001;
								case 109:
									goto end_IL_0001_3;
								}
								goto default;
							}
							IL_052c:
							num2 = 51;
							num5--;
							goto IL_0535;
							IL_0535:
							num2 = 52;
							((DataGridView)MSG).Columns[num6].HeaderText = Strings.Mid(DC_Main.RsDg.Columns[num6].ColumnName, 1, num5);
							goto IL_056e;
							IL_050c:
							num2 = 50;
							num5 = Strings.Len(DC_Main.RsDg.Columns[num6].ColumnName);
							goto IL_052c;
							IL_056e:
							num2 = 53;
							HelpWidth = (int)Math.Round((double)HelpWidth + DC_Main.ColWidth[num6] * ColCon);
							goto IL_0594;
							IL_000b:
							num2 = 2;
							((Control)this).ResumeLayout();
							goto IL_0014;
							IL_0014:
							num2 = 3;
							num7 = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
							goto IL_0028;
							IL_0028:
							num2 = 4;
							num8 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
							goto IL_003d;
							IL_003d:
							num2 = 5;
							ColCon = 1.0 + num7;
							goto IL_0050;
							IL_0050:
							num2 = 6;
							enumerator = ((Control)this).Controls.GetEnumerator();
							goto IL_010d;
							IL_010d:
							if (enumerator.MoveNext())
							{
								val = (Control)enumerator.Current;
								goto IL_0072;
							}
							goto IL_011d;
							IL_011d:
							num2 = 12;
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
							goto IL_0136;
							IL_059d:
							num2 = 55;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
							goto IL_05bf;
							IL_0136:
							num2 = 13;
							colorConverter = new ColorConverter();
							goto IL_0140;
							IL_0140:
							num2 = 14;
							if (DC_Main.MsCoTheme == 1)
							{
								goto IL_0154;
							}
							goto IL_01e3;
							IL_0154:
							num2 = 15;
							obj = colorConverter.ConvertFromString("Tan");
							((Form)this).BackColor = ((obj != null) ? ((Color)obj) : default(Color));
							goto IL_017f;
							IL_05f5:
							num2 = 57;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
							goto IL_0779;
							IL_061d:
							num2 = 59;
							if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num6].ColumnName, num5, num5), "M", false) == 0)
							{
								goto IL_0653;
							}
							goto IL_067b;
							IL_05bf:
							num2 = 56;
							if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num6].ColumnName, num5, num5), "L", false) == 0)
							{
								goto IL_05f5;
							}
							goto IL_061d;
							IL_017f:
							num2 = 16;
							((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
							goto IL_0194;
							IL_0194:
							num2 = 17;
							mSG = MSG;
							obj2 = colorConverter.ConvertFromString("SeaShell");
							((DataGridView)mSG).BackgroundColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
							goto IL_01c4;
							IL_067b:
							num2 = 62;
							if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num6].ColumnName, num5, num5), "R", false) == 0)
							{
								goto IL_06b1;
							}
							goto IL_06fb;
							IL_06b1:
							num2 = 63;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
							goto IL_06d3;
							IL_0653:
							num2 = 60;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
							goto IL_0779;
							IL_01c4:
							num2 = 18;
							((DataGridView)MSG).AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
							goto IL_03ff;
							IL_01e3:
							num2 = 20;
							if (DC_Main.MsCoTheme == 2)
							{
								goto IL_01f7;
							}
							goto IL_02a2;
							IL_01f7:
							num2 = 21;
							obj3 = colorConverter.ConvertFromString("Gray");
							((Form)this).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
							goto IL_0222;
							IL_06fb:
							num2 = 66;
							if (Operators.CompareString(Strings.Mid(DC_Main.RsDg.Columns[num6].ColumnName, num5, num5), "W", false) == 0)
							{
								goto IL_0731;
							}
							goto IL_0779;
							IL_0731:
							num2 = 67;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
							goto IL_0753;
							IL_06d3:
							num2 = 64;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Format = "0.00";
							goto IL_0779;
							IL_0222:
							num2 = 22;
							((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
							goto IL_0237;
							IL_0237:
							num2 = 23;
							mSG2 = MSG;
							obj4 = colorConverter.ConvertFromString("174, 184, 194");
							((DataGridView)mSG2).BackgroundColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
							goto IL_0267;
							IL_0779:
							num2 = 70;
							num6++;
							goto IL_0782;
							IL_099e:
							ProjectData.ClearProjectError();
							num3 = -2;
							goto IL_09a7;
							IL_0753:
							num2 = 68;
							((DataGridView)MSG).Columns[num6].DefaultCellStyle.Format = "0.000";
							goto IL_0779;
							IL_0267:
							num2 = 24;
							alternatingRowsDefaultCellStyle = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
							obj5 = colorConverter.ConvertFromString("243, 240, 239");
							alternatingRowsDefaultCellStyle.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
							goto IL_03ff;
							IL_09b0:
							num2 = 95;
							DC_Main.ColValue[DC_Main.X] = "";
							goto IL_09c3;
							IL_09c3:
							num2 = 96;
							DC_Main.X++;
							if (DC_Main.X <= 10)
							{
								goto IL_09b0;
							}
							goto IL_09db;
							IL_09a7:
							num2 = 94;
							DC_Main.X = 0;
							goto IL_09b0;
							IL_02a2:
							num2 = 26;
							if (DC_Main.MsCoTheme == 3)
							{
								goto IL_02b6;
							}
							goto IL_0345;
							IL_02b6:
							num2 = 27;
							((Form)this).BackColor = Color.LightSlateGray;
							goto IL_02c5;
							IL_02c5:
							num2 = 28;
							((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
							goto IL_02da;
							IL_02da:
							num2 = 29;
							mSG3 = MSG;
							obj6 = colorConverter.ConvertFromString("174, 184, 194");
							((DataGridView)mSG3).BackgroundColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
							goto IL_030a;
							IL_09eb:
							num2 = 98;
							((DataGridView)MSG).Rows.Clear();
							goto IL_09ff;
							IL_09ff:
							num2 = 99;
							((DataGridView)MSG).Columns.Clear();
							goto IL_0a13;
							IL_09db:
							num2 = 97;
							((DataGridView)MSG).DataSource = null;
							goto IL_09eb;
							IL_030a:
							num2 = 30;
							alternatingRowsDefaultCellStyle2 = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
							obj7 = colorConverter.ConvertFromString("233, 235, 240");
							alternatingRowsDefaultCellStyle2.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
							goto IL_03ff;
							IL_0a23:
							num2 = 102;
							((Control)this).Left = (int)Math.Round((double)(Screen.PrimaryScreen.WorkingArea.Width - ((Control)this).Width) / 2.0);
							goto IL_0a58;
							IL_0a58:
							num2 = 103;
							((Control)this).Top = (int)Math.Round((double)(Screen.PrimaryScreen.WorkingArea.Height - ((Control)this).Height) / 2.0);
							goto IL_0a8d;
							IL_0a13:
							num2 = 100;
							((Control)MSG).Refresh();
							goto IL_0a23;
							IL_0345:
							num2 = 32;
							if (DC_Main.MsCoTheme == 4)
							{
								goto IL_0359;
							}
							goto IL_03ff;
							IL_0359:
							num2 = 33;
							obj8 = colorConverter.ConvertFromString("CadetBlue");
							((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
							goto IL_0384;
							IL_0aa9:
							num2 = 105;
							tSearchText.Text = DC_Main.MsMobileLen;
							goto IL_0abd;
							IL_0abd:
							num2 = 106;
							DC_Main.MsMobileLen = "";
							break;
							IL_0a8d:
							num2 = 104;
							if (Operators.CompareString(DC_Main.MsMobileLen, "", false) == 0)
							{
								break;
							}
							goto IL_0aa9;
							IL_0384:
							num2 = 34;
							((TextBoxBase)tSearchText).BackColor = ((Form)this).BackColor;
							goto IL_0399;
							IL_0399:
							num2 = 35;
							mSG4 = MSG;
							obj9 = colorConverter.ConvertFromString("Ivory");
							((DataGridView)mSG4).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
							goto IL_03c9;
							IL_0072:
							num2 = 7;
							(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num7);
							goto IL_0097;
							IL_0097:
							num2 = 8;
							(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num8);
							goto IL_00bd;
							IL_0594:
							num2 = 54;
							num5++;
							goto IL_059d;
							IL_03c9:
							num2 = 36;
							alternatingRowsDefaultCellStyle3 = ((DataGridView)MSG).AlternatingRowsDefaultCellStyle;
							obj10 = colorConverter.ConvertFromString("238, 244, 236");
							alternatingRowsDefaultCellStyle3.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
							goto IL_03ff;
							IL_00e3:
							num2 = 10;
							(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num8);
							goto IL_010a;
							IL_010a:
							num2 = 11;
							goto IL_010d;
							IL_00bd:
							num2 = 9;
							(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num7);
							goto IL_00e3;
							IL_03ff:
							num2 = 38;
							ColNumber = 0;
							goto IL_0409;
							IL_0409:
							num2 = 39;
							((DataGridView)MSG).Columns.Clear();
							goto IL_041d;
							IL_041d:
							num2 = 40;
							((DataGridView)MSG).MultiSelect = false;
							goto IL_042d;
							IL_042d:
							num2 = 41;
							tSearchText.Text = "";
							goto IL_0441;
							IL_0441:
							num2 = 42;
							DC_Main.HelpClose = false;
							goto IL_044a;
							IL_044a:
							num2 = 43;
							if (DC_Main.RsDg.Rows.Count > 0)
							{
								goto IL_0468;
							}
							goto IL_099e;
							IL_0468:
							num2 = 44;
							((DataGridView)MSG).DataSource = DC_Main.RsDg;
							goto IL_047c;
							IL_047c:
							num2 = 45;
							HelpWidth = 0;
							goto IL_0486;
							IL_0486:
							num2 = 46;
							num9 = DC_Main.RsDg.Columns.Count - 1;
							num6 = 0;
							goto IL_0782;
							IL_0782:
							if (num6 <= num9)
							{
								goto IL_04a4;
							}
							goto IL_078b;
							IL_078b:
							num2 = 71;
							((Control)MSG).Top = 32;
							goto IL_079c;
							IL_079c:
							num2 = 72;
							((Control)MSG).Width = HelpWidth + 25;
							goto IL_07b4;
							IL_07b4:
							num2 = 73;
							((Control)MSG).Height = ((Control)this).Height - 65;
							goto IL_07cc;
							IL_07cc:
							num2 = 74;
							((Control)tSearchText).Top = ((Control)MSG).Bottom + 7;
							goto IL_07e8;
							IL_07e8:
							num2 = 75;
							((Control)tSearchText).Left = ((Control)MSG).Left + 5;
							goto IL_0804;
							IL_0804:
							num2 = 76;
							((Control)tSearchText).Width = ((Control)MSG).Width;
							goto IL_081e;
							IL_081e:
							num2 = 77;
							((Control)this).Width = ((Control)MSG).Width + 30;
							goto IL_0836;
							IL_0836:
							num2 = 78;
							((Control)MSG).Left = (int)Math.Round(15.0 * ColCon);
							goto IL_085b;
							IL_085b:
							num2 = 79;
							((Control)LblHelpName).Left = ((Control)MSG).Left;
							goto IL_0875;
							IL_0875:
							num2 = 80;
							((Control)LblHelpName).Top = 9;
							goto IL_0886;
							IL_0886:
							num2 = 81;
							((Control)LblExit).Left = ((Control)MSG).Right - 20;
							goto IL_08a3;
							IL_08a3:
							num2 = 82;
							((Control)LblExit).Top = 9;
							goto IL_08b4;
							IL_08b4:
							num2 = 83;
							((Control)tSearchText).Width = ((Control)MSG).Width;
							goto IL_08ce;
							IL_08ce:
							num2 = 84;
							DC_Main.ColValue = new string[DC_Main.RsDg.Columns.Count - 1 + 1];
							goto IL_08ee;
							IL_08ee:
							num2 = 85;
							((DataGridView)MSG).Rows[((DataGridView)MSG).RowCount - 1].Cells[0].Selected = true;
							goto IL_0920;
							IL_0920:
							num2 = 86;
							if (DC_Main.HelpSelect == 1)
							{
								goto IL_0931;
							}
							goto IL_095b;
							IL_0931:
							num2 = 87;
							((DataGridView)MSG).Rows[0].Cells[0].Selected = true;
							goto IL_098e;
							IL_095b:
							num2 = 89;
							((DataGridView)MSG).Rows[((DataGridView)MSG).RowCount - 1].Cells[0].Selected = true;
							goto IL_098e;
							IL_098e:
							num2 = 91;
							DC_Main.HelpSelect = 0;
							goto IL_0a23;
							IL_04a4:
							num2 = 47;
							((DataGridView)MSG).Columns[num6].Width = (int)Math.Round(DC_Main.ColWidth[num6] * ColCon);
							goto IL_04d4;
							IL_04d4:
							num2 = 48;
							if (DC_Main.ColWidth[num6] == 0.0)
							{
								goto IL_04f0;
							}
							goto IL_050c;
							IL_04f0:
							num2 = 49;
							((DataGridView)MSG).Columns[num6].Visible = false;
							goto IL_050c;
							end_IL_0001_2:
							break;
						}
						num2 = 108;
						((Control)MSG).Focus();
						break;
					}
					end_IL_0001:;
				}
				catch (object obj11) when (obj11 is Exception && num3 != 0 && num == 0)
				{
					ProjectData.SetProjectError((Exception)obj11);
					try0001_dispatch = 3236;
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

		private void tSearchText_TextChanged(object sender, EventArgs e)
		{
			int try0001_dispatch = -1;
			int num3 = default(int);
			int num = default(int);
			int num2 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			DataView dataView = default(DataView);
			string columnName = default(string);
			string text = default(string);
			int num7 = default(int);
			int num8 = default(int);
			DataView dataView2 = default(DataView);
			string columnName2 = default(string);
			string text2 = default(string);
			int num9 = default(int);
			int num10 = default(int);
			int num11 = default(int);
			int num12 = default(int);
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
						case 2661:
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
									goto IL_000f;
								case 5:
									goto IL_002a;
								case 6:
									goto IL_003d;
								case 7:
									goto IL_005b;
								case 8:
									goto IL_007f;
								case 9:
									goto IL_008d;
								case 10:
									goto IL_00ac;
								case 11:
									goto IL_00f0;
								case 12:
									goto IL_011a;
								case 14:
									goto IL_0161;
								case 15:
									goto IL_017d;
								case 17:
									goto IL_0204;
								case 13:
								case 16:
								case 18:
								case 19:
									goto IL_023f;
								case 20:
									goto IL_0252;
								case 21:
									goto IL_0263;
								case 24:
									goto IL_0299;
								case 25:
									goto IL_02ad;
								case 28:
									goto IL_02e4;
								case 29:
									goto IL_0303;
								case 30:
									goto IL_0328;
								case 31:
									goto IL_0337;
								case 32:
									goto IL_0356;
								case 33:
									goto IL_039a;
								case 34:
									goto IL_03c4;
								case 36:
									goto IL_040b;
								case 37:
									goto IL_0427;
								case 39:
									goto IL_04ae;
								case 35:
								case 38:
								case 40:
								case 41:
									goto IL_04e9;
								case 42:
									goto IL_04fc;
								case 43:
									goto IL_050d;
								case 46:
									goto IL_0543;
								case 47:
									goto IL_0557;
								case 50:
									goto IL_058e;
								case 51:
									goto IL_05ad;
								case 52:
									goto IL_05d2;
								case 53:
									goto IL_05f1;
								case 54:
									goto IL_062c;
								case 55:
									goto IL_0658;
								case 57:
								case 58:
									goto IL_0678;
								case 61:
									goto IL_0692;
								case 62:
									goto IL_06b1;
								case 63:
									goto IL_06ea;
								case 64:
									goto IL_0709;
								case 65:
									goto IL_0733;
								case 66:
									goto IL_076e;
								case 67:
									goto IL_078a;
								case 69:
								case 70:
									goto IL_07ba;
								case 68:
								case 71:
									goto IL_07c9;
								case 74:
									goto IL_07e4;
								case 75:
									goto IL_07fe;
								case 76:
									goto IL_0812;
								case 77:
									goto IL_0837;
								case 78:
									goto IL_0856;
								case 79:
									goto IL_0891;
								case 80:
									goto end_IL_0001_2;
								case 82:
								case 83:
									goto IL_08dd;
								default:
									goto end_IL_0001;
								case 4:
								case 22:
								case 23:
								case 26:
								case 27:
								case 44:
								case 45:
								case 48:
								case 49:
								case 56:
								case 59:
								case 60:
								case 72:
								case 73:
								case 81:
								case 84:
								case 85:
								case 86:
								case 87:
									goto end_IL_0001_3;
								}
								goto default;
							}
							IL_078a:
							num2 = 67;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num5].Cells[num6];
							goto IL_07c9;
							IL_07c9:
							num2 = 71;
							num5++;
							goto IL_07d2;
							IL_076e:
							num2 = 66;
							((DataGridView)MSG).Rows[num5].Selected = true;
							goto IL_078a;
							IL_07ba:
							num2 = 70;
							num6++;
							goto IL_07c1;
							IL_000b:
							num2 = 2;
							num6 = 0;
							goto IL_000f;
							IL_000f:
							num2 = 3;
							if (((DataGridView)MSG).CurrentCell == null)
							{
								goto end_IL_0001_3;
							}
							goto IL_002a;
							IL_002a:
							num2 = 5;
							num6 = ((DataGridView)MSG).CurrentCell.ColumnIndex;
							goto IL_003d;
							IL_003d:
							num2 = 6;
							if (Operators.CompareString(DC_Main.MsHelpSearch, "S", false) == 0)
							{
								goto IL_005b;
							}
							goto IL_02e4;
							IL_005b:
							num2 = 7;
							if (Operators.CompareString(tSearchText.Text, "", false) != 0)
							{
								goto IL_007f;
							}
							goto IL_0299;
							IL_007f:
							num2 = 8;
							dataView = new DataView(DC_Main.RsDg);
							goto IL_008d;
							IL_008d:
							num2 = 9;
							columnName = DC_Main.RsDg.Columns[ColNumber].ColumnName;
							goto IL_00ac;
							IL_00ac:
							num2 = 10;
							text = Strings.Mid(DC_Main.RsDg.Columns[ColNumber].ColumnName, Strings.Len(DC_Main.RsDg.Columns[ColNumber].ColumnName), 1);
							goto IL_00f0;
							IL_00f0:
							num2 = 11;
							if ((Operators.CompareString(text, "L", false) == 0) | (Operators.CompareString(text, "M", false) == 0))
							{
								goto IL_011a;
							}
							goto IL_0161;
							IL_011a:
							num2 = 12;
							dataView.RowFilter = " " + columnName + " Like  '" + tSearchText.Text + "%' ";
							goto IL_023f;
							IL_0161:
							num2 = 14;
							if (Operators.CompareString(text, "W", false) == 0)
							{
								goto IL_017d;
							}
							goto IL_0204;
							IL_017d:
							num2 = 15;
							dataView.RowFilter = (" " + columnName + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text)) + " AND " + columnName + " <= " + Conversions.ToString(Conversion.Val(tSearchText.Text) + 0.3)) ?? "";
							goto IL_023f;
							IL_07fe:
							num2 = 75;
							num6 = ((DataGridView)MSG).CurrentCell.ColumnIndex;
							goto IL_0812;
							IL_07e4:
							num2 = 74;
							if (((DataGridView)MSG).CurrentCell == null)
							{
								goto end_IL_0001_3;
							}
							goto IL_07fe;
							IL_0204:
							num2 = 17;
							dataView.RowFilter = (" " + columnName + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text))) ?? "";
							goto IL_023f;
							IL_0837:
							num2 = 77;
							num7 = ((DataGridView)MSG).Rows.Count - 1;
							num8 = 0;
							goto IL_08e6;
							IL_0812:
							num2 = 76;
							if (Operators.CompareString(tSearchText.Text, "", false) == 0)
							{
								goto end_IL_0001_3;
							}
							goto IL_0837;
							IL_023f:
							num2 = 19;
							if (dataView.Count <= 0)
							{
								goto end_IL_0001_3;
							}
							goto IL_0252;
							IL_0252:
							num2 = 20;
							((DataGridView)MSG).DataSource = dataView;
							goto IL_0263;
							IL_0263:
							num2 = 21;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
							goto end_IL_0001_3;
							IL_0299:
							num2 = 24;
							((DataGridView)MSG).DataSource = DC_Main.RsDg;
							goto IL_02ad;
							IL_02ad:
							num2 = 25;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
							goto end_IL_0001_3;
							IL_02e4:
							num2 = 28;
							if (Operators.CompareString(DC_Main.MsHelpSearch, "M", false) == 0)
							{
								goto IL_0303;
							}
							goto IL_058e;
							IL_0303:
							num2 = 29;
							if (Operators.CompareString(tSearchText.Text, "", false) != 0)
							{
								goto IL_0328;
							}
							goto IL_0543;
							IL_0328:
							num2 = 30;
							dataView2 = new DataView(DC_Main.RsDg);
							goto IL_0337;
							IL_0337:
							num2 = 31;
							columnName2 = DC_Main.RsDg.Columns[ColNumber].ColumnName;
							goto IL_0356;
							IL_0356:
							num2 = 32;
							text2 = Strings.Mid(DC_Main.RsDg.Columns[ColNumber].ColumnName, Strings.Len(DC_Main.RsDg.Columns[ColNumber].ColumnName), 1);
							goto IL_039a;
							IL_039a:
							num2 = 33;
							if ((Operators.CompareString(text2, "L", false) == 0) | (Operators.CompareString(text2, "M", false) == 0))
							{
								goto IL_03c4;
							}
							goto IL_040b;
							IL_03c4:
							num2 = 34;
							dataView2.RowFilter = " " + columnName2 + " Like '%" + tSearchText.Text + "%' ";
							goto IL_04e9;
							IL_040b:
							num2 = 36;
							if (Operators.CompareString(text2, "W", false) == 0)
							{
								goto IL_0427;
							}
							goto IL_04ae;
							IL_0427:
							num2 = 37;
							dataView2.RowFilter = (" " + columnName2 + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text)) + " AND " + columnName2 + " <= " + Conversions.ToString(Conversion.Val(tSearchText.Text) + 0.3)) ?? "";
							goto IL_04e9;
							IL_0856:
							num2 = 78;
							if (((DataGridView)MSG)[num6, num8].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
							{
								goto IL_0891;
							}
							goto IL_08dd;
							IL_08e6:
							if (num8 > num7)
							{
								goto end_IL_0001_3;
							}
							goto IL_0856;
							IL_04ae:
							num2 = 39;
							dataView2.RowFilter = (" " + columnName2 + " >= " + Conversions.ToString(Conversion.Val(tSearchText.Text))) ?? "";
							goto IL_04e9;
							IL_08dd:
							num2 = 83;
							num8++;
							goto IL_08e6;
							IL_0891:
							num2 = 79;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num8].Cells[num6];
							break;
							IL_04e9:
							num2 = 41;
							if (dataView2.Count <= 0)
							{
								goto end_IL_0001_3;
							}
							goto IL_04fc;
							IL_04fc:
							num2 = 42;
							((DataGridView)MSG).DataSource = dataView2;
							goto IL_050d;
							IL_050d:
							num2 = 43;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
							goto end_IL_0001_3;
							IL_0543:
							num2 = 46;
							((DataGridView)MSG).DataSource = DC_Main.RsDg;
							goto IL_0557;
							IL_0557:
							num2 = 47;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
							goto end_IL_0001_3;
							IL_058e:
							num2 = 50;
							if (Operators.CompareString(DC_Main.MsHelpSearch, "W", false) == 0)
							{
								goto IL_05ad;
							}
							goto IL_0692;
							IL_05ad:
							num2 = 51;
							if (Operators.CompareString(tSearchText.Text, "", false) == 0)
							{
								goto end_IL_0001_3;
							}
							goto IL_05d2;
							IL_05d2:
							num2 = 52;
							num9 = ((DataGridView)MSG).Rows.Count - 1;
							num10 = 0;
							goto IL_0681;
							IL_0681:
							if (num10 > num9)
							{
								goto end_IL_0001_3;
							}
							goto IL_05f1;
							IL_05f1:
							num2 = 53;
							if (((DataGridView)MSG)[num6, num10].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
							{
								goto IL_062c;
							}
							goto IL_0678;
							IL_062c:
							num2 = 54;
							((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[num10].Cells[num6];
							goto IL_0658;
							IL_0658:
							num2 = 55;
							((DataGridView)MSG).Rows[num10].Selected = true;
							goto end_IL_0001_3;
							IL_0678:
							num2 = 58;
							num10++;
							goto IL_0681;
							IL_0692:
							num2 = 61;
							if (Operators.CompareString(DC_Main.MsHelpSearch, "A", false) == 0)
							{
								goto IL_06b1;
							}
							goto IL_07e4;
							IL_06b1:
							num2 = 62;
							if (!((Operators.CompareString(tSearchText.Text, "", false) != 0) & (Strings.Len(tSearchText.Text) > 2)))
							{
								goto end_IL_0001_3;
							}
							goto IL_06ea;
							IL_06ea:
							num2 = 63;
							num11 = ((DataGridView)MSG).Rows.Count - 1;
							num5 = 0;
							goto IL_07d2;
							IL_07d2:
							if (num5 > num11)
							{
								goto end_IL_0001_3;
							}
							goto IL_0709;
							IL_0709:
							num2 = 64;
							num12 = ((BaseCollection)((DataGridView)MSG).Rows[num5].Cells).Count - 1;
							num6 = 0;
							goto IL_07c1;
							IL_07c1:
							if (num6 <= num12)
							{
								goto IL_0733;
							}
							goto IL_07c9;
							IL_0733:
							num2 = 65;
							if (((DataGridView)MSG)[num6, num5].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
							{
								goto IL_076e;
							}
							goto IL_07ba;
							end_IL_0001_2:
							break;
						}
						num2 = 80;
						((DataGridView)MSG).Rows[num8].Selected = true;
						break;
					}
					end_IL_0001:;
				}
				catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
				{
					ProjectData.SetProjectError((Exception)obj);
					try0001_dispatch = 2661;
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

		private void MSG_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int try0001_dispatch = -1;
			int num3 = default(int);
			int num = default(int);
			int num2 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			int rowIndex = default(int);
			while (true)
			{
				try
				{
					/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 196:
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
								goto IL_0014;
							case 4:
								goto IL_002e;
							case 5:
								goto IL_0044;
							case 6:
								goto IL_0075;
							case 7:
							case 8:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 9:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_007d:
						if (num5 > num6)
						{
							break;
						}
						goto IL_0044;
						IL_0044:
						num2 = 5;
						DC_Main.ColValue[num5] = Conversions.ToString(((DataGridView)MSG).Rows[rowIndex].Cells[num5].Value);
						goto IL_0075;
						IL_002e:
						num2 = 4;
						num6 = checked(((DataGridView)MSG).ColumnCount - 1);
						num5 = 0;
						goto IL_007d;
						IL_0075:
						num2 = 6;
						num5 = checked(num5 + 1);
						goto IL_007d;
						IL_000b:
						num2 = 2;
						rowIndex = e.RowIndex;
						goto IL_0014;
						IL_0014:
						num2 = 3;
						if (DC_Main.RsDg.Rows.Count <= 0)
						{
							break;
						}
						goto IL_002e;
						end_IL_0001_2:
						break;
					}
					num2 = 8;
					((Form)this).Close();
					break;
					end_IL_0001:;
				}
				catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
				{
					ProjectData.SetProjectError((Exception)obj);
					try0001_dispatch = 196;
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

		private void MSG_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Invalid comparison between Unknown and I4
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Invalid comparison between Unknown and I4
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Invalid comparison between Unknown and I4
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Invalid comparison between Unknown and I4
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 37)
			{
				tSearchText.Text = "";
				if (((DataGridView)MSG).CurrentCell.ColumnIndex > 0)
				{
					ColNumber = checked(((DataGridView)MSG).CurrentCell.ColumnIndex - 1);
				}
			}
			else if ((int)e.KeyCode == 39)
			{
				tSearchText.Text = "";
				checked
				{
					if (((DataGridView)MSG).CurrentCell.ColumnIndex < DC_Main.RsDg.Columns.Count - 1)
					{
						ColNumber = ((DataGridView)MSG).CurrentCell.ColumnIndex + 1;
					}
				}
			}
			else
			{
				if ((int)e.KeyCode == 38 || (int)e.KeyCode == 40)
				{
					return;
				}
				if ((int)e.KeyCode == 8)
				{
					if (Strings.Len(tSearchText.Text) > 0)
					{
						tSearchText.Text = Strings.Mid(tSearchText.Text, 1, checked(Strings.Len(tSearchText.Text) - 1));
					}
				}
				else
				{
					if ((int)e.KeyCode != 13)
					{
						return;
					}
					if (DC_Main.RsDg.Rows.Count == 0)
					{
						DC_Main.HelpClose = true;
						((Form)this).Close();
						return;
					}
					int index = ((DataGridViewBand)((DataGridView)MSG).CurrentRow).Index;
					checked
					{
						if (DC_Main.RsDg.Rows.Count > 0)
						{
							int num = ((DataGridView)MSG).ColumnCount - 1;
							DC_Main.X = 0;
							while (DC_Main.X <= num)
							{
								DC_Main.ColValue[DC_Main.X] = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)MSG).Rows[index].Cells[DC_Main.X].Value, (object)""));
								DC_Main.X++;
							}
						}
						((Form)this).Close();
					}
				}
			}
		}

		private void MSG_CLEAR()
		{
			((DataGridView)MSG).DataSource = null;
		}

		private void MS_HELP_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 27)
			{
				((Form)this).Close();
			}
			else if ((int)e.KeyCode == 112)
			{
				if (DC_Main.MsCreat)
				{
					DC_Main.MsSubCreat = true;
				}
				else
				{
					DC_Main.MsCreat = true;
				}
				((Form)this).Close();
			}
		}

		private void MS_HELP_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Operators.CompareString(tSearchText.Text, "", false) == 0)
			{
				((Control)tSearchText).Focus();
			}
		}

		private void LblExit_Click(object sender, EventArgs e)
		{
			((Form)this).Close();
		}

		private void MSG_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void tSearchText_KeyDown(object sender, KeyEventArgs e)
		{
			((Control)MSG).Focus();
		}

		private void MSG_KeyPress(object sender, KeyPressEventArgs e)
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
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 251:
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
								goto IL_0022;
							case 4:
							case 5:
								goto IL_0057;
							case 6:
								goto IL_0065;
							case 7:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 8:
							case 9:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0022:
						num2 = 3;
						tSearchText.Text += Conversions.ToString(Strings.Chr(Strings.Asc(e.KeyChar)));
						goto IL_0057;
						IL_0057:
						num2 = 5;
						((Control)MSG).Focus();
						goto IL_0065;
						IL_000b:
						num2 = 2;
						if (Strings.Asc(e.KeyChar) != 8)
						{
							goto IL_0022;
						}
						goto IL_0057;
						IL_0065:
						num2 = 6;
						if (!((Operators.CompareString(DC_Main.MsHelpSearch, "S", false) == 0) | (Operators.CompareString(DC_Main.MsHelpSearch, "M", false) == 0)))
						{
							goto end_IL_0001_3;
						}
						break;
						end_IL_0001_2:
						break;
					}
					num2 = 7;
					((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
					break;
					end_IL_0001:;
				}
				catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
				{
					ProjectData.SetProjectError((Exception)obj);
					try0001_dispatch = 251;
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

		private void MS_HELP_Activated(object sender, EventArgs e)
		{
			((Control)MSG).Focus();
			if (((Operators.CompareString(DC_Main.MsHelpSearch, "S", false) == 0) | (Operators.CompareString(DC_Main.MsHelpSearch, "M", false) == 0)) && Operators.CompareString(tSearchText.Text, "", false) != 0)
			{
				((DataGridView)MSG).CurrentCell = ((DataGridView)MSG).Rows[0].Cells[ColNumber];
			}
		}
	}
	[DesignerGenerated]
	public class UT_WHATSAPP_OLD : Form
	{
		public enum GridViewColumnType
		{
			TextBox,
			InvisibleTextBoxCell
		}

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
		[AccessedThroughProperty("CboSmsType")]
		private ComboBox _CboSmsType;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("nFromOs")]
		private TextBox _nFromOs;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("nToOs")]
		private TextBox _nToOs;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnOk")]
		private QButton _btnOk;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("tMobileNo")]
		private TextBox _tMobileNo;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("BtnSmsSend")]
		private QButton _BtnSmsSend;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("BtnAc")]
		private SimpleButton _BtnAc;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("BtnMemb")]
		private SimpleButton _BtnMemb;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("chkAllRow")]
		private CheckBox _chkAllRow;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnExlImport")]
		private QButton _btnExlImport;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("cboBarth")]
		private ComboBox _cboBarth;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("Timer1")]
		private Timer _Timer1;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnWappInstall")]
		private QButton _btnWappInstall;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("chkBoxHeadLess")]
		private CheckBox _chkBoxHeadLess;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("statusRetriever")]
		private Timer _statusRetriever;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnAcOs")]
		private QButton _btnAcOs;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("cboMsgType")]
		private ComboBox _cboMsgType;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnGoldRate")]
		private QButton _btnGoldRate;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("BtnLogout")]
		private QButton _BtnLogout;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnQuit")]
		private QButton _btnQuit;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("btnDelyTime")]
		private SimpleButton _btnDelyTime;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("nFromRow")]
		private TextBox _nFromRow;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("nToRow")]
		private TextBox _nToRow;

		public static WhatsApp whatsApp;

		private int sec;

		private string _translationSpeakUrl;

		private Control CurActCtrl;

		private double ColCon;

		private DataTable RsMast;

		private string EntryMode;

		private bool MsgLess;

		private bool OsMsg;

		private bool RateMsg;

		private bool ExelMsg;

		private DateTime WappEndDate;

		private string theWebSite;

		private string ScelectMo;

		private string SendDetl;

		private int SendRow;

		private int TotSms;

		private string[] AryGroup;

		private int MaxPages;

		private int LastRow;

		private int Pages;

		private bool WhatsappLoad;

		private string IdWappIdNo;

		private string MsCountryId;

		private State state;

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

		[field: AccessedThroughProperty("BtnPrint")]
		internal virtual SimpleButton BtnPrint
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblBook")]
		internal virtual Label lblBook
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Cr")]
		internal virtual AxCrystalReport Cr
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("dlgOpen")]
		internal virtual FolderBrowserDialog dlgOpen
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ComboBox CboSmsType
		{
			[CompilerGenerated]
			get
			{
				return _CboSmsType;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Expected O, but got Unknown
				EventHandler eventHandler = CboSmsType_SelectedIndexChanged;
				KeyEventHandler val = new KeyEventHandler(CboSmsType_KeyDown);
				ComboBox val2 = _CboSmsType;
				if (val2 != null)
				{
					val2.SelectedIndexChanged -= eventHandler;
					((Control)val2).KeyDown -= val;
				}
				_CboSmsType = value;
				val2 = _CboSmsType;
				if (val2 != null)
				{
					val2.SelectedIndexChanged += eventHandler;
					((Control)val2).KeyDown += val;
				}
			}
		}

		internal virtual TextBox nFromOs
		{
			[CompilerGenerated]
			get
			{
				return _nFromOs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected O, but got Unknown
				KeyEventHandler val = new KeyEventHandler(nFromOs_KeyDown);
				TextBox val2 = _nFromOs;
				if (val2 != null)
				{
					((Control)val2).KeyDown -= val;
				}
				_nFromOs = value;
				val2 = _nFromOs;
				if (val2 != null)
				{
					((Control)val2).KeyDown += val;
				}
			}
		}

		internal virtual TextBox nToOs
		{
			[CompilerGenerated]
			get
			{
				return _nToOs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected O, but got Unknown
				KeyEventHandler val = new KeyEventHandler(nToOs_KeyDown);
				TextBox val2 = _nToOs;
				if (val2 != null)
				{
					((Control)val2).KeyDown -= val;
				}
				_nToOs = value;
				val2 = _nToOs;
				if (val2 != null)
				{
					((Control)val2).KeyDown += val;
				}
			}
		}

		[field: AccessedThroughProperty("Label5")]
		internal virtual Label Label5
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Label1")]
		internal virtual Label Label1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Label2")]
		internal virtual Label Label2
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("DGV")]
		internal virtual DataGridViewX DGV
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
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

		[field: AccessedThroughProperty("Label3")]
		internal virtual Label Label3
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox tMobileNo
		{
			[CompilerGenerated]
			get
			{
				return _tMobileNo;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = TMobileNo_TextChanged;
				TextBox val = _tMobileNo;
				if (val != null)
				{
					((Control)val).TextChanged -= eventHandler;
				}
				_tMobileNo = value;
				val = _tMobileNo;
				if (val != null)
				{
					((Control)val).TextChanged += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("Label4")]
		internal virtual Label Label4
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual QButton BtnSmsSend
		{
			[CompilerGenerated]
			get
			{
				return _BtnSmsSend;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnSmsSend_Click;
				QButton val = _BtnSmsSend;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_BtnSmsSend = value;
				val = _BtnSmsSend;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		internal virtual SimpleButton BtnAc
		{
			[CompilerGenerated]
			get
			{
				return _BtnAc;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnAc_Click;
				SimpleButton val = _BtnAc;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_BtnAc = value;
				val = _BtnAc;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		internal virtual SimpleButton BtnMemb
		{
			[CompilerGenerated]
			get
			{
				return _BtnMemb;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnMemb_Click;
				SimpleButton val = _BtnMemb;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_BtnMemb = value;
				val = _BtnMemb;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		internal virtual CheckBox chkAllRow
		{
			[CompilerGenerated]
			get
			{
				return _chkAllRow;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = ChkAllRow_CheckedChanged;
				CheckBox val = _chkAllRow;
				if (val != null)
				{
					val.CheckedChanged -= eventHandler;
				}
				_chkAllRow = value;
				val = _chkAllRow;
				if (val != null)
				{
					val.CheckedChanged += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("lblSmsRow")]
		internal virtual Label lblSmsRow
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual QButton btnExlImport
		{
			[CompilerGenerated]
			get
			{
				return _btnExlImport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnExlImport_Click;
				QButton val = _btnExlImport;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnExlImport = value;
				val = _btnExlImport;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("DlgOpn")]
		internal virtual OpenFileDialog DlgOpn
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("tsmstype")]
		internal virtual TextBox tsmstype
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Label13")]
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ComboBox cboBarth
		{
			[CompilerGenerated]
			get
			{
				return _cboBarth;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = CboBarth_SelectedIndexChanged;
				ComboBox val = _cboBarth;
				if (val != null)
				{
					val.SelectedIndexChanged -= eventHandler;
				}
				_cboBarth = value;
				val = _cboBarth;
				if (val != null)
				{
					val.SelectedIndexChanged += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("ChkOnlyMoNo")]
		internal virtual CheckBox ChkOnlyMoNo
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblAcGroup")]
		internal virtual Label lblAcGroup
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("cboAcGroup")]
		internal virtual ComboBox cboAcGroup
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("BtnExcel")]
		internal virtual SimpleButton BtnExcel
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblSmsCount")]
		internal virtual Label lblSmsCount
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblMsgLenth")]
		internal virtual Label lblMsgLenth
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("_lnkSourceEnglish")]
		private virtual LinkLabel _lnkSourceEnglish
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("_lnkTargetEnglish")]
		private virtual LinkLabel _lnkTargetEnglish
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Timer Timer1
		{
			[CompilerGenerated]
			get
			{
				return _Timer1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = Timer1_Tick;
				Timer val = _Timer1;
				if (val != null)
				{
					val.Tick -= eventHandler;
				}
				_Timer1 = value;
				val = _Timer1;
				if (val != null)
				{
					val.Tick += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("lblWhatsAppState")]
		internal virtual Label lblWhatsAppState
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("LblSenderId")]
		internal virtual Label LblSenderId
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual QButton btnWappInstall
		{
			[CompilerGenerated]
			get
			{
				return _btnWappInstall;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnWappInstall_Click;
				QButton val = _btnWappInstall;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnWappInstall = value;
				val = _btnWappInstall;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("pBoxAuthQR")]
		private virtual PictureBox pBoxAuthQR
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual CheckBox chkBoxHeadLess
		{
			[CompilerGenerated]
			get
			{
				return _chkBoxHeadLess;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = chkBoxHeadLess_Click;
				CheckBox val = _chkBoxHeadLess;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_chkBoxHeadLess = value;
				val = _chkBoxHeadLess;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		private virtual Timer statusRetriever
		{
			[CompilerGenerated]
			get
			{
				return _statusRetriever;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = statusRetriever_Tick;
				Timer val = _statusRetriever;
				if (val != null)
				{
					val.Tick -= eventHandler;
				}
				_statusRetriever = value;
				val = _statusRetriever;
				if (val != null)
				{
					val.Tick += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("openAttach")]
		private virtual OpenFileDialog openAttach
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual QButton btnAcOs
		{
			[CompilerGenerated]
			get
			{
				return _btnAcOs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnAcOs_Click;
				QButton val = _btnAcOs;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnAcOs = value;
				val = _btnAcOs;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("Label17")]
		internal virtual Label Label17
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ComboBox cboMsgType
		{
			[CompilerGenerated]
			get
			{
				return _cboMsgType;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = CboMsgType_SelectedIndexChanged;
				ComboBox val = _cboMsgType;
				if (val != null)
				{
					val.SelectedIndexChanged -= eventHandler;
				}
				_cboMsgType = value;
				val = _cboMsgType;
				if (val != null)
				{
					val.SelectedIndexChanged += eventHandler;
				}
			}
		}

		internal virtual QButton btnGoldRate
		{
			[CompilerGenerated]
			get
			{
				return _btnGoldRate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnGoldRate_Click;
				QButton val = _btnGoldRate;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnGoldRate = value;
				val = _btnGoldRate;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		internal virtual QButton BtnLogout
		{
			[CompilerGenerated]
			get
			{
				return _BtnLogout;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnLogout_Click;
				QButton val = _BtnLogout;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_BtnLogout = value;
				val = _BtnLogout;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		internal virtual QButton btnQuit
		{
			[CompilerGenerated]
			get
			{
				return _btnQuit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnQuit_Click;
				QButton val = _btnQuit;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnQuit = value;
				val = _btnQuit;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("ProgressBar1")]
		internal virtual ProgressBar ProgressBar1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblDelay")]
		private virtual Label lblDelay
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("numDelay")]
		private virtual NumericUpDown numDelay
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual SimpleButton btnDelyTime
		{
			[CompilerGenerated]
			get
			{
				return _btnDelyTime;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler eventHandler = BtnDelyTime_Click;
				SimpleButton val = _btnDelyTime;
				if (val != null)
				{
					((Control)val).Click -= eventHandler;
				}
				_btnDelyTime = value;
				val = _btnDelyTime;
				if (val != null)
				{
					((Control)val).Click += eventHandler;
				}
			}
		}

		[field: AccessedThroughProperty("LblDays")]
		internal virtual Label LblDays
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Label7")]
		internal virtual Label Label7
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox nFromRow
		{
			[CompilerGenerated]
			get
			{
				return _nFromRow;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected O, but got Unknown
				KeyEventHandler val = new KeyEventHandler(nFromRow_KeyDown);
				TextBox val2 = _nFromRow;
				if (val2 != null)
				{
					((Control)val2).KeyDown -= val;
				}
				_nFromRow = value;
				val2 = _nFromRow;
				if (val2 != null)
				{
					((Control)val2).KeyDown += val;
				}
			}
		}

		[field: AccessedThroughProperty("Label8")]
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Label9")]
		internal virtual Label Label9
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox nToRow
		{
			[CompilerGenerated]
			get
			{
				return _nToRow;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Expected O, but got Unknown
				KeyEventHandler val = new KeyEventHandler(nToRow_KeyDown);
				TextBox val2 = _nToRow;
				if (val2 != null)
				{
					((Control)val2).KeyDown -= val;
				}
				_nToRow = value;
				val2 = _nToRow;
				if (val2 != null)
				{
					((Control)val2).KeyDown += val;
				}
			}
		}

		[field: AccessedThroughProperty("tMsg")]
		internal virtual RichTextBox tMsg
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("tCountryCode")]
		internal virtual TextBox tCountryCode
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("Label10")]
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("cboArea")]
		internal virtual ComboBox cboArea
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public UT_WHATSAPP_OLD()
		{
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			((Form)this).Load += UT_WHATSAPP_OLD_Load;
			((Form)this).Activated += UT_WHATSAPP_OLD_Activated;
			((Form)this).Deactivate += UT_WHATSAPP_OLD_Deactivate;
			((Control)this).KeyDown += new KeyEventHandler(UT_WHATSAPP_OLD_KeyDown);
			((Form)this).Closed += UT_WHATSAPP_OLD_Closed;
			sec = 0;
			state = (State)0;
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
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
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
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Expected O, but got Unknown
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected O, but got Unknown
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Expected O, but got Unknown
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Expected O, but got Unknown
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
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Expected O, but got Unknown
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_033b: Expected O, but got Unknown
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Expected O, but got Unknown
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Expected O, but got Unknown
			//IL_0481: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e4: Expected O, but got Unknown
			//IL_0547: Unknown result type (might be due to invalid IL or missing references)
			//IL_0551: Expected O, but got Unknown
			//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0605: Expected O, but got Unknown
			//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0704: Expected O, but got Unknown
			//IL_080b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0815: Expected O, but got Unknown
			//IL_0878: Unknown result type (might be due to invalid IL or missing references)
			//IL_0882: Expected O, but got Unknown
			//IL_092b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0935: Expected O, but got Unknown
			//IL_0998: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a2: Expected O, but got Unknown
			//IL_0a4b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a55: Expected O, but got Unknown
			//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ac2: Expected O, but got Unknown
			//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ba4: Expected O, but got Unknown
			//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c1c: Expected O, but got Unknown
			//IL_0ce8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cf2: Expected O, but got Unknown
			//IL_0d7d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d87: Expected O, but got Unknown
			//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e0f: Expected O, but got Unknown
			//IL_0e8d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e97: Expected O, but got Unknown
			//IL_0f42: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f4c: Expected O, but got Unknown
			//IL_0ffa: Unknown result type (might be due to invalid IL or missing references)
			//IL_1004: Expected O, but got Unknown
			//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_10d9: Expected O, but got Unknown
			//IL_116e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1178: Expected O, but got Unknown
			//IL_11f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_1200: Expected O, but got Unknown
			//IL_12d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_12e2: Expected O, but got Unknown
			//IL_134b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1355: Expected O, but got Unknown
			//IL_15f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1619: Unknown result type (might be due to invalid IL or missing references)
			//IL_163d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1661: Unknown result type (might be due to invalid IL or missing references)
			//IL_168a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1694: Expected O, but got Unknown
			//IL_16b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_172e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1738: Expected O, but got Unknown
			//IL_17ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_17f6: Expected O, but got Unknown
			//IL_187e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1888: Expected O, but got Unknown
			//IL_1b29: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b4d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b71: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b95: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bbe: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bc8: Expected O, but got Unknown
			//IL_1bee: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c82: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c8c: Expected O, but got Unknown
			//IL_1d61: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d6b: Expected O, but got Unknown
			//IL_1e04: Unknown result type (might be due to invalid IL or missing references)
			//IL_1e0e: Expected O, but got Unknown
			//IL_1f43: Unknown result type (might be due to invalid IL or missing references)
			//IL_1f4d: Expected O, but got Unknown
			//IL_2022: Unknown result type (might be due to invalid IL or missing references)
			//IL_202c: Expected O, but got Unknown
			//IL_20c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_20cf: Expected O, but got Unknown
			//IL_21e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_21f1: Expected O, but got Unknown
			//IL_22a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_22b2: Expected O, but got Unknown
			//IL_255a: Unknown result type (might be due to invalid IL or missing references)
			//IL_257e: Unknown result type (might be due to invalid IL or missing references)
			//IL_25a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_25c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_25ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_25f9: Expected O, but got Unknown
			//IL_261c: Unknown result type (might be due to invalid IL or missing references)
			//IL_26a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_26ae: Expected O, but got Unknown
			//IL_273f: Unknown result type (might be due to invalid IL or missing references)
			//IL_2749: Expected O, but got Unknown
			//IL_2813: Unknown result type (might be due to invalid IL or missing references)
			//IL_281d: Expected O, but got Unknown
			//IL_28c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_28d0: Expected O, but got Unknown
			//IL_298a: Unknown result type (might be due to invalid IL or missing references)
			//IL_2994: Expected O, but got Unknown
			//IL_2a5c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2a66: Expected O, but got Unknown
			//IL_2af2: Unknown result type (might be due to invalid IL or missing references)
			//IL_2afc: Expected O, but got Unknown
			//IL_2bb7: Unknown result type (might be due to invalid IL or missing references)
			//IL_2bc1: Expected O, but got Unknown
			//IL_2d9f: Unknown result type (might be due to invalid IL or missing references)
			//IL_2da9: Expected O, but got Unknown
			//IL_2ddd: Unknown result type (might be due to invalid IL or missing references)
			//IL_2e74: Unknown result type (might be due to invalid IL or missing references)
			//IL_2e7e: Expected O, but got Unknown
			//IL_2eb5: Unknown result type (might be due to invalid IL or missing references)
			//IL_312a: Unknown result type (might be due to invalid IL or missing references)
			//IL_314e: Unknown result type (might be due to invalid IL or missing references)
			//IL_3172: Unknown result type (might be due to invalid IL or missing references)
			//IL_3196: Unknown result type (might be due to invalid IL or missing references)
			//IL_31bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_31c9: Expected O, but got Unknown
			//IL_31ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_35e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_3607: Unknown result type (might be due to invalid IL or missing references)
			//IL_362b: Unknown result type (might be due to invalid IL or missing references)
			//IL_364f: Unknown result type (might be due to invalid IL or missing references)
			//IL_3678: Unknown result type (might be due to invalid IL or missing references)
			//IL_3682: Expected O, but got Unknown
			//IL_36a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_371c: Unknown result type (might be due to invalid IL or missing references)
			//IL_3726: Expected O, but got Unknown
			//IL_37f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_37fe: Expected O, but got Unknown
			//IL_3a80: Unknown result type (might be due to invalid IL or missing references)
			//IL_3aa4: Unknown result type (might be due to invalid IL or missing references)
			//IL_3ac8: Unknown result type (might be due to invalid IL or missing references)
			//IL_3aec: Unknown result type (might be due to invalid IL or missing references)
			//IL_3b15: Unknown result type (might be due to invalid IL or missing references)
			//IL_3b1f: Expected O, but got Unknown
			//IL_3b42: Unknown result type (might be due to invalid IL or missing references)
			//IL_3db7: Unknown result type (might be due to invalid IL or missing references)
			//IL_3ddb: Unknown result type (might be due to invalid IL or missing references)
			//IL_3dff: Unknown result type (might be due to invalid IL or missing references)
			//IL_3e23: Unknown result type (might be due to invalid IL or missing references)
			//IL_3e4c: Unknown result type (might be due to invalid IL or missing references)
			//IL_3e56: Expected O, but got Unknown
			//IL_3e79: Unknown result type (might be due to invalid IL or missing references)
			//IL_40dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_4101: Unknown result type (might be due to invalid IL or missing references)
			//IL_4125: Unknown result type (might be due to invalid IL or missing references)
			//IL_4149: Unknown result type (might be due to invalid IL or missing references)
			//IL_4172: Unknown result type (might be due to invalid IL or missing references)
			//IL_417c: Expected O, but got Unknown
			//IL_419f: Unknown result type (might be due to invalid IL or missing references)
			//IL_4263: Unknown result type (might be due to invalid IL or missing references)
			//IL_426d: Expected O, but got Unknown
			//IL_42f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_42fc: Expected O, but got Unknown
			//IL_43ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_43b5: Expected O, but got Unknown
			//IL_448a: Unknown result type (might be due to invalid IL or missing references)
			//IL_4494: Expected O, but got Unknown
			//IL_452d: Unknown result type (might be due to invalid IL or missing references)
			//IL_4537: Expected O, but got Unknown
			//IL_464f: Unknown result type (might be due to invalid IL or missing references)
			//IL_4659: Expected O, but got Unknown
			//IL_4711: Unknown result type (might be due to invalid IL or missing references)
			//IL_471b: Expected O, but got Unknown
			//IL_47d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_47dd: Expected O, but got Unknown
			//IL_486b: Unknown result type (might be due to invalid IL or missing references)
			//IL_4875: Expected O, but got Unknown
			//IL_492d: Unknown result type (might be due to invalid IL or missing references)
			//IL_4937: Expected O, but got Unknown
			//IL_49ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_49f9: Expected O, but got Unknown
			//IL_4a83: Unknown result type (might be due to invalid IL or missing references)
			//IL_4a8d: Expected O, but got Unknown
			//IL_4b39: Unknown result type (might be due to invalid IL or missing references)
			//IL_4b43: Expected O, but got Unknown
			//IL_4bd4: Unknown result type (might be due to invalid IL or missing references)
			//IL_4bde: Expected O, but got Unknown
			//IL_4ca6: Unknown result type (might be due to invalid IL or missing references)
			//IL_4cb0: Expected O, but got Unknown
			components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_WHATSAPP_OLD));
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
			BtnExcel = new SimpleButton();
			Cr = new AxCrystalReport();
			lblBook = new Label();
			CboSmsType = new ComboBox();
			nFromOs = new TextBox();
			nToOs = new TextBox();
			Label5 = new Label();
			Label1 = new Label();
			Label2 = new Label();
			DGV = new DataGridViewX();
			btnOk = new QButton();
			Label3 = new Label();
			tMobileNo = new TextBox();
			Label4 = new Label();
			BtnSmsSend = new QButton();
			BtnAc = new SimpleButton();
			BtnMemb = new SimpleButton();
			chkAllRow = new CheckBox();
			lblSmsRow = new Label();
			btnExlImport = new QButton();
			DlgOpn = new OpenFileDialog();
			tsmstype = new TextBox();
			Label13 = new Label();
			cboBarth = new ComboBox();
			ChkOnlyMoNo = new CheckBox();
			lblAcGroup = new Label();
			cboAcGroup = new ComboBox();
			lblSmsCount = new Label();
			lblMsgLenth = new Label();
			_lnkSourceEnglish = new LinkLabel();
			_lnkTargetEnglish = new LinkLabel();
			Timer1 = new Timer(components);
			lblWhatsAppState = new Label();
			LblSenderId = new Label();
			btnWappInstall = new QButton();
			pBoxAuthQR = new PictureBox();
			chkBoxHeadLess = new CheckBox();
			statusRetriever = new Timer(components);
			openAttach = new OpenFileDialog();
			btnAcOs = new QButton();
			Label17 = new Label();
			cboMsgType = new ComboBox();
			btnGoldRate = new QButton();
			BtnLogout = new QButton();
			btnQuit = new QButton();
			ProgressBar1 = new ProgressBar();
			lblDelay = new Label();
			numDelay = new NumericUpDown();
			btnDelyTime = new SimpleButton();
			LblDays = new Label();
			Label7 = new Label();
			nFromRow = new TextBox();
			Label8 = new Label();
			Label9 = new Label();
			nToRow = new TextBox();
			tMsg = new RichTextBox();
			tCountryCode = new TextBox();
			Label10 = new Label();
			cboArea = new ComboBox();
			((Control)PnlBotam).SuspendLayout();
			((ISupportInitialize)Cr).BeginInit();
			((ISupportInitialize)DGV).BeginInit();
			((ISupportInitialize)pBoxAuthQR).BeginInit();
			((ISupportInitialize)numDelay).BeginInit();
			((Control)this).SuspendLayout();
			((Control)PnlBotam).BackColor = Color.SandyBrown;
			((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
			((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
			((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
			((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
			((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
			((Control)PnlBotam).Controls.Add((Control)(object)BtnExcel);
			((Control)PnlBotam).Controls.Add((Control)(object)Cr);
			((Control)PnlBotam).Dock = (DockStyle)2;
			PnlBotam.FlowDirection = (FlowDirection)2;
			((Control)PnlBotam).Location = new Point(0, 566);
			((Control)PnlBotam).Margin = new Padding(2);
			((Control)PnlBotam).Name = "PnlBotam";
			((Control)PnlBotam).Size = new Size(1309, 41);
			((Control)PnlBotam).TabIndex = 5;
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
			((Control)BtnExit).TabIndex = 9;
			BtnExit.Text = "E&xit";
			((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
			((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
			((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
			((Control)BtnDelete).Location = new Point(1118, 3);
			((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
			((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnDelete).Name = "BtnDelete";
			((Control)BtnDelete).Size = new Size(91, 37);
			((Control)BtnDelete).TabIndex = 8;
			BtnDelete.Text = "&Delete";
			((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
			((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
			((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
			BtnCancel.ImageOptions.Location = (ImageLocation)1;
			((Control)BtnCancel).Location = new Point(1021, 3);
			((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
			((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnCancel).Name = "BtnCancel";
			((Control)BtnCancel).Size = new Size(91, 37);
			((Control)BtnCancel).TabIndex = 7;
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
			((Control)BtnSave).TabIndex = 5;
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
			((Control)BtnPrint).TabIndex = 6;
			BtnPrint.Text = "&Print";
			((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
			((BaseStyleControl)BtnExcel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((BaseStyleControl)BtnExcel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
			((BaseStyleControl)BtnExcel).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnExcel).Appearance.Options.UseForeColor = true;
			((ImageCollectionImageOptions)BtnExcel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExcel.ImageOptions.SvgImage");
			((Control)BtnExcel).Location = new Point(730, 3);
			((BaseControl)BtnExcel).LookAndFeel.SkinName = "The Bezier";
			((BaseControl)BtnExcel).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnExcel).Name = "BtnExcel";
			((Control)BtnExcel).Size = new Size(91, 37);
			((Control)BtnExcel).TabIndex = 11;
			BtnExcel.Text = "&Excel";
			((BaseButton)BtnExcel).ToolTipAnchor = (ToolTipAnchor)1;
			((AxHost)Cr).Enabled = true;
			((Control)Cr).Location = new Point(696, 3);
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
			lblBook.Text = "Whatsapp Sender Old";
			lblBook.TextAlign = (ContentAlignment)32;
			CboSmsType.AutoCompleteMode = (AutoCompleteMode)2;
			CboSmsType.AutoCompleteSource = (AutoCompleteSource)256;
			CboSmsType.DropDownStyle = (ComboBoxStyle)2;
			((Control)CboSmsType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((ListControl)CboSmsType).FormattingEnabled = true;
			((Control)CboSmsType).Location = new Point(111, 45);
			CboSmsType.MaxLength = 20;
			((Control)CboSmsType).Name = "CboSmsType";
			((Control)CboSmsType).Size = new Size(145, 24);
			((Control)CboSmsType).TabIndex = 4;
			((TextBoxBase)nFromOs).BackColor = Color.White;
			((Control)nFromOs).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)nFromOs).Location = new Point(111, 169);
			((TextBoxBase)nFromOs).MaxLength = 15;
			((Control)nFromOs).Name = "nFromOs";
			((Control)nFromOs).Size = new Size(81, 22);
			((Control)nFromOs).TabIndex = 0;
			((TextBoxBase)nToOs).BackColor = Color.White;
			((Control)nToOs).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)nToOs).Location = new Point(111, 198);
			((TextBoxBase)nToOs).MaxLength = 15;
			((Control)nToOs).Name = "nToOs";
			((Control)nToOs).Size = new Size(81, 22);
			((Control)nToOs).TabIndex = 1;
			((Control)Label5).BackColor = Color.Transparent;
			((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label5).ForeColor = Color.Black;
			Label5.ImeMode = (ImeMode)0;
			((Control)Label5).Location = new Point(11, 45);
			((Control)Label5).Name = "Label5";
			((Control)Label5).Size = new Size(93, 20);
			((Control)Label5).TabIndex = 19;
			Label5.Text = "Wapp Type";
			Label5.TextAlign = (ContentAlignment)64;
			((Control)Label1).BackColor = Color.Transparent;
			((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label1).ForeColor = Color.Black;
			Label1.ImeMode = (ImeMode)0;
			((Control)Label1).Location = new Point(40, 202);
			((Control)Label1).Name = "Label1";
			((Control)Label1).Size = new Size(64, 20);
			((Control)Label1).TabIndex = 16;
			Label1.Text = "To Os <";
			Label1.TextAlign = (ContentAlignment)64;
			((Control)Label2).BackColor = Color.Transparent;
			((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label2).ForeColor = Color.Black;
			Label2.ImeMode = (ImeMode)0;
			((Control)Label2).Location = new Point(21, 170);
			((Control)Label2).Name = "Label2";
			((Control)Label2).Size = new Size(84, 20);
			((Control)Label2).TabIndex = 15;
			Label2.Text = "From Os >";
			Label2.TextAlign = (ContentAlignment)64;
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
			((DataGridView)DGV).ColumnHeadersHeight = 30;
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
			((Control)DGV).Location = new Point(206, 89);
			((Control)DGV).Name = "DGV";
			DGV.PaintEnhancedSelection = false;
			val4.Alignment = (DataGridViewContentAlignment)16;
			val4.BackColor = Color.MintCream;
			val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			val4.ForeColor = SystemColors.WindowText;
			val4.SelectionBackColor = SystemColors.Highlight;
			val4.SelectionForeColor = SystemColors.HighlightText;
			val4.WrapMode = (DataGridViewTriState)1;
			((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
			((DataGridView)DGV).RowHeadersVisible = false;
			((DataGridView)DGV).RowHeadersWidth = 20;
			val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			val5.ForeColor = Color.FromArgb(64, 64, 64);
			((DataGridView)DGV).RowsDefaultCellStyle = val5;
			DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
			((DataGridView)DGV).ScrollBars = (ScrollBars)2;
			DGV.SelectAllSignVisible = false;
			((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
			((Control)DGV).Size = new Size(969, 231);
			((DataGridView)DGV).StandardTab = true;
			((Control)DGV).TabIndex = 1155;
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
			((Control)btnOk).Location = new Point(274, 43);
			((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
			((Control)btnOk).Name = "btnOk";
			((Control)btnOk).Size = new Size(117, 37);
			((Control)btnOk).TabIndex = 1156;
			btnOk.Text = "Get List";
			((Control)Label3).BackColor = Color.Transparent;
			((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label3).ForeColor = Color.Black;
			Label3.ImeMode = (ImeMode)0;
			((Control)Label3).Location = new Point(197, 336);
			((Control)Label3).Name = "Label3";
			((Control)Label3).Size = new Size(82, 20);
			((Control)Label3).TabIndex = 1158;
			Label3.Text = "Mobile No";
			Label3.TextAlign = (ContentAlignment)64;
			((TextBoxBase)tMobileNo).BackColor = Color.White;
			((Control)tMobileNo).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)tMobileNo).Location = new Point(329, 336);
			((TextBoxBase)tMobileNo).MaxLength = 10;
			((Control)tMobileNo).Name = "tMobileNo";
			((Control)tMobileNo).Size = new Size(150, 26);
			((Control)tMobileNo).TabIndex = 1157;
			((Control)Label4).BackColor = Color.Transparent;
			((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label4).ForeColor = Color.Black;
			Label4.ImeMode = (ImeMode)0;
			((Control)Label4).Location = new Point(201, 371);
			((Control)Label4).Name = "Label4";
			((Control)Label4).Size = new Size(78, 20);
			((Control)Label4).TabIndex = 1162;
			Label4.Text = "Message";
			Label4.TextAlign = (ContentAlignment)64;
			((QControl)BtnSmsSend).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)BtnSmsSend).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)BtnSmsSend).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)BtnSmsSend).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)BtnSmsSend).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)BtnSmsSend).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)BtnSmsSend).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)BtnSmsSend).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)BtnSmsSend).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)BtnSmsSend).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)BtnSmsSend).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)BtnSmsSend).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)BtnSmsSend).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)BtnSmsSend).ColorScheme).InheritCurrentThemeFromGlobal = false;
			BtnSmsSend.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnSmsSend.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnSmsSend.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnSmsSend.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnSmsSend.Image = null;
			((QControl)BtnSmsSend).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)BtnSmsSend).Location = new Point(581, 333);
			((Control)BtnSmsSend).Margin = new Padding(3, 6, 3, 6);
			((Control)BtnSmsSend).Name = "BtnSmsSend";
			((Control)BtnSmsSend).Size = new Size(87, 33);
			((Control)BtnSmsSend).TabIndex = 1164;
			BtnSmsSend.Text = "Send";
			((BaseStyleControl)BtnAc).Appearance.BackColor = Color.AntiqueWhite;
			((BaseStyleControl)BtnAc).Appearance.BorderColor = Color.SandyBrown;
			((BaseStyleControl)BtnAc).Appearance.Font = new Font("Arial", 9f);
			((BaseStyleControl)BtnAc).Appearance.ForeColor = Color.Maroon;
			((BaseStyleControl)BtnAc).Appearance.GradientMode = (LinearGradientMode)1;
			((BaseStyleControl)BtnAc).Appearance.Options.UseBackColor = true;
			((BaseStyleControl)BtnAc).Appearance.Options.UseBorderColor = true;
			((BaseStyleControl)BtnAc).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnAc).Appearance.Options.UseForeColor = true;
			((BaseButton)BtnAc).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
			((BaseButton)BtnAc).AppearanceHovered.BorderColor = Color.SandyBrown;
			((BaseButton)BtnAc).AppearanceHovered.Font = new Font("Arial", 9f);
			((BaseButton)BtnAc).AppearanceHovered.GradientMode = (LinearGradientMode)1;
			((BaseButton)BtnAc).AppearanceHovered.Options.UseBackColor = true;
			((BaseButton)BtnAc).AppearanceHovered.Options.UseBorderColor = true;
			((BaseButton)BtnAc).AppearanceHovered.Options.UseFont = true;
			((BaseButton)BtnAc).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
			((BaseButton)BtnAc).AppearancePressed.BorderColor = Color.Moccasin;
			((BaseButton)BtnAc).AppearancePressed.Font = new Font("Arial", 9f);
			((BaseButton)BtnAc).AppearancePressed.Options.UseBackColor = true;
			((BaseButton)BtnAc).AppearancePressed.Options.UseBorderColor = true;
			((BaseButton)BtnAc).AppearancePressed.Options.UseFont = true;
			((Control)BtnAc).Location = new Point(486, 335);
			((BaseControl)BtnAc).LookAndFeel.SkinName = "Office 2019 Colorful";
			((BaseControl)BtnAc).LookAndFeel.Style = (LookAndFeelStyle)0;
			((BaseControl)BtnAc).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnAc).Name = "BtnAc";
			((Control)BtnAc).Size = new Size(34, 26);
			((Control)BtnAc).TabIndex = 1166;
			BtnAc.Text = "A";
			((BaseControl)BtnAc).ToolTip = "Party Help";
			((BaseStyleControl)BtnMemb).Appearance.BackColor = Color.AntiqueWhite;
			((BaseStyleControl)BtnMemb).Appearance.BorderColor = Color.SandyBrown;
			((BaseStyleControl)BtnMemb).Appearance.Font = new Font("Arial", 9f);
			((BaseStyleControl)BtnMemb).Appearance.ForeColor = Color.Maroon;
			((BaseStyleControl)BtnMemb).Appearance.GradientMode = (LinearGradientMode)1;
			((BaseStyleControl)BtnMemb).Appearance.Options.UseBackColor = true;
			((BaseStyleControl)BtnMemb).Appearance.Options.UseBorderColor = true;
			((BaseStyleControl)BtnMemb).Appearance.Options.UseFont = true;
			((BaseStyleControl)BtnMemb).Appearance.Options.UseForeColor = true;
			((BaseButton)BtnMemb).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
			((BaseButton)BtnMemb).AppearanceHovered.BorderColor = Color.SandyBrown;
			((BaseButton)BtnMemb).AppearanceHovered.Font = new Font("Arial", 9f);
			((BaseButton)BtnMemb).AppearanceHovered.GradientMode = (LinearGradientMode)1;
			((BaseButton)BtnMemb).AppearanceHovered.Options.UseBackColor = true;
			((BaseButton)BtnMemb).AppearanceHovered.Options.UseBorderColor = true;
			((BaseButton)BtnMemb).AppearanceHovered.Options.UseFont = true;
			((BaseButton)BtnMemb).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
			((BaseButton)BtnMemb).AppearancePressed.BorderColor = Color.Moccasin;
			((BaseButton)BtnMemb).AppearancePressed.Font = new Font("Arial", 9f);
			((BaseButton)BtnMemb).AppearancePressed.Options.UseBackColor = true;
			((BaseButton)BtnMemb).AppearancePressed.Options.UseBorderColor = true;
			((BaseButton)BtnMemb).AppearancePressed.Options.UseFont = true;
			((Control)BtnMemb).Location = new Point(527, 336);
			((BaseControl)BtnMemb).LookAndFeel.SkinName = "Office 2019 Colorful";
			((BaseControl)BtnMemb).LookAndFeel.Style = (LookAndFeelStyle)0;
			((BaseControl)BtnMemb).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)BtnMemb).Name = "BtnMemb";
			((Control)BtnMemb).Size = new Size(34, 25);
			((Control)BtnMemb).TabIndex = 1167;
			BtnMemb.Text = "M";
			((BaseControl)BtnMemb).ToolTip = "Member Help";
			((ButtonBase)chkAllRow).BackColor = SystemColors.ButtonHighlight;
			((Control)chkAllRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)chkAllRow).ForeColor = Color.FromArgb(192, 0, 0);
			((Control)chkAllRow).Location = new Point(1064, 54);
			((Control)chkAllRow).Name = "chkAllRow";
			((Control)chkAllRow).RightToLeft = (RightToLeft)0;
			((Control)chkAllRow).Size = new Size(118, 19);
			((Control)chkAllRow).TabIndex = 1168;
			((ButtonBase)chkAllRow).Text = "Select All Row";
			((ButtonBase)chkAllRow).UseVisualStyleBackColor = false;
			((Control)lblSmsRow).BackColor = Color.Transparent;
			((Control)lblSmsRow).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)lblSmsRow).ForeColor = Color.FromArgb(192, 0, 0);
			lblSmsRow.ImeMode = (ImeMode)0;
			((Control)lblSmsRow).Location = new Point(718, 463);
			((Control)lblSmsRow).Name = "lblSmsRow";
			((Control)lblSmsRow).Size = new Size(87, 20);
			((Control)lblSmsRow).TabIndex = 1169;
			lblSmsRow.Text = "Select Row";
			lblSmsRow.TextAlign = (ContentAlignment)64;
			((QControl)btnExlImport).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)btnExlImport).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnExlImport).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)btnExlImport).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)btnExlImport).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)btnExlImport).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnExlImport).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnExlImport).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)btnExlImport).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)btnExlImport).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)btnExlImport).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnExlImport).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)btnExlImport).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)btnExlImport).ColorScheme).InheritCurrentThemeFromGlobal = false;
			btnExlImport.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnExlImport.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnExlImport.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnExlImport.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnExlImport.Image = null;
			((QControl)btnExlImport).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)btnExlImport).Location = new Point(682, 43);
			((Control)btnExlImport).Margin = new Padding(3, 6, 3, 6);
			((Control)btnExlImport).Name = "btnExlImport";
			((Control)btnExlImport).Size = new Size(115, 37);
			((Control)btnExlImport).TabIndex = 1170;
			btnExlImport.Text = "Exel Import";
			((FileDialog)DlgOpn).FileName = "OpenFileDialog1";
			((TextBoxBase)tsmstype).BackColor = Color.White;
			((Control)tsmstype).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)tsmstype).Location = new Point(968, 368);
			((TextBoxBase)tsmstype).MaxLength = 1;
			((Control)tsmstype).Name = "tsmstype";
			((Control)tsmstype).Size = new Size(24, 22);
			((Control)tsmstype).TabIndex = 1172;
			tsmstype.TextAlign = (HorizontalAlignment)2;
			((Control)Label13).BackColor = Color.Transparent;
			((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label13).ForeColor = Color.Black;
			Label13.ImeMode = (ImeMode)0;
			((Control)Label13).Location = new Point(-1, 137);
			((Control)Label13).Name = "Label13";
			((Control)Label13).Size = new Size(103, 20);
			((Control)Label13).TabIndex = 1180;
			Label13.Text = "Barthday";
			Label13.TextAlign = (ContentAlignment)64;
			cboBarth.AutoCompleteMode = (AutoCompleteMode)2;
			cboBarth.AutoCompleteSource = (AutoCompleteSource)256;
			cboBarth.DropDownStyle = (ComboBoxStyle)2;
			((Control)cboBarth).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((ListControl)cboBarth).FormattingEnabled = true;
			((Control)cboBarth).Location = new Point(111, 138);
			cboBarth.MaxLength = 20;
			((Control)cboBarth).Name = "cboBarth";
			((Control)cboBarth).Size = new Size(80, 24);
			((Control)cboBarth).TabIndex = 1179;
			((ButtonBase)ChkOnlyMoNo).BackColor = SystemColors.ButtonHighlight;
			ChkOnlyMoNo.Checked = true;
			ChkOnlyMoNo.CheckState = (CheckState)1;
			((Control)ChkOnlyMoNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)ChkOnlyMoNo).ForeColor = Color.FromArgb(192, 0, 0);
			((Control)ChkOnlyMoNo).Location = new Point(896, 397);
			((Control)ChkOnlyMoNo).Name = "ChkOnlyMoNo";
			((Control)ChkOnlyMoNo).RightToLeft = (RightToLeft)0;
			((Control)ChkOnlyMoNo).Size = new Size(121, 19);
			((Control)ChkOnlyMoNo).TabIndex = 1181;
			((ButtonBase)ChkOnlyMoNo).Text = "Ac With Mobile";
			((ButtonBase)ChkOnlyMoNo).UseVisualStyleBackColor = false;
			((Control)lblAcGroup).BackColor = Color.Transparent;
			((Control)lblAcGroup).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)lblAcGroup).ForeColor = Color.Black;
			lblAcGroup.ImeMode = (ImeMode)0;
			((Control)lblAcGroup).Location = new Point(16, 76);
			((Control)lblAcGroup).Name = "lblAcGroup";
			((Control)lblAcGroup).Size = new Size(88, 20);
			((Control)lblAcGroup).TabIndex = 1184;
			lblAcGroup.Text = "Ac Group";
			lblAcGroup.TextAlign = (ContentAlignment)64;
			cboAcGroup.AutoCompleteMode = (AutoCompleteMode)2;
			cboAcGroup.AutoCompleteSource = (AutoCompleteSource)256;
			cboAcGroup.DropDownStyle = (ComboBoxStyle)2;
			((Control)cboAcGroup).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((ListControl)cboAcGroup).FormattingEnabled = true;
			((Control)cboAcGroup).Location = new Point(111, 76);
			cboAcGroup.MaxLength = 20;
			((Control)cboAcGroup).Name = "cboAcGroup";
			((Control)cboAcGroup).Size = new Size(81, 24);
			((Control)cboAcGroup).TabIndex = 1183;
			((Control)lblSmsCount).BackColor = Color.Transparent;
			((Control)lblSmsCount).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)lblSmsCount).ForeColor = Color.FromArgb(192, 0, 0);
			lblSmsCount.ImeMode = (ImeMode)0;
			((Control)lblSmsCount).Location = new Point(709, 490);
			((Control)lblSmsCount).Name = "lblSmsCount";
			((Control)lblSmsCount).Size = new Size(96, 20);
			((Control)lblSmsCount).TabIndex = 1186;
			lblSmsCount.Text = "Send Row";
			lblSmsCount.TextAlign = (ContentAlignment)64;
			((Control)lblMsgLenth).BackColor = Color.Transparent;
			((Control)lblMsgLenth).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)lblMsgLenth).ForeColor = Color.FromArgb(192, 0, 0);
			lblMsgLenth.ImeMode = (ImeMode)0;
			((Control)lblMsgLenth).Location = new Point(715, 431);
			((Control)lblMsgLenth).Name = "lblMsgLenth";
			((Control)lblMsgLenth).Size = new Size(90, 20);
			((Control)lblMsgLenth).TabIndex = 1194;
			lblMsgLenth.Text = "Msg Lenth";
			lblMsgLenth.TextAlign = (ContentAlignment)64;
			((Label)_lnkSourceEnglish).AutoSize = true;
			((Control)_lnkSourceEnglish).Location = new Point(1240, 274);
			((Control)_lnkSourceEnglish).Name = "_lnkSourceEnglish";
			((Control)_lnkSourceEnglish).Size = new Size(41, 13);
			((Control)_lnkSourceEnglish).TabIndex = 1195;
			_lnkSourceEnglish.TabStop = true;
			_lnkSourceEnglish.Text = "English";
			((Control)_lnkSourceEnglish).Visible = false;
			((Label)_lnkTargetEnglish).AutoSize = true;
			((Control)_lnkTargetEnglish).Location = new Point(1240, 307);
			((Control)_lnkTargetEnglish).Name = "_lnkTargetEnglish";
			((Control)_lnkTargetEnglish).Size = new Size(41, 13);
			((Control)_lnkTargetEnglish).TabIndex = 1196;
			_lnkTargetEnglish.TabStop = true;
			_lnkTargetEnglish.Text = "English";
			((Control)_lnkTargetEnglish).Visible = false;
			((Control)lblWhatsAppState).BackColor = Color.FromArgb(255, 224, 192);
			((Control)lblWhatsAppState).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)lblWhatsAppState).ForeColor = Color.FromArgb(192, 0, 0);
			((Control)lblWhatsAppState).Location = new Point(17, 5);
			((Control)lblWhatsAppState).Margin = new Padding(3);
			((Control)lblWhatsAppState).Name = "lblWhatsAppState";
			((Control)lblWhatsAppState).Size = new Size(235, 27);
			((Control)lblWhatsAppState).TabIndex = 1197;
			lblWhatsAppState.Text = "ENGINE : STOPPED";
			lblWhatsAppState.TextAlign = (ContentAlignment)16;
			((Control)LblSenderId).BackColor = Color.FromArgb(255, 224, 192);
			((Control)LblSenderId).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)LblSenderId).ForeColor = Color.FromArgb(192, 0, 0);
			((Control)LblSenderId).Location = new Point(964, 1);
			((Control)LblSenderId).Margin = new Padding(3);
			((Control)LblSenderId).Name = "LblSenderId";
			((Control)LblSenderId).Size = new Size(211, 28);
			((Control)LblSenderId).TabIndex = 1198;
			LblSenderId.Text = "Sender Id: Unavailable";
			LblSenderId.TextAlign = (ContentAlignment)64;
			((QControl)btnWappInstall).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)btnWappInstall).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnWappInstall).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)btnWappInstall).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)btnWappInstall).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)btnWappInstall).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnWappInstall).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnWappInstall).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)btnWappInstall).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)btnWappInstall).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)btnWappInstall).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnWappInstall).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)btnWappInstall).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)btnWappInstall).ColorScheme).InheritCurrentThemeFromGlobal = false;
			btnWappInstall.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnWappInstall.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnWappInstall.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnWappInstall.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnWappInstall.Image = null;
			((QControl)btnWappInstall).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)btnWappInstall).Location = new Point(77, 395);
			((Control)btnWappInstall).Margin = new Padding(3, 6, 3, 6);
			((Control)btnWappInstall).Name = "btnWappInstall";
			((Control)btnWappInstall).Size = new Size(115, 37);
			((Control)btnWappInstall).TabIndex = 1199;
			btnWappInstall.Text = "Connect";
			((Control)pBoxAuthQR).BackColor = Color.Transparent;
			pBoxAuthQR.BorderStyle = (BorderStyle)1;
			((Control)pBoxAuthQR).Location = new Point(31, 229);
			((Control)pBoxAuthQR).Name = "pBoxAuthQR";
			((Control)pBoxAuthQR).Size = new Size(160, 157);
			pBoxAuthQR.SizeMode = (PictureBoxSizeMode)4;
			pBoxAuthQR.TabIndex = 1200;
			pBoxAuthQR.TabStop = false;
			((ButtonBase)chkBoxHeadLess).BackColor = SystemColors.ButtonHighlight;
			chkBoxHeadLess.CheckAlign = (ContentAlignment)2;
			((Control)chkBoxHeadLess).Cursor = Cursors.Hand;
			((Control)chkBoxHeadLess).Enabled = false;
			((Control)chkBoxHeadLess).Location = new Point(3, 470);
			((Control)chkBoxHeadLess).Name = "chkBoxHeadLess";
			((Control)chkBoxHeadLess).Size = new Size(68, 51);
			((Control)chkBoxHeadLess).TabIndex = 1201;
			((ButtonBase)chkBoxHeadLess).Text = "Whout Chrome";
			chkBoxHeadLess.TextAlign = (ContentAlignment)512;
			((ButtonBase)chkBoxHeadLess).UseVisualStyleBackColor = false;
			((Control)chkBoxHeadLess).Visible = false;
			statusRetriever.Enabled = true;
			statusRetriever.Interval = 1000;
			((FileDialog)openAttach).DefaultExt = "*";
			((FileDialog)openAttach).FileName = "*.*";
			((QControl)btnAcOs).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)btnAcOs).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnAcOs).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)btnAcOs).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)btnAcOs).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)btnAcOs).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnAcOs).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnAcOs).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)btnAcOs).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)btnAcOs).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)btnAcOs).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnAcOs).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)btnAcOs).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)btnAcOs).ColorScheme).InheritCurrentThemeFromGlobal = false;
			btnAcOs.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnAcOs.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnAcOs.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnAcOs.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnAcOs.Image = null;
			((QControl)btnAcOs).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)btnAcOs).Location = new Point(408, 43);
			((Control)btnAcOs).Margin = new Padding(3, 6, 3, 6);
			((Control)btnAcOs).Name = "btnAcOs";
			((Control)btnAcOs).Size = new Size(117, 37);
			((Control)btnAcOs).TabIndex = 1203;
			btnAcOs.Text = "Party Os";
			((Control)Label17).BackColor = Color.Transparent;
			((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label17).ForeColor = Color.Black;
			Label17.ImeMode = (ImeMode)0;
			((Control)Label17).Location = new Point(698, 368);
			((Control)Label17).Name = "Label17";
			((Control)Label17).Size = new Size(107, 20);
			((Control)Label17).TabIndex = 1205;
			Label17.Text = "Message Type";
			Label17.TextAlign = (ContentAlignment)64;
			cboMsgType.AutoCompleteMode = (AutoCompleteMode)2;
			cboMsgType.AutoCompleteSource = (AutoCompleteSource)256;
			cboMsgType.DropDownStyle = (ComboBoxStyle)2;
			((Control)cboMsgType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((ListControl)cboMsgType).FormattingEnabled = true;
			((Control)cboMsgType).Location = new Point(811, 367);
			cboMsgType.MaxLength = 20;
			((Control)cboMsgType).Name = "cboMsgType";
			((Control)cboMsgType).Size = new Size(145, 24);
			((Control)cboMsgType).TabIndex = 1204;
			((QControl)btnGoldRate).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)btnGoldRate).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnGoldRate).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)btnGoldRate).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)btnGoldRate).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)btnGoldRate).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnGoldRate).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnGoldRate).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)btnGoldRate).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)btnGoldRate).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)btnGoldRate).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnGoldRate).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)btnGoldRate).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)btnGoldRate).ColorScheme).InheritCurrentThemeFromGlobal = false;
			btnGoldRate.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnGoldRate.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnGoldRate.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnGoldRate.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnGoldRate.Image = null;
			((QControl)btnGoldRate).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)btnGoldRate).Location = new Point(545, 43);
			((Control)btnGoldRate).Margin = new Padding(3, 6, 3, 6);
			((Control)btnGoldRate).Name = "btnGoldRate";
			((Control)btnGoldRate).Size = new Size(117, 37);
			((Control)btnGoldRate).TabIndex = 1206;
			btnGoldRate.Text = "Rate Send";
			((QControl)btnGoldRate).ToolTipText = "Today Gold And Silver Rate Send";
			((QControl)BtnLogout).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)BtnLogout).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)BtnLogout).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)BtnLogout).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)BtnLogout).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)BtnLogout).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)BtnLogout).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)BtnLogout).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)BtnLogout).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)BtnLogout).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)BtnLogout).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)BtnLogout).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)BtnLogout).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)BtnLogout).ColorScheme).InheritCurrentThemeFromGlobal = false;
			BtnLogout.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnLogout.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnLogout.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnLogout.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			BtnLogout.Image = null;
			((QControl)BtnLogout).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)BtnLogout).Location = new Point(77, 489);
			((Control)BtnLogout).Margin = new Padding(3, 6, 3, 6);
			((Control)BtnLogout).Name = "BtnLogout";
			((Control)BtnLogout).Size = new Size(115, 37);
			((Control)BtnLogout).TabIndex = 1207;
			BtnLogout.Text = "LogOut";
			((QControl)btnQuit).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
			((QControl)btnQuit).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnQuit).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
			((QControl)btnQuit).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
			((QControl)btnQuit).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
			((QControl)btnQuit).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
			((QControl)btnQuit).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnQuit).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
			((QControl)btnQuit).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
			((QControl)btnQuit).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
			((QControl)btnQuit).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
			((QControl)btnQuit).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
			((QColorSchemeBase)((QControl)btnQuit).ColorScheme).CurrentTheme = "LunaOlive";
			((QColorSchemeBase)((QControl)btnQuit).ColorScheme).InheritCurrentThemeFromGlobal = false;
			btnQuit.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnQuit.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnQuit.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnQuit.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
			btnQuit.Image = null;
			((QControl)btnQuit).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
			((Control)btnQuit).Location = new Point(77, 442);
			((Control)btnQuit).Margin = new Padding(3, 6, 3, 6);
			((Control)btnQuit).Name = "btnQuit";
			((Control)btnQuit).Size = new Size(115, 37);
			((Control)btnQuit).TabIndex = 1208;
			btnQuit.Text = "Quit";
			((Control)ProgressBar1).Location = new Point(0, 537);
			((Control)ProgressBar1).Name = "ProgressBar1";
			((Control)ProgressBar1).Size = new Size(1309, 20);
			((Control)ProgressBar1).TabIndex = 1209;
			lblDelay.AutoSize = true;
			((Control)lblDelay).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)lblDelay).Location = new Point(698, 399);
			((Control)lblDelay).Name = "lblDelay";
			((Control)lblDelay).Size = new Size(108, 20);
			((Control)lblDelay).TabIndex = 1211;
			lblDelay.Text = "Msg Delay Time";
			lblDelay.TextAlign = (ContentAlignment)64;
			((Control)numDelay).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)numDelay).Location = new Point(811, 399);
			((Control)numDelay).Name = "numDelay";
			((Control)numDelay).Size = new Size(39, 22);
			((Control)numDelay).TabIndex = 1210;
			numDelay.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			((BaseStyleControl)btnDelyTime).Appearance.BackColor = Color.AntiqueWhite;
			((BaseStyleControl)btnDelyTime).Appearance.BorderColor = Color.SandyBrown;
			((BaseStyleControl)btnDelyTime).Appearance.Font = new Font("Arial", 9f);
			((BaseStyleControl)btnDelyTime).Appearance.ForeColor = Color.Maroon;
			((BaseStyleControl)btnDelyTime).Appearance.GradientMode = (LinearGradientMode)1;
			((BaseStyleControl)btnDelyTime).Appearance.Options.UseBackColor = true;
			((BaseStyleControl)btnDelyTime).Appearance.Options.UseBorderColor = true;
			((BaseStyleControl)btnDelyTime).Appearance.Options.UseFont = true;
			((BaseStyleControl)btnDelyTime).Appearance.Options.UseForeColor = true;
			((BaseButton)btnDelyTime).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
			((BaseButton)btnDelyTime).AppearanceHovered.BorderColor = Color.SandyBrown;
			((BaseButton)btnDelyTime).AppearanceHovered.Font = new Font("Arial", 9f);
			((BaseButton)btnDelyTime).AppearanceHovered.GradientMode = (LinearGradientMode)1;
			((BaseButton)btnDelyTime).AppearanceHovered.Options.UseBackColor = true;
			((BaseButton)btnDelyTime).AppearanceHovered.Options.UseBorderColor = true;
			((BaseButton)btnDelyTime).AppearanceHovered.Options.UseFont = true;
			((BaseButton)btnDelyTime).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
			((BaseButton)btnDelyTime).AppearancePressed.BorderColor = Color.Moccasin;
			((BaseButton)btnDelyTime).AppearancePressed.Font = new Font("Arial", 9f);
			((BaseButton)btnDelyTime).AppearancePressed.Options.UseBackColor = true;
			((BaseButton)btnDelyTime).AppearancePressed.Options.UseBorderColor = true;
			((BaseButton)btnDelyTime).AppearancePressed.Options.UseFont = true;
			((Control)btnDelyTime).Location = new Point(856, 397);
			((BaseControl)btnDelyTime).LookAndFeel.SkinName = "Office 2019 Colorful";
			((BaseControl)btnDelyTime).LookAndFeel.Style = (LookAndFeelStyle)0;
			((BaseControl)btnDelyTime).LookAndFeel.UseDefaultLookAndFeel = false;
			((Control)btnDelyTime).Name = "btnDelyTime";
			((Control)btnDelyTime).Size = new Size(34, 24);
			((Control)btnDelyTime).TabIndex = 1218;
			btnDelyTime.Text = "S";
			((BaseControl)btnDelyTime).ToolTip = "Msg Dely Time Save";
			((Control)LblDays).BackColor = Color.Transparent;
			((Control)LblDays).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)LblDays).ForeColor = Color.FromArgb(192, 0, 0);
			LblDays.ImeMode = (ImeMode)0;
			((Control)LblDays).Location = new Point(12, 434);
			((Control)LblDays).Name = "LblDays";
			((Control)LblDays).Size = new Size(54, 20);
			((Control)LblDays).TabIndex = 1219;
			LblDays.Text = "0";
			LblDays.TextAlign = (ContentAlignment)32;
			((Control)Label7).BackColor = Color.Transparent;
			((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label7).ForeColor = Color.FromArgb(192, 0, 0);
			Label7.ImeMode = (ImeMode)0;
			((Control)Label7).Location = new Point(12, 401);
			((Control)Label7).Name = "Label7";
			((Control)Label7).Size = new Size(55, 20);
			((Control)Label7).TabIndex = 1220;
			Label7.Text = "Days";
			Label7.TextAlign = (ContentAlignment)32;
			((TextBoxBase)nFromRow).BackColor = Color.White;
			((Control)nFromRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)nFromRow).Location = new Point(872, 52);
			((TextBoxBase)nFromRow).MaxLength = 5;
			((Control)nFromRow).Name = "nFromRow";
			((Control)nFromRow).Size = new Size(46, 22);
			((Control)nFromRow).TabIndex = 1221;
			nFromRow.TextAlign = (HorizontalAlignment)2;
			((Control)Label8).BackColor = Color.Transparent;
			((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label8).ForeColor = Color.FromArgb(192, 0, 0);
			Label8.ImeMode = (ImeMode)0;
			((Control)Label8).Location = new Point(807, 52);
			((Control)Label8).Name = "Label8";
			((Control)Label8).Size = new Size(58, 20);
			((Control)Label8).TabIndex = 1222;
			Label8.Text = "F/ Row";
			Label8.TextAlign = (ContentAlignment)16;
			((Control)Label9).BackColor = Color.Transparent;
			((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label9).ForeColor = Color.FromArgb(192, 0, 0);
			Label9.ImeMode = (ImeMode)0;
			((Control)Label9).Location = new Point(924, 53);
			((Control)Label9).Name = "Label9";
			((Control)Label9).Size = new Size(64, 20);
			((Control)Label9).TabIndex = 1224;
			Label9.Text = "To/ Row";
			Label9.TextAlign = (ContentAlignment)16;
			((TextBoxBase)nToRow).BackColor = Color.White;
			((Control)nToRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)nToRow).Location = new Point(997, 52);
			((TextBoxBase)nToRow).MaxLength = 5;
			((Control)nToRow).Name = "nToRow";
			((Control)nToRow).Size = new Size(46, 22);
			((Control)nToRow).TabIndex = 1223;
			nToRow.TextAlign = (HorizontalAlignment)2;
			((TextBoxBase)tMsg).BorderStyle = (BorderStyle)1;
			tMsg.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)tMsg).Location = new Point(287, 371);
			tMsg.MaxLength = 2500;
			((Control)tMsg).Name = "tMsg";
			((Control)tMsg).Size = new Size(382, 153);
			((Control)tMsg).TabIndex = 1225;
			tMsg.Text = "";
			((TextBoxBase)tCountryCode).BackColor = Color.White;
			((Control)tCountryCode).Enabled = false;
			((Control)tCountryCode).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)tCountryCode).Location = new Point(287, 336);
			((TextBoxBase)tCountryCode).MaxLength = 3;
			((Control)tCountryCode).Name = "tCountryCode";
			((Control)tCountryCode).Size = new Size(36, 26);
			((Control)tCountryCode).TabIndex = 1226;
			tCountryCode.TextAlign = (HorizontalAlignment)2;
			((Control)Label10).BackColor = Color.Transparent;
			((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((Control)Label10).ForeColor = Color.Black;
			Label10.ImeMode = (ImeMode)0;
			((Control)Label10).Location = new Point(16, 106);
			((Control)Label10).Name = "Label10";
			((Control)Label10).Size = new Size(87, 20);
			((Control)Label10).TabIndex = 1228;
			Label10.Text = "Area";
			Label10.TextAlign = (ContentAlignment)64;
			cboArea.AutoCompleteMode = (AutoCompleteMode)2;
			cboArea.AutoCompleteSource = (AutoCompleteSource)256;
			cboArea.DropDownStyle = (ComboBoxStyle)2;
			((Control)cboArea).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
			((ListControl)cboArea).FormattingEnabled = true;
			((Control)cboArea).Location = new Point(111, 107);
			cboArea.MaxLength = 20;
			((Control)cboArea).Name = "cboArea";
			((Control)cboArea).Size = new Size(81, 24);
			((Control)cboArea).TabIndex = 1227;
			((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
			((Form)this).BackColor = SystemColors.ButtonHighlight;
			((Form)this).ClientSize = new Size(1309, 607);
			((Control)this).Controls.Add((Control)(object)Label10);
			((Control)this).Controls.Add((Control)(object)cboArea);
			((Control)this).Controls.Add((Control)(object)tCountryCode);
			((Control)this).Controls.Add((Control)(object)tMsg);
			((Control)this).Controls.Add((Control)(object)Label9);
			((Control)this).Controls.Add((Control)(object)nToRow);
			((Control)this).Controls.Add((Control)(object)Label8);
			((Control)this).Controls.Add((Control)(object)nFromRow);
			((Control)this).Controls.Add((Control)(object)Label7);
			((Control)this).Controls.Add((Control)(object)LblDays);
			((Control)this).Controls.Add((Control)(object)btnDelyTime);
			((Control)this).Controls.Add((Control)(object)lblDelay);
			((Control)this).Controls.Add((Control)(object)numDelay);
			((Control)this).Controls.Add((Control)(object)ProgressBar1);
			((Control)this).Controls.Add((Control)(object)btnQuit);
			((Control)this).Controls.Add((Control)(object)BtnLogout);
			((Control)this).Controls.Add((Control)(object)btnGoldRate);
			((Control)this).Controls.Add((Control)(object)Label17);
			((Control)this).Controls.Add((Control)(object)cboMsgType);
			((Control)this).Controls.Add((Control)(object)btnAcOs);
			((Control)this).Controls.Add((Control)(object)chkBoxHeadLess);
			((Control)this).Controls.Add((Control)(object)pBoxAuthQR);
			((Control)this).Controls.Add((Control)(object)btnWappInstall);
			((Control)this).Controls.Add((Control)(object)LblSenderId);
			((Control)this).Controls.Add((Control)(object)lblWhatsAppState);
			((Control)this).Controls.Add((Control)(object)_lnkTargetEnglish);
			((Control)this).Controls.Add((Control)(object)_lnkSourceEnglish);
			((Control)this).Controls.Add((Control)(object)lblMsgLenth);
			((Control)this).Controls.Add((Control)(object)lblSmsCount);
			((Control)this).Controls.Add((Control)(object)lblAcGroup);
			((Control)this).Controls.Add((Control)(object)cboAcGroup);
			((Control)this).Controls.Add((Control)(object)ChkOnlyMoNo);
			((Control)this).Controls.Add((Control)(object)Label13);
			((Control)this).Controls.Add((Control)(object)cboBarth);
			((Control)this).Controls.Add((Control)(object)tsmstype);
			((Control)this).Controls.Add((Control)(object)btnExlImport);
			((Control)this).Controls.Add((Control)(object)lblSmsRow);
			((Control)this).Controls.Add((Control)(object)chkAllRow);
			((Control)this).Controls.Add((Control)(object)BtnMemb);
			((Control)this).Controls.Add((Control)(object)BtnAc);
			((Control)this).Controls.Add((Control)(object)BtnSmsSend);
			((Control)this).Controls.Add((Control)(object)Label4);
			((Control)this).Controls.Add((Control)(object)Label3);
			((Control)this).Controls.Add((Control)(object)tMobileNo);
			((Control)this).Controls.Add((Control)(object)btnOk);
			((Control)this).Controls.Add((Control)(object)DGV);
			((Control)this).Controls.Add((Control)(object)Label5);
			((Control)this).Controls.Add((Control)(object)Label1);
			((Control)this).Controls.Add((Control)(object)Label2);
			((Control)this).Controls.Add((Control)(object)CboSmsType);
			((Control)this).Controls.Add((Control)(object)nFromOs);
			((Control)this).Controls.Add((Control)(object)nToOs);
			((Control)this).Controls.Add((Control)(object)lblBook);
			((Control)this).Controls.Add((Control)(object)PnlBotam);
			((Form)this).FormBorderStyle = (FormBorderStyle)1;
			((Form)this).KeyPreview = true;
			((Control)this).Name = "UT_WHATSAPP_OLD";
			((Form)this).Text = "Whatsapp Sender Old";
			((Control)PnlBotam).ResumeLayout(false);
			((ISupportInitialize)Cr).EndInit();
			((ISupportInitialize)DGV).EndInit();
			((ISupportInitialize)pBoxAuthQR).EndInit();
			((ISupportInitialize)numDelay).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}

		private void UT_WHATSAPP_OLD_Load(object sender, EventArgs e)
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_0c3a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c44: Expected O, but got Unknown
			//IL_0ced: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c9f: Unknown result type (might be due to invalid IL or missing references)
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
					Label obj4 = lblWhatsAppState;
					object? obj5 = colorConverter.ConvertFromString("MistyRose");
					((Control)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
					Label lblSenderId = LblSenderId;
					object? obj6 = colorConverter.ConvertFromString("MistyRose");
					((Control)lblSenderId).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
					Label obj7 = lblBook;
					object? obj8 = colorConverter.ConvertFromString("64, 0, 64");
					((Control)obj7).ForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					Label obj9 = lblWhatsAppState;
					object? obj10 = colorConverter.ConvertFromString("64, 0, 64");
					((Control)obj9).ForeColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
					Label lblSenderId2 = LblSenderId;
					object? obj11 = colorConverter.ConvertFromString("64, 0, 64");
					((Control)lblSenderId2).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
					FlowLayoutPanel pnlBotam = PnlBotam;
					object? obj12 = colorConverter.ConvertFromString("MistyRose");
					((Control)pnlBotam).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
					((DataGridView)DGV).BackgroundColor = Color.DarkGray;
					DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
					object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
					alternatingRowsDefaultCellStyle.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
					((ButtonBase)ChkOnlyMoNo).BackColor = Color.Silver;
					((ButtonBase)chkAllRow).BackColor = Color.Silver;
				}
				else if (DC_Main.MsCoTheme == 3)
				{
					object? obj14 = colorConverter.ConvertFromString("200, 205, 210");
					((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
					((Control)lblBook).BackColor = Color.LightSlateGray;
					((Control)lblWhatsAppState).BackColor = Color.LightSlateGray;
					((Control)LblSenderId).BackColor = Color.LightSlateGray;
					((Control)lblWhatsAppState).ForeColor = Color.White;
					((Control)LblSenderId).ForeColor = Color.White;
					((Control)lblBook).ForeColor = Color.White;
					((Control)PnlBotam).BackColor = Color.SlateGray;
					DataGridViewX dGV = DGV;
					object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
					((DataGridView)dGV).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
					DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
					object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
					alternatingRowsDefaultCellStyle2.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
					ComboBox cboSmsType = CboSmsType;
					object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
					cboSmsType.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
					CheckBox chkOnlyMoNo = ChkOnlyMoNo;
					object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
					((ButtonBase)chkOnlyMoNo).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
					CheckBox obj19 = chkAllRow;
					object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
					((ButtonBase)obj19).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				}
				else if (DC_Main.MsCoTheme == 4)
				{
					object? obj21 = colorConverter.ConvertFromString("205, 220, 220");
					((Form)this).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
					((Control)lblBook).BackColor = Color.Cornsilk;
					((Control)lblWhatsAppState).BackColor = Color.Cornsilk;
					((Control)LblSenderId).BackColor = Color.Cornsilk;
					CheckBox obj22 = chkAllRow;
					object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
					((ButtonBase)obj22).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
					Label obj24 = lblBook;
					object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
					((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
					Label obj26 = lblWhatsAppState;
					object? obj27 = colorConverter.ConvertFromString("0, 0, 192");
					((Control)obj26).ForeColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
					Label lblSenderId3 = LblSenderId;
					object? obj28 = colorConverter.ConvertFromString("0, 0, 192");
					((Control)lblSenderId3).ForeColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
					FlowLayoutPanel pnlBotam2 = PnlBotam;
					object? obj29 = colorConverter.ConvertFromString("CadetBlue");
					((Control)pnlBotam2).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
					DataGridViewX dGV2 = DGV;
					object? obj30 = colorConverter.ConvertFromString("Ivory");
					((DataGridView)dGV2).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
					DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
					object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
					alternatingRowsDefaultCellStyle3.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
					ComboBox cboSmsType2 = CboSmsType;
					object? obj32 = colorConverter.ConvertFromString("Cornsilk");
					cboSmsType2.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
					CheckBox chkOnlyMoNo2 = ChkOnlyMoNo;
					object? obj33 = colorConverter.ConvertFromString("205, 220, 220");
					((ButtonBase)chkOnlyMoNo2).BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
					CheckBox obj34 = chkAllRow;
					object? obj35 = colorConverter.ConvertFromString("205, 220, 220");
					((ButtonBase)obj34).BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				}
				CboSmsType.Items.Add((object)"Accounts");
				CboSmsType.Items.Add((object)"Address");
				CboSmsType.Items.Add((object)"Scheme");
				CboSmsType.SelectedIndex = 0;
				cboBarth.Items.Add((object)"");
				cboBarth.Items.Add((object)"Both");
				cboBarth.Items.Add((object)"Barthday");
				cboBarth.Items.Add((object)"Anniversary");
				cboBarth.SelectedIndex = 0;
				cboMsgType.Items.Add((object)"");
				cboMsgType.Items.Add((object)"A Anniversary");
				cboMsgType.Items.Add((object)"B Birthday");
				cboMsgType.Items.Add((object)"L Bill Msg");
				cboMsgType.Items.Add((object)"G Gold Rate");
				cboMsgType.Items.Add((object)"O Party Os");
				cboMsgType.Items.Add((object)"1 Message");
				cboMsgType.Items.Add((object)"2 Message");
				cboMsgType.Items.Add((object)"3 Message");
				cboMsgType.Items.Add((object)"4 Message");
				cboMsgType.Items.Add((object)"5 Message");
				cboMsgType.Items.Add((object)"6 Message");
				cboMsgType.Items.Add((object)"7 Message");
				cboMsgType.Items.Add((object)"8 Message");
				cboMsgType.Items.Add((object)"9 Message");
				cboMsgType.SelectedIndex = 0;
				DC_Main.RsQry = "SELECT WAPP_DELAY From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					numDelay.Value = Conversions.ToDecimal(DC_Main.Tbl.Rows[0]["WAPP_DELAY"]);
				}
				AcGroupDetl();
				DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboArea.Items.Clear();
					cboArea.Items.Add((object)"");
					int num3 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 1;
					while (DC_Main.X <= num3)
					{
						cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboArea.Items.Add((object)"");
				}
				cboArea.SelectedIndex = 0;
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				whatsApp = new WhatsApp(false, false, (string)null, false);
				whatsApp.DisableExts = false;
				whatsApp.UserDataDir = Path.Combine(folderPath, versionInfo.ProductName, "Profile");
				EntryMode = "A";
				if (!DC_Main.MsWappMember)
				{
					if (DC_Main.MsWappEndDay <= 0)
					{
						Interaction.MsgBox((object)"You Have No Subscription... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
						DC_Main.MsWhatsAppOpen = "N";
						LblDays.Text = Conversions.ToString(0);
						((Control)btnWappInstall).Enabled = false;
					}
					else
					{
						Interaction.MsgBox((object)("This is a Demo Version Close After " + Conversions.ToString(DC_Main.MsWappEndDay) + " Days...."), (MsgBoxStyle)0, (object)null);
						DC_Main.MsWappMember = true;
					}
				}
				MsCountryId = "91";
				tCountryCode.Text = MsCountryId;
				nFromRow.Text = Conversions.ToString(1);
				nToRow.Text = Conversions.ToString(250);
				CurActCtrl = (Control)(object)cboMsgType;
			}
		}

		private void UT_WHATSAPP_OLD_Activated(object sender, EventArgs e)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			if (!DC_Main.MsWappMember)
			{
				Interaction.MsgBox((object)"You Have No Subscription... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
				DC_Main.MsWhatsAppOpen = "N";
				LblDays.Text = Conversions.ToString(0);
				((Control)btnWappInstall).Enabled = false;
			}
			else if (DC_Main.MsWappEndDay <= 0)
			{
				Interaction.MsgBox((object)"Your Subscription is Over... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
				LblDays.Text = Conversions.ToString(DC_Main.MsWappEndDay);
				DC_Main.MsWhatsAppOpen = "N";
				((Control)btnWappInstall).Enabled = false;
			}
			else
			{
				LblDays.Text = Conversions.ToString(DC_Main.MsWappEndDay);
			}
		}

		public async void InitializeWhatsApp()
		{
			whatsApp.Headless = true;
			try
			{
				await whatsApp.Initialize(false);
				statusRetriever.Enabled = true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				whatsApp = null;
				MessageBox.Show(ex3.Message);
				((Form)this).Close();
				ProjectData.ClearProjectError();
			}
		}

		private void statusRetriever_Tick(object sender, EventArgs e)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Invalid comparison between Unknown and I4
			try
			{
				state = whatsApp.GetWhatsAppState();
				lblWhatsAppState.Text = $"ENGINE: {((Enum)Unsafe.As<State, State>(ref state)/*cast due to constrained. prefix*/).ToString()}";
				pBoxAuthQR.Image = whatsApp.GetAuthQR();
				LblSenderId.Text = string.Format("Sender Id: {0}", whatsApp.GetSenderId() ?? "Unavailable");
				if ((int)state == 1)
				{
					((Control)BtnLogout).Enabled = true;
				}
				else
				{
					((Control)BtnLogout).Enabled = false;
				}
				Application.DoEvents();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		private void BtnSmsSend_Click(object sender, EventArgs e)
		{
			MaxPages = 0;
			LastRow = 0;
			TotSms = 0;
			Pages = 0;
			lblSmsRow.Text = "Select Row";
			checked
			{
				if (((DataGridView)DGV).Rows.Count > 1)
				{
					int num = ((DataGridView)DGV).Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
						{
							MaxPages++;
							lblSmsRow.Text = Conversions.ToString(MaxPages);
						}
						DC_Main.M++;
					}
				}
				ProgressBar1.Value = 0;
				ProgressBar1.Maximum = MaxPages;
				SendDetl = tMsg.Text;
				if (Operators.CompareString(tMobileNo.Text, "", false) != 0)
				{
					SingelMsg();
				}
				else if (cboBarth.SelectedIndex != 0)
				{
					BirthdaySms();
				}
				else if (OsMsg)
				{
					PartyOsSms();
				}
				else
				{
					DgvSms();
				}
			}
		}

		private async void SingelMsg()
		{
			whatsApp.Headless = true;
			checked
			{
				if (Strings.Len(tMobileNo.Text) == 10)
				{
					ScelectMo = tMobileNo.Text;
					string text = "";
					string text2 = tMsg.Text;
					int num = Strings.Len(text2);
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						text = ((Operators.CompareString(Strings.Mid(text2, DC_Main.M, 1), "\n", false) != 0) ? (text + Strings.Mid(text2, DC_Main.M, 1)) : (text + "\\n"));
						DC_Main.M++;
					}
					if (Operators.CompareString(text, "", false) == 0)
					{
						text = null;
					}
					try
					{
						MessageBox.Show(((Enum)(await whatsApp.SendAsync(tCountryCode.Text + ScelectMo, text, (string)null))/*cast due to constrained. prefix*/).ToString());
						Application.DoEvents();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Exception ex3 = ex2;
						MessageBox.Show(ex3.Message);
						ProjectData.ClearProjectError();
					}
				}
			}
		}

		private unsafe async void PartyOsSms()
		{
			SendRow = 0;
			ScelectMo = "";
			int num = 8;
			State whatsAppState = whatsApp.GetWhatsAppState();
			int num2 = 0;
			if ((int)whatsAppState == 1)
			{
				checked
				{
					foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
					{
						DataGridViewRow val = item;
						try
						{
							if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
							{
								ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num].Value, (object)"")));
								TotSms++;
								if (Operators.CompareString(ScelectMo, "", false) != 0)
								{
									string text = (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)) != 0.0)) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0)) ? (tMsg.Text + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)) != 0.0)) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : ((!((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)) != 0.0))) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + Environment.NewLine + "Have a Nice Day...") : (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + Environment.NewLine + "Have a Nice Day...")))));
									string text2 = MsCountryId + ScelectMo;
									string text3 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(text != null, (object)text, (object)null)));
									string text4 = null;
									if (text2 != null && (text3 != null || text4 != null))
									{
										Response val2 = await whatsApp.SendAsync(text2, text3, text4);
										if (num2 == 27)
										{
											num2 = 0;
											val.Cells[6].Value = ((Enum)(*unchecked((Response*)(&val2)))/*cast due to constrained. prefix*/).ToString();
											if (Convert.ToInt32(numDelay.Value) > 0)
											{
												await Task.Run([SpecialName] async () =>
												{
													await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
												});
											}
											val2 = await whatsApp.SendAsync(IdWappIdNo, "hi", "");
										}
										val.Cells[6].Value = ((Enum)(*unchecked((Response*)(&val2)))/*cast due to constrained. prefix*/).ToString();
									}
								}
								lblSmsCount.Text = Conversions.ToString(TotSms);
								ProgressBar progressBar;
								ProgressBar val3 = (progressBar = ProgressBar1);
								progressBar.Value = val3.Value + 1;
								Application.DoEvents();
								if (Convert.ToInt32(numDelay.Value) > 0)
								{
									await Task.Run([SpecialName] async () =>
									{
										await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
									});
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return;
				}
			}
			MessageBox.Show(((Enum)(*(State*)(&whatsAppState))/*cast due to constrained. prefix*/).ToString());
		}

		private unsafe async void BirthdaySms()
		{
			string text = "";
			string text2 = "";
			DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE IN ('B','A') ORDER BY MSG_TYPE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			State whatsAppState;
			checked
			{
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_TYPE"], (object)"A", false))
					{
						text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_DETL"], (object)"")));
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_TYPE"], (object)"B", false))
					{
						text = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_DETL"], (object)"")));
					}
					DC_Main.i++;
				}
				if (Operators.CompareString(text2, "", false) == 0)
				{
					text2 = "Happy Marriage Anniversary To Both Of You Regards, " + DC_Main.MCo_Name + " Have a Nice Day...";
				}
				if (Operators.CompareString(text, "", false) == 0)
				{
					text = "Happy Birthday To You Regard" + DC_Main.MCo_Name + " Have a Nice Day...";
				}
				SendRow = 0;
				TotSms = 0;
				ScelectMo = "";
				int num2 = 5;
				whatsAppState = whatsApp.GetWhatsAppState();
				int num3 = 0;
				if (unchecked((int)whatsAppState) == 1)
				{
					foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
					{
						DataGridViewRow val = item;
						try
						{
							if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
							{
								ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num2].Value, (object)"")));
								TotSms++;
								if (Operators.CompareString(ScelectMo, "", false) != 0)
								{
									if (Operators.CompareString(Strings.Mid(Conversions.ToString(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)), 1, 1), "A", false) == 0)
									{
										tMsg.Text = text2;
									}
									else if (Operators.CompareString(Strings.Mid(Conversions.ToString(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)), 1, 1), "B", false) == 0)
									{
										tMsg.Text = text;
									}
									string text3 = MsCountryId + ScelectMo;
									string text4 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(tMsg.Text != null, (object)tMsg.Text, (object)null)));
									string text5 = null;
									if (text3 != null && (text4 != null || text5 != null))
									{
										Response val2 = await whatsApp.SendAsync(text3, text4, text5);
										if (num3 == 27)
										{
											num3 = 0;
											val.Cells[4].Value = ((Enum)(*unchecked((Response*)(&val2)))/*cast due to constrained. prefix*/).ToString();
											if (Convert.ToInt32(numDelay.Value) > 0)
											{
												await Task.Run([SpecialName] async () =>
												{
													await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
												});
											}
											val2 = await whatsApp.SendAsync(IdWappIdNo, "hi", "");
										}
										val.Cells[4].Value = ((Enum)(*unchecked((Response*)(&val2)))/*cast due to constrained. prefix*/).ToString();
									}
								}
								lblSmsCount.Text = Conversions.ToString(TotSms);
								ProgressBar progressBar;
								ProgressBar val3 = (progressBar = ProgressBar1);
								progressBar.Value = val3.Value + 1;
								Application.DoEvents();
								if (Convert.ToInt32(numDelay.Value) > 0)
								{
									await Task.Run([SpecialName] async () =>
									{
										await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
									});
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return;
				}
			}
			MessageBox.Show(((Enum)(*(State*)(&whatsAppState))/*cast due to constrained. prefix*/).ToString());
		}

		private unsafe async void DgvSms()
		{
			SendRow = 0;
			TotSms = 0;
			ScelectMo = "";
			int num = 6;
			if (ExelMsg)
			{
				num = 2;
			}
			if (RateMsg)
			{
				num = 5;
			}
			if (CboSmsType.SelectedIndex == 2)
			{
				num = 7;
			}
			lblSmsCount.Text = Conversions.ToString(0);
			string text = tMsg.Text;
			string text2 = "";
			int num2 = Strings.Len(text);
			DC_Main.M = 1;
			State whatsAppState;
			checked
			{
				while (DC_Main.M <= num2)
				{
					text2 = ((Operators.CompareString(Strings.Mid(text, DC_Main.M, 1), "\n", false) != 0) ? (text2 + Strings.Mid(text, DC_Main.M, 1)) : (text2 + "\\n"));
					DC_Main.M++;
				}
				if (Operators.CompareString(text2, "", false) == 0)
				{
					text2 = null;
				}
				whatsAppState = whatsApp.GetWhatsAppState();
				int num3 = 0;
				if (unchecked((int)whatsAppState) == 1)
				{
					foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
					{
						DataGridViewRow val = item;
						try
						{
							if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
							{
								ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num].Value, (object)"")));
								TotSms++;
								if (Operators.CompareString(ScelectMo, "", false) != 0)
								{
									num3++;
									string text3 = MsCountryId + ScelectMo;
									string text4 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(text != null, (object)text, (object)null)));
									string text5 = null;
									unchecked
									{
										if (text3 != null && (text4 != null || text5 != null))
										{
											Response val2 = await whatsApp.SendAsync(text3, Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(text2, "", false) != 0, (object)text2, (object)text4))), text5);
											if (num3 == 27)
											{
												num3 = 0;
												if (ExelMsg)
												{
													val.Cells[3].Value = ((Enum)(*(Response*)(&val2))/*cast due to constrained. prefix*/).ToString();
												}
												else
												{
													val.Cells[5].Value = ((Enum)(*(Response*)(&val2))/*cast due to constrained. prefix*/).ToString();
												}
												if (Convert.ToInt32(numDelay.Value) > 0)
												{
													await Task.Run([SpecialName] async () =>
													{
														await Task.Delay(checked(Convert.ToInt32(numDelay.Value) * 1000));
													});
												}
												val2 = await whatsApp.SendAsync(IdWappIdNo, "hi", "");
											}
											if (ExelMsg)
											{
												val.Cells[3].Value = ((Enum)(*(Response*)(&val2))/*cast due to constrained. prefix*/).ToString();
											}
											else
											{
												val.Cells[5].Value = ((Enum)(*(Response*)(&val2))/*cast due to constrained. prefix*/).ToString();
											}
										}
									}
								}
								lblSmsCount.Text = Conversions.ToString(TotSms);
								ProgressBar progressBar;
								ProgressBar val3 = (progressBar = ProgressBar1);
								progressBar.Value = val3.Value + 1;
								Application.DoEvents();
								if (Convert.ToInt32(numDelay.Value) > 0)
								{
									await Task.Run([SpecialName] async () =>
									{
										await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
									});
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return;
				}
			}
			MessageBox.Show(((Enum)(*(State*)(&whatsAppState))/*cast due to constrained. prefix*/).ToString());
		}

		private void CboSmsType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("0"))
			{
				lblAcGroup.Text = "Ac Group";
			}
			else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("1"))
			{
				lblAcGroup.Text = "Cust Group";
			}
			else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("2"))
			{
				lblAcGroup.Text = "Schm Code";
			}
			AcGroupDetl();
		}

		private void AcGroupDetl()
		{
			cboAcGroup.Items.Clear();
			checked
			{
				if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("0"))
				{
					DC_Main.RsQry = "SELECT A.AC_GR As GrCode,B.AC_GR_NAME as GrName FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.AC_GR,B.AC_GR_NAME  ORDER BY A.AC_GR";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						AryGroup = new string[DC_Main.Rshlp.Rows.Count + 1];
						AryGroup[DC_Main.X] = "";
						cboAcGroup.Items.Add((object)"");
						int num = DC_Main.Rshlp.Rows.Count - 1;
						DC_Main.X = 0;
						while (DC_Main.X <= num)
						{
							cboAcGroup.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)"-"), DC_Main.Rshlp.Rows[DC_Main.X]["GrName"]), (object)""));
							AryGroup[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)""));
							DC_Main.X++;
						}
					}
					else
					{
						cboAcGroup.Items.Add((object)"");
						AryGroup[DC_Main.X] = "";
					}
					cboAcGroup.SelectedIndex = 0;
				}
				else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("1"))
				{
					DC_Main.RsQry = "SELECT A.AC_GR As GrCode FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.AC_GR  ORDER BY A.AC_GR";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						cboAcGroup.Items.Add((object)"");
						int num2 = DC_Main.Rshlp.Rows.Count - 1;
						DC_Main.X = 0;
						while (DC_Main.X <= num2)
						{
							cboAcGroup.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)""));
							DC_Main.X++;
						}
					}
					else
					{
						cboAcGroup.Items.Add((object)"");
						AryGroup[DC_Main.X] = "";
					}
					cboAcGroup.SelectedIndex = 0;
				}
				else
				{
					if ((double)CboSmsType.SelectedIndex != Conversions.ToDouble("2"))
					{
						return;
					}
					DC_Main.RsQry = "SELECT A.SCHM_CODE As GrCode,A.SCHM_NAME as GrName FROM AD_MAST AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.SCHM_CODE";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						AryGroup = new string[DC_Main.Rshlp.Rows.Count + 1];
						AryGroup[DC_Main.X] = "";
						cboAcGroup.Items.Add((object)"");
						int num3 = DC_Main.Rshlp.Rows.Count - 1;
						DC_Main.X = 0;
						while (DC_Main.X <= num3)
						{
							cboAcGroup.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)"-"), DC_Main.Rshlp.Rows[DC_Main.X]["GrName"]), (object)""));
							AryGroup[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)""));
							DC_Main.X++;
						}
					}
					else
					{
						cboAcGroup.Items.Add((object)"");
						AryGroup[DC_Main.X] = "";
					}
					cboAcGroup.SelectedIndex = 0;
				}
			}
		}

		private void DISPLAY_DATA()
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
			tCountryCode.Text = MsCountryId;
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			if (CboSmsType.SelectedIndex == 0)
			{
				PatyMast();
			}
			else if (CboSmsType.SelectedIndex == 1)
			{
				AddressMast();
			}
			else if (CboSmsType.SelectedIndex == 2)
			{
				MembMast();
			}
			nFromRow.Text = Conversions.ToString(1);
			nToRow.Text = Conversions.ToString(250);
		}

		private void AddressMast()
		{
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			ColorConverter colorConverter = new ColorConverter();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND AC_MOBILE <> ''")), (object)" "));
			if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + cboAcGroup.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
			}
			DC_Main.RsQry += "ORDER BY A.AC_NAME";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					((DataGridView)dGV).AutoGenerateColumns = false;
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
					((DataGridView)dGV).Columns[0].Width = 50;
					((DataGridViewColumn)val).Name = "Ok";
					((DataGridView)dGV).Columns.Add("", "SrNo");
					((DataGridView)dGV).Columns[1].Width = 50;
					((DataGridView)dGV).Columns.Add("", "AcCode");
					((DataGridView)dGV).Columns[2].Width = 100;
					((DataGridView)dGV).Columns.Add("", "AcName");
					((DataGridView)dGV).Columns[3].Width = 270;
					((DataGridView)dGV).Columns.Add("", "Address");
					((DataGridView)dGV).Columns[4].Width = 225;
					((DataGridView)dGV).Columns.Add("", "City");
					((DataGridView)dGV).Columns[5].Width = 150;
					((DataGridView)dGV).Columns.Add("", "Mobile");
					((DataGridView)dGV).Columns[6].Width = 110;
					((DataGridView)dGV).Columns.Add("", "Mobile2");
					((DataGridView)dGV).Columns[7].Width = 110;
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num)
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
						((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
						((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
						((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
						((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
						((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
						((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
						DC_Main.i++;
					}
					dGV = null;
				}
			}
		}

		private void MembMast()
		{
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Expected O, but got Unknown
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Expected O, but got Unknown
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			ColorConverter colorConverter = new ColorConverter();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND A.AC_MOBILE <> ''")), (object)" "));
			if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.SCHM_CODE =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
			}
			DC_Main.RsQry += "ORDER BY A.SCHM_CODE,A.MEMB_CODE";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					((DataGridView)dGV).AutoGenerateColumns = false;
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
					((DataGridView)dGV).Columns[0].Width = 50;
					((DataGridViewColumn)val).Name = "Ok";
					((DataGridView)dGV).Columns.Add("", "SrNo");
					((DataGridView)dGV).Columns[1].Width = 50;
					((DataGridView)dGV).Columns.Add("", "SchmCode");
					((DataGridView)dGV).Columns[2].Width = 100;
					((DataGridView)dGV).Columns.Add("", "MembCode");
					((DataGridView)dGV).Columns[3].Width = 100;
					((DataGridView)dGV).Columns.Add("", "MembName");
					((DataGridView)dGV).Columns[4].Width = 270;
					((DataGridView)dGV).Columns.Add("", "Address");
					((DataGridView)dGV).Columns[5].Width = 225;
					((DataGridView)dGV).Columns.Add("", "City");
					((DataGridView)dGV).Columns[6].Width = 150;
					((DataGridView)dGV).Columns.Add("", "Mobile");
					((DataGridView)dGV).Columns[7].Width = 110;
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num)
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
						((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["SCHM_CODE"]);
						((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["MEMB_CODE"]);
						((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["MEMB_NAME"]);
						((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
						((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
						((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
						DC_Main.i++;
					}
					dGV = null;
				}
			}
		}

		private void PatyMast()
		{
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Expected O, but got Unknown
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Expected O, but got Unknown
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			ColorConverter colorConverter = new ColorConverter();
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND AC_MOBILE <> ''")), (object)" AND A.AC_CODE > '00100'  "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND AC_MOBILE <> ''")), (object)" AND LEN(A.AC_CODE) <> 5  "));
			}
			if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
			}
			DC_Main.RsQry += "ORDER BY A.AC_NAME";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					((DataGridView)dGV).AutoGenerateColumns = false;
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
					((DataGridView)dGV).Columns[0].Width = 40;
					((DataGridViewColumn)val).Name = "Ok";
					((DataGridView)dGV).Columns.Add("", "SrNo");
					((DataGridView)dGV).Columns[1].Width = 40;
					((DataGridView)dGV).Columns.Add("", "AcCode");
					((DataGridView)dGV).Columns[2].Width = 80;
					((DataGridView)dGV).Columns.Add("", "AcName");
					((DataGridView)dGV).Columns[3].Width = 250;
					((DataGridView)dGV).Columns.Add("", "Address");
					((DataGridView)dGV).Columns[4].Width = 200;
					((DataGridView)dGV).Columns.Add("", "City");
					((DataGridView)dGV).Columns[5].Width = 130;
					((DataGridView)dGV).Columns.Add("", "Mobile");
					((DataGridView)dGV).Columns[6].Width = 100;
					((DataGridView)dGV).Columns.Add("", "Mobile2");
					((DataGridView)dGV).Columns[7].Width = 100;
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num)
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
						((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
						((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
						((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
						((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
						((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
						((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
						DC_Main.i++;
					}
					dGV = null;
				}
			}
		}

		private void CLEAR_DATA()
		{
			BtnCancel_Click(BtnCancel, new EventArgs());
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			((Form)this).Close();
		}

		private void UT_WHATSAPP_OLD_Deactivate(object sender, EventArgs e)
		{
			if (Information.IsReference((object)CurActCtrl))
			{
				CurActCtrl = null;
				CurActCtrl = ((ContainerControl)this).ActiveControl;
			}
		}

		private void UT_WHATSAPP_OLD_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 27)
			{
				((Form)this).Close();
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(tMsg.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please First Type Massage and Try...", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE MSG_TYPE = '" + tsmstype.Text + "'");
						if (Operators.CompareString(tsmstype.Text, "", false) != 0)
						{
							DC_Main.RsQry = "INSERT INTO MSG_MAST(CO_CODE,MSG_TYPE,MSG_TYPING,MSG_DETL) VALUES('" + DC_Main.MCo_code + "','" + tsmstype.Text + "','E','" + Strings.Mid(tMsg.Text, 1, 500) + "')";
						}
						else
						{
							DC_Main.RsQry = "INSERT INTO MSG_MAST(CO_CODE,MSG_TYPE,MSG_TYPING,MSG_DETL) VALUES('" + DC_Main.MCo_code + "','N','E','" + Strings.Mid(tMsg.Text, 1, 500) + "')";
						}
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Interaction.MsgBox((object)"Data Is Save Ok...", (MsgBoxStyle)0, (object)null);
						BtnCancel_Click(BtnCancel, new EventArgs());
						goto end_IL_0001;
					case 377:
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
					try0001_dispatch = 377;
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
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Invalid comparison between Unknown and I4
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			if ((int)Interaction.MsgBox((object)"Record will delete permantley ?", (MsgBoxStyle)20, (object)null) == 6)
			{
				DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE MSG_DETL = '" + tMsg.Text + "'");
				Interaction.MsgBox((object)"Sms Recotd Delete Sussesfuli...", (MsgBoxStyle)0, (object)null);
				BtnCancel_Click(BtnCancel, new EventArgs());
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
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
			tMsg.Text = "";
			tCountryCode.Text = MsCountryId;
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			CboSmsType.SelectedIndex = 0;
			AcGroupDetl();
			EntryMode = "A";
			((Control)nFromOs).Focus();
		}

		private void UT_WHATSAPP_OLD_Closed(object sender, EventArgs e)
		{
		}

		private void nToOs_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 13)
			{
				SendKeys.Send("{tab}");
			}
		}

		private void nFromOs_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 13 && Operators.CompareString(nFromOs.Text, "", false) != 0)
			{
				SendKeys.Send("{tab}");
			}
		}

		private void CboSmsType_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 13)
			{
				SendKeys.Send("{tab}");
			}
		}

		private void BtnAc_Click(object sender, EventArgs e)
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[6];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 220.0;
			DC_Main.ColWidth[3] = 120.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[3], "", false) != 0)
			{
				tMobileNo.Text = DC_Main.ColValue[3];
				((Control)tMsg).Focus();
			}
		}

		private void BtnMemb_Click(object sender, EventArgs e)
		{
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			DC_Main.RsQry = "SELECT MEMB_NAME As AcNameL,MEMB_CODE as AcCodeL, SCHM_CODE AS SchmCode,AC_ADD1 AS AddressL,AC_CITY AS CityL,AC_MOBILE FROM AD_MEMB   WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY MEMB_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 350.0;
			DC_Main.ColWidth[1] = 110.0;
			DC_Main.ColWidth[2] = 110.0;
			DC_Main.ColWidth[3] = 230.0;
			DC_Main.ColWidth[4] = 180.0;
			DC_Main.ColWidth[5] = 150.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tMobileNo.Text = DC_Main.ColValue[5];
				((Control)tMsg).Focus();
			}
		}

		private void ChkAllRow_CheckedChanged(object sender, EventArgs e)
		{
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			if (!chkAllRow.Checked)
			{
				return;
			}
			double num = 1.0;
			checked
			{
				if ((Conversion.Val(nFromRow.Text) != 0.0) & (Conversion.Val(nToRow.Text) != 0.0))
				{
					int num2 = ((DataGridView)DGV).Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						((DataGridView)DGV)[0, DC_Main.M].Value = false;
						DC_Main.M++;
					}
					if (Conversion.Val((object)((DataGridView)DGV).Rows.Count) < Conversion.Val(nToRow.Text))
					{
						nToRow.Text = Conversions.ToString(Conversion.Val((object)((DataGridView)DGV).Rows.Count));
					}
					if (Conversion.Val(nToRow.Text) < Conversion.Val(nFromRow.Text))
					{
						Interaction.MsgBox((object)"You Cant Set From Row > To row Please change it...", (MsgBoxStyle)0, (object)null);
						((Control)nFromRow).Focus();
						return;
					}
					double a = Conversion.Val(nFromRow.Text) - 1.0;
					double a2 = Conversion.Val(nToRow.Text) - 1.0;
					int m = (int)Math.Round(a);
					int num3 = (int)Math.Round(a2);
					DC_Main.M = m;
					while (DC_Main.M <= num3)
					{
						num += 1.0;
						((DataGridView)DGV)[0, DC_Main.M].Value = true;
						DC_Main.M++;
					}
					lblSmsRow.Text = Conversions.ToString(num);
				}
				else
				{
					int num4 = ((DataGridView)DGV).Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num4)
					{
						((DataGridView)DGV)[0, DC_Main.M].Value = true;
						DC_Main.M++;
					}
					lblSmsRow.Text = Conversions.ToString(DC_Main.M);
				}
			}
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			OsMsg = false;
			RateMsg = false;
			ExelMsg = false;
			chkAllRow.Checked = false;
			DISPLAY_DATA();
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

		private void BtnExlImport_Click(object sender, EventArgs e)
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Invalid comparison between Unknown and I4
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Invalid comparison between Unknown and I4
			chkAllRow.Checked = false;
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			DataGridViewX dGV = DGV;
			((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
			((DataGridView)dGV).AutoGenerateColumns = false;
			DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
			((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
			((DataGridView)dGV).Columns.Add("", "SrNo");
			checked
			{
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(250.0 * ColCon);
				((DataGridViewColumn)val).Name = "Select";
				dGV = null;
			}
			if ((int)Interaction.MsgBox((object)"Import Excel Data....?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				return;
			}
			((FileDialog)DlgOpn).Filter = "Excel files |*.xls;*.xlsx";
			((FileDialog)DlgOpn).Title = "Open File";
			if ((int)((CommonDialog)DlgOpn).ShowDialog() == 1)
			{
				DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpn).FileName);
				DataGridViewX dGV2 = DGV;
				checked
				{
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num)
					{
						((DataGridView)dGV2).Rows.Add();
						((DataGridView)dGV2)[1, DC_Main.i].Value = DC_Main.i;
						((DataGridView)dGV2)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i][0]);
						((DataGridView)dGV2)[3, DC_Main.i].Value = "";
						DC_Main.i++;
					}
					dGV2 = null;
					nFromRow.Text = Conversions.ToString(1);
					nToRow.Text = Conversions.ToString(250);
					OsMsg = false;
					RateMsg = false;
					ExelMsg = true;
				}
			}
		}

		private void tMsg_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			if ((int)e.KeyCode == 112)
			{
				DC_Main.RsQry = "SELECT MSG_DETL As SmsDescL,MSG_TYPE As TypeM FROM MSG_MAST WHERE MSG_DETL <> ''  ORDER BY MSG_DETL";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[3];
				DC_Main.ColWidth[0] = 700.0;
				DC_Main.ColWidth[1] = 50.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tMsg.Text = DC_Main.ColValue[0];
					tsmstype.Text = DC_Main.ColValue[1];
				}
			}
		}

		private void CboBarth_SelectedIndexChanged(object sender, EventArgs e)
		{
			//IL_0695: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0702: Expected O, but got Unknown
			//IL_070c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0713: Expected O, but got Unknown
			if (cboBarth.SelectedIndex == 0)
			{
				tMsg.Text = "";
			}
			if (cboBarth.SelectedIndex == 2)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND DAY(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "   AND   MONTH(BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"  "));
			}
			else if (cboBarth.SelectedIndex == 3)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND DAY(AN_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + " AND   MONTH(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + "  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(AN_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(ANV_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)"  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"  "));
			}
			else
			{
				if (cboBarth.SelectedIndex != 1)
				{
					return;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND (DAY(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " or  DAY(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + ")  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND MONTH(BR_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND MONTH(BIRTH_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "));
			}
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			DC_Main.i = 1;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			bool flag = false;
			if (DC_Main.Tbl.Rows.Count <= 0 || ((DataGridView)DGV).Rows.Count > 0)
			{
				return;
			}
			DataGridViewX dGV = DGV;
			((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
			((DataGridView)dGV).AutoGenerateColumns = false;
			DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
			((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
			((DataGridView)dGV).Columns[0].Width = 50;
			((DataGridViewColumn)val).Name = "Ok";
			((DataGridView)dGV).Columns.Add("", "SrNo");
			checked
			{
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(270.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Address");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(225.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile2");
				((DataGridView)dGV).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
					if (cboBarth.SelectedIndex == 2)
					{
						((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"B - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					}
					else if (cboBarth.SelectedIndex == 3)
					{
						((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"A - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					}
					else
					{
						((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["BR_DATE"])), (object)"A", (object)"B"), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					}
					((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
					((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			checked
			{
				sec++;
				if (sec == 10)
				{
					SendKeys.Send("{ENTER}");
					Timer1.Stop();
					sec = 0;
				}
			}
		}

		private async void BtnWappInstall_Click(object sender, EventArgs e)
		{
			whatsApp.Headless = chkBoxHeadLess.Checked;
			try
			{
				await whatsApp.Initialize(false);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				MessageBox.Show(ex3.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void BtnAcOs_Click(object sender, EventArgs e)
		{
			//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0638: Unknown result type (might be due to invalid IL or missing references)
			//IL_0642: Expected O, but got Unknown
			//IL_064c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0653: Expected O, but got Unknown
			tMsg.Text = "";
			chkAllRow.Checked = false;
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' and A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(cboAcGroup.SelectedIndex == 0, (object)"", (object)("AND B.AC_GR = '" + AryGroup[cboAcGroup.SelectedIndex] + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO "), (object)" HAVING (Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End) + "), (object)" (Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End)+ "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.000')) + "), (object)" (format(Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.000')) + "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.00'))+ "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.00')) <> 0 "), (object)" ORDER BY B.AC_NAME "));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			checked
			{
				while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.X]["DrAmt"], (object)0, false))
					{
						num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DrAmt"]), "0.00"));
					}
					if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.X]["DrGold"], (object)0, false))
					{
						num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DrGold"]), "0.000"));
					}
					if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.X]["DrSilver"], (object)0, false))
					{
						num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DrSilver"]), "0.000"));
					}
					if (num + num2 + num3 != 0.0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,"), (object)Math.Abs(num)), (object)",0,"), (object)Math.Abs(num2)), (object)",0,"), (object)Math.Abs(num3)), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.X++;
				}
				DC_Main.RsQry = "SELECT A.DR_AMT,A.DR_FINE_WT,A.DR_SL_FINE,B.AC_NAME,B.AC_ADD1,B.AC_CITY,B.AC_MOBILE,B.AC_MOBILE2 FROM LEDR_AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ";
				if (Conversion.Val(nFromOs.Text) != 0.0)
				{
					DC_Main.RsQry = (DC_Main.RsQry + " AND A.DR_AMT >= " + nFromOs.Text) ?? "";
				}
				if (Conversion.Val(nToOs.Text) != 0.0)
				{
					DC_Main.RsQry = (DC_Main.RsQry + " AND A.DR_AMT <= " + nToOs.Text) ?? "";
				}
				if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND B.AC_GR =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
				}
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND B.AC_AREA =  '" + cboArea.Text + "'";
				}
				DC_Main.RsQry += " ORDER BY B.AC_NAME";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 1;
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
					return;
				}
				bool flag = false;
				if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					((DataGridView)dGV).AutoGenerateColumns = false;
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
					((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridViewColumn)val).Name = "Ok";
					((DataGridView)dGV).Columns.Add("", "SrNo");
					((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "AmountOs");
					((DataGridView)dGV).Columns[2].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)dGV).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)dGV).Columns[2].DefaultCellStyle.Format = "N2";
					((DataGridView)dGV).Columns.Add("", "GoldOs");
					((DataGridView)dGV).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)dGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)dGV).Columns[3].DefaultCellStyle.Format = "N3";
					((DataGridView)dGV).Columns.Add("", "SilverOs");
					((DataGridView)dGV).Columns[4].Width = (int)Math.Round(85.0 * ColCon);
					((DataGridView)dGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)dGV).Columns[4].DefaultCellStyle.Format = "N2";
					((DataGridView)dGV).Columns.Add("", "AcName");
					((DataGridView)dGV).Columns[5].Width = (int)Math.Round(240.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "Address");
					((DataGridView)dGV).Columns[6].Width = (int)Math.Round(150.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "City");
					((DataGridView)dGV).Columns[7].Width = (int)Math.Round(120.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "Mobile");
					((DataGridView)dGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "Mobile2");
					((DataGridView)dGV).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					int num4 = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num4)
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_AMT"])) != 0.0)
						{
							((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_AMT"]);
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_FINE_WT"])) != 0.0)
						{
							((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_FINE_WT"]);
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_SL_FINE"])) != 0.0)
						{
							((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_SL_FINE"]);
						}
						((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
						((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
						((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
						((DataGridView)dGV)[8, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
						((DataGridView)dGV)[9, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
						DC_Main.i++;
					}
					dGV = null;
				}
				DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE IN ('O') ORDER BY MSG_TYPE ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MSG_DETL"], (object)""));
				}
				if (Operators.CompareString(tMsg.Text, "", false) == 0)
				{
					tMsg.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer, your due amount Is";
				}
				nFromRow.Text = Conversions.ToString(1);
				nToRow.Text = Conversions.ToString(250);
				OsMsg = true;
				RateMsg = false;
				ExelMsg = false;
			}
		}

		private void BtnGoldRate_Click(object sender, EventArgs e)
		{
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Expected O, but got Unknown
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Expected O, but got Unknown
			tMsg.Text = "";
			chkAllRow.Checked = false;
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).Columns.Clear();
			((DataGridView)DGV).Rows.Clear();
			((Control)DGV).Refresh();
			DC_Main.RsQry = "select * from RATE_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				if (dataTable.Rows.Count > 0)
				{
					double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FINE_GL_RATE"]), "0.00"));
					double num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FINE_SL_RATE"]), "0.00"));
					DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = 'G'  ";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[0]["MSG_DETL"], (object)" 999 Gold Rate = "), (object)num), (object)" And 999 Silver Rate = "), (object)num2), (object)" Have a Nice Day..."));
					}
					else
					{
						tMsg.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer Todays  999 Gold Rate = " + Conversions.ToString(num) + " And 999 Silver Rate = " + Conversions.ToString(num2) + " Have a Nice Day...";
					}
					DC_Main.RsQry = "SELECT A.* FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_MOBILE <> '' AND A.AC_GR = '20'";
					if (Operators.CompareString(cboArea.Text, "", false) != 0)
					{
						DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
					}
					DC_Main.RsQry += " ORDER BY  A.AC_NAME ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
					{
						DataGridViewX dGV = DGV;
						((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
						((DataGridView)dGV).AutoGenerateColumns = false;
						DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
						((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
						((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
						((DataGridViewColumn)val).Name = "Ok";
						((DataGridView)dGV).Columns.Add("", "SrNo");
						((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
						((DataGridView)dGV).Columns.Add("", "AcName");
						((DataGridView)dGV).Columns[2].Width = (int)Math.Round(240.0 * ColCon);
						((DataGridView)dGV).Columns.Add("", "Address");
						((DataGridView)dGV).Columns[3].Width = (int)Math.Round(210.0 * ColCon);
						((DataGridView)dGV).Columns.Add("", "City");
						((DataGridView)dGV).Columns[4].Width = (int)Math.Round(120.0 * ColCon);
						((DataGridView)dGV).Columns.Add("", "Mobile");
						((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
						((DataGridView)dGV).Columns.Add("", "Mobile2");
						((DataGridView)dGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
						int num3 = dataTable2.Rows.Count - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num3)
						{
							((DataGridView)dGV).Rows.Add();
							((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
							((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_NAME"]);
							((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_ADD1"]);
							((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_CITY"]);
							((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_MOBILE"]);
							((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_MOBILE2"]);
							DC_Main.i++;
						}
						dGV = null;
					}
					nFromRow.Text = Conversions.ToString(1);
					nToRow.Text = Conversions.ToString(250);
					OsMsg = false;
					RateMsg = true;
					ExelMsg = false;
				}
				else
				{
					Interaction.MsgBox((object)"Please Insert Daily Rate in Rate Master......", (MsgBoxStyle)0, (object)null);
				}
			}
		}

		private void BtnQuit_Click(object sender, EventArgs e)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				whatsApp.Quit();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message);
				ProjectData.ClearProjectError();
			}
		}

		private async void BtnLogout_Click(object sender, EventArgs e)
		{
			try
			{
				whatsApp = await whatsApp.Logout();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				MessageBox.Show(ex3.Message);
				ProjectData.ClearProjectError();
			}
		}

		private void CboMsgType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMsgType.SelectedIndex != 0)
			{
				tsmstype.Text = Strings.Mid(cboMsgType.Text, 1, 1);
				DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = '" + tsmstype.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MSG_DETL"], (object)""));
				}
			}
		}

		private void BtnDelyTime_Click(object sender, EventArgs e)
		{
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			DC_Main.RsQry = "UPDATE CO_SET_NEW SET WAPP_DELAY = " + Conversions.ToString(numDelay.Value) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Whatsapp Delay Time is Set....", (MsgBoxStyle)0, (object)null);
		}

		private void chkBoxHeadLess_Click(object sender, EventArgs e)
		{
			if (!chkBoxHeadLess.Checked)
			{
				((Control)chkBoxHeadLess).Enabled = false;
			}
		}

		private void PnlBotam_DoubleClick(object sender, EventArgs e)
		{
			((Control)chkBoxHeadLess).Enabled = true;
		}

		private void nFromRow_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 13)
			{
				((Control)nToRow).Focus();
			}
		}

		private void nToRow_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)e.KeyCode == 13)
			{
				((Control)chkAllRow).Focus();
			}
		}

		private void TMobileNo_TextChanged(object sender, EventArgs e)
		{
			if (Operators.CompareString(tMobileNo.Text, "", false) != 0)
			{
				((Control)tCountryCode).Enabled = true;
			}
			else
			{
				((Control)tCountryCode).Enabled = false;
			}
		}
	}
}
