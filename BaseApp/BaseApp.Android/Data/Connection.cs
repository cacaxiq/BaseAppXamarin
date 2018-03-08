using BaseApp.LocalDatabase.Interface;
using BaseApp.Droid.Data;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Connection))]
namespace BaseApp.Droid.Data
{
    public class Connection : IConnection
    {
        public SQLiteAsyncConnection GetConection(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return new SQLiteAsyncConnection(Path.Combine(path, filename));
        }
    }
}