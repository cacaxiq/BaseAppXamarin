using BaseApp.Data.Interface;
using BaseApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase, new()
    {
        readonly IDatabase Database;
        public Repository(IDatabase _database)
        {
            Database = _database;
        }

        public async Task<List<T>> GetItemsAsync()
        {
            return await Database.DatabaseConnection.Table<T>().ToListAsync();
        }

        public async Task<List<T>> GetItemsNotDoneAsync()
        {
            return await Database.DatabaseConnection.QueryAsync<T>("SELECT * FROM [T] WHERE [Done] = 0");
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Database.DatabaseConnection.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(T item)
        {
            if (item.Id != 0)
            {
                return await Database.DatabaseConnection.UpdateAsync(item);
            }
            else
            {
                return await Database.DatabaseConnection.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(T item)
        {
            return await Database.DatabaseConnection.DeleteAsync(item);
        }
    }
}
