using BaseApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApp.Data.Interface
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<List<T>> GetItemsAsync();

        Task<List<T>> GetItemsNotDoneAsync();

        Task<T> GetItemAsync(int id);

        Task<int> SaveItemAsync(T item);

        Task<int> DeleteItemAsync(T item);
    }
}
