using SQLite;

namespace BaseApp.LocalDatabase.Interface
{
    public interface IConnection
    {
        SQLiteAsyncConnection GetConection(string filename);
    }
}
