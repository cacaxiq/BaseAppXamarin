using BaseApp.Data.Interface;
using BaseApp.Infrastructure.Constants;
using SQLite;
using Xamarin.Forms;

namespace BaseApp.Data.Config
{
    public class Database : IDatabase
    {
        private SQLiteAsyncConnection _database;
        public SQLiteAsyncConnection DatabaseConnection
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }

        public Database()
        {
            DatabaseConnection = DependencyService.Get<IConnection>().GetConection(BaseAppConstants.DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            //DatabaseConnection.CreateTableAsync<"ClasseName">().Wait();
        }
    }
}
