﻿namespace FluentValidation.Resources {
	using System;
	using System.Globalization;

	/// <summary>
	/// IStringSource implementation that uses the default language manager.
	/// </summary>
	public class LanguageStringSource : IStringSource {

		private readonly string _key;

		public LanguageStringSource(string key) {
			_key = key;
		}

		public string GetString(object context) {
			return ValidatorOptions.LanguageManager.GetString(_key, CultureInfo.CurrentUICulture);
		}

		public string ResourceName => _key;

		// For backwards compatibility with < 7
		public Type ResourceType
		{
			get
			{
#pragma warning disable 618

				if (ValidatorOptions.ResourceProviderType != null) {
					return ValidatorOptions.ResourceProviderType;
				}
#pragma warning restore 618
				return typeof(LanguageManager);
			}
		}
	}
}