using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SSUP.Components.Managers
{
	public class StringManager
	{
		#region ----------------SINGLETON----------------

		public static readonly StringManager Instance = new();

		/// <summary>
		/// Private constructor for singleton pattern
		/// </summary>
		private StringManager()
		{
		}

		#endregion

		public CultureInfo CurrentCulture { get; set; } = new CultureInfo("fr-FR");
		public string CurrentCode { get; set; } = "fr-FR";

		/// <summary>
		/// Gets a string from the common resource file.
		/// </summary>
		/// <param name="key">The key.of the desired string.</param>
		/// <returns>The string corresponding to the key provided.</returns>
		public string? GetString(string key)
		{
			try
			{
				return Application.Current.FindResource(key).ToString();
			}
			catch 
			{
				return string.Empty;
			}
		}

		public void SetCulture(string cultureId)
		{
			try
			{
				ResourceDictionary? langOld = Application.Current.Resources.MergedDictionaries
													.Where(p => p.Source != null)
													.SingleOrDefault(p => p.Source.OriginalString.Contains("Strings."));

				ResourceDictionary dict = [];
				dict.Source = new Uri($"pack://application:,,,/MahApps.Metro.Demo;component/Resources/XAML/Languages/Strings.{cultureId}.xaml", UriKind.Absolute);

				Application.Current.Resources.BeginInit();
				if (langOld != null)
				{
					Application.Current.Resources.MergedDictionaries.Remove(langOld);
				}

				Application.Current.Resources.MergedDictionaries.Add(dict);

				Application.Current.Resources.EndInit();

				CurrentCode = cultureId;
			}
			catch 
			{
				throw;
			}

			try
			{
				CurrentCulture = new CultureInfo(cultureId);
				//CurrentCulture.DateTimeFormat.ShortDatePattern = Instance.GetString("Formats.ShortDatePattern");
				//CurrentCulture.DateTimeFormat.ShortTimePattern = Instance.GetString("Formats.ShortTimePattern");
				//CurrentCulture.DateTimeFormat.FullDateTimePattern = Instance.GetString("Formats.DateTimePattern");

				Thread.CurrentThread.CurrentCulture = CurrentCulture;
				Thread.CurrentThread.CurrentUICulture = CurrentCulture;

			}
			catch (Exception)
			{
				//set default culture
				CurrentCulture = new CultureInfo("fr-FR");
				Thread.CurrentThread.CurrentCulture = CurrentCulture;
				Thread.CurrentThread.CurrentUICulture = CurrentCulture;
			}
		}
	}
}
