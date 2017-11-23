using BaseApp.Infrastructure.Constants;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BaseApp.Infrastructure.Services.UserService
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string TokenKey = BaseAppConstants.TokenKey;
        private static readonly string TokenDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(TokenKey, TokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TokenKey, value);
            }
        }
    }
}
