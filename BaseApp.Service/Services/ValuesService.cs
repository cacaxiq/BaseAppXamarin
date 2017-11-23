using System.Threading.Tasks;
using BaseApp.Infrastructure.Services.UserService;
using BaseApp.Models.Business;
using BaseApp.Service.Core;
using BaseApp.Service.Interface;
using BaseApp.Infrastructure.Enums;

namespace BaseApp.Service.Services
{
    public class ValuesService : ServiceBase, IValuesService
    {
        public ValuesService(ISettingsUser settingsUser) : base(_serviceName: "posts", settingsUser: settingsUser)
        {

        }

        public Task<RespostaPadrão<string>> Teste(int id)
        {
            return WebServiceBase<string, object>.RequestAsync(service: $"{ServiceName}/{id}", token: Token, triesNumber: RetriesNumber, requestType: RequestType.Get);
        }
    }
}
