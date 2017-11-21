using BaseApp.Models.Core;
using BaseApp.Service.Core;
using System.Threading.Tasks;

namespace BaseApp.Service.Interface
{
    public interface IServiceBase<T> where T : ModelBase
    {
        Task<RespostaPadrão> GetItemsAsync();
        
        Task<RespostaPadrão> GetItemAsync(int id);

        Task<RespostaPadrão> SaveItemAsync(T item);

        Task<RespostaPadrão> DeleteItemAsync(T item);
    }
}
