using BaseApp.Infrastructure.Enums;
using BaseApp.Infrastructure.Services.UserService;
using BaseApp.Models.Authorization;
using BaseApp.Service.Core;
using BaseApp.Service.Interface;
using System.Threading.Tasks;

namespace BaseApp.Service.Services
{
    public class AccessControlService : ServiceBase, IAccessControlService
    {
        public AccessControlService() : base(_serviceName: "AccessControl", settingsUser: new SettingsUser())
        {

        }

        public Task<RespostaPadrão<Token>> GetUserToken(User user)
        {
            return WebServiceBase<Token, User>.RequestAsync(service: ServiceName, token: Token, triesNumber: RetriesNumber, requestType: RequestType.Post, SendObject: user);
        }
    }
}