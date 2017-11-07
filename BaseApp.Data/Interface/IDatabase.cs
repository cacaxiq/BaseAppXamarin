using SQLite;

namespace BaseApp.Data.Interface
{
    public interface IDatabase
    {
        SQLiteAsyncConnection DatabaseConnection { get; }
    }
}
