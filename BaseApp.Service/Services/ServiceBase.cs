
using BaseApp.Infrastructure.Enums;
using BaseApp.Models.Core;
using BaseApp.Models.Interfaces.Authorization;
using BaseApp.Service.Core;
using BaseApp.Service.Interface;
using System.Threading.Tasks;

namespace BaseApp.Service.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : ModelBase, new()
    {
        private readonly IToken token;
        private readonly string serviceName;
        private readonly int triesNumber = 3;

        public ServiceBase(string _serviceName, IToken _token)
        {
            serviceName = _serviceName;
            token = _token;
        }

        public Task<RespostaPadrão> GetItemAsync(int id)
        {
            return WebServiceBase<T>.RequestAsync($"{serviceName}/{id}", token.Token, triesNumber);
        }

        public Task<RespostaPadrão> GetItemsAsync()
        {
            return WebServiceBase<T>.RequestAsync(serviceName, token.Token, triesNumber);
        }

        public Task<RespostaPadrão> SaveItemAsync(T item)
        {
            return WebServiceBase<T>.RequestAsync(serviceName, token.Token, triesNumber, RequestType.Post, item);
        }

        public Task<RespostaPadrão> DeleteItemAsync(T item)
        {
            return WebServiceBase<T>.RequestAsync($"{serviceName}/{item.Id}", token.Token, triesNumber, RequestType.Delete);
        }
    }
}
