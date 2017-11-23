using BaseApp.Infrastructure.Constants;
using BaseApp.Infrastructure.Enums;
using BaseApp.Infrastructure.Services.UserService;
using BaseApp.Models.Core;
using BaseApp.Service.Core;
using BaseApp.Service.Interface;
using System.Threading.Tasks;

namespace BaseApp.Service.Services
{
    public class ServiceBase : IServiceBase
    {
        private readonly string serviceName;
        private readonly int retriesNumber;
        private ISettingsUser SettingsUser;

        public ServiceBase(string _serviceName, ISettingsUser settingsUser)
        {
            serviceName = _serviceName;
            retriesNumber = BaseAppConstants.RetriesNumber;
            SettingsUser = settingsUser;
        }

        public string ServiceName => serviceName;
        public int RetriesNumber => retriesNumber;
        public string Token => SettingsUser.Token;
    }
}
