using BaseApp.Models.Interfaces.Authorization;
using Plugin.Settings.Abstractions;
using BaseApp.Infrastructure.Constants;

namespace BaseApp.Models.Authorization
{
    public class TokenConfiguration :  IToken
    {
        private readonly ISettings AppSettings;

        public TokenConfiguration(ISettings _appSettings)
        {
            AppSettings = _appSettings;
        }

        public string Token => AppSettings.GetValueOrDefault(BaseAppConstants.TokenKey, string.Empty);
    }
}
