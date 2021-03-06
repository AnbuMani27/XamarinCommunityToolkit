﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.Sample.Models;
using Xamarin.CommunityToolkit.Sample.Resx;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Sample.ViewModels
{
	public class SettingViewModel : BaseViewModel
	{
		public SettingViewModel() => LoadLanguages();

		IList<Language> supportedLanguages;

		public IList<Language> SupportedLanguages
		{
			get => supportedLanguages;
			private set => Set(ref supportedLanguages, value);
		}

		Language selectedLanguage;

		public Language SelectedLanguage
		{
			get => selectedLanguage;
			set => Set(ref selectedLanguage, value);
		}

		ICommand changeLanguageCommand;

		public ICommand ChangeLanguageCommand => changeLanguageCommand ??= new Command(() =>
		{
			LocalizationResourceManager.Current.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));
			LoadLanguages();
		});

		void LoadLanguages()
		{
			SupportedLanguages = new List<Language>()
			{
				{ new Language(AppResources.English, "en") },
				{ new Language(AppResources.Spanish, "es") }
			};
			SelectedLanguage = SupportedLanguages.FirstOrDefault(pro => pro.CI == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
		}
	}
}