using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support.UI;

namespace DataCareNext;

public class Module_WhatsApp
{
	private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

	public delegate void StateChangedEventHandler(WhatsAppState state);

	public delegate void QRCodeAvailableEventHandler(string qrImage);

	public delegate void MessageSentEventHandler(string phone, bool success, string message);

	public delegate void ConnectionEstablishedEventHandler(string phoneNumber);

	public enum WhatsAppState
	{
		Stopped,
		Initializing,
		WaitingForQR,
		Authenticated,
		Ready,
		Error
	}

	public class MockResponse
	{
		public MockStatus Status { get; set; }

		public MockResponse(bool success, string errorMsg)
		{
			Status = new MockStatus(success, errorMsg);
		}
	}

	public class MockStatus
	{
		private bool _success;

		private string _errorMsg;

		public MockStatus(bool success, string errorMsg)
		{
			_success = success;
			_errorMsg = errorMsg;
		}

		public string Description()
		{
			return _success ? "Sent Successfully" : ("Sending Failed: " + _errorMsg);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__58_002D0
	{
		public IWebElement _0024VB_0024Local_resultItem;

		public _Closure_0024__58_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__58_002D0(_Closure_0024__58_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_resultItem = arg0._0024VB_0024Local_resultItem;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(IWebDriver d)
		{
			ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)d).FindElements(By.CssSelector("button[aria-label*='Chat with']"));
			if (readOnlyCollection.Count > 0 && readOnlyCollection[0].Displayed)
			{
				_0024VB_0024Local_resultItem = readOnlyCollection[0];
				return true;
			}
			ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)d).FindElements(By.CssSelector("div[role='row']"));
			foreach (IWebElement item in readOnlyCollection2)
			{
				try
				{
					if (item.Displayed)
					{
						string text = item.Text.Replace(" ", "").Replace("-", "").Replace("+", "");
						if (text.Contains(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_phone))
						{
							_0024VB_0024Local_resultItem = item;
							return true;
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			return false;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__58_002D1
	{
		public string _0024VB_0024Local_phone;

		public _Closure_0024__58_002D1(_Closure_0024__58_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_phone = arg0._0024VB_0024Local_phone;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__59_002D0
	{
		public List<int> _0024VB_0024Local_chromePids;

		public IntPtr _0024VB_0024Local_foundHwnd;

		public _Closure_0024__59_002D0(_Closure_0024__59_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_chromePids = arg0._0024VB_0024Local_chromePids;
				_0024VB_0024Local_foundHwnd = arg0._0024VB_0024Local_foundHwnd;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(IntPtr hWnd, IntPtr lParam)
		{
			try
			{
				if (IsWindowVisible(hWnd) || IsIconic(hWnd))
				{
					int lpdwProcessId = 0;
					GetWindowThreadProcessId(hWnd, ref lpdwProcessId);
					if (_0024VB_0024Local_chromePids.Contains(lpdwProcessId))
					{
						StringBuilder stringBuilder = new StringBuilder(256);
						GetWindowText(hWnd, stringBuilder, 256);
						string text = stringBuilder.ToString();
						if (text.Contains("WhatsApp"))
						{
							_0024VB_0024Local_foundHwnd = hWnd;
							return false;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class VB_0024StateMachine_64_Send : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<object> _0024Builder;

		internal object _0024VB_0024Local_request;

		internal Module_WhatsApp _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_phone_00240;

		internal string _0024VB_0024ResumableLocal_msg_00241;

		internal string _0024VB_0024ResumableLocal_attach_00242;

		internal object _0024VB_0024ResumableLocal_p_00243;

		internal object _0024VB_0024ResumableLocal_m_00244;

		internal object _0024VB_0024ResumableLocal_a_00245;

		internal (bool, string) _0024VB_0024ResumableLocal_result_00246;

		internal TaskAwaiter<(bool, string)> _0024A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = _0024State;
			object obj;
			try
			{
				TaskAwaiter<(bool, string)> awaiter;
				if (num != 0)
				{
					_0024VB_0024ResumableLocal_phone_00240 = "";
					_0024VB_0024ResumableLocal_msg_00241 = "";
					_0024VB_0024ResumableLocal_attach_00242 = "";
					if (_0024VB_0024Local_request != null)
					{
						try
						{
							_0024VB_0024ResumableLocal_p_00243 = RuntimeHelpers.GetObjectValue(Versioned.CallByName(RuntimeHelpers.GetObjectValue(_0024VB_0024Local_request), "Phone", (CallType)2, new object[0]));
							if (_0024VB_0024ResumableLocal_p_00243 != null)
							{
								_0024VB_0024ResumableLocal_phone_00240 = _0024VB_0024ResumableLocal_p_00243.ToString();
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						try
						{
							_0024VB_0024ResumableLocal_m_00244 = RuntimeHelpers.GetObjectValue(Versioned.CallByName(RuntimeHelpers.GetObjectValue(_0024VB_0024Local_request), "Message", (CallType)2, new object[0]));
							if (_0024VB_0024ResumableLocal_m_00244 != null)
							{
								_0024VB_0024ResumableLocal_msg_00241 = _0024VB_0024ResumableLocal_m_00244.ToString();
							}
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
						try
						{
							_0024VB_0024ResumableLocal_a_00245 = RuntimeHelpers.GetObjectValue(Versioned.CallByName(RuntimeHelpers.GetObjectValue(_0024VB_0024Local_request), "AttachmentPath", (CallType)2, new object[0]));
							if (_0024VB_0024ResumableLocal_a_00245 != null)
							{
								_0024VB_0024ResumableLocal_attach_00242 = _0024VB_0024ResumableLocal_a_00245.ToString();
							}
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							ProjectData.ClearProjectError();
						}
					}
					awaiter = _0024VB_0024Me.SendMessageAsync(_0024VB_0024ResumableLocal_phone_00240, _0024VB_0024ResumableLocal_msg_00241, _0024VB_0024ResumableLocal_attach_00242).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						ref AsyncTaskMethodBuilder<object> reference = ref _0024Builder;
						VB_0024StateMachine_64_Send stateMachine = this;
						reference.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
						return;
					}
				}
				else
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<(bool, string)>);
				}
				(bool, string) result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<(bool, string)>);
				_0024VB_0024ResumableLocal_result_00246 = result;
				obj = new MockResponse(_0024VB_0024ResumableLocal_result_00246.Item1, _0024VB_0024ResumableLocal_result_00246.Item2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				_0024State = -2;
				_0024Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = (_0024State = -2);
			_0024Builder.SetResult(RuntimeHelpers.GetObjectValue(obj));
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerNonUserCode]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__70_002D0
	{
		public string[] _0024VB_0024Local_captionSelectors;

		public _Closure_0024__70_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__70_002D0(_Closure_0024__70_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_captionSelectors = arg0._0024VB_0024Local_captionSelectors;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__1(IWebDriver d)
		{
			string[] array = _0024VB_0024Local_captionSelectors;
			foreach (string text in array)
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)d).FindElements(By.CssSelector(text));
				foreach (IWebElement item in readOnlyCollection)
				{
					if (item.Displayed && item.Enabled)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox = item;
						return true;
					}
				}
			}
			return false;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__70_002D1
	{
		public IWebElement _0024VB_0024Local_captionBox;

		public _Closure_0024__70_002D1(_Closure_0024__70_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_captionBox = arg0._0024VB_0024Local_captionBox;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__75_002D0
	{
		public string[] _0024VB_0024Local_captionSelectors;

		public _Closure_0024__75_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__75_002D0(_Closure_0024__75_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_captionSelectors = arg0._0024VB_0024Local_captionSelectors;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__1(IWebDriver d)
		{
			string[] array = _0024VB_0024Local_captionSelectors;
			foreach (string text in array)
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)d).FindElements(By.CssSelector(text));
				foreach (IWebElement item in readOnlyCollection)
				{
					if (item.Displayed && item.Enabled)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox = item;
						return true;
					}
				}
			}
			return false;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__75_002D1
	{
		public IWebElement _0024VB_0024Local_captionBox;

		public _Closure_0024__75_002D1(_Closure_0024__75_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_captionBox = arg0._0024VB_0024Local_captionBox;
			}
		}
	}

	private const int SW_SHOWNOACTIVATE = 4;

	private const int SW_MINIMIZE = 6;

	private const uint SWP_NOACTIVATE = 16u;

	private const uint SWP_NOZORDER = 4u;

	private const uint SWP_NOSIZE = 1u;

	private IWebDriver driver;

	private WebDriverWait wait;

	private bool isInitialized;

	private bool headlessMode;

	private WhatsAppState _currentState;

	public WhatsAppState CurrentState
	{
		get
		{
			return _currentState;
		}
		private set
		{
			_currentState = value;
			StateChanged?.Invoke(value);
		}
	}

	public event StateChangedEventHandler StateChanged;

	public event QRCodeAvailableEventHandler QRCodeAvailable;

	public event MessageSentEventHandler MessageSent;

	public event ConnectionEstablishedEventHandler ConnectionEstablished;

	public Module_WhatsApp()
	{
		isInitialized = false;
		headlessMode = false;
		_currentState = WhatsAppState.Stopped;
	}

	[DllImport("user32.dll")]
	private static extern bool IsIconic(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll")]
	private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);

	[DllImport("user32.dll")]
	private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	private async Task<string> EnsureChromeDriverAsync()
	{
		try
		{
			string text = Path.Combine(Application.StartupPath, "ChromeDriver");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string chromeMajorVersion = GetChromeMajorVersion();
			if (string.IsNullOrEmpty(chromeMajorVersion))
			{
				throw new Exception("Chrome browser Not Found Please install Chrome First....");
			}
			string text2 = Path.Combine(text, "chromedriver.exe");
			if (!File.Exists(text2) || !IsDriverVersionCompatible(text2, chromeMajorVersion))
			{
				Console.WriteLine($"ChromeDriver download for Chrome version {chromeMajorVersion}...");
				await DownloadChromeDriverAsync(chromeMajorVersion, text);
			}
			return text2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			throw new Exception($"ChromeDriver setup મ\u0abe\u0a82 error: {ex3.Message}");
		}
	}

	private string GetChromeVersion()
	{
		string result;
		try
		{
			string[] array = new string[3]
			{
				"C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
				"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe",
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\Application\\chrome.exe")
			};
			string[] array2 = array;
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					string text = array2[num];
					if (File.Exists(text))
					{
						FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text);
						result = versionInfo.FileVersion;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string GetChromeMajorVersion()
	{
		string result;
		try
		{
			string chromeVersion = GetChromeVersion();
			result = (string.IsNullOrEmpty(chromeVersion) ? null : chromeVersion.Split(new char[1] { '.' })[0]);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private async Task DownloadChromeDriverAsync(string chromeMajorVersion, string targetPath)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(targetPath);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				try
				{
					fileInfo.Delete();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				try
				{
					directoryInfo2.Delete(recursive: true);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			HttpClient val = new HttpClient();
			try
			{
				val.Timeout = TimeSpan.FromSeconds(60.0);
				string text = string.Empty;
				try
				{
					Console.WriteLine($"Strategy 1: Searching known-good-versions for Chrome {chromeMajorVersion}...");
					string text2 = "https://googlechromelabs.github.io/chrome-for-testing/known-good-versions-with-downloads.json";
					JObject val2 = JObject.Parse(await val.GetStringAsync(text2));
					JToken val3 = val2["versions"];
					JToken val4 = null;
					foreach (JToken item in (IEnumerable<JToken>)val3)
					{
						string text3 = item[(object)"version"].ToString();
						string text4 = text3.Split(new char[1] { '.' })[0];
						if (Operators.CompareString(text4, chromeMajorVersion, false) == 0)
						{
							JToken val5 = item[(object)"downloads"];
							if (val5 != null && val5[(object)"chromedriver"] != null)
							{
								val4 = item;
							}
						}
					}
					if (val4 != null)
					{
						string arg = val4[(object)"version"].ToString();
						Console.WriteLine($"Found matching ChromeDriver version: {arg}");
						JToken downloads = val4[(object)"downloads"][(object)"chromedriver"];
						text = GetPlatformUrl(downloads);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Exception ex3 = ex2;
					Console.WriteLine($"Strategy 1 failed: {ex3.Message}. Trying fallback...");
					ProjectData.ClearProjectError();
				}
				if (string.IsNullOrEmpty(text))
				{
					try
					{
						Console.WriteLine("Strategy 2: Using last-known-good-versions (latest Stable)...");
						string text5 = "https://googlechromelabs.github.io/chrome-for-testing/last-known-good-versions-with-downloads.json";
						JObject val6 = JObject.Parse(await val.GetStringAsync(text5));
						string arg2 = val6["channels"][(object)"Stable"][(object)"version"].ToString();
						Console.WriteLine($"Latest Stable ChromeDriver version: {arg2}");
						JToken downloads2 = val6["channels"][(object)"Stable"][(object)"downloads"][(object)"chromedriver"];
						text = GetPlatformUrl(downloads2);
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception ex5 = ex4;
						Exception ex6 = ex5;
						Console.WriteLine($"Strategy 2 failed: {ex6.Message}");
						ProjectData.ClearProjectError();
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					throw new Exception($"Windows compatible ChromeDriver Not Found for Chrome v{chromeMajorVersion}....");
				}
				Console.WriteLine($"Downloading ChromeDriver from: {text}");
				string text6 = Path.Combine(targetPath, "chromedriver.zip");
				File.WriteAllBytes(text6, await val.GetByteArrayAsync(text));
				ZipFile.ExtractToDirectory(text6, targetPath);
				File.Delete(text6);
				string[] directories2 = Directory.GetDirectories(targetPath);
				if (directories2.Length > 0)
				{
					string text7 = directories2[0];
					string text8 = Path.Combine(text7, "chromedriver.exe");
					if (File.Exists(text8))
					{
						File.Copy(text8, Path.Combine(targetPath, "chromedriver.exe"), overwrite: true);
					}
					Directory.Delete(text7, recursive: true);
				}
				Console.WriteLine("ChromeDriver successfully downloaded!");
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			Exception ex9 = ex8;
			throw new Exception($"ChromeDriver download Failed: {ex9.Message}");
		}
	}

	private string GetPlatformUrl(JToken downloads)
	{
		if (downloads == null)
		{
			return string.Empty;
		}
		foreach (JToken item in (IEnumerable<JToken>)downloads)
		{
			if (Operators.CompareString(item[(object)"platform"].ToString(), "win64", false) == 0)
			{
				return item[(object)"url"].ToString();
			}
		}
		foreach (JToken item2 in (IEnumerable<JToken>)downloads)
		{
			if (Operators.CompareString(item2[(object)"platform"].ToString(), "win32", false) == 0)
			{
				return item2[(object)"url"].ToString();
			}
		}
		return string.Empty;
	}

	private bool IsDriverVersionCompatible(string driverPath, string chromeVersion)
	{
		bool result;
		try
		{
			string text = "";
			using (Process process = new Process())
			{
				process.StartInfo.FileName = driverPath;
				process.StartInfo.Arguments = "--version";
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				string text2 = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
				string[] array = text2.Split(new char[1] { ' ' });
				if (array.Length >= 2)
				{
					text = array[1].Split(new char[1] { '.' })[0];
				}
			}
			result = !string.IsNullOrEmpty(text) && Operators.CompareString(text, chromeVersion, false) == 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public async Task InitializeAsync(bool headless = false)
	{
		int num = 0;
		int num2 = 2;
		while (true)
		{
			bool flag = false;
			try
			{
				num = checked(num + 1);
				try
				{
					Process[] processesByName = Process.GetProcessesByName("chromedriver");
					foreach (Process process in processesByName)
					{
						try
						{
							process.Kill();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					Process[] processesByName2 = Process.GetProcessesByName("chrome");
					foreach (Process process2 in processesByName2)
					{
						try
						{
							process2.Kill();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
				}
				await Task.Delay(2000);
				CurrentState = WhatsAppState.Initializing;
				headlessMode = headless;
				string path = await EnsureChromeDriverAsync();
				string text = GetChromeVersion();
				if (string.IsNullOrEmpty(text))
				{
					text = "148.0.7778.97";
				}
				Console.WriteLine($"Chrome version detected: {text}");
				ChromeOptions val = new ChromeOptions();
				((ChromiumOptions)val).AddArgument("--no-sandbox");
				((ChromiumOptions)val).AddArgument("--disable-dev-shm-usage");
				((ChromiumOptions)val).AddArgument("--remote-debugging-port=0");
				((ChromiumOptions)val).AddArgument("--disable-gpu");
				((ChromiumOptions)val).AddArgument("--disable-extensions");
				((ChromiumOptions)val).AddArgument("--disable-software-rasterizer");
				((ChromiumOptions)val).AddArgument("--disable-blink-features=AutomationControlled");
				((ChromiumOptions)val).AddArgument("--disable-web-security");
				((ChromiumOptions)val).AddArgument("--allow-running-insecure-content");
				((ChromiumOptions)val).AddArgument("--lang=en-US");
				((ChromiumOptions)val).AddArgument($"--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{text} Safari/537.36");
				((ChromiumOptions)val).AddArgument("--window-size=1920,1080");
				((ChromiumOptions)val).AddUserProfilePreference("profile.default_content_setting_values.images", (object)1);
				((ChromiumOptions)val).AddUserProfilePreference("profile.managed_default_content_settings.images", (object)1);
				if (headless)
				{
					((ChromiumOptions)val).AddArgument("--window-position=0,0");
					((ChromiumOptions)val).AddArgument("--start-maximized");
				}
				else
				{
					((ChromiumOptions)val).AddArgument("--window-position=0,0");
					((ChromiumOptions)val).AddArgument("--start-maximized");
				}
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				string text2 = Path.Combine(folderPath, "DcWapp", "ChromeData_Fixed");
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				((ChromiumOptions)val).AddArgument($"--user-data-dir={text2}");
				string[] array = new string[3]
				{
					"C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
					"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe",
					Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\Application\\chrome.exe")
				};
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					if (File.Exists(text3))
					{
						((ChromiumOptions)val).BinaryLocation = text3;
						break;
					}
				}
				ChromeDriverService val2 = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(path));
				((DriverService)val2).HideCommandPromptWindow = true;
				driver = (IWebDriver)new ChromeDriver(val2, val);
				wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.0));
				driver.Navigate().GoToUrl("https://web.whatsapp.com");
				isInitialized = true;
				if (headless)
				{
					try
					{
						IntPtr chromeWindowHandle = GetChromeWindowHandle();
						if (chromeWindowHandle != IntPtr.Zero)
						{
							ShowWindow(chromeWindowHandle, 6);
							Console.WriteLine("Headless mode: Chrome minimized (off-screen + minimized)");
						}
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
					}
				}
				await CheckAuthenticationStatusAsync();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				if (num >= num2)
				{
					CurrentState = WhatsAppState.Error;
					throw new Exception($"Initialization failed: {ex3.Message}");
				}
				Console.WriteLine($"Init attempt {num} failed: {ex3.Message}. Will clean up and retry...");
				flag = true;
				try
				{
					if (driver != null)
					{
						try
						{
							driver.Quit();
						}
						catch (Exception projectError5)
						{
							ProjectData.SetProjectError(projectError5);
							ProjectData.ClearProjectError();
						}
						driver = null;
					}
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
			if (!flag)
			{
				break;
			}
			try
			{
				Process[] processesByName3 = Process.GetProcessesByName("chromedriver");
				foreach (Process process3 in processesByName3)
				{
					try
					{
						process3.Kill();
					}
					catch (Exception projectError7)
					{
						ProjectData.SetProjectError(projectError7);
						ProjectData.ClearProjectError();
					}
				}
				Process[] processesByName4 = Process.GetProcessesByName("chrome");
				foreach (Process process4 in processesByName4)
				{
					try
					{
						process4.Kill();
					}
					catch (Exception projectError8)
					{
						ProjectData.SetProjectError(projectError8);
						ProjectData.ClearProjectError();
					}
				}
				await Task.Delay(2000);
				string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				string path2 = Path.Combine(folderPath2, "DcWapp", "ChromeData_Fixed");
				if (Directory.Exists(path2))
				{
					try
					{
						Directory.Delete(path2, recursive: true);
					}
					catch (Exception projectError9)
					{
						ProjectData.SetProjectError(projectError9);
						ProjectData.ClearProjectError();
					}
					Console.WriteLine("Cleaned stale ChromeData_Fixed directory");
				}
				string path3 = Path.Combine(Application.StartupPath, "ChromeDriver");
				if (Directory.Exists(path3))
				{
					try
					{
						Directory.Delete(path3, recursive: true);
					}
					catch (Exception projectError10)
					{
						ProjectData.SetProjectError(projectError10);
						ProjectData.ClearProjectError();
					}
					Console.WriteLine("Cleaned old ChromeDriver directory");
				}
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception ex5 = ex4;
				Exception ex6 = ex5;
				Console.WriteLine($"Cleanup error: {ex6.Message}");
				ProjectData.ClearProjectError();
			}
		}
	}

	public async Task Logout()
	{
		try
		{
			if (driver != null)
			{
				try
				{
					driver.Quit();
					((IDisposable)driver).Dispose();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				driver = null;
			}
			if (!headlessMode)
			{
			}
			CurrentState = WhatsAppState.Stopped;
			isInitialized = false;
			await Task.Delay(100);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			Console.WriteLine($"Logout Error: {ex3.Message}");
			ProjectData.ClearProjectError();
		}
	}

	public void Destroy()
	{
		try
		{
			if (driver != null)
			{
				try
				{
					driver.Quit();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				try
				{
					((IDisposable)driver).Dispose();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				driver = null;
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		try
		{
			Process[] processesByName = Process.GetProcessesByName("chromedriver");
			foreach (Process process in processesByName)
			{
				try
				{
					process.Kill();
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception projectError5)
		{
			ProjectData.SetProjectError(projectError5);
			ProjectData.ClearProjectError();
		}
		try
		{
			Process[] processesByName2 = Process.GetProcessesByName("chrome");
			foreach (Process process2 in processesByName2)
			{
				try
				{
					string processCommandLine = GetProcessCommandLine(process2.Id);
					if (processCommandLine.Contains("DcWapp"))
					{
						process2.Kill();
					}
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception projectError7)
		{
			ProjectData.SetProjectError(projectError7);
			ProjectData.ClearProjectError();
		}
		isInitialized = false;
		_currentState = WhatsAppState.Stopped;
		Console.WriteLine("[Destroy] Chrome and ChromeDriver terminated.");
	}

	private string GetProcessCommandLine(int pid)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		try
		{
			ObjectQuery val = new ObjectQuery($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {pid}");
			ManagementObjectSearcher val2 = new ManagementObjectSearcher(val);
			try
			{
				ManagementObjectEnumerator enumerator = default(ManagementObjectEnumerator);
				try
				{
					enumerator = val2.Get().GetEnumerator();
					if (enumerator.MoveNext())
					{
						ManagementBaseObject current = enumerator.Current;
						return Operators.ConcatenateObject(current["CommandLine"], (object)"").ToString();
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return "";
	}

	private async Task CheckAuthenticationStatusAsync()
	{
		checked
		{
			try
			{
				await Task.Delay(5000);
				try
				{
					ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.Id("side"));
					if (readOnlyCollection.Count > 0)
					{
						CurrentState = WhatsAppState.Ready;
						string connectedNumber = GetConnectedNumber();
						int num = 0;
						while (string.IsNullOrEmpty(connectedNumber) && num < 30)
						{
							Console.WriteLine($"Retry {num + 1}/30: Waiting for phone number...");
							await Task.Delay(1000);
							connectedNumber = GetConnectedNumber();
							num++;
						}
						if (string.IsNullOrEmpty(connectedNumber))
						{
							Console.WriteLine("WARNING: Failed to retrieve phone number after 30 retries");
						}
						else
						{
							Console.WriteLine($"SUCCESS: Retrieved phone number: {connectedNumber}");
						}
						ConnectionEstablished?.Invoke(connectedNumber);
						return;
					}
					IWebElement val = null;
					string[] array = new string[7] { "canvas[aria-label='Scan this QR code to link a device!']", "canvas[aria-label*='QR code']", "canvas", "[data-testid='qr-code']", "[data-testid='qrcode']", ".landing-wrapper canvas", "#app canvas" };
					int num2 = 0;
					do
					{
						string[] array2 = array;
						foreach (string text in array2)
						{
							try
							{
								ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector(text));
								if (readOnlyCollection2.Count <= 0)
								{
									continue;
								}
								foreach (IWebElement item in readOnlyCollection2)
								{
									try
									{
										Size size = item.Size;
										if (size.Width > 100 && size.Height > 100)
										{
											val = item;
											Console.WriteLine($"QR Code found with selector: {text}");
											break;
										}
									}
									catch (Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										ProjectData.ClearProjectError();
									}
								}
								if (val != null)
								{
									break;
								}
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								ProjectData.ClearProjectError();
							}
						}
						if (val != null)
						{
							break;
						}
						val = FindQRCodeElement();
						if (val != null)
						{
							break;
						}
						await Task.Delay(1000);
						num2++;
					}
					while (num2 <= 15);
					if (val != null)
					{
						CurrentState = WhatsAppState.WaitingForQR;
						try
						{
							string text2 = (string)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].toDataURL('image/png');", new object[1] { val });
							if (!string.IsNullOrEmpty(text2))
							{
								QRCodeAvailable?.Invoke(text2);
								Console.WriteLine("QR Code event raised successfully");
								return;
							}
							throw new Exception("QR Code data URL is empty");
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							Exception ex3 = ex2;
							Console.WriteLine($"QR Code extraction error: {ex3.Message}");
							CurrentState = WhatsAppState.Error;
							ProjectData.ClearProjectError();
							return;
						}
					}
					readOnlyCollection = ((ISearchContext)driver).FindElements(By.Id("side"));
					if (readOnlyCollection.Count > 0)
					{
						CurrentState = WhatsAppState.Ready;
						string connectedNumber2 = GetConnectedNumber();
						ConnectionEstablished?.Invoke(connectedNumber2);
					}
					else
					{
						Console.WriteLine("QR Code element not found after all retries");
						CurrentState = WhatsAppState.Error;
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception ex5 = ex4;
					Exception ex6 = ex5;
					Console.WriteLine($"CheckAuthenticationStatus Error: {ex6.Message}");
					ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)driver).FindElements(By.Id("side"));
					if (readOnlyCollection3.Count > 0)
					{
						CurrentState = WhatsAppState.Ready;
						string connectedNumber3 = GetConnectedNumber();
						ConnectionEstablished?.Invoke(connectedNumber3);
					}
					else
					{
						CurrentState = WhatsAppState.Error;
					}
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				Exception ex9 = ex8;
				Console.WriteLine($"CheckAuthenticationStatus Outer Error: {ex9.Message}");
				CurrentState = WhatsAppState.Error;
				ProjectData.ClearProjectError();
			}
		}
	}

	public async Task PollAuthenticationAsync()
	{
		checked
		{
			try
			{
				if (CurrentState != WhatsAppState.WaitingForQR)
				{
					return;
				}
				ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.Id("side"));
				if (readOnlyCollection.Count > 0)
				{
					Console.WriteLine("User logged in! Side panel detected.");
					CurrentState = WhatsAppState.Ready;
					string connectedNumber = GetConnectedNumber();
					int num = 0;
					while (string.IsNullOrEmpty(connectedNumber) && num < 10)
					{
						Console.WriteLine($"Polling: Retry {num + 1}/10 for phone number...");
						await Task.Delay(1000);
						connectedNumber = GetConnectedNumber();
						num++;
					}
					if (string.IsNullOrEmpty(connectedNumber))
					{
						Console.WriteLine("Polling: Phone number not found after retries");
					}
					else
					{
						Console.WriteLine($"Polling: Retrieved phone number: {connectedNumber}");
					}
					ConnectionEstablished?.Invoke(connectedNumber);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				Console.WriteLine($"PollAuthenticationAsync error: {ex3.Message}");
				ProjectData.ClearProjectError();
			}
		}
	}

	private string GetConnectedNumber()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		string result;
		try
		{
			IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
			string text = "\r\n                var attempts = ['last-wid', 'last-wid-md', 'user'];\r\n                for (var i = 0; i < attempts.length; i++) {\r\n                    var val = window.localStorage.getItem(attempts[i]);\r\n                    if (val && val.indexOf('@c.us') > -1) return val;\r\n                }\r\n                // Fallback: Deep scan for any key holding a simple WID string\r\n                try {\r\n                    for (var i = 0; i < window.localStorage.length; i++) {\r\n                        var val = window.localStorage.getItem(window.localStorage.key(i));\r\n                        // Check if value looks like '1234567890@c.us' (and isn't a huge JSON blob)\r\n                        if (val && val.length < 40 && val.indexOf('@c.us') > -1) {\r\n                             // Simple regex check: digits + @c.us (ignoring quotes)\r\n                             if (val.replace(/[^0-9@c.us]/g, '').match(/^\\d+@c\\.us$/)) {\r\n                                 return val;\r\n                             }\r\n                        }\r\n                    }\r\n                } catch(e) {}\r\n                return null;";
			object objectValue = RuntimeHelpers.GetObjectValue(val.ExecuteScript(text, new object[0]));
			if (objectValue == null)
			{
				goto IL_0102;
			}
			string text2 = objectValue.ToString();
			text2 = text2.Replace("\"", "").Replace("@c.us", "").Replace("@s.whatsapp.net", "");
			string text3 = new string(text2.Where([SpecialName] (char c) => char.IsDigit(c)).ToArray());
			if (string.IsNullOrEmpty(text3))
			{
				goto IL_0102;
			}
			Console.WriteLine($"Found number from LocalStorage (raw): {text3}");
			if (text3.Length > 12)
			{
				text3 = text3.Substring(0, 12);
				Console.WriteLine($"Trimmed to first 12 digits: {text3}");
			}
			result = text3;
			goto end_IL_0001;
			IL_0102:
			try
			{
				Console.WriteLine("LocalStorage failed, trying UI extraction...");
				string text4 = "\r\n                    try {\r\n                        // Try to find phone number in header/profile area\r\n                        var header = document.querySelector('header');\r\n                        if (header) {\r\n                            var text = header.innerText || header.textContent;\r\n                            // Look for pattern like +91 1234567890 or just digits\r\n                            var match = text.match(/\\+?(\\d{10,15})/);\r\n                            if (match) return match[1];\r\n                        }\r\n                    } catch(e) {}\r\n                    return null;";
				object objectValue2 = RuntimeHelpers.GetObjectValue(val.ExecuteScript(text4, new object[0]));
				if (objectValue2 == null)
				{
					goto end_IL_0102;
				}
				string text5 = objectValue2.ToString();
				Console.WriteLine($"Found number from UI: {text5}");
				result = text5;
				goto end_IL_0001;
				end_IL_0102:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Console.WriteLine($"UI extraction failed: {ex2.Message}");
				ProjectData.ClearProjectError();
			}
			Console.WriteLine("No phone number found in LocalStorage or UI");
			result = string.Empty;
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Console.WriteLine($"GetConnectedNumber error: {ex4.Message}");
			result = string.Empty;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private IWebElement FindQRCodeElement()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		IWebElement result;
		try
		{
			IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
			string text = "\r\n                // Try to find QR code canvas by various methods\r\n                var canvases = document.querySelectorAll('canvas');\r\n                for (var i = 0; i < canvases.length; i++) {\r\n                    var canvas = canvases[i];\r\n                    var rect = canvas.getBoundingClientRect();\r\n                    // QR code canvas is usually larger than 100x100\r\n                    if (rect.width > 100 && rect.height > 100) {\r\n                        // Check if it's in the landing area or main app\r\n                        var parent = canvas.parentElement;\r\n                        while (parent) {\r\n                            if (parent.id === 'app' || parent.className.includes('landing') || parent.className.includes('qr')) {\r\n                                return canvas;\r\n                            }\r\n                            parent = parent.parentElement;\r\n                        }\r\n                        // If no specific parent found but size matches, return it\r\n                        if (canvas.getAttribute('aria-label') && canvas.getAttribute('aria-label').toLowerCase().includes('qr')) {\r\n                            return canvas;\r\n                        }\r\n                    }\r\n                }\r\n                // Fallback: return first large canvas\r\n                for (var i = 0; i < canvases.length; i++) {\r\n                    var rect = canvases[i].getBoundingClientRect();\r\n                    if (rect.width > 150 && rect.height > 150) {\r\n                        return canvases[i];\r\n                    }\r\n                }\r\n                return null;";
			object objectValue = RuntimeHelpers.GetObjectValue(val.ExecuteScript(text, new object[0]));
			if (objectValue == null)
			{
				goto IL_0056;
			}
			IWebElement val2 = (IWebElement)((objectValue is IWebElement) ? objectValue : null);
			if (val2 == null)
			{
				goto IL_0056;
			}
			Console.WriteLine("QR Code found via JavaScript");
			result = val2;
			goto end_IL_0001;
			IL_0056:
			result = null;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Console.WriteLine($"FindQRCodeElement error: {ex2.Message}");
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private async Task<bool> SearchAndOpenChatAsync(string phone)
	{
		_Closure_0024__58_002D1 closure_0024__58_002D = new _Closure_0024__58_002D1(closure_0024__58_002D);
		closure_0024__58_002D._0024VB_0024Local_phone = phone;
		checked
		{
			try
			{
				_Closure_0024__58_002D0 arg = default(_Closure_0024__58_002D0);
				_Closure_0024__58_002D0 CS_0024_003C_003E8__locals11 = new _Closure_0024__58_002D0(arg);
				CS_0024_003C_003E8__locals11._0024VB_0024NonLocal__0024VB_0024Closure_2 = closure_0024__58_002D;
				Console.WriteLine($"Attempting to search for contact: {CS_0024_003C_003E8__locals11._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_phone}");
				IWebElement val = null;
				string[] array = new string[3] { "div[contenteditable='true'][data-tab='3']", "#side div[contenteditable='true']", "div[aria-label='Search input textbox']" };
				string[] array2 = array;
				foreach (string text in array2)
				{
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector(text));
						if (readOnlyCollection.Count > 0 && readOnlyCollection[0].Displayed)
						{
							val = readOnlyCollection[0];
							break;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				if (val == null)
				{
					Console.WriteLine("Search box not found (SearchAndOpenChatAsync).");
					return false;
				}
				try
				{
					val.Click();
					await Task.Delay(100);
					val.SendKeys(Keys.Control + "a");
					val.SendKeys(Keys.Backspace);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				await Task.Delay(150);
				if (headlessMode)
				{
					IJavaScriptExecutor val2 = (IJavaScriptExecutor)driver;
					val2.ExecuteScript("arguments[0].innerText = arguments[1];", new object[2]
					{
						val,
						CS_0024_003C_003E8__locals11._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_phone
					});
					val2.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { val });
				}
				else
				{
					string text2 = CS_0024_003C_003E8__locals11._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_phone;
					for (int j = 0; j < text2.Length; j++)
					{
						val.SendKeys(text2[j].ToString());
						await Task.Delay(20);
					}
				}
				Console.WriteLine("Waiting for search results...");
				await Task.Delay(800);
				try
				{
					Console.WriteLine("Strategy 1: Pressing ENTER on search box...");
					val.SendKeys(Keys.Enter);
					await Task.Delay(1000);
					int num = 1;
					do
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector("#main footer div[contenteditable='true'][role='textbox']"));
						if (readOnlyCollection2.Count > 0 && readOnlyCollection2[0].Displayed)
						{
							Console.WriteLine("Chat opened via ENTER key (STRICT message box verified)!");
							return true;
						}
						await Task.Delay(500);
						num++;
					}
					while (num <= 10);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Exception ex3 = ex2;
					Console.WriteLine($"Strategy 1 error: {ex3.Message}");
					ProjectData.ClearProjectError();
				}
				CS_0024_003C_003E8__locals11._0024VB_0024Local_resultItem = null;
				try
				{
					WebDriverWait val3 = new WebDriverWait(driver, TimeSpan.FromSeconds(15.0));
					((DefaultWait<IWebDriver>)(object)val3).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) =>
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection4 = ((ISearchContext)d).FindElements(By.CssSelector("button[aria-label*='Chat with']"));
						if (readOnlyCollection4.Count > 0 && readOnlyCollection4[0].Displayed)
						{
							CS_0024_003C_003E8__locals11._0024VB_0024Local_resultItem = readOnlyCollection4[0];
							return true;
						}
						ReadOnlyCollection<IWebElement> readOnlyCollection5 = ((ISearchContext)d).FindElements(By.CssSelector("div[role='row']"));
						foreach (IWebElement item in readOnlyCollection5)
						{
							try
							{
								if (item.Displayed)
								{
									string text3 = item.Text.Replace(" ", "").Replace("-", "").Replace("+", "");
									if (text3.Contains(CS_0024_003C_003E8__locals11._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_phone))
									{
										CS_0024_003C_003E8__locals11._0024VB_0024Local_resultItem = item;
										return true;
									}
								}
							}
							catch (Exception projectError5)
							{
								ProjectData.SetProjectError(projectError5);
								ProjectData.ClearProjectError();
							}
						}
						return false;
					}));
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception ex5 = ex4;
					Exception ex6 = ex5;
					Console.WriteLine($"Strategy 2 search error: {ex6.Message}");
					ProjectData.ClearProjectError();
				}
				if (CS_0024_003C_003E8__locals11._0024VB_0024Local_resultItem != null)
				{
					Console.WriteLine("Strategy 2: Clicking result item...");
					try
					{
						CS_0024_003C_003E8__locals11._0024VB_0024Local_resultItem.Click();
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						try
						{
							IJavaScriptExecutor val4 = (IJavaScriptExecutor)driver;
							val4.ExecuteScript("arguments[0].click();", new object[1] { CS_0024_003C_003E8__locals11._0024VB_0024Local_resultItem });
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							Exception ex9 = ex8;
							Console.WriteLine($"JavaScript click failed: {ex9.Message}");
							ProjectData.ClearProjectError();
						}
						ProjectData.ClearProjectError();
					}
					await Task.Delay(800);
				}
				int num2 = 1;
				do
				{
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)driver).FindElements(By.CssSelector("#main footer div[contenteditable='true'][role='textbox']"));
						if (readOnlyCollection3.Count > 0 && readOnlyCollection3[0].Displayed)
						{
							Console.WriteLine("Chat opened successfully via Search (STRICT message box verified)!");
							return true;
						}
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
					}
					await Task.Delay(500);
					num2++;
				}
				while (num2 <= 30);
				Console.WriteLine("Clicked result but message box did not appear (Timeout). Will use URL fallback.");
				return false;
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception ex11 = ex10;
				Exception ex12 = ex11;
				Console.WriteLine($"SearchAndOpenChatAsync Error: {ex12.Message}");
				bool result = false;
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	private IntPtr GetChromeWindowHandle()
	{
		IntPtr result;
		try
		{
			_Closure_0024__59_002D0 arg = default(_Closure_0024__59_002D0);
			_Closure_0024__59_002D0 CS_0024_003C_003E8__locals6 = new _Closure_0024__59_002D0(arg);
			IntPtr zero = IntPtr.Zero;
			CS_0024_003C_003E8__locals6._0024VB_0024Local_chromePids = new List<int>();
			Process[] processesByName = Process.GetProcessesByName("chrome");
			foreach (Process process in processesByName)
			{
				try
				{
					if (process.MainWindowHandle != IntPtr.Zero)
					{
						CS_0024_003C_003E8__locals6._0024VB_0024Local_chromePids.Add(process.Id);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			CS_0024_003C_003E8__locals6._0024VB_0024Local_foundHwnd = IntPtr.Zero;
			EnumWindows([SpecialName] (IntPtr hWnd, IntPtr lParam) =>
			{
				try
				{
					if (IsWindowVisible(hWnd) || IsIconic(hWnd))
					{
						int lpdwProcessId = 0;
						GetWindowThreadProcessId(hWnd, ref lpdwProcessId);
						if (CS_0024_003C_003E8__locals6._0024VB_0024Local_chromePids.Contains(lpdwProcessId))
						{
							StringBuilder stringBuilder = new StringBuilder(256);
							GetWindowText(hWnd, stringBuilder, 256);
							string text = stringBuilder.ToString();
							if (text.Contains("WhatsApp"))
							{
								CS_0024_003C_003E8__locals6._0024VB_0024Local_foundHwnd = hWnd;
								return false;
							}
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				return true;
			}, IntPtr.Zero);
			result = CS_0024_003C_003E8__locals6._0024VB_0024Local_foundHwnd;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Console.WriteLine($"GetChromeWindowHandle error: {ex2.Message}");
			result = IntPtr.Zero;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool IsBrowserWindowMinimized()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		bool result;
		try
		{
			if (driver == null)
			{
				result = false;
			}
			else
			{
				try
				{
					IntPtr chromeWindowHandle = GetChromeWindowHandle();
					if (!(chromeWindowHandle != IntPtr.Zero))
					{
						goto end_IL_0017;
					}
					if (IsIconic(chromeWindowHandle))
					{
						Console.WriteLine("Browser window is minimized (Win32 IsIconic = True)");
						result = true;
					}
					else
					{
						result = false;
					}
					goto end_IL_0001;
					end_IL_0017:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Console.WriteLine($"Win32 IsIconic check failed: {ex2.Message}, trying JS fallback...");
					ProjectData.ClearProjectError();
				}
				try
				{
					IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
					object objectValue = RuntimeHelpers.GetObjectValue(val.ExecuteScript("return document.hidden;", new object[0]));
					if (objectValue == null || !Conversions.ToBoolean(objectValue))
					{
						goto end_IL_0083;
					}
					Console.WriteLine("Browser window is minimized (document.hidden = True)");
					result = true;
					goto end_IL_0001;
					end_IL_0083:;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				try
				{
					IJavaScriptExecutor val2 = (IJavaScriptExecutor)driver;
					long num = Conversions.ToLong(val2.ExecuteScript("return window.outerHeight;", new object[0]));
					long num2 = Conversions.ToLong(val2.ExecuteScript("return window.outerWidth;", new object[0]));
					if (num > 0 && num2 > 0)
					{
						goto end_IL_00e1;
					}
					Console.WriteLine("Browser window is minimized (outerHeight/outerWidth = 0)");
					result = true;
					goto end_IL_0001;
					end_IL_00e1:;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Console.WriteLine($"Error checking browser window state: {ex4.Message}");
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public async Task<(bool, string)> SendMessageAsync(string phone, string message, string attachmentPath = null)
	{
		bool flag13;
		string phone2;
		string message2;
		try
		{
			if (!isInitialized)
			{
				return (false, "WhatsApp Not initialized First Initialize it.");
			}
			if (CurrentState != WhatsAppState.Ready)
			{
				return (false, "WhatsApp Scane QR code For WhatsApp..");
			}
			if (string.IsNullOrEmpty(phone))
			{
				return (false, "Phone number is empty or invalid.");
			}
			phone = phone.Replace("+", "").Replace(" ", "").Replace("-", "");
			try
			{
				IWebElement val = ((ISearchContext)driver).FindElement(By.TagName("body"));
				val.SendKeys(Keys.Escape);
				await Task.Delay(200);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			bool flag = false;
			try
			{
				flag = await SearchAndOpenChatAsync(phone);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				Console.WriteLine($"Search switch failed: {ex3.Message}. Using fallback.");
				ProjectData.ClearProjectError();
			}
			try
			{
				IWebElement val2 = ((ISearchContext)driver).FindElement(By.TagName("body"));
				val2.SendKeys(Keys.Escape);
				await Task.Delay(300);
				val2.SendKeys(Keys.Escape);
				await Task.Delay(200);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			if (!flag)
			{
				string text = $"https://web.whatsapp.com/send?phone={phone}";
				Console.WriteLine($"Navigating to chat (Fallback): {text}");
				driver.Navigate().GoToUrl(text);
			}
			await Task.Delay(1000);
			bool flag2 = false;
			int num = 0;
			bool flag5;
			bool flag7;
			bool flag8;
			IntPtr intPtr;
			checked
			{
				while (!flag2 && num < 120)
				{
					num++;
					bool flag3 = false;
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector("#main footer div[contenteditable='true'][role='textbox']"));
						if (readOnlyCollection.Count > 0 && readOnlyCollection[0].Displayed)
						{
							flag2 = true;
							Console.WriteLine($"Chat loaded successfully after {num} attempt(s) (STRICT verified)");
						}
						else
						{
							flag3 = true;
						}
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						flag3 = true;
						ProjectData.ClearProjectError();
					}
					if (flag3)
					{
						await Task.Delay(500);
					}
				}
				try
				{
					((DefaultWait<IWebDriver>)(object)wait).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) =>
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)d).FindElements(By.Id("main"));
						ReadOnlyCollection<IWebElement> readOnlyCollection4 = ((ISearchContext)d).FindElements(By.CssSelector("div[data-animate-modal-popup='true']"));
						return readOnlyCollection3.Count > 0 || readOnlyCollection4.Count > 0;
					}));
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
				bool flag4 = true;
				int num2 = 0;
				while (flag4 && num2 < 3)
				{
					flag4 = false;
					num2++;
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector("div[role='dialog']"));
						foreach (IWebElement item in readOnlyCollection2)
						{
							if (item.Text.Contains("Phone number shared via url is invalid"))
							{
								return (false, "Invalid Phone Number (WhatsApp does not exist)");
							}
						}
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception ex5 = ex4;
						Exception ex6 = ex5;
						if (ex6.Message.Contains("stale"))
						{
							flag4 = true;
						}
						else if (ex6.Message.Contains("Invalid Phone"))
						{
							(bool, string) result = (false, "Invalid Phone Number");
							ProjectData.ClearProjectError();
							return result;
						}
						ProjectData.ClearProjectError();
					}
					if (flag4)
					{
						await Task.Delay(1000);
					}
				}
				flag5 = false;
				bool flag6 = IsBrowserWindowMinimized();
				if (!flag6)
				{
					try
					{
						IJavaScriptExecutor val3 = (IJavaScriptExecutor)driver;
						object objectValue = RuntimeHelpers.GetObjectValue(val3.ExecuteScript("return document.visibilityState;", new object[0]));
						if (objectValue != null && Operators.CompareString(objectValue.ToString(), "visible", false) != 0)
						{
							flag6 = true;
							Console.WriteLine($"Backup detect: document.visibilityState = '{RuntimeHelpers.GetObjectValue(objectValue)}' - treating as minimized");
						}
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						ProjectData.ClearProjectError();
					}
				}
				Console.WriteLine($"Browser state - Minimized: {flag6}, Headless: {headlessMode}");
				flag7 = flag6;
				flag8 = false;
				intPtr = IntPtr.Zero;
				if (flag7)
				{
					try
					{
						intPtr = GetChromeWindowHandle();
						if (intPtr != IntPtr.Zero)
						{
							Console.WriteLine("OFF-SCREEN STRATEGY: Moving Chrome off-screen for reliable file send...");
							ShowWindow(intPtr, 4);
							await Task.Delay(200);
							SetWindowPos(intPtr, IntPtr.Zero, -32000, -32000, 1920, 1080, 20u);
							await Task.Delay(300);
							flag8 = true;
							Console.WriteLine("Chrome moved off-screen successfully. Sending as normal visible mode.");
						}
						else
						{
							Console.WriteLine("Could not get Chrome window handle - using mini mode fallback");
						}
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						Exception ex9 = ex8;
						Console.WriteLine($"Off-screen move failed: {ex9.Message}. Using mini mode fallback.");
						ProjectData.ClearProjectError();
					}
				}
			}
			if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
			{
				string text2 = Path.GetExtension(attachmentPath).ToLower();
				int num3;
				switch (text2)
				{
				default:
					num3 = ((Operators.CompareString(text2, ".gif", false) == 0) ? 1 : 0);
					break;
				case ".jpg":
				case ".jpeg":
				case ".png":
				case ".bmp":
					num3 = 1;
					break;
				}
				bool flag9 = (byte)num3 != 0;
				try
				{
					Console.WriteLine(string.Format("{0} -> Tier 0: Clipboard Paste method", flag9 ? "Image" : "Document"));
					bool flag10 = false;
					try
					{
						if (!flag9)
						{
							await SendDocumentViaClipboardAsync(attachmentPath, message);
						}
						else
						{
							await SendImageViaClipboardAsync(attachmentPath, message);
						}
						flag5 = true;
					}
					catch (Exception ex10)
					{
						ProjectData.SetProjectError(ex10);
						Exception ex11 = ex10;
						Exception ex12 = ex11;
						Console.WriteLine($"Tier 0 (Clipboard) failed: {ex12.Message}");
						flag10 = true;
						ProjectData.ClearProjectError();
					}
					if (flag10)
					{
						Console.WriteLine(string.Format("{0} -> Tier 1: Native Click method (Fallback)", flag9 ? "Image" : "Document"));
						bool flag11 = false;
						try
						{
							await SendFileNativeAsync(attachmentPath, message);
							flag5 = true;
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception ex14 = ex13;
							Exception ex15 = ex14;
							Console.WriteLine($"Tier 1 (Native) failed: {ex15.Message}");
							flag11 = true;
							ProjectData.ClearProjectError();
						}
						if (flag11)
						{
							Console.WriteLine(string.Format("{0} -> Tier 2: JS File Input method (Last Resort)", flag9 ? "Image" : "Document"));
							try
							{
								await SendAttachmentAsync(attachmentPath, message, isMiniMode: true);
								flag5 = true;
							}
							catch (Exception ex16)
							{
								ProjectData.SetProjectError(ex16);
								Exception ex17 = ex16;
								Exception ex18 = ex17;
								Console.WriteLine($"Tier 2 (JS Input) failed: {ex18.Message}");
								ProjectData.ClearProjectError();
							}
						}
					}
				}
				catch (Exception ex19)
				{
					ProjectData.SetProjectError(ex19);
					Exception ex20 = ex19;
					Exception ex21 = ex20;
					Console.WriteLine($"Attachment failed ({ex21.Message}). Falling back to Text Only...");
					ProjectData.ClearProjectError();
				}
			}
			if (!flag5)
			{
				if (string.IsNullOrEmpty(message))
				{
					return (false, "Attachment failed and no text message provided.");
				}
				Console.WriteLine("Attachment failed. Sending text message only as fallback.");
				await SendTextMessageAsync(message);
			}
			bool flag12 = await VerifySendAndCleanup();
			if (!flag12)
			{
				Console.WriteLine("WARNING: Message may not have been sent - input box was not empty after send. Cleared to prevent merge.");
			}
			if (flag7)
			{
				try
				{
					if (flag8 && intPtr != IntPtr.Zero)
					{
						ShowWindow(intPtr, 6);
						Console.WriteLine("Chrome re-minimized via Win32 after off-screen send.");
					}
					else
					{
						driver.Manage().Window.Minimize();
						Console.WriteLine("Window restored to minimized state after send.");
					}
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					ProjectData.ClearProjectError();
				}
			}
			if (!flag12)
			{
				MessageSent?.Invoke(phone, success: false, "Message not delivered - text remained in input box");
				return (false, "Message not delivered - text remained in input box");
			}
			MessageSent?.Invoke(phone, success: true, "Send Message..");
			return (true, "Success");
		}
		catch (Exception ex22)
		{
			ProjectData.SetProjectError(ex22);
			Exception ex23 = ex22;
			Exception ex24 = ex23;
			flag13 = true;
			phone2 = phone;
			message2 = ex24.Message;
			ProjectData.ClearProjectError();
		}
		if (flag13)
		{
			try
			{
				await ClearChatInputBox();
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				ProjectData.ClearProjectError();
			}
			MessageSent?.Invoke(phone2, success: false, message2);
			return (false, message2);
		}
		return (true, "Success");
	}

	private async Task ClearChatInputBox()
	{
		try
		{
			Console.WriteLine("ClearChatInputBox: Clearing chat input after send failure...");
			IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
			try
			{
				IWebElement val2 = ((ISearchContext)driver).FindElement(By.TagName("body"));
				val2.SendKeys(Keys.Escape);
				await Task.Delay(500);
				ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector("button.btn-primary, button[data-testid='popup-controls-ok']"));
				foreach (IWebElement item in readOnlyCollection)
				{
					if (item.Displayed && item.Text.ToLower().Contains("discard"))
					{
						try
						{
							item.Click();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							val.ExecuteScript("arguments[0].click();", new object[1] { item });
							ProjectData.ClearProjectError();
						}
						Console.WriteLine("ClearChatInputBox: Clicked 'Discard' on confirmation dialog");
						await Task.Delay(500);
						break;
					}
				}
				val2.SendKeys(Keys.Escape);
				await Task.Delay(300);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			string[] array = new string[2] { "#main footer div[contenteditable='true'][role='textbox']", "#main footer div[contenteditable='true']" };
			string[] array2 = array;
			foreach (string text in array2)
			{
				try
				{
					ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector(text));
					if (readOnlyCollection2.Count > 0 && readOnlyCollection2[0].Displayed)
					{
						string text2 = readOnlyCollection2[0].GetAttribute("data-tab") ?? "";
						if (Operators.CompareString(text2, "3", false) != 0)
						{
							val.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { readOnlyCollection2[0] });
							val.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { readOnlyCollection2[0] });
							Console.WriteLine("ClearChatInputBox: Message box cleared successfully.");
							break;
						}
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)driver).FindElements(By.CssSelector("div[contenteditable='true'][data-tab='3']"));
				if (readOnlyCollection3.Count > 0)
				{
					val.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { readOnlyCollection3[0] });
					val.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { readOnlyCollection3[0] });
					Console.WriteLine("ClearChatInputBox: Search bar also cleared.");
				}
			}
			catch (Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				ProjectData.ClearProjectError();
			}
			try
			{
				IWebElement val3 = ((ISearchContext)driver).FindElement(By.TagName("body"));
				val3.SendKeys(Keys.Escape);
				await Task.Delay(200);
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			Console.WriteLine($"ClearChatInputBox error (ignored): {ex3.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private async Task<bool> VerifySendAndCleanup()
	{
		checked
		{
			bool flag;
			try
			{
				IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
				int num = 1;
				do
				{
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector("#main footer div[contenteditable='true'][role='textbox']"));
						if (readOnlyCollection.Count <= 0)
						{
							Console.WriteLine("VerifySendAndCleanup: No message box found (chat may have changed). Assuming sent.");
							return true;
						}
						string text = readOnlyCollection[0].GetAttribute("data-tab") ?? "";
						if (Operators.CompareString(text, "3", false) != 0)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(val.ExecuteScript("return arguments[0].innerText;", new object[1] { readOnlyCollection[0] }));
							if (objectValue == null || string.IsNullOrEmpty(objectValue.ToString().Trim()))
							{
								Console.WriteLine($"VerifySendAndCleanup: Send confirmed (input empty) after {num * 200}ms");
								return true;
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					await Task.Delay(200);
					num++;
				}
				while (num <= 15);
				Console.WriteLine("VerifySendAndCleanup: Text still in input box after 3 seconds. Clearing to prevent merge...");
				await ClearChatInputBox();
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				Console.WriteLine($"VerifySendAndCleanup error (ignored): {ex3.Message}");
				flag = true;
				ProjectData.ClearProjectError();
			}
			if (flag)
			{
				try
				{
					await ClearChatInputBox();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				return false;
			}
			return true;
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_64_Send))]
	[DebuggerStepThrough]
	public Task<object> Send(object request)
	{
		VB_0024StateMachine_64_Send stateMachine = new VB_0024StateMachine_64_Send();
		stateMachine._0024VB_0024Me = this;
		stateMachine._0024VB_0024Local_request = request;
		stateMachine._0024State = -1;
		stateMachine._0024Builder = AsyncTaskMethodBuilder<object>.Create();
		stateMachine._0024Builder.Start(ref stateMachine);
		return stateMachine._0024Builder.Task;
	}

	private void ClearClipboard()
	{
		Thread thread = new Thread([SpecialName] () =>
		{
			try
			{
				Clipboard.Clear();
				Thread.Sleep(50);
				Clipboard.Clear();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		Thread.Sleep(50);
	}

	private void SetClipboard(string text)
	{
		Thread thread = new Thread([SpecialName] () =>
		{
			try
			{
				Clipboard.Clear();
				Clipboard.SetText(text);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
	}

	private void SetClipboardImage(string imagePath)
	{
		Thread thread = new Thread([SpecialName] () =>
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			try
			{
				Clipboard.Clear();
				Thread.Sleep(50);
				byte[] buffer = File.ReadAllBytes(imagePath);
				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					Image val = Image.FromStream((Stream)memoryStream);
					try
					{
						Image val2 = (Image)val.Clone();
						try
						{
							Clipboard.SetImage(val2);
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				Console.WriteLine($"Clipboard Image Set: {imagePath}");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Console.WriteLine($"Clipboard Image Error: {ex2.Message}");
				ProjectData.ClearProjectError();
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		Thread.Sleep(300);
	}

	private async Task<bool> SendImageViaClipboardAsync(string imagePath, string caption)
	{
		bool result = false;
		checked
		{
			try
			{
				_Closure_0024__70_002D1 closure_0024__70_002D = new _Closure_0024__70_002D1(closure_0024__70_002D);
				Console.WriteLine($"SendImageViaClipboardAsync: Starting for image: {imagePath}");
				ClearClipboard();
				await Task.Delay(200);
				IWebElement val = null;
				int num = 120;
				int num2 = 0;
				while (val == null && num2 < num)
				{
					num2++;
					string[] array = new string[3] { "#main footer div[contenteditable='true'][role='textbox']", "#main footer div[contenteditable='true']", "#main div[title='Type a message']" };
					string[] array2 = array;
					foreach (string text in array2)
					{
						try
						{
							ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector(text));
							if (readOnlyCollection.Count > 0 && readOnlyCollection[0].Displayed)
							{
								string text2 = readOnlyCollection[0].GetAttribute("data-tab") ?? "";
								if (Operators.CompareString(text2, "3", false) != 0)
								{
									val = readOnlyCollection[0];
									break;
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					if (val == null)
					{
						await Task.Delay(500);
					}
				}
				if (val == null)
				{
					throw new Exception("Message box not found for pasting");
				}
				IJavaScriptExecutor val2 = (IJavaScriptExecutor)driver;
				val2.ExecuteScript("arguments[0].focus();", new object[1] { val });
				val2.ExecuteScript("arguments[0].click();", new object[1] { val });
				await Task.Delay(200);
				Console.WriteLine($"Loading image to clipboard: {imagePath}");
				SetClipboardImage(imagePath);
				await Task.Delay(500);
				Console.WriteLine("Pasting image (Ctrl+V)...");
				val.SendKeys(Keys.Control + "v");
				await Task.Delay(1000);
				try
				{
					((DefaultWait<IWebDriver>)(object)wait).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) => ((ISearchContext)d).FindElements(By.CssSelector("span[data-icon='send']")).Count > 0 || ((ISearchContext)d).FindElements(By.CssSelector("div[contenteditable='true']")).Count > 0));
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					Console.WriteLine("Warning: Media preview (paste) might not have loaded.");
					ProjectData.ClearProjectError();
				}
				closure_0024__70_002D._0024VB_0024Local_captionBox = null;
				Console.WriteLine("Finding caption box for image send...");
				try
				{
					_Closure_0024__70_002D0 arg = default(_Closure_0024__70_002D0);
					_Closure_0024__70_002D0 CS_0024_003C_003E8__locals12 = new _Closure_0024__70_002D0(arg);
					CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2 = closure_0024__70_002D;
					CS_0024_003C_003E8__locals12._0024VB_0024Local_captionSelectors = new string[5] { "div[aria-placeholder='Add a caption']", "div[data-animate-modal-popup='true'] div[role='textbox'][contenteditable='true']", "div[data-animate-modal-popup='true'] div[contenteditable='true']", "div[data-animate-modal-popup='true'] span[data-icon='emoji-input'] + div div[contenteditable='true']", "div[role='textbox'][contenteditable='true']" };
					WebDriverWait val3 = new WebDriverWait(driver, TimeSpan.FromSeconds(5.0));
					try
					{
						((DefaultWait<IWebDriver>)(object)val3).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) =>
						{
							string[] array6 = CS_0024_003C_003E8__locals12._0024VB_0024Local_captionSelectors;
							foreach (string text7 in array6)
							{
								ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)d).FindElements(By.CssSelector(text7));
								foreach (IWebElement item in readOnlyCollection3)
								{
									if (item.Displayed && item.Enabled)
									{
										CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox = item;
										return true;
									}
								}
							}
							return false;
						}));
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						Console.WriteLine("Timed out waiting for specific caption box.");
						ProjectData.ClearProjectError();
					}
					if (CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox != null)
					{
						try
						{
							val2.ExecuteScript("arguments[0].focus();", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
							val2.ExecuteScript("arguments[0].click();", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
							await Task.Delay(300);
							if (!string.IsNullOrEmpty(caption))
							{
								val2.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
								Console.WriteLine($"Typing caption: {caption}");
								string text3 = caption.Replace("\r\n", "\n").Replace("\r", "\n");
								string[] array3 = text3.Split(new string[1] { "\n" }, StringSplitOptions.None);
								try
								{
									int num3 = array3.Length - 1;
									for (int num4 = 0; num4 <= num3; num4++)
									{
										string text4 = array3[num4];
										if (!string.IsNullOrEmpty(text4))
										{
											CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox.SendKeys(text4);
										}
										if (num4 < array3.Length - 1)
										{
											CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox.SendKeys(Keys.Shift + Keys.Enter);
											await Task.Delay(50);
										}
									}
								}
								catch (Exception projectError4)
								{
									ProjectData.SetProjectError(projectError4);
									string text5 = HttpUtility.HtmlEncode(text3);
									text5 = text5.Replace("\n", "<br>");
									val2.ExecuteScript("arguments[0].innerHTML = arguments[1];", new object[2]
									{
										CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox,
										text5
									});
									ProjectData.ClearProjectError();
								}
								val2.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
								await Task.Delay(500);
							}
							result = true;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							Exception ex3 = ex2;
							Console.WriteLine($"Error typing caption: {ex3.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						Console.WriteLine("Caption box not found after retries");
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception ex5 = ex4;
					Exception ex6 = ex5;
					Console.WriteLine($"Caption error: {ex6.Message}");
					ProjectData.ClearProjectError();
				}
				await Task.Delay(300);
				bool flag = false;
				if (!flag)
				{
					try
					{
						if (closure_0024__70_002D._0024VB_0024Local_captionBox != null)
						{
							closure_0024__70_002D._0024VB_0024Local_captionBox.SendKeys(Keys.Return);
							Console.WriteLine("Send triggered via Enter key on caption box");
							flag = true;
						}
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						ProjectData.ClearProjectError();
					}
				}
				if (!flag)
				{
					string[] array4 = new string[7] { "div[role='dialog'] span[data-icon='send']", "div[data-animate-modal-popup='true'] span[data-icon='send']", "div[role='dialog'] div[aria-label='Send']", "span[data-icon='send']", "div[aria-label='Send']", "div[role='button'][aria-label='Send']", "span[data-icon='send-light']" };
					IWebElement val4 = null;
					int num5 = 1;
					do
					{
						string[] array5 = array4;
						foreach (string text6 in array5)
						{
							try
							{
								ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector(text6));
								if (readOnlyCollection2.Count > 0)
								{
									val4 = readOnlyCollection2[0];
									break;
								}
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								ProjectData.ClearProjectError();
							}
							if (val4 != null)
							{
								break;
							}
						}
						if (val4 != null)
						{
							break;
						}
						await Task.Delay(400);
						num5++;
					}
					while (num5 <= 10);
					if (val4 != null)
					{
						try
						{
							val2.ExecuteScript("\r\n                            arguments[0].dispatchEvent(new MouseEvent('mousedown', {bubbles:true, cancelable:true}));\r\n                            arguments[0].dispatchEvent(new MouseEvent('mouseup',   {bubbles:true, cancelable:true}));\r\n                            arguments[0].dispatchEvent(new MouseEvent('click',     {bubbles:true, cancelable:true}));\r\n                            try { arguments[0].click(); } catch(e) {}\r\n                        ", new object[1] { val4 });
							Console.WriteLine("Send button clicked via MouseEvent dispatch");
							flag = true;
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							Exception ex9 = ex8;
							Console.WriteLine($"MouseEvent send failed: {ex9.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						Console.WriteLine("WARNING: Send button not found after retries");
					}
				}
				if (!flag)
				{
					try
					{
						IWebElement val5 = ((ISearchContext)driver).FindElement(By.TagName("body"));
						val5.SendKeys(Keys.Return);
						Console.WriteLine("Send triggered via Enter on body (last resort)");
					}
					catch (Exception projectError7)
					{
						ProjectData.SetProjectError(projectError7);
						ProjectData.ClearProjectError();
					}
				}
				Console.WriteLine("Waiting for image to be sent...");
				await Task.Delay(500);
				try
				{
					int num7 = 1;
					do
					{
						if (((ISearchContext)driver).FindElements(By.CssSelector("span[data-icon='send']")).Count <= 0)
						{
							Console.WriteLine("Image sent successfully - preview closed");
							break;
						}
						await Task.Delay(300);
						num7++;
					}
					while (num7 <= 6);
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					ProjectData.ClearProjectError();
				}
				Console.WriteLine("Clearing clipboard after image send...");
				ClearClipboard();
				await Task.Delay(200);
				return result;
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception ex11 = ex10;
				Exception ex12 = ex11;
				ClearClipboard();
				throw new Exception($"Clipboard Paste Failed: {ex12.Message}");
			}
		}
	}

	private async Task SendTextMessageAsync(string message)
	{
		checked
		{
			try
			{
				Console.WriteLine("SendTextMessageAsync: Starting (Full JavaScript Method for Minimized Mode)...");
				int length = message.Length;
				int millisecondsDelay = 300;
				if (length > 500)
				{
					millisecondsDelay = 800;
					Console.WriteLine($"Long message detected ({length} chars)");
				}
				else if (length > 200)
				{
					millisecondsDelay = 500;
				}
				await Task.Delay(millisecondsDelay);
				IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
				IWebElement val2 = null;
				int num = 120;
				int num2 = 0;
				while (val2 == null && num2 < num)
				{
					num2++;
					string[] array = new string[3] { "#main footer div[contenteditable='true'][role='textbox']", "#main footer div[contenteditable='true']", "#main div[title='Type a message']" };
					string[] array2 = array;
					foreach (string text in array2)
					{
						try
						{
							ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector(text));
							if (readOnlyCollection.Count > 0 && readOnlyCollection[0].Displayed)
							{
								string text2 = readOnlyCollection[0].GetAttribute("data-tab") ?? "";
								if (Operators.CompareString(text2, "3", false) != 0)
								{
									val2 = readOnlyCollection[0];
									Console.WriteLine($"Message box found with selector: {text}");
									break;
								}
								Console.WriteLine($"WARNING: Selector {text} matched search bar (data-tab=3), skipping!");
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					if (val2 == null)
					{
						Console.WriteLine($"Retry {num2}/{num}: Message box not found, waiting...");
						await Task.Delay(500);
					}
				}
				if (val2 == null)
				{
					CaptureScreenshot("MessageBoxNotFound");
					throw new Exception("Message box not found after retries");
				}
				val.ExecuteScript("arguments[0].focus();", new object[1] { val2 });
				val.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { val2 });
				await Task.Delay(200);
				Console.WriteLine($"Inserting text via JavaScript: {message.Substring(0, Math.Min(50, message.Length))}...");
				string text3 = message.Replace("\r\n", "\n").Replace("\r", "\n");
				string[] array3 = text3.Split(new string[1] { "\n" }, StringSplitOptions.None);
				Console.WriteLine($"Message has {array3.Length} lines");
				try
				{
					val.ExecuteScript("arguments[0].focus();", new object[1] { val2 });
					val.ExecuteScript("arguments[0].click();", new object[1] { val2 });
					await Task.Delay(200);
					int millisecondsDelay2 = ((length > 500) ? 100 : 50);
					int num3 = array3.Length - 1;
					for (int j = 0; j <= num3; j++)
					{
						string text4 = array3[j];
						if (!string.IsNullOrEmpty(text4))
						{
							val2.SendKeys(text4);
							await Task.Delay(millisecondsDelay2);
						}
						if (j < array3.Length - 1)
						{
							val2.SendKeys(Keys.Shift + Keys.Enter);
							await Task.Delay(millisecondsDelay2);
						}
					}
					await Task.Delay(300);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Exception ex3 = ex2;
					Console.WriteLine($"SendKeys failed: {ex3.Message}, trying JS fallback...");
					try
					{
						string text5 = HttpUtility.HtmlEncode(text3);
						text5 = text5.Replace("\n", "<br>");
						val.ExecuteScript("arguments[0].innerHTML = arguments[1];", new object[2] { val2, text5 });
						val.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { val2 });
						Thread.Sleep(300);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						val.ExecuteScript("arguments[0].innerText = arguments[1];", new object[2] { val2, text3 });
						Thread.Sleep(300);
						ProjectData.ClearProjectError();
					}
					ProjectData.ClearProjectError();
				}
				val.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { val2 });
				val.ExecuteScript("arguments[0].dispatchEvent(new Event('change', { bubbles: true }));", new object[1] { val2 });
				await Task.Delay(300);
				val.ExecuteScript("arguments[0].dispatchEvent(new KeyboardEvent('keydown', { bubbles: true, key: ' ' }));", new object[1] { val2 });
				val.ExecuteScript("arguments[0].dispatchEvent(new KeyboardEvent('keyup', { bubbles: true, key: ' ' }));", new object[1] { val2 });
				await Task.Delay(300);
				bool flag = false;
				string[] array4 = new string[4] { "span[data-icon='send']", "div[aria-label='Send']", "button[aria-label='Send']", "span[data-icon='send-light']" };
				string[] array5 = array4;
				foreach (string text6 in array5)
				{
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector(text6));
						if (readOnlyCollection2.Count > 0)
						{
							val.ExecuteScript("arguments[0].click();", new object[1] { readOnlyCollection2[0] });
							Console.WriteLine($"Send button clicked via JS: {text6}");
							flag = true;
							break;
						}
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
					}
				}
				if (!flag)
				{
					Console.WriteLine("Send button not found, trying Enter key via JavaScript...");
					val.ExecuteScript("arguments[0].dispatchEvent(new KeyboardEvent('keydown', { bubbles: true, key: 'Enter', keyCode: 13 }));", new object[1] { val2 });
					val.ExecuteScript("arguments[0].dispatchEvent(new KeyboardEvent('keypress', { bubbles: true, key: 'Enter', keyCode: 13 }));", new object[1] { val2 });
					val.ExecuteScript("arguments[0].dispatchEvent(new KeyboardEvent('keyup', { bubbles: true, key: 'Enter', keyCode: 13 }));", new object[1] { val2 });
				}
				int millisecondsDelay3 = ((length > 500) ? 1500 : 800);
				await Task.Delay(millisecondsDelay3);
				Console.WriteLine("Message sent successfully via JavaScript method.");
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception ex5 = ex4;
				Exception ex6 = ex5;
				CaptureScreenshot("MessagingError");
				Console.WriteLine($"Error: {ex6.Message}");
				try
				{
					IJavaScriptExecutor val3 = (IJavaScriptExecutor)driver;
					string[] array6 = new string[2] { "#main footer div[contenteditable='true'][role='textbox']", "#main footer div[contenteditable='true']" };
					string[] array7 = array6;
					foreach (string text7 in array7)
					{
						try
						{
							ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)driver).FindElements(By.CssSelector(text7));
							if (readOnlyCollection3.Count > 0)
							{
								val3.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { readOnlyCollection3[0] });
								val3.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { readOnlyCollection3[0] });
								Console.WriteLine("SendTextMessageAsync: Cleared message box after error.");
								break;
							}
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							ProjectData.ClearProjectError();
						}
					}
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					ProjectData.ClearProjectError();
				}
				throw new Exception($"Message send error: {ex6.Message}");
			}
		}
	}

	private async Task<bool> SendFileNativeAsync(string filePath, string caption)
	{
		bool flag = false;
		string text = Path.GetExtension(filePath).ToLower();
		int num;
		switch (text)
		{
		default:
			num = ((Operators.CompareString(text, ".gif", false) == 0) ? 1 : 0);
			break;
		case ".jpg":
		case ".jpeg":
		case ".png":
		case ".bmp":
			num = 1;
			break;
		}
		bool flag2 = (byte)num != 0;
		IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
		Console.WriteLine($"[Native] SendFileNativeAsync START. File: {filePath}, IsImage: {flag2}");
		IWebElement val2 = null;
		string[] array = new string[8] { "button[aria-label='Attach']", "div[aria-label='Attach']", "button[title='Attach']", "div[title='Attach']", "span[data-icon='plus-rounded']", "span[data-icon='plus']", "span[data-icon='attach-menu-plus']", "span[data-icon='clip']" };
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector(text2));
				if (readOnlyCollection.Count <= 0)
				{
					continue;
				}
				IWebElement val3 = null;
				try
				{
					val3 = ((ISearchContext)readOnlyCollection[0]).FindElement(By.XPath("ancestor-or-self::button[1]"));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (val3 == null)
				{
					try
					{
						val3 = ((ISearchContext)readOnlyCollection[0]).FindElement(By.XPath("ancestor-or-self::*[@role='button'][1]"));
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						val3 = readOnlyCollection[0];
						ProjectData.ClearProjectError();
					}
				}
				val2 = val3;
				Console.WriteLine($"[Native] Attach button located via: {text2}");
				break;
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
		}
		if (val2 == null)
		{
			throw new Exception("[Native] Attach button NOT found in DOM");
		}
		try
		{
			val2.Click();
			Console.WriteLine("[Native] Attach button clicked (native Click)");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			Console.WriteLine($"[Native] Native click failed: {ex3.Message}. Trying JS click...");
			try
			{
				val.ExecuteScript("arguments[0].click();", new object[1] { val2 });
				Console.WriteLine("[Native] Attach button clicked via JS fallback");
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception ex5 = ex4;
				Exception ex6 = ex5;
				throw new Exception($"[Native] Both native and JS click failed for attach button: {ex6.Message}");
			}
			ProjectData.ClearProjectError();
		}
		await Task.Delay(1200);
		IWebElement val4 = null;
		string[] array3;
		string value;
		if (flag2)
		{
			array3 = new string[9] { "[aria-label='Photos & Videos']", "[aria-label='Photo & Video']", "[aria-label='Photos']", "[aria-label='Gallery']", "span[data-icon='attach-image']", "span[data-icon='ic-attach-photo-video']", "span[data-icon='attach-photo']", "span[data-icon='gallery']", "span[data-icon='image']" };
			value = "photo";
		}
		else
		{
			array3 = new string[4] { "[aria-label='Document']", "[aria-label='Documents']", "span[data-icon='attach-document']", "span[data-icon='document']" };
			value = "document";
		}
		string[] array4 = array3;
		foreach (string text3 in array4)
		{
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector(text3));
				foreach (IWebElement item in readOnlyCollection2)
				{
					if (!item.Displayed)
					{
						continue;
					}
					IWebElement val5 = null;
					try
					{
						val5 = ((ISearchContext)item).FindElement(By.XPath("ancestor-or-self::label[1]"));
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
					}
					if (val5 == null)
					{
						try
						{
							val5 = ((ISearchContext)item).FindElement(By.XPath("ancestor-or-self::button[1]"));
						}
						catch (Exception projectError5)
						{
							ProjectData.SetProjectError(projectError5);
							ProjectData.ClearProjectError();
						}
					}
					if (val5 == null)
					{
						try
						{
							val5 = ((ISearchContext)item).FindElement(By.XPath("ancestor-or-self::*[@role='button'][1]"));
						}
						catch (Exception projectError6)
						{
							ProjectData.SetProjectError(projectError6);
							ProjectData.ClearProjectError();
						}
					}
					if (val5 == null)
					{
						val5 = item;
					}
					val4 = val5;
					Console.WriteLine($"[Native] Button found via: {text3}");
					break;
				}
				if (val4 != null)
				{
					break;
				}
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				ProjectData.ClearProjectError();
			}
		}
		if (val4 == null)
		{
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)driver).FindElements(By.CssSelector("li, div[role='menuitem'], div[role='option']"));
				foreach (IWebElement item2 in readOnlyCollection3)
				{
					if (item2.Displayed)
					{
						string text4 = (item2.Text ?? "").Trim().ToLower();
						if (text4.Length > 0 && text4.Length < 40 && text4.Contains(value) && !text4.Contains("sticker") && !text4.Contains("camera"))
						{
							val4 = item2;
							Console.WriteLine($"[Native] Button found by text: '{item2.Text}'");
							break;
						}
					}
				}
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				ProjectData.ClearProjectError();
			}
		}
		if (val4 == null && flag2)
		{
			Console.WriteLine("[Native] Photos & Videos not found. Falling back to Document for image.");
			string[] array5 = new string[3] { "[aria-label='Document']", "span[data-icon='attach-document']", "span[data-icon='document']" };
			string[] array6 = array5;
			foreach (string text5 in array6)
			{
				try
				{
					ReadOnlyCollection<IWebElement> readOnlyCollection4 = ((ISearchContext)driver).FindElements(By.CssSelector(text5));
					foreach (IWebElement item3 in readOnlyCollection4)
					{
						if (!item3.Displayed)
						{
							continue;
						}
						IWebElement val6 = null;
						try
						{
							val6 = ((ISearchContext)item3).FindElement(By.XPath("ancestor-or-self::label[1]"));
						}
						catch (Exception projectError9)
						{
							ProjectData.SetProjectError(projectError9);
							ProjectData.ClearProjectError();
						}
						if (val6 == null)
						{
							try
							{
								val6 = ((ISearchContext)item3).FindElement(By.XPath("ancestor-or-self::button[1]"));
							}
							catch (Exception projectError10)
							{
								ProjectData.SetProjectError(projectError10);
								ProjectData.ClearProjectError();
							}
						}
						if (val6 == null)
						{
							val6 = item3;
						}
						val4 = val6;
						Console.WriteLine($"[Native] Document fallback found via: {text5}");
						break;
					}
					if (val4 != null)
					{
						break;
					}
				}
				catch (Exception projectError11)
				{
					ProjectData.SetProjectError(projectError11);
					ProjectData.ClearProjectError();
				}
			}
		}
		if (val4 == null)
		{
			throw new Exception("[Native] Could not find attach submenu button. Menu may not have opened.");
		}
		Console.WriteLine("[Native] Native-clicking submenu button...");
		try
		{
			val4.Click();
			Console.WriteLine("[Native] Submenu click OK → OS file dialog should open");
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			Exception ex9 = ex8;
			Console.WriteLine($"[Native] Native click failed: {ex9.Message}. Trying JS...");
			try
			{
				val.ExecuteScript("arguments[0].click();", new object[1] { val4 });
				Console.WriteLine("[Native] JS click done");
			}
			catch (Exception projectError12)
			{
				ProjectData.SetProjectError(projectError12);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
		await Task.Delay(1500);
		Console.WriteLine($"[Native] Pasting path in OS dialog: {filePath}");
		string text6 = "";
		try
		{
			text6 = Clipboard.GetText();
		}
		catch (Exception projectError13)
		{
			ProjectData.SetProjectError(projectError13);
			ProjectData.ClearProjectError();
		}
		try
		{
			Clipboard.SetText(filePath);
			await Task.Delay(300);
			SendKeys.SendWait("^a");
			await Task.Delay(200);
			SendKeys.SendWait("^v");
			await Task.Delay(400);
			SendKeys.SendWait("{ENTER}");
			Console.WriteLine("[Native] Path pasted + Enter sent");
			await Task.Delay(2500);
		}
		catch (Exception ex10)
		{
			ProjectData.SetProjectError(ex10);
			Exception ex11 = ex10;
			Exception ex12 = ex11;
			Console.WriteLine($"[Native] OS dialog input failed: {ex12.Message}");
			throw new Exception($"[Native] Could not enter file path in OS dialog: {ex12.Message}");
		}
		finally
		{
			try
			{
				if (!string.IsNullOrEmpty(text6))
				{
					Clipboard.SetText(text6);
				}
			}
			catch (Exception projectError14)
			{
				ProjectData.SetProjectError(projectError14);
				ProjectData.ClearProjectError();
			}
		}
		checked
		{
			if (flag2)
			{
				bool flag3 = false;
				int num2 = 1;
				do
				{
					try
					{
						ReadOnlyCollection<IWebElement> readOnlyCollection5 = ((ISearchContext)driver).FindElements(By.CssSelector("div[aria-placeholder='Add a caption'], div[aria-placeholder*='caption'], div[aria-placeholder*='Caption'], div[aria-placeholder='Type a message'], input[placeholder='Type a message']"));
						foreach (IWebElement item4 in readOnlyCollection5)
						{
							if (item4.Displayed)
							{
								flag3 = true;
								break;
							}
						}
					}
					catch (Exception projectError15)
					{
						ProjectData.SetProjectError(projectError15);
						ProjectData.ClearProjectError();
					}
					if (flag3)
					{
						break;
					}
					await Task.Delay(500);
					num2++;
				}
				while (num2 <= 6);
				if (!flag3)
				{
					ReadOnlyCollection<IWebElement> source = ((ISearchContext)driver).FindElements(By.CssSelector("div[data-animate-modal-popup='true'], div[role='dialog']"));
					if (source.Any([SpecialName] (IWebElement m) => m.Displayed))
					{
						Console.WriteLine("[Native] Modal open but NO caption box → sticker preview detected! Escaping...");
						try
						{
							IWebElement val7 = ((ISearchContext)driver).FindElement(By.TagName("body"));
							val7.SendKeys(Keys.Escape);
							await Task.Delay(600);
							ReadOnlyCollection<IWebElement> readOnlyCollection6 = ((ISearchContext)driver).FindElements(By.CssSelector("div[role='button'], button"));
							foreach (IWebElement item5 in readOnlyCollection6)
							{
								if (item5.Displayed && item5.Text.ToLower().Contains("discard"))
								{
									try
									{
										item5.Click();
									}
									catch (Exception projectError16)
									{
										ProjectData.SetProjectError(projectError16);
										val.ExecuteScript("arguments[0].click();", new object[1] { item5 });
										ProjectData.ClearProjectError();
									}
									await Task.Delay(400);
									break;
								}
							}
							val7.SendKeys(Keys.Escape);
							await Task.Delay(400);
						}
						catch (Exception projectError17)
						{
							ProjectData.SetProjectError(projectError17);
							ProjectData.ClearProjectError();
						}
						throw new Exception("[Native] Sticker preview detected. Aborting to prevent stuck UI.");
					}
				}
				Console.WriteLine($"[Native] Preview check: captionFound={flag3}");
			}
			bool flag4 = false;
			IWebElement val8 = null;
			int num3 = 1;
			do
			{
				try
				{
					ReadOnlyCollection<IWebElement> readOnlyCollection7 = ((ISearchContext)driver).FindElements(By.CssSelector("div[role='dialog'], div[data-animate-modal-popup='true']"));
					foreach (IWebElement item6 in readOnlyCollection7)
					{
						if (item6.Displayed)
						{
							flag4 = true;
							val8 = item6;
							break;
						}
					}
					if (flag4)
					{
						Console.WriteLine($"[Native] Preview modal appeared after {num3 * 500}ms");
						break;
					}
				}
				catch (Exception projectError18)
				{
					ProjectData.SetProjectError(projectError18);
					ProjectData.ClearProjectError();
				}
				await Task.Delay(500);
				num3++;
			}
			while (num3 <= 20);
			if (!flag4)
			{
				Console.WriteLine("[Native] WARNING: Preview modal did not appear. Will try Send anyway.");
			}
			IWebElement val9 = null;
			Console.WriteLine("[Native] Finding caption box...");
			int num4 = 1;
			do
			{
				try
				{
					string[] array7 = new string[5] { "div[aria-placeholder='Add a caption']", "div[aria-placeholder*='caption']", "div[aria-placeholder*='Caption']", "div[role='textbox'][contenteditable='true']", "div[contenteditable='true']" };
					string[] array8 = array7;
					foreach (string text7 in array8)
					{
						object obj = ((val8 == null) ? ((ISearchContext)driver).FindElements(By.CssSelector(text7)) : ((ISearchContext)val8).FindElements(By.CssSelector(text7)));
						foreach (object item7 in (IEnumerable)obj)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item7);
							if (Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type)null, "Displayed", new object[0], (string[])null, (Type[])null, (bool[])null))))
							{
								object obj2 = Operators.ConcatenateObject(NewLateBinding.LateGet(objectValue, (Type)null, "GetAttribute", new object[1] { "data-tab" }, (string[])null, (Type[])null, (bool[])null), (object)"");
								if (Operators.ConditionalCompareObjectNotEqual(obj2, (object)"3", false) && Operators.ConditionalCompareObjectNotEqual(obj2, (object)"1", false))
								{
									val9 = (IWebElement)objectValue;
									Console.WriteLine($"[Native] Caption box found via: {text7}");
									break;
								}
							}
						}
						if (val9 != null)
						{
							break;
						}
					}
				}
				catch (Exception projectError19)
				{
					ProjectData.SetProjectError(projectError19);
					ProjectData.ClearProjectError();
				}
				if (val9 != null)
				{
					break;
				}
				await Task.Delay(300);
				num4++;
			}
			while (num4 <= 10);
			if (val9 != null)
			{
				try
				{
					try
					{
						val9.Click();
					}
					catch (Exception projectError20)
					{
						ProjectData.SetProjectError(projectError20);
						val.ExecuteScript("arguments[0].focus();", new object[1] { val9 });
						ProjectData.ClearProjectError();
					}
					await Task.Delay(200);
					if (!string.IsNullOrEmpty(caption))
					{
						val.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { val9 });
						val.ExecuteScript("arguments[0].focus();", new object[1] { val9 });
						await Task.Delay(150);
						string text8 = caption.Replace("\r\n", "\n").Replace("\r", "\n");
						string[] array9 = text8.Split(new string[1] { "\n" }, StringSplitOptions.None);
						bool flag5 = false;
						try
						{
							int num6 = array9.Length - 1;
							for (int num7 = 0; num7 <= num6; num7++)
							{
								string text9 = array9[num7];
								if (!string.IsNullOrEmpty(text9))
								{
									val9.SendKeys(text9);
								}
								if (num7 < array9.Length - 1)
								{
									val9.SendKeys(Keys.Shift + Keys.Enter);
									await Task.Delay(50);
								}
							}
							flag5 = true;
							Console.WriteLine("[Native] Caption typed via SendKeys");
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception ex14 = ex13;
							Exception ex15 = ex14;
							Console.WriteLine($"[Native] SendKeys failed: {ex15.Message}. Trying execCommand...");
							ProjectData.ClearProjectError();
						}
						if (!flag5)
						{
							try
							{
								if (Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(val.ExecuteScript("arguments[0].focus(); return document.execCommand('insertText', false, arguments[1]);", new object[2]
								{
									val9,
									text8.Replace("\n", "\n")
								}))))
								{
									flag5 = true;
									Console.WriteLine("[Native] Caption typed via execCommand");
								}
							}
							catch (Exception projectError21)
							{
								ProjectData.SetProjectError(projectError21);
								ProjectData.ClearProjectError();
							}
						}
						if (!flag5)
						{
							try
							{
								string text10 = HttpUtility.HtmlEncode(text8).Replace("\n", "<br>");
								val.ExecuteScript("arguments[0].innerHTML = arguments[1];", new object[2] { val9, text10 });
								flag5 = true;
								Console.WriteLine("[Native] Caption set via innerHTML");
							}
							catch (Exception projectError22)
							{
								ProjectData.SetProjectError(projectError22);
								ProjectData.ClearProjectError();
							}
						}
						val.ExecuteScript("arguments[0].dispatchEvent(new Event('input', {bubbles:true}));", new object[1] { val9 });
						val.ExecuteScript("arguments[0].dispatchEvent(new Event('change', {bubbles:true}));", new object[1] { val9 });
						await Task.Delay(300);
						flag = flag5;
					}
					else
					{
						flag = true;
					}
				}
				catch (Exception ex16)
				{
					ProjectData.SetProjectError(ex16);
					Exception ex17 = ex16;
					Exception ex18 = ex17;
					Console.WriteLine($"[Native] Caption typing error: {ex18.Message}");
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Console.WriteLine("[Native] WARNING: Caption box not found. Send will go without caption.");
			}
			bool flag6 = false;
			try
			{
				if (val9 != null)
				{
					val9.SendKeys(Keys.Return);
					Console.WriteLine("[Native] Send triggered via Enter key on caption box");
					flag6 = true;
				}
			}
			catch (Exception projectError23)
			{
				ProjectData.SetProjectError(projectError23);
				ProjectData.ClearProjectError();
			}
			if (!flag6)
			{
				string[] array10 = new string[6] { "div[role='dialog'] span[data-icon='send']", "div[data-animate-modal-popup='true'] span[data-icon='send']", "span[data-icon='send']", "div[aria-label='Send']", "div[role='button'][aria-label='Send']", "span[data-icon='send-light']" };
				IWebElement val10 = null;
				int num8 = 1;
				do
				{
					string[] array11 = array10;
					foreach (string text11 in array11)
					{
						try
						{
							object obj3 = ((val8 == null) ? ((ISearchContext)driver).FindElements(By.CssSelector(text11)) : ((ISearchContext)val8).FindElements(By.CssSelector(text11)));
							if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(obj3, (Type)null, "Count", new object[0], (string[])null, (Type[])null, (bool[])null), (object)0, false))
							{
								val10 = (IWebElement)NewLateBinding.LateIndexGet(obj3, new object[1] { 0 }, (string[])null);
								Console.WriteLine($"[Native] Send button found: {text11}");
								break;
							}
						}
						catch (Exception projectError24)
						{
							ProjectData.SetProjectError(projectError24);
							ProjectData.ClearProjectError();
						}
					}
					if (val10 != null)
					{
						break;
					}
					await Task.Delay(300);
					num8++;
				}
				while (num8 <= 30);
				if (val10 == null)
				{
					Console.WriteLine("[Native] Send button NOT found in preview! Closing modal to prevent stuck UI.");
					try
					{
						IWebElement val11 = ((ISearchContext)driver).FindElement(By.TagName("body"));
						val11.SendKeys(Keys.Escape);
						await Task.Delay(300);
						val11.SendKeys(Keys.Escape);
					}
					catch (Exception projectError25)
					{
						ProjectData.SetProjectError(projectError25);
						ProjectData.ClearProjectError();
					}
					throw new Exception("[Native] Send button NOT found in preview");
				}
				try
				{
					val10.Click();
					Console.WriteLine("[Native] Send button clicked (native)");
				}
				catch (Exception projectError26)
				{
					ProjectData.SetProjectError(projectError26);
					try
					{
						val.ExecuteScript("arguments[0].click();", new object[1] { val10 });
						Console.WriteLine("[Native] Send button clicked (JS fallback)");
					}
					catch (Exception ex19)
					{
						ProjectData.SetProjectError(ex19);
						Exception ex20 = ex19;
						Exception ex21 = ex20;
						throw new Exception($"[Native] Send button click failed: {ex21.Message}");
					}
					ProjectData.ClearProjectError();
				}
				await Task.Delay(1500);
			}
			int num10 = 1;
			do
			{
				try
				{
					ReadOnlyCollection<IWebElement> readOnlyCollection8 = ((ISearchContext)driver).FindElements(By.CssSelector("div[data-animate-modal-popup='true']"));
					if (readOnlyCollection8.Count == 0)
					{
						Console.WriteLine($"[Native] Modal closed (send confirmed) after {num10 * 300}ms");
						break;
					}
				}
				catch (Exception projectError27)
				{
					ProjectData.SetProjectError(projectError27);
					ProjectData.ClearProjectError();
				}
				await Task.Delay(300);
				num10++;
			}
			while (num10 <= 10);
			Console.WriteLine($"[Native] SendFileNativeAsync DONE. CaptionSuccess: {flag}");
			return flag;
		}
	}

	private async Task<bool> SendAttachmentAsync(string filePath, string caption = null, bool isMiniMode = false)
	{
		_ = string.Empty;
		bool result = false;
		try
		{
			string text = Path.GetExtension(filePath).ToLower();
			int num;
			switch (text)
			{
			default:
				num = ((Operators.CompareString(text, ".gif", false) == 0) ? 1 : 0);
				break;
			case ".jpg":
			case ".jpeg":
			case ".png":
			case ".bmp":
				num = 1;
				break;
			}
			bool flag = (byte)num != 0;
			Console.WriteLine($"SendAttachmentAsync: Path: {filePath}, IsImage: {flag}, MiniMode: {isMiniMode}");
			IJavaScriptExecutor val = (IJavaScriptExecutor)driver;
			if (isMiniMode)
			{
				Console.WriteLine("Mini Mode: Opening attach menu via robust JS approach...");
				ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector("input[type='file']"));
				Console.WriteLine($"Pre-menu DOM scan: {readOnlyCollection.Count} file input(s) already present.");
				string text2 = "\r\n                    var sels = [\r\n                        \"button[aria-label='Attach']\",\r\n                        \"div[aria-label='Attach']\",\r\n                        \"button[title='Attach']\",\r\n                        \"div[title='Attach']\",\r\n                        \"span[data-icon='plus-rounded']\",\r\n                        \"span[data-icon='plus']\",\r\n                        \"span[data-icon='attach-menu-plus']\",\r\n                        \"span[data-icon='clip']\",\r\n                        \"[data-tab='10']\"\r\n                    ];\r\n                    function fire(el){\r\n                        if(!el) return false;\r\n                        var evt = new MouseEvent('click', {bubbles:true, cancelable:true, view:window});\r\n                        el.dispatchEvent(evt);\r\n                        try { el.click(); } catch(e) {}\r\n                        return true;\r\n                    }\r\n                    for (var i = 0; i < sels.length; i++) {\r\n                        var el = document.querySelector(sels[i]);\r\n                        if (el) {\r\n                            var btn = el.closest('button') || el.closest(\"div[role='button']\") || el;\r\n                            fire(btn);\r\n                            return sels[i];\r\n                        }\r\n                    }\r\n                    return null;";
				try
				{
					object objectValue = RuntimeHelpers.GetObjectValue(val.ExecuteScript(text2, new object[0]));
					if (objectValue != null)
					{
						Console.WriteLine($"Attach button clicked via JS selector: {RuntimeHelpers.GetObjectValue(objectValue)}");
					}
					else
					{
						Console.WriteLine("WARNING: No attach button selector matched the DOM.");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Exception ex3 = ex2;
					Console.WriteLine($"Attach button JS click error: {ex3.Message}");
					ProjectData.ClearProjectError();
				}
				await Task.Delay(1200);
				string text3 = "\r\n                    var menuRoots = document.querySelectorAll(\"div[role='application'], ul[aria-label], div[data-animate-attach-bubble], div[data-animate-popover='true']\");\r\n                    for (var i = 0; i < menuRoots.length; i++) {\r\n                        var t = (menuRoots[i].innerText || '').toLowerCase();\r\n                        if (t.indexOf('photo') > -1 || t.indexOf('document') > -1 || t.indexOf('camera') > -1) return true;\r\n                    }\r\n                    return false;";
				bool flag2 = false;
				try
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(val.ExecuteScript(text3, new object[0]));
					if (objectValue2 != null)
					{
						flag2 = Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(objectValue2));
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				Console.WriteLine($"Attach menu open verification: {flag2}");
				Console.WriteLine("Skipping submenu click to avoid opening Windows OS file dialog.");
				await Task.Delay(400);
				val.ExecuteScript("\r\n                    var inputs = document.querySelectorAll('input[type=\\'file\\']');\r\n                    for (var i = 0; i < inputs.length; i++) {\r\n                        inputs[i].style.display = 'block';\r\n                        inputs[i].style.opacity = '0';\r\n                        inputs[i].style.position = 'absolute';\r\n                        inputs[i].style.left = '-9999px';\r\n                        inputs[i].removeAttribute('disabled');\r\n                    }\r\n                ", new object[0]);
				await Task.Delay(300);
				ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector("input[type='file']"));
				Console.WriteLine($"Post-menu DOM scan: {readOnlyCollection2.Count} file input(s) available.");
				foreach (IWebElement item in readOnlyCollection2)
				{
					Console.WriteLine(string.Format("  -> Available input accept: [{0}]", item.GetAttribute("accept")));
				}
			}
			else
			{
				IWebElement val2 = null;
				string[] array = new string[6] { "button[aria-label='Attach']", "div[aria-label='Attach']", "span[data-icon='plus-rounded']", "span[data-icon='plus']", "div[title='Attach']", "span[data-icon='attach-menu-plus']" };
				string[] array2 = array;
				foreach (string text4 in array2)
				{
					try
					{
						val2 = ((ISearchContext)driver).FindElement(By.CssSelector(text4));
						if (val2.Displayed)
						{
							break;
						}
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
				}
				if (val2 == null)
				{
					throw new Exception("Attach button not found");
				}
				val.ExecuteScript("arguments[0].click();", new object[1] { val2 });
				Console.WriteLine("Attach button clicked via JavaScript");
				await Task.Delay(800);
			}
			Console.WriteLine("Skipping Document menu click. Will use hidden file input approach for PDFs.");
			IWebElement val3 = null;
			ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)driver).FindElements(By.CssSelector("input[type='file']"));
			Console.WriteLine($"Found {readOnlyCollection3.Count} file inputs.");
			foreach (IWebElement item2 in readOnlyCollection3)
			{
				Console.WriteLine(string.Format("Input Accept: {0}", item2.GetAttribute("accept")));
			}
			checked
			{
				if (flag)
				{
					foreach (IWebElement item3 in readOnlyCollection3)
					{
						string text5 = item3.GetAttribute("accept") ?? "";
						if (text5.Contains("image") && text5.Contains("video"))
						{
							val3 = item3;
							Console.WriteLine("Selected: Photos & Videos input (image+video)");
							break;
						}
					}
					if (val3 == null)
					{
						foreach (IWebElement item4 in readOnlyCollection3)
						{
							string text6 = item4.GetAttribute("accept") ?? "";
							string attribute = item4.GetAttribute("multiple");
							if (text6.Contains("image") && attribute != null)
							{
								val3 = item4;
								Console.WriteLine("Selected: input with image accept AND multiple attribute");
								break;
							}
						}
					}
					if (val3 == null)
					{
						foreach (IWebElement item5 in readOnlyCollection3)
						{
							string text7 = item5.GetAttribute("accept") ?? "";
							if (text7.Contains("image") && !text7.Contains("webp"))
							{
								val3 = item5;
								Console.WriteLine("Selected: input with image accept (not sticker)");
								break;
							}
						}
					}
					if (val3 == null)
					{
						foreach (IWebElement item6 in readOnlyCollection3)
						{
							string text8 = item6.GetAttribute("accept") ?? "";
							if (text8.Contains("image"))
							{
								val3 = item6;
								break;
							}
						}
					}
					if (val3 == null && readOnlyCollection3.Count > 0)
					{
						val3 = readOnlyCollection3[0];
					}
				}
				else
				{
					Console.WriteLine("Looking for Document input for PDF...");
					foreach (IWebElement item7 in readOnlyCollection3)
					{
						string text9 = item7.GetAttribute("accept") ?? "";
						Console.WriteLine($"Checking input accept: [{text9}]");
						if (Operators.CompareString(text9, "*", false) == 0)
						{
							val3 = item7;
							Console.WriteLine("Found Document input with accept='*'");
							break;
						}
					}
					if (val3 == null)
					{
						foreach (IWebElement item8 in readOnlyCollection3)
						{
							string text10 = item8.GetAttribute("accept") ?? "";
							if (!text10.Contains("image") && !text10.Contains("video"))
							{
								val3 = item8;
								Console.WriteLine($"Found non-image input with accept: [{text10}]");
								break;
							}
						}
					}
					if (val3 == null && readOnlyCollection3.Count > 0)
					{
						val3 = readOnlyCollection3[readOnlyCollection3.Count - 1];
						Console.WriteLine(string.Format("Fallback: Using last input. Accept: [{0}]", val3.GetAttribute("accept")));
					}
				}
				if (val3 == null)
				{
					throw new Exception("Suitable File Input not found");
				}
				int num2 = 0;
				bool flag3 = false;
				while (!flag3 && num2 < 3)
				{
					try
					{
						IJavaScriptExecutor val4 = (IJavaScriptExecutor)driver;
						val4.ExecuteScript("arguments[0].focus();", new object[1] { val3 });
						await Task.Delay(200);
						Console.WriteLine($"Attempt {num2 + 1}: Sending file path to input: {filePath}");
						val3.SendKeys(filePath);
						flag3 = true;
						Console.WriteLine("File path sent successfully");
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception ex5 = ex4;
						Exception ex6 = ex5;
						num2++;
						Console.WriteLine($"SendKeys attempt {num2} failed: {ex6.Message}");
						ProjectData.ClearProjectError();
					}
					if (!flag3 && num2 < 3)
					{
						await Task.Delay(500);
					}
				}
				if (!flag3)
				{
					throw new Exception("Failed to send file path to file input after 3 attempts");
				}
				await Task.Delay(2000);
				try
				{
					((DefaultWait<IWebDriver>)(object)wait).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) => ((ISearchContext)d).FindElements(By.CssSelector("div[role='dialog'], div[data-animate-modal-popup='true']")).Count > 0));
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					Console.WriteLine("Warning: Preview wait timed out. Checking if Send button exists anyway...");
					ProjectData.ClearProjectError();
				}
				IWebElement val5 = null;
				Console.WriteLine("Applying caption...");
				try
				{
					IWebElement val6 = null;
					try
					{
						WebDriverWait val7 = new WebDriverWait(driver, TimeSpan.FromSeconds(5.0));
						val6 = ((DefaultWait<IWebDriver>)(object)val7).Until<IWebElement>((Func<IWebDriver, IWebElement>)([SpecialName] (IWebDriver d) =>
						{
							ReadOnlyCollection<IWebElement> readOnlyCollection6 = ((ISearchContext)d).FindElements(By.CssSelector("div[role='dialog'], div[data-animate-modal-popup='true']"));
							return (readOnlyCollection6.Count > 0) ? readOnlyCollection6[0] : null;
						}));
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						Console.WriteLine("Preview Modal not found.");
						ProjectData.ClearProjectError();
					}
					if (val6 != null)
					{
						try
						{
							ReadOnlyCollection<IWebElement> readOnlyCollection4 = ((ISearchContext)val6).FindElements(By.CssSelector("div[contenteditable='true']"));
							if (readOnlyCollection4.Count > 0)
							{
								val5 = readOnlyCollection4[0];
							}
							else
							{
								ReadOnlyCollection<IWebElement> readOnlyCollection5 = ((ISearchContext)val6).FindElements(By.CssSelector("footer div[contenteditable='true']"));
								if (readOnlyCollection5.Count > 0)
								{
									val5 = readOnlyCollection5[0];
								}
							}
						}
						catch (Exception projectError5)
						{
							ProjectData.SetProjectError(projectError5);
							ProjectData.ClearProjectError();
						}
					}
					if (val5 != null)
					{
						try
						{
							Console.WriteLine("Caption box found inside modal! Attempting to type...");
							IJavaScriptExecutor val8 = (IJavaScriptExecutor)driver;
							val8.ExecuteScript("arguments[0].focus();", new object[1] { val5 });
							val8.ExecuteScript("arguments[0].click();", new object[1] { val5 });
							await Task.Delay(300);
							if (!string.IsNullOrEmpty(caption))
							{
								val8.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { val5 });
								Console.WriteLine($"Typing PDF caption: {caption}");
								string text11 = caption.Replace("\r\n", "\n").Replace("\r", "\n");
								string[] array3 = text11.Split(new string[1] { "\n" }, StringSplitOptions.None);
								try
								{
									int num3 = array3.Length - 1;
									for (int num4 = 0; num4 <= num3; num4++)
									{
										string text12 = array3[num4];
										if (!string.IsNullOrEmpty(text12))
										{
											val5.SendKeys(text12);
										}
										if (num4 < array3.Length - 1)
										{
											val5.SendKeys(Keys.Shift + Keys.Enter);
											await Task.Delay(50);
										}
									}
								}
								catch (Exception projectError6)
								{
									ProjectData.SetProjectError(projectError6);
									string text13 = HttpUtility.HtmlEncode(text11);
									text13 = text13.Replace("\n", "<br>");
									val8.ExecuteScript("arguments[0].innerHTML = arguments[1];", new object[2] { val5, text13 });
									ProjectData.ClearProjectError();
								}
								val8.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { val5 });
								await Task.Delay(500);
							}
							result = true;
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							Exception ex9 = ex8;
							Console.WriteLine($"Error typing PDF caption: {ex9.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						Console.WriteLine("Caption box NOT found in modal.");
					}
				}
				catch (Exception ex10)
				{
					ProjectData.SetProjectError(ex10);
					Exception ex11 = ex10;
					Exception ex12 = ex11;
					Console.WriteLine($"Caption logic error: {ex12.Message}");
					ProjectData.ClearProjectError();
				}
				await Task.Delay(300);
				bool flag4 = false;
				if (!flag4)
				{
					try
					{
						if (val5 != null)
						{
							val5.SendKeys(Keys.Return);
							Console.WriteLine("PDF Send triggered via Enter key on caption box");
							flag4 = true;
						}
					}
					catch (Exception ex13)
					{
						ProjectData.SetProjectError(ex13);
						Exception ex14 = ex13;
						Exception ex15 = ex14;
						Console.WriteLine($"PDF Method A (SendKeys Enter) failed: {ex15.Message}");
						ProjectData.ClearProjectError();
					}
				}
				if (!flag4)
				{
					try
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(val.ExecuteScript("\r\n                        var sels = [\r\n                            \"div[role='dialog'] span[data-icon='send']\",\r\n                            \"div[data-animate-modal-popup='true'] span[data-icon='send']\",\r\n                            \"span[data-icon='send']\",\r\n                            \"div[role='button'][aria-label='Send']\",\r\n                            \"div[aria-label='Send']\",\r\n                            \"button[aria-label='Send']\",\r\n                            \"span[data-icon='send-light']\"\r\n                        ];\r\n                        for (var i = 0; i < sels.length; i++) {\r\n                            var el = document.querySelector(sels[i]);\r\n                            if (el) {\r\n                                el.dispatchEvent(new MouseEvent('mousedown', {bubbles:true, cancelable:true, view:window}));\r\n                                el.dispatchEvent(new MouseEvent('mouseup',   {bubbles:true, cancelable:true, view:window}));\r\n                                el.dispatchEvent(new MouseEvent('click',     {bubbles:true, cancelable:true, view:window}));\r\n                                try { el.click(); } catch(e) {}\r\n                                return 'clicked:' + sels[i];\r\n                            }\r\n                        }\r\n                        return null;\r\n                    ", new object[0]));
						if (objectValue3 != null)
						{
							Console.WriteLine($"PDF Send button clicked via pure JS: {RuntimeHelpers.GetObjectValue(objectValue3)}");
							flag4 = true;
						}
						else
						{
							Console.WriteLine("WARNING: PDF Send button not found via JS querySelector");
						}
					}
					catch (Exception ex16)
					{
						ProjectData.SetProjectError(ex16);
						Exception ex17 = ex16;
						Exception ex18 = ex17;
						Console.WriteLine($"PDF Method B (JS querySelector) failed: {ex18.Message}");
						ProjectData.ClearProjectError();
					}
				}
				if (!flag4)
				{
					try
					{
						IWebElement val9 = ((ISearchContext)driver).FindElement(By.TagName("body"));
						val9.SendKeys(Keys.Return);
						Console.WriteLine("PDF Send triggered via Enter on body (last resort)");
					}
					catch (Exception projectError7)
					{
						ProjectData.SetProjectError(projectError7);
						ProjectData.ClearProjectError();
					}
				}
				Console.WriteLine("Waiting for PDF to be sent...");
				await Task.Delay(500);
				try
				{
					int num5 = 1;
					do
					{
						if (((ISearchContext)driver).FindElements(By.CssSelector("span[data-icon='send']")).Count <= 0)
						{
							Console.WriteLine("PDF sent successfully - preview closed");
							break;
						}
						await Task.Delay(300);
						num5++;
					}
					while (num5 <= 6);
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					ProjectData.ClearProjectError();
				}
				await Task.Delay(1000);
				return result;
			}
		}
		catch (Exception ex19)
		{
			ProjectData.SetProjectError(ex19);
			Exception ex20 = ex19;
			Exception ex21 = ex20;
			Console.WriteLine($"Attachment via Input failed: {ex21.Message}");
			_ = ex21.Message;
			bool result2 = false;
			ProjectData.ClearProjectError();
			return result2;
		}
	}

	private void SetClipboardFile(string filePath)
	{
		Thread thread = new Thread([SpecialName] () =>
		{
			try
			{
				Clipboard.Clear();
				Thread.Sleep(50);
				Clipboard.SetFileDropList(new StringCollection { filePath });
				Console.WriteLine($"Clipboard File Set: {filePath}");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Console.WriteLine($"Clipboard File Error: {ex2.Message}");
				ProjectData.ClearProjectError();
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		Thread.Sleep(100);
	}

	private async Task<bool> SendDocumentViaClipboardAsync(string filePath, string caption)
	{
		bool result = false;
		checked
		{
			try
			{
				_Closure_0024__75_002D1 closure_0024__75_002D = new _Closure_0024__75_002D1(closure_0024__75_002D);
				Console.WriteLine($"SendDocumentViaClipboardAsync: Starting for: {filePath}");
				ClearClipboard();
				await Task.Delay(200);
				IWebElement val = null;
				int num = 120;
				int num2 = 0;
				while (val == null && num2 < num)
				{
					num2++;
					string[] array = new string[2] { "#main footer div[contenteditable='true'][role='textbox']", "#main footer div[contenteditable='true']" };
					string[] array2 = array;
					foreach (string text in array2)
					{
						try
						{
							ReadOnlyCollection<IWebElement> readOnlyCollection = ((ISearchContext)driver).FindElements(By.CssSelector(text));
							if (readOnlyCollection.Count > 0 && readOnlyCollection[0].Displayed)
							{
								string text2 = readOnlyCollection[0].GetAttribute("data-tab") ?? "";
								if (Operators.CompareString(text2, "3", false) != 0)
								{
									val = readOnlyCollection[0];
									break;
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					if (val == null)
					{
						await Task.Delay(500);
					}
				}
				if (val == null)
				{
					throw new Exception("Message box not found for pasting");
				}
				IJavaScriptExecutor val2 = (IJavaScriptExecutor)driver;
				val2.ExecuteScript("arguments[0].focus();", new object[1] { val });
				val2.ExecuteScript("arguments[0].click();", new object[1] { val });
				await Task.Delay(200);
				SetClipboardFile(filePath);
				await Task.Delay(200);
				Console.WriteLine("Pasting file (Ctrl+V)...");
				val.SendKeys(Keys.Control + "v");
				await Task.Delay(1000);
				try
				{
					WebDriverWait val3 = new WebDriverWait(driver, TimeSpan.FromSeconds(3.0));
					((DefaultWait<IWebDriver>)(object)val3).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) => ((ISearchContext)d).FindElements(By.CssSelector("div[data-animate-modal-popup='true']")).Count > 0));
					Console.WriteLine("Preview Modal Appeared.");
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					Console.WriteLine("Warning: Modal did not appear after paste.");
					ProjectData.ClearProjectError();
				}
				closure_0024__75_002D._0024VB_0024Local_captionBox = null;
				Console.WriteLine("Finding caption box...");
				try
				{
					_Closure_0024__75_002D0 arg = default(_Closure_0024__75_002D0);
					_Closure_0024__75_002D0 CS_0024_003C_003E8__locals12 = new _Closure_0024__75_002D0(arg);
					CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2 = closure_0024__75_002D;
					CS_0024_003C_003E8__locals12._0024VB_0024Local_captionSelectors = new string[5] { "div[aria-placeholder='Add a caption']", "div[data-animate-modal-popup='true'] div[role='textbox'][contenteditable='true']", "div[data-animate-modal-popup='true'] div[contenteditable='true']", "div[data-animate-modal-popup='true'] span[data-icon='emoji-input'] + div div[contenteditable='true']", "div[role='textbox'][contenteditable='true']" };
					WebDriverWait val4 = new WebDriverWait(driver, TimeSpan.FromSeconds(2.0));
					try
					{
						((DefaultWait<IWebDriver>)(object)val4).Until<bool>((Func<IWebDriver, bool>)([SpecialName] (IWebDriver d) =>
						{
							string[] array6 = CS_0024_003C_003E8__locals12._0024VB_0024Local_captionSelectors;
							foreach (string text7 in array6)
							{
								ReadOnlyCollection<IWebElement> readOnlyCollection3 = ((ISearchContext)d).FindElements(By.CssSelector(text7));
								foreach (IWebElement item in readOnlyCollection3)
								{
									if (item.Displayed && item.Enabled)
									{
										CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox = item;
										return true;
									}
								}
							}
							return false;
						}));
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						Console.WriteLine("Timed out waiting for specific caption box.");
						ProjectData.ClearProjectError();
					}
					if (CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox != null)
					{
						try
						{
							val2.ExecuteScript("arguments[0].focus();", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
							val2.ExecuteScript("arguments[0].click();", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
							await Task.Delay(300);
							if (!string.IsNullOrEmpty(caption))
							{
								val2.ExecuteScript("arguments[0].innerHTML = '';", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
								Console.WriteLine($"Typing caption: {caption}");
								string text3 = caption.Replace("\r\n", "\n").Replace("\r", "\n");
								string[] array3 = text3.Split(new string[1] { "\n" }, StringSplitOptions.None);
								try
								{
									int num3 = array3.Length - 1;
									for (int num4 = 0; num4 <= num3; num4++)
									{
										string text4 = array3[num4];
										if (!string.IsNullOrEmpty(text4))
										{
											CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox.SendKeys(text4);
										}
										if (num4 < array3.Length - 1)
										{
											CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox.SendKeys(Keys.Shift + Keys.Enter);
											await Task.Delay(50);
										}
									}
								}
								catch (Exception projectError4)
								{
									ProjectData.SetProjectError(projectError4);
									string text5 = HttpUtility.HtmlEncode(text3);
									text5 = text5.Replace("\n", "<br>");
									val2.ExecuteScript("arguments[0].innerHTML = arguments[1];", new object[2]
									{
										CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox,
										text5
									});
									ProjectData.ClearProjectError();
								}
								val2.ExecuteScript("arguments[0].dispatchEvent(new Event('input', { bubbles: true }));", new object[1] { CS_0024_003C_003E8__locals12._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_captionBox });
								await Task.Delay(200);
							}
							result = true;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							Exception ex3 = ex2;
							Console.WriteLine($"Error typing caption: {ex3.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						Console.WriteLine("Caption box not found after retries");
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception ex5 = ex4;
					Exception ex6 = ex5;
					Console.WriteLine($"Caption error: {ex6.Message}");
					ProjectData.ClearProjectError();
				}
				await Task.Delay(300);
				bool flag = false;
				if (!flag)
				{
					try
					{
						if (closure_0024__75_002D._0024VB_0024Local_captionBox != null)
						{
							closure_0024__75_002D._0024VB_0024Local_captionBox.SendKeys(Keys.Return);
							Console.WriteLine("Document Send triggered via Enter key on caption box");
							flag = true;
						}
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						ProjectData.ClearProjectError();
					}
				}
				if (!flag)
				{
					string[] array4 = new string[7] { "div[role='dialog'] span[data-icon='send']", "div[data-animate-modal-popup='true'] span[data-icon='send']", "div[role='dialog'] div[aria-label='Send']", "span[data-icon='send']", "div[aria-label='Send']", "div[role='button'][aria-label='Send']", "span[data-icon='send-light']" };
					IWebElement val5 = null;
					int num5 = 1;
					do
					{
						string[] array5 = array4;
						foreach (string text6 in array5)
						{
							try
							{
								ReadOnlyCollection<IWebElement> readOnlyCollection2 = ((ISearchContext)driver).FindElements(By.CssSelector(text6));
								if (readOnlyCollection2.Count > 0)
								{
									val5 = readOnlyCollection2[0];
									break;
								}
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								ProjectData.ClearProjectError();
							}
							if (val5 != null)
							{
								break;
							}
						}
						if (val5 != null)
						{
							break;
						}
						await Task.Delay(400);
						num5++;
					}
					while (num5 <= 10);
					if (val5 != null)
					{
						try
						{
							val2.ExecuteScript("\r\n                            arguments[0].dispatchEvent(new MouseEvent('mousedown', {bubbles:true, cancelable:true}));\r\n                            arguments[0].dispatchEvent(new MouseEvent('mouseup',   {bubbles:true, cancelable:true}));\r\n                            arguments[0].dispatchEvent(new MouseEvent('click',     {bubbles:true, cancelable:true}));\r\n                            try { arguments[0].click(); } catch(e) {}\r\n                        ", new object[1] { val5 });
							Console.WriteLine("Document Send button clicked via MouseEvent dispatch");
							flag = true;
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							Exception ex9 = ex8;
							Console.WriteLine($"MouseEvent send failed: {ex9.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						Console.WriteLine("WARNING: Document Send button not found after retries");
					}
				}
				if (!flag)
				{
					try
					{
						IWebElement val6 = ((ISearchContext)driver).FindElement(By.TagName("body"));
						val6.SendKeys(Keys.Return);
						Console.WriteLine("Document Send triggered via Enter on body (last resort)");
					}
					catch (Exception projectError7)
					{
						ProjectData.SetProjectError(projectError7);
						ProjectData.ClearProjectError();
					}
				}
				Console.WriteLine("Waiting for document to be sent...");
				await Task.Delay(500);
				try
				{
					int num7 = 1;
					do
					{
						if (((ISearchContext)driver).FindElements(By.CssSelector("span[data-icon='send']")).Count <= 0)
						{
							Console.WriteLine("Document sent successfully - preview closed");
							break;
						}
						await Task.Delay(300);
						num7++;
					}
					while (num7 <= 6);
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					ProjectData.ClearProjectError();
				}
				ClearClipboard();
				return result;
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception ex11 = ex10;
				Exception ex12 = ex11;
				Console.WriteLine($"SendDocumentViaClipboardAsync Error: {ex12.Message}");
				ClearClipboard();
				throw;
			}
		}
	}

	public async Task LogoutAsync()
	{
		try
		{
			if (driver != null)
			{
				try
				{
					driver.Manage().Window.Maximize();
					await Task.Delay(500);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				IWebElement val = ((DefaultWait<IWebDriver>)(object)wait).Until<IWebElement>((Func<IWebDriver, IWebElement>)([SpecialName] (IWebDriver d) => ((ISearchContext)d).FindElement(By.CssSelector("div[title='Menu']"))));
				val.Click();
				await Task.Delay(1000);
				IWebElement val2 = ((DefaultWait<IWebDriver>)(object)wait).Until<IWebElement>((Func<IWebDriver, IWebElement>)([SpecialName] (IWebDriver d) => ((ISearchContext)d).FindElement(By.XPath("//div[text()='Log out']"))));
				val2.Click();
				await Task.Delay(2000);
				CurrentState = WhatsAppState.WaitingForQR;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			throw new Exception($"Logout મ\u0abe\u0a82 error: {ex3.Message}");
		}
	}

	private void CaptureScreenshot(string name)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
			string text = Path.Combine(Application.StartupPath, "DebugScreenshots");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string path = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
			screenshot.SaveAsFile(Path.Combine(text, path));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
