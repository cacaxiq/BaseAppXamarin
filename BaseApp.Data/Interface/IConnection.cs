using SQLite;

namespace BaseApp.Data.Interface
{
    public interface IConnection
    {
        SQLiteAsyncConnection GetConection(string filename);
    }
}
