using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

public class Translator
{
	private static Dictionary<string, string> _languageModeMap;

	public TimeSpan TranslationTime { get; set; }

	public string TranslationSpeechUrl { get; set; }

	public Exception Error { get; set; }

	public static IEnumerable<string> Languages
	{
		get
		{
			EnsureInitialized();
			return _languageModeMap.Keys.OrderBy([SpecialName] (string p) => p);
		}
	}

	public string Translate(string sourceText, string sourceLanguage, string targetLanguage)
	{
		Error = null;
		TranslationSpeechUrl = null;
		TranslationTime = TimeSpan.Zero;
		DateTime now = DateTime.Now;
		string text = string.Empty;
		checked
		{
			try
			{
				string address = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={LanguageEnumToIdentifier(sourceLanguage)}&tl={LanguageEnumToIdentifier(targetLanguage)}&dt=t&q={HttpUtility.UrlEncode(sourceText)}";
				string tempFileName = Path.GetTempFileName();
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
					webClient.DownloadFile(address, tempFileName);
				}
				if (File.Exists(tempFileName))
				{
					string text2 = File.ReadAllText(tempFileName);
					int num = text2.IndexOf($",,\"{LanguageEnumToIdentifier(sourceLanguage)}\"");
					if (num == -1)
					{
						int num2 = text2.IndexOf('"');
						if (num2 != -1)
						{
							int num3 = text2.IndexOf('"', num2 + 1);
							if (num3 != -1)
							{
								text = text2.Substring(num2 + 1, num3 - num2 - 1);
							}
						}
					}
					else
					{
						text2 = text2.Substring(0, num);
						text2 = text2.Replace("],[", ",");
						text2 = text2.Replace("]", string.Empty);
						text2 = text2.Replace("[", string.Empty);
						text2 = text2.Replace("\",\"", "\"");
						string[] array = text2.Split(new char[1] { '"' }, StringSplitOptions.RemoveEmptyEntries);
						int num4 = 0;
						while (num4 < array.Count())
						{
							string text3 = array[num4];
							if (text3.StartsWith(",,"))
							{
								num4--;
								continue;
							}
							text = text + text3 + "  ";
							num4 += 2;
						}
					}
					text = text.Trim();
					text = text.Replace(" ?", "?");
					text = text.Replace(" !", "!");
					text = text.Replace(" ,", ",");
					text = text.Replace(" .", ".");
					text = text.Replace(" ;", ";");
					TranslationSpeechUrl = $"https://translate.googleapis.com/translate_tts?ie=UTF-8&q={HttpUtility.UrlEncode(text)}&tl={LanguageEnumToIdentifier(targetLanguage)}&total=1&idx=0&textlen={text.Length}&client=gtx";
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception error = ex;
				Error = error;
				ProjectData.ClearProjectError();
			}
			TranslationTime = DateTime.Now - now;
			return text;
		}
	}

	private static string LanguageEnumToIdentifier(string language)
	{
		string value = string.Empty;
		EnsureInitialized();
		_languageModeMap.TryGetValue(language, out value);
		return value;
	}

	private static void EnsureInitialized()
	{
		if (_languageModeMap == null)
		{
			_languageModeMap = new Dictionary<string, string>();
			_languageModeMap.Add("Bengali", "bn");
			_languageModeMap.Add("Chinese", "zh-CN");
			_languageModeMap.Add("English", "en");
			_languageModeMap.Add("French", "fr");
			_languageModeMap.Add("Gujarati", "gu");
			_languageModeMap.Add("Hindi", "hi");
			_languageModeMap.Add("Tamil", "ta");
			_languageModeMap.Add("Telugu", "te");
			_languageModeMap.Add("Urdu", "ur");
		}
	}
}
