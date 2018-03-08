using SQLite;

namespace BaseApp.LocalDatabase.Interface
{
    public interface IDatabase
    {
        SQLiteAsyncConnection DatabaseConnection { get; }
    }
}
